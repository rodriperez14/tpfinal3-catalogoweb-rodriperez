using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(id))
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        ListaArticulo = negocio.listar(id);
                        RepeaterDetalles.DataSource = ListaArticulo;
                        RepeaterDetalles.DataBind();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void txtRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}