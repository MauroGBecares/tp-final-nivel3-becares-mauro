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
    public partial class Detalle : System.Web.UI.Page
    {
        protected Articulos detalleArticulo;
        protected bool esFavorito;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                Response.Redirect("Default.aspx", true);
            foreach (var articulo in (List<Articulos>)Session["listaArticulos"])
            {
                if (articulo.Id == int.Parse(Request.QueryString["id"]))
                {
                    detalleArticulo = articulo;
                }
            }
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                    esFavorito = Seguridad.esFavorito((Users)Session["usuario"], detalleArticulo);
            }
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                FavoritosNegocio favoritosNegocio = new FavoritosNegocio();
                favoritosNegocio.AgregarFavorito((Users)Session["usuario"], detalleArticulo);
                esFavorito = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                FavoritosNegocio favoritosNegocio = new FavoritosNegocio();
                favoritosNegocio.EliminarFavorito((Users)Session["usuario"], detalleArticulo);
                if (Request.QueryString["page"] == "favoritos")
                    Response.Redirect("Favoritos.aspx", false);
                esFavorito = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}