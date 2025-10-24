<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="formadminpantauSPD.aspx.vb" Inherits="formadminpantauSPD" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Form Transfer SPD</li>
        </ul>
    </div>
    <div class="padding-md">
        <div id="searchSPD" runat="server" class="row">
            <div class="col-lg-2">
                <div class="form-group">
                    <label class="bmd-label-floating" style="font-size: 12px;">Start Date</label>
                    <dx:ASPxDateEdit ID="startdate" runat="server" Theme="MetropolisBlue" Height="35px" 
                        DisplayFormatString="dd/MM/yyyy" EditFormat="Date"></dx:ASPxDateEdit>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label class="bmd-label-floating" style="font-size: 12px;">End Date</label>
                    <dx:ASPxDateEdit ID="enddate" runat="server" Theme="MetropolisBlue" Height="35px" 
                        DisplayFormatString="dd/MM/yyyy" EditFormat="Date"></dx:ASPxDateEdit>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label class="bmd-label-floating" style="font-size: 12px;">Status Transfer</label>
                    <asp:DropDownList ID="dd_statusTransfer" runat="server" CssClass="form-control">  
                        <asp:ListItem Text="-Select-" Value=""></asp:ListItem>
                        <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                        <asp:ListItem Text="Pending" Value="PENDING"></asp:ListItem>
						<asp:ListItem Text="Done" Value="DONE"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2">
                <div style="padding-bottom:20px"></div>
                <asp:Button ID="btnfilter" CssClass="btn btn-info" runat="server" Text="show" />
            </div>
        </div>
        <div class="seperator"></div>
        <div class="row">
            <dx:ASPxGridView ID="gridpantauSPD" KeyFieldName="idtbl" ClientInstanceName="gridpantauSPD" runat="server" Width="100%" 
                AutoGenerateColumns="False" DataSourceID="dspantauspd" EnableTheming="True" Theme="MetropolisBlue"
                OnRowValidating="gridpantauSPD_RowValidating" >
                
                <%--<ClientSideEvents EndCallback="function(s, e) {
                    if (s.cpMessage) {
                        alert(s.cpMessage); // ✅ tampilkan pesan sukses
                        s.cpMessage = null;
                    }
                    if (s.cpMessageError) {
                        alert(s.cpMessageError); // ❌ tampilkan pesan error
                        s.cpMessageError = null;
                    }
                }" />--%>
                <SettingsSearchPanel Visible="True" />
                <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />                
                <SettingsSearchPanel Visible="True" />
                <SettingsDetail ShowDetailRow="true" />                
                <Columns>                    
                    <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" ShowEditButton="True" VisibleIndex="0" Width="50px">
                        <CellStyle HorizontalAlign="Center" BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="No" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" 
                        FieldName="idtbl" VisibleIndex="1" Width="50">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Foto Bukti Transfer" FieldName="fileTransf_url" ReadOnly="true"
                        PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" VisibleIndex="1"
                        Settings-AutoFilterCondition="Contains">
                        <EditFormSettings VisibleIndex="8" Visible="True" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <DataItemTemplate>
                            <%--<a href="javascript:void(0);" onclick="showImagePopup('<%# Eval("fileTransf_url") %>')">View</a>--%>
                            <a href="javascript:void(0);"
                               onclick='<%# "showImagePopup(""" & Eval("fileTransf_url") & """)" %>'
                               style='<%# If(Eval("fileTransf_url") Is Nothing OrElse Eval("fileTransf_url").ToString() = "", "pointer-events:none; color:#ccc; text-decoration:none;", "color:blue; text-decoration:underline; cursor:pointer;") %>'>
                                View
                            </a>                            
                        </DataItemTemplate>
                        <EditItemTemplate>
                            <div style="display:flex; align-items:center; gap:10px;">
                                <asp:TextBox ID="txtFileUrl" runat="server"
                                Text='<%# Eval("fileTransf_url") %>'
                                ReadOnly="true"
                                CssClass="form-control"
                                Style="width:100px; background-color:#f5f5f5;" />
                                <dx:ASPxUploadControl ID="UploadBukti" runat="server"
                                    UploadMode="Auto"
                                    ShowUploadButton="True"
                                    ShowProgressPanel="True"
                                    ClientInstanceName="uploadBukti"
                                    Width="100px"
                                    OnFileUploadComplete="UploadBukti_FileUploadComplete">
                                    <ClientSideEvents 
                                        FileUploadComplete="function(s, e) {
                                            if (e.isValid) {
                                                // setelah upload selesai, isi hidden field dengan url hasil upload
                                                var hidden = ASPxClientControl.Cast('hiddenFileUrl');
                                                hidden.Set('fileTransf_url', e.callbackData);
                                            }
                                        }" />
                                </dx:ASPxUploadControl>    
                                <dx:ASPxHiddenField ID="hiddenFileUrl" runat="server" ClientInstanceName="hiddenFileUrl" />
                            </div>
                        </EditItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tgl. Pengajuan" HeaderStyle-HorizontalAlign="Center" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" FieldName="tglpengajuan" VisibleIndex="1">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="No. Task" HeaderStyle-HorizontalAlign="Center" FieldName="NoTask" VisibleIndex="2">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Provider" HeaderStyle-HorizontalAlign="Center" FieldName="Provider" VisibleIndex="2">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Perusahaan" HeaderStyle-HorizontalAlign="Center" FieldName="Perusahaan" VisibleIndex="2">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="NamaTeknisi" VisibleIndex="3">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Type Teknisi" HeaderStyle-HorizontalAlign="Center" FieldName="TypeTeknisi" VisibleIndex="4">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="statustrf" Caption="Status Transfer" VisibleIndex="5" >
                        <EditFormSettings VisibleIndex="8" Caption="Status Transfer" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="DONE" Value="DONE" />
                                <dx:ListEditItem Text="PENDING" Value="PENDING" />                                
                            </Items>
                            <ValidationSettings RequiredField-IsRequired="false"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Note" Width="250" HeaderStyle-HorizontalAlign="Center" FieldName="keterangan" VisibleIndex="5">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jumlah Pengajuan" PropertiesTextEdit-DisplayFormatString="{0:n0}" 
                        PropertiesTextEdit-DisplayFormatInEditMode="true" Width="110"
                        HeaderStyle-HorizontalAlign="Center" FieldName="jumlahpengajuan" VisibleIndex="6">
                        <EditFormSettings Visible="false" />
                     </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jumlah Transfer" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" 
                        HeaderStyle-HorizontalAlign="Center" FieldName="jumlahtrf" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tgl. Transfer" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" HeaderStyle-HorizontalAlign="Center" 
                        FieldName="tgltrf" VisibleIndex="6">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="No. BPS" HeaderStyle-HorizontalAlign="Center" FieldName="NoReferensi" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="Note Finance" HeaderStyle-HorizontalAlign="Center" FieldName="notekeuangan" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    
                    <%--<dx:GridViewDataTextColumn Caption="Foto Bukti" FieldName="fileTransf_url" ReadOnly="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center" />
                        <DataItemTemplate>
                            <img src='<%# ResolveUrl(Eval("fileTransf_url").ToString()) %>'
                                 alt="Foto Bukti"
                                 style="width:60px; height:60px; object-fit:cover; border-radius:6px; cursor:pointer;"
                                 onclick="showImagePopup('<%# ResolveUrl(Eval("fileTransf_url").ToString()) %>')" />
                        </DataItemTemplate>
                        <EditItemTemplate>
                            <div style="display:flex; align-items:center; gap:10px;">
                                <img src='<%# ResolveUrl(Eval("fileTransf_url").ToString()) %>'
                                     alt="Foto"
                                     style="width:60px; height:60px; object-fit:cover; border-radius:6px;" />
                                <dx:ASPxUploadControl ID="UploadBukti" runat="server"
                                    UploadMode="Auto"
                                    ShowUploadButton="True"
                                    ShowProgressPanel="True"
                                    ClientInstanceName="uploadBukti"
                                    Width="250px"
                                    OnFileUploadComplete="UploadBukti_FileUploadComplete">
                                </dx:ASPxUploadControl>
                            </div>
                        </EditItemTemplate>
                    </dx:GridViewDataTextColumn>--%>
                  <%--  <dx:GridViewDataTextColumn Caption="Status Transfer" HeaderStyle-HorizontalAlign="Center" FieldName="statustrf" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>--%>                    
                </Columns>
                <SettingsEditing Mode="PopupEditForm" />
                <%--<SettingsPopup>
                    <EditForm Modal="True" HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                </SettingsPopup>--%>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="grid_DetailSPD" ClientInstanceName="grid_DetailSPD" runat="server" DataSourceID="dsdetailspd" Width="100%" 
                            OnBeforePerformDataSelect="grid_DetailSPD_BeforePerformDataSelect" AutoGenerateColumns="false" Theme="MetropolisBlue">
                            <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <SettingsSearchPanel Visible="True" />
                            <Columns>                                                                              
                                <dx:GridViewDataComboBoxColumn FieldName="VID" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="200px" ReadOnly="true" PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0">
                                    <EditFormSettings VisibleIndex="1" /> 
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="IPLAN" HeaderStyle-HorizontalAlign="Center" Caption="IP LAN" Width="100px">
                                    <EditFormSettings Visible="false" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ProjectName" HeaderStyle-HorizontalAlign="Center" Caption="Nama Project">
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
            <dx:ASPxCallbackPanel ID="cbNotify" runat="server" ClientInstanceName="cbNotify">
                <PanelCollection>
                    <dx:PanelContent>
                        <dx:ASPxLabel ID="lblNotify" runat="server" ForeColor="Green" Font-Bold="True"></dx:ASPxLabel>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>
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
            <asp:SqlDataSource ID="dspantauspd" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>  
            <asp:SqlDataSource ID="dsdetailspd" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>         
        </div>        
    </div>
    <script type="text/javascript">
        function showSuccess(message) {
            DevExpress.ui.notify({
                message: message,
                type: 'success',
                displayTime: 2500,
                position: { my: "top center", at: "top center" }
            });
        }
        function showError(message) {
            DevExpress.ui.notify({
                message: message,
                type: 'error',
                displayTime: 3000,
                position: { my: "top center", at: "top center" }
            });
        }
    </script>

    <script type="text/javascript">
        function showImagePopup(url) {
            var frame = document.getElementById("imageFrame");
            frame.src = url; // set URL gambar
            popupImage.Show(); // tampilkan popup DevExpress
        }
    </script>
</asp:Content>

