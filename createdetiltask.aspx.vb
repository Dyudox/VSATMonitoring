Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Bootstrap
'Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports DevExpress.Web.ASPxEdit
Imports System.IO
Imports System.Text
Imports System.IO.Compression
Imports System.Text.RegularExpressions

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

    'Protected WithEvents btn_detailexporttxt As Global.System.Web.UI.WebControls.Button

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Request.QueryString("status") = "Finish" Then
            Response.Redirect("viewpenyelesaiantask.aspx?ID=" & Request.QueryString("ID") & "&VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "&order=" & Request.QueryString("order") & "&status=" & Request.QueryString("status") & "")
        End If

        If Request.QueryString("VID") = "" Then
            If Session("UserName") = "" Then
                Response.Redirect("~/login.aspx")
            End If
        Else
            CariData(Request.QueryString("VID"))
        End If
        room_image()

    End Sub

    Private Sub CariGroup()
        'If Request.QueryString("order") = "PM" Or Request.QueryString("order") = "CM" Then
        groupdatalokasi.Visible = True
        groupgeneralinfo.Visible = False
        'groupdatateknis.Visible = True
        groupinstallasi.Visible = False
        groupsurvey.Visible = False
        'groupdatabarangterpasang.Visible = False
        groupfoto.Visible = True
        'groupstatusperbaikan.Visible = True
        groupstatusadmin.Visible = True
        'End If

        If Request.QueryString("order") = "SiteSurvey" Then
            groupsurvey.Visible = False
            groupdatateknis.Visible = False
            groupdatabarangterpasang.Visible = False
            groupstatusadmin.Visible = False
            groupdatalokasi.Visible = True
            groupgeneralinfo.Visible = False
            groupfoto.Visible = True
            'groupstatusperbaikan.Visible = True
            groupinstallasi.Visible = False
        End If

        If Request.QueryString("order") = "Installation" Then
            groupinstallasi.Visible = False
            groupsurvey.Visible = False
            groupdatabarangterpasang.Visible = True
            groupgeneralinfo.Visible = False
            groupdatateknis.Visible = True
            groupfoto.Visible = True
            'groupstatusperbaikan.Visible = True
        End If

        If Session("level") = "Teknisi" Then
            'groupstatusadmin.Visible = False
            groupdatateknis.Visible = False
            groupfoto.Visible = False
            'UpdatePanel1.Visible = False
            'groupstatusperbaikan.Visible = True
            groupstatusadmin.Visible = True
            groupinstallasi.Visible = False
            groupsurvey.Visible = False
            groupgeneralinfo.Visible = False
        End If

    End Sub
    Private Sub CariData(VID As String)
        Dim tampunghub As String = ""
        Dim getAlamatInstall As String = ""
        txtvid.Text = VID
        Dim getinfo As String = "SELECT trTask.*, " &
                                "CONVERT(date, trdetail_task.TglBerangkat) as Berangkat, " &
                                "convert(date, trdetail_task.TglPulang) as pulang, " &
                                "convert(date, trdetail_task.TglSelesaiKerjaan) as selesai, " &
                                "convert(date, trdetail_task.TglStatusPerbaikan) as stperbaikan  ,trDetail_Task.*, msStatus.Status AS StatusPekerjaan, trRemoteSite.AlamatInstall FROM trTask " &
                                "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " &
                                "LEFT OUTER JOIN trRemoteSite ON trTask.NoTask = trDetail_Task.NoTask " &
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

        'Get AlamatInstall
        getAlamatInstall = dr("AlamatInstall").ToString
        txtalamat.Value = getAlamatInstall

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
            strsql = "select * from mshub where hub='" & tampunghub & "'"
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
        Else
            dshub.SelectCommand = "select * from msHub"
            cbhub.DataBind()
        End If
        con.Close()

        Dim getdatalokasi As String = "select * from trRemoteSite where VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(getdatalokasi, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        getAlamatInstall = dr("AlamatInstall").ToString
        txtalamat.Value = dr("AlamatInstall").ToString
        txtPIC.Value = dr("CustPIC").ToString
        txtphonepic.Value = dr("CustPIC_Phone").ToString
        'txtidatm.value = dr("IdATM").ToString
        dr.Close()
        con.Close()

        'Validasi Data Lokasi
        If txtnamaremote.Value = Nothing Or txtalamat.Value = Nothing Or txtprovinsi.Value = Nothing Or txtkota.Value = Nothing Or
        txtkanwil.Value = Nothing Or txtkancainduk.Value = Nothing Or txtPIC.Value = Nothing Or txtphonepic.Value = Nothing Or
        txtidjarkom.Value = Nothing Or txtsatelit.Value = Nothing Or cbhub.Value = Nothing Or txtlatitude.Value = Nothing Or
        txtlongitude.Value = Nothing Or txtalamatsekarang.Value = Nothing Or txtcatatanlokasi.Value = Nothing Then
            DisableTab()
            Exit Sub

        End If

        'strsql=txtnotask.text & "|" & txtvid.text & "|" & txtSID.text & "|" & txtiplan.Value & "|" & txtidatm.Value & "|" &
        'txtstatuskoordinator.text & "|" & txttglpengaduan.Value & "|" & txtordertask.text & "|" & 
        'txttglberangkat.Value & "|" & txttglselesai.Value & "|" & txttglpulang.Value
        'clsg.writedata("Validasi General Info", strsql, "", "", "")

        'Validasi General Info
        If txtnotask.Text = Nothing Or txtvid.Text = Nothing Or txtiplan.Value = Nothing Or
        txtidatm.Value = Nothing Or txtstatuskoordinator.Text = Nothing Or txttglpengaduan.Value = Nothing Or
        txtordertask.Text = Nothing Or txttglberangkat.Value = Nothing Or txttglselesai.Value = Nothing Or txttglpulang.Value = Nothing Then
            groupdatalokasi.Visible = True
            groupgeneralinfo.Visible = False
            'Exit Sub

        End If

        'Validasi Data Teknis
        If txtfailHW.Value = Nothing Or txtSQF.Value = Nothing Or txtinitialesno.Value = Nothing Or txtCPI.Value = Nothing Or
            txtcarriertonotice.Value = Nothing Or txthasilxpoll.Value = Nothing Or txtoperatorsatelit.Value = Nothing Or
            txtoperatorhelpdesk.Value = Nothing Or txtoutpln.Value = Nothing Or txtaktifitassolusi.Value = Nothing Or txtoutups.Value = Nothing Or
            cbupsforbackup.Value = Nothing Or txtsuhuruangan.Value = Nothing Or txttypemounting.Value = Nothing Or txtpanjangkabel.Value = Nothing Or
            txtletakantena.Value = Nothing Or txtletakmodem.Value = Nothing Or txtkondisibangunan.Value = Nothing Or txtanalisaproblem.Value = Nothing Then
            groupdatalokasi.Visible = True
            groupgeneralinfo.Visible = False
            groupdatateknis.Visible = False
            If Request.QueryString("order") = "CM" Or Request.QueryString("order") = "PM" Then
                groupdatabarangterpasang.Visible = False
                groupfoto.Visible = True
                'groupstatusperbaikan.Visible = True
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
                groupgeneralinfo.Visible = False
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
        ' 'groupstatusperbaikan.Visible = True
        ' groupdatabarangterpasang.Visible = True
        ' groupfoto.Visible = True
        ' groupstatusadmin.Visible = True
        ' groupsurvey.Visible = False
        ' groupinstallasi.Visible = False
        'Else
        ' groupgeneralinfo.Visible = False
        ' groupdatateknis.Visible = False
        ' 'groupstatusperbaikan.Visible = False
        ' groupdatabarangterpasang.Visible = False
        ' groupfoto.Visible = False
        ' groupstatusadmin.Visible = False
        ' groupsurvey.Visible = False
        ' groupinstallasi.Visible = False
        'End If

        'AktifTab(Request.QueryString("order"))


    End Sub
    Private Sub DisableTab()
        groupdatalokasi.Visible = True
        groupgeneralinfo.Visible = False
        groupdatateknis.Visible = False
        groupinstallasi.Visible = False
        groupsurvey.Visible = False
        groupdatabarangterpasang.Visible = False
        groupfoto.Visible = False
        'groupstatusperbaikan.Visible = True
        groupstatusadmin.Visible = False
        strsql = "select * from trDetail_Task where NoListTask=" & Request.QueryString("ID") & ""
        tbldata = clsg.ExecuteQuery(strsql)
        'If tbldata.Rows(0).Item("FlagDataBarang") = True Then
        '    groupdatabarangterpasang.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagDataInstallasi") = True Then
        '    groupinstallasi.Visible = True
        'End If
        If tbldata.Rows(0).Item("FlagDataLokasi") = True Then
            groupdatalokasi.Visible = True
        End If
        'If tbldata.Rows(0).Item("FlagDataSurvey") = True Then
        '    groupsurvey.Visible = True
        'End If
        'If tbldata.Rows(0).Item("FlagDataTeknis") = True Then
        '    groupdatateknis.Visible = True
        '    groupfoto.Visible = True
        '    'groupstatusperbaikan.Visible = True
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
        '        'groupstatusperbaikan.Visible = False
        '        groupstatusadmin.Visible = False
        '    Else
        '        groupfoto.Visible = False
        '        'groupstatusperbaikan.Visible = False
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
                    'groupstatusperbaikan.Visible = True
                    groupstatusadmin.Visible = True
                Else
                    groupfoto.Visible = False
                    'groupstatusperbaikan.Visible = True
                    groupstatusadmin.Visible = True
                End If
            End Using
        End If

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            DisableTab()
            CariData(Request.QueryString("VID"))
            'Else
            '    CariData(Request.QueryString("VID"))
        End If

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
        'If Not Page.IsPostBack Then
        '    DisableTab()
        '    CariData(Request.QueryString("VID"))
        'Else
        '    CariData(Request.QueryString("VID"))
        'End If
        'groupfoto.Visible = true
        'groupdatabarangterpasang.Visible = False
        room_image()
        DisableGroupstatusperbaikan()
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
        'Response.Redirect("createdetiltask.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "")
    End Sub

    Sub DisableGroupstatusperbaikan()

        If Session("level") = "Teknisi" Then
            UpdatePanel1.Visible = False
            'btn_exportTxt.Visible = False
        ElseIf Session("level") = "Coordinator" Then
            groupdatateknis.Visible = False
            UpdatePanel1.Visible = False
            groupfoto.Visible = False
            'btn_exportTxt.Visible = False
        ElseIf Session("level") = "Manager" Then
            groupdatateknis.Visible = False
            UpdatePanel1.Visible = False
            groupfoto.Visible = False
            'btn_exportTxt.Visible = False
        ElseIf Session("level") = "Finance" Then
            groupdatateknis.Visible = False
            UpdatePanel1.Visible = False
            groupfoto.Visible = False
            'btn_exportTxt.Visible = False
        ElseIf Session("level") = "admin" Then
            groupdatateknis.Visible = False
            UpdatePanel1.Visible = False
            groupfoto.Visible = False
            'btn_exportTxt.Visible = False
        End If
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
            valueberangkat = txttglberangkat.Value
        End If

        If txttglpulang.Value = Nothing Then
            valuepulang = Date.Now
        Else
            valuepulang = txttglpulang.Value
        End If

        If txttglselesai.Value = Nothing Then
            valueselesai = Date.Now
        Else
            valueselesai = txttglselesai.Value
        End If

        If txttglpengaduan.Value = Nothing Then
            valuestatus = Date.Now
        Else
            valuestatus = txttglpengaduan.Value
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
        Try
            Dim updatehub As String = ""
            Dim getvaluehub As String = "select * from mshub where Hub = '" & cbhub.Value & "'"
            com = New SqlCommand(getvaluehub, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            updatehub = dr("Hub").ToString
            dr.Close()
            con.Close()

            Dim updatelokasi As String = "Update trDetail_Task set FlagDataLokasi=1,KANWIL = '" & txtkanwil.Value & "', KANCAINDUK = '" & txtkancainduk.Value & "', " &
                                          "NAMAREMOTE = '" & txtnamaremote.Value & "', ALAMAT = '" & txtalamat.Value & "', PROVINSI = '" & txtprovinsi.Value & "', " &
                                          "KOTA = '" & txtkota.Value & "', IdJarkom = '" & txtidjarkom.Value & "', IdSatelite = '" & txtsatelit.Value & "', PIC = '" & txtPIC.Value & "', " &
                                          "NoHpPic = '" & txtphonepic.Value & "', Hub = '" & updatehub & "', Latitude = '" & txtlatitude.Value & "', Longitude = '" & txtlongitude.Value & "', " &
                                          "AlamatSekarang = '" & txtalamatsekarang.Value & "', Catatan = '" & txtcatatanlokasi.InnerText & "', " &
                                          "TglBerangkat = '" & txttglberangkat.Value & "', TglPulang = '" & txttglpulang.Value & "', TglSelesaiKerjaan = '" & txttglselesai.Value & "' " &
                                          "where NoListTask = '" & Request.QueryString("id") & "'"
            com = New SqlCommand(updatelokasi, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()

            Dim updateremotesite As String = "Update trRemoteSite SET KANWIL = '" & txtkanwil.Value & "', KANCAINDUK = '" & txtkancainduk.Value & "', NAMAREMOTE = '" & txtnamaremote.Value & "', AlamatInstall = '" & txtalamat.Value & "', PROVINSI = '" & txtprovinsi.Value & "', KOTA = '" & txtkota.Value & "', IdJarkom = '" & txtidjarkom.Value & "', IdSatelite = '" & txtsatelit.Value & "', PIC = '" & txtPIC.Value & "', CustPIC = '" & txtPIC.Value & "', CustPIC_Phone = '" & txtphonepic.Value & "', Hub = '" & cbhub.Value & "', Latitude = '" & txtlatitude.Value & "', Longitude = '" & txtlongitude.Value & "' where VID = '" & Request.QueryString("VID") & "'"
            com = New SqlCommand(updateremotesite, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()

            '=== Show Success Message ===
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "success",
            "alert('✅ Data lokasi berhasil disimpan.');", True)

            If Request.QueryString("order") = "SiteSurvey" Then
                groupsurvey.Visible = True
            Else
                groupgeneralinfo.Visible = False
            End If

            groupdatateknis.Visible = True
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error",
            "alert('❌ Gagal menyimpan data: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
    End Sub

    Protected Sub btnsaveteknis_Click(sender As Object, e As EventArgs) Handles btnsaveteknis.Click
        Try
            Dim updateteknis As String = "Update trdetail_task set FlagDataTeknis=1,FAIL_HW = '" & txtfailHW.Value & "', SQF = '" & txtSQF.Value & "', INITIAL_ESNO = '" & txtinitialesno.Value & "', CARRIER_TO_NOICE = '" & txtcarriertonotice.Value & "', HasilXPOLL = '" & txthasilxpoll.Value & "', CPI = '" & txtCPI.Value & "', OperatorSatelite = '" & txtoperatorsatelit.Value & "', OperatorHelpDesk = '" & txtoperatorhelpdesk.Value & "', OutPLN = '" & txtoutpln.Value & "', OutUPS = '" & txtoutups.Value & "', UPSforBackup = '" & cbupsforbackup.Value & "', SuhuRuangan = '" & txtsuhuruangan.Value & "', TypeMounting = '" & txttypemounting.Value & "', PanjangKabel = '" & txtpanjangkabel.Value & "', LetakAntena = '" & txtletakantena.Value & "', LetakModem = '" & txtletakmodem.Value & "', KondisiBangungan = '" & txtkondisibangunan.Value & "', AnalisaProblem = '" & txtanalisaproblem.InnerText & "', AktifitasSolusi = '" & txtaktifitassolusi.InnerText & "' where NoListTask = '" & Request.QueryString("id") & "'"
            com = New SqlCommand(updateteknis, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()

            '=== Show Success Message ===
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "success",
            "alert('✅ Data Teknis berhasil disimpan.');", True)

            If Request.QueryString("order") = "Installation" Then
                groupinstallasi.Visible = False
            ElseIf Request.QueryString("order") = "CM" Or Request.QueryString("order") = "PM" Then
                groupdatabarangterpasang.Visible = False
                groupfoto.Visible = True
                'groupstatusperbaikan.Visible = True
                groupstatusadmin.Visible = True
            Else
                groupdatabarangterpasang.Visible = False
                'groupstatusperbaikan.Visible = True
                groupfoto.Visible = True
                groupstatusadmin.Visible = True
                groupinstallasi.Visible = False
            End If
            groupdatateknis.Visible = True
            UpdatePanel1.Visible = True
            'btn_exportTxt.Visible = True
            'groupstatusperbaikan.Visible = True
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error",
            "alert('❌ Gagal menyimpan data: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
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

            ' === Validasi field judul dan keterangan ===
            If String.IsNullOrWhiteSpace(txtjudulimage.Text) Then
                openTab()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert1",
                "alert('❌ Harap isi judul image.');", True)
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtketgambar.Value) Then
                openTab()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert2",
                "alert('❌ Harap isi keterangan gambar.');", True)
                Exit Sub
            End If

            ' === Validasi file upload ===
            Dim adaFile As Boolean = False
            For i As Integer = 0 To hfc.Count - 1
                Dim hpf As HttpPostedFile = hfc(i)
                If hpf.ContentLength > 0 Then
                    adaFile = True
                    Exit For
                End If
            Next

            If Not adaFile Then
                openTab()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert3",
                "alert('❌ Harap pilih file gambar terlebih dahulu.');", True)
                Exit Sub
            End If

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
                        cmd.Parameters.Add("@flagDetailTask", SqlDbType.VarChar).Value = Request.QueryString("VID") & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")

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
                        clsg.writedata(Session("UserName"), "Upload", "Foto", cmd.CommandText & "|" & Request.QueryString("VID") & "|" &
                                       "UploadFoto/" & Time & Replace(hpf.FileName, " ", "_") & "|" & Session("username") & "|" & txtjudulimage.Text & "|" &
                                       txtketgambar.InnerText & "|" & DocNo, "")
                        If j = hfc.Count Then
                            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
                            openTab()
                            Exit Sub
                        End If
                    End If
                End If
            Next
            openTab()
        Catch generatedExceptionName As Exception
            Throw
        End Try

        openTab()

        '' === Kontrol tampilan ===
        'If Request.QueryString("VID") = True Then
        '    groupdatateknis.Visible = True
        '    groupfoto.Visible = True
        '    UpdatePanel1.Visible = True
        '    Exit Sub
        'End If

        'groupdatateknis.Visible = True
        'groupfoto.Visible = True
        'UpdatePanel1.Visible = True

    End Sub

    'rizal
    Private Sub room_image()
        Dim strGambar As String
        Dim img As String
        'strGambar = "select * from trx_file where VID='" & Request.QueryString("VID") & "'"
        strGambar = "select * from trx_file where VID='" & Request.QueryString("VID") & "' And flagDetailTask <> ''"
        Try
            com = New SqlCommand(strGambar, con)
            con.Open()
            sqldr = com.ExecuteReader()
            'sqldr.Read()
            img = "<ul style='left: 0px; top: 0px;'>"
            While sqldr.Read()
                img &= "<li style='width: 200px; text-align:center'>" &
                            "<a href=" & sqldr("file_url") & "><img src=" & sqldr("file_url") & " style='max-height:200px;max-width:150px;min-height:200px;min-width:100px;'></a>" &
                            "<label style='color:Black'><b>" & sqldr("Description").ToString & "</b></label>" &
                            "<p>" & sqldr("Keterangan").ToString & "</p>" &
                            "<center><a class='label label-success' style='width:50%; align:center' href='editfoto.aspx?order=" & Request.QueryString("order") & "&id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&filename=" & sqldr("file_url") & "'>Edit</a></center>" &
                            "<center><a class='label label-danger' onclick='if (!UserCustomerConfirmation()) return false;' style='width:50%; align:center' href='createdetiltask.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&status=delete&filename=" & sqldr("file_url") & "'>Delete</a></center>" &
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

        Try
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
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnstatusdokumentasi_Click(sender As Object, e As EventArgs) Handles btnstatusdokumentasi.Click
        Try
            Dim updatestatus As String = "update trDetail_Task set statusdokumentasi = '" & cbstatusdokumentasi.Value & "' where VID = '" & Request.QueryString("VID") & "'"
            com = New SqlCommand(updatestatus, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()

            groupstatusadmin.Visible = True

            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnsurvey_Click(sender As Object, e As EventArgs) Handles btnsurvey.Click
        Dim updatesruvey As String = "update trDetail_Task set FlagDataSurvey=1,AlamatPengirimanSurvey = '" & txtalamatpengiriman.Value & "', TempatPenyimpananSurvey = '" & txttempatpenyimpanan.Value & "', NamaPICSurvey = '" & txtpicsurvey.Value & "', KontakPICSurvey = '" & txtnohppicsurvey.Value & "', PenempatanGroundingSurvey = '" & txtpenempatangrounding.Value & "', " &
                                    "UkuranAntenaSurvey = '" & txtukuranantena.Value & "', TempatAntenaSurvey = '" & txttempatantena.Value & "', KekuatanRoofSurvey = '" & txtroof.Value & "', JenisMountingSurvey = '" & txtjenismountingantena.Value & "', LatitudeSurvey = '" & txtlatitudesurvey.Value & "', LongitudeSurvey = '" & txtlongitudesurvey.Value & "', " &
                                    "ListrikAwalSurvey = '" & txtpengukuranlistrikawalsurvey.Value & "', SarpenACIndoorSurvey = '" & txtacindoorsurvey.Value & "', SarpenUPSSurvey = '" & txtsaranapendukungUPS.Value & "', PanjangKabelSurvey = '" & txtpanjangkabelsurvey.Value & "', TypeKabelSurvey = '" & cbtypekabelsurvey.Value & "', ArahAntenaSurvey = '" & txtarahantenasurvey.Value & "', " &
                                    "StatusHasilSurvey = '" & txtstatussurvey.Value & "', KeteranganSurvey = '" & txtketsurvey.Value & "' where NoListTask = '" & Request.QueryString("id") & "'"
        com = New SqlCommand(updatesruvey, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        'groupstatusperbaikan.Visible = True
        groupfoto.Visible = True
        groupstatusadmin.Visible = True
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    Protected Sub btnsimpaninstallasi_Click(sender As Object, e As EventArgs) Handles btnsimpaninstallasi.Click
        Dim updateinstallasi As String = "Update trDetail_Task set FlagDataInstallasi=1,DiameterAntena = '" & txtdiameterantena.Value & "', PolarisasiArahAntena = '" & txtpolarisasi.Value & "', ElevasiArahAntena = '" & txtelevasi.Value & "', AzimuthArahAntena = '" & txtazimuth.Value & "', SourceListrik = '" & cbsourcelistrik.Value & "', KabelRoll = '" & cbkabelroll.Value & "', PerangkatkeUPS = '" & cbupsindoor.Value & "', " &
                                        "KVAUPS = '" & KVA.Value & "', FrequencyBandModulation = '" & cbfrequency.Value & "', IPManagement = '" & txtvsatmanagementipaddress.Value & "', ReceiveSymboleRate = '" & txtreceivesimbolrate.Value & "', PhaseNetralPLN = '" & txtphasanetralpln.Value & "', PhaseNetralUPS = '" & txtphasanetralups.Value & "', PhaseNetralGenset = '" & txtphasanetralgenset.Value & "', " &
                                        "PhaseGroundPLN = '" & txtphasagroundpln.Value & "', PhaseGroundUPS = '" & txtphasagroundups.Value & "', PhaseGroundGenset = '" & txtphasagroundgenset.Value & "', NetralGroundPLN = '" & txtnetralgroundpln.Value & "', NetralGroundUPS  = '" & txtnetralgroundups.Value & "', NetralGroundGenset = '" & txtnetralgroundgenset.Value & "', SateliteLongitude = '" & txtsatelitelongitude.Value & "', " &
                                        "IPLAN1 = '" & txtlan1.Value & "', subnetmask1 = '" & txtsubnetmask1.Value & "', IPLAN2 = '" & txtlan2.Value & "', subnetmask2 = '" & txtsubnetmask2.Value & "', HasilTestAlamat1 = '" & txtalamat1.Value & "', HasilTestAlamat2 = '" & txtalamat2.Value & "', HasilTestAlamat3 = '" & txtalamat3.Value & "', SuccessTest1 = '" & txtsuccess1.Value & "', SuccessTest2 = '" & txtsuccess2.Value & "', " &
                                        "SuccessTest3 = '" & txtsuccess3.Value & "', LossTest1 = '" & txtloss1.Value & "', LossTest2 = '" & txtloss2.Value & "', LossTest3 = '" & txtloss3.Value & "', KeteranganTest1 = '" & txtket1.Value & "', KeteranganTest2 = '" & txtket2.Value & "', KeteranganTest3 = '" & txtket3.Value & "' where NoListTask = '" & Request.QueryString("id") & "'"
        com = New SqlCommand(updateinstallasi, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        groupdatabarangterpasang.Visible = True
        'groupstatusperbaikan.Visible = True
        groupfoto.Visible = True
        groupstatusadmin.Visible = True
        groupsurvey.Visible = False
        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    'Protected Sub btn_detailexporttxt_Click(sender As Object, e As EventArgs) Handles btn_detailexporttxt.Click
    'Protected Sub btn_detailexporttxt_Click(sender As Object, e As EventArgs)
    '    Try
    '        '=== 1. Siapkan folder export ===
    '        Dim exportFolder As String = Server.MapPath("~/Export_Txt/")
    '        If Not Directory.Exists(exportFolder) Then
    '            Directory.CreateDirectory(exportFolder)
    '        End If

    '        '=== 2. Nama file berdasarkan waktu ===
    '        Dim fileName As String = "DetailTask_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
    '        Dim filePath As String = Path.Combine(exportFolder, fileName)

    '        '=== 3. Buat StringBuilder untuk isi file ===
    '        Dim sb As New StringBuilder()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("DATA LOKASI")
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("Nama Remote       : " & txtnamaremote.Value)
    '        sb.AppendLine("Alamat Sekarang   : " & txtalamatsekarang.Value)
    '        sb.AppendLine("Alamat Instalasi  : " & txtalamat.Value)
    '        sb.AppendLine("Provinsi          : " & txtprovinsi.Value)
    '        sb.AppendLine("Kota / Kabupaten  : " & txtkota.Value)
    '        sb.AppendLine("Kanwil            : " & txtkanwil.Value)
    '        sb.AppendLine("Kanca Induk/Area  : " & txtkancainduk.Value)
    '        sb.AppendLine("Nama PIC          : " & txtPIC.Value)
    '        sb.AppendLine("Phone PIC         : " & txtphonepic.Value)
    '        sb.AppendLine("--------------------------------------------------")
    '        sb.AppendLine("ID Jarkom         : " & txtidjarkom.Value)
    '        sb.AppendLine("ID Satelit        : " & txtsatelit.Value)
    '        sb.AppendLine("Hub               : " & cbhub.Value)
    '        sb.AppendLine("Latitude          : " & txtlatitude.Value)
    '        sb.AppendLine("Longitude         : " & txtlongitude.Value)
    '        sb.AppendLine("Tanggal Berangkat : " & txttglberangkat.Text)
    '        sb.AppendLine("Tanggal Selesai   : " & txttglselesai.Text)
    '        sb.AppendLine("Tanggal Pulang    : " & txttglpulang.Text)
    '        sb.AppendLine("Catatan           : " & txtcatatanlokasi.Value)
    '        sb.AppendLine()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("DATA TEKNIS")
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("Hardware Rusak    : " & txtfailHW.Value)
    '        sb.AppendLine("SQF               : " & txtSQF.Value)
    '        sb.AppendLine("Initial Esno      : " & txtinitialesno.Value)
    '        sb.AppendLine("CPI               : " & txtCPI.Value)
    '        sb.AppendLine("C/N               : " & txtcarriertonotice.Value)
    '        sb.AppendLine("ASI               : " & txthasilxpoll.Value)
    '        sb.AppendLine("Operator Satelit  : " & txtoperatorsatelit.Value)
    '        sb.AppendLine("Operator Helpdesk : " & txtoperatorhelpdesk.Value)
    '        sb.AppendLine("Out PLN           : " & txtoutpln.Value)
    '        sb.AppendLine("Aktifitas Solusi  : " & txtaktifitassolusi.Value)
    '        sb.AppendLine("--------------------------------------------------")
    '        sb.AppendLine("Out UPS           : " & txtoutups.Value)
    '        sb.AppendLine("UPS For Backup    : " & cbupsforbackup.Value)
    '        sb.AppendLine("Suhu Ruangan      : " & txtsuhuruangan.Value)
    '        sb.AppendLine("Type Mounting     : " & txttypemounting.Value)
    '        sb.AppendLine("Panjang Kabel     : " & txtpanjangkabel.Value)
    '        sb.AppendLine("Letak Antena      : " & txtletakantena.Value)
    '        sb.AppendLine("Letak Modem       : " & txtletakmodem.Value)
    '        sb.AppendLine("Letak Antena Ke Satelit : " & txtkondisibangunan.Value)
    '        sb.AppendLine("Analisa Problem   : " & txtanalisaproblem.Value)
    '        sb.AppendLine()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("UPLOAD FOTO")
    '        sb.AppendLine("==================================================")

    '        Dim imgHtml As String = ltr_image_room.Text
    '        'Dim sb As New StringBuilder()

    '        ' Ambil semua blok gambar berdasarkan pola <a>..<label>..<p>
    '        Dim pattern As String = "(<a[^>]*><img[^>]*></a>.*?<label[^>]*>.*?</label>.*?<p[^>]*>.*?</p>)"
    '        Dim matches As MatchCollection = Regex.Matches(imgHtml, pattern, RegexOptions.Singleline Or RegexOptions.IgnoreCase)

    '        If matches.Count > 0 Then
    '            Dim i As Integer = 1
    '            For Each m As Match In matches
    '                Dim block As String = m.Value

    '                ' Ambil URL gambar
    '                Dim imgMatch As Match = Regex.Match(block, "<img[^>]*src=['""]?([^'""> ]+)['""]?", RegexOptions.IgnoreCase)
    '                Dim imgUrl As String = If(imgMatch.Success, imgMatch.Groups(1).Value, "-")

    '                ' Ambil nama file dari URL
    '                Dim fileNameOnly As String = If(imgUrl <> "-", Path.GetFileName(imgUrl), "-")

    '                ' Ambil Deskripsi
    '                Dim descMatch As Match = Regex.Match(block, "<label[^>]*><b>(.*?)</b></label>", RegexOptions.IgnoreCase)
    '                Dim desc As String = If(descMatch.Success, descMatch.Groups(1).Value.Trim(), "-")

    '                ' Ambil Keterangan
    '                Dim ketMatch As Match = Regex.Match(block, "<p[^>]*>(.*?)</p>", RegexOptions.IgnoreCase)
    '                Dim ket As String = If(ketMatch.Success, ketMatch.Groups(1).Value.Trim(), "-")

    '                ' Tambahkan ke hasil teks
    '                sb.AppendLine(i.ToString() & ". Deskripsi : " & desc)
    '                sb.AppendLine("   Keterangan : " & ket)
    '                sb.AppendLine("   URL : " & imgUrl)
    '                sb.AppendLine("   Nama File : " & fileNameOnly)
    '                sb.AppendLine()
    '                i += 1
    '            Next
    '        Else
    '            sb.AppendLine("Tidak ada foto diunggah.")
    '        End If

    '        sb.AppendLine()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("STATUS")
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("Status Pekerjaan   : " & cbstatusperbaikan.Text)
    '        sb.AppendLine("Status Dokumentasi : " & cbstatusdokumentasi.Text)

    '        '=== 5. Simpan ke file ===
    '        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)

    '        Dim bodyHtml As New StringBuilder()

    '        '=== Header email ===
    '        bodyHtml.AppendLine("<html><body style='font-family:Arial; font-size:13px;'>")
    '        bodyHtml.AppendLine("<h2 style='color:#004080;'>LAPORAN TASK VSAT</h2>")

    '        '=== DATA LOKASI ===
    '        bodyHtml.AppendLine("<h3 style='background:#f0f0f0; padding:5px;'>DATA LOKASI</h3>")
    '        bodyHtml.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%;'>")
    '        bodyHtml.AppendLine("<tr><td><b>Nama Remote</b></td><td>" & txtnamaremote.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Alamat Sekarang</b></td><td>" & txtalamatsekarang.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Alamat Instalasi</b></td><td>" & txtalamat.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Provinsi</b></td><td>" & txtprovinsi.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Kota / Kabupaten</b></td><td>" & txtkota.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Kanwil</b></td><td>" & txtkanwil.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Kanca Induk/Area</b></td><td>" & txtkancainduk.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Nama PIC</b></td><td>" & txtPIC.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Phone PIC</b></td><td>" & txtphonepic.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>ID Jarkom</b></td><td>" & txtidjarkom.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>ID Satelit</b></td><td>" & txtsatelit.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Hub</b></td><td>" & cbhub.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Latitude</b></td><td>" & txtlatitude.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Longitude</b></td><td>" & txtlongitude.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Tanggal Berangkat</b></td><td>" & txttglberangkat.Text & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Tanggal Selesai</b></td><td>" & txttglselesai.Text & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Tanggal Pulang</b></td><td>" & txttglpulang.Text & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Catatan</b></td><td>" & txtcatatanlokasi.Value & "</td></tr>")
    '        bodyHtml.AppendLine("</table><br>")

    '        '=== DATA TEKNIS ===
    '        bodyHtml.AppendLine("<h3 style='background:#f0f0f0; padding:5px;'>DATA TEKNIS</h3>")
    '        bodyHtml.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%;'>")
    '        bodyHtml.AppendLine("<tr><td><b>Hardware Rusak</b></td><td>" & txtfailHW.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>SQF</b></td><td>" & txtSQF.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Initial Esno</b></td><td>" & txtinitialesno.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>CPI</b></td><td>" & txtCPI.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>C/N</b></td><td>" & txtcarriertonotice.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>ASI</b></td><td>" & txthasilxpoll.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Operator Satelit</b></td><td>" & txtoperatorsatelit.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Operator Helpdesk</b></td><td>" & txtoperatorhelpdesk.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Out PLN</b></td><td>" & txtoutpln.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Aktifitas Solusi</b></td><td>" & txtaktifitassolusi.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Out UPS</b></td><td>" & txtoutups.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>UPS For Backup</b></td><td>" & cbupsforbackup.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Suhu Ruangan</b></td><td>" & txtsuhuruangan.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Type Mounting</b></td><td>" & txttypemounting.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Panjang Kabel</b></td><td>" & txtpanjangkabel.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Letak Antena</b></td><td>" & txtletakantena.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Letak Modem</b></td><td>" & txtletakmodem.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Letak Antena Ke Satelit</b></td><td>" & txtkondisibangunan.Value & "</td></tr>")
    '        bodyHtml.AppendLine("<tr><td><b>Analisa Problem</b></td><td>" & txtanalisaproblem.Value & "</td></tr>")
    '        bodyHtml.AppendLine("</table><br>")

    '        '=== Footer ===
    '        bodyHtml.AppendLine("<p style='color:#666; font-size:12px;'>Email ini dikirim otomatis oleh sistem VSAT Monitoring.</p>")
    '        'bodyHtml.AppendLine("</body></html>")


    '        '=== Tambahkan link foto ===
    '        bodyHtml.AppendLine("<h3>FOTO DOKUMENTASI</h3>")
    '        bodyHtml.AppendLine(ltr_image_room.Text)
    '        bodyHtml.AppendLine("<br/><hr/><i>Email ini dikirim otomatis oleh sistem VSAT Monitoring.</i>")
    '        bodyHtml.AppendLine("</body></html>")

    '        '=== 4. Buat URL file download ===
    '        Dim downloadUrl As String = ResolveUrl("~/DownloadTxt.ashx?file=" & fileName)
    '        Dim safeUrl As String = HttpUtility.JavaScriptStringEncode(downloadUrl)

    '        '=== 6. Isi otomatis form email di popup ===
    '        Dim subject As String = "Laporan Task - " & txtnamaremote.Value
    '        Dim body As String =
    '        "==================================================" & vbCrLf &
    '        "DATA LOKASI" & vbCrLf &
    '        "==================================================" & vbCrLf &
    '        "Nama Remote : " & txtnamaremote.Value & vbCrLf &
    '        "Alamat : " & txtalamat.Value & vbCrLf &
    '        "Provinsi : " & txtprovinsi.Value & vbCrLf &
    '        "Kota : " & txtkota.Value & vbCrLf &
    '        "..." & vbCrLf &
    '        "==================================================" & vbCrLf &
    '        "DATA TEKNIS" & vbCrLf &
    '        "==================================================" & vbCrLf &
    '        "SQF : " & txtSQF.Value & vbCrLf &
    '        "Hardware Rusak : " & txtfailHW.Value & vbCrLf &
    '        "CPI : " & txtCPI.Value & vbCrLf &
    '        vbCrLf & "=== File Lampiran ===" & vbCrLf &
    '        "~/Export_Txt/" & fileName

    '        '=== 7. Escape agar aman di JavaScript ===
    '        Dim subjectEsc As String = HttpUtility.JavaScriptStringEncode(subject)
    '        Dim bodyEsc As String = HttpUtility.JavaScriptStringEncode(body)

    '        '=== 8. Buat script show popup dan download ===
    '        Dim script As New StringBuilder()
    '        script.Append("showPopupAndDownload(")
    '        script.Append("'" & safeUrl.Replace("'", "\'") & "',")
    '        script.Append("'" & subjectEsc.Replace("'", "\'") & "',")
    '        script.Append("'" & bodyEsc.Replace("'", "\'") & "');")

    '        '=== 9. Jalankan popup di browser ===
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopupAndDownload", script.ToString(), True)



    '        openTab()
    '    Catch ex As Exception
    '        System.Diagnostics.Debug.WriteLine("Error Export TXT: " & ex.Message)
    '    End Try
    'End Sub

    Protected Sub btn_detailexporttxt_Click(sender As Object, e As EventArgs)
        Try
            '=== 1. Siapkan folder export ===
            Dim exportFolder As String = Server.MapPath("~/Export_Txt/")
            If Not Directory.Exists(exportFolder) Then
                Directory.CreateDirectory(exportFolder)
            End If

            '=== 2. Nama file berdasarkan waktu ===
            Dim fileName As String = "DetailTask_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
            Dim getFileNameTXT As String = fileName
            Dim filePath As String = Path.Combine(exportFolder, fileName)

            '=== 3. Buat StringBuilder untuk isi file ===
            Dim sb As New StringBuilder()

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("*DATA LOKASI*")
            sb.AppendLine("==================================================")
            sb.AppendLine("*Nama Remote       :* " & txtnamaremote.Value)
            sb.AppendLine("*Alamat Sekarang   :* " & txtalamatsekarang.Value)
            sb.AppendLine("*Alamat Instalasi  :* " & txtalamat.Value)
            sb.AppendLine("*Provinsi          :* " & txtprovinsi.Value)
            sb.AppendLine("*Kota / Kabupaten  :* " & txtkota.Value)
            sb.AppendLine("*Kanwil            :* " & txtkanwil.Value)
            sb.AppendLine("*Kanca Induk/Area  :* " & txtkancainduk.Value)
            sb.AppendLine("*Nama PIC          :* " & txtPIC.Value)
            sb.AppendLine("*Phone PIC         :* " & txtphonepic.Value)
            sb.AppendLine("--------------------------------------------------")
            sb.AppendLine("*ID Jarkom         :* " & txtidjarkom.Value)
            sb.AppendLine("*ID Satelit        :* " & txtsatelit.Value)
            sb.AppendLine("*Hub               :* " & cbhub.Value)
            sb.AppendLine("*Latitude          :* " & txtlatitude.Value)
            sb.AppendLine("*Longitude         :* " & txtlongitude.Value)
            sb.AppendLine("*Tanggal Berangkat :* " & txttglberangkat.Text)
            sb.AppendLine("*Tanggal Selesai   :* " & txttglselesai.Text)
            sb.AppendLine("*Tanggal Pulang    :* " & txttglpulang.Text)
            sb.AppendLine("*Catatan           :* " & txtcatatanlokasi.Value)
            sb.AppendLine()

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("*DATA TEKNIS*")
            sb.AppendLine("==================================================")
            sb.AppendLine("*Hardware Rusak    :* " & txtfailHW.Value)
            sb.AppendLine("*SQF               :* " & txtSQF.Value)
            sb.AppendLine("*Initial Esno      :* " & txtinitialesno.Value)
            sb.AppendLine("*CPI               :* " & txtCPI.Value)
            sb.AppendLine("*C/N               :* " & txtcarriertonotice.Value)
            sb.AppendLine("*ASI               :* " & txthasilxpoll.Value)
            sb.AppendLine("*Operator Satelit  :* " & txtoperatorsatelit.Value)
            sb.AppendLine("*Operator Helpdesk :* " & txtoperatorhelpdesk.Value)
            sb.AppendLine("*Out PLN           :* " & txtoutpln.Value)
            sb.AppendLine("*Aktifitas Solusi  :* " & txtaktifitassolusi.Value)
            sb.AppendLine("--------------------------------------------------")
            sb.AppendLine("*Out UPS           :* " & txtoutups.Value)
            sb.AppendLine("*UPS For Backup    :* " & cbupsforbackup.Value)
            sb.AppendLine("*Suhu Ruangan      :* " & txtsuhuruangan.Value)
            sb.AppendLine("*Type Mounting     :* " & txttypemounting.Value)
            sb.AppendLine("*Panjang Kabel     :* " & txtpanjangkabel.Value)
            sb.AppendLine("*Letak Antena      :* " & txtletakantena.Value)
            sb.AppendLine("*Letak Modem       :* " & txtletakmodem.Value)
            sb.AppendLine("*Letak Antena Ke Satelit :* " & txtkondisibangunan.Value)
            sb.AppendLine("*Analisa Problem   :* " & txtanalisaproblem.Value)
            sb.AppendLine()

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("UPLOAD FOTO")
            sb.AppendLine("==================================================")

            Dim imgHtml As String = ltr_image_room.Text
            Dim attachments As New List(Of String)()
            'Dim sb As New StringBuilder()

            ' Ambil semua blok gambar berdasarkan pola <a>..<label>..<p>
            Dim pattern As String = "(<a[^>]*><img[^>]*></a>.*?<label[^>]*>.*?</label>.*?<p[^>]*>.*?</p>)"
            Dim matches As MatchCollection = Regex.Matches(imgHtml, pattern, RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            If matches.Count > 0 Then
                Dim i As Integer = 1
                For Each m As Match In matches
                    Dim block As String = m.Value

                    ' Ambil URL gambar
                    Dim imgMatch As Match = Regex.Match(block, "<img[^>]*src=['""]?([^'""> ]+)['""]?", RegexOptions.IgnoreCase)
                    Dim imgUrl As String = If(imgMatch.Success, imgMatch.Groups(1).Value, "-")

                    ' Ambil nama file dari URL
                    Dim fileNameOnly As String = If(imgUrl <> "-", Path.GetFileName(imgUrl), "-")

                    ' Ambil Deskripsi
                    Dim descMatch As Match = Regex.Match(block, "<label[^>]*><b>(.*?)</b></label>", RegexOptions.IgnoreCase)
                    Dim desc As String = If(descMatch.Success, descMatch.Groups(1).Value.Trim(), "-")

                    ' Ambil Keterangan
                    Dim ketMatch As Match = Regex.Match(block, "<p[^>]*>(.*?)</p>", RegexOptions.IgnoreCase)
                    Dim ket As String = If(ketMatch.Success, ketMatch.Groups(1).Value.Trim(), "-")

                    ' Tambahkan ke hasil teks
                    sb.AppendLine(i.ToString() & ". Deskripsi : " & desc)
                    sb.AppendLine("   Keterangan : " & ket)
                    sb.AppendLine("   URL : " & imgUrl)
                    sb.AppendLine("   Nama File : " & fileNameOnly)
                    sb.AppendLine()

                    ' Tambahkan juga ke daftar lampiran
                    If imgUrl <> "-" Then
                        attachments.Add(imgUrl)
                    End If

                    i += 1
                Next
            Else
                sb.AppendLine("Tidak ada foto diunggah.")
            End If
            sb.AppendLine()

            '=== 3. Simpan TXT ke folder export
            Dim folderPath As String = Server.MapPath("~/Export_Txt/")
            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            'fileName = "Laporan_" & Now.ToString("yyyyMMdd_HHmmss") & ".txt"
            'filePath = Path.Combine(folderPath, fileName)
            'File.WriteAllText(filePath, sb.ToString())

            ''tambahkan txt ke attachment
            'attachments.Add("~/Export_Txt/" & fileName) 

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("STATUS")
            sb.AppendLine("==================================================")
            sb.AppendLine("Status Pekerjaan   : " & cbstatusperbaikan.Text)
            sb.AppendLine("Status Dokumentasi : " & cbstatusdokumentasi.Text)


            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)
            '=========end export txt========

            'Dim bodyHtml As New StringBuilder()

            ''=== Header email ===
            'bodyHtml.AppendLine("<html><body style='font-family:Arial; font-size:13px;'>")
            'bodyHtml.AppendLine("<h2 style='color:#004080;'>LAPORAN TASK VSAT</h2>")

            ''=== DATA LOKASI ===
            'bodyHtml.AppendLine("<h3 style='background:#f0f0f0; padding:5px;'>DATA LOKASI</h3>")
            'bodyHtml.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%;'>")
            'bodyHtml.AppendLine("<tr><td><b>Nama Remote</b></td><td>" & txtnamaremote.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Alamat Sekarang</b></td><td>" & txtalamatsekarang.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Alamat Instalasi</b></td><td>" & txtalamat.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Provinsi</b></td><td>" & txtprovinsi.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Kota / Kabupaten</b></td><td>" & txtkota.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Kanwil</b></td><td>" & txtkanwil.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Kanca Induk/Area</b></td><td>" & txtkancainduk.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Nama PIC</b></td><td>" & txtPIC.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Phone PIC</b></td><td>" & txtphonepic.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>ID Jarkom</b></td><td>" & txtidjarkom.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>ID Satelit</b></td><td>" & txtsatelit.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Hub</b></td><td>" & cbhub.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Latitude</b></td><td>" & txtlatitude.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Longitude</b></td><td>" & txtlongitude.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Tanggal Berangkat</b></td><td>" & txttglberangkat.Text & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Tanggal Selesai</b></td><td>" & txttglselesai.Text & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Tanggal Pulang</b></td><td>" & txttglpulang.Text & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Catatan</b></td><td>" & txtcatatanlokasi.Value & "</td></tr>")
            'bodyHtml.AppendLine("</table><br>")

            ''=== DATA TEKNIS ===
            'bodyHtml.AppendLine("<h3 style='background:#f0f0f0; padding:5px;'>DATA TEKNIS</h3>")
            'bodyHtml.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%;'>")
            'bodyHtml.AppendLine("<tr><td><b>Hardware Rusak</b></td><td>" & txtfailHW.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>SQF</b></td><td>" & txtSQF.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Initial Esno</b></td><td>" & txtinitialesno.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>CPI</b></td><td>" & txtCPI.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>C/N</b></td><td>" & txtcarriertonotice.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>ASI</b></td><td>" & txthasilxpoll.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Operator Satelit</b></td><td>" & txtoperatorsatelit.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Operator Helpdesk</b></td><td>" & txtoperatorhelpdesk.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Out PLN</b></td><td>" & txtoutpln.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Aktifitas Solusi</b></td><td>" & txtaktifitassolusi.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Out UPS</b></td><td>" & txtoutups.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>UPS For Backup</b></td><td>" & cbupsforbackup.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Suhu Ruangan</b></td><td>" & txtsuhuruangan.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Type Mounting</b></td><td>" & txttypemounting.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Panjang Kabel</b></td><td>" & txtpanjangkabel.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Letak Antena</b></td><td>" & txtletakantena.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Letak Modem</b></td><td>" & txtletakmodem.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Letak Antena Ke Satelit</b></td><td>" & txtkondisibangunan.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Analisa Problem</b></td><td>" & txtanalisaproblem.Value & "</td></tr>")
            'bodyHtml.AppendLine("</table><br>")

            ''=== Footer ===
            'bodyHtml.AppendLine("<p style='color:#666; font-size:12px;'>Email ini dikirim otomatis oleh sistem VSAT Monitoring.</p>")
            ''bodyHtml.AppendLine("</body></html>")


            ''=== Tambahkan link foto ===
            'bodyHtml.AppendLine("<h3>FOTO DOKUMENTASI</h3>")
            'bodyHtml.AppendLine(ltr_image_room.Text)
            'bodyHtml.AppendLine("<br/><hr/><i>Email ini dikirim otomatis oleh sistem VSAT Monitoring.</i>")
            'bodyHtml.AppendLine("</body></html>")

            '=== 6. Isi otomatis form email di popup modal ===
            Dim subject As String = "Laporan Task - " & txtnamaremote.Value

            Dim sbBody As New StringBuilder()
            sbBody.AppendLine("<div style='font-family:Arial, sans-serif; font-size:13px; color:#333;'>")

            '==================== DATA LOKASI ====================
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<h3 style='margin-bottom:0;'>DATA LOKASI</h3>")
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<p><b>Nama Remote:</b> " & txtnamaremote.Value & "<br>")
            sbBody.AppendLine("<b>Alamat:</b> " & txtalamat.Value & "<br>")
            sbBody.AppendLine("<b>Provinsi:</b> " & txtprovinsi.Value & "<br>")
            sbBody.AppendLine("<b>Kota:</b> " & txtkota.Value & "</p>")

            '==================== DATA TEKNIS ====================
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<h3 style='margin-bottom:0;'>DATA TEKNIS</h3>")
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<p><b>SQF:</b> " & txtSQF.Value & "<br>")
            sbBody.AppendLine("<b>Hardware Rusak:</b> " & txtfailHW.Value & "<br>")
            sbBody.AppendLine("<b>CPI:</b> " & txtCPI.Value & "</p>")

            '==================== FILE LAMPIRAN ====================
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<p><b>File Lampiran:</b><br>")

            '=== Buat string download convert to txt lengkap dengan path ~/Export_Txt/ ===
            'Dim downloadTxt As New List(Of String)
            'Dim fileNameTxt As String
            'For Each getFileNameTXT In filePath
            '    downloadTxt.Add("~/Export_Txt/" & getFileNameTXT)
            'Next

            '=== Buat string attachment lengkap dengan path ~/UploadFoto/ ===
            Dim attachmentsFull As New List(Of String)
            For Each fileName In attachments
                attachmentsFull.Add("~/UploadFoto/" & fileName)
            Next

            '=== Gabungkan menjadi satu string dengan separator ; ===
            Dim finalAttachments As String = String.Join(";", attachmentsFull)

            '=== Tampilkan di body email ===
            'Dim sbBody As New StringBuilder()
            If attachmentsFull.Count > 0 Then
                sbBody.AppendLine("<p>Attachment:<br>")
                sbBody.AppendLine(String.Join("<br>", attachments)) ' hanya nama file saja untuk body
                sbBody.AppendLine("</p>")
            Else
                sbBody.AppendLine("<i>Tidak ada lampiran</i><br>")
            End If

            Dim body As String = sbBody.ToString()
            Dim bodyEsc As String = body.Replace("\", "\\").Replace("'", "\'").Replace(vbCrLf, "\n")

            '=== JSON untuk popup multi attachment ===
            Dim jsonAttach As String = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(finalAttachments)
            Dim safeAttach As String = HttpUtility.JavaScriptStringEncode(jsonAttach)

            '=== Script panggil popup email ===
            'Dim downloadUrl As String = ResolveUrl("~/DownloadTxt.ashx?file=" & getFileNameTXT)
            Response.Redirect("~/DownloadTxt.ashx?file=" & getFileNameTXT, False)
            'Dim script As String = "showPopupAndDownload('" & downloadUrl.Replace("'", "\'") & "', " &
            '           "'" & safeAttach & "', " &
            '           "'" & HttpUtility.JavaScriptStringEncode(subject) & "', " &
            '           "'" & bodyEsc & "', " &
            '           "'" & HttpUtility.JavaScriptStringEncode("helpdesk@selindo.co.id") & "', " &
            '           "'" & HttpUtility.JavaScriptStringEncode("supervisor@selindo.co.id") & "', " &
            '           "'" & HttpUtility.JavaScriptStringEncode("") & "');"

            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopupAndDownload", script, True)

            'If attachments IsNot Nothing AndAlso attachments.Count > 0 Then
            '    For Each att In attachments
            '        sbBody.AppendLine(Path.GetFileName(att) & "<br>")
            '    Next
            'Else
            '    sbBody.AppendLine("<i>Tidak ada lampiran</i><br>")
            'End If
            'sbBody.AppendLine("</p>")

            'sbBody.AppendLine("</div>")

            ''==================== END FILE LAMPIRAN ====================


            ''==================== Get data modal popup email ====================

            ''===Path download hasil convert to txt kirim ke DownloadTxt.ashx dulu baru download txt  ===
            'Dim downloadUrl As String = ResolveUrl("~/DownloadTxt.ashx?file=" & fileName)

            ''ambil data attachment dari folder UploadFoto
            'Dim pathAttach As String = Path.Combine(Server.MapPath("~/UploadFoto/"), fileName)

            ''=== Simpan ke variable body HTML untuk popup ===
            'Dim body As String = sbBody.ToString()
            'Dim bodyEsc As String = body.Replace("\", "\\").Replace("'", "\'").Replace(vbCrLf, "\n")

            'Dim subjectEsc As String = HttpUtility.JavaScriptStringEncode(subject)
            'Dim toEsc As String = HttpUtility.JavaScriptStringEncode("helpdesk@selindo.co.id")
            'Dim ccEsc As String = HttpUtility.JavaScriptStringEncode("supervisor@selindo.co.id")
            'Dim bccEsc As String = HttpUtility.JavaScriptStringEncode("")
            'Dim safeUrl As String = HttpUtility.JavaScriptStringEncode(downloadUrl)

            ''=== Konversi list attachment ke JSON untuk popup multi attachment ===
            'Dim jsonAttach As String = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(attachments)
            'Dim safeAttach As String = HttpUtility.JavaScriptStringEncode(jsonAttach)

            ''=== Panggil popup email dengan multi attachment + download file export ===
            'Dim script As String = "showPopupAndDownload('" & safeUrl.Replace("'", "\'") & "', " &
            '                        "'" & safeAttach.Replace("'", "\'") & "', " &
            '                        "'" & subjectEsc.Replace("'", "\'") & "', " &
            '                        "'" & bodyEsc & "', " &
            '                        "'" & toEsc.Replace("'", "\'") & "', " &
            '                        "'" & ccEsc.Replace("'", "\'") & "', " &
            '                        "'" & bccEsc.Replace("'", "\'") & "');"

            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopupAndDownload", script, True)

            openTab()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error Export TXT: " & ex.Message)
        End Try
    End Sub

    Protected Sub btn_PrevExportTxt_Click(sender As Object, e As EventArgs)
        Try
            '=== 1. Siapkan folder export ===
            Dim exportFolder As String = Server.MapPath("~/Export_Txt/")
            If Not Directory.Exists(exportFolder) Then
                Directory.CreateDirectory(exportFolder)
            End If

            '=== 2. Nama file berdasarkan waktu ===
            Dim fileName As String = "DetailTask_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
            Dim getFileNameTXT As String = fileName
            Dim filePath As String = Path.Combine(exportFolder, fileName)

            '=== 3. Buat StringBuilder untuk isi file ===  sb.AppendLine("*" & titleText & "*")
            Dim sb As New StringBuilder()

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("DATA LOKASI")
            sb.AppendLine("==================================================")
            sb.AppendLine("Nama Remote       : " & txtnamaremote.Value)
            sb.AppendLine("Alamat Sekarang   :   " & txtalamatsekarang.Value)
            sb.AppendLine("Alamat Instalasi  : " & txtalamat.Value)
            sb.AppendLine("Provinsi          : " & txtprovinsi.Value)
            sb.AppendLine("Kota / Kabupaten  : " & txtkota.Value)
            sb.AppendLine("Kanwil            : " & txtkanwil.Value)
            sb.AppendLine("Kanca Induk/Area  : " & txtkancainduk.Value)
            sb.AppendLine("Nama PIC          : " & txtPIC.Value)
            sb.AppendLine("Phone PIC         : " & txtphonepic.Value)
            sb.AppendLine("--------------------------------------------------")
            sb.AppendLine("ID Jarkom         : " & txtidjarkom.Value)
            sb.AppendLine("ID Satelit        : " & txtsatelit.Value)
            sb.AppendLine("Hub               : " & cbhub.Value)
            sb.AppendLine("Latitude          : " & txtlatitude.Value)
            sb.AppendLine("Longitude         : " & txtlongitude.Value)
            sb.AppendLine("Tanggal Berangkat : " & txttglberangkat.Text)
            sb.AppendLine("Tanggal Selesai   : " & txttglselesai.Text)
            sb.AppendLine("Tanggal Pulang    : " & txttglpulang.Text)
            sb.AppendLine("Catatan           : " & txtcatatanlokasi.Value)
            sb.AppendLine()

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("DATA TEKNIS")
            sb.AppendLine("==================================================")
            sb.AppendLine("Hardware Rusak    : " & txtfailHW.Value)
            sb.AppendLine("SQF               : " & txtSQF.Value)
            sb.AppendLine("Initial Esno      : " & txtinitialesno.Value)
            sb.AppendLine("CPI               : " & txtCPI.Value)
            sb.AppendLine("C/N               : " & txtcarriertonotice.Value)
            sb.AppendLine("ASI               : " & txthasilxpoll.Value)
            sb.AppendLine("Operator Satelit  : " & txtoperatorsatelit.Value)
            sb.AppendLine("Operator Helpdesk : " & txtoperatorhelpdesk.Value)
            sb.AppendLine("Out PLN           : " & txtoutpln.Value)
            sb.AppendLine("Aktifitas Solusi  : " & txtaktifitassolusi.Value)
            sb.AppendLine("--------------------------------------------------")
            sb.AppendLine("Out UPS           : " & txtoutups.Value)
            sb.AppendLine("UPS For Backup    : " & cbupsforbackup.Value)
            sb.AppendLine("Suhu Ruangan      : " & txtsuhuruangan.Value)
            sb.AppendLine("Type Mounting     : " & txttypemounting.Value)
            sb.AppendLine("Panjang Kabel     : " & txtpanjangkabel.Value)
            sb.AppendLine("Letak Antena      : " & txtletakantena.Value)
            sb.AppendLine("Letak Modem       : " & txtletakmodem.Value)
            sb.AppendLine("Letak Antena Ke Satelit : " & txtkondisibangunan.Value)
            sb.AppendLine("Analisa Problem   : " & txtanalisaproblem.Value)
            sb.AppendLine()

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("UPLOAD FOTO")
            sb.AppendLine("==================================================")

            Dim imgHtml As String = ltr_image_room.Text
            Dim attachments As New List(Of String)()
            'Dim sb As New StringBuilder()

            ' Ambil semua blok gambar berdasarkan pola <a>..<label>..<p>
            Dim pattern As String = "(<a[^>]*><img[^>]*></a>.*?<label[^>]*>.*?</label>.*?<p[^>]*>.*?</p>)"
            Dim matches As MatchCollection = Regex.Matches(imgHtml, pattern, RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            If matches.Count > 0 Then
                Dim i As Integer = 1
                For Each m As Match In matches
                    Dim block As String = m.Value

                    ' Ambil URL gambar
                    Dim imgMatch As Match = Regex.Match(block, "<img[^>]*src=['""]?([^'""> ]+)['""]?", RegexOptions.IgnoreCase)
                    Dim imgUrl As String = If(imgMatch.Success, imgMatch.Groups(1).Value, "-")

                    ' Ambil nama file dari URL
                    Dim fileNameOnly As String = If(imgUrl <> "-", Path.GetFileName(imgUrl), "-")

                    ' Ambil Deskripsi
                    Dim descMatch As Match = Regex.Match(block, "<label[^>]*><b>(.*?)</b></label>", RegexOptions.IgnoreCase)
                    Dim desc As String = If(descMatch.Success, descMatch.Groups(1).Value.Trim(), "-")

                    ' Ambil Keterangan
                    Dim ketMatch As Match = Regex.Match(block, "<p[^>]*>(.*?)</p>", RegexOptions.IgnoreCase)
                    Dim ket As String = If(ketMatch.Success, ketMatch.Groups(1).Value.Trim(), "-")

                    ' Tambahkan ke hasil teks
                    sb.AppendLine(i.ToString() & ". Deskripsi : " & desc)
                    sb.AppendLine("   Keterangan : " & ket)
                    sb.AppendLine("   URL : " & imgUrl)
                    sb.AppendLine("   Nama File : " & fileNameOnly)
                    sb.AppendLine()

                    ' Tambahkan juga ke daftar lampiran
                    If imgUrl <> "-" Then
                        attachments.Add(imgUrl)
                    End If

                    i += 1
                Next
            Else
                sb.AppendLine("Tidak ada foto diunggah.")
            End If
            sb.AppendLine()

            '=== 3. Simpan TXT ke folder export
            Dim folderPath As String = Server.MapPath("~/Export_Txt/")
            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            'fileName = "Laporan_" & Now.ToString("yyyyMMdd_HHmmss") & ".txt"
            'filePath = Path.Combine(folderPath, fileName)
            'File.WriteAllText(filePath, sb.ToString())

            ''tambahkan txt ke attachment
            'attachments.Add("~/Export_Txt/" & fileName) 

            '====================================================================
            sb.AppendLine("==================================================")
            sb.AppendLine("STATUS")
            sb.AppendLine("==================================================")
            sb.AppendLine("Status Pekerjaan   : " & cbstatusperbaikan.Text)
            sb.AppendLine("Status Dokumentasi : " & cbstatusdokumentasi.Text)


            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)
            '=========end export txt========

            'Dim bodyHtml As New StringBuilder()

            ''=== Header email ===
            'bodyHtml.AppendLine("<html><body style='font-family:Arial; font-size:13px;'>")
            'bodyHtml.AppendLine("<h2 style='color:#004080;'>LAPORAN TASK VSAT</h2>")

            ''=== DATA LOKASI ===
            'bodyHtml.AppendLine("<h3 style='background:#f0f0f0; padding:5px;'>DATA LOKASI</h3>")
            'bodyHtml.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%;'>")
            'bodyHtml.AppendLine("<tr><td><b>Nama Remote</b></td><td>" & txtnamaremote.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Alamat Sekarang</b></td><td>" & txtalamatsekarang.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Alamat Instalasi</b></td><td>" & txtalamat.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Provinsi</b></td><td>" & txtprovinsi.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Kota / Kabupaten</b></td><td>" & txtkota.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Kanwil</b></td><td>" & txtkanwil.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Kanca Induk/Area</b></td><td>" & txtkancainduk.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Nama PIC</b></td><td>" & txtPIC.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Phone PIC</b></td><td>" & txtphonepic.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>ID Jarkom</b></td><td>" & txtidjarkom.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>ID Satelit</b></td><td>" & txtsatelit.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Hub</b></td><td>" & cbhub.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Latitude</b></td><td>" & txtlatitude.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Longitude</b></td><td>" & txtlongitude.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Tanggal Berangkat</b></td><td>" & txttglberangkat.Text & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Tanggal Selesai</b></td><td>" & txttglselesai.Text & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Tanggal Pulang</b></td><td>" & txttglpulang.Text & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Catatan</b></td><td>" & txtcatatanlokasi.Value & "</td></tr>")
            'bodyHtml.AppendLine("</table><br>")

            ''=== DATA TEKNIS ===
            'bodyHtml.AppendLine("<h3 style='background:#f0f0f0; padding:5px;'>DATA TEKNIS</h3>")
            'bodyHtml.AppendLine("<table border='1' cellpadding='5' cellspacing='0' style='border-collapse:collapse; width:100%;'>")
            'bodyHtml.AppendLine("<tr><td><b>Hardware Rusak</b></td><td>" & txtfailHW.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>SQF</b></td><td>" & txtSQF.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Initial Esno</b></td><td>" & txtinitialesno.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>CPI</b></td><td>" & txtCPI.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>C/N</b></td><td>" & txtcarriertonotice.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>ASI</b></td><td>" & txthasilxpoll.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Operator Satelit</b></td><td>" & txtoperatorsatelit.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Operator Helpdesk</b></td><td>" & txtoperatorhelpdesk.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Out PLN</b></td><td>" & txtoutpln.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Aktifitas Solusi</b></td><td>" & txtaktifitassolusi.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Out UPS</b></td><td>" & txtoutups.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>UPS For Backup</b></td><td>" & cbupsforbackup.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Suhu Ruangan</b></td><td>" & txtsuhuruangan.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Type Mounting</b></td><td>" & txttypemounting.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Panjang Kabel</b></td><td>" & txtpanjangkabel.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Letak Antena</b></td><td>" & txtletakantena.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Letak Modem</b></td><td>" & txtletakmodem.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Letak Antena Ke Satelit</b></td><td>" & txtkondisibangunan.Value & "</td></tr>")
            'bodyHtml.AppendLine("<tr><td><b>Analisa Problem</b></td><td>" & txtanalisaproblem.Value & "</td></tr>")
            'bodyHtml.AppendLine("</table><br>")

            ''=== Footer ===
            'bodyHtml.AppendLine("<p style='color:#666; font-size:12px;'>Email ini dikirim otomatis oleh sistem VSAT Monitoring.</p>")
            ''bodyHtml.AppendLine("</body></html>")


            ''=== Tambahkan link foto ===
            'bodyHtml.AppendLine("<h3>FOTO DOKUMENTASI</h3>")
            'bodyHtml.AppendLine(ltr_image_room.Text)
            'bodyHtml.AppendLine("<br/><hr/><i>Email ini dikirim otomatis oleh sistem VSAT Monitoring.</i>")
            'bodyHtml.AppendLine("</body></html>")

            '=== 6. Isi otomatis form email di popup modal ===      sb.AppendLine("*" & lbl & " :* " & val)
            '"<label[^>]*>LAPORAN PEKERJAAN.*?<\/label>"
            Dim subject As String = "Laporan Task - " & txtnamaremote.Value

            Dim sbBody As New StringBuilder()
            sbBody.AppendLine("<div style='font-family:Arial, sans-serif; font-size:13px; color:#333;'>")

            '==================== DATA LOKASI ====================
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<h3 style='margin-bottom:0;'>DATA LOKASI</h3>")
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<p><b>Nama Remote    :</b> " & txtnamaremote.Value & "<br>")
            sbBody.AppendLine("<b>Alamat            :</b> " & txtalamat.Value & "<br>")
            sbBody.AppendLine("<b>Provinsi          :</b> " & txtprovinsi.Value & "<br>")
            sbBody.AppendLine("<b>Kota              :</b> " & txtkota.Value & "<br>")
            sbBody.AppendLine("<b>Alamat Sekarang   :</b> " & txtalamatsekarang.Value & "<br>")
            sbBody.AppendLine("<b>Alamat Instalasi  :</b> " & txtalamat.Value & "<br>")
            sbBody.AppendLine("<b>Provinsi          :</b> " & txtprovinsi.Value & "<br>")
            sbBody.AppendLine("<b>Kota / Kabupaten  :</b> " & txtkota.Value & "<br>")
            sbBody.AppendLine("<b>Kanwil            :</b> " & txtkanwil.Value & "<br>")
            sbBody.AppendLine("<b>Kanca Induk/Area  :</b> " & txtkancainduk.Value & "<br>")
            sbBody.AppendLine("<b>Nama PIC          :</b> " & txtPIC.Value & "<br>")
            sbBody.AppendLine("<b>Phone PIC         :</b> " & txtphonepic.Value & "<br>")
            sbBody.AppendLine("--------------------------------------------------" & "<br>")
            sbBody.AppendLine("<b>ID Jarkom         :</b> " & txtidjarkom.Value & "<br>")
            sbBody.AppendLine("<b>ID Satelit        :</b> " & txtsatelit.Value & "<br>")
            sbBody.AppendLine("<b>Hub               :</b> " & cbhub.Value & "<br>")
            sbBody.AppendLine("<b>Latitude          :</b> " & txtlatitude.Value & "<br>")
            sbBody.AppendLine("<b>Longitude         :</b> " & txtlongitude.Value & "<br>")
            sbBody.AppendLine("<b>Tanggal Berangkat :</b> " & txttglberangkat.Text & "<br>")
            sbBody.AppendLine("<b>Tanggal Selesai   :</b> " & txttglselesai.Text & "<br>")
            sbBody.AppendLine("<b>Tanggal Pulang    :</b> " & txttglpulang.Text & "<br>")
            sbBody.AppendLine("<b>Catatan           :</b> " & txtcatatanlokasi.Value & "</p>")

            '==================== DATA TEKNIS ====================
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<h3 style='margin-bottom:0;'>DATA TEKNIS</h3>")
            sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            sbBody.AppendLine("<p><b>SQF            :</b> " & txtSQF.Value & "<br>")
            sbBody.AppendLine("<b>Hardware Rusak    :</b> " & txtfailHW.Value & "<br>")
            sbBody.AppendLine("<b>CPI               :</b> " & txtCPI.Value & "<br>")
            sbBody.AppendLine("<b>C/N               :</b> " & txtcarriertonotice.Value & "<br>")
            sbBody.AppendLine("<b>ASI               :</b> " & txthasilxpoll.Value & "<br>")
            sbBody.AppendLine("<b>Operator Satelit  :</b> " & txtoperatorsatelit.Value & "<br>")
            sbBody.AppendLine("<b>Operator Helpdesk :</b> " & txtoperatorhelpdesk.Value & "<br>")
            sbBody.AppendLine("<b>Out PLN           :</b> " & txtoutpln.Value & "<br>")
            sbBody.AppendLine("<b>Aktifitas Solusi  :</b> " & txtaktifitassolusi.Value & "<br>")
            sbBody.AppendLine("--------------------------------------------------" & "<br>")
            sbBody.AppendLine("<b>Out UPS           :</b> " & txtoutups.Value & "<br>")
            sbBody.AppendLine("<b>UPS For Backup    :</b> " & cbupsforbackup.Value & "<br>")
            sbBody.AppendLine("<b>Suhu Ruangan      :</b> " & txtsuhuruangan.Value & "<br>")
            sbBody.AppendLine("<b>Type Mounting     :</b> " & txttypemounting.Value & "<br>")
            sbBody.AppendLine("<b>Panjang Kabel     :</b> " & txtpanjangkabel.Value & "<br>")
            sbBody.AppendLine("<b>Letak Antena      :</b> " & txtletakantena.Value & "<br>")
            sbBody.AppendLine("<b>Letak Modem       :</b> " & txtletakmodem.Value & "<br>")
            sbBody.AppendLine("<b>Letak Antena Ke Satelit :</b> " & txtkondisibangunan.Value & "<br>")
            sbBody.AppendLine("<b>Analisa Problem   :</b> " & txtanalisaproblem.Value & "</p>")
            sbBody.AppendLine()

            '==================== FILE LAMPIRAN ====================
            'sbBody.AppendLine("<hr style='border:1px solid #999;'>")
            'sbBody.AppendLine("<p><b>File Lampiran:</b><br>")

            '=== Buat string download convert to txt lengkap dengan path ~/Export_Txt/ ===
            'Dim downloadTxt As New List(Of String)
            'Dim fileNameTxt As String
            'For Each getFileNameTXT In filePath
            '    downloadTxt.Add("~/Export_Txt/" & getFileNameTXT)
            'Next

            '=== Buat string attachment lengkap dengan path ~/UploadFoto/ ===
            Dim attachmentsFull As New List(Of String)
            For Each fileName In attachments
                attachmentsFull.Add("~/UploadFoto/" & fileName)
            Next

            '=== Gabungkan menjadi satu string dengan separator ; ===
            Dim finalAttachments As String = String.Join(";", attachmentsFull)

            '=== Tampilkan di body email ===
            'Dim sbBody As New StringBuilder()
            If attachmentsFull.Count > 0 Then
                sbBody.AppendLine("<p><b>File Lampiran:<b><br>")
                sbBody.AppendLine(String.Join("<br>", attachments)) ' hanya nama file saja untuk body
                sbBody.AppendLine("</p>")
            Else
                sbBody.AppendLine("<i>Tidak ada lampiran</i><br>")
            End If

            Dim body As String = sbBody.ToString()
            Dim bodyEsc As String = body.Replace("\", "\\").Replace("'", "\'").Replace(vbCrLf, "\n")

            '=== JSON untuk popup multi attachment ===
            Dim jsonAttach As String = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(finalAttachments)
            Dim safeAttach As String = HttpUtility.JavaScriptStringEncode(jsonAttach)

            '=== Script panggil popup email ===
            Dim downloadUrl As String = ""
            Dim script As String = "showPopupAndDownload('" & downloadUrl.Replace("'", "\'") & "', " &
                       "'" & safeAttach & "', " &
                       "'" & HttpUtility.JavaScriptStringEncode(subject) & "', " &
                       "'" & bodyEsc & "', " &
                       "'" & HttpUtility.JavaScriptStringEncode("helpdesk@selindo.co.id") & "', " &
                       "'" & HttpUtility.JavaScriptStringEncode("supervisor@selindo.co.id") & "', " &
                       "'" & HttpUtility.JavaScriptStringEncode("") & "');"

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopupAndDownload", script, True)

            'If attachments IsNot Nothing AndAlso attachments.Count > 0 Then
            '    For Each att In attachments
            '        sbBody.AppendLine(Path.GetFileName(att) & "<br>")
            '    Next
            'Else
            '    sbBody.AppendLine("<i>Tidak ada lampiran</i><br>")
            'End If
            'sbBody.AppendLine("</p>")

            'sbBody.AppendLine("</div>")

            ''==================== END FILE LAMPIRAN ====================


            ''==================== Get data modal popup email ====================

            ''===Path download hasil convert to txt kirim ke DownloadTxt.ashx dulu baru download txt  ===
            'Dim downloadUrl As String = ResolveUrl("~/DownloadTxt.ashx?file=" & fileName)

            ''ambil data attachment dari folder UploadFoto
            'Dim pathAttach As String = Path.Combine(Server.MapPath("~/UploadFoto/"), fileName)

            ''=== Simpan ke variable body HTML untuk popup ===
            'Dim body As String = sbBody.ToString()
            'Dim bodyEsc As String = body.Replace("\", "\\").Replace("'", "\'").Replace(vbCrLf, "\n")

            'Dim subjectEsc As String = HttpUtility.JavaScriptStringEncode(subject)
            'Dim toEsc As String = HttpUtility.JavaScriptStringEncode("helpdesk@selindo.co.id")
            'Dim ccEsc As String = HttpUtility.JavaScriptStringEncode("supervisor@selindo.co.id")
            'Dim bccEsc As String = HttpUtility.JavaScriptStringEncode("")
            'Dim safeUrl As String = HttpUtility.JavaScriptStringEncode(downloadUrl)

            ''=== Konversi list attachment ke JSON untuk popup multi attachment ===
            'Dim jsonAttach As String = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(attachments)
            'Dim safeAttach As String = HttpUtility.JavaScriptStringEncode(jsonAttach)

            ''=== Panggil popup email dengan multi attachment + download file export ===
            'Dim script As String = "showPopupAndDownload('" & safeUrl.Replace("'", "\'") & "', " &
            '                        "'" & safeAttach.Replace("'", "\'") & "', " &
            '                        "'" & subjectEsc.Replace("'", "\'") & "', " &
            '                        "'" & bodyEsc & "', " &
            '                        "'" & toEsc.Replace("'", "\'") & "', " &
            '                        "'" & ccEsc.Replace("'", "\'") & "', " &
            '                        "'" & bccEsc.Replace("'", "\'") & "');"

            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopupAndDownload", script, True)

            openTab()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "PrevError",
            "alert('Gagal Preview: " & ex.Message.Replace("'", "") & "');", True)
        End Try
    End Sub

    Sub openTab()
        groupdatateknis.Visible = True
        groupfoto.Visible = True
        UpdatePanel1.Visible = True
        groupstatusadmin.Visible = True
    End Sub

    ' Variabel global untuk menyimpan body email
    Private Property bodyHtml As String
        Get
            Return If(ViewState("bodyHtml"), "")
        End Get
        Set(value As String)
            ViewState("bodyHtml") = value
        End Set
    End Property

    Private Sub KirimEmailOutboxMulti(
    ByVal toList As IEnumerable(Of String),
    ByVal ccList As IEnumerable(Of String),
    ByVal bccList As IEnumerable(Of String),
    ByVal subject As String,
    ByVal bodyHtml As String,
    ByVal attachments As List(Of String)
)
        Try
            Dim connStr As String = ConfigurationManager.ConnectionStrings("iMailConnection").ConnectionString

            Using con As New SqlConnection(connStr)
                con.Open()

                'gabungkan penerima jadi string dengan koma
                Dim toStr As String = String.Join(";", toList)
                Dim ccStr As String = String.Join(";", ccList)
                Dim bccStr As String = String.Join(";", bccList)
                ' Gabungkan menjadi satu string
                Dim finalAttachments As String = String.Join(";", attachments)

                ' === Handle attachment path ===
                'Dim relativePath As String = finalAttachments
                'If attachments IsNot Nothing AndAlso attachments.Count > 0 Then
                '    Dim firstFile As String = attachments.FirstOrDefault()
                '    If Not String.IsNullOrEmpty(firstFile) Then
                '        relativePath = "~/UploadFoto/" & Path.GetFileName(firstFile)
                '    End If
                'End If

                Dim sql As String = "INSERT INTO ICC_EMAIL_OUT " &
                "(EMAIL_ID, DIRECTION, EFROM, ETO, ECC, EBCC, ESUBJECT, EBODY_HTML, ROUTED, HANDLED, Email_Date, Flag, UserID, Path, ATTACHMENT_ID, JENIS_EMAIL) " &
                "VALUES " &
                "(@EMAIL_ID, @DIRECTION, @EFROM, @ETO, @ECC, @EBCC, @ESUBJECT, @EBODY_HTML, @ROUTED, @HANDLED, @Email_Date, @Flag, @UserID, @Path, @ATTACHMENT_ID, @JENIS_EMAIL)"

                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@EMAIL_ID", Guid.NewGuid().ToString())
                    cmd.Parameters.AddWithValue("@DIRECTION", "OUT")
                    cmd.Parameters.AddWithValue("@EFROM", "rsgsystem@selindo.com")
                    cmd.Parameters.AddWithValue("@ETO", toStr)
                    cmd.Parameters.AddWithValue("@ECC", ccStr)
                    cmd.Parameters.AddWithValue("@EBCC", bccStr)
                    cmd.Parameters.AddWithValue("@ESUBJECT", subject)
                    cmd.Parameters.AddWithValue("@EBODY_HTML", bodyHtml)
                    '' Gunakan NVARCHAR(MAX) agar isi HTML tidak terpotong
                    'cmd.Parameters.Add("@EBODY_HTML", SqlDbType.NVarChar).Value = bodyHtml

                    cmd.Parameters.AddWithValue("@ROUTED", "N")
                    cmd.Parameters.AddWithValue("@HANDLED", "N")
                    cmd.Parameters.AddWithValue("@Email_Date", DateTime.Now)
                    cmd.Parameters.AddWithValue("@Flag", "N")
                    cmd.Parameters.AddWithValue("@UserID", Session("UserName"))
                    cmd.Parameters.AddWithValue("@Path", finalAttachments)
                    cmd.Parameters.AddWithValue("@ATTACHMENT_ID", finalAttachments)
                    cmd.Parameters.AddWithValue("@JENIS_EMAIL", "LAPORAN TASK")

                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error insert email multi: " & ex.Message)
        End Try
    End Sub

    'Protected Sub btn_testModal_Click(sender As Object, e As EventArgs)

    '    'lblMessage.Text = "Data lokasi berhasil disimpan!"
    '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopup", "popupEmailEndless.Show();", True)
    'End Sub

    Public Function replaceParty(ByVal str2 As String) As String
        Dim TmpStr As String = str2

        ' Hapus angka tertentu
        TmpStr = Replace(TmpStr, "~/UploadFoto", "")
        TmpStr = Replace(TmpStr, "00000", "")
        TmpStr = Replace(TmpStr, "000008", "")
        TmpStr = Replace(TmpStr, "00000187", "")

        ' Ganti karakter dengan spasi
        TmpStr = Replace(TmpStr, """", "")
        TmpStr = Replace(TmpStr, "!", " ")
        TmpStr = Replace(TmpStr, ":", " ")
        'TmpStr = Replace(TmpStr, ";", " ")
        TmpStr = Replace(TmpStr, vbCrLf, " ")
        TmpStr = Replace(TmpStr, vbLf, " ")

        ' Bisa tambahkan replace lain jika perlu
        ' TmpStr = Replace(TmpStr, "\", " ")
        ' TmpStr = Replace(TmpStr, ".", " ")

        Return TmpStr
    End Function

    Protected Sub btnSendEmail_ServerClick(sender As Object, e As EventArgs)
        Try
            Dim toList = txtToEmail.Value.Split(";"c).Where(Function(x) x.Trim() <> "").ToList()
            Dim ccList = txtCcEmail.Value.Split(";"c).Where(Function(x) x.Trim() <> "").ToList()
            Dim bccList = txtBccEmail.Value.Split(";"c).Where(Function(x) x.Trim() <> "").ToList()

            ' Parse JSON array dari hidden field txtAttachmentEmail
            Dim attachments As New List(Of String)
            If Not String.IsNullOrEmpty(txtAttachmentEmail.Value) Then
                Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
                Try
                    txtAttachmentEmail.Value = replaceParty(txtAttachmentEmail.Value)
                    attachments = serializer.Deserialize(Of List(Of String))(txtAttachmentEmail.Value)
                Catch ex As Exception
                    ' jika bukan JSON array, anggap 1 file
                    txtAttachmentEmail.Value = replaceParty(txtAttachmentEmail.Value)
                    attachments.Add(txtAttachmentEmail.Value)
                End Try
            End If

            ' --- Pisahkan file export (~) dan foto
            Dim photoFiles As New List(Of String)
            Dim exportFile As String = Nothing

            If attachments IsNot Nothing AndAlso attachments.Count > 0 Then
                For Each f In attachments
                    If Not String.IsNullOrWhiteSpace(f) AndAlso f.Length > 3 Then
                        If f.StartsWith("~/") Then
                            ' hapus ~
                            exportFile = f.Substring(2)
                        Else
                            photoFiles.Add(f)
                        End If
                    End If
                Next
            End If

            ' Gabungkan semua file untuk insert
            Dim finalAttachments As New List(Of String)
            finalAttachments.AddRange(photoFiles)
            If exportFile IsNot Nothing Then finalAttachments.Add(exportFile)

            ' Panggil fungsi insert email
            KirimEmailOutboxMulti(toList, ccList, bccList,
                              txtSubjectEmail.Value,
                              txtBodyEmail.Value,
                              finalAttachments)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EmailSuccess",
            "alert('Email berhasil dikirim ke Outbox!');", True)
            openTab()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error",
            "alert('Gagal kirim email: " & ex.Message.Replace("'", "") & "');", True)
        End Try
    End Sub


    'Protected Sub btnSendEmail_ServerClick(sender As Object, e As EventArgs)
    '    Try
    '        Dim toList = txtToEmail.Value.Split(";"c).Where(Function(x) x.Trim() <> "").ToList()
    '        Dim ccList = txtCcEmail.Value.Split(";"c).Where(Function(x) x.Trim() <> "").ToList()
    '        Dim bccList = txtBccEmail.Value.Split(";"c).Where(Function(x) x.Trim() <> "").ToList()

    '        Dim attachments As New List(Of String)
    '        attachments.Add(txtAttachmentEmail.Value)

    '        'Panggil fungsi insert email kamu
    '        KirimEmailOutboxMulti(toList, ccList, bccList,
    '                          txtSubjectEmail.Value,
    '                          txtBodyEmail.Value,
    '                          attachments)

    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "EmailSuccess",
    '        "alert('Email berhasil dikirim ke Outbox!');", True)

    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error",
    '        "alert('Gagal kirim email: " & ex.Message.Replace("'", "") & "');", True)
    '    End Try
    'End Sub

    Protected Sub btnSendEmail2_ServerClick(sender As Object, e As EventArgs)
        Try
            '=== Ambil nilai dari popup ===
            Dim toList As New List(Of String)
            Dim ccList As New List(Of String)
            Dim bccList As New List(Of String)
            Dim attachments As New List(Of String)

            '=== Ambil alamat email ===
            If Not String.IsNullOrWhiteSpace(txtToEmail.Value) Then
                toList = txtToEmail.Value.Split(";", ","c).Select(Function(x) x.Trim()).Where(Function(x) x <> "").ToList()
            End If

            If Not String.IsNullOrWhiteSpace(txtCcEmail.Value) Then
                ccList = txtCcEmail.Value.Split(";", ","c).Select(Function(x) x.Trim()).Where(Function(x) x <> "").ToList()
            End If

            '=== Ambil file hasil export ===
            Dim exportFolder As String = Server.MapPath("~/Export_Txt/")
            Dim fileName As String = TryCast(ViewState("ExportedFileName"), String)
            Dim fullPath As String = Path.Combine(exportFolder, fileName)

            If File.Exists(fullPath) Then
                attachments.Add(fullPath)
            End If

            '=== Kirim ke fungsi KirimEmailOutboxMulti ===
            KirimEmailOutboxMulti(
                toList,
                ccList,
                bccList,
                txtSubjectEmail.Value,
                txtBodyEmail.Value,
                attachments
            )

            '=== Beri notifikasi sukses ===
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "successEmail",
                "alert('Email laporan task berhasil dikirim ke outbox.'); popupEmailEndless.Hide();", True)

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error",
            "alert('Gagal kirim email: " & ex.Message.Replace("'", "") & "');", True)
        End Try
    End Sub

    'Protected Sub btnSendEmail_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim toList As New List(Of String)(txtToEmail.Text.Split(";"c))
    '        Dim ccList As New List(Of String)(txtCcEmail.Text.Split(";"c))
    '        Dim attachments As New List(Of String)
    '        Dim subject As String = txtSubjectEmail.Text
    '        Dim bodyHtml As String = txtBodyEmail.Text.Replace(vbCrLf, "<br>")

    '        KirimEmailOutboxMulti(toList, ccList, New List(Of String), subject, bodyHtml, attachments)

    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "success",
    '        "popupEmailEndless.Hide(); alert('Email berhasil dikirim ke Helpdesk!');", True)

    '    Catch ex As Exception
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "error",
    '        "alert('Gagal kirim email: " & ex.Message.Replace("'", "") & "');", True)
    '    End Try
    'End Sub


    'Protected Sub btn_exportTxt_Click(sender As Object, e As EventArgs) Handles btn_exportTxt.Click
    '    Try
    '        '=== 1. Siapkan folder export ===
    '        Dim exportFolder As String = Server.MapPath("~/Export_Txt/")
    '        If Not Directory.Exists(exportFolder) Then
    '            Directory.CreateDirectory(exportFolder)
    '        End If

    '        '=== 2. Nama file berdasarkan waktu ===
    '        Dim fileName As String = "DetailTask_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
    '        Dim filePath As String = Path.Combine(exportFolder, fileName)

    '        '=== 3. Buat StringBuilder untuk isi file ===
    '        Dim sb As New StringBuilder()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("DATA LOKASI")
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("Nama Remote       : " & txtnamaremote.Value)
    '        sb.AppendLine("Alamat Sekarang   : " & txtalamatsekarang.Value)
    '        sb.AppendLine("Alamat Instalasi  : " & txtalamat.Value)
    '        sb.AppendLine("Provinsi          : " & txtprovinsi.Value)
    '        sb.AppendLine("Kota / Kabupaten  : " & txtkota.Value)
    '        sb.AppendLine("Kanwil            : " & txtkanwil.Value)
    '        sb.AppendLine("Kanca Induk/Area  : " & txtkancainduk.Value)
    '        sb.AppendLine("Nama PIC          : " & txtPIC.Value)
    '        sb.AppendLine("Phone PIC         : " & txtphonepic.Value)
    '        sb.AppendLine("--------------------------------------------------")
    '        sb.AppendLine("ID Jarkom         : " & txtidjarkom.Value)
    '        sb.AppendLine("ID Satelit        : " & txtsatelit.Value)
    '        sb.AppendLine("Hub               : " & cbhub.Value)
    '        sb.AppendLine("Latitude          : " & txtlatitude.Value)
    '        sb.AppendLine("Longitude         : " & txtlongitude.Value)
    '        sb.AppendLine("Tanggal Berangkat : " & txttglberangkat.Text)
    '        sb.AppendLine("Tanggal Selesai   : " & txttglselesai.Text)
    '        sb.AppendLine("Tanggal Pulang    : " & txttglpulang.Text)
    '        sb.AppendLine("Catatan           : " & txtcatatanlokasi.Value)
    '        sb.AppendLine()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("DATA TEKNIS")
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("Hardware Rusak    : " & txtfailHW.Value)
    '        sb.AppendLine("SQF               : " & txtSQF.Value)
    '        sb.AppendLine("Initial Esno      : " & txtinitialesno.Value)
    '        sb.AppendLine("CPI               : " & txtCPI.Value)
    '        sb.AppendLine("C/N               : " & txtcarriertonotice.Value)
    '        sb.AppendLine("ASI               : " & txthasilxpoll.Value)
    '        sb.AppendLine("Operator Satelit  : " & txtoperatorsatelit.Value)
    '        sb.AppendLine("Operator Helpdesk : " & txtoperatorhelpdesk.Value)
    '        sb.AppendLine("Out PLN           : " & txtoutpln.Value)
    '        sb.AppendLine("Aktifitas Solusi  : " & txtaktifitassolusi.Value)
    '        sb.AppendLine("--------------------------------------------------")
    '        sb.AppendLine("Out UPS           : " & txtoutups.Value)
    '        sb.AppendLine("UPS For Backup    : " & cbupsforbackup.Value)
    '        sb.AppendLine("Suhu Ruangan      : " & txtsuhuruangan.Value)
    '        sb.AppendLine("Type Mounting     : " & txttypemounting.Value)
    '        sb.AppendLine("Panjang Kabel     : " & txtpanjangkabel.Value)
    '        sb.AppendLine("Letak Antena      : " & txtletakantena.Value)
    '        sb.AppendLine("Letak Modem       : " & txtletakmodem.Value)
    '        sb.AppendLine("Letak Antena Ke Satelit : " & txtkondisibangunan.Value)
    '        sb.AppendLine("Analisa Problem   : " & txtanalisaproblem.Value)
    '        sb.AppendLine()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("UPLOAD FOTO")
    '        sb.AppendLine("==================================================")

    '        '=== 4. Ambil semua <img src="..."> dari ltr_image_room ===
    '        Dim imgHtml As String = ltr_image_room.Text
    '        Dim matches As MatchCollection = Regex.Matches(imgHtml, "<img[^>]*src=['""]([^'""]+)['""]", RegexOptions.IgnoreCase)

    '        If matches.Count > 0 Then
    '            Dim i As Integer = 1
    '            For Each m As Match In matches
    '                sb.AppendLine(i.ToString() & ". " & m.Groups(1).Value)
    '                i += 1
    '            Next
    '        Else
    '            sb.AppendLine("Tidak ada foto diunggah.")
    '        End If
    '        sb.AppendLine()

    '        '====================================================================
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("STATUS")
    '        sb.AppendLine("==================================================")
    '        sb.AppendLine("Status Pekerjaan   : " & cbstatusperbaikan.Text)
    '        sb.AppendLine("Status Dokumentasi : " & cbstatusdokumentasi.Text)

    '        '=== 5. Simpan ke file ===
    '        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)

    '        '=== 6. Redirect ke handler download ===
    '        Response.Redirect("~/DownloadTxt.ashx?file=" & fileName, False)
    '    Catch ex As Exception
    '        '=== Tangani error (jangan kirim header lagi kalau sudah dikirim) ===
    '        System.Diagnostics.Debug.WriteLine("Error Export TXT: " & ex.Message)
    '    End Try
    'End Sub
End Class
