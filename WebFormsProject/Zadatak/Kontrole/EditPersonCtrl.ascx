<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPersonCtrl.ascx.cs" Inherits="Zadatak.Kontrole.EditPersonCtrl" %>

<%--<style>

    th, td{
        padding:5px 0;
    }

    tr td:last-child{
        padding-left:5px;
    }
</style>--%>

<div class="content">
    <%--style="overflow: hidden;"--%>
    <div >

        <div class="osoba">
            <asp:HiddenField ID="hfID" runat="server" />
            <table>
               <tbody>
                   <tr>
                       <td>
                           <asp:Label ID="lblName" runat="server" Text="Name:" meta:resourcekey="lblNameResource1"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm" Width="180px" meta:resourcekey="txtNameResource1"></asp:TextBox>
                       </td>
                       <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Insert name" Text="*" ControlToValidate="txtName" CssClass="validators" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblSurname" runat="server" Text="Surname:" meta:resourcekey="lblSurnameResource1"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control input-sm" Width="180px" meta:resourcekey="txtSurnameResource1"></asp:TextBox>
                       </td>
                       <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Insert surname" CssClass="validators" Text="*" ControlToValidate="txtSurname" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td></td>
                       <td>
                           <asp:DropDownList ID="ddlEmails" runat="server" CssClass="form-control input-sm" DataTextField="EmailAdress" DataValueField="IDEmail" OnSelectedIndexChanged="ddlEmails_SelectedIndexChanged" AutoPostBack="True" meta:resourcekey="ddlEmailsResource1" />
                       </td>
                       <td>&nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblEmail" runat="server" Text="Email:" meta:resourcekey="lblEmailResource1"></asp:Label>
                       </td>
                       <td>
                           <div class="input-group">
                               <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" meta:resourcekey="txtEmailResource1"></asp:TextBox>

                               <span class="input-group-btn">
                                   <asp:LinkButton Text="
                                &lt;span class=&quot;glyphicon glyphicon-save&quot; style=&quot;color:#0094ff&quot;&gt;&lt;/span&gt;
                                   " runat="server" CssClass="btn btn-default btn-sm" OnClick="btnChangeEmail_Click" meta:resourcekey="LinkButtonResource1"></asp:LinkButton>
                               </span>
                           </div>
                       </td>
                       <td>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Insert correct email" ControlToValidate="txtEmail" CssClass="validators" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Insert email" CssClass="validators" Text="*" ControlToValidate="txtEmail" meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblTelephone" runat="server" Text="Telephone:" meta:resourcekey="lblTelephoneResource1"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control input-sm" Width="180px" meta:resourcekey="txtTelephoneResource1"></asp:TextBox>
                       </td>
                       <td>&nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblPassword" runat="server" Text="Password:" meta:resourcekey="lblPasswordResource1"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtPass" runat="server" CssClass="form-control input-sm" Width="180px" meta:resourcekey="txtPassResource1"></asp:TextBox>
                       </td>
                       <td>&nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblStatus" runat="server" Text="Status:" Font-Bold="True" meta:resourcekey="lblStatusResource1"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control input-sm" Width="180px" DataTextField="Name" DataValueField="IDStatusPerson" meta:resourcekey="ddlStatusResource1"></asp:DropDownList>
                       </td>
                       <td>&nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblCity" runat="server" Text="City:" meta:resourcekey="lblCityResource1"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control input-sm" Width="180px" DataTextField="Name" DataValueField="IDCity" meta:resourcekey="ddlCityResource1"></asp:DropDownList>
                       </td>
                       <td>&nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td></td>
                       <td>
                           <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm" Width="80px" OnClick="btnEdit_Click" meta:resourcekey="btnEditResource1"/>
                           <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-warning btn-sm" Width="80px"
                               CausesValidation="False" OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1"/>
                       </td>
                       <td>&nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td colspan="3">
                           <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validators" meta:resourcekey="ValidationSummary1Resource1" />
                       </td>
                   </tr>
               </tbody>
            </table>

        </div>

    </div>

</div>
