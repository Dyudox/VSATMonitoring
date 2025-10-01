<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_JenisPekerjaan.aspx.vb" Inherits="ms_JenisPekerjaan" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Pekerjaan</li>
        </ul>
    </div>
    <div class="padding-md"> 
        <div class="row">
            <dx:ASPxGridView  ID="grid_jeniskerja" ClientInstanceName="grid_jeniskerja" runat="server" Width="600px" AutoGenerateColumns="False" DataSourceID="dsjeniskerja" KeyFieldName="ID" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowFooter="false" ShowGroupPanel="True"  />
                <SettingsBehavior ConfirmDelete="True" />
                 <SettingsPager>
                       <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                  </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                   <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff"  HeaderStyle-HorizontalAlign="Center" ShowDeleteButton="True" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="3">
                      <CellStyle BackColor="#d6f1ff">
                    </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Kode Service" HeaderStyle-HorizontalAlign="Center" Width="30px" FieldName="KodeService" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Service" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="Service" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
             <asp:SqlDataSource ID="dsjeniskerja" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

