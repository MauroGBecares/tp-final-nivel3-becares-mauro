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
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Registro || Page is Login || Page is Default || Page is Detalle))
            {
                if (!Seguridad.sessionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
                if (Session["usuario"] != null)
                {
                    Users user = (Users)Session["usuario"];
                    if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgAvatar.ImageUrl = $"~/Images/Perfiles/{user.UrlImagenPerfil}";
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}