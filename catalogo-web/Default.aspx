<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="catalogo_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <%if (!negocio.Seguridad.sesionActiva(Session["user"]))
        { %>
    <h1>¡Hola!</h1>
    <h4>Bienvenido a "Gestor de productos Web"</h4>
    <%}
        else
        {%>
    <h1>
        <asp:Label runat="server" Text="Saludo" ID="lblSaludo" /></h1>
    <h4>Bienvenido a "Gestor de productos Web"</h4>
    <%} %>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://procircuit.cl/cdn/shop/files/Producto_sin_foto_73f4f3b6-767d-47b0-a47e-6c39e976dd26.png?v=1713311694" : Eval("ImagenUrl") %>" class="card-img-top" alt="<%#Eval("Nombre") %>">
                        <div class="card-body">
                            <h4 class="card-title"><%#Eval("Nombre") %></h4>
                            <h6 class="card-text">$<%#Eval("Precio","{0:F2}") %></h6>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <a class="btn btn-info" href="DetalleArticulo.aspx?id=<%#Eval("Id")%>">Ver detalle</a>
                                    <%if (negocio.Seguridad.sesionActiva(Session["user"]))
                                        { %>
                                    <asp:Button Text="🩵" CssClass="btn btn-outline-primary" ID="btnFavoritos" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnFavoritos_Click" />
                                    <asp:Label runat="server" ID="lblFavoritos" Text="" Visible="false" CssClass="alert alert-info" />
                                    <%} %>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
