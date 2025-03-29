using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace catalogo_web
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        public bool AgregarMarca { get; set; }
        public bool AgregarCategoria { get; set; }

        List<Electronica> listarMarca { get; set; }
        List<Electronica> listarCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            AgregarMarca = false;
            AgregarCategoria = false;
            btnEliminar.Visible = false;

            try
            {
                //CONFIGURACION INICIAL
                if (!IsPostBack)
                {
                    ElectronicaNegocio negocio = new ElectronicaNegocio();
                    List<Electronica> lista = negocio.listarCategoria();
                    List<Electronica> lista2 = negocio.listarMarca();

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = lista2;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }
                //CONFIGURACION SI ESTAMOS MODIFICANDO
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)

                {
                    btnEliminar.Visible = true;

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> lista = negocio.listar(id);
                    Articulo seleccionado = lista[0];

                    //PRECARGAR LOS DATOS
                    txtId.Text = id;
                    //txtCodigo.Text = seleccionado.Codigo;
                    txtCodigo.Text = string.IsNullOrEmpty(seleccionado.Codigo) ? txtCodigo.Text : seleccionado.Codigo;
                    //txtNombre.Text = seleccionado.Nombre;
                    txtNombre.Text = string.IsNullOrEmpty(seleccionado.Nombre) ? txtNombre.Text : seleccionado.Nombre;
                    //txtDescripcion.Text = seleccionado.Descripcion;
                    txtDescripcion.Text = string.IsNullOrEmpty(seleccionado.Descripcion) ? txtDescripcion.Text : seleccionado.Descripcion;
                    //txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtImagenUrl.Text = string.IsNullOrEmpty(seleccionado.ImagenUrl) ? txtImagenUrl.Text : seleccionado.ImagenUrl;

                    txtPrecio.Text = seleccionado.Precio.ToString("F2");
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                //nuevo.Codigo = txtCodigo.Text;
                //nuevo.Nombre = txtNombre.Text;
                //nuevo.Descripcion = txtDescripcion.Text;
                //nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Codigo = txtCodigo.Text != "" ? txtCodigo.Text : null;
                nuevo.Nombre = txtNombre.Text != "" ? txtNombre.Text : null;
                nuevo.Descripcion = txtDescripcion.Text != "" ? txtDescripcion.Text : null;
                nuevo.ImagenUrl = txtImagenUrl.Text != "" ? txtImagenUrl.Text : null;

                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Marca = new Electronica();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Electronica();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                    negocio.agregar(nuevo);

                Response.Redirect("ArticulosLista.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
      
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImagenUrl.Text) || !txtImagenUrl.Text.ToString().Contains("http"))
                imgArticulo.ImageUrl = "https://procircuit.cl/cdn/shop/files/Producto_sin_foto_73f4f3b6-767d-47b0-a47e-6c39e976dd26.png?v=1713311694";
            else
                imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ArticulosLista.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            AgregarMarca = true;
            lblAgregarMarca.Visible = false;
        }

        protected void btnCofirmarMarcar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ElectronicaNegocio electronicaNegocio = new ElectronicaNegocio();

            try
            {
                if (!string.IsNullOrEmpty(txtAgregarMarca.Text))
                {
                    listarMarca = electronicaNegocio.listarMarca();
                    var marcaExistente = listarMarca.Find(x => x.Descripcion.ToLower() == txtAgregarMarca.Text.ToLower());

                    if (marcaExistente == null)
                    {
                        negocio.agregarMarca(txtAgregarMarca.Text);

                        listarMarca = electronicaNegocio.listarMarca();

                        ddlMarca.DataSource = listarMarca;
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataTextField = "Descripcion";
                        ddlMarca.DataBind();

                        lblAgregarMarca.Text = "¡Marca agregada con éxito!";
                        lblAgregarMarca.Visible = true;
                    }
                    else
                    {
                        lblAgregarMarca.Text = "Esa marca ya existe";
                        lblAgregarMarca.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            AgregarCategoria = true;
            lblAgregarCategoria.Visible = false;
        }

        protected void btnConfirmarCategoria_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ElectronicaNegocio electronicaNegocio = new ElectronicaNegocio();

            try
            {
                if (!string.IsNullOrEmpty(txtAgregarCategoria.Text))
                {
                    listarCategoria = electronicaNegocio.listarCategoria();
                    var categoriaExistente = listarCategoria.Find(x => x.Descripcion.ToLower() == txtAgregarCategoria.Text.ToLower());

                    if (categoriaExistente == null)
                    {
                        negocio.agregarCategoria(txtAgregarCategoria.Text);

                        listarCategoria = electronicaNegocio.listarCategoria();

                        ddlCategoria.DataSource = listarCategoria;
                        ddlCategoria.DataValueField = "Id";
                        ddlCategoria.DataTextField = "Descripcion";
                        ddlCategoria.DataBind();

                        lblAgregarCategoria.Text = "¡Categoria agregada con éxito!";
                        lblAgregarCategoria.Visible = true;
                    }
                    else
                    {
                        lblAgregarCategoria.Text = "Esa categoria ya existe";
                        lblAgregarCategoria.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}