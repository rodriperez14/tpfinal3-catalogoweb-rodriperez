<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="catalogo_web.ArticulosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Articulos</h1>

    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="true" PageSize="5">     
        
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />
        </Columns>
    </asp:GridView>

    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
