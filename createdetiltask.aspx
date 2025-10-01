<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="createdetiltask.aspx.vb" Inherits="createdetiltask" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <%--rizal--%>
    <script>
        function UserCustomerConfirmation() {
            if (confirm("what do you want to process?"))
                return true;
            else
                return false;
        }
    </script>
    <script>
        function get_filename(obj) {
            //var file = obj.value;
            var file = obj.value.split("\\");
            var fileName = file[file.length - 1];
            var filextension = fileName.substring(fileName.lastIndexOf(".") + 1);
            //alert(filextension);
            if (filextension == "word" || filextension == "xls" || filextension == "xlsx" || filextension == "txt" || filextension == "docx" || filextension == "pdf") {
                alert("File Not Allow")
                //document.getElementById('MainContent_id_attchment').value = "1";
                document.getElementById('FileUpload').value = "";
                return false;
            }
            else {
                GetFileSize()
                //alert("Success");
                document.getElementById('MainContent_id_attchment').value = "0";
                document.getElementById('FileUpload').value = fileName;
                document.form.word.focus();
                return false;
            }
        }
    </script>
    <%--<script language="javascript" type="text/javascript">
        function AddMoreImages() {
            if (!document.getElementById && !document.createElement)
                return false;
            var fileUploadarea = document.getElementById("fileUploadarea");
            if (!fileUploadarea)
                return false;
            var newLine = document.createElement("br");
            fileUploadarea.appendChild(newLine);
            var newFile = document.createElement("input");
            newFile.type = "file";
            newFile.setAttribute("class", "fileUpload");

            if (!AddMoreImages.lastAssignedId)
                AddMoreImages.lastAssignedId = 100;
            newFile.setAttribute("id", "FileUpload" + AddMoreImages.lastAssignedId);
            newFile.setAttribute("name", "FileUpload" + AddMoreImages.lastAssignedId);
            var div = document.createElement("div");
            div.appendChild(newFile);
            div.setAttribute("id", "div" + AddMoreImages.lastAssignedId);
            fileUploadarea.appendChild(div);
            AddMoreImages.lastAssignedId++;

        }

    </script>--%>
    <script>
        $(function () {

            $('#popularMovie').on('jcarousel:create', function () {
                var width = $('#popularMovie').innerWidth();

                $('#popularMovie').jcarousel('items').css('width', width + 'px');
            })
            .jcarousel({
                wrap: 'circular'
            });

            $('#newGame').on('jcarousel:create', function () {
                var width = $('#newGame').innerWidth();

                $('#newGame').jcarousel('items').css('width', width + 'px');
            })
            .jcarousel({
                wrap: 'circular'
            });

            $('.jcarousel-control-prev')
            .on('jcarouselcontrol:active', function () {
                $(this).removeClass('inactive');
            })
            .on('jcarouselcontrol:inactive', function () {
                $(this).addClass('inactive');
            })
            .jcarouselControl({
                target: '-=1'
            });

            $('.jcarousel-control-next')
            .on('jcarouselcontrol:active', function () {
                $(this).removeClass('inactive');
            })
            .on('jcarouselcontrol:inactive', function () {
                $(this).addClass('inactive');
            })
            .jcarouselControl({
                target: '+=1'
            });

            $('.movie-jcarousel').resize(function () {
                var width = $('.movie-jcarousel').innerWidth();

                if (Modernizr.mq('(min-width: 980px)')) {
                    width = width / 4;
                }
                else if (Modernizr.mq('(min-width: 768px)') && Modernizr.mq('(max-width: 979px)')) {
                    width = width / 3;
                }
                else if (Modernizr.mq('(min-width: 351px)') && Modernizr.mq('(max-width: 767px)')) {
                    width = width / 2;
                }

                $('#popularMovie').jcarousel('items').css('width', width + 'px');
                $('#newGame').jcarousel('items').css('width', width + 'px');
            });
        });
	</script>
    <%--rizal--%> <%--rizal--%>

    <script>
        function get_filename(obj) {
            //var file = obj.value;

            var file = obj.value.split("\\");
            var fileName = file[file.length - 1];
            var filextension = fileName.substring(fileName.lastIndexOf(".") + 1);
            //alert(filextension);
            if (filextension == "word" || filextension == "xls" || filextension == "xlsx" || filextension == "txt" || filextension == "docx" || filextension == "pdf") {
                alert("File Not Allow")
                //document.getElementById('MainContent_id_attchment').value = "1";
                document.getElementById('FileUpload').value = "";
                return false;
            }
            else {
                GetFileSize()
                //alert("Success");
                document.getElementById('MainContent_id_attchment').value = "0";
                document.getElementById('FileUpload').value = fileName;
                document.form.word.focus();
                return false;
            }

        }
    </script>
    <%-- <script language="javascript" type="text/javascript">
        function AddMoreImages() {
            if (!document.getElementById && !document.createElement)
                return false;
            var fileUploadarea = document.getElementById("fileUploadarea");
            if (!fileUploadarea)
                return false;
            var newLine = document.createElement("br");
            fileUploadarea.appendChild(newLine);
            var newFile = document.createElement("input");
            newFile.type = "file";
            newFile.setAttribute("class", "fileUpload");

            if (!AddMoreImages.lastAssignedId)
                AddMoreImages.lastAssignedId = 100;
            newFile.setAttribute("id", "FileUpload" + AddMoreImages.lastAssignedId);
            newFile.setAttribute("name", "FileUpload" + AddMoreImages.lastAssignedId);
            var div = document.createElement("div");
            div.appendChild(newFile);
            div.setAttribute("id", "div" + AddMoreImages.lastAssignedId);
            fileUploadarea.appendChild(div);
            AddMoreImages.lastAssignedId++;

        }

    </script>--%>
    <script>
        $(function () {

            $('#popularMovie').on('jcarousel:create', function () {
                var width = $('#popularMovie').innerWidth();

                $('#popularMovie').jcarousel('items').css('width', width + 'px');
            })
            .jcarousel({
                wrap: 'circular'
            });

            $('#newGame').on('jcarousel:create', function () {
                var width = $('#newGame').innerWidth();

                $('#newGame').jcarousel('items').css('width', width + 'px');
            })
            .jcarousel({
                wrap: 'circular'
            });

            $('.jcarousel-control-prev')
            .on('jcarouselcontrol:active', function () {
                $(this).removeClass('inactive');
            })
            .on('jcarouselcontrol:inactive', function () {
                $(this).addClass('inactive');
            })
            .jcarouselControl({
                target: '-=1'
            });

            $('.jcarousel-control-next')
            .on('jcarouselcontrol:active', function () {
                $(this).removeClass('inactive');
            })
            .on('jcarouselcontrol:inactive', function () {
                $(this).addClass('inactive');
            })
            .jcarouselControl({
                target: '+=1'
            });

            $('.movie-jcarousel').resize(function () {
                var width = $('.movie-jcarousel').innerWidth();

                if (Modernizr.mq('(min-width: 980px)')) {
                    width = width / 4;
                }
                else if (Modernizr.mq('(min-width: 768px)') && Modernizr.mq('(max-width: 979px)')) {
                    width = width / 3;
                }
                else if (Modernizr.mq('(min-width: 351px)') && Modernizr.mq('(max-width: 767px)')) {
                    width = width / 2;
                }

                $('#popularMovie').jcarousel('items').css('width', width + 'px');
                $('#newGame').jcarousel('items').css('width', width + 'px');
            });
        });
	</script>
    <%--rizal--%>
    <%--<div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Detil Task</li>
            <span class="line"></span>
        </ul>
    </div>--%>
    <h4 class="headline no-padding">
        Detail Task
        <span class="line"></span>
    </h4>
	
    <div class="padding-md">

        <div class="row">
            <div class="panel panel-default" id="groupdatalokasi" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#Lokasi">
                            <b>Data Lokasi</b>
                        </a>
                    </h4>
                </div>
                <div id="Lokasi" class="panel-collapse collapse" style="height: 0px;">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="panel-body">
                                <label>Nama Remote</label>
                                <input type="text" id="txtnamaremote" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtnamaremote" placeholder="Nama Remote" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Alamat</label>
                                <input type="text" id="txtalamat" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtalamat" placeholder="Alamat" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Provinsi</label>
                                <input type="text" id="txtprovinsi" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtprovinsi" placeholder="Provinsi" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Kota / Kabupaten</label>
                                <input type="text" id="txtkota" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtkota" placeholder="Kota / Kabupaten" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Kanwil</label>
                                <input type="text" id="txtkanwil" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtkanwil" placeholder="Kanwil" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Kanca Induk / Area</label>
                                <input type="text" id="txtkancainduk" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtkancainduk" placeholder="Kanca Induk / Area" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Nama PIC</label>
                                <input type="text" id="txtPIC" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtPIC" placeholder="Nama PIC" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Phone PIC</label>
                                <input type="text" id="txtphonepic" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtphonepic" placeholder="Phone PIC" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="panel-body">
                                <br />
                                <label>ID Jarkom</label>
                                <input type="text" id="txtidjarkom" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtidjarkom" placeholder="ID Jarkom" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>ID Satelit</label>
                                <input type="text" id="txtsatelit" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtsatelit" placeholder="ID Satelit" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <label>Hub</label>
                                <dx:ASPxComboBox ID="cbhub" CssClass="form-control input-sm bounceIn animation-delay2" ValidationSettings-RequiredField-IsRequired="true" DataSourceID="dshub" TextField="Hub" ValueField="Hub" runat="server" ValueType="System.String" Width="100%">
                                </dx:ASPxComboBox>
                                <br />
                                <label>Latitude</label>
                                <input type="text" id="txtlatitude" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtlatitude" placeholder="Latitude" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Longitude</label>
                                <input type="text" id="txtlongitude" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtlongitude" placeholder="Longitude" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Alamat Sekarang</label>
                                <input type="text" id="txtalamatsekarang" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtalamatsekarang" placeholder="Alamat Sekarang" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Catatan</label>
                                <%--<asp:TextBox ID="txtcatatanlokasi" placeholder="Catatan" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <textarea class="form-control input-sm bounceIn animation-delay2" rows="4" id="txtcatatanlokasi" placeholder="Catatan" runat="server" required="required"></textarea>
                                <br />
                                <div class="pull-right">
                                    <asp:Button ID="btnsavelokasi" runat="server" CssClass="btn btn-info" Text="Simpan" />
                                </div>
                                <asp:SqlDataSource ID="dshub" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="panel panel-default" id="groupgeneralinfo" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#Generalinfo" runat="server">
                            <b>General Info </b>
                        </a>
                    </h4>
                </div>
                <div id="Generalinfo" class="panel-collapse collapse" style="height: 0px;">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="panel-body">
                                <label>No. Task</label>
                                <asp:TextBox ReadOnly="true" ID="txtnotask" placeholder="Nomor Task" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>VID</label>
                                <asp:TextBox ID="txtvid" ReadOnly="true" placeholder="VID" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>SID</label>
                                <asp:TextBox ReadOnly="false" ID="txtSID" placeholder="SID" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>IP LAN</label>
                                <input type="text"  id="txtiplan" class="form-control input-sm bounceIn animation-delay2" runat="server" required="required" />
                                <br />
                                <label>ID ATM</label>
                                <input type="text" id="txtidatm" placeholder="ID ATM" class="form-control input-sm bounceIn animation-delay2" runat="server" required="required" />
                                <br />
                                <label>Laporan Pengaduan</label>
                                <asp:TextBox ID="txtlaporanpengaduan" placeholder="Laporan Pengaduan" ReadOnly="true" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>Status Check Koordinator</label>
                                <asp:TextBox ID="txtstatuskoordinator" placeholder="Status Perbaikan" ReadOnly="true" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="panel-body">
                                <label>Order</label>
                                <asp:TextBox ID="txtordertask" ReadOnly="true" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />

                                <%--<asp:TextBox ID="TextBox58" placeholder="Status Perbaikan" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <label>Tanggal Berangkat</label>
                                <div class="input-group">
									<dx:ASPxDateEdit ID="txttglberangkat" NullText="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" CssClass="form-control" runat="server"></dx:ASPxDateEdit>
                                    <%--<input type="date" id="txttglberangkat" runat="server" class="form-control" />
                                    <dx:ASPxDateEdit ID="txttglberangkat" runat="server" CssClass="datepicker form-control">
                                    </dx:ASPxDateEdit>--%>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                                <br />
                                <label>Tanggal Selesai</label>
                                <div class="input-group">
									<dx:ASPxDateEdit ID="txttglselesai" NullText="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" CssClass="form-control" runat="server"></dx:ASPxDateEdit>
                                    <%--<input type="date" id="txttglselesai" runat="server" class="form-control" />--%>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                                <br />
                                <label>Tanggal Pulang</label>
                                <div class="input-group">
									<dx:ASPxDateEdit ID="txttglpulang" NullText="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" CssClass="form-control" runat="server"></dx:ASPxDateEdit>
                                    <%--<input type="date" id="txttglpulang" runat="server" class="form-control" />--%>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                                <br />
                                <label>Tanggal Status Perbaikan</label>
                                <div class="input-group">
									<dx:ASPxDateEdit ID="txttglpengaduan" NullText="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" CssClass="form-control" runat="server"></dx:ASPxDateEdit>
                                    <%--<input type="date" id="txttglpengaduan" runat="server" class="form-control" />--%>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                                <br />
                                <label>Catatan Koordinator</label>
                                <asp:TextBox ID="txtcatatankoordinator" placeholder="Catatan Koordinator" ReadOnly="true" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <div class="pull-right">
                                    <asp:Button ID="btngeneralinfo" runat="server" CssClass="btn btn-info" Text="Simpan" />
                                </div>
                            </div>
                        </div>
                        <asp:SqlDataSource ID="dsstatusperbaikan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msStatus where FlagUser ='Teknisi'"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsstatusdokumentasi" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msStatus where FlagUser ='NonTeknisi'"></asp:SqlDataSource>
                    </div>
                </div>
                <!-- /panel -->

            </div>
        </div>
        
        <div class="row">
            <div class="panel panel-default" id="groupdatateknis" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#other">
                            <b>Data Teknis</b>
                        </a>
                    </h4>
                </div>
                <div id="other" class="panel-collapse collapse" style="height: 0px;">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="panel-body">
                                <label>Hardware Rusak</label>
                                <input type="text" id="txtfailHW" class="form-control" runat="server" required="required" />
                                <br />
                                <label>SQF</label>
                                <input type="text" id="txtSQF" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtSQF" placeholder="SQF" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Initial Esno</label>
                                <input type="text" id="txtinitialesno" class="form-control" runat="server" required="required" />
                                <%-- <asp:TextBox ID="txtinitialesno" placeholder="Initial Esno" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>CPI</label>
                                <input type="text" id="txtCPI" class="form-control" runat="server" required="required" />
                                <label>C/N</label>
                                <input type="text" id="txtcarriertonotice" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtcarriertonotice" placeholder="Carrier To Notice" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>ASI</label>
                                <input type="text" id="txthasilxpoll" class="form-control" runat="server" required="required" />
                                <%-- <asp:TextBox ID="txthasilxpoll" placeholder="Hasil XPOLL" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <%--<asp:TextBox ID="txtCPI" placeholder="CPI" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Operator Satelit</label>
                                <input type="text" id="txtoperatorsatelit" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtoperatorsatelit" placeholder="Operator Satelit" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Operator Helpdesk</label>
                                <input type="text" id="txtoperatorhelpdesk" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtoperatorhelpdesk" placeholder="Operator Helpdesk" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Out PLN</label>
                                <input type="text" id="txtoutpln" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtoutpln" placeholder="Out PLN" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Aktifitas Solusi</label>
                                <textarea class="form-control input-sm bounceIn animation-delay2" cols="50" style="overflow: scroll" rows="4" id="txtaktifitassolusi" placeholder="Catatan" runat="server" required="required"></textarea>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="panel-body">
                                <label>OUT UPS</label>
                                <input type="text" id="txtoutups" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtoutups" placeholder="OUT UPS" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>UPS For Backup</label>
                                <dx:ASPxComboBox ID="cbupsforbackup" CssClass="form-control input-sm bounceIn animation-delay2" runat="server" ValueType="System.String" Width="100%">
                                    <Items>
                                        <dx:ListEditItem Value="YES" Text="YES" />
                                        <dx:ListEditItem Value="NO" Text="NO" />
                                        <dx:ListEditItem Value="Tanpa UPS" Text="Tanpa UPS" />
                                    </Items>
                                </dx:ASPxComboBox>
                                <br />
                                <label>Suhu Ruangan</label>
                                <input type="text" id="txtsuhuruangan" class="form-control" runat="server" required="required" />
                                <br />
                                <label>Type Mounting</label>
                                <input type="text" id="txttypemounting" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txttypemounting" placeholder="Type Mounting" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Panjang Kabel</label>
                                <input type="text" id="txtpanjangkabel" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtpanjangkabel" placeholder="Panjang Kabel" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Letak Antena</label>
                                <input type="text" id="txtletakantena" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtletakantena" placeholder="Letak Antena" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Letak Modem</label>
                                <input type="text" id="txtletakmodem" class="form-control" runat="server" required="required" />
                                <%--<asp:TextBox ID="txtletakmodem" placeholder="Letak Modem" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Letak Antena Ke Satelit</label>
                                <input type="text" id="txtkondisibangunan" class="form-control" runat="server" required="required" />
                                <%-- <asp:TextBox ID="txtkondisibangunan" placeholder="Kondisi Bangunan" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>--%>
                                <br />
                                <label>Analisa Problem</label>
                                <textarea class="form-control input-sm bounceIn animation-delay2" rows="4" id="txtanalisaproblem" placeholder="Catatan" runat="server" required="required"></textarea>
                                <br />
                                <div class="pull-right">
                                    <asp:Button ID="btnsaveteknis" runat="server" CssClass="btn btn-info" Text="Simpan" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="panel panel-default" id="groupinstallasi" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#installasi">
                            <b>Data Installasi</b>
                        </a>
                    </h4>
                </div>
                <div id="installasi" class="panel-collapse collapse" style="height: 0px;">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="panel-body">
                                <label>Diameter Antena</label>
                                <input type="text" id="txtdiameterantena" class="form-control" runat="server" required="required" />
                                <br />
                                <label>Arah Sudut Antena :</label><br />

                                <label>Polarisasi</label>
                                <input type="text" id="txtpolarisasi" class="form-control" runat="server" required="required" />

                                <label>Elevasi</label>
                                <input type="text" id="txtelevasi" class="form-control" runat="server" required="required" />

                                <label>Azimuth</label>
                                <input type="text" id="txtazimuth" class="form-control" runat="server" required="required" />
                                <br />
                                <label>Source Listrik</label>
                                <dx:ASPxComboBox ID="cbsourcelistrik" CssClass="form-control input-sm bounceIn animation-delay2" runat="server" ValueType="System.String" Width="100%">
                                    <Items>
                                        <dx:ListEditItem Value="PLN" Text="PLN" />
                                        <dx:ListEditItem Value="Genset" Text="Genset" />
                                    </Items>
                                </dx:ASPxComboBox>
                                <br />
                                <label>Apakah sumber listrik modem menggunakan kabel extension / kabel roll?</label>
                                <dx:ASPxComboBox ID="cbkabelroll" CssClass="form-control input-sm bounceIn animation-delay2" runat="server" ValueType="System.String" Width="100%">
                                    <Items>
                                        <dx:ListEditItem Value="Ya" Text="Ya" />
                                        <dx:ListEditItem Value="Tidak" Text="Tidak" />
                                    </Items>
                                </dx:ASPxComboBox>
                                <br />
                                <label>Apakah Perangkat Indoor terhubung ke UPS ?</label>
                                <div class="col-md-6">
                                    <dx:ASPxComboBox ID="cbupsindoor" CssClass="form-control input-sm bounceIn animation-delay2" runat="server" ValueType="System.String" Width="100%">
                                        <Items>
                                            <dx:ListEditItem Value="Ya" Text="Ya" />
                                            <dx:ListEditItem Value="Tidak" Text="Tidak" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </div>
                                <div class="col-md-6">
                                    <input type="text" id="KVA" placeholder="KVA" class="form-control" runat="server" required="required" />
                                </div>
                                <br />
                                <br />
                                <br />
                                <label>Frequency Band /Modulation</label>
                                <dx:ASPxComboBox ID="cbfrequency" CssClass="form-control input-sm bounceIn animation-delay2" runat="server" ValueType="System.String" Width="100%">
                                    <Items>
                                        <dx:ListEditItem Value="C Band/BPSK" Text="C Band/BPSK" />
                                        <dx:ListEditItem Value="C Band/QPSK" Text="C Band/QPSK" />
                                        <dx:ListEditItem Value="C Band/8-PSK" Text="C Band/8-PSK" />
                                    </Items>
                                </dx:ASPxComboBox>
                                <br />
                                <label>VSAT Management IP Address</label>
                                <input type="text" id="txtvsatmanagementipaddress" placeholder="IP Management" class="form-control" runat="server" required="required" />

                                <br />
                                <label>Receive Symbole Rate</label>
                                <input type="text" id="txtreceivesimbolrate" class="form-control" runat="server" required="required" />
                                <br />
                                <div class="pull-left">
                                    <asp:Button ID="btnsimpaninstallasi" runat="server" CssClass="btn btn-info" Text="Simpan" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="panel-body">
                                <label>Pengukuran tegangan sumber listrik yang terhubung ke perangkat modem.</label>
                                <table class="table table-striped">
                                    <thead>
                                        <th>Tegangan
                                        </th>
                                        <th>PLN</th>
                                        <th>UPS</th>
                                        <th>Genset</th>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>PHASA - NETRAL
                                            </td>
                                            <td>
                                                <input type="text" id="txtphasanetralpln" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtphasanetralups" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtphasanetralgenset" class="form-control" runat="server" required="required" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>PHASA - GROUND
                                            </td>
                                            <td>
                                                <input type="text" id="txtphasagroundpln" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtphasagroundups" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtphasagroundgenset" class="form-control" runat="server" required="required" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>NETRAL - GROUND
                                            </td>
                                            <td>
                                                <input type="text" id="txtnetralgroundpln" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtnetralgroundups" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtnetralgroundgenset" class="form-control" runat="server" required="required" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <label>Satelite Longitude</label>
                                <input type="text" id="txtsatelitelongitude" class="form-control" runat="server" required="required" />
                                <br />
                                <label>LAN-1 IP Address</label>
                                <input type="text" id="txtlan1" placeholder="IP LAN" class="form-control" runat="server" required="required" />
                                <div style="padding-top:5px;"></div>
                                <input type="text" id="txtsubnetmask1" placeholder="Subnet mask" class="form-control" runat="server" required="required" />
                                <br />
                                <label>LAN-2 IP Address</label>
                                <input type="text" id="txtlan2" class="form-control" runat="server" required="required" />
                                <div style="padding-top:5px;"></div>
                                <input type="text" id="txtsubnetmask2" placeholder="Subnet mask" class="form-control" runat="server" required="required" />
                                <br />
                                <label>Hasil Test Ping</label>
                                <table class="table table-striped">
                                    <thead>
                                        <th>Alamat</th>
                                        <th>Success</th>
                                        <th>Loss</th>
                                        <th>Keterangan</th>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <input type="text" id="txtalamat1" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtsuccess1" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtloss1" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtket1" class="form-control" runat="server" required="required" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="text" id="txtalamat2" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtsuccess2" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtloss2" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtket2" class="form-control" runat="server" required="required" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <input type="text" id="txtalamat3" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtsuccess3" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtloss3" class="form-control" runat="server" required="required" />
                                            </td>
                                            <td>
                                                <input type="text" id="txtket3" class="form-control" runat="server" required="required" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="panel panel-default" id="groupsurvey" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqBasic" href="#survey">
                            <b>Data Survey</b>
                        </a>
                    </h4>
                </div>
                <div id="survey" class="panel-collapse collapse" style="height: 0px;">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <label>Alamat Pengiriman</label>
                            <input type="text" id="txtalamatpengiriman" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Tempat Penyimpanan</label>
                            <input type="text" id="txttempatpenyimpanan" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Nama PIC</label>
                            <input type="text" id="txtpicsurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Kontak PIC</label>
                            <input type="text" id="txtnohppicsurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Penempatan Grounding</label>
                            <input type="text" id="txtpenempatangrounding" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Ukuran Antena</label>
                            <input type="text" id="txtukuranantena" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Tempat Antena</label>
                            <input type="text" id="txttempatantena" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Kekuatan Roof</label>
                            <input type="text" id="txtroof" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Jenis Mounting Antena</label>
                            <input type="text" id="txtjenismountingantena" class="form-control" runat="server" required="required" />
                            <br />
                            <div class="pull-left">
                                <asp:Button ID="btnsurvey" runat="server" CssClass="btn btn-info" Text="Simpan" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Latitude</label>
                            <input type="text" id="txtlatitudesurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Longitude</label>
                            <input type="text" id="txtlongitudesurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Pengukuran Listrik Awal</label>
                            <input type="text" id="txtpengukuranlistrikawalsurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Sarana Pendukung AC Indoor</label>
                            <input type="text" id="txtacindoorsurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Sarana Pendukung UPS</label>
                            <input type="text" id="txtsaranapendukungUPS" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Panjang Kabel</label>
                            <input type="text" id="txtpanjangkabelsurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Type Kabel</label>
                            <dx:ASPxComboBox ID="cbtypekabelsurvey" CssClass="form-control input-sm bounceIn animation-delay2" TextField="Status" ValueField="ID" runat="server" ValueType="System.String" Width="100%">
                                <Items>
                                    <dx:ListEditItem Value="RG 6" Text="RG 6" />
                                    <dx:ListEditItem Value="RG 11" Text="RG 11" />
                                    <dx:ListEditItem Value="comscope" Text="comscope" />
                                </Items>
                            </dx:ASPxComboBox>
                            <br />
                            <label>Arah Antena</label>
                            <input type="text" id="txtarahantenasurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Status Hasil Survey</label>
                            <input type="text" id="txtstatussurvey" class="form-control" runat="server" required="required" />
                            <br />
                            <label>Keterangan</label>
                            <textarea class="form-control input-sm bounceIn animation-delay2" rows="4" id="txtketsurvey" placeholder="Keterangan" runat="server" required="required"></textarea>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="panel panel-default" id="groupdatabarangterpasang" runat="server">
                <div class="panel-body">

                    <div class="row">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Data Barang Terpasang</b>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <dx:ASPxGridView ID="grid_barang_on" runat="server" KeyFieldName="ID" DataSourceID="dsbarang_on" EnableTheming="true" Width="100%" Theme="MetropolisBlue">
                                <ClientSideEvents EndCallback="function(s,e){if (s.cpUpdated == true){delete s.cpUpdated;grid_barang_replace.Refresh();}}" />
								<Settings HorizontalScrollBarMode="Auto" ShowFooter="false" />
                                <SettingsBehavior ConfirmDelete="True" />
                                <SettingsPager>
                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                </SettingsPager>
                                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                <SettingsSearchPanel Visible="True" />
                                <SettingsEditing Mode="EditFormAndDisplayRow" />
                                <Columns>
                                    <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" HeaderStyle-HorizontalAlign="Center" ShowEditButton="True" ShowDeleteButton="true" ShowNewButtonInHeader="true" VisibleIndex="10">
                                        <CellStyle BackColor="#d6f1ff">
                                        </CellStyle>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Caption="ID" Width="50px" VisibleIndex="0">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="VID" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="Auto Increment" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Caption="VID" Width="200px" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataComboBoxColumn FieldName="NamaBarang" Width="200px" VisibleIndex="1" Caption="Nama Barang">
                                        <PropertiesComboBox DataSourceID="dsbarangpick" TextField="Barang"
                                            ValueField="IdBarang" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataTextColumn FieldName="Type" HeaderStyle-HorizontalAlign="Center" Caption="Type" Width="100px" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="SN" HeaderStyle-HorizontalAlign="Center" Caption="Serial Number" Width="200px" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="IPlan" HeaderStyle-HorizontalAlign="Center" Caption="IP Lan" Width="100px" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ESNMODEM" HeaderStyle-HorizontalAlign="Center" Caption="ESN Modem" Width="100px" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn FieldName="Status" Caption="Status" HeaderStyle-HorizontalAlign="Center" Width="100%" VisibleIndex="7">
                                        <Settings AutoFilterCondition="Contains"></Settings>
                                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                                            <Items>
                                                <dx:ListEditItem Text="Terpasang" Value="Terpasang" />
                                                <dx:ListEditItem Text="Rusak" Value="Rusak" />
                                            </Items>
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </div>
                        <br />

                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <b>Data Barang Replace</b>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <dx:ASPxGridView ID="grid_barang_replace" Settings-HorizontalScrollBarMode="Visible" runat="server" ClientInstanceName="grid_barang_replace" KeyFieldName="ID" DataSourceID="dsbarang_rep" Width="100%" AutoGenerateColumns="false" Theme="MetropolisBlue">
                                <Settings HorizontalScrollBarMode="Auto" ShowFooter="false" />
                                <SettingsBehavior ConfirmDelete="True" />
                                <SettingsPager>
                                    <PageSizeItemSettings Visible="true" Items="10, 15, 20" ShowAllItem="true" />
                                </SettingsPager>
                                <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
                                <SettingsSearchPanel Visible="True" />
                                <SettingsEditing Mode="EditFormAndDisplayRow" />
                                <Columns>
                                    <dx:GridViewCommandColumn CellStyle-BackColor="#d6f1ff" HeaderStyle-BackColor="#d6f1ff" ShowEditButton="True" ShowNewButtonInHeader="True" ShowDeleteButton="true" VisibleIndex="10">
                                        <CellStyle BackColor="#d6f1ff">
                                        </CellStyle>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="ID" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Caption="ID" Width="50px" VisibleIndex="0">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="VID" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="Auto Increment" PropertiesTextEdit-ReadOnlyStyle-BackColor="#c0c0c0" ReadOnly="true" Caption="VID" Width="200px" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn FieldName="NamaBarang" Width="200px" VisibleIndex="1" Caption="Nama Barang">
                                        <PropertiesComboBox DataSourceID="dsbarangpick" TextField="Barang"
                                            ValueField="IdBarang" EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataTextColumn FieldName="Type" HeaderStyle-HorizontalAlign="Center" Caption="Type" Width="100px" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="SN" HeaderStyle-HorizontalAlign="Center" Caption="Serial Number" Width="200px" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="IPlan" HeaderStyle-HorizontalAlign="Center" Caption="IP Lan" Width="100px" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ESNMODEM" HeaderStyle-HorizontalAlign="Center" Caption="ESN Modem" Width="100px" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataComboBoxColumn FieldName="Status" HeaderStyle-HorizontalAlign="Center" Caption="Status" Width="100%" VisibleIndex="7">
                                        <Settings AutoFilterCondition="Contains"></Settings>
                                        <PropertiesComboBox ValueType="System.String" IncrementalFilteringMode="Contains">
                                            <Items>
                                                <dx:ListEditItem Text="Terpasang" Value="Terpasang" />
                                                <dx:ListEditItem Text="Rusak" Value="Rusak" />
                                            </Items>
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataTextColumn FieldName="Keterangan" HeaderStyle-HorizontalAlign="Center" Caption="Keterangan Rusak" Width="200px" VisibleIndex="7">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </div>
                        <asp:SqlDataSource ID="dsbarang_rep" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsbarang_on" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsbarangpick" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msbarang"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msbarang order by IdBarang"></asp:SqlDataSource>
                    </div>

                </div>

            </div>
        </div>

        <%--rizal--%>
        <div class="row">
            <div class="panel panel-default" id="groupfoto" runat="server">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#FaqUpload" href="#upload">
                            <b>Upload Foto</b>
                        </a>
                    </h4>
                </div>
                <div id="upload" class="panel-collapse collapse" style="height: 0px;">
                    <div class="panel-body">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Judul Images</label>
                                <asp:TextBox ID="txtjudulimage" runat="server" CssClass="form-control"></asp:TextBox>
                                <br />
                                <label for="exampleInputEmail1">Keterangan Images</label>
                                <textarea maxlength="100" class="form-control input-sm bounceIn animation-delay2" rows="4" id="txtketgambar" placeholder="Keterangan" runat="server"></textarea>
                                <br />
                                <label for="exampleInputEmail1">Pilih Image</label>
                                <div id="fileUploadarea">
                                    <div class="upload-file">
                                        <label data-title="Select file" for="upload-demo">
                                            <asp:FileUpload ID="fuPuzzleImage" runat="server" CssClass="upload-demo" />
                                            <%--<asp:FileUpload ID="fuPuzzleImage" runat="server" CssClass="fileUpload" />--%>
                                            <span data-title="No file selected..."></span>
                                        </label>
                                        <br />
                                    </div>
                                </div>
                                <%--                                <div>

                                    <br />
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
                                </div>--%>
                                <%--<div class="upload-file">
                                    <label data-title="Select file" for="upload-demo">
                                        <asp:FileUpload ID="fl_task" runat="server" Visible="true" CssClass="upload-demo" onchange="get_filename(this);" Multiple="Multiple" />
                                        <span data-title="No file selected..."></span>
                                    </label>
                                </div>--%>
                                <br />
                                <div class="pull-right text-right">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-3">
                                                <button id="btn_upload" style="background-color: #F65058;" runat="server" visible="true" class="btn btn-danger" type="submit" onclick="if (!UserCustomerConfirmation()) return false;">
                                                    <%--<i class="fa fa-save"></i>&nbsp;--%>Upload Foto
                                                </button>
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--<div class="pull-right text-left">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-12">
                                                <input style="display: block; background-color: #F65058;" id="Button2" type="button" value="Tambah Gambar" class="btn btn-danger" onclick="AddMoreImages();" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="jcarousel-wrapper">
                                    <div class="jcarousel movie-jcarousel" id="popularMovie" data-jcarousel="true">

                                        <asp:Literal ID="ltr_image_room" runat="server"></asp:Literal>
                                    </div>
                                    <%--  <a href="#" class="jcarousel-control-prev" data-jcarouselcontrol="true">‹</a>
                                    <a href="#" class="jcarousel-control-next" data-jcarouselcontrol="true">›</a>--%>
                                </div>
                                <!-- /jcarousel-wrapper -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                            
                <%--rizal--%>
                <div id="groupstatusperbaikan" runat="server">
                    <div class="col-md-3">
                        <br />
                        <label>Status Pekerjaan</label>
                        <dx:ASPxComboBox ID="cbstatusperbaikan" CssClass="form-control input-sm bounceIn animation-delay2" DataSourceID="dsstatusperbaikan" TextField="Status" ValueField="ID" runat="server" ValueType="System.String" Width="100%">
                        </dx:ASPxComboBox>
                    </div>
                    <div class="col-md-3">
                        <div class="">
                            <br />
                            <br />
                            <asp:Button ID="btnselesai" runat="server" CssClass="btn btn-info" Text="Selesai" />
                        </div>
                    </div>
                </div>
                <div id="groupstatusadmin" runat="server">
                    <div class="col-md-3">
                        <br />
                        <label>Status Dokumentasi</label>
                        <dx:ASPxComboBox ID="cbstatusdokumentasi" CssClass="form-control input-sm bounceIn animation-delay2" DataSourceID="dsstatusdokumentasi" TextField="Status" ValueField="ID" runat="server" ValueType="System.String" Width="100%">
                            <%--<Items>
                                <dx:ListEditItem Value="open" Text="open" />
                                <dx:ListEditItem Value="on progres" Text="on progres" />
                                <dx:ListEditItem Value="finish" Text="finish" />
                                <dx:ListEditItem Value="verified provider" Text="verified provider" />
                                <dx:ListEditItem Value="verified BRI" Text="verified BRI" />
                                <dx:ListEditItem Value="Low SQF" Text="Low SQF" />
                            </Items>--%>
                        </dx:ASPxComboBox>
                    </div>
                    <div class="col-md-3">
                        <div class="">
                            <br />
                            <br />
                            <asp:Button ID="btnstatusdokumentasi" runat="server" CssClass="btn btn-info" Text="Update"/>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnselesai" />
                <asp:AsyncPostBackTrigger ControlID="btnstatusdokumentasi" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

