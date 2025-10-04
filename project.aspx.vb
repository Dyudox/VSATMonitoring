Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Bootstrap
Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.OleDb
Imports System.Data
Imports DevExpress.Web.ASPxEdit
Imports System.IO
Partial Class project
    Inherits System.Web.UI.Page
    Dim con, sqlcon, ep As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    'Dim mcon As New SqlConnection(ConfigurationManager.ConnectionStrings("masterconn").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand
    Dim excelscheme, dtlexcel As DataTable
    Dim conexcel As OleDbConnection
    Dim comexcel As OleDbDataAdapter
    Dim constr, sheetname, sqlexcel, tmpstr, strsql, notask, hub, IdStatusTask As String
    Dim IdProvinsi, Provinsi, IdCity, kota, jnsTask, kanwil, KANCAINDUK, ALAMAT As String
    Dim dataset As DataSet
    Dim clsg As New cls_global
    Dim tbldata, tbldata_Notask, tbldata_Wilayah, tbldata_hub, tbldata_IdStatusTask As DataTable

    Protected Sub grid_project_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_project.RowDeleting
        dsproject.DeleteCommand = "delete from trproject where ID = @ID"
        grid_project.DataBind()
    End Sub

    Public Function ReplaceSpecialLetter(ByVal str)
        tmpstr = str
        'tmpstr = Replace(tmpstr, "N/A", "NULL")
        TmpStr = Replace(TmpStr, "'", "&#39;")
        ReplaceSpecialLetter = TmpStr
    End Function
	
	Public Function CariPerusahaan(ByVal IdPerusahaan) 
		tbldata=clsg.ExecuteQuery("select * from msPerusahaan where id='"& idperusahaan &"'")
		return tbldata.rows(0).item("inisialPerusahaan")
	end function

    Protected Sub grid_project_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_project.RowInserting
        Dim awalprovider As String = "000"
        Dim idperusahaan As String = e.NewValues("IdPerusahaan")
        Dim gettahun As String = Now.Year
        Dim getidprovinder As String = e.NewValues("IdProvider")
        Dim ambildataprovider As String = "select id from msprovider where Nama_Provider = '" & getidprovinder & "' "
        com = New SqlCommand(ambildataprovider, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Dim idprovinderget As String = dr("id").ToString
        dr.Close()
        con.Close()
				
		idperusahaan=CariPerusahaan(idperusahaan)
		
        Dim getcountdata As String = "select count(ID) as tot from trProject"
        com = New SqlCommand(getcountdata, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Dim urut As String = dr("tot").ToString
        dr.Close()
        con.Close()
        Dim totalurut As String = urut + 1
        Dim idauto As String = idperusahaan + gettahun + awalprovider + idprovinderget + awalprovider + totalurut

        dsproject.InsertCommand = "insert into trproject (IdPerusahaan, IdProject, NoKontrak, ProjectName, IdAM, IdProvider, IdPelanggan, StartDate, EndDate, IdPaketLayanan, IsInstalasi, IsPMCM, CustPIC, CustEmail, CustPhone, CustOffice, CustAdd, CustProvinsi, CustKota, IdStatusProject, DateStamp, Userstamp) VALUES " & _
                                "('" & idperusahaan & "', '" & idauto & "', @NoKontrak, @ProjectName, @IdAM, @IdProvider, @IdPelanggan, @StartDate, @EndDate, @IdPaketLayanan, @IsInstalasi, @IsPMCM, @CustPIC, @CustEmail, @CustPhone, @CustOffice, @CustAdd, @CustProvinsi, @CustKota, @IdStatusProject, GETDATE(), '" & Session("username") & "')"
        grid_project.DataBind()
    End Sub

    Protected Sub grid_project_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_project.RowUpdating
        dsproject.UpdateCommand = "update trproject set NoKontrak = @NoKontrak,[IdPerusahaan] = @IdPerusahaan, ProjectName = @ProjectName, IdAM = @IdAM, " & _
                                "IdProvider = @IdProvider, IdPelanggan = @IdPelanggan, StartDate = @StartDate, EndDate = @EndDate, IdPaketLayanan = @IdPaketLayanan, " & _
                                "IsInstalasi = @IsInstalasi, IsPMCM = @IsPMCM, CustPIC = @CustPIC, CustEmail = @CustEmail, CustPhone = @CustPhone, CustOffice = @CustOffice, " & _
                                "CustAdd = @CustAdd, CustProvinsi = @CustProvinsi, CustKota = @CustKota, IdStatusProject = @IdStatusProject, DateUpdate = GETDATE(), " & _
                                "UserUpdate = '" & Session("username") & "', TempoPM= @TempoPM where ID = @ID"
        grid_project.DataBind()
    End Sub
    Protected Sub gv_detilproject_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim idproject As String = ""
        Dim getidproject As String = "select * from trproject where ID = '" & Session("ID") & "'"
        com = New SqlCommand(getidproject, con)
        con.Open()
        dr = com.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            idproject = dr("IdProject").ToString
        End If
        dr.Close()
        con.Close()

        dsdetilproject.SelectCommand = "select * from trremotesite where IdProject = '" & idproject & "'"
    End Sub

    Protected Sub gv_detilproject_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        'dsdetilproject.InsertCommand = "update trproject set CustOffice = @CustOffice, CustAdd = @CustAdd, CustProvinsi = @CustProvinsi, CustKota = @CustKota, CustPIC = @CustPIC, CustEmail = @CustEmail, CustPhone = @CustPhone, IdStatusProject = @IdStatusProject where ID = '" & Session("ID") & "'"
        dsdetilproject.InsertCommand = "INSERT INTO trremotesite (VID, SID, CID, NAMAREMOTE, AlamatInstall, PROVINSI, KOTA, IPLAN) VALUES (@VID, @SID, @CID, @NAMAREMOTE, @AlamatInstall, @PROVINSI, @KOTA, @IPLAN)"
    End Sub

    Protected Sub gv_detilproject_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        dsdetilproject.UpdateCommand = "update trremotesite set VID = @VID, SID = @SID, CID = @CID, NAMAREMOTE = @NAMAREMOTE, AlamatInstall = @AlamatInstall, PROVINSI = @PROVINSI, KOTA = @KOTA, IPLAN = @IPLAN where ID = @ID"
    End Sub

    Protected Sub gv_detilproject_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        dsdetilproject.DeleteCommand = "delete from trremotesite where ID = @ID"
    End Sub

    Protected Sub grid_project_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)
        Select Case e.Column.FieldName
            'Case "JenisTransaksi"
            '    InitializeCombo(e, "CategoryID", dsmCategory, AddressOf cmbCombo2_OnCallback)
            Case "CustKota"
                InitializeComboCity(e, "CustKota", dskota, AddressOf cmbCombo3_OnCallback)

            Case Else
        End Select
        If grid_project.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
        End If
    End Sub

    Protected Sub InitializeComboCity(ByVal e As ASPxGridViewEditorEventArgs, ByVal parentComboName As String, ByVal source As SqlDataSource, ByVal callBackHandler As CallbackEventHandlerBase)

        Dim id As String = String.Empty
        If (Not grid_project.IsNewRowEditing) Then
            Dim val As Object = grid_project.GetRowValuesByKeyValue(e.KeyValue, parentComboName)
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Setiap pertama kali load, clear file
            clear()
        End If

        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
    End Sub

    Protected Sub btn_upload_ServerClick(sender As Object, e As EventArgs) Handles btn_upload.ServerClick

        If fl_upload.HasFile Then
            Try
                If cbIdProject.Value <> "" Then
                    Dim backupdb As String = "BACKUP DATABASE " & con.Database & " TO DISK = '" & clsg.BackupPath & "" & con.Database & ".BAK' WITH INIT"
                    com = New SqlCommand(backupdb, sqlcon)
                    sqlcon.Open()
                    com.ExecuteNonQuery()
                    sqlcon.Close()


                    Dim deletetemporary As String = "delete from ms_DataRemote"
                    com = New SqlCommand(deletetemporary, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()


                    'Dim FileName As String = Path.GetFileName(ASPxUploadControl1.PostedFile.FileName)
                    'Dim Extension As String = Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
                    'Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
                    'Dim FilePath As String = Server.MapPath(FolderPath + FileName)
                    'ASPxUploadControl1.SaveAs(FilePath)
                    Dim filename As String
                    Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
                    filename = Path.GetFileName(String.Format("{0}_{1}", Time, fl_upload.FileName))
                    Dim folderPath As String = Server.MapPath("~/master_import/" & filename & "")
                    fl_upload.SaveAs(folderPath)
                    Dim IdProject As String = cbIdProject.Value

                    'Response.Write(folderPath)

                    'ini untuk define sheetname excel
                    constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
                    conexcel = New OleDbConnection(constr)
                    conexcel.Open()
                    excelscheme = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    sheetname = excelscheme.Rows(0)("TABLE_NAME").ToString()
                    conexcel.Close()

                    Dim getalldata As String = ""

                    sheetname = Replace(sheetname, "$", "")
                    comexcel = New OleDbDataAdapter("select * from [MasterRemote$]", constr)
                    dataset = New DataSet()
                    comexcel.Fill(dataset)

                    dtlexcel = dataset.Tables(0)
                    If dtlexcel.Rows.Count <> 0 Then
                        For i = 0 To dtlexcel.Rows.Count - 1
                            Try
                                If IsDBNull(dtlexcel.Rows(i).Item("IDPerusahaan")) Then
                                    Exit Try
                                ElseIf IsDBNull(dtlexcel.Rows(i).Item("SubClient")) Then
                                    Exit Try
                                End If

                                tmpstr = CariPerusahaan(dtlexcel.Rows(i).Item("IDPerusahaan").ToString)

                                sqlexcel = "INSERT INTO ms_DataRemote (IdProject , VID, Province, KABUPATEN, SiteId, IPLAN, KANWIL, [NAMA CABANG INDUK], [NAMA REMOTE], ALAMAT, Satelite, IsActive, Idjarkom, Hub, CustPIC, CustPhonePIC, Provider, IDPerusahaan, IdCustomer_Sub, IdCustomer, Skala) " &
                    "VALUES('" & IdProject & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("VID").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Province").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("KABUPATEN").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("SiteId").ToString) & "', " &
                    "'" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("IPLAN").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("KANWIL").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("NAMA CABANG INDUK").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("NAMA REMOTE").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("ALAMAT").ToString) & "', " &
                    "'" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Satelite").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("IsActive").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Idjarkom").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Hub").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("CUSTPIC").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("CUSTPIC_PHONE").ToString) & "', " &
                    "'" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Provider").ToString) & "', '" & ReplaceSpecialLetter(tmpstr) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("SubClient").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Client").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Skala").ToString) & "')"
                                com = New SqlCommand(sqlexcel, sqlcon)
                                sqlcon.Open()
                                com.ExecuteNonQuery()
                                sqlcon.Close()

                            Catch ex As Exception
                                clsg.writedata("System", "Uplaod", "Excel", sqlexcel, ex.Message)
                                Exit Sub
                            End Try
                        Next
                    End If

                    dtlexcel = Nothing

                    Dim insertsite As String = "INSERT INTO trRemoteSite (IdProject, VID, PROVINSI, KOTA, sid, IPLAN, KANWIL, KANCAINDUK, NAMAREMOTE, AlamatInstall, IdSatelite, StatusRemote, IdJarkom, HUB, IdProvider, IdPerusahaan, IdCustomer, IdCustomer_Sub, Skala,  idProvinsi, idCity) " &
                                        "SELECT ms_DataRemote.IdProject, ms_DataRemote.VID, ms_DataRemote.Province, ms_DataRemote.KABUPATEN, ms_DataRemote.SiteId, ms_DataRemote.IPLAN, ms_DataRemote.KANWIL, ms_DataRemote.[NAMA CABANG INDUK], " &
                                        "ms_DataRemote.[NAMA REMOTE], ms_DataRemote.ALAMAT, ms_DataRemote.Satelite, ms_DataRemote.IsActive, ms_DataRemote.Idjarkom, ms_DataRemote.Hub , ms_DataRemote.Provider, ms_DataRemote.IdPerusahaan, ms_DataRemote.IdCustomer, ms_DataRemote.IdCustomer_Sub, ms_DataRemote.Skala, " &
                                        "msProvinsi.IdProvinsi, msKota.idKota FROM ms_DataRemote " &
                                        "LEFT OUTER JOIN msProvinsi ON ms_DataRemote.Province = msProvinsi.Provinsi " &
                                        "LEFT OUTER JOIN msKota ON msProvinsi.IdProvinsi = msKota.idProvinsi AND ms_DataRemote.KABUPATEN = msKota.Kota"
                    com = New SqlCommand(insertsite, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()

                    'Dim CommandText As String = "import_lokasi_remote"
                    'Dim strConnString As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
                    'Dim con As New SqlConnection(strConnString)
                    'Dim cmd As New SqlCommand()
                    'cmd.CommandType = CommandType.StoredProcedure
                    'cmd.CommandText = CommandText
                    '' cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = Time
                    'cmd.Parameters.Add("@IdProject", SqlDbType.VarChar).Value = IdProject
                    'cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = folderPath
                    ''cmd.Parameters.Add("@HDR", SqlDbType.VarChar).Value = "HardwareID"
                    ''cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "MHardware"
                    'cmd.Connection = con
                    'Try
                    '    con.Open()
                    '    Dim count As Object = cmd.ExecuteNonQuery()
                    '    'lblMessage.ForeColor = System.Drawing.Color.Green
                    '    'lblMessage.Text = count.ToString() & " records inserted."
                    'Catch ex As Exception
                    '    'lblMessage.ForeColor = System.Drawing.Color.Red
                    '    'lblMessage.Text = ex.Message
                    'Finally
                    '    con.Close()
                    '    con.Dispose()
                    'End Try

                    'Tampilkan notifikasi via Label
                    lblMessage.Text = "File berhasil diupload: " & filename

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Upload sukses!');", True)

                    ' ✅ jalankan JS clearFile() setelah async postback selesai
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clearUpload_" & Guid.NewGuid().ToString(), "clearFile();", True)
                    'Response.Redirect(Request.RawUrl, False)
                    'Context.ApplicationInstance.CompleteRequest()
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal", "alert('Silakan pilih file ID Project terlebih dahulu.');", True)
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    lblMessage.Text = "Silakan pilih file ID project terlebih dahulu."
                End If

            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Upload Gagal!');", True)
                lblMessage.ForeColor = System.Drawing.Color.Red
                lblMessage.Text = "Upload gagal: " & ex.Message
            End Try
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal", "alert('Upload Gagal!');", True)
            lblMessage.ForeColor = System.Drawing.Color.Red
            lblMessage.Text = "Silakan pilih ID Project dan file upload terlebih dahulu."
        End If
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clearUpload", "clearFile();", True)
        clear()
    End Sub

    Sub clear()
        cbIdProject.Value = ""
        'fl_upload.PostedFile.InputStream.Dispose()
        fl_upload.Attributes.Clear()
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clearUpload1", "clearFile();", True)
    End Sub
    Protected Sub grid_barang_on_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("VID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim VID As String = ""
        Dim getidproject As String = "select * from trRemoteSite where ID = '" & Session("VID") & "'"
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

    Protected Sub btnuploadpenyelesaiantask_ServerClick(sender As Object, e As EventArgs) Handles btnuploadpenyelesaiantask.ServerClick

        Try

            'Dim FileName As String = Path.GetFileName(ASPxUploadControl1.PostedFile.FileName)
            'Dim Extension As String = Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
            'Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            'Dim FilePath As String = Server.MapPath(FolderPath + FileName)
            'ASPxUploadControl1.SaveAs(FilePath)
            If upload_penyelesaian.HasFile = False Then
                Exit Sub
            End If

            Dim backupdb As String = "BACKUP DATABASE " & ep.Database & " TO DISK = '" & clsg.BackupPath & "" & ep.Database & ".BAK' WITH INIT"
            com = New SqlCommand(backupdb, sqlcon)
            sqlcon.Open()
            com.ExecuteNonQuery()
            sqlcon.Close()

            Dim filename As String
            Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
            filename = Path.GetFileName(String.Format("{0}_{1}", Time, upload_penyelesaian.FileName))
            Dim folderPath As String = Server.MapPath("~/master_import/" & filename & "")
            upload_penyelesaian.SaveAs(folderPath)
            'Dim IdProject As String = cbIdProject.Value

            'Response.Write(folderPath)

            'ini untuk define sheetname excel
            constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
            conexcel = New OleDbConnection(constr)
            conexcel.Open()
            excelscheme = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            conexcel.Close()

            If excelscheme.Rows.Count > 0 Then
                For i = 0 To excelscheme.Rows.Count - 1
                    For ii = 0 To cbl_JenisTask.SelectedItems.Count - 1
                        If cbl_JenisTask.SelectedItems.Item(ii).Value = Replace(excelscheme.Rows(i)("TABLE_NAME"), "$", "") Then
                            If cbl_JenisTask.SelectedItems.Item(ii).Value = "PenyelesainTask" Then
                                DataUpload_TaskGeneral(excelscheme.Rows(i)("TABLE_NAME"))
                            ElseIf cbl_JenisTask.SelectedItems.Item(ii).Value = "TaskInstalasi" Then
                                DataUpload_TaskInstalasi(excelscheme.Rows(i)("TABLE_NAME"))
                            ElseIf cbl_JenisTask.SelectedItems.Item(ii).Value = "TaskSurvey" Then
                                DataUpload_TaskSurvey(excelscheme.Rows(i)("TABLE_NAME"))
                            End If
                        End If
                    Next
                    'If excelscheme.Rows(i).Item("TABLE_NAME") = txt_NamaSheetExcel.Value & "$" Then
                    '    sheetname = excelscheme.Rows(i)("TABLE_NAME")
                    '    Exit For
                    'End If
                Next
            End If

            'Exit Sub

            'Dim CommandText As String = "import_penyelesaian_task"
            'Dim strConnString As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
            'Dim con As New SqlConnection(strConnString)
            'Dim cmd As New SqlCommand()
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.CommandText = CommandText
            ''cmd.Parameters.Add("@IdProject", SqlDbType.VarChar).Value = IdProject
            'cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = folderPath
            ''cmd.Parameters.Add("@HDR", SqlDbType.VarChar).Value = "HardwareID"
            ''cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "MHardware"
            'cmd.Connection = con
            'Try
            '    con.Open()
            '    Dim count As Object = cmd.ExecuteNonQuery()
            '    'lblMessage.ForeColor = System.Drawing.Color.Green
            '    'lblMessage.Text = count.ToString() & " records inserted."
            'Catch ex As Exception
            '    'lblMessage.ForeColor = System.Drawing.Color.Red
            '    'lblMessage.Text = ex.Message
            'Finally
            '    con.Close()
            '    con.Dispose()
            'End Try
            cbl_JenisTask.UnselectAll()
            'Response.Write("<script>alert('Import Penyelesaian Task Success.')</script>")
            lblPenyelesaianTask.Text = "Import Penyelesaian Task Success : " & filename
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Import Penyelesaian Task Success.');", True)
        Catch ex As Exception
            'Response.Write("<script>alert('Import Penyelesaian Task Gagal.')</script>" & ex.Message())
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Import Penyelesaian Task Gagal.');", True)
            lblPenyelesaianTask.Text = "Import Penyelesaian Task Gagal : " & ex.Message
        End Try

    End Sub

    Private Sub DataUpload_TaskGeneral(NamaSheet As String)
        Try
            Dim getalldata As String = ""

            'sheetname = Replace(sheetname, "$", "")
            comexcel = New OleDbDataAdapter("select * from [" & NamaSheet & "] where vid is not null", constr)
            dataset = New DataSet()
            comexcel.Fill(dataset)

            dtlexcel = dataset.Tables(0)
            If dtlexcel.Rows.Count <> 0 Then
                For i = 0 To dtlexcel.Rows.Count - 1
                    'Cari NoTask
                    strsql = "select top 1 * from trTask order by notask desc"
                    tbldata_Notask = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_Notask.Rows.Count = 0 Then
                        notask = "100001"
                    ElseIf IsNothing(tbldata_Notask) = False Then
                        notask = tbldata_Notask.Rows(0).Item("NoTask") + 1
                    Else
                        notask = "100001"
                    End If

                    'Cari data di TrRemoteSite
                    strsql = "SELECT top 1 * FROM trRemoteSite " & _
                    "WHERE (vid = '" & dtlexcel.Rows(i).Item("vid") & "')"
                    tbldata_Wilayah = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_Wilayah.Rows.Count = 0 Then
                        IdProvinsi = Nothing
                        Provinsi = Nothing
                        IdCity = Nothing
                        kota = Nothing
                        kanwil = Nothing
                        KANCAINDUK = Nothing
                        ALAMAT = Nothing
                    ElseIf IsNothing(tbldata_Wilayah) = False Then
                        IdProvinsi = tbldata_Wilayah.Rows(0).Item("idProvinsi").ToString
                        Provinsi = tbldata_Wilayah.Rows(0).Item("PROVINSI").ToString
                        IdCity = tbldata_Wilayah.Rows(0).Item("idCity").ToString
                        kota = tbldata_Wilayah.Rows(0).Item("KOTA").ToString
                        kanwil = tbldata_Wilayah.Rows(0).Item("KANWIL").ToString
                        KANCAINDUK = tbldata_Wilayah.Rows(0).Item("KANCAINDUK").ToString
                        ALAMAT = tbldata_Wilayah.Rows(0).Item("AlamatInstall").ToString
                    Else
                        IdProvinsi = Nothing
                        Provinsi = Nothing
                        IdCity = Nothing
                        kota = Nothing
                        kanwil = Nothing
                        KANCAINDUK = Nothing
                        ALAMAT = Nothing
                    End If

                    'Cari Hub
                    If IsDBNull(dtlexcel.Rows(i).Item("Hub")) = True Then
                        hub = Nothing
                    ElseIf dtlexcel.Rows(i).Item("Hub") = "" Or dtlexcel.Rows(i).Item("Hub") = Nothing Then
                        hub = Nothing
                    Else
                        strsql = "select * from mshub where id='" & dtlexcel.Rows(i).Item("Hub") & "'"
                        tbldata_hub = clsg.ExecuteQuery(strsql)
                        If Session("Error") <> Nothing Then Exit Sub
                        If tbldata_hub.Rows.Count = 0 Then
                            hub = Nothing
                        ElseIf IsNothing(tbldata_hub) = False Then
                            hub = tbldata_hub.Rows(0).Item("Hub").ToString
                        Else
                            hub = Nothing
                        End If
                    End If

                    If dtlexcel.Rows(i).Item("task").substring(0, 2) = "PM" Then
                        jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
                    ElseIf dtlexcel.Rows(i).Item("task").substring(0, 2) = "CM" Then
                        jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
                    Else
                        jnsTask = dtlexcel.Rows(i).Item("task").ToString
                    End If

                    'Cari Id Status Task
                    strsql = "select id,Status from msStatus where Status='" & dtlexcel.Rows(i).Item("StatusPerbaikan") & "'"
                    tbldata_IdStatusTask = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_IdStatusTask.Rows.Count = 0 Then
                        IdStatusTask = Nothing
                    ElseIf IsNothing(tbldata_IdStatusTask) = False Then
                        IdStatusTask = tbldata_IdStatusTask.Rows(0).Item("id").ToString
                    Else
                        IdStatusTask = Nothing
                    End If

                    If dtlexcel.Rows(i).Item("StatusPerbaikan") = "Open" And dtlexcel.Rows(i).Item("StatusTask") = "Open" Then
                        'insert ke trtask
                        strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask,IdProvinsi," &
                            "IdCity,Provinsi,City,TglMulai,TglSelesai,TglStatusTask,IdStatusTask,IdStatusKoordinator,IdStatusManager,TglStatusManager,IdUserManager," &
                            "DateStamp,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " &
                            "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
                            dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," &
                            "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," &
                            "'" & dtlexcel.Rows(i).Item("Tanggal") & "',null,'" & dtlexcel.Rows(i).Item("Tanggal") & "'," &
                            "'1','Valid','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IdManager") & "',getdate(),getdate()," &
                            "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTask")) & "','" & jnsTask & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
                        clsg.ExecuteNonQuery(strsql)

                        'insert ke trdetail_task
                        strsql = "insert into trDetail_Task(NoTask, VID,IPLAN,KANWIL,KANCAINDUK,NAMAREMOTE,ALAMAT,idProvinsi, PROVINSI, idCity, KOTA, IdJarkom, IdSatelite, idJenisTask,NoHpPic,PIC, " &
                         "TglBerangkat, TglSelesaiKerjaan, TglPulang, IdStatusPerbaikan, TglStatusPerbaikan,UserStamp, DateStamp,HasilXPOLL, CPI, Hub,SQF, INITIAL_ESNO, " &
                         "FlagDataLokasi, FlagGeneralInfo, FlagDataTeknis, FlagDataBarang, FlagUploadPhoto, FlagDataInstallasi, FlagDataSurvey) values " &
                         "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " &
                         "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," &
                         "'" & dtlexcel.Rows(i).Item("TglBerangkat") & "', '" & dtlexcel.Rows(i).Item("TglSelesai") & "', '" & dtlexcel.Rows(i).Item("TglPulang") & "', 1, '" & dtlexcel.Rows(i).Item("TglStatus") & "','" & dtlexcel.Rows(i).Item("IdManager") & "'," &
                         "getdate(),'" & dtlexcel.Rows(i).Item("HasilXPoll") & "', '" & dtlexcel.Rows(i).Item("CPI") & "', '" & hub & "','" & dtlexcel.Rows(i).Item("SQF") & "', '" & dtlexcel.Rows(i).Item("InisialESNO") & "'," &
                         "1, 1, 0, 0, 0, 0, 0)"
                        clsg.ExecuteNonQuery(strsql)
                    Else
                        'insert ke trtask
                        strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask,IdProvinsi," &
                            "IdCity,Provinsi,City,TglMulai,TglSelesai,TglStatusTask,IdStatusTask,IdStatusKoordinator,IdStatusManager,TglStatusManager,IdUserManager," &
                            "DateStamp,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " &
                            "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
                            dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," &
                            "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," &
                            "'" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("TglSelesai") & "','" & dtlexcel.Rows(i).Item("Tanggal") & "'," &
                            "'" & IdStatusTask & "','Valid','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IdManager") & "',getdate(),getdate()," &
                            "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTask")) & "','" & jnsTask & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
                        clsg.ExecuteNonQuery(strsql)

                        'insert ke trdetail_task
                        strsql = "insert into trDetail_Task(NoTask, VID,IPLAN,KANWIL,KANCAINDUK,NAMAREMOTE,ALAMAT,idProvinsi, PROVINSI, idCity, KOTA, IdJarkom, IdSatelite, idJenisTask,NoHpPic,PIC, " &
                         "TglBerangkat, TglSelesaiKerjaan, TglPulang, IdStatusPerbaikan, TglStatusPerbaikan,UserStamp, DateStamp,HasilXPOLL, CPI, Hub,SQF, INITIAL_ESNO, " &
                         "FlagDataLokasi, FlagGeneralInfo, FlagDataTeknis, FlagDataBarang, FlagUploadPhoto, FlagDataInstallasi, FlagDataSurvey) values " &
                         "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " &
                         "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," &
                         "'" & dtlexcel.Rows(i).Item("TglBerangkat") & "', '" & dtlexcel.Rows(i).Item("TglSelesai") & "', '" & dtlexcel.Rows(i).Item("TglPulang") & "', 4, '" & dtlexcel.Rows(i).Item("TglStatus") & "','" & dtlexcel.Rows(i).Item("IdManager") & "'," &
                         "getdate(),'" & dtlexcel.Rows(i).Item("HasilXPoll") & "', '" & dtlexcel.Rows(i).Item("CPI") & "', '" & hub & "','" & dtlexcel.Rows(i).Item("SQF") & "', '" & dtlexcel.Rows(i).Item("InisialESNO") & "'," &
                         "1, 1, 1, 1, 1, 1, 1)"
                        clsg.ExecuteNonQuery(strsql)
                    End If
                Next
            End If
        Catch ex As Exception
            clsg.writedata("System", "Uplaod", "Excel", NamaSheet & " | " & strsql, ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub DataUpload_TaskInstalasi(NamaSheet As String)
        Try
            Dim getalldata As String = ""

            'sheetname = Replace(sheetname, "$", "")
            comexcel = New OleDbDataAdapter("select * from [" & NamaSheet & "] where vid is not null", constr)
            dataset = New DataSet()
            comexcel.Fill(dataset)

            dtlexcel = dataset.Tables(0)
            If dtlexcel.Rows.Count <> 0 Then
                For i = 0 To dtlexcel.Rows.Count - 1
                    'Cari NoTask
                    strsql = "select top 1 * from trTask order by notask desc"
                    tbldata_Notask = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_Notask.Rows.Count = 0 Then
                        notask = "100001"
                    ElseIf IsNothing(tbldata_Notask) = False Then
                        notask = tbldata_Notask.Rows(0).Item("NoTask") + 1
                    Else
                        notask = "100001"
                    End If

                    'Cari data di TrRemoteSite
                    strsql = "SELECT top 1 * FROM trRemoteSite " & _
                    "WHERE (vid = '" & dtlexcel.Rows(i).Item("vid") & "')"
                    tbldata_Wilayah = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_Wilayah.Rows.Count = 0 Then
                        IdProvinsi = Nothing
                        Provinsi = Nothing
                        IdCity = Nothing
                        kota = Nothing
                        kanwil = Nothing
                        KANCAINDUK = Nothing
                        ALAMAT = Nothing
                    ElseIf IsNothing(tbldata_Wilayah) = False Then
                        IdProvinsi = tbldata_Wilayah.Rows(0).Item("idProvinsi").ToString
                        Provinsi = tbldata_Wilayah.Rows(0).Item("PROVINSI").ToString
                        IdCity = tbldata_Wilayah.Rows(0).Item("idCity").ToString
                        kota = tbldata_Wilayah.Rows(0).Item("KOTA").ToString
                        kanwil = tbldata_Wilayah.Rows(0).Item("KANWIL").ToString
                        KANCAINDUK = tbldata_Wilayah.Rows(0).Item("KANCAINDUK").ToString
                        ALAMAT = tbldata_Wilayah.Rows(0).Item("AlamatInstall").ToString
                    Else
                        IdProvinsi = Nothing
                        Provinsi = Nothing
                        IdCity = Nothing
                        kota = Nothing
                        kanwil = Nothing
                        KANCAINDUK = Nothing
                        ALAMAT = Nothing
                    End If

                    'Cari Hub
                    strsql = "select * from mshub where id='" & dtlexcel.Rows(i).Item("Hub") & "'"
                    tbldata_hub = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_hub.Rows.Count = 0 Then
                        hub = Nothing
                    ElseIf IsNothing(tbldata_hub) = False Then
                        hub = tbldata_hub.Rows(0).Item("Hub").ToString
                    Else
                        hub = Nothing
                    End If

                    If dtlexcel.Rows(i).Item("task").substring(0, 2) = "PM" Then
                        jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
                    ElseIf dtlexcel.Rows(i).Item("task").substring(0, 2) = "CM" Then
                        jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
                    Else
                        If dtlexcel.Rows(i).Item("task").ToString = "Instalasi" Then
                            jnsTask = "Installation"
                        Else
                            jnsTask = dtlexcel.Rows(i).Item("task").ToString
                        End If
                    End If

                    'Cari Id Status Task
                    strsql = "select id,Status from msStatus where Status='" & dtlexcel.Rows(i).Item("StatusPerbaikan") & "'"
                    tbldata_IdStatusTask = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_IdStatusTask.Rows.Count = 0 Then
                        IdStatusTask = Nothing
                    ElseIf IsNothing(tbldata_IdStatusTask) = False Then
                        IdStatusTask = tbldata_IdStatusTask.Rows(0).Item("id").ToString
                    Else
                        IdStatusTask = Nothing
                    End If

                    'insert ke trtask
                    strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask," & _
                        "IdProvinsi,IdCity,Provinsi,City,TglMulai,TglSelesai,IdStatusTask,TglStatusTask,IdStatusKoordinator,TglStatusKoordinator" & _
                        ",CatatanKoordinator,IdUserKoordinator,IdStatusManager,TglStatusManager,CatatanManager,IdUserManager,UserStamp,DateStamp," & _
                        "VID,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " & _
                        "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
                        dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," & _
                        "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," & _
                        "'" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("TglSelesai") & "',4,'" & dtlexcel.Rows(i).Item("Tanggal") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "'" & _
                        ",'" & jnsTask & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & jnsTask & "','" & dtlexcel.Rows(i).Item("IdManager") & "'" & _
                        ",'" & Session("UserName") & "',getdate(),'" & dtlexcel.Rows(i).Item("VID") & "',getdate(),'" & dtlexcel.Rows(i).Item("NamaTask") & "','" & jnsTask & "'" & _
                        ",'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
                    clsg.ExecuteNonQuery(strsql)

                    'insert ke trdetail_task
                    strsql = "insert into trDetail_Task(NoTask,VID,SID,IPLAN,KANWIL,KANCAINDUK,NAMAREMOTE,ALAMAT,idProvinsi,PROVINSI,idCity,KOTA,IdJarkom,IdSatelite,idJenisTask,NoHpPic,PIC,SQF,INITIAL_ESNO," & _
                    "UPSforBackup,TypeMounting,PanjangKabel,AktifitasSolusi,TglBerangkat,TglSelesaiKerjaan,TglPulang,IdStatusPerbaikan,TglStatusPerbaikan," & _
                    "UserStamp,DateStamp,CARRIER_TO_NOICE,CPI,Hub,Latitude,Longitude,DiameterAntena,SourceListrik,IPLAN1,IPLAN2,FlagDataLokasi,FlagGeneralInfo,FlagDataTeknis," & _
                    "FlagDataBarang,FlagUploadPhoto,FlagDataInstallasi,FlagDataSurvey) values " & _
                    "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("SID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " & _
                    "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," & _
                    "'" & dtlexcel.Rows(i).Item("SQF") & "', '" & dtlexcel.Rows(i).Item("INTIALESNO") & "', '" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("UPSForBackUp")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Mounting")) & "', '" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("PanjangKabel")) & "'," & _
                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("AktivitasSolusi")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglBerangkat")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglSelesai")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglPulang")) & "','" & IdStatusTask & "', " & _
                    "'" & dtlexcel.Rows(i).Item("TglStatus") & "','" & Session("UserName") & "',getdate(), '" & dtlexcel.Rows(i).Item("CToN") & "', '" & dtlexcel.Rows(i).Item("CPI") & "', '" & hub & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Latitude")) & "', '" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Longitude")) & "'," & _
                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("UkuranAntena")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("SourceListrik")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("LAN1-IPAdrress")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("LAN2-IPAdrress")) & "',1, 1, 1, 1, 1, 1, 1)"
                    clsg.ExecuteNonQuery(strsql)
                Next
            End If
        Catch ex As Exception
            clsg.writedata("System", "Uplaod", "Excel", NamaSheet & " | " & strsql, ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub DataUpload_TaskSurvey(NamaSheet As String)
        Try
            Dim getalldata As String = ""

            'sheetname = Replace(sheetname, "$", "")
            comexcel = New OleDbDataAdapter("select * from [" & NamaSheet & "] where vid is not null", constr)
            dataset = New DataSet()
            comexcel.Fill(dataset)

            dtlexcel = dataset.Tables(0)
            If dtlexcel.Rows.Count <> 0 Then
                For i = 0 To dtlexcel.Rows.Count - 1
                    'Cari NoTask
                    strsql = "select top 1 * from trTask order by notask desc"
                    tbldata_Notask = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_Notask.Rows.Count = 0 Then
                        notask = "100001"
                    ElseIf IsNothing(tbldata_Notask) = False Then
                        notask = tbldata_Notask.Rows(0).Item("NoTask") + 1
                    Else
                        notask = "100001"
                    End If

                    'Cari data di TrRemoteSite
                    strsql = "SELECT top 1 * FROM trRemoteSite " & _
                    "WHERE (vid = '" & dtlexcel.Rows(i).Item("vid") & "')"
                    tbldata_Wilayah = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_Wilayah.Rows.Count = 0 Then
                        IdProvinsi = Nothing
                        Provinsi = Nothing
                        IdCity = Nothing
                        kota = Nothing
                        kanwil = Nothing
                        KANCAINDUK = Nothing
                        ALAMAT = Nothing
                    ElseIf IsNothing(tbldata_Wilayah) = False Then
                        IdProvinsi = tbldata_Wilayah.Rows(0).Item("idProvinsi").ToString
                        Provinsi = tbldata_Wilayah.Rows(0).Item("PROVINSI").ToString
                        IdCity = tbldata_Wilayah.Rows(0).Item("idCity").ToString
                        kota = tbldata_Wilayah.Rows(0).Item("KOTA").ToString
                        kanwil = tbldata_Wilayah.Rows(0).Item("KANWIL").ToString
                        KANCAINDUK = tbldata_Wilayah.Rows(0).Item("KANCAINDUK").ToString
                        ALAMAT = tbldata_Wilayah.Rows(0).Item("AlamatInstall").ToString
                    Else
                        IdProvinsi = Nothing
                        Provinsi = Nothing
                        IdCity = Nothing
                        kota = Nothing
                        kanwil = Nothing
                        KANCAINDUK = Nothing
                        ALAMAT = Nothing
                    End If

                    'Cari Hub
                    strsql = "select * from mshub where id='" & dtlexcel.Rows(i).Item("Hub") & "'"
                    tbldata_hub = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_hub.Rows.Count = 0 Then
                        hub = Nothing
                    ElseIf IsNothing(tbldata_hub) = False Then
                        hub = tbldata_hub.Rows(0).Item("Hub").ToString
                    Else
                        hub = Nothing
                    End If

                    If dtlexcel.Rows(i).Item("task").substring(0, 2) = "PM" Then
                        jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
                    ElseIf dtlexcel.Rows(i).Item("task").substring(0, 2) = "CM" Then
                        jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
                    Else
                        If dtlexcel.Rows(i).Item("task").ToString = "Instalasi" Then
                            jnsTask = "Installation"
                        Else
                            jnsTask = dtlexcel.Rows(i).Item("task").ToString
                        End If
                    End If

                    'Cari Id Status Task
                    strsql = "select id,Status from msStatus where Status='" & dtlexcel.Rows(i).Item("StatusPerbaikan") & "'"
                    tbldata_IdStatusTask = clsg.ExecuteQuery(strsql)
                    If Session("Error") <> Nothing Then Exit Sub
                    If tbldata_IdStatusTask.Rows.Count = 0 Then
                        IdStatusTask = Nothing
                    ElseIf IsNothing(tbldata_IdStatusTask) = False Then
                        IdStatusTask = tbldata_IdStatusTask.Rows(0).Item("id").ToString
                    Else
                        IdStatusTask = Nothing
                    End If

                    'insert ke trtask
                    strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask," & _
                        "IdProvinsi,IdCity,Provinsi,City,TglMulai,TglSelesai,IdStatusTask,TglStatusTask,IdStatusKoordinator,TglStatusKoordinator" & _
                        ",CatatanKoordinator,IdUserKoordinator,IdStatusManager,TglStatusManager,CatatanManager,IdUserManager,UserStamp,DateStamp," & _
                        "VID,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " & _
                        "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
                        dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," & _
                        "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," & _
                        "'" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("TglSelesai") & "',4,'" & dtlexcel.Rows(i).Item("Tanggal") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "'" & _
                        ",'" & jnsTask & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & jnsTask & "','" & dtlexcel.Rows(i).Item("IdManager") & "'" & _
                        ",'" & Session("UserName") & "',getdate(),'" & dtlexcel.Rows(i).Item("VID") & "',getdate(),'" & dtlexcel.Rows(i).Item("NamaTask") & "','" & jnsTask & "'" & _
                        ",'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
                    clsg.ExecuteNonQuery(strsql)

                    'insert ke trdetail_task
                    strsql = "insert into trDetail_Task(NoTask, VID, IPLAN, KANWIL, KANCAINDUK, NAMAREMOTE, ALAMAT, idProvinsi, PROVINSI, idCity, " & _
                        "KOTA, IdJarkom, IdSatelite, idJenisTask, NoHpPic, PIC, TglBerangkat, TglSelesaiKerjaan, " & _
                        "TglPulang, IdStatusPerbaikan, TglStatusPerbaikan, AlamatPengirimanSurvey, TempatPenyimpananSurvey, NamaPICSurvey, KontakPICSurvey, " & _
                        "UkuranAntenaSurvey, TempatAntenaSurvey, KekuatanRoofSurvey, JenisMountingSurvey, LatitudeSurvey, LongitudeSurvey, " & _
                        "ListrikAwalSurvey, SarpenACIndoorSurvey, PanjangKabelSurvey, TypeKabelSurvey, ArahAntenaSurvey, KeteranganSurvey, StatusHasilSurvey, " & _
                        "UserStamp, DateStamp, FlagDataLokasi, FlagGeneralInfo, FlagDataTeknis, FlagDataBarang, FlagUploadPhoto, FlagDataInstallasi, FlagDataSurvey) values " & _
                    "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " & _
                    "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," & _
                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglBerangkat")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglSelesai")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglPulang")) & "','" & IdStatusTask & "'," & _
                    "'" & dtlexcel.Rows(i).Item("TglStatus") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("AlamatPengiriman")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TempatPenyimpanan")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," & _
                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("UkuranAntena")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TempatAntena")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("KekuatanRoofTop")) & "'," & _
                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Mounting")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Latitude")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Longitude")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("PengukuranListrikAwal")) & "'," & _
                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("ACIndoor")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("PanjangKabel")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TypeKabel")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("ArahAntena")) & "'," & _
                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Keterangan")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("StatusHasilSurvey")) & "','" & Session("UserName") & "',getdate(),1,1,1,1,1,1,1)"
                    clsg.ExecuteNonQuery(strsql)
                Next
            End If
        Catch ex As Exception
            clsg.writedata("System", "Uplaod", "Excel", NamaSheet & " | " & strsql, ex.Message)
            Exit Sub
        End Try
    End Sub

    Protected Sub btnimportbarangon_ServerClick(sender As Object, e As EventArgs) Handles btnimportbarangon.ServerClick
        'Dim FileName As String = Path.GetFileName(ASPxUploadControl1.PostedFile.FileName)
        'Dim Extension As String = Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
        'Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        'Dim FilePath As String = Server.MapPath(FolderPath + FileName)
        'ASPxUploadControl1.SaveAs(FilePath)
        Dim filename As String
        Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
        filename = Path.GetFileName(String.Format("{0}_{1}", Time, uploadbarangon.FileName))
        Dim folderPath As String = Server.MapPath("~/master_import/" & filename & "")
        uploadbarangon.SaveAs(folderPath)
        'Dim IdProject As String = cbIdProject.Value

        'Response.Write(folderPath)

        Dim CommandText As String = "import_barang_on"
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = CommandText
        'cmd.Parameters.Add("@IdProject", SqlDbType.VarChar).Value = IdProject
        cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = folderPath
        'cmd.Parameters.Add("@HDR", SqlDbType.VarChar).Value = "HardwareID"
        'cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "MHardware"
        cmd.Connection = con
        Try
            con.Open()
            Dim count As Object = cmd.ExecuteNonQuery()
            'lblMessage.ForeColor = System.Drawing.Color.Green
            'lblMessage.Text = count.ToString() & " records inserted."
        Catch ex As Exception
            'lblMessage.ForeColor = System.Drawing.Color.Red
            'lblMessage.Text = ex.Message
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Protected Sub btnuploadbarangrusak_ServerClick(sender As Object, e As EventArgs) Handles btnuploadbarangrusak.ServerClick
        'Dim FileName As String = Path.GetFileName(ASPxUploadControl1.PostedFile.FileName)
        'Dim Extension As String = Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
        'Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        'Dim FilePath As String = Server.MapPath(FolderPath + FileName)
        'ASPxUploadControl1.SaveAs(FilePath)
        Dim filename As String
        Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
        filename = Path.GetFileName(String.Format("{0}_{1}", Time, uploadbarangrusak.FileName))
        Dim folderPath As String = Server.MapPath("~/master_import/" & filename & "")
        uploadbarangrusak.SaveAs(folderPath)
        'Dim IdProject As String = cbIdProject.Value

        'Response.Write(folderPath)

        Dim CommandText As String = "import_barang_rusak"
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = CommandText
        'cmd.Parameters.Add("@IdProject", SqlDbType.VarChar).Value = IdProject
        cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = folderPath
        'cmd.Parameters.Add("@HDR", SqlDbType.VarChar).Value = "HardwareID"
        'cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "MHardware"
        cmd.Connection = con
        Try
            con.Open()
            Dim count As Object = cmd.ExecuteNonQuery()
            'lblMessage.ForeColor = System.Drawing.Color.Green
            'lblMessage.Text = count.ToString() & " records inserted."
        Catch ex As Exception
            'lblMessage.ForeColor = System.Drawing.Color.Red
            'lblMessage.Text = ex.Message
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Sub

    Protected Sub btn_rollback_ServerClick(sender As Object, e As EventArgs) Handles btn_rollback.ServerClick
        Try
            ' 🔹 Tampilkan loading sebelum proses restore
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "showLoading",
            '"Swal.fire({title: 'Sedang Rollback...', text: 'Mohon tunggu beberapa saat', allowOutsideClick: false, didOpen: () => {Swal.showLoading()} });",
            'True)

            ' 🔹 Pastikan connect ke MASTER, bukan ke database yang akan direstore
            Using con As New SqlConnection("Data Source=.;Initial Catalog=master;User ID=sa;Password=Sa212")
                con.Open()

                ' 1. Kill semua session lain yang masih konek ke database target
                Dim sqlGetSessions As String =
                "SELECT session_id FROM sys.dm_exec_sessions " &
                "WHERE database_id = DB_ID('dbSelindoVSAT_PROD') AND session_id <> @@SPID"

                Dim cmd As New SqlCommand(sqlGetSessions, con)
                Dim rdr As SqlDataReader = cmd.ExecuteReader()
                Dim sessions As New List(Of Integer)

                While rdr.Read()
                    sessions.Add(rdr("session_id"))
                End While
                rdr.Close()

                For Each sid As Integer In sessions
                    Dim killCmd As New SqlCommand("KILL " & sid.ToString(), con)
                    killCmd.ExecuteNonQuery()
                Next

                ' 2. Restore database
                Dim sqlRestore As String =
                "ALTER DATABASE dbSelindoVSAT_PROD SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " &
                "RESTORE DATABASE dbSelindoVSAT_PROD " &
                "FROM DISK = 'D:\OfficeSelindo\Backup server\Backup_DB\dbSelindoVSAT_PROD.BAK' " &
                "WITH REPLACE; " &
                "ALTER DATABASE dbSelindoVSAT_PROD SET MULTI_USER;"

                Dim cmdRestore As New SqlCommand(sqlRestore, con)
                cmdRestore.ExecuteNonQuery()
                con.Close()
            End Using

            ' 🔹 Notifikasi sukses + tombol OK
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "restoreSuccess",
            "Swal.fire({title: 'Sukses!', text: 'Database berhasil di-Rollback', icon: 'success', confirmButtonText: 'OK'}).then(()=>{ window.location='login.aspx'; });",
            True)

            lblMessage.ForeColor = System.Drawing.Color.Green
            lblMessage.Text = "Database berhasil di-Rollback!"

        Catch ex As Exception
            ' 🔹 Notifikasi gagal
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "rollbackFail",
            "Swal.fire({title: 'Error', text: 'Rollback gagal: " & ex.Message.Replace("'", "") & "', icon: 'error', confirmButtonText: 'OK'});",
            True)

            lblMessage.ForeColor = System.Drawing.Color.Red
            lblMessage.Text = "Rollback Gagal! " & ex.Message()
        End Try
    End Sub

    'Protected Sub btn_rollback_ServerClick(sender As Object, e As EventArgs) Handles btn_rollback.ServerClick
    '    Try
    '        ' 🔹 Tampilkan loading sebelum proses
    '        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "showLoading", "Swal.fire({title: 'Sedang Rollback...', text: 'Mohon tunggu beberapa saat', allowOutsideClick: false, didOpen: () => {Swal.showLoading()} });", True)

    '        ' Pastikan koneksi pakai database master
    '        Using con As New SqlConnection("Data Source=.;Initial Catalog=master;User ID=sa;Password=Sa212")
    '            con.Open()

    '            ' 1. Ambil semua session aktif
    '            Dim sqlGetSessions As String =
    '            "SELECT session_id FROM sys.dm_exec_sessions WHERE database_id = DB_ID('dbSelindoVSAT_PROD') AND session_id <> @@SPID"
    '            Dim cmd As New SqlCommand(sqlGetSessions, con)
    '            Dim rdr As SqlDataReader = cmd.ExecuteReader()
    '            Dim sessions As New List(Of Integer)
    '            While rdr.Read()
    '                sessions.Add(CInt(rdr("session_id")))
    '            End While
    '            rdr.Close()

    '            ' 2. Kill semua session
    '            For Each sid As Integer In sessions
    '                Dim killCmd As New SqlCommand("KILL " & sid.ToString(), con)
    '                killCmd.ExecuteNonQuery()
    '            Next

    '            ' 3. Restore database (pisah jadi 3 command biar aman)
    '            Dim sql1 As String = "ALTER DATABASE dbSelindoVSAT_PROD SET SINGLE_USER WITH ROLLBACK IMMEDIATE;"
    '            Dim sql2 As String = "RESTORE DATABASE dbSelindoVSAT_PROD FROM DISK = 'D:\OfficeSelindo\Backup server\Backup_DB\dbSelindoVSAT_PROD.BAK' WITH REPLACE;"
    '            Dim sql3 As String = "ALTER DATABASE dbSelindoVSAT_PROD SET MULTI_USER;"

    '            Using cmd1 As New SqlCommand(sql1, con)
    '                cmd1.ExecuteNonQuery()
    '            End Using
    '            Using cmd2 As New SqlCommand(sql2, con)
    '                cmd2.ExecuteNonQuery()
    '            End Using
    '            Using cmd3 As New SqlCommand(sql3, con)
    '                cmd3.ExecuteNonQuery()
    '            End Using

    '            con.Close()
    '        End Using

    '        ' 🔹 Notifikasi sukses
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "restoreSuccess",
    '        "Swal.fire({" &
    '        "title: 'Sukses!'," &
    '        "text: 'Database berhasil di-Rollback'," &
    '        "icon: 'success'," &
    '        "confirmButtonText: 'OK'," &
    '        "confirmButtonColor: '#3085d6'" &
    '        "}).then((result) => {" &
    '        "if (result.isConfirmed) { window.location='login.aspx'; }" &
    '        "});", True)



    '        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "restoreSuccess",
    '        '"Swal.fire('Sukses!', 'Database berhasil di-Rollback', 'success').then(()=>{ window.location='login.aspx'; });",
    '        'True)

    '        lblMessage.ForeColor = System.Drawing.Color.Green
    '        lblMessage.Text = "Sukses! Database berhasil di-Rollback"

    '    Catch ex As Exception
    '        'Dim safeMessage As String = System.Web.HttpUtility.JavaScriptStringEncode(ex.Message)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "restoreFail",
    '        "Swal.fire({" &
    '        "title: 'Error'," &
    '        "text: 'Rollback gagal: " & ex.Message.Replace("'", "") & "'," &
    '        "icon: 'error'," &
    '        "confirmButtonText: 'OK'," &
    '        "confirmButtonColor: '#d33'" &
    '        "});", True)

    '        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "rollbackFail", "Swal.fire('Error', 'Rollback gagal: " & safeMessage & "', 'error');", True)

    '        lblMessage.ForeColor = System.Drawing.Color.Red
    '        lblMessage.Text = "Rollback Gagal! " & ex.Message
    '    End Try
    'End Sub

    'Protected Sub btn_template_Click(sender As Object, e As EventArgs)
    '    Dim filePath As String = "D:\OfficeSelindo\Backup server\BackupVsat\masterTemplate\DataLokasi.xlsx"
    '    Dim fileName As String = Path.GetFileName(filePath)

    '    If File.Exists(filePath) Then
    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    '        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
    '        Response.WriteFile(filePath)
    '        Response.Flush()
    '        HttpContext.Current.ApplicationInstance.CompleteRequest()
    '    Else
    '        ' Bisa kasih notifikasi kalau file tidak ada
    '        Response.Write("<script>alert('File tidak ditemukan');</script>")
    '    End If
    'End Sub

    Protected Sub btn_template_ServerClick(sender As Object, e As EventArgs)
        Dim filePath As String = "D:\OfficeSelindo\Backup server\BackupVsat\masterTemplate\DataLokasi.xlsx"
        Dim fileName As String = Path.GetFileName(filePath)

        If File.Exists(filePath) Then
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
            Response.TransmitFile(filePath)
            Response.End()
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('File tidak ditemukan');", True)
        End If
    End Sub

    Protected Sub btn_Download_ServerClick(sender As Object, e As EventArgs)
        Dim filePath As String = "D:\OfficeSelindo\Backup server\BackupVsat\masterTemplate\PenyelesaianTask.xlsx"
        Dim fileName As String = Path.GetFileName(filePath)

        If File.Exists(filePath) Then
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
            Response.TransmitFile(filePath)
            Response.End()
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('File tidak ditemukan');", True)
        End If
    End Sub

    Protected Sub cb_JenisTask_CheckedChanged(sender As Object, e As EventArgs) Handles cb_JenisTask.CheckedChanged
        If cb_JenisTask.Checked = True Then
            cbl_JenisTask.SelectAll()
        Else
            cbl_JenisTask.UnselectAll()
        End If
    End Sub
End Class
