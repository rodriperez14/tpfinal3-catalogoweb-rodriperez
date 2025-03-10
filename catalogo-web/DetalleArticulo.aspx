<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="catalogo_web.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerDetalle" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanelDetalle">
        <ContentTemplate>
            <div class="d-flex justify-content-center align-items-center min-vh-100">
                <div class="row row-cols-1 row-cols-md-2 g-4 text-center w-100">
                    <asp:Repeater ID="RepeaterDetalles" runat="server">
                        <ItemTemplate>
                            <div class="col mx-auto">
                                <div class="card mb-3">
                                    <img src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://imgs.search.brave.com/TvImnNqSmkLvWLy9Y1Hkith2FQJECMibPyhZ122wNb0/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/dmVjdG9yLWdyYXRp/cy9pbHVzdHJhY2lv/bi1jb25jZXB0by1j/YXJwZXRhLWltYWdl/bmVzXzExNDM2MC0x/MTQuanBnP3NlbXQ9/YWlzX2h5YnJpZA" : Eval("ImagenUrl") %>" class="card-img-top" alt="<%#Eval("Nombre") %>">
                                    <div class="card-body">
                                        <h5 class="card-title">Nombre: <%#Eval("Nombre") %></h5>
                                        <p class="card-text">Codigo: <%#Eval("Codigo") %></p>
                                        <p class="card-text">Descripcion: <%#Eval("Descripcion") %></p>
                                        <p class="card-text">Marca: <%#Eval("Marca.Descripcion") %></p>
                                        <p class="card-text">Categoria: <%#Eval("Categoria.Descripcion") %></p>
                                        <p class="card-text">Precio: <%#Eval("Precio","{0:F2}") %></p>
                                       <%-- <%if (negocio.Seguridad.sesionActiva(Session["user"]))
                                            { %>
                                        <asp:Button runat="server" ID="btnFavoritos" CssClass="btn btn-success" Text="Agregar a favoritos" OnClick="btnFavoritos_Click" CommandArgument='<%#Eval("Id")%>' CommandName="IdPokeFav" />
                                        <asp:Label runat="server" ID="lblFavoritos" Text="" Visible="false" CssClass="alert alert-info" />
                                        <%} %>--%>
                                    </div>
                                </div>
                                <div>
                                    <asp:Button Text="Regresar a Home" ID="txtRegresar" CssClass="btn btn-info" runat="server" OnClick="txtRegresar_Click" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
