<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="rpttaskperteknisi.aspx.vb" Inherits="rpttaskperteknisi" %>


<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Report Task per Teknisi</li>
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
            <dx:ASPxGridView ID="gridtaskteknisi" ClientInstanceName="gridtaskteknisi" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="dstaskteknisi" EnableTheming="True" Theme="MetropolisBlue">
                <Settings ShowFooter="true" ShowGroupFooter="VisibleIfExpanded" ShowGroupPanel="True" />
                <SettingsBehavior ConfirmDelete="True" />
                <SettingsPager>
                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                </SettingsPager>
                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                <SettingsSearchPanel Visible="True" />
                <SettingsEditing Mode="EditFormAndDisplayRow" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Nama Teknisi" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="NamaTeknisi" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Task" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="idJenisTask" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tahun" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Tahun" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jan" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Jan" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Feb" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Feb" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mar" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Mar" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Apr" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Apr" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="May" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="May" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jun" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Jun" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Jul" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Jul" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Aug" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Aug" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Sep" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Sep" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Okt" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Okt" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Nov" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Nov" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Des" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" FieldName="Dec" Settings-AutoFilterCondition="Contains">
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <%-- <CellStyle HorizontalAlign="Center"></CellStyle>--%>
                    </dx:GridViewDataTextColumn>
                </Columns>

                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="Jan" ShowInGroupFooterColumn="Jan" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Feb" ShowInGroupFooterColumn="Feb" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Mar" ShowInGroupFooterColumn="Mar" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Apr" ShowInGroupFooterColumn="Apr" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="May" ShowInGroupFooterColumn="May" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Jun" ShowInGroupFooterColumn="Jun" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Jul" ShowInGroupFooterColumn="Jul" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Aug" ShowInGroupFooterColumn="Aug" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Sep" ShowInGroupFooterColumn="Sep" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Okt" ShowInGroupFooterColumn="Okt" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Nov" ShowInGroupFooterColumn="Nov" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Dec" ShowInGroupFooterColumn="Dec" SummaryType="Sum" DisplayFormat="{0}" />
                </TotalSummary>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="Jan" ShowInGroupFooterColumn="Jan" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Feb" ShowInGroupFooterColumn="Feb" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Mar" ShowInGroupFooterColumn="Mar" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Apr" ShowInGroupFooterColumn="Apr" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="May" ShowInGroupFooterColumn="May" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Jun" ShowInGroupFooterColumn="Jun" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Jul" ShowInGroupFooterColumn="Jul" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Aug" ShowInGroupFooterColumn="Aug" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Sep" ShowInGroupFooterColumn="Sep" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Okt" ShowInGroupFooterColumn="Okt" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Nov" ShowInGroupFooterColumn="Nov" SummaryType="Sum" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="Dec" ShowInGroupFooterColumn="Dec" SummaryType="Sum" DisplayFormat="{0}" />
                </GroupSummary>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="reportexp" runat="server" GridViewID="gridtaskteknisi"></dx:ASPxGridViewExporter>
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
            <asp:SqlDataSource ID="dstaskteknisi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsproject" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select IdProject,ProjectName from trProject"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>

