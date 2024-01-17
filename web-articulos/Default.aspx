<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_articulos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/MaxContentHeight.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="row row-cols-1 row-cols-md-2 g-4 py-3">
            <asp:Repeater ID="repeaterArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%# Eval("UrlImagen") %>" height="400 " class="card-img-top" alt="...">
                            <div class="card-body">
                                <h4 class="card-title"><%# Eval("Nombre") %></h4>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p><b>$ <%# Eval("Precio") %></b></p>
                            </div>
                            <div class="d-flex justify-content-center py-2">
                                <asp:Button ID="btnDetalle" runat="server" Text="Ver Articulo" OnClick="btnDetalle_Click" CommandArgument='<%# Eval("Id") %>' CommandName="ArticuloId" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
