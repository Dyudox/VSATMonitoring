<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="rptwajibpm.aspx.vb" Inherits="rptwajibpm" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Report Wajib PM</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <div class="pull-left">
                <table>
                    <tr>
                        <td style="width: 200px">
                            <b>Choose Project:</b>
                            <dx:ASPxComboBox ID="cbproject" runat="server" ValueType="System.String" DataSourceID="dsproject" 
                                ValueField="IdProject" CssClass="form-control" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="IdProject"></dx:ListBoxColumn>
                                    <dx:ListBoxColumn Caption="Project Name" FieldName="ProjectName"></dx:ListBoxColumn>                                    
                                </Columns>
                            </dx:ASPxComboBox>
                        </td>
                        <td style="width: 200px">
                            <b>Choose PM:</b>
                            <dx:ASPxComboBox ID="cbPM" runat="server" ValueType="System.String" CssClass="form-control">
                                <Items>
                                    <dx:ListEditItem Text="PM 1" Value="PM1" />
                                    <dx:ListEditItem Text="PM 2" Value="PM2" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <br />
                            <asp:Button ID="btnfilter" CssClass="btn btn-info" runat="server" Text="show" Width="120px" Height="33px" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
            <dx:ASPxGridView ID="gridwajibpm" ClientInstanceName="gridwajibpm" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsrptwajib" EnableTheming="True" Theme="MetropolisBlue">
                 <Settings ShowFooter="true" ShowGroupFooter="VisibleIfExpanded" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Provinsi" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="PROVINSI" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="KOTA" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="KOTA" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="lokasi" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="lokasi" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Harus PM" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="wajibpm" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                </Columns>

                <TotalSummary>
                     <dx:ASPxSummaryItem FieldName="lokasi" ShowInGroupFooterColumn="lokasi" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="wajibpm" ShowInGroupFooterColumn="wajibpm" SummaryType="Sum" DisplayFormat="{0}" />
                </TotalSummary>
                 <GroupSummary>
                     <dx:ASPxSummaryItem FieldName="lokasi" ShowInGroupFooterColumn="lokasi" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="wajibpm" ShowInGroupFooterColumn="wajibpm" SummaryType="Sum" DisplayFormat="{0}" />
                </GroupSummary>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="reportexp" runat="server" GridViewID="gridwajibpm"></dx:ASPxGridViewExporter>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblExport" runat="server" Text="Export To:"></asp:Label>
                        <dx:ASPxComboBox ID="cbexpTin" CssClass="form-control" runat="server">
                            <Items>
                                <dx:ListEditItem Text="PDF" Value="pdf" />
                                <dx:ListEditItem Text="EXCEL 97-2003" Value="xls" />
                                <dx:ListEditItem Text="EXCEL" Value="xlsx" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td>&nbsp<br />
                        &nbsp
                        <asp:Button ID="bconvertTin" CssClass="btn btn-success" runat="server" Text="Convert" Width="120px" Height="33px" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:SqlDataSource ID="dsrptwajib" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select IdProject,ProjectName from trProject"></asp:SqlDataSource>
        <%--<asp:SqlDataSource ID="dstask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select Service from msJenis_Task"></asp:SqlDataSource>--%>
    </div>
</asp:Content>

