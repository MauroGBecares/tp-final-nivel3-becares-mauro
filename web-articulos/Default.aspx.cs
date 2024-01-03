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
        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}