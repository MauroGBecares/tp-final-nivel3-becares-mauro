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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    MarcasNegocio marcasNegocio = new MarcasNegocio();
                    CategoriasNegocio categoriasNegocio = new CategoriasNegocio();
                    List<Marcas> listaMarcas = marcasNegocio.listarMarcas();
                    List<Categorias> listaCategorias = categoriasNegocio.listarCategorias();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField= "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : string.Empty;
                if (!string.IsNullOrEmpty(id) && !IsPostBack) 
                {
                    txtCodigo.Enabled = false;
                    ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                    Articulos seleccionado = (articulosNegocio.listar(id))[0];

                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    imgArticulo.ImageUrl = txtImagenUrl.Text;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                Articulos articulo = new Articulos();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.UrlImagen = txtImagenUrl.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articulo.Marca = new Marcas();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Categoria = new Categorias();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    articulo.Id = int.Parse(Request.QueryString["id"]);
                    articulosNegocio.ModificarArticulo(articulo);
                }
                else
                {
                    articulosNegocio.AgregarArticulo(articulo);
                }

                Response.Redirect("Admin.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                    articulosNegocio.eliminarArticulo(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("Admin.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}