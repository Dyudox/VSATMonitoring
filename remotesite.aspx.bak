<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="remotesite.aspx.vb" Inherits="remotesite" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Remote Site</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_project" runat="server" Width="100%" AutoGenerateColumns="False" EnableTheming="true" Theme="MetropolisBlue" DataSourceID="dsRemoteSite" KeyFieldName="ID">
                <Settings ShowFooter="false" HorizontalScrollBarMode="Visible" />
                <Settings ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDetail ShowDetailRow="true" />
                <StylesEditors></StylesEditors>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <EditFormLayoutProperties ColCount="1" SettingsItems-Width="1000px">
                    <Items>
                        <dx:GridViewColumnLayoutItem ColumnName="VID" />
                        <dx:GridViewColumnLayoutItem ColumnName="Project" />
                        <dx:GridViewColumnLayoutItem ColumnName="Nama Customer" />
                        <dx:GridViewColumnLayoutItem ColumnName="Account Manager" />
                        <dx:GridViewColumnLayoutItem ColumnName="No. Kontrak" />
                        <dx:GridViewColumnLayoutItem ColumnName="SID" />
                        <dx:GridViewColumnLayoutItem ColumnName="IP LAN" />
                        <dx:GridViewColumnLayoutItem ColumnName="Kanwil" />
                        <dx:GridViewColumnLayoutItem ColumnName="Kanca Induk" />
                        <dx:GridViewColumnLayoutItem ColumnName="Nama Remote" />
                        <dx:GridViewColumnLayoutItem ColumnName="Alamat" />
                        <dx:GridViewColumnLayoutItem ColumnName="Provinsi" />
                        <dx:GridViewColumnLayoutItem ColumnName="Kota" />
                        <dx:GridViewColumnLayoutItem ColumnName="Jarkom" />
                        <dx:GridViewColumnLayoutItem ColumnName="Skala" />
                        <dx:EditModeCommandLayoutItem Width="500" HorizontalAlign="Left" />
                    </Items>
                </EditFormLayoutProperties>
                <Columns>

                    <dx:GridViewCommandColumn FixedStyle="Left" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="30">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>

                    <dx:GridViewDataTextColumn Caption="VID" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Width="180px" FieldName="VID" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>                  
                    <dx:GridViewDataComboBoxColumn FieldName="ProjectName" HeaderStyle-HorizontalAlign="Center" Caption="Project" VisibleIndex="2" Width="100px">
                        <PropertiesComboBox DataSourceID="dsproject" TextField="ProjectName" DisplayFormatInEditMode="true"
                            ValueField="IdProject" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                            <%--<ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>--%>
                        </PropertiesComboBox>
                        <EditFormSettings Caption="Project" VisibleIndex="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Customer" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="IdPelanggan" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <EditFormSettings Visible="false" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Account Manager" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="IdAM" Settings-AutoFilterCondition="Contains" VisibleIndex="7">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <EditFormSettings Visible="false" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="No. Kontrak" HeaderStyle-HorizontalAlign="Center" Width="100px" FieldName="NoKontrak" Settings-AutoFilterCondition="Contains" VisibleIndex="11">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <EditFormSettings Visible="false" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="SID" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="SID" Settings-AutoFilterCondition="Contains" VisibleIndex="12">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="IP LAN" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="IPLAN" Settings-AutoFilterCondition="Contains" VisibleIndex="13">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kanwil" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="KANWIL" Settings-AutoFilterCondition="Contains" VisibleIndex="14">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kanca Induk" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="KANCAINDUK" Settings-AutoFilterCondition="Contains" VisibleIndex="15">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Remote" Width="200px" HeaderStyle-HorizontalAlign="Center" FieldName="NAMAREMOTE" Settings-AutoFilterCondition="Contains" VisibleIndex="16">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Alamat" Width="200px" HeaderStyle-HorizontalAlign="Center" FieldName="AlamatInstall" Settings-AutoFilterCondition="Contains" VisibleIndex="17">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Provinsi" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="PROVINSI" Settings-AutoFilterCondition="Contains" VisibleIndex="18">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kota" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="KOTA" Settings-AutoFilterCondition="Contains" VisibleIndex="19">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jarkom" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="IdJarkom" Settings-AutoFilterCondition="Contains" VisibleIndex="20">
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Skala" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="Skala" Settings-AutoFilterCondition="Contains" VisibleIndex="21">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>History Order/Pekerjaan</b>
                            </h4>
                        </div>
                        <dx:ASPxGridView ID="gridhistory" runat="server" KeyFieldName="NoListTask" DataSourceID="dsgridhistory" EnableTheming="true" Width="40%" OnBeforePerformDataSelect="gridhistory_BeforePerformDataSelect" Theme="MetropolisBlue">
                            <Settings ShowFooter="false" />

                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsSearchPanel Visible="True" />
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="NoTask" HeaderStyle-HorizontalAlign="Center" Caption="No. Task" Width="200px" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NamaTeknisi" HeaderStyle-HorizontalAlign="Center" Caption="Teknisi" Width="200px" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TglSelesaiKerjaan" HeaderStyle-HorizontalAlign="Center" Caption="Tanggal Selesai pengerjaan" Width="200px" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" Caption="Order" Width="200px" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <br />
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Barang Terpasang</b>
                            </h4>
                        </div>
                        <dx:ASPxGridView ID="grid_barang_on" runat="server" KeyFieldName="ID" DataSourceID="dsbarang_on" EnableTheming="true" Width="40%" OnBeforePerformDataSelect="grid_barang_on_BeforePerformDataSelect" Theme="MetropolisBlue">
                            <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <SettingsSearchPanel Visible="True" />
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                            <Columns>
                                <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowEditButton="True" VisibleIndex="10">
                                    <CellStyle BackColor="#d6f1ff">
                                    </CellStyle>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="VID" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="200px" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NamaBarang" HeaderStyle-HorizontalAlign="Center" Caption="Nama Barang" Width="200px" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Type" HeaderStyle-HorizontalAlign="Center" Caption="Type" Width="200px" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SN" HeaderStyle-HorizontalAlign="Center" Caption="Serial Number" Width="200px" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IPlan" HeaderStyle-HorizontalAlign="Center" Caption="IP Lan" Width="200px" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Status" HeaderStyle-HorizontalAlign="Center" Caption="Status" Width="200px" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <br />
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Barang Rusak</b>
                            </h4>
                        </div>
                        <dx:ASPxGridView ID="grid_barang_rusak" runat="server" KeyFieldName="ID" DataSourceID="dsbarangreplace" EnableTheming="true" Width="40%" OnBeforePerformDataSelect="grid_barang_rusak_BeforePerformDataSelect" Theme="MetropolisBlue">
                            <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <SettingsSearchPanel Visible="True" />
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                            <Columns>
                                <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowEditButton="True" VisibleIndex="10">
                                    <CellStyle BackColor="#d6f1ff">
                                    </CellStyle>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="VID" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="200px" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NamaBarang" HeaderStyle-HorizontalAlign="Center" Caption="Nama Barang" Width="200px" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Type" HeaderStyle-HorizontalAlign="Center" Caption="Type" Width="200px" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SN" HeaderStyle-HorizontalAlign="Center" Caption="Serial Number" Width="200px" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IPlan" HeaderStyle-HorizontalAlign="Center" Caption="IP Lan" Width="200px" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Status" HeaderStyle-HorizontalAlign="Center" Caption="Status" Width="200px" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>

            </dx:ASPxGridView>

            <asp:SqlDataSource ID="dsRemoteSite" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" ></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsgridhistory" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from trproject"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsbarang_on" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsbarangreplace" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>


        </div>
    </div>
</asp:Content>

