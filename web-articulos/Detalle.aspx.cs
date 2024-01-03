using dominio;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var articulo in (List<Articulos>)Session["listaArticulos"])
            {
                if (articulo.Id == int.Parse(Request.QueryString["id"]))
                {
                    detalleArticulo = articulo;
                }
            }
        }
    }
}