<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="catalogo_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (!negocio.Seguridad.sesionActiva(Session["user"]))
        { %>
            <h1>¡Hola!</h1>
            <h4>Bienvenido a "Gestor de productos Web"</h4>
    <%}
      else {%>
        <asp:Label Text="Saludo" ID="lblSaludo" Font-Bold="true" Font-Size="35px"  runat="server" />
        <h4>Bienvenido a "Gestor de productos Web"</h4>
   <%} %>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Precio","{0:F2}") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id")%>">Ver detalle</a>
                            <asp:Button Text="Ver detalle" class="btn btn-light" ID="btnDetalle" runat="server"/>                 
                            <asp:Button Text="Ejemplo" CssClass="btn btn-primary" ID="btnEjemplo" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEjemplo_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
