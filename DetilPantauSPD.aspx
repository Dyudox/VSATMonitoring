<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="DetilPantauSPD.aspx.vb" Inherits="DetilPantauSPD" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
     
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Detail SPD Teknisi</li>
        </ul>
    </div>

    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gridpengajuanuang" KeyFieldName="NoTask" ClientInstanceName="gridpengajuanuang" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dspengajuanuang" EnableTheming="True" Theme="MetropolisBlue">
                <SettingsSearchPanel Visible="True" />
                <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsSearchPanel Visible="True" />
                <SettingsDetail ShowDetailRow="true" ShowDetailButtons="true" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="No. Task" Width="150px" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FieldName="NoTask" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tgl. Task" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="TanggalTask" VisibleIndex="2">
						<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Task" Width="200px" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTask" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Provider" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="Provider" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Teknisi" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTeknisi" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Uang Diterima/Transfer" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="total" Width="200px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Penggunaan Uang" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" Width="200px" FieldName="totalsuk" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Persetujuan Penggunaan Uang" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" HeaderStyle-HorizontalAlign="Center" FieldName="approve" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Jumlah Sisa / Kelebihan Dana" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="sisa" Width="200px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>

                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Rincian Pengajuan/Transfer</b>
                            </h4>
                        </div>
                        <dx:ASPxGridView ID="gv_detilpengajuan" ClientInstanceName="gv_detilpengajuan" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" OnBeforePerformDataSelect="gv_detilpengajuan_BeforePerformDataSelect" AutoGenerateColumns="False" DataSourceID="dsdetilpengajuan" KeyFieldName="ID">
                            <Settings ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="No Task" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="notask" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal Pengajuan" FieldName="tglpengajuan" Settings-AutoFilterCondition="Contains">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Pengajuan" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="jumlahpengajuan" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal Transfer" FieldName="tgltrf" Settings-AutoFilterCondition="Contains">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Transfer" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="jumlahtrf" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="No Referensi" FieldName="NoReferensi" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Status Transfer" FieldName="statustrf" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                        </dx:ASPxGridView>
                        <br />
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Rincian Penggunaan SPD</b>                                
                            </h4>
                            
                        </div>

                        <dx:ASPxGridView ID="gv_detailpenggunaanSPD" ClientInstanceName="gv_detailpenggunaanSPD" runat="server" EnableTheming="True" 
                            Theme="MetropolisBlue" Width="100%" OnBeforePerformDataSelect="gv_detailpenggunaanSPD_BeforePerformDataSelect" 
                            OnRowUpdating="gv_detailpenggunaanSPD_RowUpdating" OnRowDeleting="gv_detailpenggunaanSPD_RowDeleting" AutoGenerateColumns="False" 
                            DataSourceID="dspenggunaanSPD" KeyFieldName="ID">
                            <Settings ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <Columns>
                                <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" ShowDeleteButton="True" Width="100px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="15">
                                    <CellStyle BackColor="#d6f1ff">
                                    </CellStyle>
                                    <HeaderTemplate>
                                         <dx:ASPxButton ID="b_new_kosong" runat="server" ToolTip="New" OnClick="b_new_Click" RenderMode="Link" Text="New">
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer=confirm('Do you wish to process this new record?');}"/>
                                        </dx:ASPxButton>
                                    </HeaderTemplate>
                                </dx:GridViewCommandColumn>
                                <%--<dx:GridViewDataTextColumn Caption="#" HeaderStyle-HorizontalAlign="Center" Width="100px" VisibleIndex="15">
                                    <HeaderTemplate>
                                         <dx:ASPxButton ID="b_new_kosong" runat="server" ToolTip="New" OnClick="b_new_Click" RenderMode="Link" Text="New">
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer=confirm('Do you wish to process this new record?');}"/>
                                        </dx:ASPxButton>
                                    </HeaderTemplate>
                                    <DataItemTemplate>                                       
                                        <dx:ASPxButton ID="b_edit" runat="server" ToolTip="Edit" OnClick="b_edit_Click" RenderMode="Link"
                                            Text="Edit">
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer=confirm('Do you wish to process this edit record?');}"/>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="b_detele" runat="server" ToolTip="Delete" OnClick="buttonDelete_Click" RenderMode="Link"
                                            Text="Delete">
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer=confirm('Do you wish to Delete this record?');}"/>
                                        </dx:ASPxButton>
                                    </DataItemTemplate>                                    
                                </dx:GridViewDataTextColumn>--%>
                                <dx:GridViewDataTextColumn Caption="VID" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="VID" Settings-AutoFilterCondition="Contains">
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="iplan" FieldName="IPLAN" Settings-AutoFilterCondition="Contains">
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Nama Remote" FieldName="NAMAREMOTE" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jenis Pengeluaran" FieldName="JenisBiaya" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal" FieldName="TglInputBiaya" Settings-AutoFilterCondition="Contains">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Pengeluaran" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="Nominal" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Persetujuan" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="ApprovalNominal" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal Persetujuan" FieldName="TglApproveBiaya" Settings-AutoFilterCondition="Contains">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Catatan Persetujuan" FieldName="CatatanApproval" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="Status" Caption="Status Approval">
                                    <EditFormSettings Caption="Status Persetujuan" Visible="True" />
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                                        <Items>
                                            <dx:ListEditItem Text="Approve" Value="Approve" />
                                            <dx:ListEditItem Text="Reject" Value="Reject" />
                                        </Items>
                                        <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                 <dx:GridViewDataTextColumn Caption="Foto Bukti" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" FieldName="file_url" Settings-AutoFilterCondition="Contains">
                                     <DataItemTemplate>
                                        <a href="<%# Eval("file_url")%>" target="_blank">Gambar</a>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                        </dx:ASPxGridView>
                       
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dspengajuanuang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsdetilpengajuan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsgridlokasi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dspenggunaanSPD" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

