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
                                    <img src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://procircuit.cl/cdn/shop/files/Producto_sin_foto_73f4f3b6-767d-47b0-a47e-6c39e976dd26.png?v=1713311694" : Eval("ImagenUrl") %>" class="card-img-top" alt="<%#Eval("Nombre") %>">
                                    <div class="card-body">
                                        <h5 class="card-title">Nombre: <%#Eval("Nombre") %></h5>
                                        <p class="card-text">Codigo: <%#Eval("Codigo") %></p>
                                        <p class="card-text">Descripcion: <%#Eval("Descripcion") %></p>
                                        <p class="card-text">Marca: <%#Eval("Marca.Descripcion") %></p>
                                        <p class="card-text">Categoria: <%#Eval("Categoria.Descripcion") %></p>
                                        <p class="card-text">Precio: $<%#Eval("Precio","{0:F2}") %></p>                                      
                                    </div>
                                </div>
                                <div>
                                    <asp:Button Text="Regresar a Home" ID="txtRegresar" CssClass="btn btn-primary" runat="server" OnClick="txtRegresar_Click" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
