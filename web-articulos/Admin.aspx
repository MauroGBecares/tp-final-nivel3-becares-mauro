<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="web_articulos.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contenido py-3">
        <div class="container">
            <div class="row">
                <div class="col-6">
                    <div class="mb-3 d-flex mx-2">
                        <label for="txtFiltroRapido" class="form-label my-1">Filtro</label>
                        <asp:TextBox ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control mx-3" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6">
                    <div class="form-check d-flex gap-2">
                        <asp:CheckBox ID="chkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
                        <label for="chkFiltroAvanzado" class="form-check-label">Activar Filtro Avanzado</label>
                        <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar Filtro" CssClass="btn btn-outline-primary ms-auto" OnClick="btnLimpiarFiltro_Click" />
                    </div>
                </div>
            </div>
            <%if (chkFiltroAvanzado.Checked)
                { %>
            <div class="row">
                <div class="col-4">
                    <div class="mb-3 d-flex">
                        <label for="ddlCampo" class="my-1 mx-2">Campo</label>
                        <asp:DropDownList ID="ddlCampo" CssClass="form-select" runat="server">
                            <asp:ListItem Text="Código" />
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Descripción" />
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-4">
                    <div class="mb-3 d-flex">
                        <label for="txtFiltroAvanzado" class="my-1 mx-2">Filtro</label>
                        <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-4">
                    <div class="mb-3 d-flex">
                        <asp:Button ID="btnBuscarAvanzado" runat="server" Text="Buscar" OnClick="btnBuscarAvanzado_Click" CssClass="btn btn-outline-primary" />
                    </div>
                </div>
            </div>
            <%} %>
            <div class="row">
                <div class="col-12">
                    <asp:GridView ID="dgvArticulos" CssClass="table table-striped" AutoGenerateColumns="false" runat="server"
                        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                        AllowPaging="True" PageSize="5" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="Codigo" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CommandName="Select">
                                    <i class="fa-regular fa-pen-to-square"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
                </div>
                <div class="col"></div>
                <div class="col-2">
                    <a href="ASD" class="btn btn-danger">Seleccionar para borrar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
