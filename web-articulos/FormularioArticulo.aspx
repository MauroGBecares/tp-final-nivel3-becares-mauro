<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="web_articulos.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ValidarTexto.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="contenido">
        <div class="row">
            <div class="col-1"></div>
            <div class="col">
                <% if (Request.QueryString["id"] == null)
                    { %>
                <h2 class="my-4 text-decoration-underline">Añadir Articulo</h2>
                <% }
                    else
                    {  %>
                <h2 class="my-4 text-decoration-underline">Modificar Articulo</h2>
                <%} %>
            </div>
        </div>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-4">
                <div class="mb-4">
                    <label for="txtCodigo" class="form-label">Código</label>
                    <asp:TextBox ID="txtCodigo" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div id="mensajeCodigo" class="mensajesTextBox"></div>
                </div>
                <div class="mb-4">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div class="mensajesTextBox"></div>
                </div>
                <div class="mb-4">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-4">
                    <label for="ddlCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-1"></div>
            <div class="col-4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-4">
                            <label for="txtImagenUrl" class="form-label">Imagen URL</label>
                            <asp:TextBox ID="txtImagenUrl" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                        </div>
                        <div class="mb-4">
                            <asp:Image ID="imgArticulo" runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" Width="58%" Height="160.84px" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="mb-4">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="fa-solid fa-dollar-sign"></i></span>
                        <asp:TextBox ID="txtPrecio" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                        <div id="mensajePrecio" class="mensajesTextBox"></div>
                    </div>
                </div>
            </div>
            <div class="col-1"></div>
        </div>
        <div class="row">
            <div class="col-1"></div>
            <div class="col">
                <div class="mb-4">
                    <label for="txtDescripcion" class="form-label">Descripcion</label>
                    <asp:TextBox ID="txtDescripcion" ClientIDMode="Static" TextMode="MultiLine" Rows="3" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div class="mensajesTextBox"></div>
                </div>
            </div>
            <div class="col-1"></div>
        </div>
        <div class="row">
            <div class="col-1"></div>
            <div class="col">
                <div class="d-flex">
                    <div>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClientClick="return validar()" Width="176px" OnClick="btnGuardar_Click" />
                    </div>
                    <div class="ms-auto">
                        <% if (Request.QueryString["id"] != null)
                            {%>
                        <asp:UpdatePanel ID="UpdatePanelEliminar" runat="server">
                            <ContentTemplate>
                                <div class="d-flex flex-column gap-2">
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Width="176px" OnClientClick="cambiarCheckBox();" />
                                    <% if (ConfirmarEliminacion)
                                        { %>
                                    <div class="d-flex gap-1">
                                        <asp:CheckBox ID="chkConfirmarEliminacion" runat="server" />
                                        <label for="chkConfirmarEliminacion" class="form-check-label">Confirmar Eliminacion</label>
                                    </div>
                                    <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Confirmar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" />
                                    <%} %>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%} %>
                    </div>
                </div>
            </div>
            <div class="col-1"></div>
        </div>
    </div>
</asp:Content>
