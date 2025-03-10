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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["user"]))
                    {
                        User user = (User)Session["user"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    Page.Validate();
                    if (!Page.IsValid)
                        return;

                    UserNegocio negocio = new UserNegocio();
                    User user = (User)Session["user"];

                    if (txtImagen.PostedFile.FileName != "")
                    {
                        string ruta = Server.MapPath("./Images/");
                        txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                        user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                    }

                    Image img = (Image)Master.FindControl("imgAvatar");
                    img.ImageUrl = "~/Images/" + user.ImagenPerfil;

                    if (txtNombre.Text == "")
                        user.Nombre = null;
                    else
                        user.Nombre = txtNombre.Text;

                    if (txtApellido.Text == "")
                        user.Apellido = null;
                    else
                        user.Apellido = txtApellido.Text;

                    negocio.actualizar(user);
                    //Session.Add("user", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}