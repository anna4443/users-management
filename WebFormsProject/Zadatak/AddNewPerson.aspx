<%@ Page Title="Add new person" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddNewPerson.aspx.cs" Inherits="Zadatak.AddNewPerson" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentAdd">
        <div class="formContainer">
            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="form-group">
                    <asp:Label ID="lblName" runat="server" Text="Name:" Font-Bold="True" meta:resourcekey="lblNameResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Insert name" ControlToValidate="txtName" CssClass="validators" Text="*" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" meta:resourcekey="txtNameResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblSurname" runat="server" Text="Surname:" Font-Bold="True" meta:resourcekey="lblSurnameResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Insert surname" ControlToValidate="txtSurname" CssClass="validators" Text="*" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" meta:resourcekey="txtSurnameResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="True" meta:resourcekey="lblEmailResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Insert email" ControlToValidate="txtEmail1" CssClass="validators" Text="*" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Insert correctly email" ControlToValidate="txtEmail1" Text="*" CssClass="validators" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                    <br />
                    <asp:TextBox ID="txtEmail1" runat="server" CssClass="form-control" meta:resourcekey="txtEmail1Resource1"></asp:TextBox>
                    <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control" Visible="False" meta:resourcekey="txtEmail2Resource1"></asp:TextBox>
                    <asp:TextBox ID="txtEmail3" runat="server" CssClass="form-control" Visible="False" meta:resourcekey="txtEmail3Resource1"></asp:TextBox>
                    <asp:LinkButton Text="Add more email addresses" ID="btnAddEmails" runat="server" OnClick="btnAddEmails_Click" CausesValidation="False" meta:resourcekey="btnAddEmailsResource1" />
                </div>
                </div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="form-group">
                    <asp:Label ID="lblTelephone" runat="server" Text="Telephone:" Font-Bold="True" meta:resourcekey="lblTelephoneResource1"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" meta:resourcekey="txtTelephoneResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCity" runat="server" Text="City:" Font-Bold="True" meta:resourcekey="lblCityResource1"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="IDCity" meta:resourcekey="ddlCitiesResource1"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblStatusPerson" runat="server" Text="Status:" Font-Bold="True" meta:resourcekey="lblStatusPersonResource1"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlStatusPerson" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="IDStatusPerson" meta:resourcekey="ddlStatusPersonResource1"></asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-4">
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Bold="True" meta:resourcekey="lblPasswordResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Insert password" CssClass="validators" ControlToValidate="txtPassword" Text="*" meta:resourcekey="RequiredFieldValidator4Resource1"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Password:" meta:resourcekey="lblConfirmPasswordResource1"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Insert password" CssClass="validators" ControlToValidate="txtConfirmPassword" Text="*" meta:resourcekey="RequiredFieldValidator5Resource1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Wrong password" CssClass="validators" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" Text="*" meta:resourcekey="CompareValidator1Resource1"></asp:CompareValidator>
                    <br />
                    <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" CssClass="form-control" meta:resourcekey="txtConfirmPasswordResource1"></asp:TextBox>
                </div>
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" meta:resourcekey="btnAddResource1" />
            </div>
    </div>
        <div style="clear:both;">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"  CssClass="validators" meta:resourcekey="ValidationSummary1Resource1"/>
        </div>
    </div>
</asp:Content>
