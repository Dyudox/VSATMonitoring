<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>VSAT Dashboard</title>
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

    <!-- Datatable -->

    <link href="css/jquery.dataTables_themeroller.css" rel="stylesheet" />

    <link href="owl.carousel/owl.carousel.min.css" rel="stylesheet" />
    <link href="owl.carousel/owl.theme.min.css" rel="stylesheet" />

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
	<div id="top-nav" class="fixed skin-6">
		<a href="#" class="brand">
			<span>VSAT</span>
			<span class="text-toggle"> Dashboard</span>
		</a>
		
		<ul class="nav-notification clearfix">
			<li class="dropdown">
				<a class="dropdown-toggle" data-toggle="dropdown" href="#">
					<strong id="projectid">Select Project</strong>
					<span class="caret"></span>
				</a>
				<ul class="dropdown-menu" id="SelectProject">
					<!-- <li><a href="#">project1</a></li> -->
					<!-- <li><a href="#">project2</a></li> -->
					<!-- <li><a href="#">project3</a></li> -->
				</ul>
			</li>
		</ul>
	</div><!-- /top-nav-->
	<br/>
	<br/>
	<br/>
		
    <form id="form1" runat="server">
        <div class="padding-md">
			
			<!-- <div class="row"> -->
				<!-- <div class="col-md-12" id=""> -->
					<!-- <div id="news-slider" class="owl-carousel owl-theme"> -->
						<!-- <div id="slider" style='position:relative !important;'></div> -->
					<!-- </div> -->
				<!-- </div> -->
			<!-- </div> -->
            <!-- <br /> -->
			
            <div class="row">
				<div class="col-md-12">
					<div id="news-slider" class="owl-carousel owl-theme">
						<div class="panel panel-default panel-stat1 bg-info">
							<div class="panel-body">
								<div class="value"><span id="Unknown">0</span></div>
								<div class="title">
									<span class="m-left-xs">Unknown</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-warning">
							<div class="panel-body">
								<div class="value"><span id="BBD">0</span></div>
								<div class="title">
									<span class="m-left-xs">BBD</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-success">
							<div class="panel-body">
								<div class="value"><span id="CM">0</span></div>
								<div class="title">
									<span class="m-left-xs">CM</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-danger">
							<div class="panel-body">
								<div class="value"><span id="Dismantle">0</span></div>
								<div class="title">
									<span class="m-left-xs">Dismantle</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-info">
							<div class="panel-body">
								<div class="value"><span id="Installation">0</span></div>
								<div class="title">
									<span class="m-left-xs">Installation</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-warning">
							<div class="panel-body">
								<div class="value"><span id="Migrasi">0</span></div>
								<div class="title">
									<span class="m-left-xs">Migrasi</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-success">
							<div class="panel-body">
								<div class="value"><span id="Obstacle">0</span></div>
								<div class="title">
									<span class="m-left-xs">Obstacle</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-danger">
							<div class="panel-body">
								<div class="value"><span id="PM">0</span></div>
								<div class="title">
									<span class="m-left-xs">PM</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-info">
							<div class="panel-body">
								<div class="value"><span id="Relokasi">0</span></div>
								<div class="title">
									<span class="m-left-xs">Relokasi</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-warning">
							<div class="panel-body">
								<div class="value"><span id="SiteSurvey">0</span></div>
								<div class="title">
									<span class="m-left-xs">Site Survey</span>
								</div>
							</div>
						</div>
						<div class="panel panel-default panel-stat1 bg-success">
							<div class="panel-body">
								<div class="value"><span id="SoftwareUpgrade">0</span></div>
								<div class="title">
									<span class="m-left-xs">Software Upgrade</span>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
	
            <div class="row">
                <div class="col-md-6">
					<div class="panel panel-info">
                        <div class="panel-heading">
                            <b>Top 10 Penyelesaian Task</b>
                        </div>
						
						<div class="panel-body no-padding">
                            <div id="grafik_bar_task" class="graph" style="height:380px"></div>
                        </div>
					</div>
				</div>
				
                <div class="col-md-6">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <b>Top 10 Work Progress Berdasarkan Provinsi</b>
                        </div>
						
						<div class="panel-body no-padding">
							<div style="height:380px">
								<table class="table table-striped">
									<thead>
										<tr>
											<th>Provinsi</th>
											<th>Progress</th>
											<th></th>
											<th>Total Site</th>
										</tr>
									</thead>
									<tbody id="table_work_progress"></tbody>
								</table>
							</div>
                        </div>
                    </div>
                    <!-- /panel -->
                </div>
            </div>
			
			<!--<div class="row">
                <div class="col-md-12">
					<div class="panel panel-info">
                        <div class="panel-heading">
                            <b>Top 10 Penyelesaian Task</b>
                        </div>
						
						<div class="panel-body no-padding">
                            <div id="grafik_line" class="graph" style="height:300px"></div>
                        </div>
					</div>
				</div>
            </div>-->
			
        </div>
    </form>

    <!-- Jquery -->
    <script src="js/jquery-1.10.2.min.js"></script>
    <!-- Bootstrap -->
    <script src="bootstrap/js/bootstrap.js"></script>
    <!-- Flot -->
    <script src='js/jquery.flot.min.js'></script>
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
    <!-- Endless -->
    <script src="js/endless/endless.js"></script>
    <script src="owl.carousel/owl.carousel.min.js"></script>
	
	<!--HIGHCHART-->
	<script type="text/javascript" src="script/highchart/highchart.js"></script>
	<script type="text/javascript" src="script/highchart/highchart-more.js"></script>
	<script type="text/javascript" src="script/dashowner.js"></script>
	
	<script>
		$(document).ready(function() {
			$("#news-slider").owlCarousel({
				items : 5,
				itemsDesktop : [1199,2],
				itemsMobile : [400,2],
				pagination :true,
				autoPlay : true
			});
		});
	</script>
</body>
</html>
