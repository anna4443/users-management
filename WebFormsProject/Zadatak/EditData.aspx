<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditData.aspx.cs" Inherits="Zadatak.EditData" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Src="~/Kontrole/EditPersonCtrl.ascx" TagPrefix="uc1" TagName="EditPersonCtrl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--class="row"--%>
    <div runat="server" id="pnlControls">
        <%--<uc1:EditPersonCtrl runat="server" id="EditPersonCtrl" />--%>


    </div>
    <div style="clear: both;"></div>

    <div class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" style="display: inline-block">
                        <asp:Label Text="Confirm deletion" runat="server" ID="lblTitle" meta:resourcekey="lblTitleResource1" />
                    </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label Text="Are you sure you want to delete this person?" runat="server" ID="lblAreYouSure" meta:resourcekey="lblAreYouSureResource1" />
                </div>
                <div class="modal-footer">
                    <asp:Button Text="Delete" runat="server" ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn btn-primary" meta:resourcekey="btnDeleteResource1" />
                    <asp:Button Text="Cancel" runat="server" ID="btnCancel" CssClass="btn btn-default" meta:resourcekey="btnCancelResource1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
