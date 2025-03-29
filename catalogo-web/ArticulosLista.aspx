﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="catalogo_web.ArticulosLista" %>

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
    <h1>Lista de Articulos</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
                        <asp:RegularExpressionValidator ErrorMessage="Solo letras" CssClass="validacion" ControlToValidate="txtFiltro"
                            ValidationExpression="^[a-zA-Z]+$" runat="server" />
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado"
                            runat="server" CssClass="ajusteCheckbox" ID="chkAvanzado"
                            AutoPostBack="true"
                            OnCheckedChanged="chkAvanzado_CheckedChanged" />
                        <style>
                            .ajusteCheckbox {
                                position: relative;
                                top: -20px;
                            }
                        </style>

                    </div>
                </div>

                <%if (chkAvanzado.Checked)
                    { %>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Campo" runat="server" />
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                                <asp:ListItem Text="" Value="" Selected="True" />
                                <asp:ListItem Text="Nombre" />
                                <asp:ListItem Text="Precio" />
                                <asp:ListItem Text="Marca" />
                                <asp:ListItem Text="Categoria" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Seleccione una opción." CssClass="validacion" ControlToValidate="ddlCampo" runat="server" />
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Criterio" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Filtro" runat="server" />
                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                            <asp:Label Text="" ID="lblMensajeError" Visible="false" CssClass="validacion" runat="server" />
                        </div>
                    </div>
                    <div class="col-3" style="display: flex; position: relative; top: -24px; flex-direction: column; justify-content: flex-end;">
                        <div class="mb-3">
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
                <%} %>
            </div>
            <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id"
                CssClass="table table-dark table-bordered" AutoGenerateColumns="false"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="d-grid gap-2 col-3 mx-auto">
        <asp:Button Text="Agregar articulo" ID="btnAgregarArticulo" class="btn btn-primary" runat="server" CausesValidation="false" OnClick="btnAgregarArticulo_Click" />
    </div>
</asp:Content>
