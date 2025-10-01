<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="createtask.aspx.vb" Inherits="createtask" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script type="text/javascript">
        function onCityChanged(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            grid_helpdesk.GetEditor("IdCity").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
			console.log(comboValue)
        }

        function onkotachanged(cmbParent) {
            var comboValue = cmbParent.GetSelectedItem().value;
            grid_koordinator.GetEditor("IdCity").PerformCallback(comboValue.toString());
            //alert(comboValue.toString());
        }
        var combo = null;
        var isUpdating = true;
    </script>
    <script>
        function functionlihome() {
            //alert("testhome")
            var home = document.getElementById("lihome1");
            var isi = document.getElementById("home1");
            var profile = document.getElementById("liprofile1");
            var isiprofile = document.getElementById("profile1");
            profile.classList.remove("active");
            isiprofile.classList.remove("tab-pane fade in active");
            home.classList.add("active");
            isi.classList.add("tab-pane fade in active");
        }

        function functionliprofile() {
            // alert("testprofile")
            var home = document.getElementById("lihome1");
            var isi = document.getElementById("home1");
            var profile = document.getElementById("liprofile1");
            var isiprofile = document.getElementById("profile1");
            home.classList.remove("active");
            isi.classList.remove("tab-pane fade in active");
            profile.classList.add("active");
            isiprofile.classList.add("tab-pane fade in active");
        }

        function testdoang(s, e) {
            var comboValue = s.GetValue();
            //document.getElementById("MainContent_callbackPanelX_hdvaluefilter").value = comboValue
            callbackPanelX.PerformCallback(s.GetValue());
            //alert(comboValue);
        }
        function tesjarak(s, e) {
            var suktest = s.GetValue();
            callbackPanel1.PerformCallback(s.GetValue());
        }
    </script>

    <dx:ASPxPopupControl ID="popup" ClientInstanceName="popup" runat="server" AllowDragging="true"
        HeaderText="Lokasi Remote Di Sekitarnya" OnWindowCallback="popup_WindowCallback" Width="650">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <div class="panel-tab clearfix">
                    <ul class="tab-bar">
                        <li id="lihome1" runat="server" class="active"><a href="#home1" onclick="functionlihome()" data-toggle="tab"><i class="fa fa-home"></i>Pilih Lokasi Berdasarkan Provinsi</a></li>
                        <li id="liprofile1" runat="server"><a href="#profile1" onclick="functionliprofile()" data-toggle="tab"><i class="fa fa-pencil"></i>Pilih Lokasi Terdekat</a></li>
                    </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="home1">
                            <table>
                                <tr>
                                    <td>
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <b>Lokasi Remote</b>
                                            </h4>
                                            <div class="pull-right">
                                                <dx:ASPxComboBox ID="cbfilter" ClientInstanceName="cbfilter" OnSelectedIndexChanged="cbfilter_SelectedIndexChanged" runat="server" ValueType="System.String">
                                                    <ClientSideEvents SelectedIndexChanged="testdoang" />
                                                    <Items>
                                                        <dx:ListEditItem Text="All Data" Value="All Data" />
                                                        <dx:ListEditItem Text="PM 1" Value="Wajib PM" />
                                                        <dx:ListEditItem Text="PM 2" Value="PM" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </div>
                                            <asp:Literal ID="litText" runat="server" Text=""></asp:Literal>
                                        </div>
                                        <br />
                                        <%--<div class="panel-body">--%>
                                            <dx:ASPxCallbackPanel ID="callbackPanelX" ClientInstanceName="callbackPanelX" runat="server" Width="850px">
                                            <PanelCollection>
                                                <dx:PanelContent ID="PanelContent2" runat="server">
                                                    <asp:HiddenField runat="server" ID="hdvaluefilter" />
                                                    <dx:ASPxGridView ID="popup_grid_subtask" ClientInstanceName="popup_grid_subtask" runat="server" DataSourceID="dssubtask" OnBeforePerformDataSelect="grid_subtask_BeforePerformDataSelect" OnRowDeleting="grid_subtask_RowDeleting" OnRowInserting="grid_subtask_RowInserting" OnRowUpdating="grid_subtask_RowUpdating" KeyFieldName="ID" Width="800px" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                                        <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
                                                        <SettingsPager>
                                                            <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                        </SettingsPager>
                                                        <SettingsSearchPanel Visible="True" />
                                                        <SettingsEditing Mode="EditFormAndDisplayRow" />
                                                        <Columns>
                                                            <dx:GridViewDataComboBoxColumn FieldName="ProjectName" HeaderStyle-HorizontalAlign="Center" Caption="Project" Width="200px">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn FieldName="KOTA" HeaderStyle-HorizontalAlign="Center" Caption="Kota" Width="150px">
                                                            </dx:GridViewDataComboBoxColumn>
															<dx:GridViewDataComboBoxColumn FieldName="SID" HeaderStyle-HorizontalAlign="Center" Caption="SID" Width="150px">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn FieldName="VID" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="150px">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn FieldName="IPLAN" HeaderStyle-HorizontalAlign="Center" Caption="IP LAN" Width="100px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="NAMAREMOTE" HeaderStyle-HorizontalAlign="Center" Caption="Nama Remote" Width="300px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="AlamatInstall" HeaderStyle-HorizontalAlign="Center" Caption="Alamat" Width="200px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="PM" HeaderStyle-HorizontalAlign="Center" Caption="PM" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="CM" HeaderStyle-HorizontalAlign="Center" Caption="CM" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="MIGRASI" HeaderStyle-HorizontalAlign="Center" Caption="MIG" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="RELOKASI" HeaderStyle-HorizontalAlign="Center" Caption="REL" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="BBD" HeaderStyle-HorizontalAlign="Center" Caption="BBD" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="OBSTACLE" HeaderStyle-HorizontalAlign="Center" Caption="OBS" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewCommandColumn VisibleIndex="0" Width="100px" Caption="Action" HeaderStyle-HorizontalAlign="Center">
                                                                <CustomButtons>
                                                                    <dx:GridViewCommandColumnCustomButton ID="btnPickRemoteSite" Text="Pick" />
                                                                </CustomButtons>
                                                            </dx:GridViewCommandColumn>
                                                        </Columns>
                                                        <ClientSideEvents CustomButtonClick="function(s, e) {
                                        if(e.buttonID == 'btnPickRemoteSite'){
                                            var rowVisibleIndex = e.visibleIndex;
                                            var rowKeyValue = s.GetRowKey(rowVisibleIndex);
                                                    $.ajax({
                                                        url: 'proses.aspx?ket=insert&id=' + rowKeyValue,
                                                        type: 'GET',
                                                        async: false,
                                                        cache: false,
                                                        success: function (result) {
                                                            popup_grid_subtask.Refresh();
                                                            grid_VID.Refresh();
                                                        },
                                                        error: function (xhr, textStatus, errorThrown) {
                                                            alert('Request Status: ' + xhr.status + '; Status Text: ' + textStatus + '; Error: ' + errorThrown);
                                                        }
                                                    });
                                                        
                                                }
                                            }" />
                                                    </dx:ASPxGridView>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxCallbackPanel>
                                        <%--</div>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="tab-pane fade" id="profile1">
                            <table>
                                <tr>
                                    <td>
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <b>Lokasi Remote</b>
                                            </h4>
                                            <div class="pull-left">
                                                <br />
                                                <b>Tentukan Jarak </b>
                                                <%-- <dx:ASPxComboBox ID="cbjarak" AutoPostBack="false" OnSelectedIndexChanged="cbjarak_SelectedIndexChanged" runat="server" ValueType="System.String">
                                                    <ClientSideEvents SelectedIndexChanged="tesjarak" />
                                                    <Items>
                                                        <dx:ListEditItem Text="1Km" Value="1" />
                                                        <dx:ListEditItem Text="5Km" Value="5" />
                                                        <dx:ListEditItem Text="10Km" Value="10" />
                                                        <dx:ListEditItem Text="15Km" Value="15" />
                                                        <dx:ListEditItem Text="20Km" Value="20" />
                                                        <dx:ListEditItem Text="25Km" Value="25" />
                                                    </Items>
                                                </dx:ASPxComboBox>--%>
                                                <dx:ASPxComboBox ID="cbjarak" OnSelectedIndexChanged="cbjarak_SelectedIndexChanged" ValidationSettings-RequiredField-IsRequired="true" DataSourceID="dscbjarak" TextField="Description" ValueField="Jarak" runat="server" ValueType="System.String">
                                                    <ClientSideEvents SelectedIndexChanged="tesjarak" />
                                                </dx:ASPxComboBox>
                                                <br />
                                            </div>
                                        </div>
                                        <asp:SqlDataSource ID="dscbjarak" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="Select * from msJarak"></asp:SqlDataSource>
                                        <br />
                                        <dx:ASPxCallbackPanel ID="callbackPanel1" ClientInstanceName="callbackPanel1" runat="server" Width="800px">
                                            <PanelCollection>
                                                <dx:PanelContent ID="PanelContent1" runat="server">
                                                    <asp:HiddenField runat="server" ID="HiddenField1" />
                                                    <dx:ASPxGridView ID="popup_grid_jarak" ClientInstanceName="popup_grid_jarak" runat="server" DataSourceID="dsjarak" OnBeforePerformDataSelect="popup_grid_jarak_BeforePerformDataSelect" KeyFieldName="ID" Width="800px" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                                        <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
                                                        <SettingsPager>
                                                            <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                        </SettingsPager>
                                                        <SettingsSearchPanel Visible="True" />
                                                        <SettingsEditing Mode="EditFormAndDisplayRow" />
                                                        <Columns>
                                                            <dx:GridViewDataComboBoxColumn FieldName="ProjectName" HeaderStyle-HorizontalAlign="Center" Caption="Project" Width="200px">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn FieldName="KOTA" HeaderStyle-HorizontalAlign="Center" Caption="Kota" Width="150px">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataComboBoxColumn FieldName="VID" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="150px">
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewDataTextColumn FieldName="IPLAN" HeaderStyle-HorizontalAlign="Center" Caption="IP LAN" Width="100px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="NAMAREMOTE" HeaderStyle-HorizontalAlign="Center" Caption="Nama Remote" Width="300px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="AlamatInstall" HeaderStyle-HorizontalAlign="Center" Caption="Alamat" Width="200px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="PM" HeaderStyle-HorizontalAlign="Center" Caption="PM" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="CM" HeaderStyle-HorizontalAlign="Center" Caption="CM" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="MIGRASI" HeaderStyle-HorizontalAlign="Center" Caption="MIG" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="RELOKASI" HeaderStyle-HorizontalAlign="Center" Caption="REL" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="BBD" HeaderStyle-HorizontalAlign="Center" Caption="BBD" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="OBSTACLE" HeaderStyle-HorizontalAlign="Center" Caption="OBS" Width="50px">
                                                                <EditFormSettings Visible="false" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewCommandColumn VisibleIndex="0" Width="100px" Caption="Action" HeaderStyle-HorizontalAlign="Center">
                                                                <CustomButtons>
                                                                    <dx:GridViewCommandColumnCustomButton ID="GridViewCommandColumnCustomButton1" Text="Pick" />
                                                                </CustomButtons>
                                                            </dx:GridViewCommandColumn>
                                                        </Columns>
                                                        <ClientSideEvents CustomButtonClick="function(s, e) {
                                        if(e.buttonID == 'btnPickRemoteSite'){
                                            var rowVisibleIndex = e.visibleIndex;
                                            var rowKeyValue = s.GetRowKey(rowVisibleIndex);
                                                    $.ajax({
                                                        url: 'proses.aspx?ket=insert&id=' + rowKeyValue,
                                                        type: 'GET',
                                                        async: false,
                                                        cache: false,
                                                        success: function (result) {
                                                            popup_grid_jarak.Refresh();
                                                            grid_VID.Refresh();
                                                        },
                                                        error: function (xhr, textStatus, errorThrown) {
                                                            alert('Request Status: ' + xhr.status + '; Status Text: ' + textStatus + '; Error: ' + errorThrown);
                                                        }
                                                    });
                                                        
                                                }
                                            }" />
                                                    </dx:ASPxGridView>
                                                </dx:PanelContent>
                                            </PanelCollection>
                                        </dx:ASPxCallbackPanel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                </div>

            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <asp:SqlDataSource ID="dsfilter" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="Select 'All No Order' as Service from msJenis_Task UNION select Service from msJenis_Task"></asp:SqlDataSource>
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Create Task</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <div class="panel panel-default" id="panelhelpdesk" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <%-- <a id="headerhelpdesk" runat="server" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#helpdesk">--%>
                        <b>HelpDesk </b>
                        <%--  </a>--%>
                    </h4>
                </div>
                <%--   <div id="helpdesk" class="panel-collapse collapse" style="height: 0px;">--%>
                <div class="panel-body">
                    <dx:ASPxGridView ID="grid_helpdesk" ClientInstanceName="grid_helpdesk" runat="server" DataSourceID="dstask" KeyFieldName="ID" Width="100%" AutoGenerateColumns="false" 
                        Theme="MetropolisBlue" OnCellEditorInitialize="grid_helpdesk_CellEditorInitialize">
                        <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                        <SettingsPager>
                            <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                        <SettingsSearchPanel Visible="True" />
                        <SettingsEditing Mode="PopupEditForm" />
                        <SettingsDetail ShowDetailRow="true" />
                        <Columns>
                            <dx:GridViewCommandColumn FixedStyle="Left" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="false" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="10">
                                <CellStyle BackColor="#d6f1ff">
                                </CellStyle>
                            </dx:GridViewCommandColumn>
							<dx:GridViewDataTextColumn FieldName="NoTask" Visible="false">                                
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="No. Pengaduan" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" PropertiesTextEdit-DisplayFormatInEditMode="true" Width="100%" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="NomorPengaduan" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                                <EditFormSettings VisibleIndex="0" Visible="True" Caption="No Pengaduan" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn Caption="No. Pengaduan/TicketNo" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" PropertiesTextEdit-DisplayFormatInEditMode="true" Width="100%" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="TicketNumber" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                                <EditFormSettings VisibleIndex="0" Visible="True" Caption="No Pengaduan/TicketNo" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataTextColumn>--%>
                            <%--<dx:GridViewDataTextColumn Caption="TicketNumber" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" PropertiesTextEdit-DisplayFormatInEditMode="true" Width="100%" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="TicketNumber" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                                <EditFormSettings VisibleIndex="0" Visible="True" Caption="No TicketNumber" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataDateColumn FieldName="TanggalTask" HeaderStyle-HorizontalAlign="Center" Caption="Tgl Pengaduan" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss" VisibleIndex="1" Width="100%">
                                <EditFormSettings VisibleIndex="4" Visible="True" Caption="Tgl Pengaduan" />
                                <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd HH:mm:ss" DisplayFormatInEditMode="True"
								ValidationSettings-RequiredField-IsRequired="true"></PropertiesDateEdit>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="LaporanPengaduan" HeaderStyle-HorizontalAlign="Center" Caption="Pengaduan" VisibleIndex="2" Width="200px">
                                <EditFormSettings VisibleIndex="5" Visible="True" Caption="Pengaduan" />
                                <PropertiesComboBox DataSourceID="dsjeniskerja" TextField="Service" ValueField="KodeService"
                                    ValueType="System.String" IncrementalFilteringMode="Contains">
                                    <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdStatusTask" HeaderStyle-HorizontalAlign="Center" Caption="Status Pengaduan" VisibleIndex="3" Width="150px">
                                <EditFormSettings VisibleIndex="6" Visible="True" Caption="Status Pengaduan" />
                                <PropertiesComboBox DataSourceID="dsstatus" TextField="Status" ValueField="ID"
                                    ValueType="System.String" IncrementalFilteringMode="Contains">
                                    <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataDateColumn FieldName="TglStatusTask" HeaderStyle-HorizontalAlign="Center" Caption="Tgl Status Pengaduan" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss" VisibleIndex="4" Width="100%">
                                <EditFormSettings VisibleIndex="2" Visible="True" Caption="Tgl Status Pengaduan" />
                                <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd HH:mm:ss" DisplayFormatInEditMode="True"
								ValidationSettings-RequiredField-IsRequired="true"></PropertiesDateEdit>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataComboBoxColumn Visible="False" FieldName="IdProject" Caption="Project" Width="100px">
                                <EditFormSettings VisibleIndex="3" Visible="True" Caption="Nama Project" />
                                <PropertiesComboBox DataSourceID="dsproject" TextField="ProjectName" ValueField="IdProject"
                                    ValueType="System.String" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="AsalPengaduan" Caption="Media Pengaduan" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="8" Caption="Media Pengaduan" Visible="True" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                                    <Items>
                                        <dx:ListEditItem Text="Phone" Value="Phone" />
                                        <dx:ListEditItem Text="Email" Value="Email" />
                                        <dx:ListEditItem Text="SMS" Value="SMS" />
                                        <dx:ListEditItem Text="Social Media" Value="Sosmed" />
                                        <dx:ListEditItem Text="dll" Value="Other" />
                                    </Items>
                                    <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="NamaPelapor" Caption="Nama Pelapor" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="1" Caption="Nama Pelapor" Visible="True" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true"></PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="TelpPelapor" Caption="Telp Pelapor" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="7" Visible="True" Caption="Telp Pelapor" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true">
                                    <ValidationSettings RequiredField-IsRequired="true">
                                        <RegularExpression ValidationExpression="^[0-9]+$" ErrorText="Number Only" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdProvinsi" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="9" Visible="True" Caption="Provinsi" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <PropertiesComboBox DataSourceID="dsprovinsi" TextField="Provinsi"
                                    ValueField="IdProvinsi" EnableSynchronization="False" IncrementalFilteringMode="StartsWith" ValidationSettings-RequiredField-IsRequired="true">
                                    <ClientSideEvents SelectedIndexChanged="onCityChanged"></ClientSideEvents>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdCity" Visible="false" Width="100px">
                                <EditFormSettings VisibleIndex="11" Visible="True" Caption="Kota" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <PropertiesComboBox DataSourceID="dskota" TextField="Kota" ValueField="idKota"
                                    IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataMemoColumn FieldName="AlamatPengaduan" Caption="Alamat Pengaduan" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="10" Visible="True" Caption="Alamat " />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true"></PropertiesMemoEdit>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataMemoColumn FieldName="DeskripsiPermasalahan" Visible="false" Width="100%" HeaderStyle-HorizontalAlign="Center" Caption="Permasalahan" VisibleIndex="9">
                                <EditFormSettings VisibleIndex="12" Visible="True" Caption="Permasalahan" />
                                <PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true"></PropertiesMemoEdit>
                                <PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true" Width="300px" Height="90px"></PropertiesMemoEdit>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataMemoColumn FieldName="CatatanKoordinator" Visible="false" Width="100%" HeaderStyle-HorizontalAlign="Center" Caption="Catatan Koordinator" VisibleIndex="9">
                                <EditFormSettings VisibleIndex="13" Visible="True" Caption="Catatan Koordinator" />
                                <PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true"></PropertiesMemoEdit>
                                <PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true" Width="300px" Height="90px"></PropertiesMemoEdit>
                            </dx:GridViewDataMemoColumn>
                        </Columns>
                        <Templates>
                            <DetailRow>
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <b>Lokasi Remote</b>
                                        <div class="pull-right">
                                            <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" ClientSideEvents-Click="OnCustomButtonClick" Text="Pilih Lokasi Remote" Font-Bold="True" Font-Underline="True">
                                            </dx:ASPxHyperLink>
                                            <%--<dx:ASPxButton ID="ASPxButton1" runat="server"  AutoPostBack="false" CssClass="btn btn-md btn-info" Text="Pilih Lokasi Remote"></dx:ASPxButton>--%>
                                        </div>
                                    </h4>

                                </div>

                                <dx:ASPxGridView ID="grid_VID" ClientInstanceName="grid_VID" runat="server" DataSourceID="dsdetailtask" KeyFieldName="NoListTask" Width="100%" OnBeforePerformDataSelect="grid_VID_BeforePerformDataSelect" OnRowDeleting="grid_VID_RowDeleting" OnRowInserting="grid_VID_RowInserting" OnRowUpdating="grid_VID_RowUpdating" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="PopupEditForm" />
                                    <SettingsDetail ShowDetailRow="true" />
                                    <Columns>
                                        <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" Caption="ACTION" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="10">
                                            <CellStyle BackColor="#d6f1ff">
                                            </CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="NoTask" Visible="false" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" Caption="No. Task" Width="70px">
                                            <EditFormSettings VisibleIndex="2" Visible="True" />
                                        </dx:GridViewDataTextColumn>
										<dx:GridViewDataTextColumn FieldName="SID" HeaderStyle-HorizontalAlign="Center" Caption="SID">                                            
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="VID" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="200px" ReadOnly="true" PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0">
                                            <EditFormSettings VisibleIndex="1" />
                                            <PropertiesComboBox DataSourceID="dsVIDload" TextField="VID" ValueField="VID"
                                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="IPLAN" HeaderStyle-HorizontalAlign="Center" Caption="IP LAN" Width="100px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="NAMAREMOTE" HeaderStyle-HorizontalAlign="Center" Caption="Nama Remote" Width="300px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ALAMAT" HeaderStyle-HorizontalAlign="Center" Caption="Alamat" Width="300px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="IdStatusPerbaikan" HeaderStyle-HorizontalAlign="Center" Caption="Status" Width="100px">
                                            <PropertiesComboBox DataSourceID="dsStatusperbaikan" TextField="Status" ValueField="ID"
                                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" Caption="Order" Width="100px">
                                            <EditFormSettings Visible="True" VisibleIndex="10" />
                                            <PropertiesComboBox DataSourceID="dsjeniskerja" TextField="Service" ValueField="Service" ValueType="System.String" IncrementalFilteringMode="Contains">
                                            </PropertiesComboBox>
                                            <Settings AutoFilterCondition="Contains"></Settings>
                                        </dx:GridViewDataComboBoxColumn>
                                        <%--<dx:GridViewCommandColumn Caption="Remote Lainnya" VisibleIndex="7">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnDetails" Text="Select" />
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>--%>
                                    </Columns>
                                    <Templates>
                                        <DetailRow>
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <b>Barang Terpasang</b>
                                                </h4>
                                            </div>
                                            <dx:ASPxGridView ID="grid_barang_on" runat="server" KeyFieldName="ID" DataSourceID="dsbarang_on" EnableTheming="true" Width="80%" OnBeforePerformDataSelect="grid_barang_on_BeforePerformDataSelect" Theme="MetropolisBlue">
                                                <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" />
                                                <SettingsBehavior ConfirmDelete="True" />
                                                <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                                <SettingsPager>
                                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                </SettingsPager>
                                                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                                <SettingsSearchPanel Visible="True" />
                                                <SettingsEditing Mode="PopupEditForm" />
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
                                            <br />
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <b>History Order/Pekerjaan</b>
                                                </h4>
                                            </div>
                                            <dx:ASPxGridView ID="gridhistory" runat="server" KeyFieldName="NoListTask" DataSourceID="dsgridhistory" EnableTheming="true" Width="80%" OnBeforePerformDataSelect="gridhistory_BeforePerformDataSelect" Theme="MetropolisBlue">
                                                <Settings ShowFooter="false" />
                                                <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                                <SettingsPager>
                                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                </SettingsPager>
                                                <SettingsSearchPanel Visible="True" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="NoTask" HeaderStyle-HorizontalAlign="Center" Caption="No. Task" Width="200px" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NamaTeknisi" HeaderStyle-HorizontalAlign="Center" Caption="Teknisi" Width="200px" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TglSelesaiKerjaan" HeaderStyle-HorizontalAlign="Center" Caption="Tanggal Selesai pengerjaan" Width="200px" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" Caption="Order" Width="200px" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                            <br />
                                        </DetailRow>
                                    </Templates>
                                    <%-- <ClientSideEvents CustomButtonClick="OnCustomButtonClick" />--%>
                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="dsprovinsi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [msProvinsi]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dskota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM [mskota] where IdProvinsi = @IdProvinsi">
                        <SelectParameters>
                            <asp:Parameter Name="IdProvinsi" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM trProject where convert(date,enddate)>=convert(date,getdate()) order by ProjectName"></asp:SqlDataSource>
                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>--%>
                    <asp:SqlDataSource ID="dstask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsstatus" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM msStatus"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsjeniskerja" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT * FROM msJenis_Task order by KodeService asc"></asp:SqlDataSource>
                </div>
                <%-- </div>--%>
            </div>
            <!-- /panel -->

            <div class="panel panel-default" id="panelkoordinator" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <b>Koordinator </b>
                    </h4>
                </div>
                <div class="panel-body">
                    <dx:ASPxGridView ID="grid_koordinator" ClientInstanceName="grid_koordinator" runat="server" DataSourceID="dstaskcoor" KeyFieldName="ID" Width="100%" 
                        AutoGenerateColumns="false" Theme="MetropolisBlue" OnCellEditorInitialize="grid_koordinator_CellEditorInitialize" 
                        OnBeforePerformDataSelect="grid_koordinator_BeforePerformDataSelect">
                        <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                        <SettingsPager>
                            <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                        <SettingsSearchPanel Visible="True" />
                        <SettingsEditing Mode="PopupEditForm" />
                        <SettingsDetail ShowDetailRow="true" />
                        <Styles>
                            <Header HorizontalAlign="Center" Wrap="True"></Header>
                        </Styles>
                        <Columns>
                            <dx:GridViewCommandColumn FixedStyle="Left" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="false" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="30">
                                <CellStyle BackColor="#d6f1ff">
                                </CellStyle>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="No. Task" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" 
                                ReadOnly="true" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" 
                                FieldName="NoTask" Settings-AutoFilterCondition="Contains" Width="80px">
                                <EditFormSettings VisibleIndex="0" Visible="True" Caption="Nomor Task" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="No. Pengaduan" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" 
							PropertiesTextEdit-DisplayFormatInEditMode="true" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-Wrap="True"
							HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="NomorPengaduan" Settings-AutoFilterCondition="Contains" Width="150px">
                                <EditFormSettings VisibleIndex="0" Visible="false" Caption="No Pengaduan" />
                                <Settings AutoFilterCondition="Contains"></Settings>								
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn Caption="No. Pengaduan/TicketNo" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" 
							PropertiesTextEdit-DisplayFormatInEditMode="true" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-Wrap="True"
							HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="TicketNumber" Settings-AutoFilterCondition="Contains" Width="150px">
                                <EditFormSettings VisibleIndex="0" Visible="false" Caption="No Pengaduan/TicketNo" />
                                <Settings AutoFilterCondition="Contains"></Settings>								
                            </dx:GridViewDataTextColumn>--%>
                            <%--<dx:GridViewDataTextColumn Caption="TicketNumber" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" 
							PropertiesTextEdit-DisplayFormatInEditMode="true" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-Wrap="True"
							HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="NomorPengaduan" Settings-AutoFilterCondition="Contains" Width="150px">
                                <EditFormSettings VisibleIndex="0" Visible="false" Caption="TicketNumber" />
                                <Settings AutoFilterCondition="Contains"></Settings>								
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataDateColumn FieldName="TanggalTask" PropertiesDateEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss"
							HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Caption="Tgl Pengaduan" VisibleIndex="1" HeaderStyle-Wrap="True" Width="130px">
                                <EditFormSettings VisibleIndex="3" Visible="false" Caption="Tgl Pengaduan" />
                                <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd HH:mm:ss" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="NamaTask" Width="100%">
                                <%--<DataItemTemplate>
                                    <%# Eval("NamaTask") %> - <%# Eval("IdProvinsi") %>
                                    <%# If(Eval("NamaTask").ToString() <> "", Eval("NamaTask") + " - " + Eval("IdProvinsi"), "") %>
                                </DataItemTemplate>--%>
                                <EditFormSettings VisibleIndex="1" Visible="True" Caption="Nama Task " />
                                <PropertiesTextEdit ValidationSettings-RequiredField-IsRequired="true"></PropertiesTextEdit>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>                            
                            <dx:GridViewDataComboBoxColumn FieldName="NamaTeknisi" Width="100%" Caption="Teknisi" CellStyle-HorizontalAlign="Center" >
                                <EditFormSettings VisibleIndex="2" Visible="True" Caption="Teknisi " />
                                <PropertiesComboBox DataSourceID="dsteknisi" TextField="Nama" ValidationSettings-RequiredField-IsRequired="true"
                                    ValueField="Nama" EnableSynchronization="False" IncrementalFilteringMode="Contains">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>   
                            <dx:GridViewDataTextColumn FieldName="NamaKoordinator" Width="100%" Caption="Koordinator" CellStyle-HorizontalAlign="Center" >
                                <EditFormSettings Visible="False"/>
                                <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            </dx:GridViewDataTextColumn> 
                            <dx:GridViewDataComboBoxColumn Visible="true" FieldName="IdProject" Caption="Project" Width="140px" CellStyle-HorizontalAlign="Center" >
                                <EditFormSettings Visible="True" Caption="nama project" />
                                <PropertiesComboBox DataSourceID="dsproject" TextField="ProjectName" ValueField="IdProject"
                                    ValueType="System.String" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="IdStatusKoordinator" Caption="Status Koordinator" HeaderStyle-Wrap="True" CellStyle-HorizontalAlign="Center" >
                                <EditFormSettings Visible="False"/>
                                <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            </dx:GridViewDataTextColumn>                          
                            <dx:GridViewDataComboBoxColumn FieldName="IdJenisTask" HeaderStyle-HorizontalAlign="Center" Caption="Order" Visible="false" 
							VisibleIndex="2" Width="100px">
                                <EditFormSettings VisibleIndex="5" Visible="True" Caption="Order" />
                                <PropertiesComboBox DataSourceID="dsjeniskerja" TextField="Service" ValueField="KodeService"
                                    ValueType="System.String" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataDateColumn FieldName="TglMulai" Visible="false" Caption="Tanggal Mulai" Width="100%">
                                <EditFormSettings Caption="Tanggal Mulai" VisibleIndex="4" Visible="True" />
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True" ValidationSettings-RequiredField-IsRequired="true"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="TglSelesai" Visible="false" Caption="Tanggal Mulai" Width="100%">
                                <EditFormSettings Caption="Tanggal Selesai" VisibleIndex="5" Visible="True" />
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True" ValidationSettings-RequiredField-IsRequired="true"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdProvinsi" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="6" Visible="True" Caption="Provinsi" />
                                <PropertiesComboBox DataSourceID="dsprovinsi" TextField="Provinsi" ValidationSettings-RequiredField-IsRequired="true"
                                    ValueField="IdProvinsi" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                    <ClientSideEvents SelectedIndexChanged="onkotachanged"></ClientSideEvents>
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdCity" Visible="false" Width="100px">
                                <EditFormSettings VisibleIndex="8" Visible="True" Caption="Kota" />
                                <PropertiesComboBox DataSourceID="dskota" TextField="Kota" ValueField="Kota"
                                    IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                </PropertiesComboBox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataMemoColumn FieldName="AlamatPengaduan" Caption="Alamat Pengaduan" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="12" Visible="True" Caption="Alamat " />
                                <Settings AutoFilterCondition="Contains"></Settings>
								<PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true"></PropertiesMemoEdit>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataMemoColumn FieldName="CatatanKoordinator" Visible="true" HeaderStyle-Wrap="True" Width="100%">
                                <EditFormSettings VisibleIndex="14" Visible="True" Caption="Catatan Koordinator"/>
                                <Settings AutoFilterCondition="Contains"></Settings>
								<PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true" Width="300px" Height="90px"></PropertiesMemoEdit>
								<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataMemoColumn FieldName="DeskripsiPermasalahan" Caption="Permasalah" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="13" Visible="True" Caption="Permasalahan " />
                                <Settings AutoFilterCondition="Contains"></Settings>
								<PropertiesMemoEdit ValidationSettings-RequiredField-IsRequired="true" Width="300px" Height="90px"></PropertiesMemoEdit>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataDateColumn FieldName="TglStatusTask" Visible="false" Width="100%">
                                <EditFormSettings Caption="Tanggal Status Task" VisibleIndex="9" Visible="True" />
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True" ValidationSettings-RequiredField-IsRequired="true"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>                            
                            <dx:GridViewDataComboBoxColumn Visible="False" FieldName="IdStatusTask" HeaderStyle-HorizontalAlign="Center" Caption="Status Pengaduan" VisibleIndex="3" Width="150px">
                                <EditFormSettings Visible="True" VisibleIndex="11" Caption="Status task" />
                                <PropertiesComboBox DataSourceID="dsstatus" TextField="Status" ValueField="ID"
                                    ValueType="System.String" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            
                        </Columns>
                        <Templates>
                            <DetailRow>
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <b>Lokasi Remote</b>
                                        <div class="pull-right">
                                            <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" ClientSideEvents-Click="OnCustomButtonClick" Text="Pilih Lokasi Remote" Font-Bold="True" Font-Underline="True">
                                            </dx:ASPxHyperLink>
                                            <%--<dx:ASPxButton ID="ASPxButton1" runat="server"  AutoPostBack="false" CssClass="btn btn-md btn-info" Text="Pilih Lokasi Remote"></dx:ASPxButton>--%>
                                        </div>
                                    </h4>

                                </div>

                                <dx:ASPxGridView ID="grid_VID" ClientInstanceName="grid_VID" runat="server" DataSourceID="dsdetailtask" 
                                    KeyFieldName="NoListTask" ClientIDMode="AutoID" Width="100%" 
                                    OnBeforePerformDataSelect="grid_VID_BeforePerformDataSelect" OnRowDeleting="grid_VID_RowDeleting" OnRowInserting="grid_VID_RowInserting" 
                                    OnRowUpdating="grid_VID_RowUpdating" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1" />
                                    <SettingsDetail ShowDetailRow="true" />
                                    <Columns>
                                        <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" Caption="ACTION" HeaderStyle-BackColor="#d6f1ff" HeaderStyle-HorizontalAlign="Center"
                                            ShowDeleteButton="True" ShowEditButton="true" VisibleIndex="10">
                                            <CellStyle BackColor="#d6f1ff">
                                            </CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="NoTask" Visible="false" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" 
                                            HeaderStyle-HorizontalAlign="Center" Caption="No. Task" Width="70px">
                                            <EditFormSettings VisibleIndex="2" Visible="True" />
                                            <PropertiesTextEdit Width="500px"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
										<dx:GridViewDataTextColumn FieldName="SID" HeaderStyle-HorizontalAlign="Center" ReadOnly="true" Caption="SID" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0">
                                            <PropertiesTextEdit Width="500px"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="VID" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="170px" ReadOnly="true" PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0">
                                            <EditFormSettings VisibleIndex="1" />
                                            <PropertiesComboBox DataSourceID="dsVIDload" TextField="VID" ValueField="VID" Width="170px"
                                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="IPLAN" HeaderStyle-HorizontalAlign="Center" Caption="IP LAN" Width="80px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="NAMAREMOTE" HeaderStyle-HorizontalAlign="Center" Caption="Nama Remote" Width="150px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ALAMAT" HeaderStyle-HorizontalAlign="Center" Caption="Alamat" Width="250px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="IdStatusPerbaikan" HeaderStyle-HorizontalAlign="Center" Caption="Status" Width="100px">
                                            <PropertiesComboBox DataSourceID="dsStatusperbaikan" TextField="Status" ValueField="ID" Width="170px"
                                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <%--<dx:GridViewDataTextColumn FieldName="CatatanKoordinator" VisibleIndex="7" HeaderStyle-HorizontalAlign="Center" Caption="Catatan Koordinator" Width="140px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>--%>
                                        <dx:GridViewDataMemoColumn FieldName="CatatanKoordinator" Visible="true" HeaderStyle-Wrap="True" Width="400px">
                                            <EditFormSettings VisibleIndex="11" Visible="True" Caption="Catatan Koordinator"/>
                                            <Settings AutoFilterCondition="Contains"></Settings>
								            <PropertiesMemoEdit  ValidationSettings-RequiredField-IsRequired="true" Width="500px" Height="90px" ></PropertiesMemoEdit>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </dx:GridViewDataMemoColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" Caption="Order" Width="100px">
                                            <EditFormSettings Visible="True" VisibleIndex="10" />
                                            <PropertiesComboBox DataSourceID="dsjeniskerja" Width="500px" TextField="Service" ValueField="Service" ValueType="System.String" IncrementalFilteringMode="Contains">
                                            </PropertiesComboBox>
                                            <Settings AutoFilterCondition="Contains"></Settings>
                                        </dx:GridViewDataComboBoxColumn>
                                        <%--<dx:GridViewCommandColumn Caption="Remote Lainnya" VisibleIndex="7">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnDetails" Text="Select" />
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>--%>
                                    </Columns>
                                    <Templates>
                                        <DetailRow>
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <b>Barang Terpasang</b>
                                                </h4>
                                            </div>
                                            <dx:ASPxGridView ID="grid_barang_on" runat="server" KeyFieldName="ID" DataSourceID="dsbarang_on" EnableTheming="true" Width="80%" OnBeforePerformDataSelect="grid_barang_on_BeforePerformDataSelect" Theme="MetropolisBlue">
                                                <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" />
                                                <SettingsBehavior ConfirmDelete="True" />
                                                <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                                <SettingsPager>
                                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                </SettingsPager>
                                                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                                <SettingsSearchPanel Visible="True" />
                                                <SettingsEditing Mode="PopupEditForm" />
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
                                            <br />
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <b>History Order/Pekerjaan</b>
                                                </h4>
                                            </div>
                                            <dx:ASPxGridView ID="gridhistory" runat="server" KeyFieldName="NoListTask" DataSourceID="dsgridhistory" EnableTheming="true" Width="80%" OnBeforePerformDataSelect="gridhistory_BeforePerformDataSelect" Theme="MetropolisBlue">
                                                <Settings ShowFooter="false" />

                                                <SettingsPager>
                                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                </SettingsPager>
                                                <SettingsSearchPanel Visible="True" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="NoTask" HeaderStyle-HorizontalAlign="Center" Caption="No. Task" Width="200px" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NamaTeknisi" HeaderStyle-HorizontalAlign="Center" Caption="Teknisi" Width="200px" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TglSelesaiKerjaan" HeaderStyle-HorizontalAlign="Center" Caption="Tanggal Selesai pengerjaan" Width="200px" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" Caption="Order" Width="200px" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                            <br />
                                        </DetailRow>
                                    </Templates>
                                    <%-- <ClientSideEvents CustomButtonClick="OnCustomButtonClick" />--%>
                                </dx:ASPxGridView>

                                <br />
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <b>Barang/Sparepart Yang Dibawa</b>
                                    </h4>
                                </div>
                                <dx:ASPxGridView ID="grid_barang" runat="server" ClientInstanceName="grid_barang" KeyFieldName="ID" DataSourceID="dsbarang" OnRowInserting="grid_barang_RowInserting" OnRowUpdating="grid_barang_RowUpdating" OnRowDeleting="grid_barang_RowDeleting" OnBeforePerformDataSelect="grid_barang_BeforePerformDataSelect" Width="100%" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="PopupEditForm" />
                                    <Columns>
                                        <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" Width="200px" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="10">
                                            <CellStyle BackColor="#d6f1ff">
                                            </CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="NoTask" Width="200px" PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                            <PropertiesComboBox DataSourceID="dsvidbarang" TextField="NoTask"
                                                ValueField="NoTask" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="NamaBarang" Width="200px" VisibleIndex="1" Caption="Nama Barang">
                                            <PropertiesComboBox DataSourceID="dsbarangpick" TextField="Barang"
                                                ValueField="IdBarang" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="SN" HeaderStyle-HorizontalAlign="Center" Caption="Serial Number" Width="200px" VisibleIndex="3">
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn FieldName="Qty" HeaderStyle-HorizontalAlign="Center" Caption="Qty" Width="100px" VisibleIndex="7">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <br />
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <b>Status Validasi Task</b>
                                    </h4>
                                </div>
                                <dx:ASPxGridView ID="Grid_Validasi" runat="server" ClientInstanceName="Grid_Validasi" KeyFieldName="ID" DataSourceID="dsstatusvalidasi" 
                                    OnRowUpdating="Grid_Validasi_RowUpdating" OnBeforePerformDataSelect="Grid_Validasi_BeforePerformDataSelect" Width="50%" 
                                    AutoGenerateColumns="false" Theme="MetropolisBlue" OnCellEditorInitialize="grid_CellEditorInitialize" 
                                    OnExpandedChanged="Grid_Validasi_ExpandedChanged" AutoCollapse="True" EnableCallBacks="True">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="PopupEditForm" />

                                    <Columns>
                                        <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ButtonRenderMode="Default" ShowEditButton="True" Caption="Action" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10">
                                            <CellStyle BackColor="#d6f1ff">
                                            </CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="NoTask" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Caption="No. Task" Width="100%" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="IdStatusKoordinator" Caption="status" Width="100%">
                                            <EditFormSettings VisibleIndex="10" Visible="True" Caption="status" />
                                            <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                                                <Items>
                                                    <dx:ListEditItem Text="Valid" Value="Valid" />
                                                    <dx:ListEditItem Text="Not Valid" Value="Not Valid" />
                                                </Items>
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="dsvidbarang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select NoTask from trTask"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dssubtask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsjarak" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dstaskcoor" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsteknisi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msEmployee where EmployeeType = 'Teknisi'"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsdetailtask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsstatusvalidasi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select NoTask, IdStatusKoordinator from trTask"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsVID" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select VID, IPLAN, SID, NAMAREMOTE, AlamatInstall from trRemoteSite"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsVIDload" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select top 10 VID from trRemoteSite"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsbarang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsuang" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsbarangpick" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msbarang order by IdBarang"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsStatusperbaikan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msstatus"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsgridhistory" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                </div>

            </div>


            <div class="panel panel-default" id="panelmanager" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <b>Manager</b>
                    </h4>
                </div>

                <div class="panel-body">
                    <dx:ASPxGridView ID="grid_manager" runat="server" DataSourceID="dsmanager" KeyFieldName="ID" Width="100%" AutoGenerateColumns="false" 
                        Theme="MetropolisBlue">
                        <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" ShowGroupPanel="True" />
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                        <SettingsPager>
                            <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                        <SettingsSearchPanel Visible="True" />
                        <SettingsEditing Mode="PopupEditForm" />
                        <SettingsDetail ShowDetailRow="true" />
                        <Columns>
                            <dx:GridViewCommandColumn FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="false" ShowEditButton="True" VisibleIndex="20">
                                <CellStyle BackColor="#d6f1ff">
                                </CellStyle>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="No. Task" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Width="80px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="NoTask" Settings-AutoFilterCondition="Contains" VisibleIndex="0">
                                <EditFormSettings VisibleIndex="0" Visible="True" Caption="Nomor Task " />
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn Caption="TicketNumber" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" 
							PropertiesTextEdit-DisplayFormatInEditMode="true" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-Wrap="True"
							HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="TicketNumber" Settings-AutoFilterCondition="Contains" Width="150px" VisibleIndex="0">
                                <EditFormSettings VisibleIndex="0" Visible="false" Caption="TicketNumber" />
                                <Settings AutoFilterCondition="Contains"></Settings>								
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataDateColumn FieldName="TanggalTask" PropertiesDateEdit-CalendarProperties-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss" HeaderStyle-HorizontalAlign="Center" Caption="Tgl Pengaduan" VisibleIndex="1" Width="140px">
                                <EditFormSettings VisibleIndex="1" Visible="True" Caption="Tgl Pengaduan " />
                                <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd HH:mm:ss" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn Caption="No. Pengaduan" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" VisibleIndex="1"
							PropertiesTextEdit-DisplayFormatInEditMode="true" PropertiesTextEdit-DisplayFormatString="Auto Increment" HeaderStyle-Wrap="True"
							HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" FieldName="NomorPengaduan" Settings-AutoFilterCondition="Contains" Width="150px">
                                <EditFormSettings VisibleIndex="0" Visible="false" Caption="No Pengaduan" />
                                <Settings AutoFilterCondition="Contains"></Settings>								
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="NamaTask" Width="200px" VisibleIndex="2">
                                <%--<DataItemTemplate>
                                    <%# Eval("NamaTask")%> - <%# Eval("IdProvinsi")%>
                                    <%# If(Eval("NamaTask").ToString() <> "", Eval("NamaTask") + " - " + Eval("IdProvinsi"), "") %>
                                </DataItemTemplate>--%>
                                <EditFormSettings VisibleIndex="2" Visible="True" Caption="Nama Task " />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="NamaTeknisi" Width="150px" Caption="Teknisi" VisibleIndex="3">
                                <EditFormSettings VisibleIndex="3" Visible="True" Caption="Teknisi " />
                                <PropertiesComboBox DataSourceID="dsteknisi" TextField="Nama" ValidationSettings-RequiredField-IsRequired="true"
                                    ValueField="Nama" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataDateColumn FieldName="TglMulai" Visible="false" Caption="Tanggal Mulai" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss" Width="100px" VisibleIndex="4">
                                <EditFormSettings Caption="Tanggal Mulai" VisibleIndex="4" Visible="True" />
                                <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="TglSelesai" Visible="false" Caption="Tanggal Mulai" Width="140px" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss">
                                <EditFormSettings Caption="Tanggal Selesai" VisibleIndex="5" Visible="True" />
                                <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd HH:mm:ss" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataMemoColumn FieldName="CatatanKoordinator" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="16" Visible="True" Caption="Catatan Koor" />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <PropertiesMemoEdit  ValidationSettings-RequiredField-IsRequired="true" Width="350px" Height="90px" ></PropertiesMemoEdit>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdProject" Caption="nama project" Width="100px" VisibleIndex="8">
                                <EditFormSettings Visible="True" VisibleIndex="6" Caption="nama project" />
                                <PropertiesComboBox DataSourceID="dsproject" TextField="ProjectName" ValueField="IdProject"
                                    ValueType="System.String" IncrementalFilteringMode="Contains">
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="NamaKoordinator" Caption="Koordinator" Width="100px">
                                <EditFormSettings Visible="True" VisibleIndex="7" />
                                <PropertiesComboBox DataSourceID="dskoordinator" TextField="Nama" ValueField="Nama"
                                    ValueType="System.String" IncrementalFilteringMode="Contains">
                                </PropertiesComboBox>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataMemoColumn FieldName="CatatanManager" VisibleIndex="12" Width="100%">
                                <EditFormSettings VisibleIndex="15" Visible="True" Caption="Catatan Manager" />
                                <PropertiesMemoEdit  ValidationSettings-RequiredField-IsRequired="true" Width="350px" Height="90px" ></PropertiesMemoEdit>
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdStatusManager" Width="100 PX" Caption="Status Manager" VisibleIndex="13">
                                <EditFormSettings Visible="True" VisibleIndex="13" Caption="Status Manager" />
                                <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains" ValidationSettings-RequiredField-IsRequired="true">
                                    <Items>
                                        <dx:ListEditItem Text="Valid" Value="Valid" />
                                        <dx:ListEditItem Text="Not Valid" Value="Not Valid" />
                                    </Items>
                                </PropertiesComboBox>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataDateColumn FieldName="TglStatusManager" Visible="false" Caption="Tanggal " ReadOnly="true" Width="140px" PropertiesDateEdit-DisplayFormatString="yyyy-MM-dd HH:mm:ss">
                                <EditFormSettings Visible="false" />
                                <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="IdStatusTask" HeaderStyle-HorizontalAlign="Center" Caption="Status Task" VisibleIndex="14" Width="100px">
                                <EditFormSettings VisibleIndex="14" Visible="True" Caption="Status Task" />
                                <PropertiesComboBox DataSourceID="dsstatus" TextField="Status" ValueField="ID"
                                    ValueType="System.String" IncrementalFilteringMode="Contains">
                                </PropertiesComboBox>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataMemoColumn FieldName="DeskripsiPermasalahan" Caption="Permasalah" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="8" Visible="True" Caption="Permasalahan " />
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataMemoColumn FieldName="AlamatPengaduan" Caption="Alamat Pengaduan" Visible="false" Width="100%">
                                <EditFormSettings VisibleIndex="9" Visible="True" Caption="Alamat " />
                                <Settings AutoFilterCondition="Contains"></Settings>
                            </dx:GridViewDataMemoColumn>

                        </Columns>
                        <Templates>
                            <DetailRow>
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <b>Lokasi Remote</b>
                                        <div class="pull-right">
                                            <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" ClientSideEvents-Click="OnCustomButtonClick" Text="Pilih Lokasi Remote" Font-Bold="True" Font-Underline="True">
                                            </dx:ASPxHyperLink>
                                            <%--<dx:ASPxButton ID="ASPxButton1" runat="server"  AutoPostBack="false" CssClass="btn btn-md btn-info" Text="Pilih Lokasi Remote"></dx:ASPxButton>--%>
                                        </div>
                                    </h4>

                                </div>

                                <dx:ASPxGridView ID="grid_VID" ClientInstanceName="grid_VID" runat="server" DataSourceID="dsdetailtask" KeyFieldName="NoListTask" Width="100%" OnBeforePerformDataSelect="grid_VID_BeforePerformDataSelect" OnRowDeleting="grid_VID_RowDeleting" OnRowInserting="grid_VID_RowInserting" OnRowUpdating="grid_VID_RowUpdating" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="PopupEditForm" />
                                    <SettingsDetail ShowDetailRow="true" />
                                    <Columns>
                                        <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" Caption="ACTION" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="10">
                                            <CellStyle BackColor="#d6f1ff">
                                            </CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="NoTask" Visible="false" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" HeaderStyle-HorizontalAlign="Center" Caption="No. Task" Width="70px">
                                            <EditFormSettings VisibleIndex="2" Visible="True" />
                                        </dx:GridViewDataTextColumn>
										<dx:GridViewDataTextColumn FieldName="SID" HeaderStyle-HorizontalAlign="Center" Caption="SID" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true">                                            
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="VID" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Caption="VID" Width="200px" ReadOnly="true" PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0">
                                            <EditFormSettings VisibleIndex="1" />
                                            <PropertiesComboBox DataSourceID="dsVIDload" TextField="VID" ValueField="VID"
                                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                            </PropertiesComboBox>

                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="IPLAN" HeaderStyle-HorizontalAlign="Center" Caption="IP LAN" Width="100px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="NAMAREMOTE" HeaderStyle-HorizontalAlign="Center" Caption="Nama Remote" Width="300px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ALAMAT" HeaderStyle-HorizontalAlign="Center" Caption="Alamat" Width="300px">
                                            <EditFormSettings Visible="false" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="IdStatusPerbaikan" HeaderStyle-HorizontalAlign="Center" Caption="Status" Width="100px">
                                            <PropertiesComboBox DataSourceID="dsStatusperbaikan" TextField="Status" ValueField="ID"
                                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" Caption="Order" Width="100px"
										PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true">
                                            <EditFormSettings Visible="True" VisibleIndex="10" />
                                            <PropertiesComboBox DataSourceID="dsjeniskerja" TextField="Service" ValueField="Service" ValueType="System.String" IncrementalFilteringMode="Contains">
                                            </PropertiesComboBox>
                                            <Settings AutoFilterCondition="Contains"></Settings>
                                        </dx:GridViewDataComboBoxColumn>
                                        <%--<dx:GridViewCommandColumn Caption="Remote Lainnya" VisibleIndex="7">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton ID="btnDetails" Text="Select" />
                                            </CustomButtons>
                                        </dx:GridViewCommandColumn>--%>
                                    </Columns>
                                    <Templates>
                                        <DetailRow>
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <b>Barang Terpasang</b>
                                                </h4>
                                            </div>
                                            <dx:ASPxGridView ID="grid_barang_on" runat="server" KeyFieldName="ID" DataSourceID="dsbarang_on" EnableTheming="true" Width="80%" OnBeforePerformDataSelect="grid_barang_on_BeforePerformDataSelect" Theme="MetropolisBlue">
                                                <Settings HorizontalScrollBarMode="Visible" ShowFooter="false" />
                                                <SettingsBehavior ConfirmDelete="True" />
                                                <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                                <SettingsPager>
                                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                </SettingsPager>
                                                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                                <SettingsSearchPanel Visible="True" />
                                                <SettingsEditing Mode="PopupEditForm" />
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
                                            <br />
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <b>History Order/Pekerjaan</b>
                                                </h4>
                                            </div>
                                            <dx:ASPxGridView ID="gridhistory" runat="server" KeyFieldName="NoListTask" DataSourceID="dsgridhistory" EnableTheming="true" Width="80%" OnBeforePerformDataSelect="gridhistory_BeforePerformDataSelect" Theme="MetropolisBlue">
                                                <Settings ShowFooter="false" />
                                                <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                                <SettingsPager>
                                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                                </SettingsPager>
                                                <SettingsSearchPanel Visible="True" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="NoTask" HeaderStyle-HorizontalAlign="Center" Caption="No. Task" Width="200px" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NamaTeknisi" HeaderStyle-HorizontalAlign="Center" Caption="Teknisi" Width="200px" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TglSelesaiKerjaan" HeaderStyle-HorizontalAlign="Center" Caption="Tanggal Selesai pengerjaan" Width="200px" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="idJenisTask" HeaderStyle-HorizontalAlign="Center" Caption="Order" Width="200px" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                            <br />
                                        </DetailRow>
                                    </Templates>
                                    <%-- <ClientSideEvents CustomButtonClick="OnCustomButtonClick" />--%>
                                </dx:ASPxGridView>
                                <br />
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <b>Barang/Sparepart Yang Dibawa</b>
                                    </h4>
                                </div>

                                <dx:ASPxGridView ID="grid_barang_Manager" runat="server" ClientInstanceName="grid_barang_Manager" KeyFieldName="ID" DataSourceID="dsbarangmanager" OnRowInserting="grid_barang_Manager_RowInserting" OnRowUpdating="grid_barang_Manager_RowUpdating" OnRowDeleting="grid_barang_Manager_RowDeleting" OnBeforePerformDataSelect="grid_barang_Manager_BeforePerformDataSelect" Width="100%" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsResizing ColumnResizeMode="Control" Visualization="Postponed" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="PopupEditForm" />
                                    <Columns>
                                        <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="10">
                                            <CellStyle BackColor="#d6f1ff">
                                            </CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="NoTask" Width="100px" PropertiesComboBox-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" VisibleIndex="0">
                                            <EditFormSettings Visible="False" />
                                            <PropertiesComboBox DataSourceID="dsvidbarang" TextField="NoTask"
                                                ValueField="NoTask" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="NamaBarang" Width="100px" VisibleIndex="1" Caption="Nama Barang">
                                            <PropertiesComboBox DataSourceID="dsbarangpick" TextField="Barang"
                                                ValueField="IdBarang" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="SN" HeaderStyle-HorizontalAlign="Center" Caption="Serial Number" Width="200px" VisibleIndex="3">
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn FieldName="Qty" HeaderStyle-HorizontalAlign="Center" Caption="Qty" Width="100px" VisibleIndex="7">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>

                                <div class="panel-heading">

                                    <h4><a href="formpengajuanuang.aspx?NoTask=<%# Eval("NoTask")%>" class="btn btn-info" style="color: white;">Input Dana SPJ</a></h4>

                                </div>
                                <%--<dx:ASPxGridView ID="Grid_Uang" runat="server" ClientInstanceName="Grid_Uang" KeyFieldName="ID" DataSourceID="dsuang" OnRowInserting="Grid_Uang_RowInserting" OnRowUpdating="Grid_Uang_RowUpdating" OnRowDeleting="Grid_Uang_RowDeleting" OnBeforePerformDataSelect="Grid_Uang_BeforePerformDataSelect" Width="100%" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                    <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" ShowGroupPanel="True" />
                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsPager>
                                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsEditing Mode="EditFormAndDisplayRow" />

                                    <Columns>
                                        <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="10">
                                            <CellStyle BackColor="#d6f1ff">
                                            </CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="NoTask" ReadOnly="true" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" Caption="No. Task" Width="150px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="TglPengajuan" Caption="Tanggal Pengajuan" Width="150px">
                                            <EditFormSettings Caption="Tanggal Pengajuan" VisibleIndex="1" Visible="True" />
                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" DisplayFormatInEditMode="True"></PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataTextColumn FieldName="JumlahPengajuan" Caption="Jumlah Pengajuan" Width="200px" PropertiesTextEdit-DisplayFormatString="{0:n0}" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataMemoColumn FieldName="Catatan" Caption="Catatan" Width="300px" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2">
                                        </dx:GridViewDataMemoColumn>
                                    </Columns>
                                </dx:ASPxGridView>--%>
                            </DetailRow>
                        </Templates>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="dsbarang_on" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsdetailtaskmanager" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsbarangmanager" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsmanager" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="dskoordinator" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msEmployee where EmployeeType= 'Coordinator'"></asp:SqlDataSource>
                </div>

            </div>
        </div>

    </div>
</asp:Content>

