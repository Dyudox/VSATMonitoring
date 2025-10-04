<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="tasklistBootsraps.aspx.vb" Inherits="tasklistBootsraps" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i>&nbsp;<a href="dashboard.aspx">Home</a></li>
            <li class="active"><a href="">Todolist</a></li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=open" data-toggle="modal" id="modal_ticket_pending" runat="server">
                    <div class="panel panel-default panel-stat2 bg-success">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lbl_open" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Open"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!-- /panel -->
                </a>
            </div>
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=onprogress" data-toggle="modal" id="A1" runat="server">
                    <div class="panel panel-default panel-stat2 bg-info">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lblonprogress" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="Label3" runat="server" ForeColor="White" Text="On Progress"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </a>
            </div>
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=finish" data-toggle="modal" id="A2" runat="server">
                    <div class="panel panel-default panel-stat2 bg-warning">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lblfinish" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Finish"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </a>
            </div>
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=Obscatle" data-toggle="modal" id="A3" runat="server">
                    <div class="panel panel-default panel-stat2 bg-danger">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lblverified" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Obstacle"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=Reschedule" data-toggle="modal" id="A4" runat="server">
                    <div class="panel panel-default panel-stat2 bg-success">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lblreschedule" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Reschedule"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </a>
            </div>
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=Pending" data-toggle="modal" id="A5" runat="server">
                    <div class="panel panel-default panel-stat2 bg-info">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lblpending" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="Label9" runat="server" ForeColor="White" Text="Pending"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </a>
            </div>
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=Cancel" data-toggle="modal" id="A6" runat="server">
                    <div class="panel panel-default panel-stat2 bg-warning">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lblcancel" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="Label11" runat="server" ForeColor="White" Text="Cancel"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </a>
            </div>
            <div class="col-md-3 col-sm-4">
                <a href="tasklistBootsraps.aspx?page=dattsklis&status=all" data-toggle="modal" id="A7" runat="server">
                    <div class="panel panel-default panel-stat2 bg-danger">
                        <div class="panel-body">
                            <span class="stat-icon">
                                <i class="fa fa-envelope"></i>
                            </span>
                            <div class="pull-right text-right">
                                <div class="value">
                                    <asp:Label ID="lblalldata" runat="server" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                                </div>
                                <div class="title">
                                    <asp:Label ID="label" runat="server" ForeColor="White" Text="All Data"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /panel -->
                </a>
            </div>
        </div>

        <div class="row">
            <div class="panel-body" style="overflow-x: auto">
                <%--<dx:BootstrapGridView ID="gridtask" ClientInstanceName="gridtask" runat="server" DataSourceID="dstask" KeyFieldName="ID" Width="100%" AutoGenerateColumns="false" EnableTheming="true">

                    <Settings ShowGroupPanel="True" />

                    <SettingsPager>
                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                    </SettingsPager>

                    <SettingsSearchPanel Visible="True" />
                    <SettingsEditing Mode="EditFormAndDisplayRow" />
                    <Columns>
                        <dx:BootstrapGridViewTextColumn Caption="No. Task" VisibleIndex="0">
                            <DataItemTemplate>
                                <a href="createdetiltask.aspx?ID=<%# Eval("ID")%>&VID=<%# Eval("VID")%>&notask=<%# Eval("NoTask")%>"><%# Eval("NoTask")%></a>
                            </DataItemTemplate>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Caption="VID" VisibleIndex="1">
                            <DataItemTemplate>
                                <a href="createdetiltask.aspx?ID=<%# Eval("ID")%>&VID=<%# Eval("VID")%>&notask=<%# Eval("NoTask")%>"><%# Eval("VID")%></a>
                            </DataItemTemplate>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewDateColumn Caption="Tanggal Task" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" CssClasses-HeaderCell="Center" FieldName="TanggalTask" VisibleIndex="2">
                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                            <CssClasses HeaderCell="Center"></CssClasses>
                        </dx:BootstrapGridViewDateColumn>
                        <dx:BootstrapGridViewTextColumn Caption="Provinsi" CssClasses-HeaderCell="Center" FieldName="PROVINSI" VisibleIndex="3">
                            <CssClasses HeaderCell="Center"></CssClasses>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Caption="Order" CssClasses-HeaderCell="Center" FieldName="idJenisTask" VisibleIndex="4">
                            <CssClasses HeaderCell="Center"></CssClasses>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Caption="Koordinator" CssClasses-HeaderCell="Center" FieldName="NamaKoordinator" VisibleIndex="5">
                            <CssClasses HeaderCell="Center"></CssClasses>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Caption="Teknisi" CssClasses-HeaderCell="Center" FieldName="NamaTeknisi" VisibleIndex="6">
                            <CssClasses HeaderCell="Center"></CssClasses>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Caption="Status" CssClasses-HeaderCell="Center" FieldName="StatusTask" VisibleIndex="7">
                            <CssClasses HeaderCell="Center"></CssClasses>
                        </dx:BootstrapGridViewTextColumn>
                    </Columns>
                </dx:BootstrapGridView>--%>
                <dx:ASPxGridView ID="gridtask" ClientInstanceName="gridtask" runat="server" DataSourceID="dstask" KeyFieldName="ID" Width="100%" AutoGenerateColumns="false" Theme="MetropolisBlue">
                    <Settings ShowFooter="false" ShowGroupPanel="True" />

                    <SettingsPager>
                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                    </SettingsPager>

                    <SettingsSearchPanel Visible="True" />
                    <SettingsEditing Mode="EditFormAndDisplayRow" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="#" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="30px">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <DataItemTemplate>
                                <a href="createdetiltask.aspx?ID=<%# Eval("ID")%>&VID=<%# Eval("VID")%>&notask=<%# Eval("NoTask")%>&order=<%# Eval("idJenisTask")%>&status=<%# Eval("StatusTask")%>">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Apps-text-editor-icon22.png" Width="20px"/>
                                </a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="No. Task" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" FieldName="NoTask" Visible="false">                              
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>                          
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="VID" FieldName="VID" HeaderStyle-HorizontalAlign="Center" Width="200px" VisibleIndex="2">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <%--<DataItemTemplate>
                                <a href="createdetiltask.aspx?ID=<%# Eval("ID")%>&VID=<%# Eval("VID")%>&notask=<%# Eval("NoTask")%>"><%# Eval("VID")%></a>
                            </DataItemTemplate>--%>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Tanggal Task" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="TanggalTask" VisibleIndex="3">
                            <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd HH:mm:ss"></PropertiesDateEdit>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Nama Remote" HeaderStyle-HorizontalAlign="Center" FieldName="NAMAREMOTE" Width="150px" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Provinsi" HeaderStyle-HorizontalAlign="Center" FieldName="PROVINSI" Width="150px" VisibleIndex="4">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Order" HeaderStyle-HorizontalAlign="Center" FieldName="idJenisTask" Width="100px" VisibleIndex="5">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Koordinator" HeaderStyle-HorizontalAlign="Center" FieldName="NamaKoordinator" Width="150px" VisibleIndex="6">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTeknisi" Width="150px" VisibleIndex="7">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Status" HeaderStyle-HorizontalAlign="Center" FieldName="StatusTask" Width="100px" VisibleIndex="8">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dstask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            </div>
            <%--<div class="table-responsive">
                <table class="table table-striped" id="dataTable">

                    <thead>
                        <asp:Literal ID="ltrheader" runat="server"></asp:Literal>

                    </thead>
                    <tbody>
                        <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                    </tbody>
                </table>
            </div>

        </div>--%>
        </div>
    </div>
</asp:Content>

