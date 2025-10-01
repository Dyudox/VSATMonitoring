Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Timers
Partial Class msusertrustee
    Inherits System.Web.UI.Page
    Dim Con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim Con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim Com As SqlCommand
    Dim Dr, sqlDr As SqlDataReader
    Dim a As String = "satu"
    Dim strArray
    Dim strArr
    Dim strTrustee
    Dim strCheckBox As String = ""
    Dim countuserlevel As String
    Dim div_master_pagu, div_master_data_perusahaan, div_master_karyawan, div_master_customer, div_master_provider, div_master_hub, div_master_jenis_pekerjaan As String
    Dim div_master_status_pekerjaan, div_all_wilayah, div_master_provinsi, div_master_kokab, div_master_kecamatan, div_master_kelurahan, div_all_task, div_tasklist As String
    Dim div_create_project, div_create_task, div_remotesite, div_all_report, div_report_satu, div_report_dua, div_report_tiga, div_report_empat, div_report_lima, div_menu_Management_user, div_menu_dashboard, div_master_level_user, div_master_jenis_barang As String
    Dim div_permintaanspd, div_penggunaanspd, div_approvalspd, div_statustransferspd, div_master_jarak, div_report_BPS, div_report_task As String
    Dim insertdata As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        DsLevel.UpdateCommand = ""
        dsCheckBox.SelectCommand = "SELECT * FROM msmenu order by Description"
        BUpdateleveluser_user_management.Visible = False
        BSaveleveluser_user_management.Visible = False
        bDelete.Visible = False
        BCancelleveluser_user_management.Visible = False
        panelusercreate.Visible = False

    End Sub

    Protected Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase) Handles callbackPanelX.Callback
        Dim smastertrustee As String = "select * from msUserTrusteee where TrusteeID='" & txtGroupID.Value & "'"
        Com = New SqlCommand(smastertrustee, Con1)
        Con1.Open()
        sqlDr = Com.ExecuteReader()
        If sqlDr.Read() Then
            strCheckBox = sqlDr("div_master_jenis_barang") & ";" & sqlDr("div_master_customer") & ";" & sqlDr("div_master_hub") & ";" & sqlDr("div_master_jarak") & ";" &
            sqlDr("div_master_jenis_pekerjaan") & ";" & sqlDr("div_master_karyawan") & ";" & sqlDr("div_master_kecamatan") & ";" & sqlDr("div_master_kelurahan") & ";" &
            sqlDr("div_master_kokab") & ";" & sqlDr("div_master_level_user") & ";" & sqlDr("div_master_pagu") & ";" & sqlDr("div_master_data_perusahaan") & ";" &
            sqlDr("div_master_provider") & ";" & sqlDr("div_master_provinsi") & ";" & sqlDr("div_master_status_pekerjaan") & ";" & sqlDr("div_approvalspd") & ";" &
            sqlDr("div_create_project") & ";" & sqlDr("div_create_task") & ";" & sqlDr("div_menu_dashboard") & ";" & sqlDr("div_penggunaanspd") & ";" &
            sqlDr("div_permintaanspd") & ";" & sqlDr("div_remotesite") & ";" & sqlDr("div_statustransferspd") & ";" & sqlDr("div_tasklist") & ";" &
            sqlDr("div_report_tiga") & ";" & sqlDr("div_report_BPS") & ";" & sqlDr("div_report_satu") & ";" & sqlDr("div_report_task") & ";" &
            sqlDr("div_report_empat") & ";" & sqlDr("div_report_lima") & ";" & sqlDr("div_report_dua") & ";" & sqlDr("div_menu_Management_user") & ""
            strArr = strCheckBox.Split(";")
            For i = 0 To checkBoxList.Items.Count - 1
                checkBoxList.Items(i).Selected = False
                For count = 0 To strArr.Length - 1
                    If strArr(i) = "TRUE" Then
                        checkBoxList.Items(i).Selected = True
                    Else
                        checkBoxList.Items(i).Selected = False
                    End If
                    'MsgBox(strArr(count), vbSystemModal)
                Next
            Next
        End If
        sqlDr.Close()
        Con1.Close()
        BUpdateleveluser_user_management.Visible = True
        Bleveluser_user_management.Visible = False
        BCancelleveluser_user_management.Visible = True
        bDelete.Visible = True
    End Sub

    Protected Sub Bleveluser_user_management_Click(sender As Object, e As EventArgs) Handles Bleveluser_user_management.Click
        gridLevelUser.Visible = False
        panelusercreate.Visible = True
        BSaveleveluser_user_management.Visible = True
        BCancelleveluser_user_management.Visible = True
        Bleveluser_user_management.Visible = False
        bDelete.Visible = False
    End Sub

    Private Sub AlokasiList()
        If checkBoxList.Items(0).Selected Then
            div_master_jenis_barang = "TRUE"
        Else
            div_master_jenis_barang = "FALSE"
        End If

        If checkBoxList.Items(1).Selected Then
            div_master_customer = "TRUE"
        Else
            div_master_customer = "FALSE"
        End If

        If checkBoxList.Items(2).Selected Then
            div_master_hub = "TRUE"
        Else
            div_master_hub = "FALSE"
        End If

        If checkBoxList.Items(3).Selected Then
            div_master_jarak = "TRUE"
        Else
            div_master_jarak = "FALSE"
        End If

        If checkBoxList.Items(4).Selected Then
            div_master_jenis_pekerjaan = "TRUE"
        Else
            div_master_jenis_pekerjaan = "FALSE"
        End If

        If checkBoxList.Items(5).Selected Then
            div_master_karyawan = "TRUE"
        Else
            div_master_karyawan = "FALSE"
        End If

        If checkBoxList.Items(6).Selected Then
            div_master_kecamatan = "TRUE"
        Else
            div_master_kecamatan = "FALSE"
        End If

        If checkBoxList.Items(7).Selected Then
            div_master_kelurahan = "TRUE"
        Else
            div_master_kelurahan = "FALSE"
        End If

        If checkBoxList.Items(8).Selected Then
            div_master_kokab = "TRUE"
        Else
            div_master_kokab = "FALSE"
        End If

        If checkBoxList.Items(9).Selected Then
            div_master_level_user = "TRUE"
        Else
            div_master_level_user = "FALSE"
        End If

        If checkBoxList.Items(10).Selected Then
            div_master_pagu = "TRUE"
        Else
            div_master_pagu = "FALSE"
        End If

        If checkBoxList.Items(11).Selected Then
            div_master_data_perusahaan = "TRUE"
        Else
            div_master_data_perusahaan = "FALSE"
        End If

        If checkBoxList.Items(12).Selected Then
            div_master_provider = "TRUE"
        Else
            div_master_provider = "FALSE"
        End If

        If checkBoxList.Items(13).Selected Then
            div_master_provinsi = "TRUE"
        Else
            div_master_provinsi = "FALSE"
        End If

        If checkBoxList.Items(14).Selected Then
            div_master_status_pekerjaan = "TRUE"
        Else
            div_master_status_pekerjaan = "FALSE"
        End If

        If checkBoxList.Items(15).Selected Then
            div_approvalspd = "TRUE"
        Else
            div_approvalspd = "FALSE"
        End If

        If checkBoxList.Items(16).Selected Then
            div_create_project = "TRUE"
        Else
            div_create_project = "FALSE"
        End If

        If checkBoxList.Items(17).Selected Then
            div_create_task = "TRUE"
        Else
            div_create_task = "FALSE"
        End If

        If checkBoxList.Items(18).Selected Then
            div_menu_dashboard = "TRUE"
        Else
            div_menu_dashboard = "FALSE"
        End If

        If checkBoxList.Items(19).Selected Then
            div_penggunaanspd = "TRUE"
        Else
            div_penggunaanspd = "FALSE"
        End If

        If checkBoxList.Items(20).Selected Then
            div_permintaanspd = "TRUE"
        Else
            div_permintaanspd = "FALSE"
        End If

        If checkBoxList.Items(21).Selected Then
            div_remotesite = "TRUE"
        Else
            div_remotesite = "FALSE"
        End If

        If checkBoxList.Items(22).Selected Then
            div_statustransferspd = "TRUE"
        Else
            div_statustransferspd = "FALSE"
        End If

        If checkBoxList.Items(23).Selected Then
            div_tasklist = "TRUE"
        Else
            div_tasklist = "FALSE"
        End If

        If checkBoxList.Items(24).Selected Then
            div_report_tiga = "TRUE"
        Else
            div_report_tiga = "FALSE"
        End If

        If checkBoxList.Items(25).Selected Then
            div_report_BPS = "TRUE"
        Else
            div_report_BPS = "FALSE"
        End If

        If checkBoxList.Items(26).Selected Then
            div_report_satu = "TRUE"
        Else
            div_report_satu = "FALSE"
        End If

        If checkBoxList.Items(27).Selected Then
            div_report_task = "TRUE"
        Else
            div_report_task = "FALSE"
        End If

        If checkBoxList.Items(28).Selected Then
            div_report_empat = "TRUE"
        Else
            div_report_empat = "FALSE"
        End If

        If checkBoxList.Items(29).Selected Then
            div_report_lima = "TRUE"
        Else
            div_report_lima = "FALSE"
        End If

        If checkBoxList.Items(30).Selected Then
            div_report_dua = "TRUE"
        Else
            div_report_dua = "FALSE"
        End If

        If checkBoxList.Items(31).Selected Then
            div_menu_Management_user = "TRUE"
        Else
            div_menu_Management_user = "FALSE"
        End If
    End Sub

    Protected Sub BSaveleveluser_user_management_Click(sender As Object, e As EventArgs) Handles BSaveleveluser_user_management.Click
        Dim i As Integer = 0
        Dim ii As Integer = 0
        Dim ld As String = 0
        Dim listBarangID As String = 0

        AlokasiList()

        Dim insertleveluser As String = "insert into msUserTrusteee (LevelUser, LevelUserSbg, Description, div_master_jenis_barang,div_master_customer,div_master_hub,div_master_jarak,div_master_jenis_pekerjaan,div_master_karyawan,div_master_kecamatan,div_master_kelurahan" & _
        ",div_master_kokab,div_master_level_user,div_master_pagu,div_master_data_perusahaan,div_master_provider,div_master_provinsi,div_master_status_pekerjaan,div_approvalspd,div_create_project,div_create_task,div_menu_dashboard,div_penggunaanspd,div_permintaanspd" & _
        ",div_remotesite, div_statustransferspd, div_tasklist, div_report_tiga, div_report_BPS,div_report_satu,div_report_task,div_report_empat,div_report_lima,div_report_dua,div_menu_Management_user) VALUES " & _
        "('" & txtleveluser.Text & "', '" & cmb_level_user.Value & "', '" & txt_descriptionText.Text & "', '" & div_master_jenis_barang & "', '" & div_master_customer & "', '" & div_master_hub & "', '" & div_master_jarak & "'" & _
        ", '" & div_master_jenis_pekerjaan & "',, '" & div_master_karyawan & "', '" & div_master_kecamatan & "', '" & div_master_kelurahan & "', '" & div_master_kokab & "', '" & div_master_level_user & "'" & _
        ", '" & div_master_pagu & "',, '" & div_master_data_perusahaan & "', '" & div_master_provider & "', '" & div_master_provinsi & "', '" & div_master_status_pekerjaan & "', '" & div_approvalspd & "'" & _
        ", '" & div_create_project & "', '" & div_create_task & "', '" & div_menu_dashboard & "', '" & div_penggunaanspd & "', '" & div_permintaanspd & "', '" & div_remotesite & "', '" & div_statustransferspd & "', '" & div_tasklist & "'" & _
        ", '" & div_report_tiga & "', '" & div_report_BPS & "', '" & div_report_satu & "', '" & div_report_task & "', '" & div_report_empat & "', '" & div_report_lima & "', '" & div_report_dua & "', '" & div_menu_Management_user & "')"
        Com = New SqlCommand(insertleveluser, Con1)
        Con1.Open()
        Com.ExecuteNonQuery()
        Con1.Close()
        Response.Redirect("msusertrustee.aspx?page=datsetusr")
    End Sub

    Protected Sub BUpdateleveluser_user_management_Click(sender As Object, e As EventArgs) Handles BUpdateleveluser_user_management.Click
       
        AlokasiList()

        Dim selectdata As String = "select * from msusertrusteee where TrusteeId = '" & txtGroupID.Value & "'"
        Com = New SqlCommand(selectdata, Con1)
        Con1.Open()
        Dr = Com.ExecuteReader()
        Dr.Read()
        Dim leveluser As String = Dr("LevelUser").ToString
        Dim UserSbg As String = Dr("LevelUserSbg").ToString
        Dim Descr As String = Dr("Description").ToString
        Dr.Close()
        Con1.Close()

        Try
            Dim UpdateTable As String = "Update msUserTrusteee SET LevelUser='" & leveluser & "', LevelUserSbg='" & UserSbg & "', Description='" & Descr & "', div_report_task='" & div_report_task & "'," & _
            "div_master_data_perusahaan = '" & div_master_data_perusahaan & "', div_master_karyawan = '" & div_master_karyawan & "', div_master_customer = '" & div_master_customer & "', div_master_provider = '" & div_master_provider & "', div_master_hub = '" & div_master_hub & "', div_master_jenis_pekerjaan = '" & div_master_jenis_pekerjaan & "', " & _
            "div_master_status_pekerjaan = '" & div_master_status_pekerjaan & "', div_master_provinsi = '" & div_master_provinsi & "', div_master_kokab = '" & div_master_kokab & "', div_master_kecamatan = '" & div_master_kecamatan & "', div_master_kelurahan = '" & div_master_kelurahan & "', div_tasklist = '" & div_tasklist & "', " & _
            "div_create_project = '" & div_create_project & "', div_create_task = '" & div_create_task & "', div_remotesite = '" & div_remotesite & "', div_report_satu = '" & div_report_satu & "', div_report_dua = '" & div_report_dua & "', div_report_tiga = '" & div_report_tiga & "', div_report_empat = '" & div_report_empat & "', div_report_lima = '" & div_report_lima & "', div_menu_Management_user = '" & div_menu_Management_user & "', div_menu_dashboard = '" & div_menu_dashboard & "', div_master_jenis_barang = '" & div_master_jenis_barang & "', div_master_level_user = '" & div_master_level_user & "', " & _
            "div_permintaanspd = '" & div_permintaanspd & "', div_penggunaanspd = '" & div_penggunaanspd & "', div_approvalspd = '" & div_approvalspd & "', div_statustransferspd = '" & div_statustransferspd & "', div_master_pagu = '" & div_master_pagu & "', div_master_jarak = '" & div_master_jarak & "', div_report_BPS = '" & div_report_BPS & "' where TrusteeID='" & txtGroupID.Value & "'"
            Com = New SqlCommand(UpdateTable, Con1)
            Con1.Open()
            Com.ExecuteNonQuery()
            Con1.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try

        Response.Redirect("msusertrustee.aspx?page=datsetusr")
    End Sub

    Protected Sub BCancelleveluser_user_management_Click(sender As Object, e As EventArgs) Handles BCancelleveluser_user_management.Click
        Response.Redirect("msusertrustee.aspx?page=datsetusr")
    End Sub

    Protected Sub bDelete_Click(sender As Object, e As EventArgs) Handles bDelete.Click
        Try
            Dim deletedata As String = "delete from msUserTrusteee where TrusteeId = '" & txtGroupID.Value & "'"
            Com = New SqlCommand(deletedata, Con1)
            Con1.Open()
            Com.ExecuteNonQuery()
            Con1.Close()
        Catch ex As Exception
            Response.Write(DirectCast("", String))
        Finally
        End Try
        Response.Redirect("msusertrustee.aspx?page=datsetusr")
    End Sub

    'Protected Sub gridLevelUser_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gridLevelUser.RowInserting
    '    DsUserTrustee.InsertCommand = "Insert into "
    'End Sub
End Class
