<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ReportRekapTask.aspx.vb" Inherits="ReportRekapTask" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Report Rekap Task</li>
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
                        <td style="width: 200px">
                            <b>Choose Task:</b>
                            <dx:ASPxComboBox ID="cbtask" runat="server" ValueType="System.String" DataSourceID="dstask" ValueField="Service" TextField="Service" CssClass="form-control"></dx:ASPxComboBox>
                        </td>
                        <td>
                            <br />
                            <asp:Button ID="btnfilter" CssClass="btn btn-info" runat="server" Text="show" Width="120px" Height="33px" />
                        </td>
                    </tr>
                </table>
                <br />

            </div>

            <dx:ASPxGridView ID="gridrekaptask" ClientInstanceName="gridrekaptask" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dsrekaptask" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowFooter="true" ShowGroupFooter="VisibleIfExpanded" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Project" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="IdProject" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jenis Task" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="idJenisTask" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tahun" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="tahun" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jan" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="January" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Feb" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="February" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mar" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="March" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Apr" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="April" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mei" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="May" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jun" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="June" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jul" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="July" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Aug" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="August" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Sep" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="September" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Okt" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="October" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nov" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="November" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Des" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="December" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Total" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Total" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>

                </Columns>

                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="January" ShowInGroupFooterColumn="January" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="February" ShowInGroupFooterColumn="February" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="March" ShowInGroupFooterColumn="March" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="April" ShowInGroupFooterColumn="April" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="May" ShowInGroupFooterColumn="May" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="June" ShowInGroupFooterColumn="June" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="July" ShowInGroupFooterColumn="July" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="August" ShowInGroupFooterColumn="August" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="September" ShowInGroupFooterColumn="September" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="October" ShowInGroupFooterColumn="October" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="November" ShowInGroupFooterColumn="November" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="December" ShowInGroupFooterColumn="December" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Total" ShowInGroupFooterColumn="Total" SummaryType="Sum" DisplayFormat="{0}" />
                </TotalSummary>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="January" ShowInGroupFooterColumn="January" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="February" ShowInGroupFooterColumn="February" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="March" ShowInGroupFooterColumn="March" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="April" ShowInGroupFooterColumn="April" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="May" ShowInGroupFooterColumn="May" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="June" ShowInGroupFooterColumn="June" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="July" ShowInGroupFooterColumn="July" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="August" ShowInGroupFooterColumn="August" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="September" ShowInGroupFooterColumn="September" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="October" ShowInGroupFooterColumn="October" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="November" ShowInGroupFooterColumn="November" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="December" ShowInGroupFooterColumn="December" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Total" ShowInGroupFooterColumn="Total" SummaryType="Sum" DisplayFormat="{0}" />
                </GroupSummary>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="reportexp" runat="server" GridViewID="gridrekaptask"></dx:ASPxGridViewExporter>
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
            <asp:SqlDataSource ID="dsrekaptask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select IdProject,ProjectName from trProject"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dstask" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select Service from msJenis_Task"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

