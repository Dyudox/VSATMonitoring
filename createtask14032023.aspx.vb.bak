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
Imports System.Net
Imports System.Net.Mail

Partial Class createtask
    Inherits System.Web.UI.Page
    Dim con, con1, con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand
    Dim VID, NamaRemote, IPLAN, SID, ALamatInstall, Provinsi, Kota, IDJARKOM, PIC, CustPhone As String
    Dim tampung, NoSubtask, NamaBarang, strsql, namaCity As String
    Dim StatusTeknisi, idproject As String
    Dim note, latitude, longitude, VIDjarak As Object
    Dim emailAcc As String = ConfigurationManager.AppSettings("emailAcc")
    Dim emailPass As String = ConfigurationManager.AppSettings("emailPass")
    Dim emailHost As String = ConfigurationManager.AppSettings("emailHost")
    Dim emailPort As String = ConfigurationManager.AppSettings("emailPort")
    Dim clsg As New cls_global
    Dim tbldata As DataTable

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = "admin" Then
            'dsmanager.SelectCommand = "select * from trtask where trtask.IdStatusKoordinator = 'Valid' order by TanggalTask desc"
            dsmanager.SelectCommand = "SELECT a.ID, a.NoTask, a.NomorPengaduan, a.TanggalTask, a.NamaTask, a.IdKoordinator, a.NamaKoordinator, a.NamaTeknisi, a.IdJenisTask, a.TglMulai, a.TglSelesai, " &
                                        "b.Provinsi as IdProvinsi, c.Kota as IdCity, a.CatatanKoordinator, a.CatatanManager, a.IdStatusKoordinator, a.IdStatusManager, a.TglStatusTask, a.IdProject, " &
                                        "a.IdStatusTask, a.AlamatPengaduan, a.DeskripsiPermasalahan FROM trTask a LEFT OUTER JOIN msProvinsi b ON a.IdProvinsi = b.IdProvinsi " &
                                        "LEFT OUTER JOIN msKota c ON a.IdCity = c.idKota " &
                                        "order by a.TanggalTask desc,a.NomorPengaduan desc ,a.id DESC,a.IdStatusKoordinator desc"
        Else
            'dsmanager.SelectCommand = "select * from trtask where trtask.IdStatusKoordinator = 'Valid' and (IdUserManager is null or IdUserManager='" & Session("username") & "') order by TanggalTask desc"
            'dsmanager.SelectCommand = "select a.IdUserManager, a.IdUserKoordinator, b.NIK, b.EmployeeType, * from trTask a LEFT OUTER JOIN msEmployee b ON b.NIK = a.IdUserManager " &
            '                          "where a.IdStatusKoordinator = 'Valid' and a.IdUserManager " &
            '                          "in ( select NIK from msEmployee where b.EmployeeType Like '%" & Session("level") & "%' or (a.IdUserManager is null or a.IdUserManager='" & Session("username") & "') ) " &
            '                          "order by TanggalTask desc"
            dsmanager.SelectCommand = "SELECT a.ID, a.NoTask, a.NomorPengaduan, a.TanggalTask, a.NamaTask, a.IdKoordinator, a.NamaKoordinator, a.NamaTeknisi, a.IdJenisTask, a.TglMulai, a.TglSelesai, " &
                                        "b.Provinsi as IdProvinsi, c.Kota as IdCity, a.CatatanKoordinator, a.CatatanManager, a.IdStatusKoordinator, a.IdStatusManager, a.TglStatusTask, a.IdProject, " &
                                        "a.IdStatusTask, a.AlamatPengaduan, a.DeskripsiPermasalahan FROM trTask a LEFT OUTER JOIN msProvinsi b ON a.IdProvinsi = b.IdProvinsi " &
                                        "LEFT OUTER JOIN msKota c ON a.IdCity = c.idKota " &
                                        "order by a.TanggalTask desc,a.NomorPengaduan desc ,a.id DESC,a.IdStatusKoordinator desc"
        End If
        'clsg.writedata(Session("UserName"), "Data", "Foto", dsmanager.SelectCommand, "")
        grid_manager.DataBind()

        If Session("Level") = "Coordinator" Then
            panelhelpdesk.Visible = False
            panelmanager.Visible = False
            dstaskcoor.SelectCommand = "SELECT a.ID, a.NoTask, a.NomorPengaduan, a.TanggalTask, a.NamaTask, a.IdKoordinator,a.NamaKoordinator, a.IdStatusKoordinator,a.NamaTeknisi, a.IdJenisTask, a.TglMulai, a.TglSelesai, " &
                                       "b.Provinsi as IdProvinsi, c.Kota as IdCity, a.CatatanKoordinator, a.IdStatusKoordinator, a.TglStatusTask, a.IdProject, " &
                                       "a.IdStatusTask, a.AlamatPengaduan, a.DeskripsiPermasalahan FROM trTask a LEFT OUTER JOIN msProvinsi b ON a.IdProvinsi = b.IdProvinsi " &
                                       "LEFT OUTER JOIN msKota c ON a.IdCity = c.idKota where IdKoordinator='" & Session("username") & "' or NamaKoordinator is null " &
                                       "order by a.TanggalTask desc,a.NomorPengaduan desc,a.id DESC,a.IdStatusKoordinator desc"

            'dstaskcoor.SelectCommand = "SELECT a.ID, a.NoTask, a.NomorPengaduan, a.TanggalTask, a.NamaTask, a.IdKoordinator,a.NamaKoordinator, a.IdStatusKoordinator,a.NamaTeknisi, a.IdJenisTask, a.TglMulai, a.TglSelesai, " &
            '                           "b.Provinsi as IdProvinsi, c.Kota as IdCity, a.CatatanKoordinator, a.IdStatusKoordinator, a.TglStatusTask, a.IdProject, " &
            '                           "a.IdStatusTask, a.AlamatPengaduan, a.DeskripsiPermasalahan FROM trTask a LEFT OUTER JOIN msProvinsi b ON a.IdProvinsi = b.IdProvinsi " &
            '                           "LEFT OUTER JOIN msKota c ON a.IdCity = c.idKota " &
            '                           "order by a.TanggalTask desc,a.NomorPengaduan desc,a.id DESC,a.IdStatusKoordinator desc"
            grid_koordinator.DataBind()
        ElseIf Session("level") = "Manager" Then
            panelkoordinator.Visible = False
            panelhelpdesk.Visible = False
            dstaskcoor.SelectCommand = "SELECT a.ID, a.NoTask, a.NomorPengaduan, a.TanggalTask, a.NamaTask, a.IdKoordinator, a.NamaTeknisi, a.IdJenisTask, a.TglMulai, a.TglSelesai, " &
                                        "b.Provinsi as IdProvinsi, c.Kota as IdCity, a.CatatanKoordinator, a.IdStatusKoordinator, a.TglStatusTask, a.IdProject, " &
                                        "a.IdStatusTask, a.AlamatPengaduan, a.DeskripsiPermasalahan FROM trTask a LEFT OUTER JOIN msProvinsi b ON a.IdProvinsi = b.IdProvinsi " &
                                        "LEFT OUTER JOIN msKota c ON a.IdCity = c.idKota " &
                                        "order by a.TanggalTask desc,a.NomorPengaduan desc ,a.id DESC,a.IdStatusKoordinator desc"
        ElseIf Session("Level") = "Helpdesk" Then
            panelmanager.Visible = False
            panelkoordinator.Visible = False
            dstaskcoor.SelectCommand = "SELECT a.ID, a.NoTask, a.NomorPengaduan, a.TanggalTask, a.NamaTask, a.IdKoordinator, a.NamaTeknisi, a.IdJenisTask, a.TglMulai, a.TglSelesai, " &
                                        "b.Provinsi as IdProvinsi, c.Kota as IdCity, a.CatatanKoordinator, a.IdStatusKoordinator, a.TglStatusTask, a.IdProject, " &
                                        "a.IdStatusTask, a.AlamatPengaduan, a.DeskripsiPermasalahan FROM trTask a LEFT OUTER JOIN msProvinsi b ON a.IdProvinsi = b.IdProvinsi " &
                                        "LEFT OUTER JOIN msKota c ON a.IdCity = c.idKota " &
                                        "order by a.TanggalTask desc,a.NomorPengaduan desc ,a.id DESC,a.IdStatusKoordinator desc"
        Else
            dstaskcoor.SelectCommand = "SELECT a.ID, a.NoTask, a.NomorPengaduan, a.TanggalTask, a.NamaTask, a.IdKoordinator,a.NamaKoordinator,a.IdStatusKoordinator, a.NamaTeknisi, a.IdJenisTask, a.TglMulai, a.TglSelesai, " &
                                       "b.Provinsi as IdProvinsi, c.Kota as IdCity, a.CatatanKoordinator, a.IdStatusKoordinator, a.TglStatusTask, a.IdProject, " &
                                       "a.IdStatusTask, a.AlamatPengaduan, a.DeskripsiPermasalahan FROM trTask a LEFT OUTER JOIN msProvinsi b ON a.IdProvinsi = b.IdProvinsi " &
                                       "LEFT OUTER JOIN msKota c ON a.IdCity = c.idKota " &
                                       "order by a.TanggalTask desc,a.NomorPengaduan desc ,a.id DESC,a.IdStatusKoordinator desc"
        End If

        'If cbfilter.Value <> "" Then

        'Else

        'End If

        'If cbjarak.Value <> "" Then
        '    liprofile1.Attributes.Add("Class", "Active")
        '    profile1.Attributes.Add("Class", "tab-pane fade in active")
        '    lihome1.Attributes.Add("Class", "")
        '    home1.Attributes.Add("Class", "tab-pane fade")
        'Else
        '    lihome1.Attributes.Add("Class", "Active")
        '    home1.Attributes.Add("Class", "tab-pane fade in active")
        '    liprofile1.Attributes.Add("Class", "")
        '    profile1.Attributes.Add("Class", "tab-pane fade")
        'End If


    End Sub

    Private Sub createtask_Init(sender As Object, e As EventArgs) Handles Me.Init
        dstask.SelectCommand = "SELECT a.NoTask,a.ID, a.NomorPengaduan, a.TanggalTask, a.LaporanPengaduan, a.IdStatusTask, a.TglStatusTask, a.IdProject, a.AsalPengaduan, a.NamaPelapor, a.TelpPelapor, a.AlamatPengaduan, a.DeskripsiPermasalahan, a.City as IdCity, a.Provinsi as IdProvinsi, a.CatatanKoordinator FROM  trTask a  where NomorPengaduan <> '' order by ID DESC"
    End Sub
    Protected Sub popup_grid_subtask_CustomButtonCallback(sender As Object, e As ASPxGridViewCustomButtonCallbackEventArgs) Handles popup_grid_subtask.CustomButtonCallback
        ' If e.ButtonID = "btnPickRemoteSite" Then
        Dim keyValue = popup_grid_subtask.GetRowValues(e.VisibleIndex, popup_grid_subtask.KeyFieldName)
        'UpdateItem(keyValue)
        litText.Text = "Provinsi : adad"
        'End If
    End Sub

    Protected Sub popup_WindowCallback(ByVal source As Object, ByVal e As PopupWindowCallbackArgs)
        'GetData(e.Parameter)

        'edBinaryImage.Value = Image

        If cbfilter.Value = "" Then
            cbfilter.Value = "All Data"
        Else

        End If

        'lihome1.Attributes.Add("Class", "Active")
        'home1.Attributes.Add("Class", "tab-pane fade in active")

        Dim strGetData As String
        'strGetData = "select c.Provinsi,c.NoTask from msProvinsi a left outer join trTask b on b.IdProvinsi=a.IdProvinsi " &
        '    "left outer join trDetail_Task c on c.NoTask=b.NoTask " &
        '    "where c.NoListTask='" & note.ToString() & "'"

        strGetData = "SELECT trTask.NoTask, trtask.Provinsi, city,trtask.IdProject, trtask.TglMulai from trTask " &
                    "where trTask.NoTask = '" & note.ToString & "'"
        com = New SqlCommand(strGetData, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Session("project") = dr("IdProject").ToString
        Dim NamaProvinsi As String = dr("Provinsi").ToString
        Dim NoTask As String = dr("NoTask").ToString
        namaCity = dr("city").ToString
        'Dim tglmulai As String = dr("tglmulai").ToString
        'Session("notask") = dr("NoTask").ToString
        dr.Close()
        con.Close()
        litText.Text = "Provinsi : " & NamaProvinsi & ", Kota : " & namaCity

        Session("NamaProvinsi") = NamaProvinsi
        Session("NoTask") = NoTask

        dssubtask.SelectCommand = "exec res_LokasiRemoteSiteSekitar '" & NamaProvinsi & "','" & namaCity & "', '" & cbfilter.Value & "', '" & Session("project") & "', '" & Session("tglmulai") & "'"
        'clsg.writedata(Session("UserName"), "Data", "Foto", dssubtask.SelectCommand, "")
        'Select Case * From trTask Where NoTask ='100005'
        'dssubtask.SelectCommand = "SELECT trRemoteSite.VID, trRemoteSite.ProjectName, trRemoteSite.SID, trRemoteSite.CID, trRemoteSite.NAMAREMOTE, trRemoteSite.AlamatInstall, trRemoteSite.PROVINSI, trRemoteSite.KOTA FROM trRemoteSite"
    End Sub

    'Private Sub GetData(ByVal id As String)
    '    Dim ds As New AccessDataSource()
    '    'note()
    '    'ds.DataFile = ads.DataFile
    '    'ds.SelectCommand = String.Format("Select Photo, Notes FROM [Employees] WHERE EmployeeID = {0}", id)
    '    'Dim view As DataView = DirectCast(ds.Select(DataSourceSelectArguments.Empty), DataView)
    '    'If view.Count > 0 Then
    '    '    Image = TryCast(view(0)(0), Byte())
    '    '    note = view(0)(1)
    '    'End If
    'End Sub

    Protected Sub grid_helpdesk_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_helpdesk.RowDeleting
        strsql = "delete trDetail_Task where NoTask='" & e.Values("NoTask") & "'"
        clsg.ExecuteNonQuery(strsql)
        dstask.DeleteCommand = "delete from trtask where ID = @ID"
        grid_helpdesk.DataBind()
        grid_koordinator.DataBind()
        grid_manager.DataBind()
        ' Response.Redirect("createtask.aspx")
    End Sub

    Protected Sub grid_helpdesk_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_helpdesk.RowInserting
        Try
            Dim getdate As String = "SELECT CONVERT(char(10), GetDate(),112) as tgl "
            com = New SqlCommand(getdate, con)
            con.Open()
            dr = com.ExecuteReader
            dr.Read()
            Dim tgl As String = dr("tgl").ToString
            dr.Close()
            con.Close()

            Dim provinsi As String = e.NewValues("IdProvinsi").ToString
            Dim Kota As String = e.NewValues("IdCity").ToString
            Dim idkota As String = ""
            Dim namakota As String = ""
            Dim Getkota As String = "Select * from mskota where idKota = '" & Kota & "' or Kota = '" & Kota & "'"
            com = New SqlCommand(Getkota, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idkota = dr("idKota").ToString
                namakota = dr("Kota").ToString
            End If
            dr.Close()
            con.Close()

            Dim idprovinsi, provinsiupdate As String
            Dim getprovinsi As String = "select * from msProvinsi where IdProvinsi = '" & provinsi & "' or Provinsi = '" & provinsi & "'"
            com = New SqlCommand(getprovinsi, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idprovinsi = dr("IdProvinsi").ToString
                provinsiupdate = dr("Provinsi").ToString
            End If
            dr.Close()
            con.Close()

            Dim idtask, idsuk, idpelanggan, idtot As String
            Dim getidakhir As String = "select max(NoTask) NoTask, max(NomorPengaduan) NomorPengaduan from trTask"
            com = New SqlCommand(getidakhir, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idtask = dr("NoTask").ToString
                idpelanggan = dr("NomorPengaduan").ToString
            End If
            dr.Close()
            con.Close()



            If idtask = "" Then
                If idpelanggan = "" Then
                    dstask.InsertCommand = "INSERT INTO trTask (NoTask, NomorPengaduan, TanggalTask, LaporanPengaduan, IdJenisTask, IdStatusTask, TglStatusTask, IdProject, AsalPengaduan, NamaPelapor, TelpPelapor, AlamatPengaduan, IdProvinsi, IdCity, Provinsi, City, DeskripsiPermasalahan, UserStamp, DateStamp) VALUES " &
                                       "('100001', '101', @TanggalTask, @LaporanPengaduan, @LaporanPengaduan, @IdStatusTask, @TglStatusTask, @IdProject, @AsalPengaduan, @NamaPelapor, @TelpPelapor, @AlamatPengaduan, '" & idprovinsi & "', '" & idkota & "', '" & provinsiupdate & "', '" & namakota & "', @DeskripsiPermasalahan, '" & Session("username") & "', GETDATE()) "
                Else
                    idtot = idpelanggan + 1
                    idsuk = idtask + 1
                    dstask.InsertCommand = "INSERT INTO trTask (NoTask, NomorPengaduan, TanggalTask, LaporanPengaduan, IdJenisTask, IdStatusTask, TglStatusTask, IdProject, AsalPengaduan, NamaPelapor, TelpPelapor, AlamatPengaduan, IdProvinsi, IdCity, Provinsi, City, DeskripsiPermasalahan, User, UserStamp, DateStamp) VALUES " &
                                     "('" & idsuk & "', '" & idtot & "', @TanggalTask, @LaporanPengaduan, @LaporanPengaduan, @IdStatusTask, @TglStatusTask, @IdProject, @AsalPengaduan, @NamaPelapor, @TelpPelapor, @AlamatPengaduan, '" & idprovinsi & "', '" & idkota & "', '" & provinsiupdate & "', '" & namakota & "', @DeskripsiPermasalahan, '" & Session("username") & "', GETDATE()) "
                End If

            Else
                If idpelanggan = "" Then
                    idsuk = idtask + 1
                    dstask.InsertCommand = "INSERT INTO trTask (NoTask, NomorPengaduan, TanggalTask, LaporanPengaduan, IdJenisTask, IdStatusTask, TglStatusTask, IdProject, AsalPengaduan, NamaPelapor, TelpPelapor, AlamatPengaduan, IdProvinsi, IdCity, Provinsi, City, DeskripsiPermasalahan, UserStamp, DateStamp) VALUES " &
                                     "('" & idsuk & "', '101', @TanggalTask, @LaporanPengaduan, @LaporanPengaduan, @IdStatusTask, @TglStatusTask, @IdProject, @AsalPengaduan, @NamaPelapor, @TelpPelapor, @AlamatPengaduan, '" & idprovinsi & "', '" & idkota & "', '" & provinsiupdate & "', '" & namakota & "', @DeskripsiPermasalahan, '" & Session("username") & "', GETDATE()) "
                Else
                    idtot = idpelanggan + 1
                    idsuk = idtask + 1
                    dstask.InsertCommand = "INSERT INTO trTask (NoTask, NomorPengaduan, TanggalTask, LaporanPengaduan, IdJenisTask, IdStatusTask, TglStatusTask, IdProject, AsalPengaduan, NamaPelapor, TelpPelapor, AlamatPengaduan, IdProvinsi, IdCity, Provinsi, City, DeskripsiPermasalahan, UserStamp, DateStamp) VALUES " &
                                          "('" & idsuk & "', '" & idtot & "', @TanggalTask, @LaporanPengaduan, @LaporanPengaduan, @IdStatusTask, @TglStatusTask, @IdProject, @AsalPengaduan, @NamaPelapor, @TelpPelapor, @AlamatPengaduan, '" & idprovinsi & "', '" & idkota & "', '" & provinsiupdate & "', '" & namakota & "', @DeskripsiPermasalahan, '" & Session("username") & "', GETDATE()) "
                End If

            End If

            grid_helpdesk.DataBind()
            grid_koordinator.DataBind()
            grid_manager.DataBind()

            dstask.DataBind()
            dstaskcoor.DataBind()
            dsmanager.DataBind()
            ' Response.Redirect("createtask.aspx")
        Catch ex As Exception
            clsg.writedata("Error", "Create Task", "HelpDesk", ex.Message, "")
        End Try
    End Sub

    Protected Sub grid_helpdesk_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_helpdesk.RowUpdating
        Try
            Dim provinsi As String = e.NewValues("IdProvinsi").ToString
            Dim kota As String = e.NewValues("IdCity").ToString

            Dim idkota As String = ""
            Dim namakota As String = ""
            Dim Getkota As String = "Select * from mskota where idKota = '" & kota & "' or Kota = '" & kota & "'"
            com = New SqlCommand(Getkota, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idkota = dr("idKota").ToString
                namakota = dr("Kota").ToString
            End If
            dr.Close()
            con.Close()

            Dim idprovinsi, provinsiupdate As String
            Dim getprovinsi As String = "select * from msProvinsi where IdProvinsi = '" & provinsi & "' or Provinsi = '" & provinsi & "'"
            com = New SqlCommand(getprovinsi, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idprovinsi = dr("IdProvinsi").ToString
                provinsiupdate = dr("Provinsi").ToString
            End If
            dr.Close()
            con.Close()

            dstask.UpdateCommand = "update trTask SET NomorPengaduan = @NomorPengaduan, TanggalTask = @TanggalTask, LaporanPengaduan = @LaporanPengaduan, IdJenisTask = @LaporanPengaduan, IdStatusTask = @IdStatusTask, TglStatusTask = @TglStatusTask, IdProject = @IdProject, AsalPengaduan = @AsalPengaduan, NamaPelapor = @NamaPelapor, TelpPelapor = @TelpPelapor, AlamatPengaduan = @AlamatPengaduan, IdProvinsi = '" & idprovinsi & "', Provinsi = '" & provinsiupdate & "', IdCity = '" & idkota & "', City = '" & namakota & "' ,DeskripsiPermasalahan = @DeskripsiPermasalahan, UserStamp = '" & Session("username") & "', DateStamp = GETDATE() WHERE ID = @ID"
            grid_helpdesk.DataBind()
            grid_koordinator.DataBind()
            grid_manager.DataBind()
            ' Response.Redirect("createtask.aspx")
        Catch ex As Exception
            clsg.writedata("Error", "Update Task", "HelpDesk", ex.Message, "")
        End Try
    End Sub

    Protected Sub grid_koordinator_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_koordinator.RowDeleting
        strsql = "delete trDetail_Task where NoTask='" & e.Values("NoTask") & "'"
        clsg.ExecuteNonQuery(strsql)
        dstaskcoor.DeleteCommand = "delete from trtask where ID = @ID"
        grid_helpdesk.DataBind()
        grid_koordinator.DataBind()
        grid_manager.DataBind()
        ' Response.Redirect("createtask.aspx")
    End Sub

    Protected Sub grid_koordinator_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_koordinator.RowInserting
        Try
            Dim idtask, idsuk As String
            Dim getidakhir As String = "select NoTask from trTask order by NoTask desc"
            com = New SqlCommand(getidakhir, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idtask = dr("NoTask").ToString
            End If
            dr.Close()
            con.Close()

            Dim provinsi As String = e.NewValues("IdProvinsi").ToString
            Dim Kota As String = e.NewValues("IdCity").ToString

            Dim idkota As String = ""
            Dim namakota As String = ""
            Dim Getkota As String = "Select * from mskota where idKota = '" & Kota & "' or Kota = '" & Kota & "'"
            com = New SqlCommand(Getkota, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idkota = dr("idKota").ToString
                namakota = dr("Kota").ToString
            End If
            dr.Close()
            con.Close()

            Dim idprovinsi, provinsiupdate As String
            Dim getprovinsi As String = "select * from msProvinsi where IdProvinsi = '" & provinsi & "' or Provinsi = '" & provinsi & "'"
            com = New SqlCommand(getprovinsi, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idprovinsi = dr("IdProvinsi").ToString
                provinsiupdate = dr("Provinsi").ToString
            End If
            dr.Close()
            con.Close()

            Dim tampungteknisi, tampungNIK As String
            Dim NamaTeknisi As String = clsg.ReplacePetik(e.NewValues("NamaTeknisi").ToString)
            Dim getjenisteknisi As String = "select IdStatusPegawai, NIK from msEmployee where Nama = '" & NamaTeknisi & "'"
            com = New SqlCommand(getjenisteknisi, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                tampungNIK = dr("NIK").ToString
                tampungteknisi = dr("IdStatusPegawai").ToString
            End If
            dr.Close()
            con.Close()

            If idtask = "" Then
                dstaskcoor.InsertCommand = "insert into trTask (NoTask, TanggalTask, NamaTask, IdKoordinator, NamaKoordinator, IdTeknisi, NamaTeknisi, TglMulai, TglSelesai, IdJenisTask, IdProvinsi, Provinsi, IdCity, City, CatatanKoordinator, TglStatusTask, IdProject, IdStatusTask, DeskripsiPermasalahan, AlamatPengaduan) VALUES ('100001', GETDATE(), @NamaTask, '" & Session("username") & "', '" & Session("namalogin") & "', '" & tampungNIK & "', @NamaTeknisi, @TglMulai, @TglSelesai, @IdJenisTask, '" & idprovinsi & "', '" & provinsiupdate & "', '" & idkota & "', '" & namakota & "', @CatatanKoordinator, @TglStatusTask, @IdProject, @IdStatusTask, @DeskripsiPermasalahan, @AlamatPengaduan)"
            Else
                idsuk = idtask + 1
                dstaskcoor.InsertCommand = "insert into trTask (NoTask, TanggalTask, NamaTask, IdKoordinator, NamaKoordinator, IdTeknisi, NamaTeknisi, TglMulai, TglSelesai, IdJenisTask, IdProvinsi, Provinsi, IdCity, City, CatatanKoordinator, TglStatusTask, IdProject, IdStatusTask, DeskripsiPermasalahan, AlamatPengaduan) VALUES ('" & idsuk & "', GETDATE(), @NamaTask, '" & Session("username") & "', '" & Session("namalogin") & "', '" & tampungNIK & "', @NamaTeknisi, @TglMulai, @TglSelesai, @IdJenisTask, '" & idprovinsi & "', '" & provinsiupdate & "', '" & idkota & "', '" & namakota & "', @CatatanKoordinator, @TglStatusTask, @IdProject, @IdStatusTask, @DeskripsiPermasalahan, @AlamatPengaduan)"
            End If

            Dim namaperusahaan, namaprovider As String
            Dim idproject As String = e.NewValues("IdProject").ToString
            Dim getlainnya As String = "select IdProject, IdPerusahaan, IdProvider from trProject where IdProject = '" & idproject & "'"
            com = New SqlCommand(getlainnya, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                namaperusahaan = dr("IdPerusahaan").ToString
                namaprovider = dr("IdProvider").ToString
            End If
            dr.Close()
            con.Close()

            Dim GetPerusahaan As String
            If namaperusahaan = "SCM" Then
                GetPerusahaan = "SC MEDIA"
            ElseIf namaperusahaan = "SA" Then
                GetPerusahaan = "Selindo Alpha"
            End If

            'Dim insertPermintaan As String = "insert into tr_permintaanSPD (NamaTeknisi, TypeTeknisi, NoTask, Provider, Perusahaan) VALUES ('" & e.NewValues("NamaTeknisi").ToString & "', '" & tampungteknisi & "', '" & idsuk & "', '" & namaprovider & "', '" & GetPerusahaan & "')"
            'com = New SqlCommand(insertPermintaan, con)
            'con.Open()
            'com.ExecuteNonQuery()
            'con.Close()
        Catch ex As Exception
            clsg.writedata("Error", "Create Task", "Koordinator", ex.Message, "")
        End Try
    End Sub

    Protected Sub grid_koordinator_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_koordinator.RowUpdating
        Try
            Dim provinsi As String = e.NewValues("IdProvinsi").ToString
            Dim Kota As String = e.NewValues("IdCity").ToString

            Dim idkota As String = ""
            Dim namakota As String = ""
            Dim Getkota As String = "Select * from mskota where idKota = '" & Kota & "' or Kota = '" & Kota & "'"
            com = New SqlCommand(Getkota, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idkota = dr("idKota").ToString
                namakota = dr("Kota").ToString
            End If
            dr.Close()
            con.Close()

            Dim idprovinsi, provinsiupdate As String
            Dim getprovinsi As String = "select * from msProvinsi where IdProvinsi = '" & provinsi & "' or Provinsi = '" & provinsi & "'"
            com = New SqlCommand(getprovinsi, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                idprovinsi = dr("IdProvinsi").ToString
                provinsiupdate = dr("Provinsi").ToString
            End If
            dr.Close()
            con.Close()

            Dim tampungteknisi, tampungNIK As String
            Dim NamaTeknisi As String = clsg.ReplacePetik(e.NewValues("NamaTeknisi").ToString)
            Dim getjenisteknisi As String = "select IdStatusPegawai, NIK from msEmployee where Nama = '" & NamaTeknisi & "'"
            com = New SqlCommand(getjenisteknisi, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                tampungNIK = dr("NIK").ToString
                tampungteknisi = dr("IdStatusPegawai").ToString
            End If
            dr.Close()
            con.Close()

            Dim namaperusahaan, namaprovider As String
            Dim idproject As String = e.NewValues("IdProject").ToString
            Dim getlainnya As String = "select IdProject, IdPerusahaan, IdProvider from trProject where IdProject = '" & idproject & "'"
            com = New SqlCommand(getlainnya, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                namaperusahaan = dr("IdPerusahaan").ToString
                namaprovider = dr("IdProvider").ToString
            End If
            dr.Close()
            con.Close()

            dstaskcoor.UpdateCommand = "update trTask SET AlamatPengaduan = @AlamatPengaduan, DeskripsiPermasalahan = @DeskripsiPermasalahan, NamaTask = @NamaTask, TanggalTask = GETDATE(), IdTeknisi = '" & tampungNIK & "', NamaTeknisi = @NamaTeknisi, IdKoordinator = '" & Session("username") & "', NamaKoordinator = '" & Trim(Session("namalogin")) & "', TglMulai = @TglMulai, TglSelesai = @TglSelesai, IdJenisTask = @IdJenisTask, IdProvinsi = '" & idprovinsi & "', Provinsi = '" & provinsiupdate & "', IdCity = '" & idkota & "', City = '" & namakota & "' ,CatatanKoordinator = @CatatanKoordinator, TglStatusTask = @TglStatusTask, IdProject = @IdProject, IdStatusTask = @IdStatusTask, IdUserKoordinator = '" & Session("username") & "' WHERE ID = @ID"
            grid_helpdesk.DataBind()
            grid_koordinator.DataBind()
            grid_manager.DataBind()
            ' Response.Redirect("createtask.aspx")




            Dim GetPerusahaan As String
            If namaperusahaan = "SCM" Then
                GetPerusahaan = "SC MEDIA"
            ElseIf namaperusahaan = "SA" Then
                GetPerusahaan = "Selindo Alpha"
            End If

            'Dim cektask As String = "select * from tr_permintaanSPD where NoTask = '" & e.NewValues("NoTask").ToString & "'"
            'com = New SqlCommand(cektask, con)
            'con.Open()
            'dr = com.ExecuteReader()
            'If dr.HasRows Then
            '    Dim insertPermintaan As String = "UPDATE tr_permintaanSPD SET NamaTeknisi = '" & e.NewValues("NamaTeknisi").ToString & "', TypeTeknisi = '" & tampungteknisi & "', Provider = '" & namaprovider & "', Perusahaan = '" & GetPerusahaan & "' where NoTask = '" & e.NewValues("NoTask") & "'"
            '    com = New SqlCommand(insertPermintaan, con1)
            '    con1.Open()
            '    com.ExecuteNonQuery()
            '    con1.Close()
            'Else
            '    Dim insertPermintaan As String = "insert into tr_permintaanSPD (NamaTeknisi, TypeTeknisi, NoTask, Provider, Perusahaan) VALUES ('" & e.NewValues("NamaTeknisi").ToString & "', '" & tampungteknisi & "', '" & e.NewValues("NoTask").ToString & "', '" & namaprovider & "', '" & GetPerusahaan & "')"
            '    com = New SqlCommand(insertPermintaan, con1)
            '    con1.Open()
            '    com.ExecuteNonQuery()
            '    con1.Close()
            'End If
            'dr.Close()
            'con.Close()
        Catch ex As Exception
            clsg.writedata("Error", "Update Task", "Koordinator", ex.Message, "")
        End Try
    End Sub

    Protected Sub grid_manager_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_manager.RowDeleting
        strsql = "delete trDetail_Task where NoTask='" & e.Values("NoTask") & "'"
        clsg.ExecuteNonQuery(strsql)
        dsmanager.DeleteCommand = "delete from trTask where ID = @ID"
        grid_manager.DataBind()
    End Sub



    Protected Sub grid_manager_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_manager.RowUpdating
        Try
            strsql = "select * from trTask where ID='" & e.Keys.Item("ID").ToString & "'"
            tbldata = clsg.ExecuteQuery(strsql)

            If IsDBNull(tbldata.Rows(0).Item("IdStatusManager")) = False Then
                If tbldata.Rows(0).Item("IdStatusManager") = "Valid" And e.NewValues("IdStatusManager") <> "Valid" Then
                    'Throw New Exception(tbldata.Rows(0).Item("NoTask") & " tidak dapat di ubah karena sudah valid")
                    grid_manager.CancelEdit()
                    Exit Sub
                ElseIf tbldata.Rows(0).Item("IdStatusManager") = "Valid" And e.OldValues("IdStatusManager") <> "Valid" Then
                    'Throw New Exception(tbldata.Rows(0).Item("NoTask") & " tidak dapat di ubah karena sudah valid")
                    grid_manager.CancelEdit()
                    Exit Sub
                End If
            End If

            ' Dim getidkoordinator As String = "select NIK from msEmployee where nama = '" & e.NewValues("NamaKoordinator") & "' and EmployeeType = 'coordinator'"

            'dsmanager.UpdateCommand = "Update trTask SET IdUserManager = '" & Session("username") & "',CatatanKoordinator=@CatatanKoordinator, " & _
            '    "CatatanManager = @CatatanManager, NamaKoordinator = @NamaKoordinator, IdStatusManager = @IdStatusManager, TglStatusManager = GETDATE(),AlamatPengaduan=@AlamatPengaduan where NoTask = '" & e.OldValues("NoTask").ToString & "'"
            'grid_manager.DataBind()

            If e.NewValues("NamaTeknisi").ToString <> Nothing Then
                strsql = "select NIK from msEmployee where Nama = '" & e.NewValues("NamaTeknisi") & "'"
            ElseIf e.NewValues("NamaTeknisi").ToString Is Nothing Then
                strsql = "select NIK from msEmployee where Nama = '" & e.NewValues("NamaTeknisi") & "'"
            Else
                strsql = "select NIK from msEmployee where Nama = '" & e.OldValues("NamaTeknisi") & "'"
            End If
            tbldata = clsg.ExecuteQuery(strsql)
            If tbldata.Rows.Count <> 0 Then
                tampung = tbldata.Rows(0).Item(0).ToString
            End If

            'strsql = "update trTask SET IdProject = @IdProject,IdUserManager = '" & Session("username") & "',CatatanKoordinator='" & clsg.ReplacePetik(e.NewValues("CatatanKoordinator")) & "', CatatanManager = '" & clsg.ReplacePetik(e.NewValues("CatatanManager")) & "'," & _
            '    " NamaKoordinator = '" & Trim(e.NewValues("NamaKoordinator")) & "', IdStatusManager = '" & e.NewValues("IdStatusManager") & "', TglStatusManager = GETDATE(),AlamatPengaduan='" & clsg.ReplacePetik(e.NewValues("AlamatPengaduan")) & "' where NoTask = '" & e.OldValues("NoTask").ToString & "'"
            strsql = "update trTask SET IdProject = @IdProject,TanggalTask=@TanggalTask,NamaTask=@NamaTask,IdTeknisi = '" & tampung & "',NamaTeknisi=@NamaTeknisi,TglMulai=@TglMulai,TglSelesai=@TglSelesai," &
            "DeskripsiPermasalahan=@DeskripsiPermasalahan,IdStatusTask=@IdStatusTask,IdUserManager = '" & Session("username") & "',CatatanKoordinator='" & clsg.ReplacePetik(e.NewValues("CatatanKoordinator")) & "', " &
            "CatatanManager = '" & clsg.ReplacePetik(e.NewValues("CatatanManager")) & "',NamaKoordinator = '" & Trim(e.NewValues("NamaKoordinator")) & "', IdStatusManager = '" & e.NewValues("IdStatusManager") & "', " &
            "TglStatusManager = GETDATE(),AlamatPengaduan='" & clsg.ReplacePetik(e.NewValues("AlamatPengaduan")) & "' where NoTask = '" & e.OldValues("NoTask").ToString & "'"
            clsg.writedata(Session("username"), "Update", "Task Manager", strsql, "")
            dsmanager.UpdateCommand = strsql
            grid_manager.DataBind()

            Dim Notask, namatask, tanggaltask, teknisi, email, project, tglmulai, tglselesai, permasalahan, catkoor, catman As String
            Dim getdataemail As String = "SELECT trTask.NoTask, trTask.IdProject, trTask.NamaTask, trTask.TanggalTask, trTask.NamaTeknisi,msEmployee.IdStatusPegawai, msEmployee.Email, trProject.ProjectName, " &
                                        "trTask.TglMulai, trTask.TglSelesai, trTask.DeskripsiPermasalahan, trTask.CatatanKoordinator, trTask.CatatanManager FROM trTask " &
                                        "INNER JOIN trProject ON trTask.IdProject = trProject.IdProject " &
                                        "INNER JOIN msEmployee ON trTask.IdTeknisi = msEmployee.NIK " &
                                        "WHERE NoTask = '" & e.OldValues("NoTask").ToString & "'"
            com = New SqlCommand(getdataemail, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            Notask = dr("NoTask").ToString
            namatask = dr("NamaTask").ToString
            tanggaltask = dr("TanggalTask").ToString
            teknisi = dr("NamaTeknisi").ToString
            email = dr("Email").ToString
            project = dr("ProjectName").ToString
            tglmulai = dr("TglMulai").ToString
            tglselesai = dr("TglSelesai").ToString

            If IsDBNull(dr("CatatanKoordinator")) = True Then
                catkoor = Nothing
            Else
                catkoor = dr("CatatanKoordinator")
            End If
            If IsDBNull(dr("CatatanManager")) = True Then
                catman = Nothing
            Else
                catman = e.NewValues("CatatanManager")
            End If
            If IsDBNull(dr("DeskripsiPermasalahan")) = True Then
                permasalahan = Nothing
            Else
                permasalahan = dr("DeskripsiPermasalahan").ToString
            End If
            StatusTeknisi = dr("IdStatusPegawai").ToString
            idproject = dr("IdProject").ToString
            dr.Close()
            con.Close()

            Dim RequestTittle As String = "New Task " & Notask & ""
            Dim Body As String
            Body &= "<hr noshade='noshade' style='background-color:#515041; height: 5px;'/>" &
                    "<p>Halo, kamu mendapatkan task/pekerjaan baru dengan detil sebagai berikut: </p>" &
                    "<br/>" &
                    "<p>No. Task : " & Notask & " </p>" &
                    "<p>Nama Task : " & namatask & "</p>" &
                    "<p>Tanggal Task : " & tanggaltask & "</p>" &
                    "<p>Project : " & project & "</p>" &
                    "<p>Tanggal Mulai : " & tglmulai & "</p>" &
                    "<p>Tanggal Selesai : " & tglselesai & "</p>" &
                    "<p>Permasalahan : " & permasalahan & "</p>" &
                    "<p>Catatan Koordinator : " & catkoor & "</p>" &
                    "<p>Catatan Manager : " & catman & "</p>" &
                    "<br/>" &
                    "<p><b>Dibawah ini adalah detail lokasi remote yang harus dikunjungi: </b></p>"
            Dim getlokasiremote As String = "select * from trDetail_Task where NoTask = '" & e.OldValues("NoTask").ToString & "'"
            com = New SqlCommand(getlokasiremote, con)
            con.Open()
            dr = com.ExecuteReader()
            While dr.Read
                Body &= "<p>VID : " & dr("VID").ToString & "</p>" &
                        "<p>IP LAN : " & dr("IPLAN").ToString & "</p>" &
                        "<p>Nama Remote : " & dr("NAMAREMOTE").ToString & "</p>" &
                        "<p>Alamat : " & dr("ALAMAT").ToString & "</p>" &
                        "<p>Jenis Task : " & dr("idJenisTask").ToString & "</p>" &
                        "<hr />"
            End While
            dr.Close()
            con.Close()

            'cari nama Perusahan dan Provider
            Dim namaperusahaan, namaprovider As String
            'Dim idproject As String = e.NewValues("IdProject").ToString
            Dim getlainnya As String = "select IdProject, IdPerusahaan, IdProvider from trProject where IdProject = '" & idproject & "'"
            com = New SqlCommand(getlainnya, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows() Then
                namaperusahaan = dr("IdPerusahaan").ToString
                namaprovider = dr("IdProvider").ToString
            End If
            dr.Close()
            con.Close()

            Dim GetPerusahaan As String
            If namaperusahaan = "SCM" Then
                GetPerusahaan = "SC MEDIA"
            ElseIf namaperusahaan = "SA" Then
                GetPerusahaan = "Selindo Alpha"
            End If
            strsql = "select COUNT(NoTask)Jml from tr_permintaanSPD where NoTask = '" & e.OldValues("NoTask").ToString & "'"
            tbldata = clsg.ExecuteQuery(strsql)

            If tbldata.Rows(0).Item("Jml") = 0 Then
                'strsql = "insert into tr_permintaanSPD (NamaTeknisi, TypeTeknisi, NoTask, Provider, Perusahaan) VALUES " & _
                '"('" & teknisi & "', '" & StatusTeknisi & "', '" & e.OldValues("NoTask").ToString & "', '" & namaprovider & "', '" & GetPerusahaan & "')"
                strsql = "insert into tr_permintaanSPD (NamaTeknisi, TypeTeknisi, NoTask, Provider, Perusahaan) VALUES " &
                "('" & teknisi & "', '" & StatusTeknisi & "', '" & e.OldValues("NoTask").ToString & "', '" & namaprovider & "', '" & namaperusahaan & "')"
            End If
            com = New SqlCommand(strsql, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()

            Body &= "<p>Good luck and thank you</p>" &
                    "<hr noshade='noshade' style='background-color:#515041; height: 5px;'/>" &
                    "<p style='text-align:center; margin-top:-60px;'><font size='1'>This email has been send from an automated system, Please do not reply</font></p>" &
                    "<p style='text-align:center;'><font size='2'>© PT Semesta Citra Media</font></p>"
            Using mm As New MailMessage(emailAcc, "syarief@invision-ap.com")
                Try
                    mm.Subject = RequestTittle
                    mm.Body = Body
                    mm.IsBodyHtml = True
                    Dim smtp As New SmtpClient()
                    smtp.Host = emailHost
                    smtp.EnableSsl = True
                    Dim NetworkCred As New NetworkCredential(emailAcc, emailPass)
                    smtp.UseDefaultCredentials = True
                    smtp.Credentials = NetworkCred
                    smtp.Port = emailPort
                    smtp.Send(mm)
                    ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('The email has been successfully');", True)
                Catch ex As Exception
                    ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email Not Delivered, There was a problem delivering your message to andri@tlt.co.id. See the technical details below');", True)
                End Try
            End Using
        Catch ex As Exception
            clsg.writedata("Error", "Update Task", "Manager", ex.Message, "")
        End Try
    End Sub


    Protected Sub grid_subtask_BeforePerformDataSelect(sender As Object, e As EventArgs)

        If cbfilter.Value = "" Then
            cbfilter.Value = "All Data"
        Else

            'lihome1.Attributes.Add("Class", "Active")
            'home1.Attributes.Add("Class", "tab-pane fade in active")

        End If
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim getproject As String = ""
        Dim getnotask As String = "select NoTask, IdProject,city from trTask where NoTask = '" & Session("NoTask") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            getproject = dr("IdProject").ToString
            tampung = dr("NoTask").ToString
			namaCity=dr("city").ToString
        End If
        dr.Close()
        con.Close()
        dssubtask.SelectCommand = "exec res_LokasiRemoteSiteSekitar '" & Session("NamaProvinsi") & "','"& namaCity &"', '" & cbfilter.Value & "', '" & Session("project") & "', '" & Session("tglmulai") & "'"
        ' dssubtask.SelectCommand = "select * from trTask where NoTask = '" & tampung & "' and NoSubTask <> '' order by ID Desc"
		'clsg.writedata(Session("UserName"), "Data", "Foto", dssubtask.SelectCommand, "")
    End Sub

    Protected Sub grid_subtask_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim cekprov As String = e.Values("NoSubTask").ToString
        Dim getid As String = e.Values("NoSubTask").ToString

        dssubtask.DeleteCommand = "delete from trtask where NoSubTask='" & getid & "'"
    End Sub

    Protected Sub grid_subtask_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim getnotask As String = "select NoSubTask, NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        NoSubtask = dr("NoSubTask").ToString
        tampung = dr("NoTask").ToString
        dr.Close()
        con.Close()

        If NoSubtask = "" Then
            dssubtask.InsertCommand = "Insert into trTask (NoSubTask, NoTask, TanggalTask, IdTeknisi, TglMulai, TglSelesai, NamaTask, CatatanKoordinator, IdStatusKoordinator, TglStatusTask, UserStamp, DateStamp, IdProject, IdStatusTask, IdProvinsi, IdCity) VALUES ('" & tampung & "001', '" & tampung & "', GETDATE(), @IdTeknisi, @TglMulai, @TglSelesai, @NamaTask, @CatatanKoordinator, @IdStatusKoordinator, @TglStatusTask, '" & Session("username") & "', GETDATE(), @IdProject, @IdStatusTask, @IdProvinsi, @IdCity)"
        Else
            Dim idsuk, idsuk1 As String
            Dim idakhir As String = "select NoSubTask from trTask where NoTask = '" & tampung & "' order by NoSubTask Desc"
            com = New SqlCommand(idakhir, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            idsuk = dr("NoSubTask").ToString
            dr.Close()
            con.Close()

            idsuk1 = idsuk + 1
            dssubtask.InsertCommand = "Insert into trTask (NoSubTask, NoTask, TanggalTask, IdTeknisi, TglMulai, TglSelesai, NamaTask, CatatanKoordinator, IdStatusKoordinator, TglStatusTask, UserStamp, DateStamp, IdProject, IdStatusTask, IdProvinsi, IdCity) VALUES ('" & idsuk1 & "', '" & tampung & "', GETDATE(), @IdTeknisi, @TglMulai, @TglSelesai, @NamaTask, @CatatanKoordinator, @IdStatusKoordinator, @TglStatusTask, '" & Session("username") & "', GETDATE(), @IdProject, @IdStatusTask, @IdProvinsi, @IdCity)"
        End If

    End Sub

    Protected Sub grid_subtask_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        'Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        'Dim getnotask As String = "select NoSubTask, NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        'com = New SqlCommand(getnotask, con)
        'con.Open()
        'dr = com.ExecuteReader()
        'dr.Read()
        'NoSubtask = dr("NoSubTask").ToString
        'tampung = dr("NoTask").ToString
        'dr.Close()
        'con.Close()
        Dim cekprov As String = e.NewValues("NoSubTask").ToString
        Dim getid As String = e.OldValues("NoSubTask").ToString

        dssubtask.UpdateCommand = "Update trTask set IdTeknisi = @IdTeknisi, TglMulai = @TglMulai, TglSelesai = @TglSelesai, NamaTask = @NamaTask, CatatanKoordinator = @CatatanKoordinator, IdStatusKoordinator = @IdStatusKoordinator, TglStatusTask = @TglStatusTask, IdProject = @IdProject, IdStatusTask = @IdStatusTask, IdProvinsi = @IdProvinsi, IdCity = @IdCity, UserStamp = '" & Session("username") & "', DateStamp = GETDATE() WHERE NoSubTask = '" & cekprov & "'"
    End Sub

    Protected Sub grid_VID_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        dsdetailtask.DeleteCommand = "delete from trDetail_Task where NoListTask = @NoListTask"
    End Sub

    Protected Sub grid_VID_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Dim tampungVID As String = e.NewValues("VID")
        Dim getdetiltask As String = "select * from trRemoteSite where VID = '" & tampungVID & "'"
        com = New SqlCommand(getdetiltask, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        VID = dr("VID").ToString
        NamaRemote = dr("NAMAREMOTE").ToString
        IPLAN = dr("IPLAN").ToString
        SID = dr("SID").ToString
        ALamatInstall = dr("AlamatInstall").ToString
        Provinsi = dr("PROVINSI").ToString
        Kota = dr("KOTA").ToString
        IDJARKOM = dr("idjarkom").ToString
        PIC = dr("PIC").ToString
        CustPhone = dr("CustPhone").ToString

        dr.Close()
        con.Close()

        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungstatus, tampungidjenistask As String
        Dim getnotask As String = "select NoTask, IdStatusTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
            tampungstatus = dr("IdStatusTask").ToString
            'tampungidjenistask = dr("IdJenisTask").ToString
        End If
        dr.Close()
        con.Close()

        Dim updatestatus As String = "Update TrTask set IdStatusTask = '" & tampungstatus & "' where NoTask = '" & tampung & "'"
        com = New SqlCommand(updatestatus, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        dsdetailtask.InsertCommand = "insert into trDetail_Task (PIC, NoHpPic, NoTask, VID, NAMAREMOTE, IPLAN, SID, ALAMAT, PROVINSI, KOTA, IdJarkom, IdStatusPerbaikan, " & _
		"idJenisTask, UserStamp, DateStamp) VALUES ('" & PIC & "', '" & CustPhone & "' ,'" & tampung & "', '" & VID & "', '" & NamaRemote & "', '" & IPLAN & "', " & _
		"'" & SID & "', '" & ALamatInstall & "', '" & Provinsi & "', '" & Kota & "', '" & IDJARKOM & "', '" & tampungstatus & "', @idJenisTask, '" & Session("username") & "', GETDATE())"

    End Sub

    Protected Sub grid_VID_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        dsdetailtask.UpdateCommand = "update trDetail_Task set IdStatusPerbaikan=@IdStatusPerbaikan where NoListTask = @NoListTask"
        strsql = "select NoTask,max(bykFinish) bfinish,max(bykOpen) [bopen] from ( " &
        "Select NoTask,count(NoTask)bykFinish,0 bykOpen,idJenisTask as idJenisTaskNew from trDetail_Task where IdStatusPerbaikan=4 and NoTask='" & e.OldValues("NoTask") & "' " &
        "group by NoTask, idJenisTask " &
        "union " &
        "select NoTask,0 bykFinish,count(NoTask) bykOpen,idJenisTask as idJenisTaskNew from trDetail_Task where IdStatusPerbaikan<>4 and NoTask='" & e.OldValues("NoTask") & "' " &
        "group by NoTask, idJenisTask " &
        ") a group by NoTask, idJenisTaskNew"
        tbldata = clsg.ExecuteQuery(strsql)
        If tbldata.Rows(0).Item("bfinish") = tbldata.Rows(0).Item("bopen") Then
            strsql = "update trTask SET IdStatusTask=4 where NoTask = '" & e.OldValues("NoTask").ToString & "'"
        Else
            strsql = "update trTask SET IdStatusTask=1 where NoTask = '" & e.OldValues("NoTask").ToString & "'"
        End If
        clsg.ExecuteNonQuery(strsql)
        grid_manager.DataBind()
        'Exit Sub

        Dim tampungVID As String = e.NewValues("VID")
        Dim tampungold As String = e.OldValues("VID")
        Dim tampungTaskOld As String = e.OldValues("NoTask")
        Dim tampungstatus As String = e.NewValues("IdStatusPerbaikan")
        'Dim CttnKoordinatorOld As String = e.OldValues("CatatanKoordinator")
        Dim CttnKoordinatorNew As String = e.NewValues("CatatanKoordinator")
        'Dim idJenisTaskOld As String = e.OldValues("idJenisTask")
        Dim idJenisTaskNew As String = e.NewValues("idJenisTaskNew")


        Dim getdetiltask As String = "select * from trRemoteSite where VID = '" & tampungVID & "'"
        com = New SqlCommand(getdetiltask, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        VID = dr("VID").ToString
        NamaRemote = dr("NAMAREMOTE").ToString
        IPLAN = dr("IPLAN").ToString
        SID = dr("SID").ToString
        ALamatInstall = dr("AlamatInstall").ToString
        Provinsi = dr("PROVINSI").ToString
        Kota = dr("KOTA").ToString
        IDJARKOM = dr("idjarkom").ToString
        PIC = dr("PIC").ToString
        CustPhone = dr("CustPhone").ToString
        dr.Close()
        con.Close()

        Dim updatestatus As String = "Update TrTask set IdStatusTask = '" & tampungstatus & "' where NoTask = '" & tampungTaskOld & "'"
        com = New SqlCommand(updatestatus, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        dsdetailtask.UpdateCommand = "UPDATE trDetail_Task SET PIC = '" & PIC & "', NoHpPic = '" & CustPhone & "', VID ='" & VID & "', NAMAREMOTE = '" & NamaRemote & "', IPLAN = '" & IPLAN & "', SID = '" & SID & "', ALAMAT = '" & ALamatInstall & "', PROVINSI ='" & Provinsi & "', KOTA = '" & Kota & "', IdJarkom = '" & IDJARKOM & "', IdStatusPerbaikan = '" & tampungstatus & "', idJenisTask = @idJenisTask , UserStamp = '" & Session("username") & "', DateStamp = GETDATE(), CatatanKoordinator = '" & CttnKoordinatorNew & "' where NoTask = '" & tampungTaskOld & "' and VID = '" & tampungold & "'"

    End Sub

    Protected Sub grid_VID_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim getnotask As String = "select trtask.NoTask, trtask.TglMulai, trRemoteSite.VID, trRemoteSite.Latitude, trRemoteSite.Longitude from trTask " & _
                                "LEFT OUTER JOIN trDetail_Task On trTask.NoTask = trDetail_Task.NoTask " & _
                                "LEFT OUTER JOIN trRemoteSite on trDetail_Task.VID = trRemoteSite.VID where trtask.ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
            note = dr("NoTask").ToString
            Session("TglMulai") = dr("TglMulai").ToString
            latitude = dr("Latitude").ToString
            longitude = dr("Longitude").ToString
            VIDjarak = dr("VID").ToString
        End If
        dr.Close()
        con.Close()
        dsdetailtask.SelectCommand = "select * from trDetail_Task where NoTask = '" & tampung & "' order by NoListTask desc"
        'dsdetailtask.SelectCommand = "select a.NoListTask,b.ID,b.NoTask,a.NoTask,b.CatatanKoordinator, a.SID, a.VID, a.IPLAN, a.NAMAREMOTE, a.ALAMAT, a.IdStatusPerbaikan, a.idJenisTask from trDetail_Task a LEFT OUTER JOIN trTask b On b.NoTask = a.NoTask where a.NoTask = '" & tampung & "' order by NoListTask desc"
    End Sub


    Protected Sub grid_barang_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()

        dsbarang.SelectCommand = "select * from msVsat_Set where NoTask = '" & tampung & "'"
    End Sub

    Protected Sub grid_barang_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        NamaBarang = e.NewValues("NamaBarang")
        Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()

        dsbarang.InsertCommand = "INSERT INTO msVsat_Set (NoTask, KodeBarang, NamaBarang, SN, Qty) VALUES ('" & tampung & "', @NamaBarang, @NamaBarang,  @SN, @Qty)"
    End Sub

    Protected Sub grid_barang_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim NoTask123 As String = e.OldValues("NoTask")
        dsbarang.UpdateCommand = "Update msVsat_Set SET KodeBarang = @NamaBarang, NamaBarang = @NamaBarang, SN = @SN,  Qty = @Qty where ID = @ID"
    End Sub

    Protected Sub grid_barang_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim NoTask123 As String = e.Values("NoTask")
        dsbarang.DeleteCommand = "delete from msVsat_Set where ID = @ID"
    End Sub

    Protected Sub grid_VID_Manager_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()
        dsdetailtaskmanager.SelectCommand = "select * from trDetail_Task where NoTask = '" & tampung & "'"
    End Sub

    Protected Sub grid_VID_Manager_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        dsdetailtaskmanager.DeleteCommand = "delete from trDetail_Task where NoListTask = @NoListTask"
    End Sub

    Protected Sub grid_VID_Manager_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Dim tampungVID As String = e.NewValues("VID")
        Dim getdetiltask As String = "select * from trRemoteSite where VID = '" & tampungVID & "'"
        com = New SqlCommand(getdetiltask, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        VID = dr("VID").ToString
        NamaRemote = dr("NAMAREMOTE").ToString
        IPLAN = dr("IPLAN").ToString
        SID = dr("SID").ToString
        ALamatInstall = dr("AlamatInstall").ToString
        dr.Close()
        con.Close()

        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()

        dsdetailtaskmanager.InsertCommand = "insert into trDetail_Task (NoTask, VID, NAMAREMOTE, IPLAN, SID, ALAMAT, UserStamp, DateStamp) VALUES ('" & tampung & "', '" & VID & "', '" & NamaRemote & "', '" & IPLAN & "', '" & SID & "', '" & ALamatInstall & "', '" & Session("username") & "', GETDATE())"
    End Sub

    Protected Sub grid_VID_Manager_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim tampungVID As String = e.NewValues("VID")
        Dim tampungold As String = e.OldValues("VID")
        Dim tampungTaskOld As String = e.OldValues("NoTask")


        Dim getdetiltask As String = "select * from trRemoteSite where VID = '" & tampungVID & "'"
        com = New SqlCommand(getdetiltask, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        VID = dr("VID").ToString
        NamaRemote = dr("NAMAREMOTE").ToString
        IPLAN = dr("IPLAN").ToString
        SID = dr("SID").ToString
        ALamatInstall = dr("AlamatInstall").ToString
        dr.Close()
        con.Close()

        dsdetailtaskmanager.UpdateCommand = "UPDATE trDetail_Task SET VID ='" & VID & "', NAMAREMOTE = '" & NamaRemote & "', IPLAN = '" & IPLAN & "', SID = '" & SID & "', ALAMAT = '" & ALamatInstall & "', UserStamp = '" & Session("username") & "', DateStamp = GETDATE() where NoTask = '" & tampungTaskOld & "' and VID = '" & tampungold & "'"

    End Sub

    Protected Sub grid_barang_Manager_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()
        dsbarangmanager.InsertCommand = "INSERT INTO msVsat_Set (NoTask, KodeBarang, NamaBarang, SN, Qty) VALUES ('" & tampung & "', @NamaBarang, @NamaBarang,  @SN, @Qty)"
        'dsbarangmanager.InsertCommand = "INSERT INTO msVsat_Set (NoTask, KodeBarang, NamaBarang, Type, SN, SNCac, SNChasing, Adaptor, Qty) VALUES ('" & tampung & "', @KodeBarang, @KodeBarang, @Type, @SN, @SNCac, @SNChasing, @Adaptor, @Qty)"
    End Sub

    Protected Sub grid_barang_Manager_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim NoTask123 As String = e.OldValues("NoTask")
        dsbarangmanager.UpdateCommand = "Update msVsat_Set SET KodeBarang = @NamaBarang, NamaBarang = @NamaBarang, SN = @SN,  Qty = @Qty where ID = @ID"
        'dsbarangmanager.UpdateCommand = "Update msVsat_Set SET KodeBarang = @KodeBarang, NamaBarang = @KodeBarang, Type = @Type, SN = @SN, SNCac = @SNCac, SNChasing = @SNChasing, Adaptor= @Adaptor, Qty = @Qty where ID = @ID"
    End Sub

    Protected Sub grid_barang_Manager_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim NoTask123 As String = e.Values("NoTask")
        dsbarangmanager.DeleteCommand = "delete from msVsat_Set where ID = @ID"
    End Sub

    Protected Sub grid_barang_Manager_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()

        dsbarangmanager.SelectCommand = "select * from msVsat_Set where NoTask = '" & tampung & "'"
    End Sub

    'Protected Sub Grid_Uang_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
    '    Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

    '    Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
    '    com = New SqlCommand(getnotask, con)
    '    con.Open()
    '    dr = com.ExecuteReader()
    '    If dr.HasRows Then
    '        dr.Read()
    '        tampung = dr("NoTask").ToString
    '    End If
    '    dr.Close()
    '    con.Close()

    '    dsuang.InsertCommand = "INSERT INTO tr_biaya (NoTask, TglPengajuan, JumlahPengajuan, Catatan, UserCreate, DateCreate) VALUES ('" & tampung & "', GETDATE(), @JumlahPengajuan, @Catatan, '" & Session("username") & "', GETDATE())"
    'End Sub

    'Protected Sub Grid_Uang_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
    '    dsuang.UpdateCommand = "UPDATE tr_biaya set TglPengajuan = @TglPengajuan, JumlahPengajuan = @JumlahPengajuan, Catatan = @Catatan, UserUpdate = '" & Session("username") & "', DateUpdate = GETDATE() where ID = @ID"
    'End Sub

    'Protected Sub Grid_Uang_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
    '    dsuang.DeleteCommand = "delete from tr_biaya where ID = @ID"
    'End Sub

    'Protected Sub Grid_Uang_BeforePerformDataSelect(sender As Object, e As EventArgs)
    '    Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

    '    Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
    '    com = New SqlCommand(getnotask, con)
    '    con.Open()
    '    dr = com.ExecuteReader()
    '    If dr.HasRows Then
    '        dr.Read()
    '        tampung = dr("NoTask").ToString
    '    End If
    '    dr.Close()
    '    con.Close()

    '    dsuang.SelectCommand = "select * from tr_biaya where NoTask = '" & tampung & "'"
    '    dsuang.DataBind()
    'End Sub

    Protected Sub grid_helpdesk_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)
        Select Case e.Column.FieldName
            'Case "JenisTransaksi"
            '    InitializeCombo(e, "CategoryID", dsmCategory, AddressOf cmbCombo2_OnCallback)
            Case "IdCity"
                InitializeComboCity(e, "IdCity", dskota, AddressOf cmbCombo3_OnCallback)

            Case Else
        End Select
        If grid_helpdesk.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
        End If
    End Sub

    Protected Sub InitializeComboCity(ByVal e As ASPxGridViewEditorEventArgs, ByVal parentComboName As String, ByVal source As SqlDataSource, ByVal callBackHandler As CallbackEventHandlerBase)

        Dim id As String = String.Empty
        If (Not grid_helpdesk.IsNewRowEditing) Then
            Dim val As Object = grid_helpdesk.GetRowValuesByKeyValue(e.KeyValue, parentComboName)
            If (val Is Nothing OrElse val Is DBNull.Value) Then
                id = Nothing
            Else
                id = val.ToString()
            End If
        End If
        Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
        If combo IsNot Nothing Then
            ' unbind combo
            combo.DataSourceID = Nothing
            FillComboSubject(combo, id, source)
            AddHandler combo.Callback, callBackHandler
        End If
        Return
    End Sub

    Private Sub cmbCombo3_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
        FillComboUnitKerja(TryCast(source, ASPxComboBox), e.Parameter, dskota)
    End Sub

    Protected Sub FillComboUnitKerja(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
        cmb.Items.Clear()
        ' trap null selection
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        ' get the values
        source.SelectParameters(0).DefaultValue = id
        Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
        For Each row As DataRowView In view
            cmb.Items.Add(row(3).ToString(), row(1))
        Next row
    End Sub

    Protected Sub FillComboSubject(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
        cmb.Items.Clear()
        ' trap null selection
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        ' get the values
        source.SelectParameters(0).DefaultValue = id
        Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
        For Each row As DataRowView In view
            cmb.Items.Add(row(4).ToString(), row(2))
        Next row
    End Sub


    Private Sub FillCitiesComboBox(aSPxComboBox As ASPxComboBox, p2 As String, sqlDataSource As SqlDataSource)
        Throw New NotImplementedException
    End Sub

    Protected Sub grid_koordinator_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)
        Select Case e.Column.FieldName
            'Case "JenisTransaksi"
            '    InitializeCombo(e, "CategoryID", dsmCategory, AddressOf cmbCombo2_OnCallback)
            Case "IdCity"
                InitializeComboCity(e, "IdCity", dskota, AddressOf cmbCombo3_OnCallback)

            Case Else
        End Select
        If grid_helpdesk.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
        End If
    End Sub

    Protected Sub grid_barang_on_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("VID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim VID As String
        Dim getidproject As String = "select * from trDetail_Task where NoListTask = '" & Session("VID") & "'"
        com = New SqlCommand(getidproject, con)
        con.Open()
        dr = com.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            VID = dr("VID").ToString
        End If
        dr.Close()
        con.Close()

        dsbarang_on.SelectCommand = "select * from trRemoteSite_D where VID = '" & VID & "'"
    End Sub

    Protected Sub cbfilter_SelectedIndexChanged(sender As Object, e As EventArgs)

        If cbfilter.Value = "" Then
            cbfilter.Value = "All Data"
        Else

        End If

        'lihome1.Attributes.Add("Class", "Active")
        'home1.Attributes.Add("Class", "tab-pane fade in active")

        Dim strGetData As String
        strGetData = "SELECT trTask.NoTask, trtask.Provinsi, trtask.IdProject, trtask.TglMulai,city from trTask " & _
                    "where trTask.NoTask = '" & note.ToString & "'"
        com = New SqlCommand(strGetData, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Dim project As String = dr("IdProject").ToString
        Dim NamaProvinsi As String = dr("Provinsi").ToString
        Dim NoTask As String = dr("NoTask").ToString
		namaCity=dr("city").ToString
        'Session("notask") = dr("NoTask").ToString
        dr.Close()
        con.Close()
        litText.Text = "Provinsi : " & NamaProvinsi &", Kota : " & namaCity
        Session("NamaProvinsi") = NamaProvinsi
        Session("NoTask") = NoTask
        dssubtask.SelectCommand = "exec res_LokasiRemoteSiteSekitar '" & NamaProvinsi & "','"& namaCity &"', '" & cbfilter.Value & "', '" & Session("project") & "', '" & Session("tglmulai") & "'"
		'clsg.writedata(Session("UserName"), "Data", "Foto", dssubtask.SelectCommand, "")
    End Sub

    Protected Sub gridhistory_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("VID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim VID As String
        Dim getidproject As String = "select * from trDetail_Task where NoListTask = '" & Session("VID") & "'"
        com = New SqlCommand(getidproject, con)
        con.Open()
        dr = com.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            VID = dr("VID").ToString
        End If
        dr.Close()
        con.Close()

        dsgridhistory.SelectCommand = "SELECT trDetail_Task.NoListTask, trDetail_Task.VID, trDetail_Task.NoTask, trTask.NamaTeknisi, trDetail_Task.TglSelesaiKerjaan, trDetail_Task.idJenisTask " & _
                                        "FROM trTask INNER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask where trDetail_Task.VID = '" & VID & "'"
    End Sub

    Protected Sub grid_koordinator_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("IDCOBA") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
    End Sub


    'Protected Sub Grid_Validasi_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
    '    dsstatusvalidasi.InsertCommand = "insert into trtask (IdStatusKoordinator) VALUES (@IdStatusKoordinator)"
    '    dsstatusvalidasi.DataBind()
    'End Sub

    'Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
    'Throw New CustomExceptions.MyException("Data updates aren't allowed in online examples")
    'End Sub
    Protected Sub Grid_Validasi_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Try
            If e.NewValues("IdStatusKoordinator").ToString = "Valid" Then
                dsstatusvalidasi.UpdateCommand = "update trtask set IdStatusKoordinator = @IdStatusKoordinator,TglStatusKoordinator=getdate(), " &
                    "IdStatusManager='Valid', TglStatusManager=getdate(), CatatanManager='Laksanakan Segera!', IdUserManager='233019505' where ID=@ID"
            Else
                dsstatusvalidasi.UpdateCommand = "update trtask set IdStatusKoordinator = @IdStatusKoordinator,TglStatusKoordinator=getdate() where ID=@ID"
            End If
            dsstatusvalidasi.DataBind()
        Catch ex As Exception
            Throw New Exception("Remote location is empty.")
        End Try

    End Sub

    Protected Sub Grid_Validasi_ExpandedChanged(ByVal source As Object, ByVal e As DevExpress.Web.NavBarGroupEventArgs)
        Throw New Exception("Remote location is empty.")
    End Sub

    Protected Sub grid_CellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs)
        Dim gridView As ASPxGridView = CType(sender, ASPxGridView)
        Dim tampung2 As String = ""

        If (Not gridView.IsNewRowEditing) Then
            'Dim keyValue As Int32 = CInt(Fix(gridView.GetRowValues(gridView.EditingRowVisibleIndex, New String() {gridView.KeyFieldName})))
            'select * from trDetail_Task where NoTask = '" & tampung & "' order by NoListTask desc
            Dim getnotask2 As String = "select NoTask from trDetail_Task where NoTask = '" & tampung & "' order by NoListTask desc"
            com = New SqlCommand(getnotask2, con)
            con.Open()
            dr = com.ExecuteReader()
            If dr.HasRows Then
                dr.Read()
                tampung2 = dr("NoTask").ToString
            End If
            dr.Close()
            con.Close()

            If e.Column.FieldName = "IdStatusKoordinator" Then
                If tampung2 = "" Then
                    e.Editor.Enabled = False
                Else
                    e.Editor.Enabled = True
                End If
            End If
        End If
    End Sub
    Protected Sub Grid_Validasi_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        Dim getnotask As String = "select NoTask from trTask where ID = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()

        dsstatusvalidasi.SelectCommand = "select * from trtask where NoTask = '" & tampung & "'"
        dsstatusvalidasi.DataBind()
    End Sub

    Protected Sub cbjarak_ValueChanged(sender As Object, e As EventArgs)
       
    End Sub

    Protected Sub popup_grid_jarak_BeforePerformDataSelect(sender As Object, e As EventArgs)

        If cbfilter.Value = "" Then
            cbfilter.Value = "1"
            
        Else

        End If
        'liprofile1.Attributes.Add("Class", "Active")
        'profile1.Attributes.Add("Class", "tab-pane fade in active")

        'If latitude.ToString = "" Then
        '    latitude = "-2.5489"
        '    longitude = "118.0149"
        'End If

        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim getproject As String = ""
        Dim getnotask As String = "select NoTask, IdProject from trTask where NoTask = '" & Session("NoTask") & "'"
        com = New SqlCommand(getnotask, con)
        con.Open()
        dr = com.ExecuteReader()
        If dr.HasRows Then
            dr.Read()
            getproject = dr("IdProject").ToString
            tampung = dr("NoTask").ToString
        End If
        dr.Close()
        con.Close()
        'dsjarak.SelectCommand = "exec SP_Distance_Latlong '%" & Session("NamaProvinsi") & "%', '" & latitude.ToString & "', '" & longitude.ToString & "', '" & cbjarak.Value & "'"
        ' dssubtask.SelectCommand = "select * from trTask where NoTask = '" & tampung & "' and NoSubTask <> '' order by ID Desc"

    End Sub

    Protected Sub callbackPanelX_Callback(sender As Object, e As CallbackEventArgsBase) Handles callbackPanelX.Callback
        If cbfilter.Value = "" Then
            cbfilter.Value = "All Data"
        Else

        End If

        'lihome1.Attributes.Add("Class", "Active")
        'home1.Attributes.Add("Class", "tab-pane fade in active")

        Dim strGetData As String
        strGetData = "SELECT trTask.NoTask, trtask.Provinsi, trtask.IdProject,city, trtask.TglMulai from trTask " & _
                    "where trTask.NoTask = '" & note.ToString & "'"
        com = New SqlCommand(strGetData, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Dim project As String = dr("IdProject").ToString
        Dim NamaProvinsi As String = dr("Provinsi").ToString
        Dim NoTask As String = dr("NoTask").ToString
		namaCity=dr("city").ToString
        'Session("notask") = dr("NoTask").ToString
        dr.Close()
        con.Close()
        litText.Text = "Provinsi : " & NamaProvinsi &", Kota : " & namaCity
        Session("NamaProvinsi") = NamaProvinsi
        Session("NoTask") = NoTask
        dssubtask.SelectCommand = "exec res_LokasiRemoteSiteSekitar '" & NamaProvinsi & "','"& namaCity &"', '" & cbfilter.Value & "', '" & Session("project") & "', '" & Session("tglmulai") & "'"
		'clsg.writedata(Session("UserName"), "Data", "Foto", dssubtask.SelectCommand, "")
    End Sub

    Protected Sub cbjarak_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbjarak.Value = "" Then
            cbjarak.Value = "1"
        Else

        End If

        'lihome.Attributes.Remove("Class")
        'home1.Attributes.Remove("Class")

        'liprofile.Attributes.Add("Class", "Active")
        'profile1.Attributes.Add("Class", "tab-pane fade in active")

        If latitude.ToString = "" Then
            latitude = "-2.5489"
            longitude = "118.0149"
        End If
        Dim strGetData As String
        strGetData = "SELECT trTask.NoTask, trtask.Provinsi, trtask.IdProject, trtask.TglMulai from trTask " & _
                    "where trTask.NoTask = '" & note.ToString & "'"
        com = New SqlCommand(strGetData, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Dim project As String = dr("IdProject").ToString
        Dim NamaProvinsi As String = dr("Provinsi").ToString
        Dim NoTask As String = dr("NoTask").ToString
        'Session("notask") = dr("NoTask").ToString
        dr.Close()
        con.Close()
        litText.Text = "Provinsi : " & NamaProvinsi
        Session("NamaProvinsi") = NamaProvinsi
        Session("NoTask") = NoTask
        dsjarak.SelectCommand = "exec SP_Distance_Latlong '%" & NamaProvinsi & "%', '" & latitude.ToString & "', '" & longitude.ToString & "', '" & cbjarak.Value & "'"
		'clsg.writedata(Session("UserName"), "Data", "Foto", dsjarak.SelectCommand, "")
    End Sub

    Protected Sub callbackPanel1_Callback(sender As Object, e As CallbackEventArgsBase) Handles callbackPanel1.Callback
        If cbjarak.Value = "" Then
            cbjarak.Value = "1"
        Else

        End If

        'lihome.Attributes.Remove("Class")
        'home1.Attributes.Remove("Class")

        'liprofile.Attributes.Add("Class", "Active")
        'profile1.Attributes.Add("Class", "tab-pane fade in active")

        If latitude.ToString = "" Then
            latitude = "-2.5489"
            longitude = "118.0149"
        End If
        Dim strGetData As String
        strGetData = "SELECT trTask.NoTask, trtask.Provinsi, trtask.IdProject, trtask.TglMulai from trTask " & _
                    "where trTask.NoTask = '" & note.ToString & "'"
        com = New SqlCommand(strGetData, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Dim project As String = dr("IdProject").ToString
        Dim NamaProvinsi As String = dr("Provinsi").ToString
        Dim NoTask As String = dr("NoTask").ToString
        'Session("notask") = dr("NoTask").ToString
        dr.Close()
        con.Close()
        litText.Text = "Provinsi : " & NamaProvinsi
        Session("NamaProvinsi") = NamaProvinsi
        Session("NoTask") = NoTask
        dsjarak.SelectCommand = "exec SP_Distance_Latlong '%" & NamaProvinsi & "%', '" & latitude.ToString & "', '" & longitude.ToString & "', '" & cbjarak.Value & "'"
		'clsg.writedata(Session("UserName"), "Data", "Foto", dsjarak.SelectCommand, "")
    End Sub

End Class
