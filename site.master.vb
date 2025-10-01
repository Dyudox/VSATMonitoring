Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class site
    Inherits System.Web.UI.MasterPage
    Dim value As String = ""
    'Dim Proses As New ClsConn
    Dim sqldr As SqlDataReader
    Dim sql As String
    Dim VTicket, VTwitter, VFacebook, VEmail, VFax, Vchat, VSms As String
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    'Dim Con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("SosmedConnection").ConnectionString)
    Dim Com As SqlCommand
    Dim Dr As SqlDataReader
    Dim url As String = String.Empty

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("NamaForm") <> "formadminpantauSPD.aspx" Then Session("filter") = Nothing
        If Session("username") = "" Then
            Response.Redirect("login.aspx")
        End If

        If Session("username") = "admin" Then
            Session("namalogin") = "admin"
        Else
            Dim getnamalogin As String = "select * from msEmployee where NIK = '" & Session("username") & "'"
            Com = New SqlCommand(getnamalogin, Con)
            Con.Open()
            Dr = Com.ExecuteReader()
            Dr.Read()
            Session("namalogin") = Dr("Nama").ToString
            Dr.Close()
            Con.Close()
        End If


        lbl_user_login.Text = Session("namalogin")
        lbl_user_login_detail.Text = Session("level")
        lbl_user_login_detail_nama.Text = Session("namalogin")

        Dim getmenu As String = "select * from msusertrusteee where LevelUserSbg = '" & Session("Level") & "'"
        Com = New SqlCommand(getmenu, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        Dr.Read()
        If Dr.HasRows() Then

            If Dr("div_master_data_perusahaan").ToString = "FALSE" And Dr("div_master_karyawan").ToString = "FALSE" And
            Dr("div_master_customer").ToString = "FALSE" And Dr("div_master_provider").ToString = "FALSE" And
            Dr("div_master_hub").ToString = "FALSE" And Dr("div_master_jenis_pekerjaan").ToString = "FALSE" And
            Dr("div_master_status_pekerjaan").ToString = "FALSE" And Dr("div_master_pagu").ToString = "FALSE" And
            Dr("div_master_kokab").ToString = "FALSE" And Dr("div_master_jenis_barang").ToString = "FALSE" And
            Dr("div_master_jarak").ToString = "FALSE" Then
                div_all_master.Visible = False
            End If

            If Dr("div_master_hub").ToString = "TRUE" Then
                div_master_hub.Visible = True
            Else
                div_master_hub.Visible = False
            End If

            If Dr("div_master_jenis_barang").ToString = "TRUE" Then
                div_master_jenis_barang.Visible = True
            Else
                div_master_jenis_barang.Visible = False
            End If

            If Dr("div_master_pagu").ToString = "TRUE" Then
                div_master_pagu.Visible = True
            Else
                div_master_pagu.Visible = False
            End If

            If Dr("div_master_data_perusahaan").ToString = "TRUE" Then
                div_master_data_perusahaan.Visible = True
            Else
                div_master_data_perusahaan.Visible = False
            End If

            If Dr("div_master_karyawan").ToString = "TRUE" Then
                div_master_karyawan.Visible = True
            Else
                div_master_karyawan.Visible = False
            End If

            If Dr("div_master_customer").ToString = "TRUE" Then
                div_master_customer.Visible = True
            Else
                div_master_customer.Visible = False
            End If

            If Dr("div_master_provider").ToString = "TRUE" Then
                div_master_provider.Visible = True
            Else
                div_master_provider.Visible = False
            End If

            If Dr("div_master_jenis_pekerjaan").ToString = "TRUE" Then
                div_master_jenis_pekerjaan.Visible = True
            Else
                div_master_jenis_pekerjaan.Visible = False
            End If

            If Dr("div_master_status_pekerjaan").ToString = "TRUE" Then
                div_master_status_pekerjaan.Visible = True
            Else
                div_master_status_pekerjaan.Visible = False
            End If


            If Dr("div_master_kokab").ToString = "TRUE" Then
                div_all_wilayah.Visible = True
            Else
                div_all_wilayah.Visible = False
            End If

            If Dr("div_master_provinsi").ToString = "TRUE" Then
                div_master_provinsi.Visible = True
            Else
                div_master_provinsi.Visible = False
            End If

            If Dr("div_master_kokab").ToString = "TRUE" Then
                div_master_kokab.Visible = True
            Else
                div_master_kokab.Visible = False
            End If

            If Dr("div_master_kecamatan").ToString = "TRUE" Then
                div_master_kecamatan.Visible = True
            Else
                div_master_kecamatan.Visible = False
            End If

            If Dr("div_master_kelurahan").ToString = "TRUE" Then
                div_master_kelurahan.Visible = True
            Else
                div_master_kelurahan.Visible = False
            End If

            'If Dr("div_all_task").ToString = "TRUE" Then
            '    div_all_task.Visible = True
            'Else
            '    div_all_task.Visible = False
            'End If

            If Dr("div_tasklist").ToString = "TRUE" Then
                div_tasklist.Visible = True
            Else
                div_tasklist.Visible = False
            End If

            If Dr("div_create_project").ToString = "TRUE" Then
                div_create_project.Visible = True
            Else
                div_create_project.Visible = False
            End If

            If Dr("div_create_task").ToString = "TRUE" Then
                div_create_task.Visible = True
            Else
                div_create_task.Visible = False
            End If

            If Dr("div_remotesite").ToString = "TRUE" Then
                div_remotesite.Visible = True
            Else
                div_remotesite.Visible = False
            End If

            'If Dr("div_all_report").ToString = "TRUE" Then
            '    div_all_report.Visible = True
            'Else
            '    div_all_report.Visible = False
            'End If

            If Dr("div_report_satu").ToString = "FALSE" And Dr("div_report_dua").ToString = "FALSE" And Dr("div_report_tiga").ToString = "FALSE" And
            Dr("div_report_empat").ToString = "FALSE" And Dr("div_report_lima").ToString = "FALSE" And Dr("div_report_BPS").ToString = "FALSE" Then
                div_all_report.Visible = False
            End If

            If Dr("div_report_satu").ToString = "TRUE" Then
                div_report_satu.Visible = True
            Else
                div_report_dua.Visible = False
            End If

            If Dr("div_report_dua").ToString = "TRUE" Then
                div_report_dua.Visible = True
            Else
                div_report_dua.Visible = False
            End If

            If Dr("div_report_tiga").ToString = "TRUE" Then
                div_report_tiga.Visible = True
            Else
                div_report_tiga.Visible = False
            End If

            If Dr("div_report_empat").ToString = "TRUE" Then
                div_report_empat.Visible = True
            Else
                div_report_empat.Visible = False
            End If

            If Dr("div_report_lima").ToString = "TRUE" Then
                div_report_lima.Visible = True
            Else
                div_report_lima.Visible = False
            End If

            If Dr("div_menu_Management_user").ToString = "TRUE" Then
                div_menu_Management_user.Visible = True
            Else
                div_menu_Management_user.Visible = False
            End If

            If Dr("div_menu_dashboard").ToString = "TRUE" Then
                div_menu_dashboard.Visible = True
            Else
                div_menu_dashboard.Visible = False
            End If

            If Dr("div_permintaanspd").ToString = True Then
                div_permintaanspd.Visible = True
            Else
                div_permintaanspd.Visible = False
            End If

            If Dr("div_penggunaanspd").ToString = True Then
                div_penggunaanspd.Visible = True
            Else
                div_penggunaanspd.Visible = False
            End If

            If Dr("div_approvalspd").ToString = True Then
                div_approvalspd.Visible = True
            Else
                div_approvalspd.Visible = False
            End If

            If Dr("div_statustransferspd").ToString = True Then
                div_statustransferspd.Visible = True
            Else
                div_statustransferspd.Visible = False
            End If

            If Dr("div_master_jarak").ToString = True Then
                div_master_jarak.Visible = True
            Else
                div_master_jarak.Visible = False
            End If

            If Dr("div_master_jarak").ToString = True Then
                div_master_jarak.Visible = True
            Else
                div_master_jarak.Visible = False
            End If

            If Dr("div_report_BPS").ToString = True Then
                div_report_BPS.Visible = True
            Else
                div_report_BPS.Visible = False
            End If
        End If
        Dr.Close()
        Con.Close()
        session_menu()

        Dim tampungalert As String = ""
        tampungalert &= "<div id='alert'>" & _
                          "<div class='alert alert-warning'>" & _
                       "<strong>Kamu masih mempunyai beberapa task yang belum selesai lebih dari 120 hari!</strong>" & _
                       "<ul>"
        Dim getdataalert As String = "SELECT trTask.ID, trTask.NoTask, trTask.TanggalTask, trTask.IdProject, trTask.IdTeknisi, trTask.NamaTeknisi, " & _
                                    "trDetail_Task.IdJenisTask, trDetail_Task.VID, trDetail_Task.NAMAREMOTE, trDetail_Task.ALAMAT, trDetail_Task.PROVINSI, " & _
                                    "trDetail_Task.IdStatusPerbaikan, trDetail_Task.KOTA FROM trTask INNER JOIN  trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                    "where TanggalTask <= DATEADD(day,-120,convert(date, GETDATE())) and IdStatusPerbaikan <> '4'"
        Com = New SqlCommand(getdataalert, Con)
        Con.Open()
        Dr = Com.ExecuteReader()
        While Dr.Read()
            tampungalert &= "<li>Task : " & Dr("NoTask") & ", " & Dr("VID") & ", " & Dr("NAMAREMOTE") & ", " & Dr("IdJenisTask") & ", Mohon Segera di selesaikan</li>"
        End While
        Dr.Close()
        Con.Close()
        tampungalert &= "</li>" & _
                        "</div>" & _
                        "</div>"
        If Session("NamaForm") <> "rptbps.aspx" Then
            Session("query") = Nothing
        End If
    End Sub

    Private Sub session_menu()
        url = Request.QueryString("page")
        If url = "dataper" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_data_perusahaan")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "jarak" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_jarak")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datakar" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_karyawan")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datapel" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_customer")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datpro" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_provider")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "dathub" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_hub")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datjnspek" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_jenis_pekerjaan")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datstspek" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_status_pekerjaan")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datprov" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim li2 As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            li2 = Page.Master.FindControl("div_all_wilayah")
            ul = Page.Master.FindControl("div_master_provinsi")
            li.Attributes.Add("class", "openable active open")
            li2.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datkotkab" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim li2 As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            li2 = Page.Master.FindControl("div_all_wilayah")
            ul = Page.Master.FindControl("div_master_provinsi")
            li.Attributes.Add("class", "openable active open")
            li2.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datkec" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim li2 As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            li2 = Page.Master.FindControl("div_all_wilayah")
            ul = Page.Master.FindControl("div_master_provinsi")
            li.Attributes.Add("class", "openable active open")
            li2.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datkel" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim li2 As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            li2 = Page.Master.FindControl("div_all_wilayah")
            ul = Page.Master.FindControl("div_master_provinsi")
            li.Attributes.Add("class", "openable active open")
            li2.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "dattsklis" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_task")
            ul = Page.Master.FindControl("div_tasklist")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datcrtpro" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_task")
            ul = Page.Master.FindControl("div_create_project")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datcrttas" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_task")
            ul = Page.Master.FindControl("div_create_task")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datrmtsit" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_task")
            ul = Page.Master.FindControl("div_remotesite")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datusr" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_Management_user")
            ul = Page.Master.FindControl("div_user_add")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datsetusr" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_Management_user")
            ul = Page.Master.FindControl("div_user_setting")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "rptsatu" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_report")
            ul = Page.Master.FindControl("div_report_satu")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "rptdua" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_report")
            ul = Page.Master.FindControl("div_report_dua")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "rpttiga" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_report")
            ul = Page.Master.FindControl("div_report_tiga")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "rptempat" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_report")
            ul = Page.Master.FindControl("div_report_empat")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "rptlima" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_report")
            ul = Page.Master.FindControl("div_report_lima")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "bps" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_report")
            ul = Page.Master.FindControl("div_report_BPS")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "pengajuanspd" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_finance")
            ul = Page.Master.FindControl("div_permintaanspd")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "penggunaanspd" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_finance")
            ul = Page.Master.FindControl("div_penggunaanspd")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "adminspd" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_finance")
            ul = Page.Master.FindControl("div_approvalspd")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "financespd" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_finance")
            ul = Page.Master.FindControl("div_statustransferspd")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        ElseIf url = "datpag" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            Dim ul As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_all_master")
            ul = Page.Master.FindControl("div_master_pagu")
            li.Attributes.Add("class", "openable active open")
            ul.Attributes.Add("class", "active")
        End If
        If url = "dashboard" Then
            Dim li As System.Web.UI.HtmlControls.HtmlGenericControl
            li = Page.Master.FindControl("div_menu_dashboard")
            li.Attributes.Add("class", "active")
        End If
    End Sub
End Class

