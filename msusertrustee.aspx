<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="msusertrustee.aspx.vb" Inherits="msusertrustee" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        function OnRowClickUserTrustee(s, e) {
            //Unselect all rows

            //Select the row

            //alert(values);
            gridLevelUser.GetRowValues(gridLevelUser.GetFocusedRowIndex(), 'TrusteeID;LevelUser', OnGetRowValuesssUserTrustee);
        }
        function OnGetRowValuesssUserTrustee(values) {
            var status;
            var tablename;
            var checkVoice;
            var suara;
            // document.getElementById("MainContent_callbackPanelX_txtKodeGroup_I").value = values[1];
            document.getElementById("MainContent_callbackPanelX_txtGroupID").value = values[0];
            //alert(values[0]);
            callbackPanelX.PerformCallback(values[0]);
        }
    </script>

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Master User Trustee</li>
        </ul>
    </div>
    <br />
    <asp:Label ID="errlabel" runat="server"></asp:Label>
    <asp:Panel ID="panelusercreate" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Level User"></asp:Label>
                </td>
                <td>&nbsp;:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtleveluser" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Level Autorization"></asp:Label>
                </td>
                <td>&nbsp;:&nbsp;</td>
                <td>
                    <dx:ASPxComboBox ID="cmb_level_user" Height="30px" runat="server" Theme="MetropolisBlue" Width="100%"
                        DataSourceID="sql_level_user" TextField="Description" ValueField="Name" CssClass="form-control chzn-select">
                        <Columns>
                            <dx:ListBoxColumn Caption="Level Autorization" FieldName="Description" Width="200px" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:SqlDataSource ID="sql_level_user" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"
                        SelectCommand="select * from msLevelUser"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <dx:ASPxLabel runat="server" ID="LblDescription" Text="Description">
                    </dx:ASPxLabel>

                </td>
                <td style="vertical-align: top;">&nbsp;:&nbsp;</td>
                <td>
                    <asp:TextBox ID="txt_descriptionText" runat="server" CssClass="form-control" TextMode="MultiLine" Width="900px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table style="width: 100%;">
        <tr>
            <td>
                <%--<dx:ASPxGridView ID="gridLevelUser" KeyFieldName="TrusteeID" runat="server"
                    DataSourceID="DsUserTrustee" ClientInstanceName="gridLevelUser" Width="100%" AutoGenerateColumns="False" EnableTheming="True" Theme="MetropolisBlue">
                    <SettingsPager>
                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm" />
                    <SettingsBehavior EnableRowHotTrack="true" ConfirmDelete="true" AllowSelectByRowClick="true" />
                    <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowVerticalScrollBar="false"
                        ShowGroupPanel="false" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <ClientSideEvents RowDblClick="function(s, e) 
                   { 
                    OnRowClickUserTrustee(s,e); 
                   }" />
                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" Width="20%" ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="7">
                            <CellStyle BackColor="#d6f1ff">
                            </CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Level User" FieldName="LevelUser" VisibleIndex="1">
                            <PropertiesComboBox DataSourceID="dsleveluser" TextField="Name" ValueField="Name"
                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="User Previlege" FieldName="LevelUserSbg" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Level User Description" FieldName="Description" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsSearchPanel Visible="True" />
                    <SettingsEditing Mode="EditFormAndDisplayRow" />
                </dx:ASPxGridView>--%>
                <dx:BootstrapGridView ID="gridLevelUser" KeyFieldName="TrusteeID" runat="server"
                    DataSourceID="DsUserTrustee" ClientInstanceName="gridLevelUser" Width="100%" AutoGenerateColumns="False">
                    <SettingsPager>
                        <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm" />
                    <SettingsBehavior EnableRowHotTrack="true" ConfirmDelete="true" AllowSelectByRowClick="true" />
                    <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowVerticalScrollBar="false"
                        ShowGroupPanel="false" />
                    <SettingsBehavior ConfirmDelete="true" />
                    <ClientSideEvents RowDblClick="function(s, e) 
                   { 
                    OnRowClickUserTrustee(s,e); 
                   }" />
                    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                    <Columns>
                        <dx:BootstrapGridViewComboBoxColumn Caption="Level User" FieldName="LevelUser" VisibleIndex="1">
                            <PropertiesComboBox DataSourceID="dsleveluser" TextField="Name" ValueField="Name"
                                ValueType="System.String" IncrementalFilteringMode="Contains">
                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                            </PropertiesComboBox>
                        </dx:BootstrapGridViewComboBoxColumn>
                        <dx:BootstrapGridViewTextColumn Caption="User Previlege" FieldName="LevelUserSbg" Settings-AutoFilterCondition="Contains" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn Caption="Level User Description" FieldName="Description" Settings-AutoFilterCondition="Contains" VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:BootstrapGridViewTextColumn>
                    </Columns>                   
                    <SettingsEditing Mode="PopupEditForm" />
                    <SettingsPopup>
                        <EditForm Width="600" />
                    </SettingsPopup>
                </dx:BootstrapGridView>
                <asp:SqlDataSource ID="dsleveluser" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select DISTINCT(Name) as Name from msLevelUser"></asp:SqlDataSource>
                <asp:SqlDataSource ID="DsLevel" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="SELECT LevelUser FROM [msUserTrusteee]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="DsUserTrustee" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"
                    SelectCommand="SELECT * FROM [msUserTrusteee]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <dx:ASPxCallbackPanel ID="callbackPanelX" ClientInstanceName="callbackPanelX" runat="server"
        Width="100%" Height="100px" RenderMode="Table">
        <PanelCollection>
            <dx:PanelContent ID="PanelContent2" runat="server">
                <asp:HiddenField runat="server" ID="txtGroupID" />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <%--<dx:ASPxLabel runat="server" ID="lblListBarang" ForeColor="black" Text="Menu Name ">
                                                            </dx:ASPxLabel>--%>
                            <%-- <dx:ASPxListBox ID="listBarang" runat="server" SelectionMode="CheckColumn" Width="510"
                                                                Height="200" DataSourceID="ds_muser_trustee" ValueField="MenuID" ValueType="System.String"
                                                                TextField="Description">
                                                            </dx:ASPxListBox>--%>

                            <dx:ASPxCheckBoxList ID="checkBoxList" runat="server" DataSourceID="dsCheckBox" Width="100%"
                                ValueField="MenuID" TextField="Description" RepeatColumns="5" RepeatLayout="Table" ToolTip="Menu Name" ValueType="System.String">
                            </dx:ASPxCheckBoxList>
                        </td>
                    </tr>

                </table>
                <br />
                <asp:SqlDataSource ID="dsCheckBox" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                <asp:Button class="btn btn-info" ID="Bleveluser_user_management" runat="server" Text="Add Level User" />
                <asp:Button class="btn btn-info" ID="BUpdateleveluser_user_management" runat="server" Text="Update" OnClientClick="return confirm('Are you sure you want to Update?')" />
                <asp:Button class="btn btn-info" ID="BSaveleveluser_user_management" runat="server" Text="Save" OnClientClick="return confirm('Are you sure you want to Save?')" />
                <asp:Button class="btn btn-info" ID="BCancelleveluser_user_management" runat="server" Text="Cancel" />
                <asp:Button class="btn btn-info" ID="bDelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to Delete?')" />
                <br />
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
</asp:Content>

