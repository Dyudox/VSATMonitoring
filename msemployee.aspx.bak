<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="msemployee.aspx.vb" Inherits="msemployee" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        //function onprovinsichange(cmbParent) {
        //    var comboValue = cmbParent.GetSelectedItem().value;
        //    if (isUpdating)
        //        //return;
        //        gv_detilemployee.GetEditor("idKota").PerformCallback(comboValue.toString());
        //    if (comboValue)
        //        gv_detilemployee.GetEditor("idKota").PerformCallback(comboValue.toString());
        //    // alert(comboValue.toString());
        //}
        function onCityChanged(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            grid_employee.GetEditor("IdHomeBaseCity").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }


        function onkotachanged(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            grid_employee.GetEditor("idKota").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }
        var combo = null;
        var isUpdating = true;
    </script>

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Karyawan</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_employee" ClientInstanceName="grid_employee" runat="server" DataSourceID="dsemployee" KeyFieldName="ID" Width="100%" AutoGenerateColumns="false" OnCellEditorInitialize="grid_employee_CellEditorInitialize" OnRowValidating="grid_employee_RowValidating" Theme="MetropolisBlue">
                <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <SettingsDetail ShowDetailRow="true" />
                <Columns>
                    <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="7">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="NIK" Width="200%" HeaderStyle-HorizontalAlign="Center" FieldName="NIK" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                        <EditFormSettings Caption="NIK" VisibleIndex="0" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama" Width="200%" HeaderStyle-HorizontalAlign="Center" FieldName="Nama" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <EditFormSettings Caption="Nama" VisibleIndex="1" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Coordinator" HeaderStyle-HorizontalAlign="Center" Caption="Koordinator" VisibleIndex="2" Width="100px">
                        <PropertiesComboBox DataSourceID="dscoordinator" TextField="Nama"
                            ValueField="Nama" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                            <%--<ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>--%>
                        </PropertiesComboBox>
                        <EditFormSettings Caption="Koordinator" VisibleIndex="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdHomeBaseProvinsi" HeaderStyle-HorizontalAlign="Center" Caption="Homebase" VisibleIndex="3" Width="150px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox DataSourceID="dsprovinsihomebase" TextField="Provinsi"
                            ValueField="IdProvinsi" EnableSynchronization="False" IncrementalFilteringMode="StartsWith" ValidationSettings-RequiredField-IsRequired="true">
                            <ClientSideEvents SelectedIndexChanged="onCityChanged"></ClientSideEvents>
                        </PropertiesComboBox>
                        <EditFormSettings VisibleIndex="3" Caption="Homebase" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdHomeBaseCity" Visible="false" HeaderStyle-HorizontalAlign="Center" Caption="City Homebase" VisibleIndex="4" Width="200px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <EditFormSettings VisibleIndex="4" Caption="City Homebase" Visible="True" />
                        <PropertiesComboBox DataSourceID="dskotahombase" TextField="Kota" ValueField="idKota" 
                            IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Alamat Homebase" HeaderStyle-HorizontalAlign="Center" Width="250px" FieldName="AlamatHomeBase" Settings-AutoFilterCondition="Contains" VisibleIndex="5">
                        <EditFormSettings VisibleIndex="5" Caption="Alamat Homebase" />
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdStatus" HeaderStyle-HorizontalAlign="Center" Caption="Status" VisibleIndex="6" Width="100%">
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="Active" Value="Active" />
                                <dx:ListEditItem Text="Non Active" Value="Non Active" />
                            </Items>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <EditFormSettings VisibleIndex="6" Caption="Status" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Email" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="Email" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings Caption="Email" Visible="True" VisibleIndex="7" />
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorText="Invalid e-mail" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Phone" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="NomorHP" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings Caption="Phone" Visible="True" VisibleIndex="8" />
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^[0-9]+$" ErrorText="Number Only" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Domisili" Width="250px" HeaderStyle-HorizontalAlign="Center" FieldName="Alamat" Settings-AutoFilterCondition="Contains" Visible="false">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <EditFormSettings Caption="Alamat Domisili" Visible="True" VisibleIndex="9" />
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdProvinsi" HeaderStyle-HorizontalAlign="Center" Caption="Provinsi" Visible="false">
                        <EditFormSettings Caption="Provinsi" Visible="True" VisibleIndex="10" />
                        <PropertiesComboBox DataSourceID="dsprovinsi" TextField="Provinsi"
                            ValueField="IdProvinsi" IncrementalFilteringMode="Contains">
                            <ClientSideEvents SelectedIndexChanged="onkotachanged"></ClientSideEvents>
                            <ValidationSettings RequiredField-IsRequired="true">
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="idKota" HeaderStyle-HorizontalAlign="Center" Caption="Kota" Visible="false">
                        <EditFormSettings Caption="Kota" Visible="True" VisibleIndex="11" />
                        <PropertiesComboBox DataSourceID="dsKota" TextField="Kota" ValueField="idKota"
                            IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="EmployeeType" HeaderStyle-HorizontalAlign="Center" Caption="Employee Type" VisibleIndex="5" Width="100px">
                        <EditFormSettings Caption="Employee Type" Visible="True" VisibleIndex="12" />
                        <PropertiesComboBox ValueType="System.String" DataSourceID="dsleveluser" TextField="Description" ValueField="Description" IncrementalFilteringMode="Contains">                            
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdStatusPegawai" HeaderStyle-HorizontalAlign="Center" Caption="Status Pegawai" Visible="false" Width="100px">
                        <EditFormSettings Caption="Status Pegawai" Visible="True" VisibleIndex="13" />
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="Internal" Value="Internal" />
                                <dx:ListEditItem Text="Kontrak" Value="Kontrak" />
                                <dx:ListEditItem Text="Service Representative" Value="Service Representative" />
                                <dx:ListEditItem Text="Sub Cont" Value="subcont" />
                            </Items>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdPerusahaan" HeaderStyle-HorizontalAlign="Center" Caption="Perusahaan" Visible="false">
                        <EditFormSettings Caption="Perusahaan" Visible="True" VisibleIndex="14" />
                        <PropertiesComboBox DataSourceID="dsperusahaan" TextField="NamaPerusahaan" ValueField="Id"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataTextColumn Caption="Account Bank" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="AccountBank" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings Caption="Account Bank" Visible="True" VisibleIndex="15" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Bank" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="NamaBank" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings Caption="Nama Bank" Visible="True" VisibleIndex="16" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Rekening Bank" HeaderStyle-HorizontalAlign="Center" Width="100px" FieldName="RekeningBank" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings Caption="Rekening Bank" Visible="True" VisibleIndex="17" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>

                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="gv_detilemployee" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" OnBeforePerformDataSelect="gv_detilemployee_DataSelect" AutoGenerateColumns="False" DataSourceID="dsdetilemployee" KeyFieldName="ID">
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Email" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="Email" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Phone" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="NomorHP" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Alamat" Width="250px" HeaderStyle-HorizontalAlign="Center" FieldName="Alamat" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="IdProvinsi" HeaderStyle-HorizontalAlign="Center" Caption="Provinsi" VisibleIndex="3" Width="100px">
                                    <PropertiesComboBox DataSourceID="dsprovinsiload" TextField="Provinsi" ValueField="IdProvinsi" IncrementalFilteringMode="Contains">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="idKota" HeaderStyle-HorizontalAlign="Center" Caption="Kota" VisibleIndex="4" Width="100px">
                                    <PropertiesComboBox DataSourceID="dsKotaload" TextField="Kota" ValueField="idKota" IncrementalFilteringMode="Contains">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="EmployeeType" HeaderStyle-HorizontalAlign="Center" Caption="Employee Type" VisibleIndex="5" Width="100px">
                                    <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                                        <Items>
                                            <dx:ListEditItem Text="SR" Value="sr" />
                                            <dx:ListEditItem Text="Coordinator" Value="coor" />
                                            <dx:ListEditItem Text="Account Manager" Value="am" />
                                            <dx:ListEditItem Text="Manager" Value="manager" />
                                        </Items>
                                        <ValidationSettings RequiredField-IsRequired="true">
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="IdStatusPegawai" HeaderStyle-HorizontalAlign="Center" Caption="Status Pegawai" VisibleIndex="6" Width="100px">
                                    <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                                        <Items>
                                            <dx:ListEditItem Text="Internal" Value="Internal" />
                                            <dx:ListEditItem Text="Kontrak" Value="Kontrak" />
                                            <dx:ListEditItem Text="Service Representative" Value="Service Representative" />
                                        </Items>
                                        <ValidationSettings RequiredField-IsRequired="true">
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="IdPerusahaan" HeaderStyle-HorizontalAlign="Center" Caption="Perusahaan" VisibleIndex="7" Width="100px">
                                    <PropertiesComboBox DataSourceID="dsperusahaan" TextField="NamaPerusahaan" ValueField="Id"
                                        ValueType="System.String" IncrementalFilteringMode="Contains">
                                        <ValidationSettings RequiredField-IsRequired="true">
                                            <RequiredField IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn Caption="Account Bank" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="AccountBank" Settings-AutoFilterCondition="Contains" VisibleIndex="8">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nama Bank" HeaderStyle-HorizontalAlign="Center" Width="150px" FieldName="NamaBank" Settings-AutoFilterCondition="Contains" VisibleIndex="9">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Rekening Bank" HeaderStyle-HorizontalAlign="Center" Width="100px" FieldName="RekeningBank" Settings-AutoFilterCondition="Contains" VisibleIndex="10">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                            </Columns>

                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="dsleveluser" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msLevelUser"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsperusahaan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msperusahaan]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsemployee" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovinsihomebase" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskotahombase" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota] where idProvinsi = @idProvinsi ">
                <SelectParameters>
                    <asp:Parameter Name="idProvinsi" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovinsi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovinsiload" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsKota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota] where IdProvinsi = @IdProvinsi ">
                <SelectParameters>
                    <asp:Parameter Name="IdProvinsi" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsKotaload" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsdetilemployee" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dscoordinator" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msEmployee where EmployeeType='Coordinator'"></asp:SqlDataSource>
            <%--  <asp:SqlDataSource ID="dskecamatan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskecamatan]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskelurahan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskelurahan]"></asp:SqlDataSource>--%>
            <%--   <asp:SqlDataSource ID="dsdetilemployee" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovinsihombase" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskotahombase" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota] where IdProvinsi = @IdProvinsi"">
                <SelectParameters>
                        <asp:Parameter Name="IdProvinsi" Type="String" />
                    </SelectParameters>
            </asp:SqlDataSource>--%>
        </div>
    </div>
</asp:Content>

