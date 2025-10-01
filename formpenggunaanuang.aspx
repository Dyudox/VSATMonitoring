
<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="formpenggunaanuang.aspx.vb" Inherits="formpenggunaanuang" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <%--rizal--%>
    <script>		
        function confirm_click() {
            if (confirm('Are you sure?'))
                return true;
            else
                return false;
        }

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

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Form Penggunaan Uang</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row">
            
                    <div class="col-md-12">
                        <div class="panel-body">
                            <div class="col-md-6">
                                <label>No. Task</label>
                                <asp:TextBox ReadOnly="true" ID="txtnotask" placeholder="Nomor Task" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>VID</label>
                                <dx:ASPxComboBox ID="cb_vid" CssClass="form-control input-sm bounceIn animation-delay2" DataSourceID="sql_ddVID" 
                                ValueField="vid" runat="server" ValueType="System.String" Width="100%" AutoPostBack="true"
                                IncrementalFilteringMode="Contains" TextFormatString="{0} - {1}">
                                   <Columns>
                                        <dx:ListBoxColumn FieldName="vid" Caption="VID"></dx:ListBoxColumn>
                                        <dx:ListBoxColumn FieldName="NAMAREMOTE" Caption="Nama Remote"></dx:ListBoxColumn>
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sql_ddVID" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>"></asp:SqlDataSource>
                                <asp:TextBox ID="txtvid" ReadOnly="true" placeholder="VID" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>Pengeluaran</label>
                                <dx:ASPxComboBox ID="cbjenispengeluaran" TextField="JenisBiaya" ValueField="JenisBiaya" DataSourceID="dsjenisbiaya" Width="100%" CssClass="form-control" runat="server" ValueType="System.String">
                          
                                </dx:ASPxComboBox>
                                <br />
                                <label>Tanggal Kwitansi</label>
                                <div class="input-group">
                                    <dx:ASPxDateEdit ID="tglkwitansi" NullText="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" CssClass="form-control" runat="server"></dx:ASPxDateEdit>
                                    <%--<input type="date" id="tglkwitansi" runat="server" class=" form-control" />--%>
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                                <br />
                                <label>Nominal</label>
                                <asp:TextBox ID="txtnominal" placeholder="Nominal" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>Upload Bukti</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <br />

                            </div>
                            <div class="col-md-6">
                                <label>Nama Task</label>
                                <asp:TextBox ReadOnly="true" ID="txtnamatask" placeholder="Nama Task" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>Nama Remote</label>
                                <asp:TextBox ID="txtnamaremote" ReadOnly="true" placeholder="NAMA REMOTE" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>IP LAN</label>
                                <asp:TextBox ID="txtiplan" ReadOnly="true" placeholder="IP LAN" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>Lokasi</label>
                                <asp:TextBox ID="txtlokasi" ReadOnly="true" placeholder="Lokasi" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <label>Note</label>
                                <asp:TextBox ID="txtcatatantransaksi" placeholder="Note" runat="server" CssClass="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                                <br />
                                <div class="pull-right">
                                    <asp:Button ID="btnsimpan" class="btn btn-info" OnClientClick="return confirm_click();" runat="server" Text="Simpan" />
                                    <asp:Button ID="btnupdate" class="btn btn-info" OnClientClick="return confirm_click();" runat="server" Text="Update" />
                                    <%--<button id="btnsimpan" runat="server" class="btn btn-info">Simpan</button>--%>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
               

            <div class="col-md-12" id="tableisi" runat="server">
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
                <br />
                <table class="table table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Pengeluaran</th>
                            <th>Nominal</th>
                            <th>Tanggal</th>
                            <th>Note</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:Literal ID="ltrisi" runat="server"></asp:Literal>
                        <%-- <tr>
                                <td>BRINETCOM</td>
                                <td>Hotel</td>
                                <td>Rp. 800.000,-</td>
                                <td>../BuktiBayar/bonhotel.jpg</td>
                                <td>25-10-2018</td>
                                <td><a href="#" class="btn btn-success">Edit</a> &nbsp; &nbsp; <a href="#" class="btn btn-success">Delete</a></td>
                                <td><a href="#" class="btn btn-danger">Valid</a></td>
                            </tr>
                            <tr>
                                <td>BRINETCOM</td>
                                <td>Transport</td>
                                <td>Rp. 800.000,-</td>
                                <td>../BuktiBayar/bontransport.jpg</td>
                                <td>25-10-2018</td>
                                <td><a href="#" class="btn btn-success">Edit</a> &nbsp; &nbsp; <a href="#" class="btn btn-success">Delete</a></td>
                                <td><a href="#" class="btn btn-danger">Valid</a></td>
                            </tr>--%>
                    </tbody>
                </table>
                <br />
                <center>
                 <asp:Button ID="btnconfirm" class="btn btn-info" OnClientClick="return confirm_click();" runat="server" Text="Konfirmasi Penggunaan Uang" />
                <br />*Apabila sudah di konfirmasi, maka data tidak bisa dirubah dan di hapus
                </center>
            </div>
            <asp:SqlDataSource ID="dsstatusperbaikan" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select * from msStatus where FlagUser ='Teknisi'"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsjenisbiaya" runat="server" ConnectionString="<%$ ConnectionStrings:dbVsatConnectionString %>" SelectCommand="select JenisBiaya from [msJenisBiaya]"></asp:SqlDataSource>

        </div>
    </div>
</asp:Content>

