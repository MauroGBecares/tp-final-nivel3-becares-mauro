<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web_articulos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <h2 class="my-4 text-decoration-underline">Loguearse</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
