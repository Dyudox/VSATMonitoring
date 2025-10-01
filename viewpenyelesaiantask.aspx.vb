Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.Bootstrap
Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports System.Data
Imports DevExpress.Web.ASPxEdit

Partial Class viewpenyelesaiantask
    Inherits System.Web.UI.Page
    Dim con, con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr, sqldr, dr1 As SqlDataReader
    Dim com, com1 As SqlCommand
    Dim VID, NamaRemote, IPLAN, SID, ALamatInstall As String
    Dim tampung, NoSubtask,strsql As String
    Dim filePath As String = ConfigurationManager.AppSettings("filePath")
	Dim clsg As New cls_global
	Dim tbldata As DataTable
	
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Request.QueryString("VID") = "" Then
            If Session("UserName") = "" Then
                Response.Redirect("~/login.aspx")
            End If
        Else
            txtvid.Text = Request.QueryString("VID")
            Dim tampunghub As String = ""
            Dim getinfo As String = "SELECT trTask.*, " & _
                                    "CONVERT(date, trdetail_task.TglBerangkat) as Berangkat, " & _
                                    "convert(date, trdetail_task.TglPulang) as pulang, " & _
                                    "convert(date, trdetail_task.TglSelesaiKerjaan) as selesai, " & _
                                    "convert(date, trdetail_task.TglStatusPerbaikan) as stperbaikan  ,trDetail_Task.*, msStatus.Status AS StatusPekerjaan FROM trTask " & _
                                    "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                    "LEFT OUTER JOIN msStatus ON trTask.IdStatusTask = msStatus.ID where trDetail_task.NoListTask = '" & Request.QueryString("id") & "'"
            com = New SqlCommand(getinfo, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            txtordertask.Text = dr("idJenisTask").ToString
            txtordertask.ReadOnly = True
            Session("notask") = dr("NoListTask").ToString
            txtnotask.Text = dr("NoTask").ToString
            txtnotask.ReadOnly = True
            ' txtvid.Text = dr("VID").ToString
            txtSID.Text = dr("SID").ToString
            txtSID.ReadOnly = True
            txtiplan.Value = dr("IPLAN").ToString

            Dim getdatastatus As String = "select * from msstatus where ID = '" & dr("IdStatusPerbaikan").ToString & "'"
            com1 = New SqlCommand(getdatastatus, con1)
            con1.Open()
            dr1 = com1.ExecuteReader()
            dr1.Read()
            If dr1.HasRows Then
                txtstatusperbaikan.Value = dr1("Status").ToString
            End If

            dr1.Close()
            con1.Close()

            txtlaporanpengaduan.Text = dr("LaporanPengaduan").ToString
            txtstatuskoordinator.Text = dr("IdStatusKoordinator").ToString
            txtcatatankoordinator.Text = dr("CatatanKoordinator").ToString
            txtPIC.Value = dr("PIC").ToString
            txtphonepic.Value = dr("NoHpPic").ToString
            txttglberangkat.Value = dr("Berangkat")
            txttglselesai.Value = dr("selesai")
            txttglpulang.Value = dr("pulang")
            txttglpengaduan.Value = dr("stperbaikan")
            txtidatm.Value = dr("IdATM").ToString
            txtalamatsekarang.Value = dr("AlamatSekarang").ToString
            txtcatatanlokasi.Value = dr("Catatan").ToString
            txtfailHW.Value = dr("FAIL_HW").ToString
            txtSQF.Value = dr("SQF").ToString
            txtinitialesno.Value = dr("INITIAL_ESNO").ToString
            txtcarriertonotice.Value = dr("CARRIER_TO_NOICE").ToString
            txthasilxpoll.Value = dr("HasilXPOLL").ToString
            txtCPI.Value = dr("CPI").ToString
            tampunghub = dr("Hub").ToString
            txtoperatorsatelit.Value = dr("OperatorSatelite").ToString
            txtoperatorhelpdesk.Value = dr("OperatorHelpDesk").ToString
            txtoutpln.Value = dr("OutPLN").ToString
            txtaktifitassolusi.Value = dr("AktifitasSolusi").ToString
            txtoutups.Value = dr("OutUPS").ToString
            txtupsforbackup.Value = dr("UPSforBackup").ToString
            txtsuhuruangan.Value = dr("SuhuRuangan").ToString
            txttypemounting.Value = dr("TypeMounting").ToString
            txtpanjangkabel.Value = dr("PanjangKabel").ToString
            txtletakantena.Value = dr("LetakAntena").ToString
            txtletakmodem.Value = dr("LetakModem").ToString
            txtkondisibangunan.Value = dr("KondisiBangungan").ToString
            txtanalisaproblem.Value = dr("AnalisaProblem").ToString
            txtstatusdokumentasi.Value = dr("statusdokumentasi").ToString

            'Load data survey
            txtalamatpengiriman.Value = dr("AlamatPengirimanSurvey").ToString
            txttempatpenyimpanan.Value = dr("TempatPenyimpananSurvey").ToString
            txtpicsurvey.Value = dr("NamaPICSurvey").ToString
            txtnohppicsurvey.Value = dr("KontakPICSurvey").ToString
            txtpenempatangrounding.Value = dr("PenempatanGroundingSurvey").ToString
            txtukuranantena.Value = dr("UkuranAntenaSurvey").ToString
            txttempatantena.Value = dr("TempatAntenaSurvey").ToString
            txtroof.Value = dr("KekuatanRoofSurvey").ToString
            txtjenismountingantena.Value = dr("JenisMountingSurvey").ToString
            txtlatitudesurvey.Value = dr("LatitudeSurvey").ToString
            txtlongitudesurvey.Value = dr("LongitudeSurvey").ToString
            txtpengukuranlistrikawalsurvey.Value = dr("ListrikAwalSurvey").ToString
            txtacindoorsurvey.Value = dr("SarpenACIndoorSurvey").ToString
            txtsaranapendukungUPS.Value = dr("SarpenUPSSurvey").ToString
            txtpanjangkabelsurvey.Value = dr("PanjangKabelSurvey").ToString
            cbtypekabelsurvey.Value = dr("TypeKabelSurvey").ToString
            txtarahantenasurvey.Value = dr("ArahAntenaSurvey").ToString
            txtstatussurvey.Value = dr("StatusHasilSurvey").ToString
            txtketsurvey.Value = dr("KeteranganSurvey").ToString

            'Load Data Installasi
            txtdiameterantena.Value = dr("DiameterAntena").ToString
            txtpolarisasi.Value = dr("PolarisasiArahAntena").ToString
            txtelevasi.Value = dr("ElevasiArahAntena").ToString
            txtazimuth.Value = dr("AzimuthArahAntena").ToString
            cbsourcelistrik.Value = dr("SourceListrik").ToString
            cbkabelroll.Value = dr("KabelRoll").ToString
            cbupsindoor.Value = dr("PerangkatkeUPS").ToString
            KVA.Value = dr("KVAUPS").ToString
            cbfrequency.Value = dr("FrequencyBandModulation").ToString
            txtvsatmanagementipaddress.Value = dr("IPManagement").ToString
            txtreceivesimbolrate.Value = dr("ReceiveSymboleRate").ToString
            txtphasanetralpln.Value = dr("PhaseNetralPLN").ToString
            txtphasanetralups.Value = dr("PhaseNetralUPS").ToString
            txtphasanetralgenset.Value = dr("PhaseNetralGenset").ToString
            txtphasagroundpln.Value = dr("PhaseGroundPLN").ToString
            txtphasagroundups.Value = dr("PhaseGroundUPS").ToString
            txtphasagroundgenset.Value = dr("PhaseGroundGenset").ToString
            txtnetralgroundpln.Value = dr("NetralGroundPLN").ToString
            txtnetralgroundups.Value = dr("NetralGroundUPS").ToString
            txtnetralgroundgenset.Value = dr("NetralGroundGenset").ToString
            txtsatelitelongitude.Value = dr("SateliteLongitude").ToString
            txtlan1.Value = dr("IPLAN1").ToString
            txtsubnetmask1.Value = dr("subnetmask1").ToString
            txtlan2.Value = dr("IPLAN2").ToString
            txtsubnetmask2.Value = dr("subnetmask2").ToString
            txtalamat1.Value = dr("HasilTestAlamat1").ToString
            txtalamat2.Value = dr("HasilTestAlamat2").ToString
            txtalamat3.Value = dr("HasilTestAlamat3").ToString
            txtsuccess1.Value = dr("SuccessTest1").ToString
            txtsuccess2.Value = dr("SuccessTest2").ToString
            txtsuccess3.Value = dr("SuccessTest3").ToString
            txtloss1.Value = dr("LossTest1").ToString
            txtloss2.Value = dr("LossTest2").ToString
            txtloss3.Value = dr("LossTest3").ToString
            txtket1.Value = dr("KeteranganTest1").ToString
            txtket2.Value = dr("KeteranganTest2").ToString
            txtket3.Value = dr("KeteranganTest3").ToString
            dr.Close()
            con.Close()

			strsql = "select * from mshub where id='" & tampunghub & "'"
        tbldata = clsg.ExecuteQuery(strsql)
        If IsNothing(tbldata) = True Then
			strsql="select * from mshub where hub='" & tampunghub & "'"
        End If
		Dim gethub As String = strsql
            'Dim gethub As String = "select * from msHub where id = '" & tampunghub & "' "
			'clsg.writedata(Session("UserName"), "Upload", "Foto",gethub,"")
            com = New SqlCommand(gethub, con)
            con.Open()
            dr = com.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                txthub.Value = dr("Hub").ToString
                dr.Close()
            End If
            con.Close()

            Dim getdatalokasi As String = "select * from trRemoteSite where VID = '" & Request.QueryString("VID") & "'"
            com = New SqlCommand(getdatalokasi, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            txtnamaremote.Value = dr("NAMAREMOTE").ToString
            txtalamat.Value = dr("AlamatInstall").ToString
            txtprovinsi.Value = dr("PROVINSI").ToString
            txtkota.Value = dr("KOTA").ToString
            txtkancainduk.Value = dr("KANCAINDUK").ToString
            txtkanwil.Value = dr("KANWIL").ToString
            txtidjarkom.Value = dr("IdJarkom").ToString
            txtsatelit.Value = dr("IdSatelite").ToString
            txtPIC.Value = dr("CustPIC").ToString
            txtphonepic.Value = dr("CustPIC_Phone").ToString
            txtsatelit.Value = dr("IdSatelite").ToString
            txtlatitude.Value = dr("Latitude").ToString
            txtlongitude.Value = dr("Longitude").ToString
            'txtidatm.value = dr("IdATM").ToString
            dr.Close()
            con.Close()

			groupdatalokasi.Visible = True
			groupgeneralinfo.Visible = True
			groupdatateknis.Visible = True
			groupinstallasi.Visible = True
			groupsurvey.Visible = True
			groupdatabarangterpasang.Visible = True
			groupfoto.Visible = True
			groupstatusperbaikan.Visible = True
			groupstatusadmin.Visible = True

        End If
        CariGroup()
        room_image()
    End Sub

    Private Sub CariGroup()
        groupdatalokasi.Visible = False
        groupgeneralinfo.Visible = False
        groupdatateknis.Visible = False
        groupinstallasi.Visible = False
        groupsurvey.Visible = False
        groupdatabarangterpasang.Visible = False
        groupfoto.Visible = False
        groupstatusperbaikan.Visible = False
        groupstatusadmin.Visible = False

        'If Request.QueryString("order") = "PM" Then
        groupdatalokasi.Visible = True
        groupgeneralinfo.Visible = True
        groupdatateknis.Visible = True
        groupinstallasi.Visible = False
        groupsurvey.Visible = False
        groupdatabarangterpasang.Visible = True
        groupfoto.Visible = True
        groupstatusperbaikan.Visible = True
        groupstatusadmin.Visible = True
        'End If

        If Request.QueryString("order") = "SiteSurvey" Then
            groupsurvey.Visible = True
            groupdatateknis.Visible = False
            groupdatabarangterpasang.Visible = False
            groupstatusadmin.Visible = False
            groupdatalokasi.Visible = True
            groupgeneralinfo.Visible = False
            groupfoto.Visible = True
            groupstatusperbaikan.Visible = True
        End If

        If Request.QueryString("order") = "Installation" Then
            groupinstallasi.Visible = True
            groupsurvey.Visible = False
            groupdatabarangterpasang.Visible = True
            groupgeneralinfo.Visible = True
            groupdatateknis.Visible = True
            groupfoto.Visible = True
            groupstatusperbaikan.Visible = True
        End If

        If Session("level") = "Teknisi" Then
            groupstatusadmin.Visible = False
        End If
    End Sub

    Private Sub room_image()
        Dim strGambar As String
        Dim img As String
        strGambar = "select * from trx_file where VID='" & Request.QueryString("VID") & "' and keterangan <> 'Penggunaan Uang SPD'"
        Try
            com = New SqlCommand(strGambar, con)
            con.Open()
            sqldr = com.ExecuteReader()
            'sqldr.Read()
            img = "<ul style='left: 0px; top: 0px;'>"
            While sqldr.Read()
                img &= "<li style='width: 200px; text-align:center'>" &
                            "<a href=" & sqldr("file_url") & "><img src=" & sqldr("file_url") & " style='max-height:200px;max-width:150px;min-height:200px;min-width:100px;'></a>" & _
                            "<label style='color:Black'><b>" & sqldr("Description").ToString & "</b></label>" & _
                            "<p>" & sqldr("Keterangan").ToString & "</p>" & _
                            "<center><a class='label label-success' style='width:50%; align:center' href='editfoto.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&filename=" & sqldr("file_url") & "'>Edit</a></center>" & _
                            "<center><a class='label label-danger' onclick='if (!UserCustomerConfirmation()) return false;' style='width:50%; align:center' href='createdetiltask.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&status=delete&filename=" & sqldr("file_url") & "'>Delete</a></center>" & _
                       "</li> &nbsp;&nbsp;"
            End While
            img &= "</ul>"
            sqldr.Close()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        ltr_image_room.Text = img
    End Sub

    Protected Sub grid_barang_on_Load(sender As Object, e As EventArgs) Handles grid_barang_on.Load
        'dsbarang_on.SelectCommand = "SELECT trTask.*, trDetail_Task.*, msStatus.Status AS StatusPekerjaan " & _
        '                           "FROM trTask LEFT OUTER JOIN " & _
        '                           "trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
        '                           "msStatus ON trTask.IdStatusTask = msStatus.ID where trTask.ID = '" & Request.QueryString("id") & "'"
        dsbarang_on.SelectCommand = "select * from trRemoteSite_D where VID = '" & Request.QueryString("VID") & "'"
    End Sub

    Protected Sub grid_barang_replace_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles grid_barang_replace.CustomCallback
        grid_barang_replace.DataBind()
    End Sub

    Protected Sub grid_barang_replace_Load(sender As Object, e As EventArgs) Handles grid_barang_replace.Load
        'dsbarang_rep.SelectCommand = "SELECT trTask.*, trDetail_Task.*, msStatus.Status AS StatusPekerjaan " & _
        '                           "FROM trTask LEFT OUTER JOIN " & _
        '                           "trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
        '                           "msStatus ON trTask.IdStatusTask = msStatus.ID where trTask.ID = '" & Request.QueryString("id") & "'"
        dsbarang_rep.SelectCommand = "SELECT * FROM trRemoteSite_D_Rusak where VID = '" & Request.QueryString("VID") & "'"
    End Sub
End Class
