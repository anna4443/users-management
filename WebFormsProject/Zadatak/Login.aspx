<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Zadatak.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentLogin">
        <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-4"></div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="formContainer">
                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email je obavezan" class="validators" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail" runat="server" ErrorMessage="Potrebno je unesti ispravan email" class="validators" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Lozinka je obavezna" ControlToValidate="txtPassword" class="validators" Text="*"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="checkbox">
                        <asp:CheckBox ID="cbRemember" runat="server" />
                        <asp:Label ID="lblRemember" runat="server" Text="Zapamti me"></asp:Label>
                    </div>

                    <asp:Button ID="btnEnter" runat="server" Text="Enter" class="btn btn-primary" OnClick="btnEnter_Click" />

                    <div>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-4"></div>
    </div>
</asp:Content>
