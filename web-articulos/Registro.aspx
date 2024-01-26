<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="web_articulos.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ValidarTexto.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="row">
            <div class="col-2"></div>
            <div class="col">
                <h2 class="my-4 text-decoration-underline">Registrarse</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-2"></div>
            <div class="col-3">
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div id="mensajeEmail" class="mensajesTextBox"></div>
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox TextMode="Password" ClientIDMode="Static" ID="txtPass" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div class="mensajesTextBox"></div>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrarse" OnClientClick="return validar()" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="col-1"></div>
            <div class="col-3">
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div class="mensajesTextBox"></div>
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div class="mensajesTextBox"></div>
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
