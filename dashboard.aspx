<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="dashboard.aspx.vb" Inherits="dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-4 col-sm-4">
                <div class="panel panel-default panel-stat2 bg-danger" onclick="TaskYesterday()">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-envelope"></i>
                        </span>
                        <div class="pull-right text-right" id="divyesterday">
                            <%--<div class="value">5</div>
                            <div class="title">Task Yesterday</div>--%>
                        </div>
                    </div>
                </div>
                <!-- /panel -->
            </div>
            <div class="col-md-4 col-sm-4">
                <div class="panel panel-default panel-stat2 bg-success" onclick="TaskToday()">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-bar-chart-o"></i>
                        </span>
                        <div class="pull-right text-right" id="divtoday">
                            <%--<div class="value">116</div>
                            <div class="title">Task Today</div>--%>
                        </div>
                    </div>
                </div>
                <!-- /panel -->
            </div>
            <div class="col-md-4 col-sm-4">
                <div class="panel panel-default panel-stat2 bg-warning" onclick="TaskTomorrow()">
                    <div class="panel-body">
                        <span class="stat-icon">
                            <i class="fa fa-archive"></i>
                        </span>
                        <div class="pull-right text-right" id="divtomorrow()">
                            <%--<div class="value">121</div>
                            <div class="title">Task Tomorrow</div>--%>
                        </div>
                    </div>
                </div>
                <!-- /panel -->
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Work Progress Per Aktivitas
                    </div>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Task</th>
                                <th>Progress</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Corrective Maintenance</td>
                                <td>
                                    <div class="progress progress-striped active" style="height: 8px; margin: 5px 0 0 0;">
                                        <div class="progress-bar" style="width: 45%">
                                            <span class="sr-only">45% Complete</span>
                                        </div>
                                    </div>
                                </td>
                                <td><span class="badge badge-info">45%</span></td>
                            </tr>
                            <tr>
                                <td>Preventive Maintenance</td>
                                <td>
                                    <div class="progress progress-striped active" style="height: 8px; margin: 5px 0 0 0;">
                                        <div class="progress-bar progress-bar-success" style="width: 61%">
                                            <span class="sr-only">61% Complete</span>
                                        </div>
                                    </div>
                                </td>
                                <td><span class="badge badge-info">61%</span></td>
                            </tr>
                            <tr>
                                <td>Relocation</td>
                                <td>
                                    <div class="progress progress-striped active" style="height: 8px; margin: 5px 0 0 0;">
                                        <div class="progress-bar progress-bar-danger" style="width: 97%">
                                            <span class="sr-only">97% Complete</span>
                                        </div>
                                    </div>
                                </td>
                                <td><span class="badge badge-info">97%</span></td>
                            </tr>
                            <tr>
                                <td>Migration/Repointing</td>
                                <td>
                                    <div class="progress progress-striped active" style="height: 8px; margin: 5px 0 0 0;">
                                        <div class="progress-bar progress-bar-warning" style="width: 18%">
                                            <span class="sr-only">18% Complete</span>
                                        </div>
                                    </div>
                                </td>
                                <td><span class="badge badge-info">18%</span></td>
                            </tr>
                            <tr>
                                <td>Pasang Baru</td>
                                <td>
                                    <div class="progress progress-striped active" style="height: 8px; margin: 5px 0 0 0;">
                                        <div class="progress-bar progress-bar-danger" style="width: 18%">
                                            <span class="sr-only">18% Complete</span>
                                        </div>
                                    </div>
                                </td>
                                <td><span class="badge badge-info">18%</span></td>
                            </tr>
                            <tr>
                                <td>Dismentel</td>
                                <td>
                                    <div class="progress progress-striped active" style="height: 8px; margin: 5px 0 0 0;">
                                        <div class="progress-bar" style="width: 45%">
                                            <span class="sr-only">45% Complete</span>
                                        </div>
                                    </div>
                                </td>
                                <td><span class="badge badge-info">45%</span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Work Progress per wilayah
                    </div>
                    <div class="table-responsive">
                        <table class="table table-striped" id="dataTable">
                            <thead>
                                <tr>
                                    <th>Provinsi</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Sumatera</td>
                                    <td>3300</td>
                                </tr>
                                <tr>
                                    <td>Jawa</td>
                                    <td>1200</td>
                                </tr>
                                <tr>
                                    <td>DKI Jakarta</td>
                                    <td>550</td>
                                </tr>

                                <tr>
                                    <td>Bali</td>
                                    <td>978</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
            </div>
        </div>
        <br />
        <div class="row">

            <div class="table-responsive">
                <table class="table table-striped" id="dataTable2">
                    <thead>
                        <tr>
                            <th class="text-center">VID</th>
                            <th>Tanggal Task</th>
                            <th>Provinsi</th>
                            <th>Koordinator</th>
                            <th>Teknisi</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="ltr_email" runat="server"></asp:Literal>
                    </tbody>
                </table>
            </div>

        </div>

        <%-- <div class="panel panel-default">
                <div class="panel-heading clearfix">
                    <span class="pull-left"><i class="fa fa-bar-chart-o fa-lg"></i>Website Traffic</span>
                    <ul class="tool-bar">
                        <li><a href="#" class="refresh-widget" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Refresh"><i class="fa fa-refresh"></i></a></li>
                    </ul>
                </div>
                <div class="panel-body" id="trafficWidget">
                    <div id="placeholder" class="graph" style="height: 250px"></div>
                </div>
                <div class="panel-footer">
                    <div class="row row-merge">
                        <div class="col-xs-3 text-center border-right">
                            <h4 class="no-margin">1232</h4>
                            <small class="text-muted">Visitors</small>
                        </div>
                        <div class="col-xs-3 text-center border-right">
                            <h4 class="no-margin">5421</h4>
                            <small class="text-muted">Orders</small>
                        </div>
                        <div class="col-xs-3 text-center border-right">
                            <h4 class="no-margin">3021</h4>
                            <small class="text-muted">Tickets</small>
                        </div>
                        <div class="col-xs-3 text-center">
                            <h4 class="no-margin">7098</h4>
                            <small class="text-muted">Customers</small>
                        </div>
                    </div>
                    <!-- ./row -->
                </div>
                <div class="loading-overlay">
                    <i class="loading-icon fa fa-refresh fa-spin fa-lg"></i>
                </div>
            </div>--%>
        <!-- /panel -->
    </div>

</asp:Content>

