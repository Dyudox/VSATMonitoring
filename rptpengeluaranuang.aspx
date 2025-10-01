<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="rptpengeluaranuang.aspx.vb" Inherits="rptpengeluaranuang" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Reporting All Data SPJ</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gvuang" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsuang" KeyFieldName="NoTask" ClientInstanceName="gvuang" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Nomor Task" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="NoTask" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tanggal Task" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="TanggalTask" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="ID Project" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="IdProject" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Teknisi" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="IdTeknisi" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Koordinator" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="IdKoordinator" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Provinsi" HeaderStyle-HorizontalAlign="Center" FieldName="IdProvinsi" Visible="true" Width="100px" VisibleIndex="5">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox DataSourceID="dsprovinsi" TextField="Provinsi"
                            ValueField="IdProvinsi" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Kota" HeaderStyle-HorizontalAlign="Center" FieldName="IdCity" Visible="true" Width="100px" VisibleIndex="6">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox DataSourceID="dskota" TextField="Kota" ValueField="idKota"
                            IncrementalFilteringMode="StartsWith">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Dana SPJ" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="{0:c}" CellStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="totalbiaya" Settings-AutoFilterCondition="Contains" VisibleIndex="7">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>

                </Columns>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="reportexp" runat="server" GridViewID="gvuang"></dx:ASPxGridViewExporter>
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
            <asp:SqlDataSource ID="dsprovinsi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsuang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

