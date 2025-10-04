<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="testpopup.aspx.vb" Inherits="testpopup" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script>
        function testdoang(s, e) {
            var comboValue = s.GetValue();
            //document.getElementById("MainContent_callbackPanelX_hdvaluefilter").value = comboValue
            callbackPanelX.PerformCallback(s.GetValue());
            //alert(comboValue);
        }
    </script>
    <div class="panel-tab clearfix">
        <ul class="tab-bar">
            <li id="lihome1" runat="server" class="active"><a href="#home1" data-toggle="tab"><i class="fa fa-home"></i>Pilih Lokasi Berdasarkan Provinsi</a></li>
            <li id="liprofile1" runat="server"><a href="#profile1" data-toggle="tab"><i class="fa fa-pencil"></i>Pilih Lokasi Terdekat</a></li>
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
                            <dx:ASPxCallbackPanel ID="callbackPanelX" ClientInstanceName="callbackPanelX" runat="server" Width="200px">
                                <PanelCollection>
                                    <dx:PanelContent ID="PanelContent2" runat="server">
                                        <asp:HiddenField runat="server" ID="hdvaluefilter" />
                                        <dx:ASPxGridView ID="popup_grid_subtask" ClientInstanceName="popup_grid_subtask" runat="server" DataSourceID="dssubtask" OnBeforePerformDataSelect="popup_grid_subtask_BeforePerformDataSelect" KeyFieldName="ID" Width="800px" AutoGenerateColumns="false" Theme="MetropolisBlue">
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


                        </td>
                    </tr>
                </table>
            </div>

        </div>

    </div>
    <asp:SqlDataSource ID="dssubtask" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" runat="server"></asp:SqlDataSource>
</asp:Content>

