<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="tasklist.aspx.vb" Inherits="tasklist" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Task List</li>
        </ul>
    </div>
    <div class="padding-md">
        <br />
        <div class="row">
            <dx:ASPxGridView ID="gridtasklist" KeyFieldName="NoTask" ClientInstanceName="gridtasklist" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dstasklist" EnableTheming="True" Theme="MetropolisBlue">
                <SettingsSearchPanel Visible="True" />
                <Settings ShowFooter="false" ShowGroupPanel="True" HorizontalScrollBarMode="Auto" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsDetail ShowDetailRow="true" />
                <Columns>
                    <%--<dx:GridViewCommandColumn ShowDeleteButton="True" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="3">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>--%>
                    <dx:GridViewDataTextColumn Caption="No. Task" Width="100%" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="NoTask" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="tanggal" HeaderStyle-HorizontalAlign="Center" Caption="Tanggal" VisibleIndex="2" Width="100%">
                        <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy"></PropertiesDateEdit>
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Provinsi" Width="100%" HeaderStyle-HorizontalAlign="Center" FieldName="Provinsi" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Koordinator" Width="100%" HeaderStyle-HorizontalAlign="Center" FieldName="IdKoordinator" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                  <%--  <dx:GridViewDataTextColumn Caption="Teknisi" Width="100%" HeaderStyle-HorizontalAlign="Center" FieldName="IdTeknisi" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>--%>
                    <%--  <dx:GridViewDataTextColumn Caption="Status Pekerjaan" Width="100px" FieldName="IdStatusTask" Settings-AutoFilterCondition="Contains" VisibleIndex="6">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn Caption="Total Task" Width="100%" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FieldName="tot" Settings-AutoFilterCondition="Contains" VisibleIndex="7">
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="gridalltask" OnBeforePerformDataSelect="gridalltask_BeforePerformDataSelect" KeyFieldName="NoTask" ClientInstanceName="gridalltask" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsalltask" EnableTheming="True" Theme="MetropolisBlue">
                            <Settings ShowFooter="false" ShowGroupPanel="True" HorizontalScrollBarMode="Auto" />
                            <Columns>
                                <dx:GridViewDataHyperLinkColumn Caption="Show Detail Task" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Width="100%">
                                    <DataItemTemplate>
                                        <a href="createdetiltask.aspx?id=<%# Eval("ID") %>">Detail Task</a>
                                    </DataItemTemplate>
                                </dx:GridViewDataHyperLinkColumn>
                                <dx:GridViewDataTextColumn Caption="" Width="100%" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Visible="false" FieldName="ID" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="No. Task" Width="100%" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="NoTask" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="TanggalTask" HeaderStyle-HorizontalAlign="Center" Caption="Tanggal" VisibleIndex="2" Width="100%">
                                    <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy"></PropertiesDateEdit>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Provinsi" Width="100%" HeaderStyle-HorizontalAlign="Center" FieldName="Provinsi" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Koordinator" Width="100%" HeaderStyle-HorizontalAlign="Center" FieldName="IdKoordinator" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Teknisi" Width="100%" HeaderStyle-HorizontalAlign="Center" FieldName="IdTeknisi" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Status Pekerjaan" Width="100%" FieldName="Status" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" VisibleIndex="6">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dstasklist" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsalltask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>

        </div>

    </div>
    <%--<div class="modal fade" id="ModalEmail">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4>Input Task</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label></label>
                            <asp:HiddenField ID="customerIDUpdate" runat="server" />
                            <asp:TextBox ID="txt_customer_name" runat="server" placeholder="Customer Name" CssClass="form-control input-sm bounceIn animation-delay1"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox ID="txt_address" runat="server" placeholder="Address" CssClass="form-control input-sm bounceIn animation-delay1"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox ID="txt_email" runat="server" placeholder="Email" CssClass="form-control input-sm bounceIn animation-delay1"></asp:TextBox>
                        </div>
                     
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Phone 1</label>
                                    <asp:TextBox ID="txt_phone1" runat="server" placeholder="Phone 1" CssClass="form-control input-sm bounceIn animation-delay1"></asp:TextBox>
                                </div>
                            </div>
                         
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Phone 2</label>
                                    <asp:TextBox ID="txt_phone2" runat="server" placeholder="Phone 2" CssClass="form-control input-sm bounceIn animation-delay1"></asp:TextBox>
                                </div>
                            </div>
                           
                        </div>
                       
                    </div>
                    <div class="modal-footer">
                       <button id="btn_customer_update" runat="server" class="btn btn-info" type="submit">
                            <i class="fa fa-retweet"></i>&nbsp;Update
                        </button>
                        <button id="Btn_Cancel" runat="server" datadata-dismiss="modal" class="btn btn-info" type="submit">
                            <i class="fa fa-arrow-circle-left"></i>&nbsp;Cancel
                        </button>

                    </div>
                </div>
              
            </div>
         
        </div>--%>
</asp:Content>

