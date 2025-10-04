<%@ Page Title="Report BPS" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="rptbps.aspx.vb" Inherits="rptbps" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Report Rekap BPS</li>
        </ul>
    </div>

    <div class="padding-md">
        <div class="row">
            <div class="pull-left">
                <table>
                    <tr>
                        <td style="width: 200px">
                            <b>Perusahaan:</b>
                            <dx:ASPxComboBox ID="cbperusahaan" runat="server" ValueType="System.String" DataSourceID="dsperusahaan" ValueField="NamaPerusahaan" TextField="NamaPerusahaan" CssClass="form-control"></dx:ASPxComboBox>
                        </td>
                        <td style="width: 200px">
                            <b>Tanggal Transfer:</b>
                            <dx:ASPxDateEdit ID="strdate" DisplayFormatString="dd-MM-yyyy" EditFormatString="dd-MM-yyyy" CssClass="form-control" runat="server"></dx:ASPxDateEdit>
                        </td>
                        <td style="width: 200px">
                            <b>Akhir Tanggal</b>
                            <dx:ASPxDateEdit ID="enddate" DisplayFormatString="dd-MM-yyyy" EditFormatString="dd-MM-yyyy" CssClass="form-control" runat="server"></dx:ASPxDateEdit>
                        </td>
                        <td style="width: 200px">
                            <br />
                            <asp:Button ID="btnfilter" CssClass="btn btn-info" runat="server" Text="show" Width="120px" Height="33px" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>

            <dx:ASPxGridView ID="grid_bps" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsbps" KeyFieldName="NoTask" ClientInstanceName="grid_bps" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowFooter="true" ShowGroupFooter="VisibleIfExpanded" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsDetail ShowDetailRow="true" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="No BPS" HeaderStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="NoReferensi" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tanggal Transfer" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" HeaderStyle-HorizontalAlign="Center" FieldName="tgltrf" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTeknisi" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jumlah Transfer" HeaderStyle-HorizontalAlign="Center" FieldName="jumlahtrf" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>                   
                    <dx:GridViewDataTextColumn Caption="No. Task" HeaderStyle-HorizontalAlign="Center" FieldName="NoTask" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tanggal Pengajuan" PropertiesDateEdit-DisplayFormatString="dd-MM-yyyy" HeaderStyle-HorizontalAlign="Center" FieldName="tglpengajuan" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataDateColumn>                   
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="grid_VID" ClientInstanceName="grid_VID" runat="server" DataSourceID="dsdetailtask" KeyFieldName="NoListTask" Width="100%" OnBeforePerformDataSelect="grid_VID_BeforePerformDataSelect" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="EditFormAndDisplayRow" />
                                    
                                    <Columns>                                                                              
                                        <dx:GridViewDataComboBoxColumn FieldName="VID" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="200px" ReadOnly="true" PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0">
                                            <EditFormSettings VisibleIndex="1" /> 
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="IPLAN" HeaderStyle-HorizontalAlign="Center" Caption="IP LAN" Width="100px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="NAMAREMOTE" HeaderStyle-HorizontalAlign="Center" Caption="Nama Remote" Width="300px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ALAMAT" HeaderStyle-HorizontalAlign="Center" Caption="Alamat" Width="300px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>                                        
                                        <dx:GridViewDataTextColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" Caption="Order" Width="100px">
                                            <EditFormSettings Visible="True" VisibleIndex="10" />                                          
                                            <Settings AutoFilterCondition="Contains"></Settings>
                                        </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dsbps" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsdetailtask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsperusahaan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select NamaPerusahaan from msPerusahaan"></asp:SqlDataSource>

            <dx:ASPxGridViewExporter ID="reportexp" runat="server" GridViewID="grid_bps"></dx:ASPxGridViewExporter>
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
    </div>
</asp:Content>

