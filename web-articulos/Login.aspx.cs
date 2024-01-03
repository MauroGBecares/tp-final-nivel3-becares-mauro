using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_articulos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsersNegocio negocioUser = new UsersNegocio();
            Users user = new Users();
            try
            {
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                if (negocioUser.Loguearse(user))
                {
                    Session.Add("usuario", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}