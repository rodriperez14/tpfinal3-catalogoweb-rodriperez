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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();

            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx");
                }

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (System.Threading.ThreadAbortException ex) { }

            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

}

        protected void btnCancelarLogin_Click(object sender, EventArgs e)
        {

        }
        //private void Page_Error(object sender, EventArgs e)
        //{
        //    Exception exc = Server.GetLastError();

        //    Session.Add("error", exc.ToString());

        //    Server.Transfer("Error.aspx");
        //}
    }
}