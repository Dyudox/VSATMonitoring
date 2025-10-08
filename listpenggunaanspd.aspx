<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="listpenggunaanspd.aspx.vb" Inherits="listpenggunaanspd" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Form List Penggunaan SPD</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gridpengajuanuang" KeyFieldName="NoTask" ClientInstanceName="gridpengajuanuang" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dspengajuanuang" EnableTheming="True" Theme="MetropolisBlue">
                <SettingsSearchPanel Visible="True" />
                <Settings ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsSearchPanel Visible="True" />
                <SettingsDetail ShowDetailButtons="true" ShowDetailRow="true" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="No. Task" HeaderStyle-HorizontalAlign="Center" FieldName="NoTask" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tgl. Task" HeaderStyle-HorizontalAlign="Center" FieldName="TanggalTask" VisibleIndex="1">
						<PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"/>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTeknisi" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Type Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="TypeTeknisi" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Uang Diterima (Transfer)" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="total" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Penggunaan Uang" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" HeaderStyle-HorizontalAlign="Center" FieldName="totalsuk" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="Total Persetujuan Penggunaan Uang" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" HeaderStyle-HorizontalAlign="Center" FieldName="approve" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total Jumlah Sisa / Kelebihan Dana" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" HeaderStyle-HorizontalAlign="Center" FieldName="sisa" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Input SPD per VID</b>
                            </h4>
                        </div>
                        <dx:ASPxGridView ID="gv_detilpengajuan" ClientInstanceName="gv_detilpengajuan" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" 
                            OnBeforePerformDataSelect="gv_detilpengajuan_BeforePerformDataSelect" AutoGenerateColumns="False" DataSourceID="dsdetilpengajuan" KeyFieldName="VID">
                            <Settings ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <SettingsDetail ShowDetailButtons="true" ShowDetailRow="true" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="VID" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" ReadOnly="true" Settings-AutoFilterCondition="Contains">
                                    <DataItemTemplate>
                                        <a href="formpenggunaanuang.aspx?VID=<%# Eval("VID")%>&notask=<%# Eval("NoTask")%>"><%# Eval("VID")%></a>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="IP LAN" FieldName="IPLAN" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nama Lokasi" FieldName="NAMAREMOTE" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Total Pengeluaran" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" FieldName="TotalPengeluaran" Settings-AutoFilterCondition="Contains">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                            <Templates>
                                <DetailRow>
                                    <dx:ASPxGridView ID="gv_subDetilpengajuan" ClientInstanceName="gv_subDetilpengajuan" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" 
                                        OnBeforePerformDataSelect="gv_subDetilpengajuan_BeforePerformDataSelect" AutoGenerateColumns="False" DataSourceID="dsSubdetilpengajuan" KeyFieldName="VID">
                                        <Settings ShowFooter="false" ShowGroupPanel="True" />
                                        <SettingsBehavior ConfirmDelete="True" />
                                        <SettingsPager>
                                            <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                        <%--<SettingsDetail ShowDetailButtons="true" ShowDetailRow="true" />--%>
                                        <Columns>                                            
                                            <dx:GridViewDataTextColumn Caption="Description Pengeluaran" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" 
                                                FieldName="JenisBiaya" Settings-AutoFilterCondition="Contains">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn> 
                                            <dx:GridViewDataTextColumn Caption="Nominal" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" 
                                                FieldName="Nominal" Settings-AutoFilterCondition="Contains">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>                                            
                                            <dx:GridViewDataTextColumn Caption="Tanggal" FieldName="TglInputBiaya" Settings-AutoFilterCondition="Contains">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Note" FieldName="CatatanTransaksi" Settings-AutoFilterCondition="Contains">
                                                <Settings AutoFilterCondition="Contains"></Settings>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Foto Bukti" FieldName="file_url" ReadOnly="true"
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
            
                                                        <!-- URL text (jika kamu mau tampilkan path-nya) -->
                                                        <%--<asp:TextBox ID="txtFileUrl" runat="server" 
                                                                     Text='<%# Bind("file_url") %>' 
                                                                     Width="250px" ReadOnly="true"
                                                                     CssClass="form-control" />--%>
                                                    </div>
                                                </EditItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsEditing Mode="EditFormAndDisplayRow" />
                                        <%--<Templates>
                                            <DetailRow>

                                            </DetailRow>
                                        </Templates>--%>
                                    </dx:ASPxGridView>
                                </DetailRow>
                            </Templates>
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
            <asp:SqlDataSource ID="dsSubdetilpengajuan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsgridlokasi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>

    <%--<div class="padding-md">
        <a href="#" class="btn btn-success"> Tambah Penggunaan </a>
        <br />
        <br />
        <div class="row">
            <table class="table table-striped" id="dataTable">
                <thead>
                    <tr>
                        <th>VID</th>
                        <th>No Task</th>
                        <th>Tanggal Penggunaan</th>
                        <th>Nama Teknisi</th>
                        <th>Tipe Teknisi</th>
                        <th>Pengeluaran</th>
                        <th>Nominal</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>SCM201818292019292019</td>
                        <td>20182918291</td>
                        <td>15-10-2018</td>
                        <td>Udin</td>
                        <td>Internal</td>
                        <td>Hotel</td>
                        <td>800.000</td>
                        <td><a href="formpenggunaanuang.aspx" class="label label-info">Edit</a> &nbsp; &nbsp; <a href="#" class="label label-info">Delete</a></td>
                    </tr>
                    <tr>
                        <td>SCM201818292019292019</td>
                        <td>20182918291</td>
                        <td>15-10-2018</td>
                        <td>Udin</td>
                        <td>Internal</td>
                        <td>Hotel</td>
                        <td>800.000</td>
                        <td><a href="formpenggunaanuang.aspx" class="label label-info">Edit</a> &nbsp; &nbsp; <a href="#" class="label label-info">Delete</a></td>
                    </tr>
                    <tr>
                        <td>SCM201818292019292019</td>
                        <td>20182918291</td>
                        <td>15-10-2018</td>
                        <td>Udin</td>
                        <td>Internal</td>
                        <td>Hotel</td>
                        <td>800.000</td>
                        <td><a href="formpenggunaanuang.aspx" class="label label-info">Edit</a> &nbsp; &nbsp; <a href="#" class="label label-info">Delete</a></td>
                    </tr>
                    <tr>
                        <td>SCM201818292019292019</td>
                        <td>20182918291</td>
                        <td>15-10-2018</td>
                        <td>Udin</td>
                        <td>Internal</td>
                        <td>Hotel</td>
                        <td>800.000</td>
                        <td><a href="formpenggunaanuang.aspx" class="label label-info">Edit</a> &nbsp; &nbsp; <a href="#" class="label label-info">Delete</a></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>--%>

    <script type="text/javascript">
        function showImagePopup(url) {
            var frame = document.getElementById("imageFrame");
            frame.src = url; // set URL gambar
            popupImage.Show(); // tampilkan popup DevExpress
        }
    </script>
</asp:Content>

