using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> Lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["user"]))
                {
                    List<Articulo> favoritos = (List<Articulo>)Session["favoritos"];
                    if (favoritos != null)
                    {
                        if (favoritos.Count == 0)
                        {
                            lblMsjFav.Text = "¡Acá podras agregar artículos a tu sección Favoritos 🩵!";
                            lblMsjFav.Visible = true;
                        }

                        Lista = favoritos;
                        RepeaterFavoritos.DataSource = Lista;
                        RepeaterFavoritos.DataBind();
                    }
                    else
                    {
                        lblMsjFav.Text = "¡Acá podras agregar artículos a tu sección Favoritos 🩵!";
                        lblMsjFav.Visible = true;
                    }
                }
            }
        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {

            try
            {
                string id = ((Button)sender).CommandArgument;
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> favoritos = (List<Articulo>)Session["favoritos"];
                Articulo seleccionado = negocio.listar(id).Find(x => x.Id == int.Parse(id));
                favoritos.RemoveAll(x => x.Id == seleccionado.Id);
                Session["favoritos"] = favoritos;

                if (favoritos != null)
                {
                    if (favoritos.Count == 0)
                    {
                        lblMsjFav.Text = "Acá podras agregar artículos a tu sección Favoritos 🩵";
                        lblMsjFav.Visible = true;
                    }

                    Lista = favoritos;
                    RepeaterFavoritos.DataSource = Lista;
                    RepeaterFavoritos.DataBind();
                }
                else
                {
                    lblMsjFav.Text = "¡Acá podras agregar artículos a tu sección Favoritos 🩵";
                    lblMsjFav.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }
    }

}