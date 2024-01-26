using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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
            if (Validacion.esVacio(txtEmail, txtApellido, txtNombre, txtImagen))
                return;
            if (!Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                return;

            UsersNegocio negocio = new UsersNegocio();
            Users user = (Users)Session["usuario"];

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
                if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                    img.ImageUrl = $"~/Images/Perfiles/{user.UrlImagenPerfil}";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}