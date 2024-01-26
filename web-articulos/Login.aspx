<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web_articulos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ValidarTexto.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <h2 class="my-4 text-decoration-underline">Loguearse</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div class="mensajesTextBox"></div>
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox TextMode="Password" ClientIDMode="Static" ID="txtPass" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div class="mensajesTextBox"></div>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" OnClientClick="return validar()" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
