<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="project.aspx.vb" Inherits="project" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">    
    <script>        
        function onCityChanged(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            grid_project.GetEditor("CustKota").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }

        var combo = null;
        var isUpdating = true;
    </script>
    <script>
        function UserCustomerConfirmation() {
            if (confirm("what do you want to process?"))
                return true;
            else
                return false;
        }
    </script>

    <script type="text/javascript">
        function OnGridFocusedRowChanged() {
            // Query the server for the "EmployeeID" and "Notes" fields from the focused row
            // The values will be returned to the OnGetRowValues() function
            DetailNotes.SetText("Loading...");
            grid_project.GetRowValues(grid_project.GetFocusedRowIndex(), 'ID', OnGetRowValues);
        }
        // Value array contains "EmployeeID" and "Notes" field values returned from the server
        function OnGetRowValues(values) {
            DetailImage.SetImageUrl("FocusedRow.aspx?Photo=" + values[0]);
            DetailImage.SetVisible(true);
            DetailNotes.SetText(values[1]);
        }
    </script>
    <script type="text/javascript">

        //function onRowDblClick(s, e) {
        //    //alert("test1");
        //    s.GetSelectedFieldValues('ID', onRowDblClickVal);

        //}
        //function onRowDblClickVal(val) {
        //    //var loginID = document.getElementById("ASPxLabel2").value;
        //    alert(val);
        //    MainContent_grid_project.SetVisible(true);
        //    //if (val.length > 1) {
        //    //    MM_openBrWindow(val[val.length - 1], "PlayVoiceHTML5", "450", "350")
        //    //    //alert(MM_openBrWindow);
        //    //}
        //    //else
        //    //    MM_openBrWindow(val, "PlayVoiceHTML5", "450", "350")
        //    ////alert(MM_openBrWindow);
        //}

        //var doProcessClick;
        //var visibleIndex;

        //function ProcessClick() {
        //    if (doProcessClick) {
        //        alert("Here is the RowClick action in the " + visibleIndex.toString() + "-th row");
        //    }
        //}

        //function OnRowClick(s, e) {
        //    doProcessClick = true;
        //    visibleIndex = e.visibleIndex + 1;
        //    window.setTimeout(ProcessClick, 500);
        //}

        //function OnRowDblClick(s, e) {
        //    doProcessClick = false;
        //    var key = s.GetRowKey(e.visibleIndex);
        //    alert('Here is the RowDoubleClick action in a row with the Key = ' + key);
        //    //MainContent_grid_project.SetVisible = true;
        //    MainContent_grid_project.show(true);
        //    MainContent_grid_project.SetText(values[1]);
        //}

        function OnRowDblClick(s, e) {
            e.processOnServer = false;
            var index = e.visibleIndex;
            //var key = s.GetRowKey(e.visibleIndex);
            //alert('Here is the RowDoubleClick action in a row with the Key = ' + key);

            s.CollapseAllDetailRows();   // tutup semua row detail
            s.ExpandDetailRow(index);    // buka detail row yg diklik
        }

        function get_filename(input) {
            var fileName = input.value.split('\\').pop();
            document.getElementById("fileNameLabel").innerText = fileName || "No file selected...";
        }

        function clearFile() {
            var fileInput = document.getElementById("<%= fl_upload.ClientID %>");
            fileInput.value = ""; // reset file input
            document.getElementById("fileNameLabel").innerText = "";
        }

    </script>    

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Data Project</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <dx:ASPxGridView ID="grid_project" ClientInstanceName="grid_project" runat="server" Width="100%" AutoGenerateColumns="False" 
                DataSourceID="dsproject" OnCellEditorInitialize="grid_project_CellEditorInitialize" KeyFieldName="ID" EnableTheming="True" 
                Theme="MetropolisBlue">
                <Settings ShowFooter="false" HorizontalScrollBarMode="Visible" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" AllowSelectByRowClick="true" AllowFocusedRow="false"/>
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDetail ShowDetailRow="true" />
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow"  />
                <Styles>
                    <%--<Header BackgroundImage-ImageUrl="images/footer.jpg" ForeColor="White">--%>
                    <%--<Header BackColor="#0090c2" ForeColor="White">--%>
                    <%--<Header BackColor="#0090c2" ForeColor="White">
                    </Header>--%>
                    <SelectedRow BackColor="#718ea9" ForeColor="White">
                    </SelectedRow>
                    <Footer></Footer>
                </Styles>
                <%--<ClientSideEvents RowDblClick="function(s, e) {onRowDblClick(s,e);}" />--%>                
                <%--<ClientSideEvents RowClick="OnRowClick" RowDblClick="OnRowDblClick"/>--%>
                <%--<ClientSideEvents FocusedRowChanged="function(s, e) { OnGridFocusedRowChanged(); }" />--%>
                <ClientSideEvents RowDblClick="OnRowDblClick"/>
                <Columns>
                    <dx:GridViewCommandColumn FixedStyle="Left" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="True" Width="100px" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True"  VisibleIndex="15">
                        <CellStyle BackColor="#d6f1ff">
                        </CellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="ID Project" Width="150px" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" HeaderStyle-HorizontalAlign="Center" FieldName="IdProject" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <%-- <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>--%>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nomor Kontrak" Width="150px" HeaderStyle-HorizontalAlign="Center" FieldName="NoKontrak" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nama Project" Width="100px" FieldName="ProjectName" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdAM" HeaderStyle-HorizontalAlign="Center" Caption="Account Manager" VisibleIndex="3" Width="100px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox DataSourceID="dsAM" TextField="Nama" ValueField="Nama"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdProvider" HeaderStyle-HorizontalAlign="Center" Caption="Nama Provider" VisibleIndex="4" Width="100px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox DataSourceID="dsProvider" TextField="Nama_Provider" ValueField="Nama_Provider"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdPelanggan" HeaderStyle-HorizontalAlign="Center" Caption="Nama Pelanggan" VisibleIndex="5" Width="100px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox DataSourceID="dsPelanggan" TextField="Customer" ValueField="Customer"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataDateColumn FieldName="StartDate" HeaderStyle-HorizontalAlign="Center" Caption="Mulai Kontrak" VisibleIndex="6" Width="100px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EndDate" HeaderStyle-HorizontalAlign="Center" Caption="Akhir Kontrak" VisibleIndex="7" Width="100px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"> 
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Paket Layanan" Width="100px" FieldName="IdPaketLayanan" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" VisibleIndex="8">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IsInstalasi" HeaderStyle-HorizontalAlign="Center" Caption="Instalasi" VisibleIndex="9" Width="100px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="Ya" Value="true" />
                                <dx:ListEditItem Text="Tidak" Value="false" />
                            </Items>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IsPMCM" HeaderStyle-HorizontalAlign="Center" Caption="PMCM" VisibleIndex="10" Width="100px">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="Ya" Value="true" />
                                <dx:ListEditItem Text="Tidak" Value="false" />
                            </Items>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataTextColumn Caption="PIC" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="CustPIC" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings VisibleIndex="12" Caption="PIC" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataComboBoxColumn FieldName="TempoPM" HeaderStyle-HorizontalAlign="Center" Caption="Status" Visible="false" Width="100px">
                        <EditFormSettings Caption="Tempo PM /Bulan" VisibleIndex="13" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="Selected" Value="" />
                                <dx:ListEditItem Text="1" Value="1" />
                                <dx:ListEditItem Text="2" Value="2" />
                                <dx:ListEditItem Text="3" Value="3" />
                                <dx:ListEditItem Text="4" Value="4" />
                                <dx:ListEditItem Text="5" Value="5" />
                                <dx:ListEditItem Text="6" Value="6" />
                                <dx:ListEditItem Text="7" Value="7" />
                                <dx:ListEditItem Text="8" Value="8" />
                                <dx:ListEditItem Text="9" Value="9" />
                                <dx:ListEditItem Text="10" Value="10" />
                                <dx:ListEditItem Text="11" Value="11" />
                                <dx:ListEditItem Text="12" Value="12" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataTextColumn Caption="Email" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="CustEmail" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings VisibleIndex="14" Caption="Email" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorText="Invalid e-mail" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Phone" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="CustPhone" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings VisibleIndex="15" Caption="Phone" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true">
                                <RegularExpression ValidationExpression="^[0-9]+$" ErrorText="Number Only" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Customer Office" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="CustOffice" Settings-AutoFilterCondition="Contains" Visible="false">
                        <EditFormSettings VisibleIndex="16" Caption="Cust Office" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Alamat Customer" Width="100px" FieldName="CustAdd" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" Visible="false">
                        <EditFormSettings VisibleIndex="17" Caption="Alamat Office" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesTextEdit>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Visible="false" FieldName="CustProvinsi" HeaderStyle-HorizontalAlign="Center" VisibleIndex="3" Width="100%">
                        <EditFormSettings Caption="Provinsi" VisibleIndex="18" Visible="True" />
                        <PropertiesComboBox DataSourceID="dsprovinsi" TextField="Provinsi"
                            ValueField="IdProvinsi" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                            <ClientSideEvents SelectedIndexChanged="onCityChanged"></ClientSideEvents>
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="CustKota" HeaderStyle-HorizontalAlign="Center" Caption="Kota" Visible="false" Width="100px">
                        <EditFormSettings Caption="Kota" VisibleIndex="19" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox DataSourceID="dskota" TextField="Kota" ValueField="Kota"
                            ValueType="System.String" IncrementalFilteringMode="Contains">
                            <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdStatusProject" HeaderStyle-HorizontalAlign="Center" Caption="Status" Visible="false" Width="100px">
                        <EditFormSettings Caption="Status" VisibleIndex="20" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                            <Items>
                                <dx:ListEditItem Text="Valid" Value="Valid" />
                                <dx:ListEditItem Text="Not Valid" Value="Not Valid" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="IdPerusahaan" HeaderStyle-HorizontalAlign="Center" Caption="Kode Perusahaan" Visible="false" Width="100px">
                        <EditFormSettings Caption="Perusahaan" VisibleIndex="21" Visible="True" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains" 
                            DataSourceID="dsPerusahaan" ValueField="Id" TextFormatString="{0} - {1} - {2}">
                            <Columns>
                                <dx:ListBoxColumn Caption="ID" FieldName="Id"></dx:ListBoxColumn>
								<dx:ListBoxColumn Caption="Inisial Perusahaan" FieldName="inisialPerusahaan"></dx:ListBoxColumn>
                                <dx:ListBoxColumn Caption="Nama Perusahaan" FieldName="NamaPerusahaan"></dx:ListBoxColumn>
                            </Columns>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="gv_detilproject" runat="server" EnableTheming="True" Theme="MetropolisBlue" Width="100%" 
                            OnBeforePerformDataSelect="gv_detilproject_DataSelect" 
                            OnRowDeleting="gv_detilproject_RowDeleting" OnRowInserting="gv_detilproject_RowInserting" OnRowUpdating="gv_detilproject_RowUpdating" 
                            AutoGenerateColumns="False" DataSourceID="dsdetilproject" KeyFieldName="ID">
                            <Settings ShowFooter="false" ShowGroupPanel="True" HorizontalScrollBarMode="Auto" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsPager>
                                <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True"/>
                            <SettingsSearchPanel Visible="True" />
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                            <SettingsDetail ShowDetailRow="true" />
                            <ClientSideEvents RowDblClick="OnRowDblClick"/>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="VID" Width="200px" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" FieldName="VID" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="SID" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="SID" Settings-AutoFilterCondition="Contains" VisibleIndex="1">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="IP LAN" Width="100px" HeaderStyle-HorizontalAlign="Center" FieldName="IPLAN" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nama Remote" Width="250px" HeaderStyle-HorizontalAlign="Center" FieldName="NAMAREMOTE" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Alamat Install" Width="250px" FieldName="AlamatInstall" Settings-AutoFilterCondition="Contains" HeaderStyle-HorizontalAlign="Center" VisibleIndex="4">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="PROVINSI" HeaderStyle-HorizontalAlign="Center" Caption="Provinsi" VisibleIndex="5" Width="100px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <PropertiesComboBox DataSourceID="dsprovinsiload" TextField="Provinsi"
                                        ValueField="IdProvinsi" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="KOTA" HeaderStyle-HorizontalAlign="Center" Caption="Kota" VisibleIndex="6" Width="100px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                    <PropertiesComboBox DataSourceID="dskotaload" TextField="Kota" ValueField="Kota"
                                        ValueType="System.String" IncrementalFilteringMode="Contains">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="KANWIL" HeaderStyle-HorizontalAlign="Center" Caption="Kanwil" VisibleIndex="10" Width="100px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="KANCAINDUK" HeaderStyle-HorizontalAlign="Center" Caption="Kanca Induk" VisibleIndex="11" Width="100px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Latitude" HeaderStyle-HorizontalAlign="Center" Caption="Latitude" VisibleIndex="13" Width="100px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Longitude" HeaderStyle-HorizontalAlign="Center" Caption="Longitude" VisibleIndex="14" Width="100px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IdSatelite" HeaderStyle-HorizontalAlign="Center" Caption="Satelite" VisibleIndex="15" Width="100px">
                                    <Settings AutoFilterCondition="Contains"></Settings>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Templates>
                                <DetailRow>
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <b>Barang Terpasang</b>
                                        </h4>
                                    </div>
                                    <dx:ASPxGridView ID="grid_barang_on" runat="server" KeyFieldName="ID" DataSourceID="dsbarang_on" EnableTheming="true" Width="100%" OnBeforePerformDataSelect="grid_barang_on_BeforePerformDataSelect" Theme="MetropolisBlue">
                                        <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" />
                                        <SettingsBehavior ConfirmDelete="True" />
                                        <SettingsPager>
                                            <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                        <SettingsSearchPanel Visible="True" />
                                        <SettingsEditing Mode="EditFormAndDisplayRow" />
                                        <Columns>
                                            <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowEditButton="True" VisibleIndex="10">
                                                <CellStyle BackColor="#d6f1ff">
                                                </CellStyle>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn FieldName="VID" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="200px" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="NamaBarang" HeaderStyle-HorizontalAlign="Center" Caption="Nama Barang" Width="200px" VisibleIndex="3">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Type" HeaderStyle-HorizontalAlign="Center" Caption="Type" Width="200px" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="SN" HeaderStyle-HorizontalAlign="Center" Caption="Serial Number" Width="200px" VisibleIndex="5">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="IPlan" HeaderStyle-HorizontalAlign="Center" Caption="IP Lan" Width="200px" VisibleIndex="6">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Status" HeaderStyle-HorizontalAlign="Center" Caption="Status" Width="200px" VisibleIndex="7">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </DetailRow>
                            </Templates>
                            <SettingsEditing Mode="EditFormAndDisplayRow" />
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>            
            <br />
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#ImportDataLokasi">
                            <b>Import Data Lokasi</b>
                        </a>
                    </h4>
                </div>                
                <div id="ImportDataLokasi" class="panel-collapse collapse" style="height: 0px;">
                    <div class="container">
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <label for="exampleInputEmail1">Pilih ID project terlebih dahulu</label><br />
                                <dx:ASPxComboBox ID="cbIdProject" CssClass="form-control input-sm bounceIn animation-delay2" DataSourceID="dsidproject" 
                                    ValueField="IdProject" runat="server" ValueType="System.String" Width="100%"
                                    IncrementalFilteringMode="Contains" TextFormatString="{0} - {1}">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="IdProject"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="ProjectName"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>
                            </div>
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-4"></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <div class="upload-file">
                                        <%--<input id="upload-demo" class="upload-demo" type="file">--%>
                                        <label data-title="Select file" for="upload-demo">
                                            <asp:FileUpload ID="fl_upload" runat="server" Visible="true" CssClass="upload-demo" onchange="get_filename(this);" />
                                            <span id="fileNameLabel" data-title="No file selected..."></span>
                                        </label>                                        
                                    </div>                                    
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="pull-left text-right">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <button id="btn_upload" style="background-color: #F65058;" runat="server" visible="true" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-save"></i>&nbsp;Import
                                                </button>
                                                <button id="btn_cancel" style="background-color: #F65058;" runat="server" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-arrow-circle-o-up"></i>&nbsp;Cancel
                                                </button>
                                                <button id="btn_rollback" style="background-color: #F65058;" runat="server" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-arrow-circle-o-up"></i>&nbsp;Rollback Data
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>                            
                        </div>

                    </div>
                </div>
            </div>
           
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#Importpenyelesaiantask">
                            <b>Import Data Penyelesaian Task</b>
                        </a>
                    </h4>
                </div>
                <div id="Importpenyelesaiantask" class="panel-collapse collapse" style="height: 0px;">
                    <div class="container">
                        <br />

                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group">
                                    Select File
                                    <div class="upload-file">
                                        <%--<input id="upload-demo" class="upload-demo" type="file">--%>
                                        <label data-title="Select file" for="upload-demo">
                                            <asp:FileUpload ID="upload_penyelesaian" runat="server" Visible="true" CssClass="upload-demo" onchange="get_filename(this);" />
                                            <span data-title="No file selected..."></span>
                                        </label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblPenyelesaianTask" runat="server" ForeColor="Green" Font-Bold="true"/>
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblPenyelesaianTask" Text="444" runat="server" ForeColor="Green" Font-Bold="true"/>
                                </div>
                            </div>--%>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="cb_JenisTask" />
                                        <asp:AsyncPostBackTrigger ControlID="cbl_JenisTask" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12 border">                                
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <dx:ASPxCheckBox ID="cb_JenisTask" runat="server" ClientInstanceName="chkSelAll" 
                                                            Text="Select All" Font-Bold="true" AutoPostBack="true">                                            
                                                        </dx:ASPxCheckBox>
                                                    </div>
                                                </div>                                
                                                <dx:aspxcheckboxlist ID="cbl_JenisTask" runat="server" RepeatColumns="2" RepeatLayout="Table" AutoPostBack="true"
                                                    ClientInstanceName="cbl_JenisTask" Border-BorderStyle="None" Width="100%" Paddings-Padding="0">
                                                    <Items>                                        
                                                        <dx:ListEditItem Text="General Task" Value="PenyelesainTask" />
                                                        <dx:ListEditItem Text="Instalasi Task" Value="TaskInstalasi" />
                                                        <dx:ListEditItem Text="Survey Task" Value="TaskSurvey" />
                                                    </Items>
                                                </dx:aspxcheckboxlist>                                    
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                <div class="seperator"></div>
                            </div>          
                            <div class="col-md-3">
                                <div class="pull-left text-right">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <button id="btnuploadpenyelesaiantask" style="background-color: #F65058;" runat="server" visible="true" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-save"></i>&nbsp;Import
                                                </button>
                                                <button id="btncancelpenyelesaian" style="background-color: #F65058;" runat="server" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-arrow-circle-o-up"></i>&nbsp;Cancel
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                        </div>

                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-default" hidden="hidden">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#ImportBarangOn">
                            <b>Import Data Barang Terpasang</b>
                        </a>
                    </h4>
                </div>
                <div id="ImportBarangOn" class="panel-collapse collapse" style="height: 0px;">
                    <div class="container">
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <div class="upload-file">
                                        <%--<input id="upload-demo" class="upload-demo" type="file">--%>
                                        <label data-title="Select file" for="upload-demo">
                                            <asp:FileUpload ID="uploadbarangon" runat="server" Visible="true" CssClass="upload-demo" onchange="get_filename(this);" />
                                            <span data-title="No file selected..."></span>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="pull-left text-right">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <button id="btnimportbarangon" style="background-color: #F65058;" runat="server" visible="true" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-save"></i>&nbsp;Import
                                                </button>
                                                <button id="btncancelbarangon" style="background-color: #F65058;" runat="server" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-arrow-circle-o-up"></i>&nbsp;Cancel
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-default" hidden="hidden">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#ImportBarangRep">
                            <b>Import Data Barang Rusak</b>
                        </a>
                    </h4>
                </div>
                <div id="ImportBarangRep" class="panel-collapse collapse" style="height: 0px;">
                    <div class="container">
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <div class="upload-file">
                                        <%--<input id="upload-demo" class="upload-demo" type="file">--%>
                                        <label data-title="Select file" for="upload-demo">
                                            <asp:FileUpload ID="uploadbarangrusak" runat="server" Visible="true" CssClass="upload-demo" onchange="get_filename(this);" />
                                            <span data-title="No file selected..."></span>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="pull-left text-right">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <button id="btnuploadbarangrusak" style="background-color: #F65058;" runat="server" visible="true" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-save"></i>&nbsp;Import
                                                </button>
                                                <button id="Button6" style="background-color: #F65058;" runat="server" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <i class="fa fa-arrow-circle-o-up"></i>&nbsp;Cancel
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <asp:SqlDataSource ID="dsidproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT ProjectName,IdProject FROM trProject order by IdProject"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsstatus" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM msStatus"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovinsi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota] where idProvinsi = @idProvinsi">
                <SelectParameters>
                    <asp:Parameter Name="IdProvinsi" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsProvider" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msProvider"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsPelanggan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msCustomer"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsAM" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msEmployee where EmployeeType = 'Account Manager'"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from trProject"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsdetilproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsprovinsiload" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dskotaload" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota] "></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsbarang_on" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
			<asp:SqlDataSource ID="dsPerusahaan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" 
                SelectCommand="select Id,inisialPerusahaan,NamaPerusahaan from msperusahaan order by NamaPerusahaan"></asp:SqlDataSource>
        </div>
    </div>

    <script src="js/sweetalert2@11.js"></script>
</asp:Content>

