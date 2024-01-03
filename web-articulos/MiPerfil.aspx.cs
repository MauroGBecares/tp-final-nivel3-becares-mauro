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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sessionActiva(Session["usuario"]))
                    {
                        Users user = (Users)Session["usuario"];
                        txtEmail.Text = user.Email;
                        txtEmail.Enabled = false;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                            imgPerfil.ImageUrl = $"~/Images/Perfiles/{user.UrlImagenPerfil}";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsersNegocio negocio = new UsersNegocio();
            Users user = new Users();
            try
            {
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/Perfiles/");
                    txtImagen.PostedFile.SaveAs($"{ruta}perfil-foto-{user.Id}.jpg");
                    user.UrlImagenPerfil = $"perfil-foto-{user.Id}.jpg";
                }
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.actualizarUsuario(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = $"~/Images/Perfiles/{user.UrlImagenPerfil}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}