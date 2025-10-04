<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_Status.aspx.vb" Inherits="ms_Status" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Status</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="gridstatus" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsstatus" KeyFieldName="ID" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowGroupPanel="True"  ShowFooter="false" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff"  ShowDeleteButton="True" Width="20px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="2">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="Status" HeaderStyle-HorizontalAlign="Center" width="100px"  VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="FlagUser" HeaderStyle-HorizontalAlign="Center" Caption="User" Width="100px" VisibleIndex="1">
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="All User" Value="All" />
                                <dx:ListEditItem Text="Non Teknisi" Value="NonTeknisi" />
                                <dx:ListEditItem Text="Teknisi" Value="Teknisi" />
                            </Items>                            
                        </PropertiesComboBox>                        
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="FlagUnitKerja" HeaderStyle-HorizontalAlign="Center" Caption="Jenis Pekerjaan" Width="100px" VisibleIndex="1">
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="Installasi" Value="Installasi" />
                                <dx:ListEditItem Text="Survey" Value="Survey" />
                            </Items>                            
                        </PropertiesComboBox>                        
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dsstatus" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

