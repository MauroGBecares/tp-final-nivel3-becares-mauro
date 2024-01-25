<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="web_articulos.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox TextMode="Password" ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrarse" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="col-1"></div>
            <div class="col-3">
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>
