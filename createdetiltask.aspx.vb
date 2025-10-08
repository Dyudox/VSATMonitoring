Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Bootstrap
'Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports DevExpress.Web.ASPxEdit

Partial Class createdetiltask
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr, sqldr As SqlDataReader
    Dim com As SqlCommand
    Dim VID, NamaRemote, IPLAN, SID, ALamatInstall As String
    Dim tampung, NoSubtask As String
    Dim filePath As String = ConfigurationManager.AppSettings("filePath")
    Dim clsg As New cls_global
	Dim tbldata As DataTable
    Dim strsql As String
    Dim DocNo As String = "DT" & Now.Hour.ToString("D2") & Now.Year & Now.Minute.ToString("D2") & Now.Month.ToString("D2") & Now.Day.ToString("D2") & Now.Second.ToString("D2")
    Dim GetFlagDataTeknis As String

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Request.QueryString("status") = "Finish" Then
            Response.Redirect("viewpenyelesaiantask.aspx?ID=" & Request.QueryString("ID") & "&VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "&order=" & Request.QueryString("order") & "&status=" & Request.QueryString("status") & "")
        End If

        If Request.QueryString("VID") = "" Then
            If Session("UserName") = "" Then
                Response.Redirect("~/login.aspx")
            End If
            'Else
            '    CariData(Request.QueryString("VID"))
        End If
        'room_image()

    End Sub

    Private Sub CariGroup()
        'If Request.QueryString("order") = "PM" Or Request.QueryString("order") = "CM" Then
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
            groupsurvey.Visible = False
            groupdatateknis.Visible = False
            groupdatabarangterpasang.Visible = False
            groupstatusadmin.Visible = False
            groupdatalokasi.Visible = True
            groupgeneralinfo.Visible = True
            groupfoto.Visible = True
            groupstatusperbaikan.Visible = True
			groupinstallasi.Visible = false
        End If

        If Request.QueryString("order") = "Installation" Then
            groupinstallasi.Visible = False
            groupsurvey.Visible = False
            groupdatabarangterpasang.Visible = True
            groupgeneralinfo.Visible = True
            groupdatateknis.Visible = True
            groupfoto.Visible = True
            groupstatusperbaikan.Visible = True
        End If

        If Session("level") = "Teknisi" Then
            'groupstatusadmin.Visible = False
            groupdatateknis.Visible = True
            groupfoto.Visible = True
            groupstatusperbaikan.Visible = True
            groupstatusadmin.Visible = True
            groupinstallasi.Visible = False
            groupsurvey.Visible = False
        End If

    End Sub
	private sub CariData(VID as string)
		Dim tampunghub As String = ""
		txtvid.Text = VID
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
		
		Session("notask") = dr("NoListTask").ToString
		
		cbstatusperbaikan.Value = dr("IdStatusPerbaikan").ToString
		
		txtPIC.Value = dr("PIC").ToString
		txtphonepic.Value = dr("NoHpPic").ToString
				
		txtcarriertonotice.Value = dr("CARRIER_TO_NOICE").ToString
		
		tampunghub = dr("Hub").ToString
		
		cbstatusdokumentasi.Value = dr("statusdokumentasi").ToString
		
		'Data Lokasi		
		txtnamaremote.Value = dr("NAMAREMOTE").ToString
		
		txtprovinsi.Value = dr("PROVINSI").ToString
		txtkota.Value = dr("KOTA").ToString
		txtkanwil.Value = dr("KANWIL").ToString
		txtkancainduk.Value = dr("KANCAINDUK").ToString	
		txtidjarkom.Value = dr("IdJarkom").ToString
		txtsatelit.Value = dr("IdSatelite").ToString		
		txtlatitude.Value = dr("Latitude").ToString
		txtlongitude.Value = dr("Longitude").ToString
		txtalamatsekarang.Value = dr("AlamatSekarang").ToString
		txtcatatanlokasi.Value = dr("Catatan").ToString
				
		'General Info
		txtnotask.Text = dr("NoTask").ToString
		txtnotask.ReadOnly = True
		txtvid.Text = VID
		txtSID.Text = dr("SID").ToString
		txtiplan.Value = dr("IPLAN").ToString
		txtidatm.Value = dr("IdATM").ToString
		txtlaporanpengaduan.Text = dr("LaporanPengaduan").ToString
		txtstatuskoordinator.Text = dr("IdStatusKoordinator").ToString
		
		txtordertask.Text = dr("idJenisTask").ToString
		txtordertask.ReadOnly = True
		txttglberangkat.Value = dr("Berangkat")
		txttglselesai.Value = dr("selesai")
		txttglpulang.Value = dr("pulang")
		txttglpengaduan.Value = dr("stperbaikan")		
		txtcatatankoordinator.Text = dr("CatatanKoordinator").ToString
		
		'Data Teknis
		txtfailHW.Value = dr("FAIL_HW").ToString
		txtSQF.Value = dr("SQF").ToString
		txtinitialesno.Value = dr("INITIAL_ESNO").ToString
		txtCPI.Value = dr("CPI").ToString
		txthasilxpoll.Value = dr("HasilXPOLL").ToString
		txtoperatorsatelit.Value = dr("OperatorSatelite").ToString
		txtoperatorhelpdesk.Value = dr("OperatorHelpDesk").ToString
		txtoutpln.Value = dr("OutPLN").ToString
		txtaktifitassolusi.Value = dr("AktifitasSolusi").ToString
		
		txtoutups.Value = dr("OutUPS").ToString
		cbupsforbackup.Value = dr("UPSforBackup").ToString
		txtsuhuruangan.Value = dr("SuhuRuangan").ToString
		txttypemounting.Value = dr("TypeMounting").ToString
		txtpanjangkabel.Value = dr("PanjangKabel").ToString
		txtletakantena.Value = dr("LetakAntena").ToString
		txtletakmodem.Value = dr("LetakModem").ToString
		txtkondisibangunan.Value = dr("KondisiBangungan").ToString
		txtanalisaproblem.Value = dr("AnalisaProblem").ToString
		
		'Data Installasi
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
		txtsuccess1.Value = dr("SuccessTest1").ToString
		txtloss1.Value = dr("LossTest1").ToString
		txtket1.Value = dr("KeteranganTest1").ToString
		txtalamat2.Value = dr("HasilTestAlamat2").ToString
		txtsuccess2.Value = dr("SuccessTest2").ToString
		txtloss2.Value = dr("LossTest2").ToString
		txtket2.Value = dr("KeteranganTest2").ToString
		txtalamat3.Value = dr("HasilTestAlamat3").ToString
		txtsuccess3.Value = dr("SuccessTest3").ToString
		txtloss3.Value = dr("LossTest3").ToString
		txtket3.Value = dr("KeteranganTest3").ToString
		
		'Data Survey
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

		dr.Close()
		con.Close()

		strsql = "select * from mshub where id='" & tampunghub & "'"
        tbldata = clsg.ExecuteQuery(strsql)
        If IsNothing(tbldata) = True Then
			strsql="select * from mshub where hub='" & tampunghub & "'"
        End If
		Dim gethub As String = strsql
		com = New SqlCommand(gethub, con)
		con.Open()
        dr = com.ExecuteReader()
        dshub.SelectCommand = "select * from msHub"
        cbhub.DataBind()
		If dr.HasRows Then
			dr.Read()
			If IsDBNull(dr("Hub")) Then
				dshub.SelectCommand = "select * from msHub"
				cbhub.DataBind()
			Else
                cbhub.Text = dr("Hub").ToString
                'cbhub.SelectedItem = dr("id").ToString
                cbhub.SelectedItem.Text = dr("Hub").ToString
			End If
			dr.Close()
			else
			dshub.SelectCommand = "select * from msHub"
			cbhub.DataBind()
		End If
		con.Close()

        Dim getdatalokasi As String = "select isnull('',AlamatInstall) as AlamatInstall, * from trRemoteSite where VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(getdatalokasi, con)
		con.Open()
		dr = com.ExecuteReader()
		dr.Read()
			txtalamat.Value = dr("AlamatInstall").ToString	
			txtPIC.Value = dr("CustPIC").ToString
			txtphonepic.Value = dr("CustPIC_Phone").ToString
		'txtidatm.value = dr("IdATM").ToString
		dr.Close()
		con.Close()

		'Validasi Data Lokasi
		if txtnamaremote.Value=nothing or txtalamat.Value=nothing or txtprovinsi.Value=nothing or txtkota.Value=nothing or
		txtkanwil.Value=nothing or txtkancainduk.Value=nothing or txtPIC.Value=nothing or txtphonepic.Value=nothing or
		txtidjarkom.Value=nothing or txtsatelit.Value=nothing or cbhub.Value=nothing or txtlatitude.Value=nothing or
		txtlongitude.Value=nothing or txtalamatsekarang.Value=nothing or txtcatatanlokasi.Value=nothing then
		DisableTab()
		exit sub
		
		end if
		
		'strsql=txtnotask.text & "|" & txtvid.text & "|" & txtSID.text & "|" & txtiplan.Value & "|" & txtidatm.Value & "|" &
		'txtstatuskoordinator.text & "|" & txttglpengaduan.Value & "|" & txtordertask.text & "|" & 
		'txttglberangkat.Value & "|" & txttglselesai.Value & "|" & txttglpulang.Value
		'clsg.writedata("Validasi General Info", strsql, "", "", "")

        'Validasi General Info
        If txtnotask.Text = Nothing Or txtvid.Text = Nothing Or txtiplan.Value = Nothing Or
        txtidatm.Value = Nothing Or txtstatuskoordinator.Text = Nothing Or txttglpengaduan.Value = Nothing Or
        txtordertask.Text = Nothing Or txttglberangkat.Value = Nothing Or txttglselesai.Value = Nothing Or txttglpulang.Value = Nothing Then
            groupdatalokasi.Visible = True
            groupgeneralinfo.Visible = True
            'Exit Sub

        End If

        'Validasi Data Teknis
        If txtfailHW.Value = Nothing Or txtSQF.Value = Nothing Or txtinitialesno.Value = Nothing Or txtCPI.Value = Nothing Or
            txtcarriertonotice.Value = Nothing Or txthasilxpoll.Value = Nothing Or txtoperatorsatelit.Value = Nothing Or
            txtoperatorhelpdesk.Value = Nothing Or txtoutpln.Value = Nothing Or txtaktifitassolusi.Value = Nothing Or txtoutups.Value = Nothing Or
            cbupsforbackup.Value = Nothing Or txtsuhuruangan.Value = Nothing Or txttypemounting.Value = Nothing Or txtpanjangkabel.Value = Nothing Or
            txtletakantena.Value = Nothing Or txtletakmodem.Value = Nothing Or txtkondisibangunan.Value = Nothing Or txtanalisaproblem.Value = Nothing Then
            groupdatalokasi.Visible = True
            groupgeneralinfo.Visible = True
            groupdatateknis.Visible = True
            If Request.QueryString("order") = "CM" Or Request.QueryString("order") = "PM" Then
                groupdatabarangterpasang.Visible = True
                groupfoto.Visible = True
                groupstatusperbaikan.Visible = True
                groupstatusadmin.Visible = True
            End If
            CariGroup()
            Exit Sub

        End If

        If Request.QueryString("order") = "SiteSurvey" Then
        Else
            'Validasi Data Installasi
            If txtdiameterantena.Value = Nothing Or txtpolarisasi.Value = Nothing Or txtelevasi.Value = Nothing Or txtazimuth.Value = Nothing Or
            cbsourcelistrik.Value = Nothing Or cbkabelroll.Value = Nothing Or cbupsindoor.Value = Nothing Or KVA.Value = Nothing Or txtloss3.Value = Nothing Or
            cbfrequency.Value = Nothing Or txtvsatmanagementipaddress.Value = Nothing Or txtreceivesimbolrate.Value = Nothing Or txtket3.Value = Nothing Or
            txtphasanetralpln.Value = Nothing Or txtphasanetralups.Value = Nothing Or txtphasanetralgenset.Value = Nothing Or txtphasagroundpln.Value = Nothing Or
            txtphasagroundups.Value = Nothing Or txtphasagroundgenset.Value = Nothing Or txtnetralgroundpln.Value = Nothing Or txtnetralgroundups.Value = Nothing Or
            txtnetralgroundgenset.Value = Nothing Or txtsatelitelongitude.Value = Nothing Or txtlan1.Value = Nothing Or txtlan2.Value = Nothing Or txtsubnetmask2.Value = Nothing Or
            txtalamat1.Value = Nothing Or txtsuccess1.Value = Nothing Or txtloss1.Value = Nothing Or txtket1.Value = Nothing Or txtalamat2.Value = Nothing Or
            txtsuccess2.Value = Nothing Or txtloss2.Value = Nothing Or txtket2.Value = Nothing Or txtalamat3.Value = Nothing Or txtsuccess3.Value = Nothing Then
                groupdatalokasi.Visible = True
                groupgeneralinfo.Visible = True
                groupdatateknis.Visible = True
				groupinstallasi.Visible = True
                If Request.QueryString("order") = "Installation" Then
                    groupinstallasi.Visible = True
                End If
				CariGroup()
                Exit Sub
            End If
        End If
		
        CariGroup()
		
        'If cbupsforbackup.Value <> "" Then
        ' groupgeneralinfo.Visible = True
        ' groupdatateknis.Visible = True
        ' groupstatusperbaikan.Visible = True
        ' groupdatabarangterpasang.Visible = True
        ' groupfoto.Visible = True
        ' groupstatusadmin.Visible = True
        ' groupsurvey.Visible = False
        ' groupinstallasi.Visible = False
        'Else
        ' groupgeneralinfo.Visible = False
        ' groupdatateknis.Visible = False
        ' groupstatusperbaikan.Visible = False
        ' groupdatabarangterpasang.Visible = False
        ' groupfoto.Visible = False
        ' groupstatusadmin.Visible = False
        ' groupsurvey.Visible = False
        ' groupinstallasi.Visible = False
        'End If

		'AktifTab(Request.QueryString("order"))

        
	end sub
    Private Sub DisableTab()
        groupdatalokasi.Visible = True
        groupgeneralinfo.Visible = False
        groupdatateknis.Visible = False
        groupinstallasi.Visible = False
        groupsurvey.Visible = False
        groupdatabarangterpasang.Visible = False
        groupfoto.Visible = False
        groupstatusperbaikan.Visible = False
        groupstatusadmin.Visible = False
		strsql = "select * from trDetail_Task where NoListTask=" & Request.QueryString("ID") & ""
        tbldata = clsg.ExecuteQuery(strsql)
        'If tbldata.Rows(0).Item("FlagDataBarang") = True Then
        '    groupdatabarangterpasang.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagDataInstallasi") = True Then
        '    groupinstallasi.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagDataLokasi") = True Then
        '    groupdatalokasi.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagDataSurvey") = True Then
        '    groupsurvey.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagDataTeknis") = True Then
        '    groupdatateknis.Visible = True
        '    groupfoto.Visible = True
        '    groupstatusperbaikan.Visible = True
        '    groupstatusadmin.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagGeneralInfo") = True Then
        '    groupgeneralinfo.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagUploadPhoto") = True Then
        '    groupfoto.Visible = True
        'End If

        'If Session("level") = "Teknisi" Then
        '    Dim strFlagDataTeknis As String = "select * from trDetail_Task where NoListTask=" & Request.QueryString("ID") & ""
        '    com = New SqlCommand(strFlagDataTeknis, con)
        '    con.Open()
        '    dr = com.ExecuteReader()
        '    If dr.HasRows Then
        '        dr.Read()
        '        GetFlagDataTeknis = Convert.ToBoolean(dr("FlagDataTeknis"))
        '    End If
        '    dr.Close()
        '    con.Close()

        '    If GetFlagDataTeknis = True Then
        '        groupfoto.Visible = False
        '        groupstatusperbaikan.Visible = False
        '        groupstatusadmin.Visible = False
        '    Else
        '        groupfoto.Visible = False
        '        groupstatusperbaikan.Visible = False
        '        groupstatusadmin.Visible = False
        '    End If
        'End If

        If Session("level") = "Teknisi" Then
            Dim strFlagDataTeknis As String = "SELECT FlagDataTeknis FROM trDetail_Task WHERE NoListTask = @NoListTask"
            com = New SqlCommand(strFlagDataTeknis, con)

            Using com As New SqlCommand(strFlagDataTeknis, con)
                Dim noListTask As Integer
                If Integer.TryParse(Request.QueryString("ID"), noListTask) Then
                    com.Parameters.AddWithValue("@NoListTask", noListTask)
                Else
                    Exit Sub
                End If

                con.Open()
                Dim result As Object = com.ExecuteScalar()
                con.Close()

                ' 🛠️ Cek NULL atau kosong dulu
                If result IsNot Nothing AndAlso Not IsDBNull(result) AndAlso Not String.IsNullOrEmpty(result.ToString()) Then
                    GetFlagDataTeknis = Convert.ToBoolean(result)
                Else
                    GetFlagDataTeknis = False ' default jika NULL / kosong
                End If

                ' === Kontrol tampilan ===
                If GetFlagDataTeknis = True Then
                    groupfoto.Visible = False
                    groupstatusperbaikan.Visible = False
                    groupstatusadmin.Visible = False
                Else
                    groupfoto.Visible = False
                    groupstatusperbaikan.Visible = False
                    groupstatusadmin.Visible = False
                End If
            End Using
        End If

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		'test.Value = Now.AddDays(5)
	'exit sub
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If

        If Session("level") = "Teknisi" Then
            groupstatusadmin.Visible = False
            txtSID.Enabled = False
            txtiplan.Disabled = True
            txtidatm.Disabled = True
        End If

        Dim tampungid As String = ""

        If Request.QueryString("status") = "delete" Then
            Dim getid As String = "select * from trx_file where file_url = '" & Request.QueryString("filename") & "'"
            com = New SqlCommand(getid, con)
            con.Open()
            dr = com.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tampungid = dr("file_id").ToString
            End If
            dr.Close()
            con.Close()

            Dim hapusgambar As String = "delete from trx_file where file_id = '" & tampungid & "'"
            com = New SqlCommand(hapusgambar, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        End If
        'room_image()
        If Not Page.IsPostBack Then
            DisableTab()
			CariData(Request.QueryString("VID"))
        End If
        'groupfoto.Visible = true
        room_image()
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
        'Response.Redirect("createdetiltask.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "")
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

    Protected Sub btngeneralinfo_Click(sender As Object, e As EventArgs) Handles btngeneralinfo.Click
	'clsg.writedata("General Info", "Createdetailtask.aspx", "Update", "Step 1", "")
		'clsg.writedata(txttglberangkat.Value, txttglpulang.value, txttglselesai.value, txttglpengaduan.value, "")
	'exit sub
        Dim Tahunberangkat, Tahunselesai, TahunPulang, TahunStatus As String
        Dim Bulanberangkat, Bulanselesai, Bulanpulang, Bulanstatus As String
        Dim tanggalberangkat, tanggalselesai, tanggalpulang, tanggalstatus As String
        Dim valueberangkat As System.DateTime
        Dim valuepulang As System.DateTime
        Dim valueselesai As System.DateTime
        Dim valuestatus As System.DateTime

        If txttglberangkat.Value = Nothing Then
            valueberangkat = Date.Now
        Else
            valueberangkat = txttglberangkat.value
        End If

        If txttglpulang.value = Nothing Then
            valuepulang = Date.Now
        Else
            valuepulang = txttglpulang.value
        End If

        If txttglselesai.value = Nothing Then
            valueselesai = Date.Now
        Else
            valueselesai = txttglselesai.value
        End If

        If txttglpengaduan.value = Nothing Then
            valuestatus = Date.Now
        Else
            valuestatus = txttglpengaduan.value
        End If
		'clsg.writedata("General Info", "Createdetailtask.aspx", "Update", "Step 2", "")
        'Dim valuepulang As System.DateTime = txttglpulang.value
        'Dim valueselesai As System.DateTime = txttglselesai.value
        'Dim valuestatus As System.DateTime = txttglpengaduan.value

        Tahunberangkat = valueberangkat.Year.ToString()
        Bulanberangkat = valueberangkat.Month.ToString()
        tanggalberangkat = valueberangkat.Day.ToString()
        Dim berangkatsuk As String = Tahunberangkat & "-" & Bulanberangkat & "-" & tanggalberangkat & ""
        ' Dim berangkatsuk As String = "2018-06-02"

        Tahunselesai = valueselesai.Year.ToString()
        Bulanselesai = valueselesai.Month.ToString()
        tanggalselesai = valueselesai.Day.ToString()
        Dim selesaisuk As String = Tahunselesai & "-" & Bulanselesai & "-" & tanggalselesai & ""
        ' Dim selesaisuk As String = "2018-06-03"

        TahunPulang = valuepulang.Year.ToString()
        Bulanpulang = valuepulang.Month.ToString()
        tanggalpulang = valuepulang.Day.ToString()
        Dim pulangsuk As String = TahunPulang & "-" & Bulanpulang & "-" & tanggalpulang & ""
        'Dim pulangsuk As String = "2018-06-04"

        TahunStatus = valuestatus.Year.ToString()
        Bulanstatus = valuestatus.Month.ToString()
        tanggalstatus = valuestatus.Day.ToString()
        Dim statussuk As String = TahunStatus & "-" & Bulanstatus & "-" & tanggalstatus & ""
        'clsg.writedata("General Info", "Createdetailtask.aspx", "Update", "Step 3", "")
        'Dim statussuk As String = "2018-06-05"

        'ValueDateCloseTicket = VMonth & "-" & VDay & "-" & VYear & " " & VHours & ":" & VMinnute & ":" & VDetik & ""

        Dim detiltask As String = "Update trDetail_Task set FlagGeneralInfo=1,IdATM = '" & txtidatm.Value & "', IPLAN = '" & txtiplan.Value & "', TglBerangkat = '" & berangkatsuk & "', TglSelesaiKerjaan =  '" & selesaisuk & "', TglPulang = '" & pulangsuk & "', TglStatusPerbaikan = '" & statussuk & "', UserUpdate = '" & Session("username") & "', DateUpdate = GETDATE() where NoListTask = '" & Request.QueryString("id") & "'"
        'Dim detiltask As String = "Update trDetail_Task set TglBerangkat = '" & berangkatsuk & "' where VID = '" & Request.QueryString("VID") & "'"
        clsg.writedata("General Info", "Createdetailtask.aspx", "Update", detiltask, "")
		com = New SqlCommand(detiltask, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        Dim remotesite As String = "update trRemoteSite set IPLAN = '" & txtiplan.Value & "' where VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(remotesite, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        If Request.QueryString("order") <> "SiteSurvey" Then
            groupdatateknis.Visible = True
        End If
    End Sub

    Protected Sub btnsavelokasi_Click(sender As Object, e As EventArgs) Handles btnsavelokasi.Click
        Dim updatehub As String = ""
        Dim getvaluehub As String = "select * from mshub where Hub = '" & cbhub.Value & "'"
        com = New SqlCommand(getvaluehub, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        updatehub = dr("Hub").ToString
        dr.Close()
        con.Close()

        Dim updatelokasi As String = "Update trDetail_Task set FlagDataLokasi=1,KANWIL = '" & txtkanwil.Value & "', KANCAINDUK = '" & txtkancainduk.Value & "', NAMAREMOTE = '" & txtnamaremote.Value & "', ALAMAT = '" & txtalamat.Value & "', PROVINSI = '" & txtprovinsi.Value & "', KOTA = '" & txtkota.Value & "', IdJarkom = '" & txtidjarkom.Value & "', IdSatelite = '" & txtsatelit.Value & "', PIC = '" & txtPIC.Value & "', NoHpPic = '" & txtphonepic.Value & "', Hub = '" & updatehub & "', Latitude = '" & txtlatitude.Value & "', Longitude = '" & txtlongitude.Value & "', AlamatSekarang = '" & txtalamatsekarang.Value & "', Catatan = '" & txtcatatanlokasi.InnerText & "' where NoListTask = '" & Request.QueryString("id") & "'"
        com = New SqlCommand(updatelokasi, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        Dim updateremotesite As String = "Update trRemoteSite SET KANWIL = '" & txtkanwil.Value & "', KANCAINDUK = '" & txtkancainduk.Value & "', NAMAREMOTE = '" & txtnamaremote.Value & "', AlamatInstall = '" & txtalamat.Value & "', PROVINSI = '" & txtprovinsi.Value & "', KOTA = '" & txtkota.Value & "', IdJarkom = '" & txtidjarkom.Value & "', IdSatelite = '" & txtsatelit.Value & "', PIC = '" & txtPIC.Value & "', CustPIC = '" & txtPIC.Value & "', CustPIC_Phone = '" & txtphonepic.Value & "', Hub = '" & cbhub.Value & "', Latitude = '" & txtlatitude.Value & "', Longitude = '" & txtlongitude.Value & "' where VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(updateremotesite, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        If Request.QueryString("order") = "SiteSurvey" Then
            groupsurvey.Visible = True
        Else
            groupgeneralinfo.Visible = True
        End If
    End Sub

    Protected Sub btnsaveteknis_Click(sender As Object, e As EventArgs) Handles btnsaveteknis.Click
        Dim updateteknis As String = "Update trdetail_task set FlagDataTeknis=1,FAIL_HW = '" & txtfailHW.Value & "', SQF = '" & txtSQF.Value & "', INITIAL_ESNO = '" & txtinitialesno.Value & "', CARRIER_TO_NOICE = '" & txtcarriertonotice.Value & "', HasilXPOLL = '" & txthasilxpoll.Value & "', CPI = '" & txtCPI.Value & "', OperatorSatelite = '" & txtoperatorsatelit.Value & "', OperatorHelpDesk = '" & txtoperatorhelpdesk.Value & "', OutPLN = '" & txtoutpln.Value & "', OutUPS = '" & txtoutups.Value & "', UPSforBackup = '" & cbupsforbackup.Value & "', SuhuRuangan = '" & txtsuhuruangan.Value & "', TypeMounting = '" & txttypemounting.Value & "', PanjangKabel = '" & txtpanjangkabel.Value & "', LetakAntena = '" & txtletakantena.Value & "', LetakModem = '" & txtletakmodem.Value & "', KondisiBangungan = '" & txtkondisibangunan.Value & "', AnalisaProblem = '" & txtanalisaproblem.InnerText & "', AktifitasSolusi = '" & txtaktifitassolusi.InnerText & "' where NoListTask = '" & Request.QueryString("id") & "'"
        com = New SqlCommand(updateteknis, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        If Request.QueryString("order") = "Installation" Then
            groupinstallasi.Visible = False
        ElseIf Request.QueryString("order") = "CM" Or Request.QueryString("order") = "PM" Then
            groupdatabarangterpasang.Visible = True
            groupfoto.Visible = True
            groupstatusperbaikan.Visible = True
            groupstatusadmin.Visible = True
        Else
            groupdatabarangterpasang.Visible = True
            groupstatusperbaikan.Visible = True
            groupfoto.Visible = True
            groupstatusadmin.Visible = True
            groupinstallasi.Visible = False
        End If
    End Sub

    Protected Sub grid_barang_on_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_barang_on.RowDeleting
        dsbarang_on.DeleteCommand = "delete from trRemoteSite_D where ID = @ID"
    End Sub

    Protected Sub grid_barang_on_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_barang_on.RowInserting
        Dim tampungcombo As String = e.NewValues("Status").ToString
        If tampungcombo = "Terpasang" Then
            dsbarang_on.InsertCommand = "INSERT trRemoteSite_D (VID, NamaBarang, Type, SN, IPlan, ESNMODEM, Status, DateCreate, UserCreate) VALUES ('" & Request.QueryString("VID") & "' , @NamaBarang, @Type, @SN, @IPlan, @ESNMODEM, @Status, GETDATE(), '" & Session("username") & "')"
            grid_barang_on.DataBind()

            strsql = "update trdetail_task set FlagDataBarang=1 where vid='" & Request.QueryString("VID") & "'"
            clsg.ExecuteNonQuery(strsql)
        Else
            dsbarang_on.InsertCommand = "INSERT trRemoteSite_D_Rusak (VID, NamaBarang, Type, SN, IPlan, ESNMODEM, Status, DateCreate, UserCreate) VALUES ('" & Request.QueryString("VID") & "' ,  @NamaBarang, @Type, @SN, @IPlan, @ESNMODEM, @Status,  GETDATE(), '" & Session("username") & "')"
            grid_barang_replace.DataBind()
            dsbarang_rep.DataBind()
			grid_barang_on.JSProperties("cpUpdated") = True
            'Dim updaterusak As String = "insert into trRemoteSite_D_Rusak (VID, KodeBarang, NamaBarang, Type, SN, IPlan, Status) VALUES ('" & Request.QueryString("VID") & "', '" & e.NewValues("KodeBarang").ToString & "', '" & e.NewValues("NamaBarang").ToString & "', '" & e.NewValues("Type").ToString & "', '" & e.NewValues("SN").ToString & "', '" & e.NewValues("IPlan").ToString & "', '" & e.NewValues("Status") & "')"
            'com = New SqlCommand(updaterusak, con)
            'con.Open()
            'com.ExecuteNonQuery()
            'con.Close()

            'Dim deletedata As String = "delete from trRemoteSite_D where ID = @ID"
            'com = New SqlCommand(deletedata, con)
            'con.Open()
            'com.ExecuteNonQuery()
            'con.Close()
        End If
        grid_barang_on.DataBind()
        grid_barang_replace.DataBind()
       
    End Sub

    Protected Sub grid_barang_on_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_barang_on.RowUpdating
        Dim tampungcombo As String = e.NewValues("Status").ToString
        Dim tampungid As String = e.OldValues("ID").ToString
        If tampungcombo = "Terpasang" Then
            dsbarang_on.UpdateCommand = "update trRemoteSite_D set NamaBarang = @NamaBarang, Type = @Type, SN = @SN, IPlan = @IPlan, Status = @Status, ESNMODEM = @ESNMODEM, DateCreate = GETDATE(), UserCreate = '" & Session("username") & "' where ID = @ID "
            grid_barang_on.DataBind()
        Else
            dsbarang_on.UpdateCommand = "INSERT trRemoteSite_D_Rusak (VID, NamaBarang, Type, SN, IPlan, ESNMODEM, Status, DateCreate, UserCreate) VALUES ('" & Request.QueryString("VID") & "' , @NamaBarang, @Type, @SN, @IPlan, @ESNMODEM, @Status, GETDATE(), '" & Session("username") & "')"
            grid_barang_replace.DataBind()
            dsbarang_rep.DataBind()

            Dim deletedata As String = "delete from trRemoteSite_D  where ID = '" & tampungid & "'"
            com = New SqlCommand(deletedata, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
			grid_barang_on.JSProperties("cpUpdated") = True
        End If
        grid_barang_on.DataBind()
        grid_barang_replace.DataBind()
        dsbarang_on.DataBind()
        dsbarang_rep.DataBind()

        'DevExpress.Web.ASPxWebControl.RedirectOnCallback(Request.RawUrl)

        'Response.Redirect("createdetiltask.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "")
        'Dim tampungmodem As String = e.NewValues("MODEM_ON").ToString
        'Dim tampungsncac As String = e.NewValues("SNCAC_ON").ToString
        'Dim tampungsnbuc As String = e.NewValues("SNBUC_ON").ToString
        'Dim tampungsnlnb As String = e.NewValues("SNLNB_LNA").ToString

        'Dim updateremote As String = " update trRemoteSite set MODEM = @MODEM_ON, SNCAC = @SNCAC_ON, SNBUC_ODU = @SNBUC_ON, SNLNB_LNA = @SNLNB_ON where VID = '" & Request.QueryString("VID") & "'"
        'com = New SqlCommand(updateremote, con)
        'con.Open()
        'com.ExecuteNonQuery()
        'con.Close()
    End Sub

    Protected Sub grid_barang_replace_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_barang_replace.RowDeleting
        dsbarang_rep.DeleteCommand = "DELETE FROM trRemoteSite_D_Rusak where ID = @ID"
    End Sub

    Protected Sub grid_barang_replace_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_barang_replace.RowInserting
        dsbarang_rep.InsertCommand = "INSERT INTO trRemoteSite_D_Rusak (VID,  NamaBarang, Type, SN, IPlan, Status, Keterangan, ESNMODEM, DateCreate, UserCreate) VALUES ('" & Request.QueryString("VID") & "', @NamaBarang, @Type, @SN, @IPlan, @Status, @Keterangan, @ESNMODEM, GETDATE(), ' " & Session("username") & "')"
    End Sub

    Protected Sub grid_barang_replace_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_barang_replace.RowUpdating
        dsbarang_rep.UpdateCommand = "Update trRemoteSite_D_Rusak set VID = @VID, NamaBarang = @NamaBarang, Type = @Type, SN = @SN, IPlan = @IPlan, Status = @Status, Keterangan = @Keterangan, ESNMODEM = @ESNMODEM, DateCreate = GETDATE(), UserCreate = '" & Session("username") & "' where ID = @ID "
        grid_barang_replace.DataBind()
    End Sub
    ' rizal
    Protected Sub btn_upload_ServerClick(sender As Object, e As EventArgs) Handles btn_upload.ServerClick
        Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
        Try
            Dim j As Integer = 0
            Dim hfc As HttpFileCollection = Request.Files
            Dim PathName As String
            For i As Integer = 0 To hfc.Count - 1
                Dim hpf As HttpPostedFile = hfc(i)

                If hpf.ContentLength > 0 Then
                    hpf.SaveAs(Server.MapPath("~/UploadFoto/") & System.IO.Path.GetFileName(Time & Replace(hpf.FileName, " ", "_")))
                    PathName = Server.MapPath(hpf.FileName)

                    If j < hfc.Count Then
                        Dim strConnString As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
                        Dim sqlquery As String
                        sqlquery = "Insert_proc"
                        Dim con As New SqlConnection(strConnString)
                        Dim cmd As New SqlCommand(sqlquery, con)

                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Parameters.Add("@vid", SqlDbType.VarChar).Value = Request.QueryString("VID")
                        cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = "UploadFoto/" & Time & Replace(hpf.FileName, " ", "_")
                        cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = Session("username")
                        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = txtjudulimage.Text
                        cmd.Parameters.Add("@Keterangan", SqlDbType.VarChar).Value = txtketgambar.InnerText
                        cmd.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = DocNo
                        j = j + 1

                        Try
                            con.Open()
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            Throw ex
                        Finally
                            con.Close()
                            con.Dispose()

                        End Try
                        clsg.writedata(Session("UserName"), "Upload", "Foto", cmd.CommandText & "|" & Request.QueryString("VID") & "|" & _
                                       "UploadFoto/" & Time & Replace(hpf.FileName, " ", "_") & "|" & Session("username") & "|" & txtjudulimage.Text & "|" & _
                                       txtketgambar.InnerText & "|" & DocNo, "")
                        If j = hfc.Count Then
                            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
                            Exit Sub
                        End If
                    End If
                End If
            Next

        Catch generatedExceptionName As Exception

            Throw
        End Try


    End Sub

    'rizal
    Private Sub room_image()
        Dim strGambar As String
        Dim img As String
        strGambar = "select * from trx_file where VID='" & Request.QueryString("VID") & "'"
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
                            "<center><a class='label label-success' style='width:50%; align:center' href='editfoto.aspx?order=" & Request.QueryString("order") & "&id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&filename=" & sqldr("file_url") & "'>Edit</a></center>" & _
                            "<center><a class='label label-danger' onclick='if (!UserCustomerConfirmation()) return false;' style='width:50%; align:center' href='createdetiltask.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&status=delete&filename=" & sqldr("file_url") & "'>Delete</a></center>" & _
                       "</li> &nbsp;&nbsp;"
            End While
            img &= "</ul>"
            clsg.writedata(Session("UserName"), "Upload Foto", img, strGambar, "")
            sqldr.Close()
            con.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
        ltr_image_room.Text = img
    End Sub
    
    Protected Sub btnselesai_Click(sender As Object, e As EventArgs) Handles btnselesai.Click

        Dim detiltask As String = "Update trDetail_Task set IdStatusPerbaikan = '" & cbstatusperbaikan.Value & "', DateUpdate = GETDATE(), UserUpdate = '" & Session("UserName") & "' where NoListTask = '" & Request.QueryString("id") & "'"
        'Dim detiltask As String = "Update trDetail_Task set TglBerangkat = '" & berangkatsuk & "' where VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(detiltask, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        Dim updatestatustask As String = "update TrTask set IdStatusTask = '" & cbstatusperbaikan.Value & "', UserStamp = '" & Session("UserName") & "', DateStamp = GETDATE() where NoTask = '" & txtnotask.Text & "'"
        com = New SqlCommand(updatestatustask, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        groupstatusadmin.Visible = True
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    Protected Sub btnstatusdokumentasi_Click(sender As Object, e As EventArgs) Handles btnstatusdokumentasi.Click
        Dim updatestatus As String = "update trDetail_Task set statusdokumentasi = '" & cbstatusdokumentasi.Value & "' where VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(updatestatus, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        groupstatusadmin.Visible = True

        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    Protected Sub btnsurvey_Click(sender As Object, e As EventArgs) Handles btnsurvey.Click
        Dim updatesruvey As String = "update trDetail_Task set FlagDataSurvey=1,AlamatPengirimanSurvey = '" & txtalamatpengiriman.Value & "', TempatPenyimpananSurvey = '" & txttempatpenyimpanan.Value & "', NamaPICSurvey = '" & txtpicsurvey.Value & "', KontakPICSurvey = '" & txtnohppicsurvey.Value & "', PenempatanGroundingSurvey = '" & txtpenempatangrounding.Value & "', " & _
                                    "UkuranAntenaSurvey = '" & txtukuranantena.Value & "', TempatAntenaSurvey = '" & txttempatantena.Value & "', KekuatanRoofSurvey = '" & txtroof.Value & "', JenisMountingSurvey = '" & txtjenismountingantena.Value & "', LatitudeSurvey = '" & txtlatitudesurvey.Value & "', LongitudeSurvey = '" & txtlongitudesurvey.Value & "', " & _
                                    "ListrikAwalSurvey = '" & txtpengukuranlistrikawalsurvey.Value & "', SarpenACIndoorSurvey = '" & txtacindoorsurvey.Value & "', SarpenUPSSurvey = '" & txtsaranapendukungUPS.Value & "', PanjangKabelSurvey = '" & txtpanjangkabelsurvey.Value & "', TypeKabelSurvey = '" & cbtypekabelsurvey.Value & "', ArahAntenaSurvey = '" & txtarahantenasurvey.Value & "', " & _
                                    "StatusHasilSurvey = '" & txtstatussurvey.Value & "', KeteranganSurvey = '" & txtketsurvey.Value & "' where NoListTask = '" & Request.QueryString("id") & "'"
        com = New SqlCommand(updatesruvey, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        groupstatusperbaikan.Visible = True
        groupfoto.Visible = True
        groupstatusadmin.Visible = True
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    Protected Sub btnsimpaninstallasi_Click(sender As Object, e As EventArgs) Handles btnsimpaninstallasi.Click
        Dim updateinstallasi As String = "Update trDetail_Task set FlagDataInstallasi=1,DiameterAntena = '" & txtdiameterantena.Value & "', PolarisasiArahAntena = '" & txtpolarisasi.Value & "', ElevasiArahAntena = '" & txtelevasi.Value & "', AzimuthArahAntena = '" & txtazimuth.Value & "', SourceListrik = '" & cbsourcelistrik.Value & "', KabelRoll = '" & cbkabelroll.Value & "', PerangkatkeUPS = '" & cbupsindoor.Value & "', " & _
                                        "KVAUPS = '" & KVA.Value & "', FrequencyBandModulation = '" & cbfrequency.Value & "', IPManagement = '" & txtvsatmanagementipaddress.Value & "', ReceiveSymboleRate = '" & txtreceivesimbolrate.Value & "', PhaseNetralPLN = '" & txtphasanetralpln.Value & "', PhaseNetralUPS = '" & txtphasanetralups.Value & "', PhaseNetralGenset = '" & txtphasanetralgenset.Value & "', " & _
                                        "PhaseGroundPLN = '" & txtphasagroundpln.Value & "', PhaseGroundUPS = '" & txtphasagroundups.Value & "', PhaseGroundGenset = '" & txtphasagroundgenset.Value & "', NetralGroundPLN = '" & txtnetralgroundpln.Value & "', NetralGroundUPS  = '" & txtnetralgroundups.Value & "', NetralGroundGenset = '" & txtnetralgroundgenset.Value & "', SateliteLongitude = '" & txtsatelitelongitude.Value & "', " & _
                                        "IPLAN1 = '" & txtlan1.Value & "', subnetmask1 = '" & txtsubnetmask1.Value & "', IPLAN2 = '" & txtlan2.Value & "', subnetmask2 = '" & txtsubnetmask2.Value & "', HasilTestAlamat1 = '" & txtalamat1.Value & "', HasilTestAlamat2 = '" & txtalamat2.Value & "', HasilTestAlamat3 = '" & txtalamat3.Value & "', SuccessTest1 = '" & txtsuccess1.Value & "', SuccessTest2 = '" & txtsuccess2.Value & "', " & _
                                        "SuccessTest3 = '" & txtsuccess3.Value & "', LossTest1 = '" & txtloss1.Value & "', LossTest2 = '" & txtloss2.Value & "', LossTest3 = '" & txtloss3.Value & "', KeteranganTest1 = '" & txtket1.Value & "', KeteranganTest2 = '" & txtket2.Value & "', KeteranganTest3 = '" & txtket3.Value & "' where NoListTask = '" & Request.QueryString("id") & "'"
        com = New SqlCommand(updateinstallasi, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        groupdatabarangterpasang.Visible = True
        groupstatusperbaikan.Visible = True
        groupfoto.Visible = True
        groupstatusadmin.Visible = True
        groupsurvey.Visible = False
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub
End Class
