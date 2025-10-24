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
                    <dx:GridViewDataTextColumn Caption="No. Task" Width="100px" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FieldName="NoTask" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Task" Width="200px" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTask" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tgl. Task" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="TanggalTask" VisibleIndex="2">
						<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                    </dx:GridViewDataDateColumn>      
                    <dx:GridViewDataTextColumn Caption="Teknisi" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTeknisi" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Type Teknisi" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="IdStatusPegawai" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>              
                    <dx:GridViewDataTextColumn Caption="Provider" Visible="false" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="Provider" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdStatusManager" Width="100 PX" Caption="Status Manager" VisibleIndex="5">
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
                    <dx:GridViewDataTextColumn Caption="Pagu" PropertiesTextEdit-DisplayFormatString="{0:n0}" HeaderStyle-HorizontalAlign="Center" FieldName="pagu" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Estimasi Biaya" FieldName="estimasiBiaya" VisibleIndex="7">
                        <PropertiesTextEdit DisplayFormatString="{0:n0}" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Pengajuan Uang" PropertiesTextEdit-DisplayFormatString="{0:n0}" FieldName="totalPengajuan" 
                        HeaderStyle-HorizontalAlign="Center" VisibleIndex="8" Width="100%">
                    </dx:GridViewDataTextColumn>
                    
                    <%--<dx:GridViewDataTextColumn Caption="Pagu" PropertiesTextEdit-DisplayFormatString="{0:n0}" HeaderStyle-HorizontalAlign="Center" FieldName="pagu" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Pengajuan Uang" PropertiesTextEdit-DisplayFormatString="{0:n0}" FieldName="total" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>--%>

                    <dx:GridViewDataTextColumn Caption="Total Uang Diterima/Transfer" Visible="false" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="total" Width="200px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Penggunaan Uang" Visible="false" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" Width="200px" FieldName="totalsuk" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Persetujuan Penggunaan Uang" Visible="false" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" HeaderStyle-HorizontalAlign="Center" FieldName="approve" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Jumlah Sisa / Kelebihan Dana" Visible="false" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="sisa" Width="200px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>

                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Rincian Pengajuan/Transfer</b>
                            </h4>
                        </div>
                        <dx:ASPxGridView ID="gv_detilpengajuan" ClientInstanceName="gv_detilpengajuan" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" 
                            OnBeforePerformDataSelect="gv_detilpengajuan_BeforePerformDataSelect" AutoGenerateColumns="False" DataSourceID="dsdetilpengajuan" KeyFieldName="ID">
                            <Settings ShowFooter="false" ShowGroupPanel="True" />
                            <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="No Task" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="notask" Settings-AutoFilterCondition="Contains">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal Pengajuan" FieldName="tglpengajuan" Settings-AutoFilterCondition="Contains" Width="150px">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Pengajuan" PropertiesTextEdit-DisplayFormatString="{0:n0}" Width="150px" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="jumlahpengajuan" Settings-AutoFilterCondition="Contains">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal Transfer" FieldName="tgltrf" Settings-AutoFilterCondition="Contains">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Transfer" PropertiesTextEdit-DisplayFormatString="{0:n0}" Width="150px" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="jumlahtrf" Settings-AutoFilterCondition="Contains">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="No Referensi" FieldName="NoReferensi" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Status Transfer" FieldName="statustrf" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
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
                            <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <Columns>
                                <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" ShowDeleteButton="True" Width="100px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                    <CellStyle BackColor="#d6f1ff"></CellStyle>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <HeaderTemplate>
                                         <dx:ASPxButton ID="b_new_kosong" runat="server" ToolTip="New" OnClick="b_new_Click" RenderMode="Link" Text="New">
                                            <ClientSideEvents Click="function(s,e){ e.processOnServer=confirm('Do you wish to process this new record?');}"/>
                                        </dx:ASPxButton>
                                    </HeaderTemplate>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Foto Bukti" FieldName="file_url" ReadOnly="true"
                                    PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0"
                                    Settings-AutoFilterCondition="Contains">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    <DataItemTemplate>
                                        <%--<a href="javascript:void(0);" onclick="showImagePopup('<%# Eval("file_url") %>')">View</a>--%>
                                        <a href="javascript:void(0);"
                                           onclick='<%# "showImagePopup(""" & Eval("file_url") & """)" %>'
                                           style='<%# If(Eval("file_url") Is Nothing OrElse Eval("file_url").ToString() = "", "pointer-events:none; color:#ccc; text-decoration:none;", "color:blue; text-decoration:underline; cursor:pointer;") %>'>
                                            View
                                        </a>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
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
                                <dx:GridViewDataTextColumn Caption="VID" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" 
                                    CellStyle-HorizontalAlign="Center" ReadOnly="true" FieldName="VID" Settings-AutoFilterCondition="Contains" Width="150px">
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="iplan" FieldName="IPLAN" Settings-AutoFilterCondition="Contains" Visible="false">
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Nama Remote" FieldName="NAMAREMOTE" Settings-AutoFilterCondition="Contains" Width="200px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jenis Pengeluaran" FieldName="JenisBiaya" Settings-AutoFilterCondition="Contains" Width="150px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="Tanggal" FieldName="TglInputBiaya" Settings-AutoFilterCondition="Contains">
									<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Pengeluaran" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" 
                                    FieldName="Nominal" Settings-AutoFilterCondition="Contains" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" 
                                    ReadOnly="true" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Right" Width="150px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Jumlah Persetujuan" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" 
                                    FieldName="ApprovalNominal" Settings-AutoFilterCondition="Contains" Width="150px">
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
                                
                                <%--<dx:GridViewDataTextColumn Caption="Foto Bukti" FieldName="file_url" ReadOnly="true"
                                    PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0"
                                    Settings-AutoFilterCondition="Contains">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center" />
                                    <DataItemTemplate>
                                        <img src='<%# ResolveUrl(Eval("file_url").ToString()) %>' 
                                             alt="Foto Bukti" 
                                             style="width:60px; height:60px; object-fit:cover; border-radius:6px; cursor:pointer;"
                                             onclick="showImagePopup('<%# ResolveUrl(Eval("file_url").ToString()) %>')" />
                                    </DataItemTemplate>
                                    <EditItemTemplate>
                                        <div style="display:flex; align-items:center; gap:10px;">
                                            <!-- Thumbnail foto -->
                                            <img src='<%# ResolveUrl(Eval("file_url").ToString()) %>'
                                                 alt="Foto" 
                                                 style="width:60px; height:60px; object-fit:cover; border-radius:6px; cursor:pointer;"
                                                 onclick="showImagePopup('<%# ResolveUrl(Eval("file_url").ToString()) %>')" />            
                                        </div>
                                    </EditItemTemplate>
                                </dx:GridViewDataTextColumn>--%>
                                 <%--<dx:GridViewDataTextColumn Caption="Foto Bukti" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" FieldName="file_url" Settings-AutoFilterCondition="Contains">
                                     <DataItemTemplate>
                                        <a href="<%# Eval("file_url")%>" target="_blank">Gambar</a>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>--%>
                            </Columns>
                            <SettingsEditing Mode="PopupEditForm" />
                            <ClientSideEvents EndCallback="function(s, e) {
                                    if (s.cpWarning) {
                                        alert(s.cpWarning);
                                        s.cpWarning = null; // reset agar tidak muncul lagi
                                    }
                                }" />
                        </dx:ASPxGridView>
                        <dx:ASPxPopupControl ID="popupImage" runat="server" 
                            ClientInstanceName="popupImage"
                            Width="800px" 
                            Height="600px"
                            CloseAction="CloseButton"
                            HeaderText="Foto Bukti"
                            PopupHorizontalAlign="WindowCenter"
                            PopupVerticalAlign="WindowCenter"
                            AllowDragging="True"
                            Modal="True">
                            <ContentCollection>
                                <dx:PopupControlContentControl runat="server">
                                    <iframe id="imageFrame" src="" style="width:100%; height:550px; border:none;"></iframe>
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                        </dx:ASPxPopupControl>

                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dspengajuanuang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsdetilpengajuan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsgridlokasi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dspenggunaanSPD" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
    <script type="text/javascript">
        function showImagePopup(url) {
            var frame = document.getElementById("imageFrame");
            frame.src = url; // set URL gambar
            popupImage.Show(); // tampilkan popup DevExpress
        }
    </script>
</asp:Content>

