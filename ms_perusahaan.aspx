<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_perusahaan.aspx.vb" Inherits="ms_perusahaan" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Perusahaan</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_perusahaan" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsperusahaan" KeyFieldName="Id" EnableTheming="True" Theme="MetropolisBlue">
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
                    <dx:GridViewCommandColumn ShowDeleteButton="True" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" Width="100px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="7">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
					<dx:GridViewDataTextColumn Caption="ID" ReadOnly="true" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="Id" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="Kode Perusahaan" HeaderStyle-HorizontalAlign="Center" FieldName="inisialPerusahaan" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Perusahaan" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="NamaPerusahaan" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Alamat" Width="350px" HeaderStyle-HorizontalAlign="Center" FieldName="Alamat" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Telp" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="Telp" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^[0-9]+$" ErrorText="Number Only" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Email" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="Email" Settings-AutoFilterCondition="Contains" VisibleIndex="4">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorText="Invalid e-mail" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Fax" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="Fax" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^[0-9]+$" ErrorText="Number Only" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Description" Width="200px" HeaderStyle-HorizontalAlign="Center" FieldName="Description" Settings-AutoFilterCondition="Contains" VisibleIndex="6">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="false">
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dsperusahaan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

