<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dashnomaster.aspx.vb" Inherits="dashnomaster" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" />

    <!-- Pace -->
    <link href="css/pace.css" rel="stylesheet" />

    <!-- Color box -->
    <link href="css/colorbox/colorbox.css" rel="stylesheet" />

    <!-- Morris -->
    <link href="css/morris.css" rel="stylesheet" />

    <!-- Datatable -->

    <link href="css/jquery.dataTables_themeroller.css" rel="stylesheet" />

    <!-- Endless -->
    <link href="css/endless.min.css" rel="stylesheet" />
    <link href="css/endless-skin.css" rel="stylesheet" />
    <style>
        /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
        #map {
            height: 70%;
        }
        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 100%;
            margin: 100;
            padding: 100;
        }
    </style>
</head>
<body class="overflow-hidden">
    <form runat="server">
        <!-- Overlay Div -->
        <div class="padding-md">
            <div class="col-md-12" style="width: 100%; height: 700px;">
                <div class="row">
                    <div class="col-md-3 col-sm-4">
                        <div class="panel panel-default panel-stat2 bg-danger" onclick="TaskYesterday()">
                            <div class="panel-body">
                                <span class="stat-icon">
                                    <i class="fa fa-bar-chart-o"></i>
                                </span>
                                <div class="pull-right text-right" id="divyesterday">
                                    <%--<div class="value">5</div>
                            <div class="title">Task Yesterday</div>--%>
                                </div>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>
                    <div class="col-md-3 col-sm-4">
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
                    <div class="col-md-3 col-sm-4">
                        <div class="panel panel-default panel-stat2 bg-warning" onclick="TaskTomorrow()">
                            <div class="panel-body">
                                <span class="stat-icon">
                                    <i class="fa fa-bar-chart-o"></i>
                                </span>
                                <div class="pull-right text-right" id="divtomorrow">
                                    <%--<div class="value">121</div>
                            <div class="title">Task Tomorrow</div>--%>
                                </div>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>
                    <div class="col-md-3 col-sm-4">
                        <div class="panel panel-default panel-stat2 bg-info" onclick="alltask()">
                            <div class="panel-body">
                                <span class="stat-icon">
                                    <i class="fa fa-bar-chart-o"></i>
                                </span>
                                <div class="pull-right text-right" id="divalltask">
                                    <%--<div class="value">121</div>
                            <div class="title">Task Tomorrow</div>--%>
                                </div>
                            </div>
                        </div>
                        <!-- /panel -->
                    </div>
                </div>

                <div class="row">

                    <div class="col-md-12">
                        <iframe src="http://invision.io/maps/cobamarkers.html" width="100%" height="400px"></iframe>
                        <br /><br />
                        <div class="row">
                            <div class="col-md-3">
                                <h4 style="text-align:left"><b>Advance Search :</b></h4>
                            </div>
                            <div class="col-md-3">
                                <dx:ASPxComboBox ID="cbProvinsi" Width="100%" CssClass="form-control" runat="server" ValueType="System.String" DataSourceID="dsprovinsi" ValueField="Provinsi" TextField="Provinsi"></dx:ASPxComboBox>
                            </div>
                            <div class="col-md-3">
                                <dx:ASPxComboBox ID="cbKota" Width="100%" CssClass="form-control" runat="server" ValueType="System.String" DataSourceID="dskota" ValueField="Kota" TextField="Kota"></dx:ASPxComboBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-success" Width="100%"  />
                            </div>
                        </div>
                        <asp:SqlDataSource ID="dsprovinsi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msProvinsi"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="dskota" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msKota"></asp:SqlDataSource>
                    </div>
                    <%--<div class="col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Work Progress Per Aktivitas
                            </div>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Task</th>
                                        <th>Total Task</th>
                                    </tr>
                                </thead>
                                <tbody id="divaktivitas" onclick="dataaktivitas()">
                                </tbody>
                            </table>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </form>
    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>

    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.js"></script>

    <!-- Datatable -->
    <script src='js/jquery.dataTables.min.js'></script>

    <!-- Flot -->
    <script src='js/jquery.flot.min.js'></script>

    <!-- Morris -->
    <script src='js/rapheal.min.js'></script>
    <script src='js/morris.min.js'></script>

    <!-- Colorbox -->
    <script src='js/jquery.colorbox.min.js'></script>

    <!-- Sparkline -->
    <script src='js/jquery.sparkline.min.js'></script>

    <!-- Pace -->
    <script src='js/uncompressed/pace.js'></script>

    <!-- Popup Overlay -->
    <script src='js/jquery.popupoverlay.min.js'></script>

    <!-- Slimscroll -->
    <script src='js/jquery.slimscroll.min.js'></script>

    <!-- Modernizr -->
    <script src='js/modernizr.min.js'></script>

    <!-- Cookie -->
    <script src='js/jquery.cookie.min.js'></script>


    <%--     <script type="text/javascript">
         var map;
         function initMap() {
             map = new google.maps.Map(document.getElementById('map'), {
                 center: { lat: -6.175110, lng: 106.865039 },
                 zoom: 8
             });
         }
    </script>--%>
    <%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCl-PW09nRRwHZcIUNwG4oXf0EvJS9dlYc&callback=initMap" async defer></script>--%>


    <script type="text/javascript">
        $(document).ready(function () {
            var waktu = setInterval(aaaa, 5000);

        });

        function aaaa() {
            TaskYesterday();
            TaskToday();
            TaskTomorrow();
            alltask();
            dataaktivitas();
            datawilayah();
        }

        function TaskYesterday() {
            var messageDiv = $('#content');
            var dataTableDivNya = $('#divyesterday');

            $.ajax({
                type: 'GET',
                async: false,
                url: "AjaxPages/dashboardload.aspx?source=taskyesterday",
                cache: false,
                success: function (result) {
                    dataTableDivNya.empty();
                    dataNyaBar = result;
                    //alert(result);
                    //counter++;
                    dataTableDivNya.empty();
                    dataTableDivNya.append(result);
                    //dataTableDivNya.append("<br />");
                    //messageDiv.append("counter = " + counter);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    counter++;
                    messageDiv.empty();
                    messageDiv.append("thrown error: " + thrownError);
                    messageDiv.append("<br />");
                    messageDiv.append("status text: " + xhr.statusText);
                    messageDiv.append("<br />");
                    messageDiv.append("counter = " + counter);
                }
            });

        }

        function TaskToday() {
            var messageDiv = $('#content');
            var dataTableDivNya = $('#divtoday');

            $.ajax({
                type: 'GET',
                async: false,
                url: "AjaxPages/dashboardload.aspx?source=tasktoday",
                cache: false,
                success: function (result) {
                    dataTableDivNya.empty();
                    dataNyaBar = result;
                    //alert(result);
                    //counter++;
                    dataTableDivNya.empty();
                    dataTableDivNya.append(result);
                    //dataTableDivNya.append("<br />");
                    //messageDiv.append("counter = " + counter);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    counter++;
                    messageDiv.empty();
                    messageDiv.append("thrown error: " + thrownError);
                    messageDiv.append("<br />");
                    messageDiv.append("status text: " + xhr.statusText);
                    messageDiv.append("<br />");
                    messageDiv.append("counter = " + counter);
                }
            });

        }

        function TaskTomorrow() {
            var messageDiv = $('#content');
            var dataTableDivNya = $('#divtomorrow');

            $.ajax({
                type: 'GET',
                async: false,
                url: "AjaxPages/dashboardload.aspx?source=tasktomorrow",
                cache: false,
                success: function (result) {
                    dataTableDivNya.empty();
                    dataNyaBar = result;
                    //alert(result);
                    //counter++;
                    dataTableDivNya.empty();
                    dataTableDivNya.append(result);
                    //dataTableDivNya.append("<br />");
                    //messageDiv.append("counter = " + counter);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    counter++;
                    messageDiv.empty();
                    messageDiv.append("thrown error: " + thrownError);
                    messageDiv.append("<br />");
                    messageDiv.append("status text: " + xhr.statusText);
                    messageDiv.append("<br />");
                    messageDiv.append("counter = " + counter);
                }
            });

        }

        function alltask() {
            var messageDiv = $('#content');
            var dataTableDivNya = $('#divalltask');

            $.ajax({
                type: 'GET',
                async: false,
                url: "AjaxPages/dashboardload.aspx?source=alltask",
                cache: false,
                success: function (result) {
                    dataTableDivNya.empty();
                    dataNyaBar = result;
                    //alert(result);
                    //counter++;
                    dataTableDivNya.empty();
                    dataTableDivNya.append(result);
                    //dataTableDivNya.append("<br />");
                    //messageDiv.append("counter = " + counter);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    counter++;
                    messageDiv.empty();
                    messageDiv.append("thrown error: " + thrownError);
                    messageDiv.append("<br />");
                    messageDiv.append("status text: " + xhr.statusText);
                    messageDiv.append("<br />");
                    messageDiv.append("counter = " + counter);
                }
            });

        }

        function dataaktivitas() {
            var messageDiv = $('#content');
            var dataTableDivNya = $('#divaktivitas');

            $.ajax({
                type: 'GET',
                async: false,
                url: "AjaxPages/dashboardload.aspx?source=dataaktivitas",
                cache: false,
                success: function (result) {
                    dataTableDivNya.empty();
                    dataNyaBar = result;
                    //alert(result);
                    //counter++;
                    dataTableDivNya.empty();
                    dataTableDivNya.append(result);
                    //dataTableDivNya.append("<br />");
                    //messageDiv.append("counter = " + counter);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    counter++;
                    messageDiv.empty();
                    messageDiv.append("thrown error: " + thrownError);
                    messageDiv.append("<br />");
                    messageDiv.append("status text: " + xhr.statusText);
                    messageDiv.append("<br />");
                    messageDiv.append("counter = " + counter);
                }
            });

        }

        function datawilayah() {
            var messageDiv = $('#content');
            var dataTableDivNya = $('#divwilayah');

            $.ajax({
                type: 'GET',
                async: false,
                url: "AjaxPages/dashboardload.aspx?source=datawilayah",
                cache: false,
                success: function (result) {
                    dataTableDivNya.empty();
                    dataNyaBar = result;
                    //alert(result);
                    //counter++;
                    dataTableDivNya.empty();
                    dataTableDivNya.append(result);
                    //dataTableDivNya.append("<br />");
                    //messageDiv.append("counter = " + counter);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    counter++;
                    messageDiv.empty();
                    messageDiv.append("thrown error: " + thrownError);
                    messageDiv.append("<br />");
                    messageDiv.append("status text: " + xhr.statusText);
                    messageDiv.append("<br />");
                    messageDiv.append("counter = " + counter);
                }
            });

        }
    </script>


    <script>
        $(function () {
            //Gritter notification
            $('#regular-notification').click(function () {
                $.gritter.add({
                    title: 'This is a regular notice!',
                    text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    image: 'img/user.jpg',
                    sticky: false,
                    time: ''
                });
                return false;
            });

            $('#sticky-notification').click(function () {

                var unique_id = $.gritter.add({
                    title: 'This is a sticky notice!',
                    text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    image: 'img/user.jpg',
                    sticky: true,
                    time: '',
                    class_name: 'my-sticky-class'
                });

                // You can have it return a unique id, this can be used to manually remove it later using
                /*
				setTimeout(function(){

					$.gritter.remove(unique_id, {
						fade: true,
						speed: 'slow'
					});
						
				}, 6000)
				*/

                return false;
            });

            $('#info-notification').click(function () {

                $.gritter.add({
                    title: '<i class="fa fa-info-circle"></i> This is a info notification',
                    text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    sticky: false,
                    time: '',
                    class_name: 'gritter-info'
                });
                return false;
            });

            $('#success-notification').click(function () {

                $.gritter.add({
                    title: '<i class="fa fa-check-circle"></i> This is a success notification',
                    text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    sticky: false,
                    time: '',
                    class_name: 'gritter-success'
                });
                return false;
            });

            $('#warning-notification').click(function () {

                $.gritter.add({
                    title: '<i class="fa fa-warning"></i> This is a warning notification!',
                    text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    sticky: false,
                    time: '',
                    class_name: 'gritter-warning'
                });
                return false;
            });

            $('#danger-notification').click(function () {

                $.gritter.add({
                    title: '<i class="fa fa-times-circle"></i> This is a error notification!',
                    text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    sticky: false,
                    time: '',
                    class_name: 'gritter-danger'
                });
                return false;
            });

            $('#facebook-notification').click(function () {

                $.gritter.add({
                    title: '<i class="fa fa-times-circle"></i> This is a error notification!',
                    text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    sticky: false,
                    time: '',
                    class_name: 'gritter-info'
                });
                return false;
            });

            $('#twitter-notification').click(function () {

                $.gritter.add({
                    title: '<i class="fa fa-times-circle"></i> This is a error notification!',
                    text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
                    sticky: false,
                    time: '',
                    class_name: 'gritter-info'
                });
                return false;
            });

            $("#remove-all").click(function () {
                $.gritter.removeAll();
                return false;
            });

            //jQuery popup overlay
            $('#darkCustomModal').popup({
                pagecontainer: '.container',
                transition: 'all 0.3s'
            });


            $('#lightCustomModal').popup({
                pagecontainer: '.container',
                transition: 'all 0.3s'
            });

        });
    </script>

    <script>
        $(function () {
            $('#dataTable').dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers"
            });

            $('#chk-all').click(function () {
                if ($(this).is(':checked')) {
                    $('#responsiveTable').find('.chk-row').each(function () {
                        $(this).prop('checked', true);
                        $(this).parent().parent().parent().addClass('selected');
                    });
                }
                else {
                    $('#responsiveTable').find('.chk-row').each(function () {
                        $(this).prop('checked', false);
                        $(this).parent().parent().parent().removeClass('selected');
                    });
                }
            });
        });
	</script>

    <script>
        $(function () {
            $('#dataTable2').dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers"
            });

            $('#chk-all').click(function () {
                if ($(this).is(':checked')) {
                    $('#responsiveTable').find('.chk-row').each(function () {
                        $(this).prop('checked', true);
                        $(this).parent().parent().parent().addClass('selected');
                    });
                }
                else {
                    $('#responsiveTable').find('.chk-row').each(function () {
                        $(this).prop('checked', false);
                        $(this).parent().parent().parent().removeClass('selected');
                    });
                }
            });
        });
    </script>

</body>
</html>
