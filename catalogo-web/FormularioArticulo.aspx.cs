using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace catalogo_web
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
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
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redireccion pantalla de error
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.precio = decimal.Parse(txtPrecio.Text);

                nuevo.Marca = new Electronica();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Electronica();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                negocio.agregarConSP(nuevo);
                Response.Redirect("ArticulosLista.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
    }
}