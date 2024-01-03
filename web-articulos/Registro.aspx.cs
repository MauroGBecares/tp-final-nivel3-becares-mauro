using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_articulos
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            UsersNegocio negocio = new UsersNegocio();
            Users user = new Users();
            try
            {
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                user.Apellido = txtApellido.Text;
                user.Nombre = txtNombre.Text;
                user.Id = negocio.registrarUsuario(user);
                Session.Add("usuario", user);
                Response.Redirect("MiPerfil.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}