<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="web_articulos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/MaxContentHeight.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="row">
            <div class="col"></div>
            <div class="col-8">
                <div class="card mb-3">
                    <img src="<%: detalleArticulo.UrlImagen %>" height="500" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%: detalleArticulo.Nombre %></h5>
                        <p class="card-text"><%: detalleArticulo.Descripcion %></p>
                        <p class="card-text">Marca: <%: detalleArticulo.Marca.Descripcion %></p>
                        <p class="card-text">Categoria: <%: detalleArticulo.Categoria.Descripcion %></p>
                        <p class="card-text"><b>Precio: $ <%: detalleArticulo.Precio %></b></p>
                    </div>
                    <div class="d-flex justify-content-center py-1 gap-2">
                        <% if (Request.QueryString["page"] == "favoritos")
                            { %>
                        <a href="Favoritos.aspx" class="btn btn-primary">Regresar</a>
                        <%}
                            else
                            {  %>
                        <a href="Default.aspx" class="btn btn-primary">Regresar</a>
                        <%} %>
                        <% if (Session["usuario"] != null)
                            { %>
                        <%if (!esFavorito)
                            { %>
                        <asp:Button ID="btnAgregarFavorito" runat="server" Text="Agregar a Favoritos" CssClass="btn btn-outline-primary" OnClick="btnAgregarFavorito_Click" />
                        <%}
                            else
                            { %>
                        <asp:Button ID="btnEliminarFavorito" runat="server" Text="Eliminar de Favoritos" CssClass="btn btn-outline-danger" OnClick="btnEliminarFavorito_Click" />
                        <%} %>
                        <%} %>
                    </div>
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
