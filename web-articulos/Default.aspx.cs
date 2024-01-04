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
    public partial class Default : System.Web.UI.Page
    {
        private TextBox txtBuscar;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBuscar = (TextBox)Master.FindControl("txtBuscar");
            if (txtBuscar != null)
                txtBuscar.TextChanged += new EventHandler(txtBuscar_TextChanged);

            ArticulosNegocio negocio = new ArticulosNegocio();
            Session.Add("listaArticulos", negocio.listar());
            if (!IsPostBack)
            {
                repeaterArticulos.DataSource = Session["listaArticulos"];
                repeaterArticulos.DataBind();
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect($"Detalle.aspx?id={id}");
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltro = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            repeaterArticulos.DataSource = listaFiltro;
            repeaterArticulos.DataBind();
        }
    }
}