<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="formpengajuanuang.aspx.vb" Inherits="formpengajuanuang" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Pengajuan Uang SPD</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gridpengajuanuang" KeyFieldName="NoTask" ClientInstanceName="gridpengajuanuang" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dspengajuanuang" EnableTheming="True" Theme="MetropolisBlue">
                <SettingsSearchPanel Visible="True" />
                <Settings ShowFooter="false" ShowGroupPanel="True" ShowFilterRow="true" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <%--<Settings ShowFilterRow="True" ShowFilterRowMenu="true" ShowFooter="True"/>--%>
                <SettingsSearchPanel Visible="True" />
                <SettingsDetail ShowDetailRow="true" ShowDetailButtons="true" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="No. Task" HeaderStyle-HorizontalAlign="Center" FieldName="NoTask" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Task" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTask" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tgl. Task" HeaderStyle-HorizontalAlign="Center" FieldName="TanggalTask" VisibleIndex="1">
						<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTeknisi" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Type Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="IdStatusPegawai" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdStatusManager" Width="100 PX" Caption="Status Manager" VisibleIndex="4">
                        <EditFormSettings Visible="True" VisibleIndex="4" Caption="Status Manager" />
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                            <Items>
                                <dx:ListEditItem Text="Valid" Value="Valid" />
                                <dx:ListEditItem Text="Not Valid" Value="Not Valid" />
                            </Items>
                        </PropertiesComboBox>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <Settings AutoFilterCondition="Contains"></Settings>
                    </dx:GridViewDataComboBoxColumn>
                    <%--<dx:GridViewDataTextColumn Caption="Status Manager" HeaderStyle-HorizontalAlign="Center" FieldName="IdStatusManager" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn Caption="Pagu" PropertiesTextEdit-DisplayFormatString="{0:n0}" HeaderStyle-HorizontalAlign="Center" FieldName="pagu" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Pengajuan Uang" PropertiesTextEdit-DisplayFormatString="{0:n0}" FieldName="total" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>                    
                </Columns>
                <Templates>
                    <DetailRow>
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Pagu / Lokasi Remote</b>
                            </h4>

                        </div>
                        <dx:ASPxGridView ID="gridlokasi" ClientInstanceName="gridlokasi" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" OnBeforePerformDataSelect="gridlokasi_BeforePerformDataSelect" AutoGenerateColumns="False" DataSourceID="dsgridlokasi" KeyFieldName="VID">
                            <Settings ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <Columns>

                                <dx:GridViewDataTextColumn Caption="VID" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="VID" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Provider" FieldName="Provider" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Hotel" PropertiesTextEdit-DisplayFormatString="{0:n0}" FieldName="Hotel" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Transport" PropertiesTextEdit-DisplayFormatString="{0:n0}" FieldName="Transport" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Paket" PropertiesTextEdit-DisplayFormatString="{0:n0}" FieldName="Paket" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <%-- <dx:GridViewDataTextColumn Caption="Sisa Pagu" Width="100px" FieldName="SisaPagu" Settings-AutoFilterCondition="Contains" >
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>         --%>
                            </Columns>
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                        </dx:ASPxGridView>
                        <br />
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Input Permintaan SPD</b>
                            </h4>
                        </div>
                        <dx:ASPxGridView ID="gv_detilpengajuan" ClientInstanceName="gv_detilpengajuan" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" OnBeforePerformDataSelect="gv_detilpengajuan_BeforePerformDataSelect" OnRowDeleting="gridpengajuanuang_RowDeleting" OnRowInserting="gridpengajuanuang_RowInserting" OnRowUpdating="gridpengajuanuang_RowUpdating" AutoGenerateColumns="False" DataSourceID="dsdetilpengajuan" KeyFieldName="idtbl">
                            <Settings ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <Columns>
                                <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" ShowDeleteButton="True" Width="100px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="8">
                                    <CellStyle BackColor="#d6f1ff">
                                    </CellStyle>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="ID Pengajuan" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="idtbl" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Pengajuan" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="jumlahpengajuan" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal Pengajuan" FieldName="tglpengajuan" Settings-AutoFilterCondition="Contains">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Perusahaan" FieldName="Perusahaan" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Provider" FieldName="Provider" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Note" FieldName="keterangan" Width="150px" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataComboBoxColumn FieldName="IdStatusManager" Width="100 PX" Caption="Status Manager" VisibleIndex="4">
                                    <EditFormSettings Visible="True" VisibleIndex="4" Caption="Status Manager" />
                                    <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                        <Items>
                                            <dx:ListEditItem Text="Valid" Value="Valid" />
                                            <dx:ListEditItem Text="Not Valid" Value="Not Valid" />
                                        </Items>
                                    </PropertiesComboBox>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataComboBoxColumn>--%>
                            </Columns>
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dspengajuanuang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsdetilpengajuan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsgridlokasi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

