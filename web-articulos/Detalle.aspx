<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="web_articulos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/Default.css" rel="stylesheet" />
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
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
