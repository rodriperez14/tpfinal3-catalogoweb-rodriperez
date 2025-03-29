<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="catalogo_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center align-items-center vh-90 mx-0">
        <div class="col-12 col-md-10 col-lg-6">
            <h2 class="text-center mb-4">Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Formato email por favor" ControlToValidate="txtEmail"
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                    runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <div class="mb-3">
                <div style="display: flex; justify-content: center; gap: 10px; margin-top: 50px;">
                    <asp:Button Text="Ingresar" CssClass="btn btn-success" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
                    <a href="/" class="btn btn-secondary">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
