<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Zadatak.Setup" Culture="auto" UICulture="auto" meta:resourcekey="PageResource1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <div class="formContainer">
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4"></div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="form-group">
                        <asp:Label ID="lblTheme" runat="server" Text="Theme" Font-Bold="True" meta:resourceKey="lblThemeResource1"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlTheme" 
                            runat="server" 
                            CssClass="form-control"
                             AutoPostBack="True"
                             OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged"
                             meta:resourceKey="ddlThemeResource1">
                            <asp:ListItem Text="--- choose ---" Value="0" meta:resourcekey="ListItemResource1" />
                            <asp:ListItem Text="Default" Value="default" meta:resourcekey="ListItemResource2" />
                            <asp:ListItem Text="Blue" Value="blue" meta:resourcekey="ListItemResource3" />
                            <asp:ListItem Text="Red" Value="red" meta:resourcekey="ListItemResource4" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblLanguage" runat="server" Text="Language:" Font-Bold="True" meta:resourceKey="lblLanguageResource1"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlLanguages" 
                            runat="server" 
                            CssClass="form-control"
                            AutoPostBack="True"
                             OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged"
                            meta:resourceKey="ddlLanguagesResource1">
                            <asp:ListItem Text="--- choose ---" Value="0" meta:resourcekey="ListItemResource5" />
                            <asp:ListItem Text="Croatian" Value="hr" meta:resourcekey="ListItemResource6" />
                            <asp:ListItem Text="English" Value="en" meta:resourcekey="ListItemResource7" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblRepozitorij" runat="server" Text="Repozitorij:" Font-Bold="True" meta:resourcekey="lblRepozitorijResource1"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlRepo" runat="server" CssClass="form-control" meta:resourcekey="ddlRepoResource1" OnSelectedIndexChanged="ddlRepo_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="---choose---" meta:resourcekey="ListItemResource8" />
                            <asp:ListItem Text="Tekstualna datoteka" meta:resourcekey="ListItemResource9" />
                            <asp:ListItem Text="Baza podataka" meta:resourcekey="ListItemResource10" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4"></div>
            </div>
        </div>
    </div>
</asp:Content>
