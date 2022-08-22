<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="Zadatak.PersonList" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel-group" id="accordion">
        <div class="panel panel-default">
            <div class="panel-heading" role="tab" id="headingTwo">
                <h4 class="panel-title">
                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#gridViewContent">Grid View
                    </a>
                </h4>
            </div>
            <div id="gridViewContent" class="panel-collapse collapse in">
                <div class="panel-body">
                    <asp:GridView runat="server" ID="mojGV" AutoGenerateColumns="False" OnRowEditing="mojGV_RowEditing" OnRowUpdating="mojGV_RowUpdating" OnRowCancelingEdit="mojGV_RowCancelingEdit"
                      OnRowDataBound="mojGV_RowDataBound" meta:resourcekey="mojGVResource1" >
                        <Columns>
                            <asp:BoundField HeaderText="Name" DataField="Name" ControlStyle-CssClass="form-control" meta:resourcekey="BoundFieldResource1" >
<ControlStyle CssClass="form-control"></ControlStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Surname" DataField="Surname" ControlStyle-CssClass="form-control" meta:resourcekey="BoundFieldResource2" >
<ControlStyle CssClass="form-control"></ControlStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="E-mail Addresses" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Email") %>'>
                                        <ItemTemplate>
                                            <asp:LinkButton Text='<%# Eval("EmailAdress") %>' runat="server" PostBackUrl='<%# "mailto:" + Eval("EmailAdress") %>' meta:resourcekey="LinkButtonResource1" />
                                            <br />
                                        </ItemTemplate>

                                    </asp:Repeater>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Email") %>'>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# Eval("EmailAdress") %>' CssClass="form-control" meta:resourcekey="TextBoxResource1" />

                                        </ItemTemplate>

                                    </asp:Repeater>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Telephone" HeaderText="Telephone" ControlStyle-CssClass="form-control" meta:resourcekey="BoundFieldResource3" >
<ControlStyle CssClass="form-control"></ControlStyle>
                            </asp:BoundField>
                            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" Enabled="False"  SelectMethod="GetStatuses" DataTextField="Name" DataValueField="IDStatusPerson" CssClass="form-control" Width="120px" meta:resourcekey="DropDownListResource2">
                                    </asp:DropDownList>
                                        
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" SelectMethod="GetStatuses" DataTextField="Name" DataValueField="IDStatusPerson" CssClass="form-control" meta:resourcekey="DropDownListResource1">
                                    </asp:DropDownList>
                                    
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField EditText="Edit" CancelText="Cancel" UpdateText="Update" ShowEditButton="true" ShowCancelButton="true" meta:resourcekey="CommandFieldResource1"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading" id="headingOne">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-parent="#accordion" href="#repeaterContent">Repeater
                    </a>
                </h4>
            </div>
            <div id="repeaterContent" class="panel-collapse collapse">
                <div class="panel-body">

                    <asp:Repeater runat="server" ID="repeater" OnItemCommand="repeater_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-condensed table-hover tblPrikazOsoba">
                                <tr>
                                    <th>Name</th>
                                    <th>Surname</th>
                                    <th>E-Mail</th>
                                    <th>Telephone</th>
                                    <th>Status</th>
                                    <th>City</th>
                                    <th></th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label Text='<%# Eval("Name") %>' runat="server" meta:resourcekey="LabelResource1" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("Surname") %>' runat="server" meta:resourcekey="LabelResource2" />
                                </td>
                                <td>
                                    <asp:Repeater runat="server" DataSource='<%# Eval("Email") %>'>
                                        <ItemTemplate>
                                            <asp:LinkButton Text='<%# Eval("EmailAdress") %>' runat="server" PostBackUrl='<%# "mailto:" + Eval("EmailAdress") %>' meta:resourcekey="LinkButtonResource2" />
                                            <br />
                                        </ItemTemplate>

                                    </asp:Repeater>
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("Telephone") %>' runat="server" meta:resourcekey="LabelResource3" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("StatusPerson.Name") %>' runat="server" meta:resourcekey="LabelResource4" />
                                </td>
                                <td>
                                    <asp:Label Text='<%# Eval("City.Name") %>' runat="server" meta:resourcekey="LabelResource5" />
                                </td>
                                <td>
                                    <asp:Button Text="Edit" runat="server" CssClass="btn btn-primary" meta:resourcekey="ButtonResource3" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
