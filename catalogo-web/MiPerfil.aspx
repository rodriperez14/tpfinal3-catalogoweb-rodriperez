<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="catalogo_web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }

        .centered-image {
            display: block;
            margin-left: auto;
            margin-right: auto;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>Mi Perfil</h1>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El email es requerido." ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo formato email" ControlToValidate="txtEmail" 
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />                
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo formato letras" ControlToValidate="txtNombre" 
                   ValidationExpression="^[a-zA-Z]+$" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo formato letras" ControlToValidate="txtApellido"
                   ValidationExpression="^[a-zA-Z]+$" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label">Imagen Perfil</label>
                        <input type="file" id="txtImagen" runat="server" class="form-control" />
                    </div>
                    <asp:Image ID="imgNuevoPerfil" ImageUrl="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_640.png"
                        runat="server" CssClass="centered-image" Width="75%" />
                    <script>
                        const fileInput = document.getElementById('<%= txtImagen.ClientID %>');
                        const preview = document.getElementById('<%= imgNuevoPerfil.ClientID %>');

                        fileInput.addEventListener('change', function (event) {
                            const file = event.target.files[0];
                            if (file) {
                                const reader = new FileReader();
                                reader.onload = function (e) {
                                    preview.src = e.target.result;
                                    preview.style.display = 'block';
                                };
                                reader.readAsDataURL(file);
                            }
                        });
                    </script>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
            <a href="/" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>
