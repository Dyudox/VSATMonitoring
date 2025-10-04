<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="rpttask.aspx.vb" Inherits="rpttask" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Report Task per Teknisi</li>
        </ul>
    </div>
    <div class="seperator"></div>
    <div class="panel panel-default">
        <div class="panel-tab clearfix">
            <ul class="tab-bar">
                <li class="active"><a href="#view" data-toggle="tab"><i class="fa fa-home"></i> View</a></li>
				<li><a href="#export" data-toggle="tab"><i class="fa fa-pencil"></i> Export</a></li>
            </ul>
        </div>
        <div class="panel-body">
            <div class="tab-content">
                <div class="tab-pane fade in active" id="view">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">  
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnsubmit" />
                        </Triggers>                      
                        <ContentTemplate>
                            <div class="row">       
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label>Perusahaan</label> 
                                        <dx:ASPxComboBox ID="cb_perusahaan" runat="server" CssClass="form-control input-sm" IncrementalFilteringMode="Contains"
                                             ValueField="id" TextField="NamaPerusahaan">                                            
                                        </dx:ASPxComboBox> 
                                        <asp:SqlDataSource ID="ds_perusahaan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"
                                            SelectCommand="select * from msPerusahaan"></asp:SqlDataSource>
                                    </div>                                    
                                </div>                        
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label>Start Date</label> 
                                        <dx:aspxdateedit ID="StarDate" runat="server" CssClass="form-control input-sm" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                            <TimeSectionProperties Visible="false">
                                                <TimeEditProperties EditFormatString="HH:mm:ss" />
                                            </TimeSectionProperties>
                                        </dx:aspxdateedit>       
                                    </div>                                                                         
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label>End Date</label> 
                                        <dx:aspxdateedit ID="enddate" runat="server" CssClass="form-control input-sm" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">                                            
                                            <TimeSectionProperties Visible="false">
                                                <TimeEditProperties EditFormatString="HH:mm:ss" />
                                            </TimeSectionProperties>
                                        </dx:aspxdateedit>  
                                    </div>                                                                              
                                </div>
                                <div class="col-lg-1">
                                    <div style="padding-top:18px"></div>
                                    <asp:Button ID="btnsubmit" runat="server" Text="Show" CssClass="btn btn-info" ValidationGroup="btnsubmit" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="tab-pane fade" id="export">
                    <div class="row">
                        <div class="col-lg-1">
                            <asp:Label ID="Label1" runat="server" Text="Export To:" Font-Bold="True"></asp:Label>
                        </div>
                        <div class="col-lg-2">
                            <dx:ASPxComboBox ID="cbExpLogin" runat="server" CssClass="form-control input-sm">
                                <Items>
                                    <dx:ListEditItem Text="pdf" Value="pdf" />
                                    <dx:ListEditItem Text="Excel 97-2003" Value="xls" />
                                    <dx:ListEditItem Text="Excel" Value="xlsx" />
                                    <dx:ListEditItem Text="CSV" Value="csv" />
                                    <dx:ListEditItem Text="RTF" Value="Rtf" />
                                </Items>
                            </dx:ASPxComboBox> 
                        </div>
                        <div class="col-lg-1">
                            <asp:Button ID="bconvert" runat="server" Text="Download" CssClass="btn btn-info" />         
                            <dx:ASPxGridViewExporter ID="GVExpTax" runat="server" PaperKind="A2" GridViewID="gv_rptTaskDataEntry"
                                BottomMargin="1" LeftMargin="1" RightMargin="1" TopMargin="1" ></dx:ASPxGridViewExporter>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row form-group" id="lblError" runat="server" visible="false"> 
        <div class="col-sm-12">
            <div class="alert alert-danger">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true" id="B_notError" runat="server">&times;</button>
                <strong>
                    <asp:Label ID="lbl_Error" runat="server">error Massege</asp:Label>
                </strong>
            </div>
        </div>
    </div><!-- Notifed Error-->
    <div class="seperator"></div>
    <div class="row hide">
        <div class="col-lg-11 text-right">
            <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Clear" NavigateUrl="javascript:void(0);">
                <ClientSideEvents Click="function(s, e) {gv_rptTaskDataEntry.ClearFilter(); }" />
            </dx:ASPxHyperLink>
        </div>
    </div>   
    <div style="width:100%;" class="form-group">
        <asp:SqlDataSource ID="ds_RptTaskDataEntry" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
        <dx:ASPxGridView ID="gv_rptTaskDataEntry" runat="server" ClientInstanceName="gv_rptTaskDataEntry" DataSourceID="ds_RptTaskDataEntry"
            Width="100%" Theme="MetropolisBlue" AutoGenerateColumns="False" KeyFieldName="Id">
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            <Styles>
                <Header HorizontalAlign="Center" Wrap="False"></Header>
                <Cell Wrap="False" />
                <FixedColumn BackColor="LightYellow" />
            </Styles>
            <SettingsPager Position="Bottom" PageSize="10">
                <AllButton Text="All"></AllButton>
                <NextPageButton Text="Next &gt;"></NextPageButton>
                <PrevPageButton Text="&lt; Prev"></PrevPageButton>
                <PageSizeItemSettings ShowAllItem="true" Items="50, 100" Visible="True" />
            </SettingsPager>
            <SettingsBehavior AllowEllipsisInText="true" />
            <SettingsResizing ColumnResizeMode="Control" Visualization="Live" />
            <SettingsSearchPanel Visible="True" />
            <Settings ShowGroupPanel="True" VerticalScrollableHeight="300" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Visible" VerticalScrollBarStyle="VirtualSmooth"/>
            <Columns>
                <dx:GridViewDataTextColumn FieldName="No" FixedStyle="Left" Width="40">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NamaTeknisi" Caption="NAMA TEKNISI" FixedStyle="Left" Width="200">                    
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NoTask" Caption="NO. TASK" Width="90">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NamaTask" Caption="NAMA TASK" Width="200">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TanggalTask" Caption="TGL. CREATE TASK">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm tt" />
                </dx:GridViewDataDateColumn>
				<dx:GridViewDataTextColumn FieldName="VID">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NAMAREMOTE" Caption="NAMA LOKASI" Width="200">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="idJenisTask" Caption="JENIS ORDER">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="TglMulai" Caption="TGL. MULAI KERJA">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="TglSelesai" Caption="TGL. SELESAI KERJA">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="Status" Caption="STATUS">
                    <Settings FilterMode="DisplayText" AutoFilterCondition="Contains"/>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
    </div>
</asp:Content>

