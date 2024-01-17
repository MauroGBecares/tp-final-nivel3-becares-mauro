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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                    Session.Add("listaArticulos", articulosNegocio.listar());
                }
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();    
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect($"FormularioArticulo.aspx?id={id}");
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> listaArticulos = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltroRapido.Enabled = !chkFiltroAvanzado.Checked;
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void btnBuscarAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                dgvArticulos.DataSource = articulosNegocio.filtro(ddlCampo.Text, ddlCriterio.Text, txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            switch (ddlCampo.Text)
            {
                case "Código":
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Igual");
                    break;
                case "Precio":
                    ddlCriterio.Items.Add("Menos a");
                    ddlCriterio.Items.Add("Igual");
                    ddlCriterio.Items.Add("Mayor a");
                    break;
                default:
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Termina con");
                    break;
            }
        }
    }
}