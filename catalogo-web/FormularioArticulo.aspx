<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="catalogo_web.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }

        .validacion2 {
            color: green;
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

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id: </label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="20" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo numeros o letras." ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z0-9 ]+$" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtPrecio" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo numeros" ControlToValidate="txtPrecio" ValidationExpression="^(\d{1}\.)?(\d+\.?)+(,\d{2})?$" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca: </label>
                        <asp:DropDownList ID="ddlMarca" CssClass="btn btn-secondary" runat="server"></asp:DropDownList>
                        <asp:Button Text="Agregar Marca" ID="btnAgregarMarca" CssClass="btn btn-outline-secondary" OnClick="btnAgregarMarca_Click" runat="server" />
                        <asp:Label Text="" ID="lblAgregarMarca" CssClass="validacion2" Visible="false" runat="server" />
                    </div>           
                    <%if (AgregarMarca)
                        { %>
                    <div class="mb-3">
                        <label class="form-label">Nueva Marca:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtAgregarMarca" />
                        <asp:RegularExpressionValidator ErrorMessage="Solo letras" CssClass="validacion" ControlToValidate="txtAgregarMarca" ValidationExpression="^[a-zA-Z]+$" runat="server" />
                        <div class="d-grid gap-2 col-3 mx-auto">
                            <asp:Button Text="Agregar" ID="btnCofirmarMarcar" CssClass="btn btn-outline-primary" OnClick="btnCofirmarMarcar_Click" runat="server" />
                        </div>
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoria: </label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="btn btn-secondary" runat="server"></asp:DropDownList>
                        <asp:Button Text="Agregar Categoria" ID="btnAgregarCategoria" CssClass="btn btn-outline-secondary" OnClick="btnAgregarCategoria_Click" runat="server" />
                        <asp:Label Text="" ID="lblAgregarCategoria" CssClass="validacion2" Visible="false" runat="server" />
                    
                    </div>
                    <%if (AgregarCategoria)
                        { %>
                    <div class="mb-3">
                        <label class="form-label">Nueva Categoria:</label>
                        <asp:TextBox CssClass="form-control" ID="txtAgregarCategoria" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="Solo letras" CssClass="validacion" ControlToValidate="txtAgregarCategoria" ValidationExpression="^[a-zA-Z]+$" runat="server" />
                        <div class="d-grid gap-2 col-3 mx-auto">
                            <asp:Button Text="Agregar" ID="btnConfirmarCategoria" CssClass="btn btn-outline-primary" OnClick="btnConfirmarCategoria_Click" runat="server" />
                        </div>
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="d-grid gap-2">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a class="btn btn-outline-secondary" href="ArticulosLista.aspx">Cancelar</a>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="d-grid gap-2">
                            <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" runat="server" />
                        </div>
                        <%if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-danger" runat="server" />
                        </div>
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen: </label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://procircuit.cl/cdn/shop/files/Producto_sin_foto_73f4f3b6-767d-47b0-a47e-6c39e976dd26.png?v=1713311694"
                        runat="server" CssClass="centered-image" ID="imgArticulo" Width="75%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
