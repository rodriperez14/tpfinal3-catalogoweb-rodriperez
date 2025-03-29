<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="catalogo_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Favoritos</h1>
    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-4">
        <asp:Repeater ID="RepeaterFavoritos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card mb-3 h-100">
                        <img src="<%# string.IsNullOrEmpty((string)Eval("ImagenUrl")) || !Eval("ImagenUrl").ToString().Contains("http") ? "https://procircuit.cl/cdn/shop/files/Producto_sin_foto_73f4f3b6-767d-47b0-a47e-6c39e976dd26.png?v=1713311694" : Eval("ImagenUrl") %>" class="card-img-top img-fluid" alt="<%#Eval("Nombre") %>">
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">Nombre: <%#Eval("Nombre") %></h5>                          
                            <p class="card-text">Descripcion: <%#Eval("Descripcion") %></p>
                            <p class="card-text">Marca: <%#Eval("Marca.Descripcion") %></p>
                            <p class="card-text">Categoria: <%#Eval("Categoria.Descripcion") %></p>
                            <p class="card-text">Precio: $<%#Eval("Precio","{0:F2}") %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Label runat="server" ID="lblMsjFav" CssClass="alert alert-info" Text="" Visible="false" />
    </div>
</asp:Content>
