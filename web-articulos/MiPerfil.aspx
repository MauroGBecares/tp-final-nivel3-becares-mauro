<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="web_articulos.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ValidarTexto.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenido">
        <div class="row">
            <div class="col-2"></div>
            <div class="col">
                <h2 class="my-4 text-decoration-underline">Mi Perfil</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-2"></div>
            <div class="col-3 d-flex flex-column gap-4">
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" ClientIDMode="Static" CssClass="form-control cajasTexto" runat="server"></asp:TextBox>
                    <div id="mensajeEmail" class="mensajesTextBox"></div>
                </div>
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
            <div class="col-1"></div>
            <div class="col-4">
                <div class="mb-3">
                    <label class="form-label" for="txtImagen">Imagen Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                    <div class="mensajesTextBox"></div>
                </div>
                <asp:Image ID="imgPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                    runat="server" CssClass="img-fluid mb-3" Height="350" />
            </div>
        </div>
        <div class="row">
            <div class="col-2"></div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button ID="btnGuardar" runat="server" OnClientClick="return validar()" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <a href="Default.aspx">Regresar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
