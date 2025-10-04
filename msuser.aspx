<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="msuser.aspx.vb" Inherits="msuser" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Master User</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_kokab" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsuser" KeyFieldName="ID" EnableTheming="True" Theme="MetropolisBlue">
                <Settings />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                     <dx:GridViewCommandColumn ShowDeleteButton="True" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="7">
                    <CellStyle BackColor="#d6f1ff">
                    </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Nama" Width="200px" FieldName="UserName" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                          <PropertiesComboBox DataSourceID="dskaryawan" TextField="Nama" ValueField="NIK"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Password" Width="200px" FieldName="Password" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                        <PropertiesTextEdit Password="true" >
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Leveluser" Caption="Level User" VisibleIndex="3" Width="200px">
                        <PropertiesComboBox DataSourceID="dsleveluser" TextField="Name" ValueField="Name"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
            </dx:ASPxGridView>
            <br />
            <p><strong>Note:</strong>
                <br /> Apabila nama tidak ada di combo box pilihan, harap mendaftarkan data karyawan terlebih dahulu di master data karyawan.
            </p>
            <%--  <dx:BootstrapGridView ID="grid_kokab" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsuser" KeyFieldName="ID">
                <Settings />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <Columns>
                    <dx:BootstrapGridViewCommandColumn ShowDeleteButton="True" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="4">
                    </dx:BootstrapGridViewCommandColumn>
                    <dx:BootstrapGridViewTextColumn Caption="User Name" Width="100px" FieldName="UserName" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewTextColumn Caption="Password" Width="100px" FieldName="Password" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:BootstrapGridViewTextColumn>
                    <dx:BootstrapGridViewComboBoxColumn FieldName="Leveluser" Caption="Level User" VisibleIndex="3" Width="100px">
                        <PropertiesComboBox DataSourceID="dsleveluser" TextField="Name" ValueField="Name"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:BootstrapGridViewComboBoxColumn>
                </Columns>
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="inline" />
                <SettingsPopup>
                    <EditForm Width="600" />
                </SettingsPopup>
            </dx:BootstrapGridView>--%>
            <asp:SqlDataSource ID="dsuser" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsleveluser" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msleveluser]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskaryawan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT Nama, NIK FROM [msEmployee]"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

