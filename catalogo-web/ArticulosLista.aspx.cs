﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace catalogo_web
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.esAdmin(Session["user"]))
            {
                Session.Add("error", "Se requiere permisos de admin para acceder a esta pantalla.");
                Response.Redirect("Error.aspx");
            }

            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar2());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }

        }
        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }
        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["listaFiltrada"] != null)
                dgvArticulos.DataSource = Session["listaFiltrada"];
            else
                dgvArticulos.DataSource = Session["listaArticulos"];

            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }
        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedItem.ToString() == "Nombre")
            {
                txtFiltroAvanzado.Enabled = true;
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");

            }
            else if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                txtFiltroAvanzado.Enabled = true;
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else if (ddlCampo.SelectedItem.ToString() == "Marca")
            {

                txtFiltroAvanzado.Text = "";
                txtFiltroAvanzado.Enabled = false;
                ddlCriterio.Items.Add("Samsung");
                ddlCriterio.Items.Add("Apple");
                ddlCriterio.Items.Add("Sony");
                ddlCriterio.Items.Add("Huawei");
                ddlCriterio.Items.Add("Motorola");
            }
            else
            {
                txtFiltroAvanzado.Text = "";
                txtFiltroAvanzado.Enabled = false;
                ddlCriterio.Items.Add("Celulares");
                ddlCriterio.Items.Add("Televisores");
                ddlCriterio.Items.Add("Media");
                ddlCriterio.Items.Add("Audio");
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string opcionSeleccionada = ddlCampo.SelectedValue;
                string inputUsuario = txtFiltroAvanzado.Text;

                if (!txtFiltroAvanzado.Enabled)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                        ddlCriterio.SelectedItem.ToString(),
                        txtFiltroAvanzado.Text);
                    dgvArticulos.DataBind();
                }

                if (opcionSeleccionada == "Nombre")
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(inputUsuario, @"^[a-zA-Z]+$"))
                    {
                        lblMensajeError.Visible = true;
                        lblMensajeError.Text = "Ingrese solo letras.";
                    }
                    else
                    {
                        lblMensajeError.Visible = false;
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                            ddlCriterio.SelectedItem.ToString(),
                            txtFiltroAvanzado.Text);
                        dgvArticulos.DataBind();
                    }
                    
                }
                else if (opcionSeleccionada == "Precio")
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(inputUsuario, @"^[0-9]+$"))
                    {
                        lblMensajeError.Visible = true;
                        lblMensajeError.Text = "Ingrese solo números.";
                    }
                    else
                    {
                        lblMensajeError.Visible = false;
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                            ddlCriterio.SelectedItem.ToString(),
                            txtFiltroAvanzado.Text);
                        dgvArticulos.DataBind();
                    }
                }
                               
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FormularioArticulo.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}