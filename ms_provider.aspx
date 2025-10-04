<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_provider.aspx.vb" Inherits="ms_provider" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Provider</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_provider" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsprovider" KeyFieldName="id" EnableTheming="True" Theme="MetropolisBlue">
                <SettingsSearchPanel Visible="True" />
                <Settings ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsSearchPanel Visible="True" />
                <Columns>

                    <dx:GridViewCommandColumn ShowDeleteButton="True" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="7">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Provider" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="Nama_Provider" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Alamat" Width="200px" HeaderStyle-HorizontalAlign="Center" FieldName="Alamat" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telp" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="Telp" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^[0-9]+$" ErrorText="Number Only" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Email" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="Email" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorText="Invalid e-mail" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Fax" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="Fax" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^[0-9]+$" ErrorText="Number Only" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Description" Width="200px" HeaderStyle-HorizontalAlign="Center" FieldName="Desc_Provider" Settings-AutoFilterCondition="Contains" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>

                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dsprovider" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

