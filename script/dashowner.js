function gup( name, url ) {
    if (!url) url = location.href;
    name = name.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
    var regexS = "[\\?&]"+name+"=([^&#]*)";
    var regex = new RegExp( regexS );
    var results = regex.exec( url );
    return results == null ? null : results[1];
}
var id_project = gup('id_project', location.search);

//grafik_bar_task
var grafik_bar_task = Highcharts.chart('grafik_bar_task', {
	chart: {
		type: 'column'
	},
	title: {
		text: ''
	},
	xAxis: {
		type: 'category',
		labels: {
            style: {
                fontSize: '9px',
            }
        }
	},
		
	yAxis: {
		min: 0,
		title: {
			text: ''
		},
	},
	tooltip: {
		headerFormat: '<span style="color : {point.color}"><center><b>{series.name}</b></center>',
		pointFormat: 'Total : {point.y} Task</span>',
		useHTML: true,
		crosshairs: false,

	},
	plotOptions: {
		column: {
			colors : '{point.color}',
			dataLabels: {
				enabled: true,
				format: '<b>{point.y}</b>'
			}
			
        },
		series: {
            stacking: 'normal'
        }
	},
	legend: {
		enabled: true,
		layout: 'vertical',
		align: 'right',
		verticalAlign: 'top',
		x: -10,
		y: 10,
		floating: true,
		borderWidth: 0,
		backgroundColor: 'transparent',
		shadow: false,
		colors : '{point.color}',
	},
	credits:{
		enabled : false
	},
	series: []
});

//LOAD DATA TOTAL TICKET
function JsonTotalTicket(ProjectID){
	// alert(ProjectID);
	// return fetch('script/TotalTicket2.json')
	// return fetch('http://182.16.164.170:7020/ws_dashboardVsat_PROD/Service1.svc/Total_Ticket2/SCM201800010001')
    return fetch('http://182.16.164.170:7020/ws_dashboardVsat_PROD/Service1.svc/Total_Ticket2/'+ProjectID)
	.then((response) => response.json())
	.then((responseJson) => {

		let str = JSON.stringify(responseJson);
		let obj = JSON.parse(str);
		
		if (obj.Result == "True") {
			
			var data = obj.Raw[0];
			var raw = obj.Raw;
			var html = [];
			// var colors = ["bg-info","bg-success","bg-warning","bg-danger","bg-info","bg-success","bg-warning","bg-danger","bg-info","bg-success","bg-warning","bg-danger","bg-info","bg-success","bg-warning","bg-danger","bg-info","bg-success","bg-warning","bg-danger","bg-info","bg-success","bg-warning","bg-danger"];
			
			// console.log(raw);
			for(var i=0; i < raw.length; i++){
				if(raw[i].Ticket == "BBD"){
					$("#BBD").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "CM"){
					$("#CM").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "DISMANTLE"){
					$("#Dismantle").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "Installation"){
					$("#Installation").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "MIGRASI"){
					$("#Migrasi").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "OBSTACLE"){
					$("#Obstacle").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "PM"){
					$("#PM").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "RELOKASI"){
					$("#Relokasi").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "SiteSurvey"){
					$("#SiteSurvey").html(raw[i].Value);
				}
				else if(raw[i].Ticket == "SoftwareUpgrade"){
					$("#SoftwareUpgrade").html(raw[i].Value);
				}
				else{
					$("#Unknown").html(raw[i].Value);
				}
				
			}
			
			/* // html += '<div id="news-slider" class="owl-carousel">';
			for(var i=0; i < raw.length; i++){
				html += "<div class='panel panel-default panel-stat1 "+colors[i]+"'>"+
					"<div class='panel-body'>"+
						"<div class='value'>"+raw[i].Value+"</div>"+
						"<div class='title'>"+
							"<span class='m-left-xs'>"+raw[i].Ticket+"</span>"+
						"</div>"+
					"</div>"+
				"</div>";
			}
			// html += '</div>';
			// $("#slider").html(html); 
			// console.log(html); */
		}
	})
	.catch((error) => {
		console.error(error);
	});
}

//LOAD DATA CHART BAR
function JsonBarTask(ProjectID) {
	if (grafik_bar_task) {
		
		// return fetch('script/jsonBar.json')
	    // return fetch('http://182.16.164.170:7020/ws_dashboardVsat_PROD/Service1.svc/JsonBar/SCM201800010001')
	    return fetch('http://182.16.164.170:7020/ws_dashboardVsat_PROD/Service1.svc/JsonBar/'+ProjectID)
		.then((response) => response.json())
		.then((responseJson) => {

			let str = JSON.stringify(responseJson);
			let obj = JSON.parse(str);
			// console.log(obj.Raw);
			
			if (obj.Result == "True") {
				var data = obj.Raw;
				var colors = ["#00a0dc","#8d6cab","#dd5143","#e68523","#57bfc1","#edb220","#dc4b89","#69a62a","#046293","#66418c"];
				var isi2 = [];
				var kategori2 = [];

				// console.log(grafik_bar_task.series.length);
				for(var i = grafik_bar_task.series.length -1; i > -1; i--) {
					grafik_bar_task.series[i].remove();
				}

				for(var i=0; i < data.length; i++){
					var NamaTek = data[i].NamaTeknisi;
					var NamaTeknisi = NamaTek.substring(0, 8);
					var Jumlah = parseInt( data[i].Jumlah );

					grafik_bar_task.addSeries({
						name: NamaTek,
						color : colors[i],
						data: [{
							name: NamaTeknisi,
							color : colors[i],
							y: Jumlah
						}]
					});
				}
				grafik_bar_task.redraw();
			}
		})
		.catch((error) => {
			console.error(error);
		});
	} 
} 


function JsonWorkProgress(ProjectID){
	// return fetch('script/DataTable.json')
    return fetch('http://182.16.164.170:7020/ws_dashboardVsat_PROD/Service1.svc/datatable/'+ProjectID)
	.then((response) => response.json())
	.then((responseJson) => {

		let str = JSON.stringify(responseJson);
		let obj = JSON.parse(str);
		
		if (obj.Result == "True") {
			// console.log(obj.Raw);
			
			var data = obj.Raw;
			var colors = ["progress-bar-info","progress-bar-success","progress-bar-warning","progress-bar-danger","progress-bar-info","progress-bar-success","progress-bar-warning","progress-bar-danger","progress-bar-info","progress-bar-success","progress-bar-warning","progress-bar-danger"];
			var html = [];
			var text = "";

			for(var i=0; i < data.length; i++){
				text += "<tr>"+
				"<td>"+data[i].PROVINSI+"</td>"+
				"<td>"+
					"<div class='progress progress-striped active' style='height: 8px; margin: 5px 0 0 0;'>"+
						"<div class='progress-bar "+colors[i]+"' style='width: "+data[i].progress+"%'>"+
							"<span class='sr-only'>"+data[i].progress+" % Complete</span>"+
						"</div>"+
					"</div>"+
				"</td>"+
				"<td>"+data[i].progress+"</td>"+
				"<td><span class='badge badge-info'>"+data[i].totalsite+" Lokasi</span></td>"+
				"</tr>";
			} 
			document.getElementById("table_work_progress").innerHTML = text;
		}
	})
	.catch((error) => {
		console.error(error);
	});
}

function JsonSelectProject(){
	// return fetch('script/jsonProject.json')
    return fetch('http://182.16.164.170:7020/ws_dashboardVsat_PROD/Service1.svc/jsonProject')
	.then((response) => response.json())
	.then((responseJson) => {

		let str = JSON.stringify(responseJson);
		let obj = JSON.parse(str);
		
		if (obj.Result == "True") {
			var data = obj.Raw;
			var html = [];
			var no = 1;
			
			// console.log(document.location.origins+""+document.location.pathname);
			
			// html += "<option value='0' selected>-- Select Project --</option>";
			for(var i=0; i < data.length; i++){
				html += "<li><a href='"+ document.location.origin+""+document.location.pathname + "?page=dash&id_project="+data[i].idproject+"'>"+no+". "+data[i].ProjectName+"</a></li>";
				no++;
				
			}
			$("#SelectProject").html(html);

		}
	})
	.catch((error) => {
		console.error(error);
	});
}

// INTERVAL LOAD DATA CHART
$( document ).ready(function() {
	JsonSelectProject();
	// jsonLine();
	
	return fetch('http://182.16.164.170:7020/ws_dashboardVsat_PROD/Service1.svc/jsonProject')
	.then((response) => response.json())
	.then((responseJson) => {

		let str = JSON.stringify(responseJson);
		let obj = JSON.parse(str);
		
		if (obj.Result == "True") {
			var data = obj.Raw;
			// alert(id_project);
			
			//jika idproject null, set value data pertama dari ws
			if(id_project == null){
				JsonTotalTicket( data[0].idproject );
				JsonBarTask( data[0].idproject );
				JsonWorkProgress( data[0].idproject );
				
				setInterval(function () {
					JsonTotalTicket( data[0].idproject );
					JsonBarTask( data[0].idproject );
					JsonWorkProgress( data[0].idproject );
				}, 10000); //End Interval
				
			}else{
				JsonTotalTicket( id_project );
				JsonBarTask( id_project );
				JsonWorkProgress( id_project );
				
				setInterval(function () {
					JsonTotalTicket( id_project );
					JsonBarTask( id_project );
					JsonWorkProgress( id_project );
				}, 10000); //End Interval
			}
			
		}
	})
	.catch((error) => {
		console.error(error);
	}); 
	
	// JsonTotalTicket(123123);
	// JsonBarTask();
	// JsonWorkProgress();
	// JsonSelectProject();
});


/* setInterval(function () {
	JsonTotalTicket();
	JsonBarTask();
	JsonWorkProgress();
	JsonSelectProject();
}, 10000); //End Interval */

