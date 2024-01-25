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
    public partial class Favoritos : System.Web.UI.Page
    {
        private TextBox txtBuscar;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBuscar = (TextBox)Master.FindControl("txtBuscar");
            if (txtBuscar != null)
                txtBuscar.TextChanged += new EventHandler(txtBuscar_TextChanged);
            
            FavoritosNegocio favoritosNegocio = new FavoritosNegocio();
            List<dominio.Favoritos> favoritos = favoritosNegocio.listarFavoritos((Users)Session["usuario"]);
            List<Articulos> listaArticulosFavoritos = new List<Articulos>();
            foreach (var item in favoritos)
            {
                listaArticulosFavoritos.Add(item.Articulo);
            }
            Session.Add("listaFavoritos", listaArticulosFavoritos);
            if (!IsPostBack)
            {
                repeaterFavoritos.DataSource = Session["listaFavoritos"];
                repeaterFavoritos.DataBind();
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect($"Detalle.aspx?id={id}&page=favoritos");
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaFavoritos"];
            List<Articulos> listaFiltro = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            repeaterFavoritos.DataSource = listaFiltro;
            repeaterFavoritos.DataBind();
        }
    }
}