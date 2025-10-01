<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="rpttaskperprovinsi.aspx.vb" Inherits="rpttaskperprovinsi" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Report Task per Provinsi</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            <div class="pull-left">
                <table>
                    <tr>
                        <td style="width: 200px">
                            <b>Choose Project:</b>
                            <dx:ASPxComboBox ID="cbproject" runat="server" ValueType="System.String" DataSourceID="dsproject" 
                                ValueField="IdProject" CssClass="form-control" IncrementalFilteringMode="Contains">
                                <Columns>
                                    <dx:ListBoxColumn Caption="ID" FieldName="IdProject"></dx:ListBoxColumn>
                                    <dx:ListBoxColumn Caption="Project Name" FieldName="ProjectName"></dx:ListBoxColumn>                                    
                                </Columns>
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <br />
                            <asp:Button ID="btnfilter" CssClass="btn btn-info" runat="server" Text="show" Width="120px" Height="33px" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>

            <dx:ASPxGridView ID="gridtaskprov" ClientInstanceName="gridtaskprov" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dstaskprov" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowFooter="true" ShowGroupFooter="VisibleIfExpanded" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Provinsi" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Provinsi" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Site Survey" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="SiteSurvey" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Installation" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Installation" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MIGRASI" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="MIGRASI" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="CM" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="CM" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DISMANTLE" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="DISMANTLE" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Software Upgrade" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="SoftwareUpgrade" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="PM" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="PM" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="OBSTACLE" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="OBSTACLE" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="RELOKASI" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="RELOKASI" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="BBD" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="BBD" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>                   
                </Columns>
                
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="SiteSurvey" ShowInGroupFooterColumn="SiteSurvey" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Installation" ShowInGroupFooterColumn="Installation" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="MIGRASI" ShowInGroupFooterColumn="MIGRASI" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="CM" ShowInGroupFooterColumn="CM" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="DISMANTLE" ShowInGroupFooterColumn="DISMANTLE" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="SoftwareUpgrade" ShowInGroupFooterColumn="SoftwareUpgrade" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="PM" ShowInGroupFooterColumn="PM" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="OBSTACLE" ShowInGroupFooterColumn="OBSTACLE" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="RELOKASI" ShowInGroupFooterColumn="RELOKASI" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="BBD" ShowInGroupFooterColumn="BBD" SummaryType="Sum" DisplayFormat="{0}" />
                  
                </TotalSummary>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="SiteSurvey" ShowInGroupFooterColumn="SiteSurvey" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Installation" ShowInGroupFooterColumn="Installation" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="MIGRASI" ShowInGroupFooterColumn="MIGRASI" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="CM" ShowInGroupFooterColumn="CM" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="DISMANTLE" ShowInGroupFooterColumn="DISMANTLE" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="SoftwareUpgrade" ShowInGroupFooterColumn="SoftwareUpgrade" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="PM" ShowInGroupFooterColumn="PM" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="OBSTACLE" ShowInGroupFooterColumn="OBSTACLE" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="RELOKASI" ShowInGroupFooterColumn="RELOKASI" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="BBD" ShowInGroupFooterColumn="BBD" SummaryType="Sum" DisplayFormat="{0}" />
                </GroupSummary>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="reportexp" runat="server" GridViewID="gridtaskprov"></dx:ASPxGridViewExporter>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblExport" runat="server" Text="Export To:"></asp:Label>
                        <dx:ASPxComboBox ID="cbexpTin" CssClass="form-control" runat="server">
                            <Items>
                                <dx:ListEditItem Text="PDF" Value="pdf" />
                                <dx:ListEditItem Text="EXCEL 97-2003" Value="xls" />
                                <dx:ListEditItem Text="EXCEL" Value="xlsx" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td>&nbsp<br />
                        &nbsp
                        <asp:Button ID="bconvertTin" CssClass="btn btn-success" runat="server" Text="Convert" Width="120px" Height="33px" />
                    </td>
                </tr>
            </table>
            <asp:SqlDataSource ID="dstaskprov" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select IdProject,ProjectName from trProject"></asp:SqlDataSource>

        </div>
    </div>
</asp:Content>

