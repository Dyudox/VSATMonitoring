<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ms_Kelurahan.aspx.vb" Inherits="ms_Kelurahan" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
   <%-- <script type="text/javascript">
        function onkecamatanchanged(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            grid_kelurahan.GetEditor("idKecamatan").PerformCallback(comboValue.toString());
            alert(comboValue.toString());
        }

        var combo = null;
        var isUpdating = true;
    </script>--%>
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Kelurahan</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_kelurahan" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dskelurahan" KeyFieldName="ID" EnableTheming="True" Theme="MetropolisBlue" >
                <Settings ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="4">
                    </dx:GridViewCommandColumn>
                    <%--<dx:GridViewDataComboBoxColumn FieldName="idKota" HeaderStyle-HorizontalAlign="Center" Caption="Kota/Kabupaten" Visible="false">
                        <EditFormSettings Caption="Kota/Kabupaten" Visible="True" />
                        <PropertiesComboBox DataSourceID="dskota" TextField="Kota"
                            ValueField="idKota" IncrementalFilteringMode="Contains">
                            <ClientSideEvents SelectedIndexChanged="onkecamatanchanged"></ClientSideEvents>
                            <ValidationSettings RequiredField-IsRequired="true">
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>--%>
                    <dx:GridViewDataComboBoxColumn FieldName="idKecamatan" Caption="Kecamatan" VisibleIndex="1" Width="100px">
                        <%--<PropertiesComboBox DataSourceID="dskecamatan" TextField="Kecamatan" ValueField="IdKecamatan" 
                                        ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>--%>
                        <PropertiesComboBox TextField="Kecamatan" DataSourceID="dsloadkecamatan" ValueField="idKecamatan" ValueType="System.String" IncrementalFilteringMode="Contains" EnableCallbackMode="true" CallbackPageSize="7">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                        <%--<EditItemTemplate>
                            <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" Width="100%"
                                AutoGenerateColumns="False" DataSourceID="dskecamatan" Theme="Metropolis" KeyFieldName="idKecamatan" 
                                Value='<%# Bind("idKecamatan")%>' DisplayFormatString="{2}" IncrementalFilteringMode="Contains">
                                  <ClearButton DisplayMode="OnHover" />
                                <GridViewProperties>
                                    <SettingsBehavior AllowFocusedRow="True" AllowHeaderFilter="true" AllowSelectSingleRowOnly="True" />
                                </GridViewProperties>
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Provinsi" FieldName="Provinsi"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Kota/Kabupaten" FieldName="Kota"></dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Caption="idKecamatan" FieldName="idKecamatan"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Kecamatan" FieldName="Kecamatan"></dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridLookup>
                        </EditItemTemplate>--%>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="ID Kelurahan" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Width="100px" FieldName="idKelurahan" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Kelurahan" Width="100px" FieldName="Kelurahan" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dskota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msKota order by ID"></asp:SqlDataSource>
            <%--<asp:SqlDataSource ID="dskelurahan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msKelurahan order by ID"></asp:SqlDataSource>--%>
            <asp:SqlDataSource ID="dskelurahan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskecamatan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msKecamatan ">
                <SelectParameters>
                    <asp:Parameter Name="idKota" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsloadkecamatan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msKecamatan">
               
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

