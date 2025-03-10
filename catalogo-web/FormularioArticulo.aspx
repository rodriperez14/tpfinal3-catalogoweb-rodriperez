<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="catalogo_web.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="20" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo numeros o letras." ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z0-9 ]+$" runat="server"  />
            </div>

            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca: </label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Este campo es requerido." ControlToValidate="txtPrecio" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo numeros" ControlToValidate="txtPrecio" ValidationExpression="^(\d{1}\.)?(\d+\.?)+(,\d{2})?$" runat="server" />
            </div>
            <div class="d-grid gap-2">
                <asp:Button Text="Aceptar/Modificar" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" runat="server" />
                <a class="btn btn-outline-dark" href="ArticulosLista.aspx">Cancelar</a>
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
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1SUJxGrRAinWDNX-bL1hYT9OSHsaTJZaErw&s"
                        runat="server" ID="imgArticulo" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <%-- <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                    </div>
                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>--%>
</asp:Content>
