<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_hub.aspx.vb" Inherits="ms_hub" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Hub</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_hub"  KeyFieldName="id" ClientInstanceName="grid_hub" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dshub" EnableTheming="True" Theme="MetropolisBlue">
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
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="6">
                    <CellStyle BackColor="#d6f1ff">
                    </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Kode Hub" HeaderStyle-HorizontalAlign="Center" Width="5%" FieldName="id" CellStyle-HorizontalAlign="Center" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Hub" HeaderStyle-HorizontalAlign="Center" FieldName="Hub" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Simbol Read" HeaderStyle-HorizontalAlign="Center" FieldName="Simbol_Read" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Frekwensi" HeaderStyle-HorizontalAlign="Center" FieldName="Frekwensi" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Keterangan" HeaderStyle-HorizontalAlign="Center" FieldName="Desc_Hub" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                </Columns>

            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dshub" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT [id], [Hub], [Simbol_Read], [Frekwensi], [Desc_Hub] FROM [msHub]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

