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

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                Button btn = (Button)sender;
                RepeaterItem i = (RepeaterItem)btn.NamingContainer;
                Label lblFavoritos = (Label)i.FindControl("lblFavoritos");

                string valor = ((Button)sender).CommandArgument;
                Articulo seleccionado = negocio.listar(valor).Find(x => x.Id == int.Parse(valor));
                List<Articulo> favoritos = (List<Articulo>)Session["favoritos"];

                if (favoritos == null)
                    favoritos = new List<Articulo>();
                if (!favoritos.Any(x => x.Id == seleccionado.Id))
                {
                    favoritos.Add(seleccionado);
                    Session["favoritos"] = favoritos;
                    btn.Visible = false;


                    lblFavoritos.Text = "¡Agregado a Favoritos!";
                    lblFavoritos.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}