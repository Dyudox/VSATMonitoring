<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="formadminpantauSPD.aspx.vb" Inherits="formadminpantauSPD" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Form Transfer SPD</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
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
						<asp:ListItem Text="Done" Value="DONE"></asp:ListItem>
                        <asp:ListItem Text="Waiting" Value="kosong"></asp:ListItem>
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
                AutoGenerateColumns="False" DataSourceID="dspantauspd" EnableTheming="True" Theme="MetropolisBlue">
                <SettingsSearchPanel Visible="True" />
                <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsSearchPanel Visible="True" />
                <SettingsDetail ShowDetailRow="true" />
                <Columns>                    
                    <dx:GridViewCommandColumn HeaderStyle-HorizontalAlign="Center" ShowEditButton="True" VisibleIndex="10" FixedStyle="Left" Width="50px">
                        <CellStyle HorizontalAlign="Center" BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="No" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" 
                        FieldName="idtbl" VisibleIndex="0" Width="50">
                        <EditFormSettings Visible="false" />
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
                    <dx:GridViewDataTextColumn Caption="Note" Width="250" HeaderStyle-HorizontalAlign="Center" FieldName="keterangan" VisibleIndex="5">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jumlah Pengajuan" PropertiesTextEdit-DisplayFormatString="{0:n0}" 
                        PropertiesTextEdit-DisplayFormatInEditMode="true" Width="110"
                        HeaderStyle-HorizontalAlign="Center" FieldName="jumlahpengajuan" VisibleIndex="6">
                        <EditFormSettings Visible="false" />
                     </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jumlah Transfer" PropertiesTextEdit-DisplayFormatString="{0:n0}" PropertiesTextEdit-DisplayFormatInEditMode="true" HeaderStyle-HorizontalAlign="Center" FieldName="jumlahtrf" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Tgl. Transfer" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" HeaderStyle-HorizontalAlign="Center" FieldName="tgltrf" VisibleIndex="6">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="No. BPS" HeaderStyle-HorizontalAlign="Center" FieldName="NoReferensi" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="Note Finance" HeaderStyle-HorizontalAlign="Center" FieldName="notekeuangan" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                  <%--  <dx:GridViewDataTextColumn Caption="Status Transfer" HeaderStyle-HorizontalAlign="Center" FieldName="statustrf" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataComboBoxColumn FieldName="statustrf" Caption="Status Transfer" >
                        <EditFormSettings VisibleIndex="8" Caption="Status Transfer" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="DONE" Value="DONE" />
                                <dx:ListEditItem Text="PENDING" Value="PENDING" />                                
                            </Items>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
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
            <asp:SqlDataSource ID="dspantauspd" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>  
            <asp:SqlDataSource ID="dsdetailspd" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>         
        </div>
    </div>
</asp:Content>

