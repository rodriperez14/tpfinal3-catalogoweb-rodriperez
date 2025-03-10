using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace catalogo_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listar2();

            if (!IsPostBack)
            {
                if (!Seguridad.sesionActiva(Session["user"]))
                {
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
                else
                {
                    User user = (User)Session["user"];
                    if (!string.IsNullOrEmpty(user.Nombre))
                        lblSaludo.Text = "¡Hola " + user.Nombre + "!";
                     else
                        lblSaludo.Text = "¡Hola " + user.Email + "!";

                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
               
            }
          
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}