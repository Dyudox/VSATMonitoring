Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Bootstrap
'Imports DevExpress.Web.BootstrapMode
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

    'Public Function ReplaceSpecialLetter(ByVal str)
    '    tmpstr = str
    '    'tmpstr = Replace(tmpstr, "N/A", "NULL")
    '    TmpStr = Replace(TmpStr, "'", "&#39;")
    '    ReplaceSpecialLetter = TmpStr
    'End Function
    Public Function ReplaceSpecialLetter(ByVal str As String) As String
        If String.IsNullOrEmpty(str) Then Return String.Empty

        Dim tmpStr As String = str
        ' Jika ingin mengganti N/A dengan NULL, aktifkan baris ini
        ' tmpStr = tmpStr.Replace("N/A", "NULL")
        tmpStr = tmpStr.Replace("'", "&#39;")

        Return tmpStr
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
                ' === 1️⃣ Validasi nama file & ekstensi ===
                Dim fileExt As String = Path.GetExtension(fl_upload.FileName).ToLower()
                Dim originalName As String = Path.GetFileName(fl_upload.FileName)

                If fileExt <> ".xlsx" Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "extError",
                    "alert('Hanya file Excel dengan ekstensi .xlsx yang diperbolehkan.');", True)
                    lblMessage.ForeColor = Drawing.Color.Red
                    lblMessage.Text = "Format file tidak valid. Harap upload file dengan ekstensi .xlsx."
                    clear()
                    Exit Sub
                End If

                ' ✅ Nama file wajib "DataLokasi.xlsx"
                If Not originalName.Equals("DataLokasi.xlsx", StringComparison.OrdinalIgnoreCase) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "fileNameError",
                    "alert('Nama file harus DataLokasi.xlsx');", True)
                    lblMessage.ForeColor = Drawing.Color.Red
                    lblMessage.Text = "Nama file tidak sesuai. Harap gunakan file bernama DataLokasi.xlsx."
                    clear()
                    Exit Sub
                End If

                ' === 2️⃣ Validasi project terpilih ===
                If String.IsNullOrEmpty(cbIdProject.Value) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal",
                    "alert('Silakan pilih ID Project terlebih dahulu.');", True)
                    lblMessage.ForeColor = Drawing.Color.Red
                    lblMessage.Text = "Silakan pilih ID project terlebih dahulu."
                    clear()
                    Exit Sub
                End If

                ' === 3️⃣ Simpan file upload ke server ===
                Dim Time As String = DateTime.Now.ToString("yyyyMMddHHmmss")
                Dim filename As String = Time & "_" & fl_upload.FileName
                Dim folderPath As String = Server.MapPath("~/master_import/" & filename)
                fl_upload.SaveAs(folderPath)

                ' === 4️⃣ Cek isi sheet di Excel ===
                'Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
                Dim constr As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"

                Using conexcel As New OleDbConnection(constr)
                    conexcel.Open()
                    Dim schema As DataTable = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

                    ' ✅ Nama sheet yang wajib ada
                    'Dim requiredSheets As String() = {"MasterRemote$", "TaskSurvey$", "TaskInstalasi$"}
                    Dim requiredSheets As String() = {"MasterRemote$"}
                    Dim sheetNames As List(Of String) = schema.AsEnumerable().Select(Function(r) r("TABLE_NAME").ToString()).ToList()

                    ' Cek satu per satu
                    Dim missingSheets As New List(Of String)
                    For Each s In requiredSheets
                        Dim found = sheetNames.Any(Function(n) n.Equals(s, StringComparison.OrdinalIgnoreCase))
                        If Not found Then
                            missingSheets.Add(s.Replace("$", ""))
                        End If
                    Next

                    If missingSheets.Count > 0 Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sheetError",
                        "alert('Sheet berikut tidak ditemukan di Excel: " & String.Join(", ", missingSheets) & "');", True)
                        lblMessage.ForeColor = Drawing.Color.Red
                        lblMessage.Text = "Sheet wajib berikut tidak ditemukan: " & String.Join(", ", missingSheets)
                        clear()
                        Exit Sub
                    End If

                    ' === 5️⃣ Validasi kolom wajib di sheet MasterRemote ===
                    Dim requiredColumns As String() = {
                                                        "VID",
                                                        "NO",
                                                        "Province",
                                                        "KABUPATEN",
                                                        "SiteId",
                                                        "IPLAN",
                                                        "KANWIL",
                                                        "NAMA CABANG INDUK",
                                                        "NAMA REMOTE",
                                                        "ALAMAT",
                                                        "Project",
                                                        "IsActive",
                                                        "CUSTPIC",
                                                        "CUSTPIC_PHONE",
                                                        "Satelite",
                                                        "Idjarkom",
                                                        "Hub",
                                                        "Provider",
                                                        "Client",
                                                        "IdProject",
                                                        "IDPerusahaan",
                                                        "SubClient",
                                                        "Client1",
                                                        "Skala"
                                                       }

                    Dim missingColumns As New List(Of String)
                    Dim wrongOrder As New List(Of String)

                    Using conCheck As New OleDbConnection(constr)
                        Dim cmd As New OleDbCommand("SELECT TOP 1 * FROM [MasterRemote$]", conCheck)
                        Dim da As New OleDbDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        ' Ambil semua kolom dari Excel (header)
                        Dim excelColumns As List(Of String) = dt.Columns.Cast(Of DataColumn)().
                        Select(Function(c) c.ColumnName.Trim()).
                        ToList()

                        ' === 5a️⃣ Cek kolom wajib ada ===
                        For Each col In requiredColumns
                            Dim found = excelColumns.Any(Function(c) c.Equals(col, StringComparison.OrdinalIgnoreCase))
                            If Not found Then
                                missingColumns.Add(col)
                            End If
                        Next

                        ' Jika ada kolom hilang
                        If missingColumns.Count > 0 Then
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "columnError",
                            "alert('Kolom berikut tidak ditemukan di sheet MasterRemote: " & String.Join(", ", missingColumns) & "');", True)
                            lblMessage.ForeColor = Drawing.Color.Red
                            lblMessage.Text = "Kolom wajib berikut tidak ditemukan di sheet MasterRemote: " & String.Join(", ", missingColumns)
                            clear()
                            Exit Sub
                        End If

                        ' === 5b️⃣ Cek urutan kolom ===
                        For i As Integer = 0 To requiredColumns.Length - 1
                            ' Jika jumlah kolom Excel kurang panjang, langsung hentikan
                            If i >= excelColumns.Count Then Exit For

                            ' Bandingkan kolom ke-i Excel dengan yang seharusnya
                            If Not excelColumns(i).Trim().Equals(requiredColumns(i), StringComparison.OrdinalIgnoreCase) Then
                                wrongOrder.Add("Posisi ke-" & (i + 1).ToString() & " seharusnya '" & requiredColumns(i) & "' (sekarang '" & excelColumns(i) & "')")
                            End If
                        Next

                        If wrongOrder.Count > 0 Then
                            Dim msg As String = "Urutan kolom tidak sesuai di sheet MasterRemote:" & Environment.NewLine & String.Join(Environment.NewLine, wrongOrder)
                            msg = msg.Replace("'", "\'").Replace(Environment.NewLine, "\n")
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "orderError", "alert('" & msg & "');", True)

                            lblMessage.ForeColor = Drawing.Color.Red
                            lblMessage.Text = "Urutan kolom tidak sesuai: " & String.Join(" | ", wrongOrder)
                            clear()
                            Exit Sub
                        End If
                    End Using


                    conexcel.Close()
                End Using

                ' === ✅ Kalau lolos semua validasi ===
                lblMessage.ForeColor = Drawing.Color.Green
                lblMessage.Text = "Validasi file berhasil. Semua sheet dan kolom ditemukan, file berhasil diimport."
                clear()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess",
                "alert('Upload sukses dan validasi Excel berhasil!');", True)

            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadError",
                "alert('Upload Gagal: " & ex.Message.Replace("'", "") & "');", True)
                lblMessage.ForeColor = Drawing.Color.Red
                lblMessage.Text = "Upload gagal: " & ex.Message
            End Try
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "noFile",
            "alert('Silakan pilih file Excel terlebih dahulu.');", True)
            lblMessage.ForeColor = Drawing.Color.Red
            lblMessage.Text = "Silakan pilih file Excel terlebih dahulu."
        End If
        clear()
    End Sub

    'Protected Sub btn_upload_ServerClick(sender As Object, e As EventArgs) Handles btn_upload.ServerClick

    '    If fl_upload.HasFile Then
    '        Try
    '            If cbIdProject.Value <> "" Then
    '                Dim backupdb As String = "BACKUP DATABASE " & con.Database & " TO DISK = '" & clsg.BackupPath & "" & con.Database & ".BAK' WITH INIT"
    '                com = New SqlCommand(backupdb, sqlcon)
    '                sqlcon.Open()
    '                com.ExecuteNonQuery()
    '                sqlcon.Close()


    '                Dim deletetemporary As String = "delete from ms_DataRemote"
    '                com = New SqlCommand(deletetemporary, con)
    '                con.Open()
    '                com.ExecuteNonQuery()
    '                con.Close()


    '                'Dim FileName As String = Path.GetFileName(ASPxUploadControl1.PostedFile.FileName)
    '                'Dim Extension As String = Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
    '                'Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
    '                'Dim FilePath As String = Server.MapPath(FolderPath + FileName)
    '                'ASPxUploadControl1.SaveAs(FilePath)

    '                Dim filename As String
    '                Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
    '                filename = Path.GetFileName(String.Format("{0}_{1}", Time, fl_upload.FileName))
    '                Dim folderPath As String = Server.MapPath("~/master_import/" & filename & "")
    '                fl_upload.SaveAs(folderPath)
    '                Dim IdProject As String = cbIdProject.Value

    '                'Response.Write(folderPath)

    '                'ini untuk define sheetname excel
    '                constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
    '                conexcel = New OleDbConnection(constr)
    '                conexcel.Open()
    '                excelscheme = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '                sheetname = excelscheme.Rows(0)("TABLE_NAME").ToString()
    '                conexcel.Close()

    '                Dim getalldata As String = ""

    '                sheetname = Replace(sheetname, "$", "")
    '                comexcel = New OleDbDataAdapter("select * from [MasterRemote$]", constr)
    '                dataset = New DataSet()
    '                comexcel.Fill(dataset)

    '                dtlexcel = dataset.Tables(0)
    '                If dtlexcel.Rows.Count <> 0 Then
    '                    For i = 0 To dtlexcel.Rows.Count - 1
    '                        Try
    '                            If IsDBNull(dtlexcel.Rows(i).Item("IDPerusahaan")) Then
    '                                Exit Try
    '                            ElseIf IsDBNull(dtlexcel.Rows(i).Item("SubClient")) Then
    '                                Exit Try
    '                            End If

    '                            tmpstr = CariPerusahaan(dtlexcel.Rows(i).Item("IDPerusahaan").ToString)

    '                            sqlexcel = "INSERT INTO ms_DataRemote (IdProject , VID, Province, KABUPATEN, SiteId, IPLAN, KANWIL, [NAMA CABANG INDUK], [NAMA REMOTE], ALAMAT, Satelite, IsActive, Idjarkom, Hub, CustPIC, CustPhonePIC, Provider, IDPerusahaan, IdCustomer_Sub, IdCustomer, Skala) " &
    '                "VALUES('" & IdProject & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("VID").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Province").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("KABUPATEN").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("SiteId").ToString) & "', " &
    '                "'" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("IPLAN").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("KANWIL").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("NAMA CABANG INDUK").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("NAMA REMOTE").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("ALAMAT").ToString) & "', " &
    '                "'" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Satelite").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("IsActive").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Idjarkom").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Hub").ToString) & "','" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("CUSTPIC").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("CUSTPIC_PHONE").ToString) & "', " &
    '                "'" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Provider").ToString) & "', '" & ReplaceSpecialLetter(tmpstr) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("SubClient").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Client").ToString) & "', '" & ReplaceSpecialLetter(dtlexcel.Rows(i).Item("Skala").ToString) & "')"
    '                            com = New SqlCommand(sqlexcel, sqlcon)
    '                            sqlcon.Open()
    '                            com.ExecuteNonQuery()
    '                            sqlcon.Close()

    '                        Catch ex As Exception
    '                            clsg.writedata("System", "Uplaod", "Excel", sqlexcel, ex.Message)
    '                            Exit Sub
    '                        End Try
    '                    Next
    '                End If

    '                dtlexcel = Nothing

    '                Dim insertsite As String = "INSERT INTO trRemoteSite (IdProject, VID, PROVINSI, KOTA, sid, IPLAN, KANWIL, KANCAINDUK, NAMAREMOTE, AlamatInstall, IdSatelite, StatusRemote, IdJarkom, HUB, IdProvider, IdPerusahaan, IdCustomer, IdCustomer_Sub, Skala,  idProvinsi, idCity) " &
    '                                    "SELECT ms_DataRemote.IdProject, ms_DataRemote.VID, ms_DataRemote.Province, ms_DataRemote.KABUPATEN, ms_DataRemote.SiteId, ms_DataRemote.IPLAN, ms_DataRemote.KANWIL, ms_DataRemote.[NAMA CABANG INDUK], " &
    '                                    "ms_DataRemote.[NAMA REMOTE], ms_DataRemote.ALAMAT, ms_DataRemote.Satelite, ms_DataRemote.IsActive, ms_DataRemote.Idjarkom, ms_DataRemote.Hub , ms_DataRemote.Provider, ms_DataRemote.IdPerusahaan, ms_DataRemote.IdCustomer, ms_DataRemote.IdCustomer_Sub, ms_DataRemote.Skala, " &
    '                                    "msProvinsi.IdProvinsi, msKota.idKota FROM ms_DataRemote " &
    '                                    "LEFT OUTER JOIN msProvinsi ON ms_DataRemote.Province = msProvinsi.Provinsi " &
    '                                    "LEFT OUTER JOIN msKota ON msProvinsi.IdProvinsi = msKota.idProvinsi AND ms_DataRemote.KABUPATEN = msKota.Kota"
    '                com = New SqlCommand(insertsite, con)
    '                con.Open()
    '                com.ExecuteNonQuery()
    '                con.Close()

    '                'Dim CommandText As String = "import_lokasi_remote"
    '                'Dim strConnString As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
    '                'Dim con As New SqlConnection(strConnString)
    '                'Dim cmd As New SqlCommand()
    '                'cmd.CommandType = CommandType.StoredProcedure
    '                'cmd.CommandText = CommandText
    '                '' cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = Time
    '                'cmd.Parameters.Add("@IdProject", SqlDbType.VarChar).Value = IdProject
    '                'cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = folderPath
    '                ''cmd.Parameters.Add("@HDR", SqlDbType.VarChar).Value = "HardwareID"
    '                ''cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "MHardware"
    '                'cmd.Connection = con
    '                'Try
    '                '    con.Open()
    '                '    Dim count As Object = cmd.ExecuteNonQuery()
    '                '    'lblMessage.ForeColor = System.Drawing.Color.Green
    '                '    'lblMessage.Text = count.ToString() & " records inserted."
    '                'Catch ex As Exception
    '                '    'lblMessage.ForeColor = System.Drawing.Color.Red
    '                '    'lblMessage.Text = ex.Message
    '                'Finally
    '                '    con.Close()
    '                '    con.Dispose()
    '                'End Try

    '                'Tampilkan notifikasi via Label
    '                lblMessage.Text = "File berhasil diupload: " & filename

    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Upload sukses!');", True)

    '                ' ✅ jalankan JS clearFile() setelah async postback selesai
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clearUpload_" & Guid.NewGuid().ToString(), "clearFile();", True)
    '                'Response.Redirect(Request.RawUrl, False)
    '                'Context.ApplicationInstance.CompleteRequest()
    '            Else
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal", "alert('Silakan pilih file ID Project terlebih dahulu.');", True)
    '                lblMessage.ForeColor = System.Drawing.Color.Red
    '                lblMessage.Text = "Silakan pilih file ID project terlebih dahulu."
    '            End If

    '        Catch ex As Exception
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Upload Gagal!');", True)
    '            lblMessage.ForeColor = System.Drawing.Color.Red
    '            lblMessage.Text = "Upload gagal: " & ex.Message
    '        End Try
    '    Else
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal", "alert('Upload Gagal!');", True)
    '        lblMessage.ForeColor = System.Drawing.Color.Red
    '        lblMessage.Text = "Silakan pilih ID Project dan file upload terlebih dahulu."
    '    End If
    '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "clearUpload", "clearFile();", True)
    '    clear()
    'End Sub

    Sub clear()
        cbIdProject.Value = ""
        'fl_upload.PostedFile.InputStream.Dispose()
        fl_upload.Attributes.Clear()

        'lblPenyelesaianTask.Text = ""
        cbl_JenisTask.UnselectAll()
        upload_penyelesaian.Attributes.Clear()
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

    '=== Fungsi Button Upload ===
    Protected Sub btnuploadpenyelesaiantask_ServerClick(sender As Object, e As EventArgs) Handles btnuploadpenyelesaiantask.ServerClick
        Try
            '=== 1. Cek file ===
            If Not upload_penyelesaian.HasFile Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nofile",
            "alert('Silakan pilih file terlebih dahulu.');", True)
                lblPenyelesaianTask.ForeColor = Drawing.Color.Red
                lblPenyelesaianTask.Text = "Silakan pilih file terlebih dahulu."
                clear()
                Exit Sub
            End If

            '=== 2. Validasi ekstensi ===
            Dim fileExt As String = Path.GetExtension(upload_penyelesaian.FileName).ToLower()
            If fileExt <> ".xlsx" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "extError",
            "alert('Hanya file Excel dengan ekstensi .xlsx yang diperbolehkan.');", True)
                lblPenyelesaianTask.ForeColor = Drawing.Color.Red
                lblPenyelesaianTask.Text = "Format file tidak valid. Harap upload file .xlsx."
                clear()
                Exit Sub
            End If

            '=== 3. Validasi nama file ===
            Dim originalName As String = Path.GetFileName(upload_penyelesaian.FileName)
            If Not originalName.Equals("PenyelesaianTask.xlsx", StringComparison.OrdinalIgnoreCase) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nameError",
            "alert('Nama file harus PenyelesaianTask.xlsx');", True)
                lblPenyelesaianTask.ForeColor = Drawing.Color.Red
                lblPenyelesaianTask.Text = "Nama file tidak sesuai. Gunakan PenyelesaianTask.xlsx."
                clear()
                Exit Sub
            End If

            '=== 4. Backup DB ===
            Dim backupdb As String = "BACKUP DATABASE " & ep.Database & " TO DISK = '" & clsg.BackupPath & "" & ep.Database & ".BAK' WITH INIT"
            com = New SqlCommand(backupdb, sqlcon)
            sqlcon.Open()
            com.ExecuteNonQuery()
            sqlcon.Close()

            '=== 5. Simpan file ke server ===
            Dim Time As String = DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim filename As String = Time & "_" & upload_penyelesaian.FileName
            Dim folderPath As String = Server.MapPath("~/master_import/" & filename)
            upload_penyelesaian.SaveAs(folderPath)

            '=== 6. Connection string Excel ===
            Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'"

            '=== 7. Ambil nama sheet dari Excel ===
            Dim sheetNames As New List(Of String)
            Using conexcel As New OleDbConnection(constr)
                conexcel.Open()
                Dim schema As DataTable = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                sheetNames = schema.AsEnumerable() _
                .Select(Function(r) r("TABLE_NAME").ToString().Trim().Replace("$", "").Replace("'", "")) _
                .ToList()
                conexcel.Close()
            End Using

            '=== 8. Proses sheet sesuai checkbox ===
            Dim selectedTasks = cbl_JenisTask.Items.Cast(Of DevExpress.Web.ListEditItem)().Where(Function(i) i.Selected).ToList()
            If selectedTasks.Count = 0 Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "noSelection",
            "alert('Silakan pilih minimal satu jenis task untuk diimport.');", True)
                lblPenyelesaianTask.ForeColor = Drawing.Color.Red
                lblPenyelesaianTask.Text = "Tidak ada jenis task yang dipilih."
                Exit Sub
            End If

            Dim resultMsg As New List(Of String)
            For Each item As DevExpress.Web.ListEditItem In selectedTasks
                Dim selectedSheet As String = item.Value.Trim()
                Dim match = sheetNames.FirstOrDefault(Function(s) s.Equals(selectedSheet, StringComparison.OrdinalIgnoreCase))

                If String.IsNullOrEmpty(match) Then
                    resultMsg.Add("❌ Sheet '" & selectedSheet & "' tidak ditemukan di Excel.")
                Else
                    Select Case selectedSheet
                        Case "PenyelesainTask"
                            DataUpload_TaskGeneral(match & "$", folderPath)
                        Case "TaskInstalasi"
                            DataUpload_TaskInstalasi(match & "$", folderPath)
                        Case "TaskSurvey"
                            DataUpload_TaskSurvey(match & "$", folderPath)
                    End Select
                    resultMsg.Add("✅ Sheet '" & selectedSheet & "' berhasil diimport.")
                End If
            Next

            '=== 9. Tampilkan hasil ===
            lblPenyelesaianTask.ForeColor = Drawing.Color.Green
            lblPenyelesaianTask.Text = "Import selesai:<br/>" & String.Join("<br/>", resultMsg)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadResult",
            "alert('Import selesai. Lihat detail hasil di bawah.');", True)
            clear()

        Catch ex As Exception
            clear()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal",
            "alert('Import Penyelesaian Task Gagal: " & ex.Message.Replace("'", "") & "');", True)
            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
            lblPenyelesaianTask.Text = "Import Penyelesaian Task Gagal : " & ex.Message
        End Try
    End Sub

    Private Function GetExcelValue(row As DataRow, columnName As String) As Object
        If Not row.Table.Columns.Contains(columnName) Then
            Return DBNull.Value
        End If

        Dim val = row.Item(columnName)
        If val Is Nothing OrElse val Is DBNull.Value Then
            Return DBNull.Value
        End If

        If TypeOf val Is String AndAlso String.IsNullOrWhiteSpace(val.ToString()) Then
            Return DBNull.Value
        End If

        Return val
    End Function

    '=== Helper function untuk ambil DataTable dengan parameter ===
    Private Function GetDataTable(query As String, ParamArray parameters() As SqlParameter) As DataTable
        Dim dt As New DataTable()
        Using cmd As New SqlCommand(query, sqlcon)
            If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                cmd.Parameters.AddRange(parameters)
            End If
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Sub DataUpload_TaskGeneral(NamaSheet As String, FileUploadPath As String)
        Try
            Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileUploadPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
            Using comexcel As New OleDbDataAdapter("SELECT * FROM [" & NamaSheet & "] WHERE vid IS NOT NULL", constr)
                Dim dataset As New DataSet()
                comexcel.Fill(dataset)
                Dim dtlexcel As DataTable = dataset.Tables(0)

                For Each row As DataRow In dtlexcel.Rows
                    Dim vid As Object = GetExcelValue(row, "vid")
                    Dim namaTeknisi As Object = GetExcelValue(row, "NamaTeknisi")
                    Dim nohp As Object = GetExcelValue(row, "NoHp")
                    Dim wilayah As Object = GetExcelValue(row, "Wilayah")
                    Dim hub As Object = GetExcelValue(row, "Hub")
                    Dim taskVal As Object = GetExcelValue(row, "Task")

                    Dim jnsTask As String = ""
                    If taskVal IsNot DBNull.Value Then
                        Dim t As String = taskVal.ToString().Trim()
                        If t.StartsWith("PM") OrElse t.StartsWith("CM") Then
                            jnsTask = t.Substring(0, 2)
                        Else
                            jnsTask = t
                        End If
                    End If

                    Dim wilayahId As Object = DBNull.Value
                    If wilayah IsNot DBNull.Value Then
                        Dim dtwilayah As DataTable = clsg.ExecuteQuery("SELECT idWilayah FROM msWilayah WHERE namaWilayah=@nama", New SqlParameter("@nama", wilayah))
                        If dtwilayah.Rows.Count > 0 Then wilayahId = dtwilayah.Rows(0)("idWilayah")
                    End If

                    Dim hubId As Object = DBNull.Value
                    If hub IsNot DBNull.Value Then
                        Dim dthub As DataTable = clsg.ExecuteQuery("SELECT idHub FROM msHub WHERE namaHub=@nama", New SqlParameter("@nama", hub))
                        If dthub.Rows.Count > 0 Then hubId = dthub.Rows(0)("idHub")
                    End If

                    Dim strsql As String = "INSERT INTO trRemoteSite (vid, NamaTeknisi, NoHp, IdWilayah, IdHub, JenisTask, CreatedDate) " &
                                            "VALUES (@vid, @NamaTeknisi, @NoHp, @IdWilayah, @IdHub, @JenisTask, GETDATE())"

                    Dim parameters As SqlParameter() = {
                    New SqlParameter("@vid", vid),
                    New SqlParameter("@NamaTeknisi", namaTeknisi),
                    New SqlParameter("@NoHp", nohp),
                    New SqlParameter("@IdWilayah", wilayahId),
                    New SqlParameter("@IdHub", hubId),
                    New SqlParameter("@JenisTask", jnsTask)
                }

                    clsg.ExecuteNonQuery(strsql, parameters)
                Next
            End Using
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMsg", "alert('Gagal upload Task General: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
    End Sub

    Private Sub DataUpload_TaskInstalasi(NamaSheet As String, FileUploadPath As String)
        Try
            Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileUploadPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
            Using comexcel As New OleDbDataAdapter("SELECT * FROM [" & NamaSheet & "] WHERE vid IS NOT NULL", constr)
                Dim dataset As New DataSet()
                comexcel.Fill(dataset)
                Dim dtlexcel As DataTable = dataset.Tables(0)

                For Each row As DataRow In dtlexcel.Rows
                    Dim vid As Object = GetExcelValue(row, "vid")
                    Dim siteName As Object = GetExcelValue(row, "NamaSite")
                    Dim alamat As Object = GetExcelValue(row, "Alamat")
                    Dim kota As Object = GetExcelValue(row, "Kota")
                    Dim teknisi As Object = GetExcelValue(row, "NamaTeknisi")
                    Dim nohp As Object = GetExcelValue(row, "NoHp")
                    Dim tglInstalasi As Object = GetExcelValue(row, "TglInstalasi")

                    Dim strsql As String = "INSERT INTO trTaskInstalasi (vid, NamaSite, Alamat, Kota, NamaTeknisi, NoHp, TglInstalasi, CreatedDate) " &
                                            "VALUES (@vid, @NamaSite, @Alamat, @Kota, @NamaTeknisi, @NoHp, @TglInstalasi, GETDATE())"

                    Dim tglInstalasiParam As Object = DBNull.Value

                    If Not (tglInstalasi Is DBNull.Value OrElse String.IsNullOrEmpty(tglInstalasi.ToString())) Then
                        tglInstalasiParam = Convert.ToDateTime(tglInstalasi)
                    End If

                    Dim parameters As SqlParameter() = {
                    New SqlParameter("@vid", vid),
                    New SqlParameter("@NamaSite", siteName),
                    New SqlParameter("@Alamat", alamat),
                    New SqlParameter("@Kota", kota),
                    New SqlParameter("@NamaTeknisi", teknisi),
                    New SqlParameter("@NoHp", nohp),
                    New SqlParameter("@TglInstalasi", tglInstalasiParam)
                    }

                    clsg.ExecuteNonQuery(strsql, parameters)
                Next
            End Using
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMsg", "alert('Gagal upload Task Instalasi: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
    End Sub

    Private Sub DataUpload_TaskSurvey(NamaSheet As String, FileUploadPath As String)
        Try
            Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileUploadPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
            Using comexcel As New OleDbDataAdapter("SELECT * FROM [" & NamaSheet & "] WHERE vid IS NOT NULL", constr)
                Dim dataset As New DataSet()
                comexcel.Fill(dataset)
                Dim dtlexcel As DataTable = dataset.Tables(0)

                For Each row As DataRow In dtlexcel.Rows
                    Dim vid As Object = GetExcelValue(row, "vid")
                    Dim namaSite As Object = GetExcelValue(row, "NamaSite")
                    Dim lokasi As Object = GetExcelValue(row, "Lokasi")
                    Dim hasilSurvey As Object = GetExcelValue(row, "HasilSurvey")
                    Dim rekomendasi As Object = GetExcelValue(row, "Rekomendasi")
                    Dim teknisi As Object = GetExcelValue(row, "NamaTeknisi")
                    Dim nohp As Object = GetExcelValue(row, "NoHp")

                    Dim strsql As String = "INSERT INTO trTaskSurvey (vid, NamaSite, Lokasi, HasilSurvey, Rekomendasi, NamaTeknisi, NoHp, CreatedDate) " &
                                            "VALUES (@vid, @NamaSite, @Lokasi, @HasilSurvey, @Rekomendasi, @NamaTeknisi, @NoHp, GETDATE())"

                    Dim parameters As SqlParameter() = {
                    New SqlParameter("@vid", vid),
                    New SqlParameter("@NamaSite", namaSite),
                    New SqlParameter("@Lokasi", lokasi),
                    New SqlParameter("@HasilSurvey", hasilSurvey),
                    New SqlParameter("@Rekomendasi", rekomendasi),
                    New SqlParameter("@NamaTeknisi", teknisi),
                    New SqlParameter("@NoHp", nohp)
                }

                    clsg.ExecuteNonQuery(strsql, parameters)
                Next
            End Using
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMsg", "alert('Gagal upload Task Survey: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
    End Sub

    'ok Protected Sub btnuploadpenyelesaiantask_ServerClick(sender As Object, e As EventArgs) Handles btnuploadpenyelesaiantask.ServerClick
    '    Try
    '        ' === 1. Cek file ===
    '        If Not upload_penyelesaian.HasFile Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nofile",
    '        "alert('Silakan pilih file terlebih dahulu.');", True)
    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '            lblPenyelesaianTask.Text = "Silakan pilih file terlebih dahulu."
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 2. Validasi ekstensi ===
    '        Dim fileExt As String = Path.GetExtension(upload_penyelesaian.FileName).ToLower()
    '        If fileExt <> ".xlsx" Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "extError",
    '        "alert('Hanya file Excel dengan ekstensi .xlsx yang diperbolehkan.');", True)
    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '            lblPenyelesaianTask.Text = "Format file tidak valid. Harap upload file .xlsx."
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 3. Validasi nama file ===
    '        Dim originalName As String = Path.GetFileName(upload_penyelesaian.FileName)
    '        If Not originalName.Equals("PenyelesaianTask.xlsx", StringComparison.OrdinalIgnoreCase) Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nameError",
    '        "alert('Nama file harus PenyelesaianTask.xlsx');", True)
    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '            lblPenyelesaianTask.Text = "Nama file tidak sesuai. Gunakan PenyelesaianTask.xlsx."
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 4. Backup DB ===
    '        Dim backupdb As String = "BACKUP DATABASE " & ep.Database & " TO DISK = '" & clsg.BackupPath & "" & ep.Database & ".BAK' WITH INIT"
    '        com = New SqlCommand(backupdb, sqlcon)
    '        sqlcon.Open()
    '        com.ExecuteNonQuery()
    '        sqlcon.Close()

    '        ' === 5. Simpan file ke server ===
    '        Dim Time As String = DateTime.Now.ToString("yyyyMMddHHmmss")
    '        Dim filename As String = Time & "_" & upload_penyelesaian.FileName
    '        Dim folderPath As String = Server.MapPath("~/master_import/" & filename)
    '        upload_penyelesaian.SaveAs(folderPath)

    '        ' === 6. Koneksi Excel ===
    '        Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
    '        Dim requiredSheets As String() = {"PenyelesainTask", "TaskInstalasi", "TaskSurvey"}
    '        Dim resultMsg As New List(Of String)

    '        Using conexcel As New OleDbConnection(constr)
    '            conexcel.Open()
    '            Dim schema As DataTable = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '            conexcel.Close()

    '            ' Dapatkan semua nama sheet bersih (tanpa $)
    '            Dim sheetNames As List(Of String) = schema.AsEnumerable() _
    '        .Select(Function(r) r("TABLE_NAME").ToString().Trim().Replace("$", "").Replace("'", "")) _
    '        .ToList()

    '            ' === 7. Proses data sesuai sheet dan checkbox yang dipilih ===
    '            Dim selectedTasks = cbl_JenisTask.Items.Cast(Of DevExpress.Web.ListEditItem)().Where(Function(i) i.Selected).ToList()

    '            If selectedTasks.Count = 0 Then
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "noSelection",
    '            "alert('Silakan pilih minimal satu jenis task untuk diimport.');", True)
    '                lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '                lblPenyelesaianTask.Text = "Tidak ada jenis task yang dipilih."
    '                Exit Sub
    '            End If

    '            For Each item As DevExpress.Web.ListEditItem In selectedTasks
    '                Dim selectedSheet As String = item.Value.Trim()

    '                ' Cek apakah sheet ada di Excel
    '                Dim match = sheetNames.FirstOrDefault(Function(s) s.Equals(selectedSheet, StringComparison.OrdinalIgnoreCase))

    '                If String.IsNullOrEmpty(match) Then
    '                    resultMsg.Add("❌ Sheet '" & selectedSheet & "' tidak ditemukan di Excel.")
    '                Else
    '                    Select Case selectedSheet
    '                        Case "PenyelesainTask"
    '                            DataUpload_TaskGeneral(match & "$")
    '                        Case "TaskInstalasi"
    '                            DataUpload_TaskInstalasi(match & "$")
    '                        Case "TaskSurvey"
    '                            DataUpload_TaskSurvey(match & "$")
    '                    End Select
    '                    resultMsg.Add("✅ Sheet '" & selectedSheet & "' berhasil diimport.")
    '                End If
    '            Next
    '        End Using

    '        ' === 8. Tampilkan hasil ===
    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Green
    '        lblPenyelesaianTask.Text = "Import selesai:<br/>" & String.Join("<br/>", resultMsg)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadResult",
    '    "alert('Import selesai. Lihat detail hasil di bawah.');", True)
    '        clear()

    '    Catch ex As Exception
    '        clear()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal",
    '    "alert('Import Penyelesaian Task Gagal: " & ex.Message.Replace("'", "") & "');", True)
    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '        lblPenyelesaianTask.Text = "Import Penyelesaian Task Gagal : " & ex.Message
    '    End Try
    'End Sub


    'Protected Sub btnuploadpenyelesaiantask_ServerClick(sender As Object, e As EventArgs) Handles btnuploadpenyelesaiantask.ServerClick
    '    Try
    '        ' === 1. Cek file ===
    '        If Not upload_penyelesaian.HasFile Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nofile",
    '            "alert('Silakan pilih file terlebih dahulu.');", True)
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 2. Validasi ekstensi ===
    '        Dim fileExt As String = Path.GetExtension(upload_penyelesaian.FileName).ToLower()
    '        If fileExt <> ".xlsx" Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "extError",
    '            "alert('Hanya file Excel dengan ekstensi .xlsx yang diperbolehkan.');", True)
    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '            lblPenyelesaianTask.Text = "Format file tidak valid. Harap upload file .xlsx."
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 3. Validasi nama file ===
    '        Dim originalName As String = Path.GetFileName(upload_penyelesaian.FileName)
    '        If Not originalName.Equals("PenyelesaianTask.xlsx", StringComparison.OrdinalIgnoreCase) Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nameError",
    '            "alert('Nama file harus PenyelesaianTask.xlsx');", True)
    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '            lblPenyelesaianTask.Text = "Nama file tidak sesuai. Gunakan PenyelesaianTask.xlsx."
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 4. Backup DB ===
    '        Dim backupdb As String = "BACKUP DATABASE " & ep.Database & " TO DISK = '" & clsg.BackupPath & "" & ep.Database & ".BAK' WITH INIT"
    '        com = New SqlCommand(backupdb, sqlcon)
    '        sqlcon.Open()
    '        com.ExecuteNonQuery()
    '        sqlcon.Close()

    '        ' === 5. Simpan file ke server ===
    '        Dim Time As String = DateTime.Now.ToString("yyyyMMddHHmmss")
    '        Dim filename As String = Time & "_" & upload_penyelesaian.FileName
    '        Dim folderPath As String = Server.MapPath("~/master_import/" & filename)
    '        upload_penyelesaian.SaveAs(folderPath)

    '        ' === 6. Koneksi Excel ===
    '        Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
    '        Dim resultMsg As New List(Of String)

    '        Using conexcel As New OleDbConnection(constr)
    '            conexcel.Open()
    '            Dim schema As DataTable = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '            conexcel.Close()

    '            ' Dapatkan nama semua sheet
    '            Dim sheetNames As List(Of String) = schema.AsEnumerable() _
    '            .Select(Function(r) r("TABLE_NAME").ToString().Trim().Replace("$", "").Replace("'", "")) _
    '            .ToList()

    '            ' === 7. Ambil task yang dicentang ===
    '            Dim selectedTasks = cbl_JenisTask.Items.Cast(Of DevExpress.Web.ListEditItem)().
    '            Where(Function(i) i.Selected).ToList()

    '            If selectedTasks.Count = 0 Then
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "noSelection",
    '                "alert('Silakan pilih minimal satu jenis task untuk diimport.');", True)
    '                lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '                lblPenyelesaianTask.Text = "Tidak ada jenis task yang dipilih."
    '                Exit Sub
    '            End If

    '            ' === 8. Proses hanya sheet yang dipilih ===
    '            For Each item As DevExpress.Web.ListEditItem In selectedTasks
    '                Dim selectedSheet As String = item.Value.Trim()

    '                ' Cek apakah sheet ada di Excel
    '                Dim match = sheetNames.FirstOrDefault(Function(s) s.Equals(selectedSheet, StringComparison.OrdinalIgnoreCase))

    '                If match Is Nothing Then
    '                    resultMsg.Add("❌ Sheet '" & selectedSheet & "' tidak ditemukan di file Excel.")
    '                Else
    '                    Select Case selectedSheet
    '                        Case "PenyelesainTask"
    '                            DataUpload_TaskGeneral(match & "$")
    '                        Case "TaskInstalasi"
    '                            DataUpload_TaskInstalasi(match & "$")
    '                        Case "TaskSurvey"
    '                            DataUpload_TaskSurvey(match & "$")
    '                    End Select
    '                    resultMsg.Add("❌ Sheet '" & selectedSheet & "' berhasil diimport.")
    '                End If
    '            Next

    '        End Using

    '        ' === 9. Tampilkan hasil ===
    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Green
    '        lblPenyelesaianTask.Text = "Import selesai.<br/>" & String.Join("<br/>", resultMsg)
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadResult",
    '        "alert('Hasil import:\n" & String.Join("\n", resultMsg) & "');", True)

    '        cbl_JenisTask.UnselectAll()
    '        clear()

    '    Catch ex As Exception
    '        clear()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal",
    '        "alert('Import Penyelesaian Task Gagal: " & ex.Message.Replace("'", "") & "');", True)
    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '        lblPenyelesaianTask.Text = "Import Penyelesaian Task Gagal : " & ex.Message
    '    End Try
    'End Sub


    'Protected Sub btnuploadpenyelesaiantask_ServerClick(sender As Object, e As EventArgs) Handles btnuploadpenyelesaiantask.ServerClick

    '    Try
    '        ' === 1️⃣ Cek apakah file dipilih ===
    '        If Not upload_penyelesaian.HasFile Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nofile",
    '            "alert('Silakan pilih file terlebih dahulu.');", True)
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 2️⃣ Validasi ekstensi file ===
    '        Dim fileExt As String = Path.GetExtension(upload_penyelesaian.FileName).ToLower()
    '        If fileExt <> ".xlsx" Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "extError",
    '            "alert('Hanya file Excel dengan ekstensi .xlsx yang diperbolehkan.');", True)
    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '            lblPenyelesaianTask.Text = "Format file tidak valid. Harap upload file dengan ekstensi .xlsx."
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 3️⃣ Validasi nama file ===
    '        Dim originalName As String = Path.GetFileName(upload_penyelesaian.FileName)
    '        If Not originalName.Equals("PenyelesaianTask.xlsx", StringComparison.OrdinalIgnoreCase) Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nameError",
    '            "alert('Nama file harus PenyelesaianTask.xlsx');", True)
    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '            lblPenyelesaianTask.Text = "Nama file tidak sesuai. Harap gunakan file bernama PenyelesaianTask.xlsx."
    '            clear()
    '            Exit Sub
    '        End If

    '        ' === 4️⃣ Backup database sebelum import ===
    '        Dim backupdb As String = "BACKUP DATABASE " & ep.Database & " TO DISK = '" & clsg.BackupPath & "" & ep.Database & ".BAK' WITH INIT"
    '        com = New SqlCommand(backupdb, sqlcon)
    '        sqlcon.Open()
    '        com.ExecuteNonQuery()
    '        sqlcon.Close()

    '        ' === 5️⃣ Simpan file ke server ===
    '        Dim Time As String = DateTime.Now.ToString("yyyyMMddHHmmss")
    '        Dim filename As String = Time & "_" & upload_penyelesaian.FileName
    '        Dim folderPath As String = Server.MapPath("~/master_import/" & filename)
    '        upload_penyelesaian.SaveAs(folderPath)

    '        ' === 6️⃣ Definisi kolom per sheet ===
    '        Dim colsPenyelesaian As String() = {"VID", "IPLAN", "Tanggal", "Task", "NAMA REMOTE", "NIK", "NamaTeknisi", "TglBerangkat", "TglSelesai", "TglPulang", "TglStatus", "StatusPerbaikan", "StatusCekKoordinator", "IDJarkom", "IDSatelite", "Hub", "NamaPIC", "TelpPIC", "SQF", "InisialESNO", "CPI", "HasilXPoll", "HasilXPoll2", "AktivitasSolusi", "Project", "IDKoordinator", "NamaKoordinator", "Mounting", "PanjangKabel", "UPSForbackup", "IDProject", "StatusManager", "StatusTask", "NamaTask", "IdManager", "NamaManager"}
    '        Dim colsInstalasi As String() = {"VID", "IPLAN", "Tanggal", "Task", "NAMA REMOTE", "NIK", "NamaTeknisi", "TglBerangkat", "TglSelesai", "TglPulang", "TglStatus", "StatusPerbaikan", "StatusCekKoordinator", "IDJarkom", "IDSatelite", "Hub", "NamaPIC", "TelpPIC", "Latitude", "Longitude", "SID", "SQF", "INTIALESNO", "CPI", "CToN", "UPSForBackUp", "Mounting", "PanjangKabel", "UkuranAntena", "SourceListrik", "AktivitasSolusi", "LAN1-IPAdrress", "LAN2-IPAdrress", "Project", "IDKoordinator", "NamaKoordinator", "IDProject", "StatusManager", "StatusTask", "NamaTask"}
    '        Dim colsSurvey As String() = {"VID", "IPLAN", "Tanggal", "Task", "NAMA REMOTE", "NIK", "NamaTeknisi", "TglBerangkat", "TglSelesai", "TglPulang", "TglStatus", "StatusPerbaikan", "StatusCekKoordinator", "IDJarkom", "IDSatelite", "Hub", "NamaPIC", "TelpPIC", "Keterangan", "Latitude", "Longitude", "AlamatPengiriman", "TempatPenyimpanan", "UkuranAntena", "TempatAntena", "KekuatanRoofTop", "PengukuranListrikAwal", "ACIndoor", "TypeKabel", "ArahAntena", "StatusHasilSurvey", "Project", "IDKoordinator", "NamaKoordinator", "Mounting", "PanjangKabel", "IDProject", "StatusManager", "StatusTask", "NamaTask", "IdManager", "NamaManager"}

    '        ' === 7️⃣ Validasi sheet & kolom ===
    '        'Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
    '        Dim constr As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"

    '        Dim requiredSheets As String() = {"PenyelesainTask$", "TaskInstalasi$", "TaskSurvey$"}

    '        Using conexcel As New OleDbConnection(constr)
    '            conexcel.Open()
    '            Dim schema As DataTable = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '            conexcel.Close()

    '            ' Cek keberadaan sheet
    '            Dim sheetNames As List(Of String) = schema.AsEnumerable().Select(Function(r) r("TABLE_NAME").ToString()).ToList()
    '            Dim missingSheets As New List(Of String)

    '            For Each s In requiredSheets
    '                Dim found = sheetNames.Any(Function(n) n.Equals(s, StringComparison.OrdinalIgnoreCase))
    '                If Not found Then missingSheets.Add(s.Replace("$", ""))
    '            Next

    '            If missingSheets.Count > 0 Then
    '                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sheetError",
    '                "alert('Sheet berikut tidak ditemukan di Excel: " & String.Join(", ", missingSheets) & "');", True)
    '                Exit Sub
    '            End If

    '            ' Cek kolom per sheet
    '            For Each sheet As String In requiredSheets
    '                Dim query As String = "SELECT TOP 1 * FROM [" & sheet & "]"
    '                Dim da As New OleDbDataAdapter(query, conexcel)
    '                Dim dt As New DataTable
    '                da.Fill(dt)

    '                Dim actualCols As String() = dt.Columns.Cast(Of DataColumn)().Select(Function(c) c.ColumnName.Trim()).ToArray()
    '                Dim expectedCols As String()

    '                Select Case sheet
    '                    Case "PenyelesainTask$"
    '                        expectedCols = colsPenyelesaian
    '                    Case "TaskInstalasi$"
    '                        expectedCols = colsInstalasi
    '                    Case "TaskSurvey$"
    '                        expectedCols = colsSurvey
    '                    Case Else
    '                        Continue For
    '                End Select

    '                Dim wrongOrder As New List(Of String)
    '                For i = 0 To Math.Min(expectedCols.Length, actualCols.Length) - 1
    '                    If Not expectedCols(i).Equals(actualCols(i), StringComparison.OrdinalIgnoreCase) Then
    '                        wrongOrder.Add("Kolom ke-" & (i + 1) & ": '" & actualCols(i) & "' seharusnya '" & expectedCols(i) & "'")
    '                    End If
    '                Next

    '                If wrongOrder.Count > 0 Then
    '                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "colError",
    '                    "alert('Urutan kolom tidak sesuai di sheet " & sheet.Replace("$", "") & ":\n" & String.Join("\n", wrongOrder) & "');", True)
    '                    Exit Sub
    '                End If
    '            Next

    '            ' === 8️⃣ Proses data sesuai sheet & checklist ===
    '            For i = 0 To schema.Rows.Count - 1
    '                For ii = 0 To cbl_JenisTask.SelectedItems.Count - 1
    '                    Dim sheetName = Replace(schema.Rows(i)("TABLE_NAME").ToString(), "$", "")
    '                    If cbl_JenisTask.SelectedItems.Item(ii).Value = sheetName Then
    '                        Select Case sheetName
    '                            Case "PenyelesainTask"
    '                                DataUpload_TaskGeneral(schema.Rows(i)("TABLE_NAME").ToString())
    '                            Case "TaskInstalasi"
    '                                DataUpload_TaskInstalasi(schema.Rows(i)("TABLE_NAME").ToString())
    '                            Case "TaskSurvey"
    '                                DataUpload_TaskSurvey(schema.Rows(i)("TABLE_NAME").ToString())
    '                        End Select
    '                    End If
    '                Next
    '            Next
    '        End Using

    '        ' === 9️⃣ Sukses ===
    '        cbl_JenisTask.UnselectAll()
    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Green
    '        lblPenyelesaianTask.Text = "Import Penyelesaian Task Success : " & filename
    '        clear()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Import Penyelesaian Task Success.');", True)

    '    Catch ex As Exception
    '        clear()
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal",
    '        "alert('Import Penyelesaian Task Gagal: " & ex.Message.Replace("'", "") & "');", True)
    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '        lblPenyelesaianTask.Text = "Import Penyelesaian Task Gagal : " & ex.Message
    '    End Try


    '    'Try
    '    '    ' === 1️⃣ Cek apakah file dipilih ===
    '    '    If Not upload_penyelesaian.HasFile Then
    '    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nofile",
    '    '            "alert('Silakan pilih file terlebih dahulu.');", True)
    '    '        clear()
    '    '        Exit Sub
    '    '    End If

    '    '    ' === 2️⃣ Validasi ekstensi file ===
    '    '    Dim fileExt As String = Path.GetExtension(upload_penyelesaian.FileName).ToLower()
    '    '    If fileExt <> ".xlsx" Then
    '    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "extError",
    '    '            "alert('Hanya file Excel dengan ekstensi .xlsx yang diperbolehkan.');", True)
    '    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '    '        lblPenyelesaianTask.Text = "Format file tidak valid. Harap upload file dengan ekstensi .xlsx."
    '    '        clear()
    '    '        Exit Sub
    '    '    End If

    '    '    ' === 3️⃣ Validasi nama file ===
    '    '    Dim originalName As String = Path.GetFileName(upload_penyelesaian.FileName)
    '    '    If Not originalName.Equals("PenyelesaianTask.xlsx", StringComparison.OrdinalIgnoreCase) Then
    '    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "nameError",
    '    '            "alert('Nama file harus PenyelesaianTask.xlsx');", True)
    '    '        lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '    '        lblPenyelesaianTask.Text = "Nama file tidak sesuai. Harap gunakan file bernama PenyelesaianTask.xlsx."
    '    '        clear()
    '    '        Exit Sub
    '    '    End If

    '    '    ' === 4️⃣ Backup database sebelum import ===
    '    '    Dim backupdb As String = "BACKUP DATABASE " & ep.Database & " TO DISK = '" & clsg.BackupPath & "" & ep.Database & ".BAK' WITH INIT"
    '    '    com = New SqlCommand(backupdb, sqlcon)
    '    '    sqlcon.Open()
    '    '    com.ExecuteNonQuery()
    '    '    sqlcon.Close()

    '    '    ' === 5️⃣ Simpan file ke server ===
    '    '    Dim Time As String = DateTime.Now.ToString("yyyyMMddHHmmss")
    '    '    Dim filename As String = Time & "_" & upload_penyelesaian.FileName
    '    '    Dim folderPath As String = Server.MapPath("~/master_import/" & filename)
    '    '    upload_penyelesaian.SaveAs(folderPath)

    '    '    ' === 6️⃣ Cek sheet di Excel ===
    '    '    Dim constr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
    '    '    Dim requiredSheets As String() = {"PenyelesainTask$", "TaskInstalasi$", "TaskSurvey$"}

    '    '    Using conexcel As New OleDbConnection(constr)
    '    '        conexcel.Open()
    '    '        Dim schema As DataTable = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '    '        conexcel.Close()

    '    '        ' Cek sheet yang ada
    '    '        Dim sheetNames As List(Of String) = schema.AsEnumerable().Select(Function(r) r("TABLE_NAME").ToString()).ToList()
    '    '        Dim missingSheets As New List(Of String)

    '    '        For Each s In requiredSheets
    '    '            Dim found = sheetNames.Any(Function(n) n.Equals(s, StringComparison.OrdinalIgnoreCase))
    '    '            If Not found Then
    '    '                missingSheets.Add(s.Replace("$", ""))
    '    '            End If
    '    '        Next

    '    '        If missingSheets.Count > 0 Then
    '    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sheetError",
    '    '                "alert('Sheet berikut tidak ditemukan di Excel: " & String.Join(", ", missingSheets) & "');", True)
    '    '            lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '    '            lblPenyelesaianTask.Text = "Sheet wajib berikut tidak ditemukan: " & String.Join(", ", missingSheets)
    '    '            Exit Sub
    '    '        End If

    '    '        ' === 7️⃣ Proses data sesuai sheet dan checkbox yang dipilih ===
    '    '        For i = 0 To schema.Rows.Count - 1
    '    '            For ii = 0 To cbl_JenisTask.SelectedItems.Count - 1
    '    '                Dim sheetName = Replace(schema.Rows(i)("TABLE_NAME").ToString(), "$", "")
    '    '                If cbl_JenisTask.SelectedItems.Item(ii).Value = sheetName Then
    '    '                    Select Case sheetName
    '    '                        Case "PenyelesainTask"
    '    '                            DataUpload_TaskGeneral(schema.Rows(i)("TABLE_NAME").ToString())
    '    '                        Case "TaskInstalasi"
    '    '                            DataUpload_TaskInstalasi(schema.Rows(i)("TABLE_NAME").ToString())
    '    '                        Case "TaskSurvey"
    '    '                            DataUpload_TaskSurvey(schema.Rows(i)("TABLE_NAME").ToString())
    '    '                    End Select
    '    '                End If
    '    '            Next
    '    '        Next
    '    '    End Using

    '    '    ' === 8️⃣ Reset UI dan tampilkan pesan sukses ===
    '    '    cbl_JenisTask.UnselectAll()
    '    '    lblPenyelesaianTask.ForeColor = Drawing.Color.Green
    '    '    lblPenyelesaianTask.Text = "Import Penyelesaian Task Success : " & filename
    '    '    clear()
    '    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Import Penyelesaian Task Success.');", True)

    '    'Catch ex As Exception
    '    '    clear()
    '    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal",
    '    '        "alert('Import Penyelesaian Task Gagal: " & ex.Message.Replace("'", "") & "');", True)
    '    '    lblPenyelesaianTask.ForeColor = Drawing.Color.Red
    '    '    lblPenyelesaianTask.Text = "Import Penyelesaian Task Gagal : " & ex.Message
    '    'End Try

    '    'Try

    '    '    'Dim FileName As String = Path.GetFileName(ASPxUploadControl1.PostedFile.FileName)
    '    '    'Dim Extension As String = Path.GetExtension(ASPxUploadControl1.PostedFile.FileName)
    '    '    'Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
    '    '    'Dim FilePath As String = Server.MapPath(FolderPath + FileName)
    '    '    'ASPxUploadControl1.SaveAs(FilePath)
    '    '    If upload_penyelesaian.HasFile = False Then
    '    '        Exit Sub
    '    '    End If

    '    '    Dim backupdb As String = "BACKUP DATABASE " & ep.Database & " TO DISK = '" & clsg.BackupPath & "" & ep.Database & ".BAK' WITH INIT"
    '    '    com = New SqlCommand(backupdb, sqlcon)
    '    '    sqlcon.Open()
    '    '    com.ExecuteNonQuery()
    '    '    sqlcon.Close()

    '    '    Dim filename As String
    '    '    Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
    '    '    filename = Path.GetFileName(String.Format("{0}_{1}", Time, upload_penyelesaian.FileName))
    '    '    Dim folderPath As String = Server.MapPath("~/master_import/" & filename & "")
    '    '    upload_penyelesaian.SaveAs(folderPath)
    '    '    'Dim IdProject As String = cbIdProject.Value

    '    '    'Response.Write(folderPath)

    '    '    'ini untuk define sheetname excel
    '    '    constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folderPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
    '    '    conexcel = New OleDbConnection(constr)
    '    '    conexcel.Open()
    '    '    excelscheme = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

    '    '    conexcel.Close()

    '    '    If excelscheme.Rows.Count > 0 Then
    '    '        For i = 0 To excelscheme.Rows.Count - 1
    '    '            For ii = 0 To cbl_JenisTask.SelectedItems.Count - 1
    '    '                If cbl_JenisTask.SelectedItems.Item(ii).Value = Replace(excelscheme.Rows(i)("TABLE_NAME"), "$", "") Then
    '    '                    If cbl_JenisTask.SelectedItems.Item(ii).Value = "PenyelesainTask" Then
    '    '                        DataUpload_TaskGeneral(excelscheme.Rows(i)("TABLE_NAME"))
    '    '                    ElseIf cbl_JenisTask.SelectedItems.Item(ii).Value = "TaskInstalasi" Then
    '    '                        DataUpload_TaskInstalasi(excelscheme.Rows(i)("TABLE_NAME"))
    '    '                    ElseIf cbl_JenisTask.SelectedItems.Item(ii).Value = "TaskSurvey" Then
    '    '                        DataUpload_TaskSurvey(excelscheme.Rows(i)("TABLE_NAME"))
    '    '                    End If
    '    '                End If
    '    '            Next
    '    '            'If excelscheme.Rows(i).Item("TABLE_NAME") = txt_NamaSheetExcel.Value & "$" Then
    '    '            '    sheetname = excelscheme.Rows(i)("TABLE_NAME")
    '    '            '    Exit For
    '    '            'End If
    '    '        Next
    '    '    End If

    '    '    'Exit Sub

    '    '    'Dim CommandText As String = "import_penyelesaian_task"
    '    '    'Dim strConnString As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
    '    '    'Dim con As New SqlConnection(strConnString)
    '    '    'Dim cmd As New SqlCommand()
    '    '    'cmd.CommandType = CommandType.StoredProcedure
    '    '    'cmd.CommandText = CommandText
    '    '    ''cmd.Parameters.Add("@IdProject", SqlDbType.VarChar).Value = IdProject
    '    '    'cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = folderPath
    '    '    ''cmd.Parameters.Add("@HDR", SqlDbType.VarChar).Value = "HardwareID"
    '    '    ''cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "MHardware"
    '    '    'cmd.Connection = con
    '    '    'Try
    '    '    '    con.Open()
    '    '    '    Dim count As Object = cmd.ExecuteNonQuery()
    '    '    '    'lblMessage.ForeColor = System.Drawing.Color.Green
    '    '    '    'lblMessage.Text = count.ToString() & " records inserted."
    '    '    'Catch ex As Exception
    '    '    '    'lblMessage.ForeColor = System.Drawing.Color.Red
    '    '    '    'lblMessage.Text = ex.Message
    '    '    'Finally
    '    '    '    con.Close()
    '    '    '    con.Dispose()
    '    '    'End Try
    '    '    cbl_JenisTask.UnselectAll()
    '    '    'Response.Write("<script>alert('Import Penyelesaian Task Success.')</script>")
    '    '    lblPenyelesaianTask.Text = "Import Penyelesaian Task Success : " & filename
    '    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadSuccess", "alert('Import Penyelesaian Task Success.');", True)
    '    'Catch ex As Exception
    '    '    'Response.Write("<script>alert('Import Penyelesaian Task Gagal.')</script>" & ex.Message())
    '    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "uploadGagal", "alert('Import Penyelesaian Task Gagal.');", True)
    '    '    lblPenyelesaianTask.Text = "Import Penyelesaian Task Gagal : " & ex.Message
    '    'End Try

    'End Sub

    Protected Sub btncancelpenyelesaian_ServerClick(sender As Object, e As EventArgs) Handles btncancelpenyelesaian.ServerClick
        clear()
    End Sub

    'OK Private Sub DataUpload_TaskGeneral(NamaSheet As String)
    '    ' NamaSheet expected: "PenyelesainTask$"
    '    'Try
    '    '    If String.IsNullOrWhiteSpace(NamaSheet) Then Return

    '    '    ' --- 1) Baca data Excel ---
    '    '    Dim dtlexcel As New DataTable()
    '    '    Using da As New OleDbDataAdapter("SELECT * FROM [" & NamaSheet & "] WHERE VID IS NOT NULL", constr)
    '    '        da.Fill(dtlexcel)
    '    '    End Using

    '    '    If dtlexcel.Rows.Count = 0 Then Return

    '    '    ' --- 2) SQL insert parameterized ---
    '    '    Dim insertTrTaskSql As String =
    '    '    "INSERT INTO trTask (NoTask, TanggalTask, IdProject, IdTeknisi, NamaTeknisi, IdKoordinator, NamaKoordinator, IdJenisTask, IdProvinsi, IdCity, Provinsi, City, TglMulai, TglSelesai, TglStatusTask, IdStatusTask, IdStatusKoordinator, IdStatusManager, TglStatusManager, IdUserManager, DateStamp, tglentrytaskcoor, NamaTask, DeskripsiPermasalahan, NamaPelapor, TelpPelapor) " &
    '    '    "VALUES (@NoTask, @TanggalTask, @IdProject, @IdTeknisi, @NamaTeknisi, @IdKoordinator, @NamaKoordinator, @IdJenisTask, @IdProvinsi, @IdCity, @Provinsi, @City, @TglMulai, @TglSelesai, @TglStatusTask, @IdStatusTask, @IdStatusKoordinator, @IdStatusManager, @TglStatusManager, @IdUserManager, GETDATE(), GETDATE(), @NamaTask, @DeskripsiPermasalahan, @NamaPelapor, @TelpPelapor);"

    '    '    Dim insertTrDetailSql As String =
    '    '    "INSERT INTO trDetail_Task (NoTask, VID, IPLAN, KANWIL, KANCAINDUK, NAMAREMOTE, ALAMAT, idProvinsi, PROVINSI, idCity, KOTA, IdJarkom, IdSatelite, idJenisTask, NoHpPic, PIC, TglBerangkat, TglSelesaiKerjaan, TglPulang, IdStatusPerbaikan, TglStatusPerbaikan, UserStamp, DateStamp, HasilXPOLL, CPI, Hub, SQF, INITIAL_ESNO, FlagDataLokasi, FlagGeneralInfo, FlagDataTeknis, FlagDataBarang, FlagUploadPhoto, FlagDataInstallasi, FlagDataSurvey) " &
    '    '    "VALUES (@NoTask, @VID, @IPLAN, @KANWIL, @KANCAINDUK, @NAMAREMOTE, @ALAMAT, @idProvinsi, @PROVINSI, @idCity, @KOTA, @IdJarkom, @IdSatelite, @idJenisTask, @NoHpPic, @PIC, @TglBerangkat, @TglSelesaiKerjaan, @TglPulang, @IdStatusPerbaikan, @TglStatusPerbaikan, @UserStamp, GETDATE(), @HasilXPOLL, @CPI, @Hub, @SQF, @INITIAL_ESNO, @FlagDataLokasi, @FlagGeneralInfo, @FlagDataTeknis, @FlagDataBarang, @FlagUploadPhoto, @FlagDataInstallasi, @FlagDataSurvey);"

    '    '    ' --- 3) Buka koneksi SQL ---
    '    '    If sqlcon.State <> ConnectionState.Open Then sqlcon.Open()

    '    '    Using cmdInsertTrTask As New SqlCommand(insertTrTaskSql, sqlcon),
    '    '      cmdInsertTrDetail As New SqlCommand(insertTrDetailSql, sqlcon)

    '    '        ' --- 4) Tambahkan parameter trTask ---
    '    '        cmdInsertTrTask.Parameters.Add("@NoTask", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@TanggalTask", SqlDbType.DateTime)
    '    '        cmdInsertTrTask.Parameters.Add("@IdProject", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@IdTeknisi", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@NamaTeknisi", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrTask.Parameters.Add("@IdKoordinator", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@NamaKoordinator", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrTask.Parameters.Add("@IdJenisTask", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@IdProvinsi", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@IdCity", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@Provinsi", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrTask.Parameters.Add("@City", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrTask.Parameters.Add("@TglMulai", SqlDbType.DateTime)
    '    '        cmdInsertTrTask.Parameters.Add("@TglSelesai", SqlDbType.DateTime)
    '    '        cmdInsertTrTask.Parameters.Add("@TglStatusTask", SqlDbType.DateTime)
    '    '        cmdInsertTrTask.Parameters.Add("@IdStatusTask", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@IdStatusKoordinator", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@IdStatusManager", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@TglStatusManager", SqlDbType.DateTime)
    '    '        cmdInsertTrTask.Parameters.Add("@IdUserManager", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrTask.Parameters.Add("@NamaTask", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrTask.Parameters.Add("@DeskripsiPermasalahan", SqlDbType.NVarChar, 500)
    '    '        cmdInsertTrTask.Parameters.Add("@NamaPelapor", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrTask.Parameters.Add("@TelpPelapor", SqlDbType.NVarChar, 100)

    '    '        ' --- 5) Tambahkan parameter trDetail_Task ---
    '    '        cmdInsertTrDetail.Parameters.Add("@NoTask", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrDetail.Parameters.Add("@VID", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@IPLAN", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@KANWIL", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@KANCAINDUK", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@NAMAREMOTE", SqlDbType.NVarChar, 300)
    '    '        cmdInsertTrDetail.Parameters.Add("@ALAMAT", SqlDbType.NVarChar, 500)
    '    '        cmdInsertTrDetail.Parameters.Add("@idProvinsi", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrDetail.Parameters.Add("@PROVINSI", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@idCity", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrDetail.Parameters.Add("@KOTA", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@IdJarkom", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@IdSatelite", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@idJenisTask", SqlDbType.NVarChar, 50)
    '    '        cmdInsertTrDetail.Parameters.Add("@NoHpPic", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@PIC", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@TglBerangkat", SqlDbType.DateTime)
    '    '        cmdInsertTrDetail.Parameters.Add("@TglSelesaiKerjaan", SqlDbType.DateTime)
    '    '        cmdInsertTrDetail.Parameters.Add("@TglPulang", SqlDbType.DateTime)
    '    '        cmdInsertTrDetail.Parameters.Add("@IdStatusPerbaikan", SqlDbType.Int)
    '    '        cmdInsertTrDetail.Parameters.Add("@TglStatusPerbaikan", SqlDbType.DateTime)
    '    '        cmdInsertTrDetail.Parameters.Add("@UserStamp", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@HasilXPOLL", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@CPI", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@Hub", SqlDbType.NVarChar, 200)
    '    '        cmdInsertTrDetail.Parameters.Add("@SQF", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@INITIAL_ESNO", SqlDbType.NVarChar, 100)
    '    '        cmdInsertTrDetail.Parameters.Add("@FlagDataLokasi", SqlDbType.Bit)
    '    '        cmdInsertTrDetail.Parameters.Add("@FlagGeneralInfo", SqlDbType.Bit)
    '    '        cmdInsertTrDetail.Parameters.Add("@FlagDataTeknis", SqlDbType.Bit)
    '    '        cmdInsertTrDetail.Parameters.Add("@FlagDataBarang", SqlDbType.Bit)
    '    '        cmdInsertTrDetail.Parameters.Add("@FlagUploadPhoto", SqlDbType.Bit)
    '    '        cmdInsertTrDetail.Parameters.Add("@FlagDataInstallasi", SqlDbType.Bit)
    '    '        cmdInsertTrDetail.Parameters.Add("@FlagDataSurvey", SqlDbType.Bit)

    '    '        ' --- 6) Loop Excel ---
    '    '        Dim notaskVal As String = ""
    '    '        Dim vid As String = ""
    '    '        For Each row As DataRow In dtlexcel.Rows
    '    '            Try
    '    '                ' --- Generate NoTask ---
    '    '                Dim tbNoTask As DataTable = clsg.ExecuteQuery("SELECT TOP 1 NoTask FROM trTask ORDER BY NoTask DESC")
    '    '                notaskVal = "100001"
    '    '                If tbNoTask IsNot Nothing AndAlso tbNoTask.Rows.Count > 0 Then
    '    '                    Dim curNo As Integer
    '    '                    If Integer.TryParse(tbNoTask.Rows(0)("NoTask").ToString(), curNo) Then notaskVal = (curNo + 1).ToString()
    '    '                End If

    '    '                ' --- Lookup trRemoteSite safely ---
    '    '                vid = If(row.Table.Columns.Contains("VID") AndAlso Not IsDBNull(row("VID")), row("VID").ToString().Trim(), "")
    '    '                Dim IdProvinsi As String = Nothing, Provinsi As String = Nothing, IdCity As String = Nothing, kota As String = Nothing, kanwil As String = Nothing, KANCAINDUK As String = Nothing, ALAMAT As String = Nothing

    '    '                If vid <> "" Then
    '    '                    Using cmdRemote As New SqlCommand("SELECT TOP 1 * FROM trRemoteSite WHERE vid=@vid", sqlcon)
    '    '                        cmdRemote.Parameters.AddWithValue("@vid", vid)
    '    '                        Using rdr As SqlDataReader = cmdRemote.ExecuteReader()
    '    '                            If rdr.Read() Then
    '    '                                IdProvinsi = If(Not IsDBNull(rdr("idProvinsi")), rdr("idProvinsi").ToString(), Nothing)
    '    '                                Provinsi = If(Not IsDBNull(rdr("PROVINSI")), rdr("PROVINSI").ToString(), Nothing)
    '    '                                IdCity = If(Not IsDBNull(rdr("idCity")), rdr("idCity").ToString(), Nothing)
    '    '                                kota = If(Not IsDBNull(rdr("KOTA")), rdr("KOTA").ToString(), Nothing)
    '    '                                kanwil = If(Not IsDBNull(rdr("KANWIL")), rdr("KANWIL").ToString(), Nothing)
    '    '                                KANCAINDUK = If(Not IsDBNull(rdr("KANCAINDUK")), rdr("KANCAINDUK").ToString(), Nothing)
    '    '                                ALAMAT = If(Not IsDBNull(rdr("AlamatInstall")), rdr("AlamatInstall").ToString(), Nothing)
    '    '                            End If
    '    '                        End Using
    '    '                    End Using
    '    '                End If

    '    '                ' --- Lookup Hub safely ---
    '    '                Dim hubVal As String = Nothing
    '    '                If row.Table.Columns.Contains("Hub") AndAlso Not IsDBNull(row("Hub")) AndAlso row("Hub").ToString().Trim() <> "" Then
    '    '                    Using cmdHub As New SqlCommand("SELECT TOP 1 Hub FROM msHub WHERE id=@id", sqlcon)
    '    '                        cmdHub.Parameters.AddWithValue("@id", row("Hub").ToString())
    '    '                        Dim obj = cmdHub.ExecuteScalar()
    '    '                        If obj IsNot Nothing Then hubVal = obj.ToString()
    '    '                    End Using
    '    '                End If

    '    '                ' --- Lookup Status safely ---
    '    '                Dim idStatusTask As String = Nothing
    '    '                If row.Table.Columns.Contains("StatusPerbaikan") AndAlso Not IsDBNull(row("StatusPerbaikan")) Then
    '    '                    Using cmdStatus As New SqlCommand("SELECT TOP 1 id FROM msStatus WHERE Status=@status", sqlcon)
    '    '                        cmdStatus.Parameters.AddWithValue("@status", row("StatusPerbaikan").ToString())
    '    '                        Dim obj = cmdStatus.ExecuteScalar()
    '    '                        If obj IsNot Nothing Then idStatusTask = obj.ToString()
    '    '                    End Using
    '    '                End If

    '    '                ' --- Parse tanggal ---
    '    '                Dim tanggalTask As Object = DBNull.Value
    '    '                Dim tglMulai As Object = DBNull.Value
    '    '                Dim tglSelesai As Object = DBNull.Value
    '    '                Dim tglPulang As Object = DBNull.Value
    '    '                Dim tglStatus As Object = DBNull.Value
    '    '                Dim tmp As DateTime

    '    '                If row.Table.Columns.Contains("Tanggal") AndAlso Not IsDBNull(row("Tanggal")) AndAlso DateTime.TryParse(row("Tanggal").ToString(), tmp) Then
    '    '                    tanggalTask = tmp
    '    '                    tglMulai = tmp
    '    '                    tglStatus = tmp
    '    '                End If

    '    '                If row.Table.Columns.Contains("TglSelesai") AndAlso Not IsDBNull(row("TglSelesai")) AndAlso DateTime.TryParse(row("TglSelesai").ToString(), tmp) Then
    '    '                    tglSelesai = tmp
    '    '                End If

    '    '                If row.Table.Columns.Contains("TglPulang") AndAlso Not IsDBNull(row("TglPulang")) AndAlso DateTime.TryParse(row("TglPulang").ToString(), tmp) Then
    '    '                    tglPulang = tmp
    '    '                End If

    '    '                ' --- Tentukan jnsTask ---
    '    '                Dim taskStr As String = If(row.Table.Columns.Contains("Task") AndAlso Not IsDBNull(row("Task")), row("Task").ToString().Trim(), "")
    '    '                Dim jnsTask As String = If(taskStr.StartsWith("PM") OrElse taskStr.StartsWith("CM"), taskStr.Substring(0, 2), taskStr)

    '    '                ' --- Isi parameter trTask ---
    '    '                cmdInsertTrTask.Parameters("@NoTask").Value = notaskVal
    '    '                cmdInsertTrTask.Parameters("@TanggalTask").Value = If(tanggalTask Is Nothing, DBNull.Value, tanggalTask)
    '    '                cmdInsertTrTask.Parameters("@IdProject").Value = If(row.Table.Columns.Contains("IDProject") AndAlso Not IsDBNull(row("IDProject")), row("IDProject").ToString(), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@IdTeknisi").Value = If(row.Table.Columns.Contains("NIK") AndAlso Not IsDBNull(row("NIK")), row("NIK").ToString(), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@NamaTeknisi").Value = If(row.Table.Columns.Contains("NamaTeknisi") AndAlso Not IsDBNull(row("NamaTeknisi")), clsg.ReplacePetik(row("NamaTeknisi").ToString()), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@IdKoordinator").Value = If(row.Table.Columns.Contains("IDKoordinator") AndAlso Not IsDBNull(row("IDKoordinator")), row("IDKoordinator").ToString(), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@NamaKoordinator").Value = If(row.Table.Columns.Contains("NamaKoordinator") AndAlso Not IsDBNull(row("NamaKoordinator")), clsg.ReplacePetik(row("NamaKoordinator").ToString()), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@IdJenisTask").Value = jnsTask
    '    '                cmdInsertTrTask.Parameters("@IdProvinsi").Value = If(String.IsNullOrEmpty(IdProvinsi), DBNull.Value, IdProvinsi)
    '    '                cmdInsertTrTask.Parameters("@IdCity").Value = If(String.IsNullOrEmpty(IdCity), DBNull.Value, IdCity)
    '    '                cmdInsertTrTask.Parameters("@Provinsi").Value = If(String.IsNullOrEmpty(Provinsi), DBNull.Value, Provinsi)
    '    '                cmdInsertTrTask.Parameters("@City").Value = If(String.IsNullOrEmpty(kota), DBNull.Value, kota)
    '    '                cmdInsertTrTask.Parameters("@TglMulai").Value = If(tglMulai Is Nothing, DBNull.Value, tglMulai)
    '    '                cmdInsertTrTask.Parameters("@TglSelesai").Value = If(tglSelesai Is Nothing, DBNull.Value, tglSelesai)
    '    '                cmdInsertTrTask.Parameters("@TglStatusTask").Value = If(tglStatus Is Nothing, DBNull.Value, tglStatus)
    '    '                cmdInsertTrTask.Parameters("@IdStatusTask").Value = If(String.IsNullOrEmpty(idStatusTask), DBNull.Value, idStatusTask)
    '    '                cmdInsertTrTask.Parameters("@IdStatusKoordinator").Value = "Valid"
    '    '                cmdInsertTrTask.Parameters("@IdStatusManager").Value = "Valid"
    '    '                cmdInsertTrTask.Parameters("@TglStatusManager").Value = If(tglStatus Is Nothing, DBNull.Value, tglStatus)
    '    '                cmdInsertTrTask.Parameters("@IdUserManager").Value = If(row.Table.Columns.Contains("IdManager") AndAlso Not IsDBNull(row("IdManager")), row("IdManager").ToString(), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@NamaTask").Value = If(row.Table.Columns.Contains("NamaTask") AndAlso Not IsDBNull(row("NamaTask")), clsg.ReplacePetik(row("NamaTask").ToString()), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@DeskripsiPermasalahan").Value = jnsTask
    '    '                cmdInsertTrTask.Parameters("@NamaPelapor").Value = If(row.Table.Columns.Contains("NamaPIC") AndAlso Not IsDBNull(row("NamaPIC")), clsg.ReplacePetik(row("NamaPIC").ToString()), DBNull.Value)
    '    '                cmdInsertTrTask.Parameters("@TelpPelapor").Value = If(row.Table.Columns.Contains("TelpPIC") AndAlso Not IsDBNull(row("TelpPIC")), clsg.ReplacePetik(row("TelpPIC").ToString()), DBNull.Value)

    '    '                ' --- Eksekusi insert trTask ---
    '    '                cmdInsertTrTask.ExecuteNonQuery()

    '    '                ' --- Isi parameter trDetail_Task ---
    '    '                cmdInsertTrDetail.Parameters("@NoTask").Value = notaskVal
    '    '                cmdInsertTrDetail.Parameters("@VID").Value = vid
    '    '                cmdInsertTrDetail.Parameters("@IPLAN").Value = If(row.Table.Columns.Contains("IPLAN") AndAlso Not IsDBNull(row("IPLAN")), row("IPLAN").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@KANWIL").Value = If(String.IsNullOrEmpty(kanwil), DBNull.Value, kanwil)
    '    '                cmdInsertTrDetail.Parameters("@KANCAINDUK").Value = If(String.IsNullOrEmpty(KANCAINDUK), DBNull.Value, KANCAINDUK)
    '    '                cmdInsertTrDetail.Parameters("@NAMAREMOTE").Value = If(row.Table.Columns.Contains("NAMA REMOTE") AndAlso Not IsDBNull(row("NAMA REMOTE")), clsg.ReplacePetik(row("NAMA REMOTE").ToString()), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@ALAMAT").Value = If(String.IsNullOrEmpty(ALAMAT), DBNull.Value, ALAMAT)
    '    '                cmdInsertTrDetail.Parameters("@idProvinsi").Value = If(String.IsNullOrEmpty(IdProvinsi), DBNull.Value, IdProvinsi)
    '    '                cmdInsertTrDetail.Parameters("@PROVINSI").Value = If(String.IsNullOrEmpty(Provinsi), DBNull.Value, Provinsi)
    '    '                cmdInsertTrDetail.Parameters("@idCity").Value = If(String.IsNullOrEmpty(IdCity), DBNull.Value, IdCity)
    '    '                cmdInsertTrDetail.Parameters("@KOTA").Value = If(String.IsNullOrEmpty(kota), DBNull.Value, kota)
    '    '                cmdInsertTrDetail.Parameters("@IdJarkom").Value = If(row.Table.Columns.Contains("IDJarkom") AndAlso Not IsDBNull(row("IDJarkom")), row("IDJarkom").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@IdSatelite").Value = If(row.Table.Columns.Contains("IDSatelite") AndAlso Not IsDBNull(row("IDSatelite")), row("IDSatelite").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@idJenisTask").Value = jnsTask
    '    '                cmdInsertTrDetail.Parameters("@NoHpPic").Value = If(row.Table.Columns.Contains("TelpPIC") AndAlso Not IsDBNull(row("TelpPIC")), row("TelpPIC").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@PIC").Value = If(row.Table.Columns.Contains("NamaPIC") AndAlso Not IsDBNull(row("NamaPIC")), clsg.ReplacePetik(row("NamaPIC").ToString()), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@TglBerangkat").Value = If(tglMulai Is Nothing, DBNull.Value, tglMulai)
    '    '                cmdInsertTrDetail.Parameters("@TglSelesaiKerjaan").Value = If(tglSelesai Is Nothing, DBNull.Value, tglSelesai)
    '    '                cmdInsertTrDetail.Parameters("@TglPulang").Value = If(tglPulang Is Nothing, DBNull.Value, tglPulang)
    '    '                cmdInsertTrDetail.Parameters("@IdStatusPerbaikan").Value = If(String.IsNullOrEmpty(idStatusTask), 4, 1) ' 1=open, 4=other
    '    '                cmdInsertTrDetail.Parameters("@TglStatusPerbaikan").Value = If(tglStatus Is Nothing, DBNull.Value, tglStatus)
    '    '                cmdInsertTrDetail.Parameters("@UserStamp").Value = If(row.Table.Columns.Contains("IdManager") AndAlso Not IsDBNull(row("IdManager")), row("IdManager").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@HasilXPOLL").Value = If(row.Table.Columns.Contains("HasilXPoll") AndAlso Not IsDBNull(row("HasilXPoll")), row("HasilXPoll").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@CPI").Value = If(row.Table.Columns.Contains("CPI") AndAlso Not IsDBNull(row("CPI")), row("CPI").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@Hub").Value = If(String.IsNullOrEmpty(hubVal), DBNull.Value, hubVal)
    '    '                cmdInsertTrDetail.Parameters("@SQF").Value = If(row.Table.Columns.Contains("SQF") AndAlso Not IsDBNull(row("SQF")), row("SQF").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@INITIAL_ESNO").Value = If(row.Table.Columns.Contains("InisialESNO") AndAlso Not IsDBNull(row("InisialESNO")), row("InisialESNO").ToString(), DBNull.Value)
    '    '                cmdInsertTrDetail.Parameters("@FlagDataLokasi").Value = True
    '    '                cmdInsertTrDetail.Parameters("@FlagGeneralInfo").Value = True
    '    '                cmdInsertTrDetail.Parameters("@FlagDataTeknis").Value = False
    '    '                cmdInsertTrDetail.Parameters("@FlagDataBarang").Value = False
    '    '                cmdInsertTrDetail.Parameters("@FlagUploadPhoto").Value = False
    '    '                cmdInsertTrDetail.Parameters("@FlagDataInstallasi").Value = False
    '    '                cmdInsertTrDetail.Parameters("@FlagDataSurvey").Value = False

    '    '                ' --- Eksekusi insert trDetail_Task ---
    '    '                cmdInsertTrDetail.ExecuteNonQuery()

    '    '            Catch exRow As Exception
    '    '                ' Log detail error per row
    '    '                clsg.writedata("System", "Upload", "Excel", $"Sheet={NamaSheet}, NoTask={notaskVal}, VID={vid}", exRow.Message)
    '    '                Continue For
    '    '            End Try
    '    '        Next

    '    '    End Using

    '    'Catch ex As Exception
    '    '    clsg.writedata("System", "Upload", "Excel", $"Sheet={NamaSheet}", ex.Message)
    '    '    Dim msg As String = "Gagal insert database trRemoteSite:" & vbCrLf & ex.Message
    '    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DataUpload",
    '    '    "alert('" & msg.Replace("'", "\'").Replace(vbCrLf, "\n") & "');", True)
    '    'Finally
    '    '    If sqlcon.State = ConnectionState.Open Then sqlcon.Close()
    '    'End Try
    'End Sub


    'Private Sub DataUpload_TaskGeneral(NamaSheet As String)
    '    Try
    '        Dim getalldata As String = ""

    '        'sheetname = Replace(sheetname, "$", "")
    '        comexcel = New OleDbDataAdapter("select * from [" & NamaSheet & "] where vid is not null", constr)
    '        dataset = New DataSet()
    '        comexcel.Fill(dataset)

    '        dtlexcel = dataset.Tables(0)
    '        If dtlexcel.Rows.Count <> 0 Then
    '            For i = 0 To dtlexcel.Rows.Count - 1
    '                'Cari NoTask
    '                strsql = "select top 1 * from trTask order by notask desc"
    '                tbldata_Notask = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_Notask.Rows.Count = 0 Then
    '                    notask = "100001"
    '                ElseIf IsNothing(tbldata_Notask) = False Then
    '                    notask = tbldata_Notask.Rows(0).Item("NoTask") + 1
    '                Else
    '                    notask = "100001"
    '                End If

    '                'Cari data di TrRemoteSite
    '                strsql = "SELECT top 1 * FROM trRemoteSite " &
    '                "WHERE (vid = '" & dtlexcel.Rows(i).Item("vid") & "')"
    '                tbldata_Wilayah = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_Wilayah.Rows.Count = 0 Then
    '                    IdProvinsi = Nothing
    '                    Provinsi = Nothing
    '                    IdCity = Nothing
    '                    kota = Nothing
    '                    kanwil = Nothing
    '                    KANCAINDUK = Nothing
    '                    ALAMAT = Nothing
    '                ElseIf IsNothing(tbldata_Wilayah) = False Then
    '                    IdProvinsi = tbldata_Wilayah.Rows(0).Item("idProvinsi").ToString
    '                    Provinsi = tbldata_Wilayah.Rows(0).Item("PROVINSI").ToString
    '                    IdCity = tbldata_Wilayah.Rows(0).Item("idCity").ToString
    '                    kota = tbldata_Wilayah.Rows(0).Item("KOTA").ToString
    '                    kanwil = tbldata_Wilayah.Rows(0).Item("KANWIL").ToString
    '                    KANCAINDUK = tbldata_Wilayah.Rows(0).Item("KANCAINDUK").ToString
    '                    ALAMAT = tbldata_Wilayah.Rows(0).Item("AlamatInstall").ToString
    '                Else
    '                    IdProvinsi = Nothing
    '                    Provinsi = Nothing
    '                    IdCity = Nothing
    '                    kota = Nothing
    '                    kanwil = Nothing
    '                    KANCAINDUK = Nothing
    '                    ALAMAT = Nothing
    '                End If

    '                'Cari Hub
    '                If IsDBNull(dtlexcel.Rows(i).Item("Hub")) = True Then
    '                    hub = Nothing
    '                ElseIf dtlexcel.Rows(i).Item("Hub") = "" Or dtlexcel.Rows(i).Item("Hub") = Nothing Then
    '                    hub = Nothing
    '                Else
    '                    strsql = "select * from mshub where id='" & dtlexcel.Rows(i).Item("Hub") & "'"
    '                    tbldata_hub = clsg.ExecuteQuery(strsql)
    '                    If Session("Error") <> Nothing Then Exit Sub
    '                    If tbldata_hub.Rows.Count = 0 Then
    '                        hub = Nothing
    '                    ElseIf IsNothing(tbldata_hub) = False Then
    '                        hub = tbldata_hub.Rows(0).Item("Hub").ToString
    '                    Else
    '                        hub = Nothing
    '                    End If
    '                End If

    '                If dtlexcel.Rows(i).Item("task").substring(0, 2) = "PM" Then
    '                    jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
    '                ElseIf dtlexcel.Rows(i).Item("task").substring(0, 2) = "CM" Then
    '                    jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
    '                Else
    '                    jnsTask = dtlexcel.Rows(i).Item("task").ToString
    '                End If

    '                'Cari Id Status Task
    '                strsql = "select id,Status from msStatus where Status='" & dtlexcel.Rows(i).Item("StatusPerbaikan") & "'"
    '                tbldata_IdStatusTask = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_IdStatusTask.Rows.Count = 0 Then
    '                    IdStatusTask = Nothing
    '                ElseIf IsNothing(tbldata_IdStatusTask) = False Then
    '                    IdStatusTask = tbldata_IdStatusTask.Rows(0).Item("id").ToString
    '                Else
    '                    IdStatusTask = Nothing
    '                End If

    '                If dtlexcel.Rows(i).Item("StatusPerbaikan") = "Open" And dtlexcel.Rows(i).Item("StatusTask") = "Open" Then
    '                    'insert ke trtask
    '                    strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask,IdProvinsi," &
    '                        "IdCity,Provinsi,City,TglMulai,TglSelesai,TglStatusTask,IdStatusTask,IdStatusKoordinator,IdStatusManager,TglStatusManager,IdUserManager," &
    '                        "DateStamp,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " &
    '                        "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
    '                        dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," &
    '                        "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," &
    '                        "'" & dtlexcel.Rows(i).Item("Tanggal") & "',null,'" & dtlexcel.Rows(i).Item("Tanggal") & "'," &
    '                        "'1','Valid','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IdManager") & "',getdate(),getdate()," &
    '                        "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTask")) & "','" & jnsTask & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
    '                    clsg.ExecuteNonQuery(strsql)

    '                    'insert ke trdetail_task
    '                    strsql = "insert into trDetail_Task(NoTask, VID,IPLAN,KANWIL,KANCAINDUK,NAMAREMOTE,ALAMAT,idProvinsi, PROVINSI, idCity, KOTA, IdJarkom, IdSatelite, idJenisTask,NoHpPic,PIC, " &
    '                     "TglBerangkat, TglSelesaiKerjaan, TglPulang, IdStatusPerbaikan, TglStatusPerbaikan,UserStamp, DateStamp,HasilXPOLL, CPI, Hub,SQF, INITIAL_ESNO, " &
    '                     "FlagDataLokasi, FlagGeneralInfo, FlagDataTeknis, FlagDataBarang, FlagUploadPhoto, FlagDataInstallasi, FlagDataSurvey) values " &
    '                     "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " &
    '                     "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," &
    '                     "'" & dtlexcel.Rows(i).Item("TglBerangkat") & "', '" & dtlexcel.Rows(i).Item("TglSelesai") & "', '" & dtlexcel.Rows(i).Item("TglPulang") & "', 1, '" & dtlexcel.Rows(i).Item("TglStatus") & "','" & dtlexcel.Rows(i).Item("IdManager") & "'," &
    '                     "getdate(),'" & dtlexcel.Rows(i).Item("HasilXPoll") & "', '" & dtlexcel.Rows(i).Item("CPI") & "', '" & hub & "','" & dtlexcel.Rows(i).Item("SQF") & "', '" & dtlexcel.Rows(i).Item("InisialESNO") & "'," &
    '                     "1, 1, 0, 0, 0, 0, 0)"
    '                    clsg.ExecuteNonQuery(strsql)
    '                Else
    '                    'insert ke trtask
    '                    strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask,IdProvinsi," &
    '                        "IdCity,Provinsi,City,TglMulai,TglSelesai,TglStatusTask,IdStatusTask,IdStatusKoordinator,IdStatusManager,TglStatusManager,IdUserManager," &
    '                        "DateStamp,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " &
    '                        "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
    '                        dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," &
    '                        "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," &
    '                        "'" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("TglSelesai") & "','" & dtlexcel.Rows(i).Item("Tanggal") & "'," &
    '                        "'" & IdStatusTask & "','Valid','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IdManager") & "',getdate(),getdate()," &
    '                        "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTask")) & "','" & jnsTask & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
    '                    clsg.ExecuteNonQuery(strsql)

    '                    'insert ke trdetail_task
    '                    strsql = "insert into trDetail_Task(NoTask, VID,IPLAN,KANWIL,KANCAINDUK,NAMAREMOTE,ALAMAT,idProvinsi, PROVINSI, idCity, KOTA, IdJarkom, IdSatelite, idJenisTask,NoHpPic,PIC, " &
    '                     "TglBerangkat, TglSelesaiKerjaan, TglPulang, IdStatusPerbaikan, TglStatusPerbaikan,UserStamp, DateStamp,HasilXPOLL, CPI, Hub,SQF, INITIAL_ESNO, " &
    '                     "FlagDataLokasi, FlagGeneralInfo, FlagDataTeknis, FlagDataBarang, FlagUploadPhoto, FlagDataInstallasi, FlagDataSurvey) values " &
    '                     "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " &
    '                     "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," &
    '                     "'" & dtlexcel.Rows(i).Item("TglBerangkat") & "', '" & dtlexcel.Rows(i).Item("TglSelesai") & "', '" & dtlexcel.Rows(i).Item("TglPulang") & "', 4, '" & dtlexcel.Rows(i).Item("TglStatus") & "','" & dtlexcel.Rows(i).Item("IdManager") & "'," &
    '                     "getdate(),'" & dtlexcel.Rows(i).Item("HasilXPoll") & "', '" & dtlexcel.Rows(i).Item("CPI") & "', '" & hub & "','" & dtlexcel.Rows(i).Item("SQF") & "', '" & dtlexcel.Rows(i).Item("InisialESNO") & "'," &
    '                     "1, 1, 1, 1, 1, 1, 1)"
    '                    clsg.ExecuteNonQuery(strsql)
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        clsg.writedata("System", "Uplaod", "Excel", NamaSheet & " | " & strsql, ex.Message)
    '        Dim msg As String = "Gagal insert database trRemoteSite:" & vbCrLf &
    '                ex.Message & vbCrLf &
    '                "Query: " & strsql

    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "DataUpload",
    '"alert('" & msg.Replace("'", "\'").Replace(vbCrLf, "\n") & "');", True)

    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub DataUpload_TaskInstalasi(NamaSheet As String)
    '    Try
    '        Dim getalldata As String = ""

    '        'sheetname = Replace(sheetname, "$", "")
    '        comexcel = New OleDbDataAdapter("select * from [" & NamaSheet & "] where vid is not null", constr)
    '        dataset = New DataSet()
    '        comexcel.Fill(dataset)

    '        dtlexcel = dataset.Tables(0)
    '        If dtlexcel.Rows.Count <> 0 Then
    '            For i = 0 To dtlexcel.Rows.Count - 1
    '                'Cari NoTask
    '                strsql = "select top 1 * from trTask order by notask desc"
    '                tbldata_Notask = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_Notask.Rows.Count = 0 Then
    '                    notask = "100001"
    '                ElseIf IsNothing(tbldata_Notask) = False Then
    '                    notask = tbldata_Notask.Rows(0).Item("NoTask") + 1
    '                Else
    '                    notask = "100001"
    '                End If

    '                'Cari data di TrRemoteSite
    '                strsql = "SELECT top 1 * FROM trRemoteSite " & _
    '                "WHERE (vid = '" & dtlexcel.Rows(i).Item("vid") & "')"
    '                tbldata_Wilayah = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_Wilayah.Rows.Count = 0 Then
    '                    IdProvinsi = Nothing
    '                    Provinsi = Nothing
    '                    IdCity = Nothing
    '                    kota = Nothing
    '                    kanwil = Nothing
    '                    KANCAINDUK = Nothing
    '                    ALAMAT = Nothing
    '                ElseIf IsNothing(tbldata_Wilayah) = False Then
    '                    IdProvinsi = tbldata_Wilayah.Rows(0).Item("idProvinsi").ToString
    '                    Provinsi = tbldata_Wilayah.Rows(0).Item("PROVINSI").ToString
    '                    IdCity = tbldata_Wilayah.Rows(0).Item("idCity").ToString
    '                    kota = tbldata_Wilayah.Rows(0).Item("KOTA").ToString
    '                    kanwil = tbldata_Wilayah.Rows(0).Item("KANWIL").ToString
    '                    KANCAINDUK = tbldata_Wilayah.Rows(0).Item("KANCAINDUK").ToString
    '                    ALAMAT = tbldata_Wilayah.Rows(0).Item("AlamatInstall").ToString
    '                Else
    '                    IdProvinsi = Nothing
    '                    Provinsi = Nothing
    '                    IdCity = Nothing
    '                    kota = Nothing
    '                    kanwil = Nothing
    '                    KANCAINDUK = Nothing
    '                    ALAMAT = Nothing
    '                End If

    '                'Cari Hub
    '                strsql = "select * from mshub where id='" & dtlexcel.Rows(i).Item("Hub") & "'"
    '                tbldata_hub = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_hub.Rows.Count = 0 Then
    '                    hub = Nothing
    '                ElseIf IsNothing(tbldata_hub) = False Then
    '                    hub = tbldata_hub.Rows(0).Item("Hub").ToString
    '                Else
    '                    hub = Nothing
    '                End If

    '                If dtlexcel.Rows(i).Item("task").substring(0, 2) = "PM" Then
    '                    jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
    '                ElseIf dtlexcel.Rows(i).Item("task").substring(0, 2) = "CM" Then
    '                    jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
    '                Else
    '                    If dtlexcel.Rows(i).Item("task").ToString = "Instalasi" Then
    '                        jnsTask = "Installation"
    '                    Else
    '                        jnsTask = dtlexcel.Rows(i).Item("task").ToString
    '                    End If
    '                End If

    '                'Cari Id Status Task
    '                strsql = "select id,Status from msStatus where Status='" & dtlexcel.Rows(i).Item("StatusPerbaikan") & "'"
    '                tbldata_IdStatusTask = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_IdStatusTask.Rows.Count = 0 Then
    '                    IdStatusTask = Nothing
    '                ElseIf IsNothing(tbldata_IdStatusTask) = False Then
    '                    IdStatusTask = tbldata_IdStatusTask.Rows(0).Item("id").ToString
    '                Else
    '                    IdStatusTask = Nothing
    '                End If

    '                'insert ke trtask
    '                strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask," & _
    '                    "IdProvinsi,IdCity,Provinsi,City,TglMulai,TglSelesai,IdStatusTask,TglStatusTask,IdStatusKoordinator,TglStatusKoordinator" & _
    '                    ",CatatanKoordinator,IdUserKoordinator,IdStatusManager,TglStatusManager,CatatanManager,IdUserManager,UserStamp,DateStamp," & _
    '                    "VID,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " & _
    '                    "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
    '                    dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," & _
    '                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," & _
    '                    "'" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("TglSelesai") & "',4,'" & dtlexcel.Rows(i).Item("Tanggal") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "'" & _
    '                    ",'" & jnsTask & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & jnsTask & "','" & dtlexcel.Rows(i).Item("IdManager") & "'" & _
    '                    ",'" & Session("UserName") & "',getdate(),'" & dtlexcel.Rows(i).Item("VID") & "',getdate(),'" & dtlexcel.Rows(i).Item("NamaTask") & "','" & jnsTask & "'" & _
    '                    ",'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
    '                clsg.ExecuteNonQuery(strsql)

    '                'insert ke trdetail_task
    '                strsql = "insert into trDetail_Task(NoTask,VID,SID,IPLAN,KANWIL,KANCAINDUK,NAMAREMOTE,ALAMAT,idProvinsi,PROVINSI,idCity,KOTA,IdJarkom,IdSatelite,idJenisTask,NoHpPic,PIC,SQF,INITIAL_ESNO," & _
    '                "UPSforBackup,TypeMounting,PanjangKabel,AktifitasSolusi,TglBerangkat,TglSelesaiKerjaan,TglPulang,IdStatusPerbaikan,TglStatusPerbaikan," & _
    '                "UserStamp,DateStamp,CARRIER_TO_NOICE,CPI,Hub,Latitude,Longitude,DiameterAntena,SourceListrik,IPLAN1,IPLAN2,FlagDataLokasi,FlagGeneralInfo,FlagDataTeknis," & _
    '                "FlagDataBarang,FlagUploadPhoto,FlagDataInstallasi,FlagDataSurvey) values " & _
    '                "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("SID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " & _
    '                "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," & _
    '                "'" & dtlexcel.Rows(i).Item("SQF") & "', '" & dtlexcel.Rows(i).Item("INTIALESNO") & "', '" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("UPSForBackUp")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Mounting")) & "', '" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("PanjangKabel")) & "'," & _
    '                "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("AktivitasSolusi")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglBerangkat")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglSelesai")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglPulang")) & "','" & IdStatusTask & "', " & _
    '                "'" & dtlexcel.Rows(i).Item("TglStatus") & "','" & Session("UserName") & "',getdate(), '" & dtlexcel.Rows(i).Item("CToN") & "', '" & dtlexcel.Rows(i).Item("CPI") & "', '" & hub & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Latitude")) & "', '" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Longitude")) & "'," & _
    '                "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("UkuranAntena")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("SourceListrik")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("LAN1-IPAdrress")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("LAN2-IPAdrress")) & "',1, 1, 1, 1, 1, 1, 1)"
    '                clsg.ExecuteNonQuery(strsql)
    '            Next
    '        End If
    '    Catch ex As Exception
    '        clsg.writedata("System", "Uplaod", "Excel", NamaSheet & " | " & strsql, ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub
    'Private Sub DataUpload_TaskSurvey(NamaSheet As String)
    '    Try
    '        Dim getalldata As String = ""

    '        'sheetname = Replace(sheetname, "$", "")
    '        comexcel = New OleDbDataAdapter("select * from [" & NamaSheet & "] where vid is not null", constr)
    '        dataset = New DataSet()
    '        comexcel.Fill(dataset)

    '        dtlexcel = dataset.Tables(0)
    '        If dtlexcel.Rows.Count <> 0 Then
    '            For i = 0 To dtlexcel.Rows.Count - 1
    '                'Cari NoTask
    '                strsql = "select top 1 * from trTask order by notask desc"
    '                tbldata_Notask = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_Notask.Rows.Count = 0 Then
    '                    notask = "100001"
    '                ElseIf IsNothing(tbldata_Notask) = False Then
    '                    notask = tbldata_Notask.Rows(0).Item("NoTask") + 1
    '                Else
    '                    notask = "100001"
    '                End If

    '                'Cari data di TrRemoteSite
    '                strsql = "SELECT top 1 * FROM trRemoteSite " & _
    '                "WHERE (vid = '" & dtlexcel.Rows(i).Item("vid") & "')"
    '                tbldata_Wilayah = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_Wilayah.Rows.Count = 0 Then
    '                    IdProvinsi = Nothing
    '                    Provinsi = Nothing
    '                    IdCity = Nothing
    '                    kota = Nothing
    '                    kanwil = Nothing
    '                    KANCAINDUK = Nothing
    '                    ALAMAT = Nothing
    '                ElseIf IsNothing(tbldata_Wilayah) = False Then
    '                    IdProvinsi = tbldata_Wilayah.Rows(0).Item("idProvinsi").ToString
    '                    Provinsi = tbldata_Wilayah.Rows(0).Item("PROVINSI").ToString
    '                    IdCity = tbldata_Wilayah.Rows(0).Item("idCity").ToString
    '                    kota = tbldata_Wilayah.Rows(0).Item("KOTA").ToString
    '                    kanwil = tbldata_Wilayah.Rows(0).Item("KANWIL").ToString
    '                    KANCAINDUK = tbldata_Wilayah.Rows(0).Item("KANCAINDUK").ToString
    '                    ALAMAT = tbldata_Wilayah.Rows(0).Item("AlamatInstall").ToString
    '                Else
    '                    IdProvinsi = Nothing
    '                    Provinsi = Nothing
    '                    IdCity = Nothing
    '                    kota = Nothing
    '                    kanwil = Nothing
    '                    KANCAINDUK = Nothing
    '                    ALAMAT = Nothing
    '                End If

    '                'Cari Hub
    '                strsql = "select * from mshub where id='" & dtlexcel.Rows(i).Item("Hub") & "'"
    '                tbldata_hub = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_hub.Rows.Count = 0 Then
    '                    hub = Nothing
    '                ElseIf IsNothing(tbldata_hub) = False Then
    '                    hub = tbldata_hub.Rows(0).Item("Hub").ToString
    '                Else
    '                    hub = Nothing
    '                End If

    '                If dtlexcel.Rows(i).Item("task").substring(0, 2) = "PM" Then
    '                    jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
    '                ElseIf dtlexcel.Rows(i).Item("task").substring(0, 2) = "CM" Then
    '                    jnsTask = dtlexcel.Rows(i).Item("task").substring(0, 2)
    '                Else
    '                    If dtlexcel.Rows(i).Item("task").ToString = "Instalasi" Then
    '                        jnsTask = "Installation"
    '                    Else
    '                        jnsTask = dtlexcel.Rows(i).Item("task").ToString
    '                    End If
    '                End If

    '                'Cari Id Status Task
    '                strsql = "select id,Status from msStatus where Status='" & dtlexcel.Rows(i).Item("StatusPerbaikan") & "'"
    '                tbldata_IdStatusTask = clsg.ExecuteQuery(strsql)
    '                If Session("Error") <> Nothing Then Exit Sub
    '                If tbldata_IdStatusTask.Rows.Count = 0 Then
    '                    IdStatusTask = Nothing
    '                ElseIf IsNothing(tbldata_IdStatusTask) = False Then
    '                    IdStatusTask = tbldata_IdStatusTask.Rows(0).Item("id").ToString
    '                Else
    '                    IdStatusTask = Nothing
    '                End If

    '                'insert ke trtask
    '                strsql = "insert into trTask(NoTask,TanggalTask,IdProject,IdTeknisi,NamaTeknisi,IdKoordinator,NamaKoordinator,IdJenisTask," & _
    '                    "IdProvinsi,IdCity,Provinsi,City,TglMulai,TglSelesai,IdStatusTask,TglStatusTask,IdStatusKoordinator,TglStatusKoordinator" & _
    '                    ",CatatanKoordinator,IdUserKoordinator,IdStatusManager,TglStatusManager,CatatanManager,IdUserManager,UserStamp,DateStamp," & _
    '                    "VID,tglentrytaskcoor,NamaTask,DeskripsiPermasalahan, NamaPelapor, TelpPelapor) values " & _
    '                    "('" & notask & "','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("IDProject") & "','" &
    '                    dtlexcel.Rows(i).Item("NIK") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaTeknisi")) & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "'," & _
    '                    "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaKoordinator")) & "','" & jnsTask & "','" & IdProvinsi & "','" & IdCity & "','" & Provinsi & "','" & kota & "'," & _
    '                    "'" & dtlexcel.Rows(i).Item("Tanggal") & "','" & dtlexcel.Rows(i).Item("TglSelesai") & "',4,'" & dtlexcel.Rows(i).Item("Tanggal") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "'" & _
    '                    ",'" & jnsTask & "','" & dtlexcel.Rows(i).Item("IDKoordinator") & "','Valid','" & dtlexcel.Rows(i).Item("Tanggal") & "','" & jnsTask & "','" & dtlexcel.Rows(i).Item("IdManager") & "'" & _
    '                    ",'" & Session("UserName") & "',getdate(),'" & dtlexcel.Rows(i).Item("VID") & "',getdate(),'" & dtlexcel.Rows(i).Item("NamaTask") & "','" & jnsTask & "'" & _
    '                    ",'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "')"
    '                clsg.ExecuteNonQuery(strsql)

    '                'insert ke trdetail_task
    '                strsql = "insert into trDetail_Task(NoTask, VID, IPLAN, KANWIL, KANCAINDUK, NAMAREMOTE, ALAMAT, idProvinsi, PROVINSI, idCity, " & _
    '                    "KOTA, IdJarkom, IdSatelite, idJenisTask, NoHpPic, PIC, TglBerangkat, TglSelesaiKerjaan, " & _
    '                    "TglPulang, IdStatusPerbaikan, TglStatusPerbaikan, AlamatPengirimanSurvey, TempatPenyimpananSurvey, NamaPICSurvey, KontakPICSurvey, " & _
    '                    "UkuranAntenaSurvey, TempatAntenaSurvey, KekuatanRoofSurvey, JenisMountingSurvey, LatitudeSurvey, LongitudeSurvey, " & _
    '                    "ListrikAwalSurvey, SarpenACIndoorSurvey, PanjangKabelSurvey, TypeKabelSurvey, ArahAntenaSurvey, KeteranganSurvey, StatusHasilSurvey, " & _
    '                    "UserStamp, DateStamp, FlagDataLokasi, FlagGeneralInfo, FlagDataTeknis, FlagDataBarang, FlagUploadPhoto, FlagDataInstallasi, FlagDataSurvey) values " & _
    '                "('" & notask & "', '" & dtlexcel.Rows(i).Item("VID") & "','" & dtlexcel.Rows(i).Item("IPLAN") & "','" & kanwil & "','" & KANCAINDUK & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NAMA REMOTE")) & "','" & ALAMAT & "','" & IdProvinsi & "', " & _
    '                "'" & Provinsi & "', '" & IdCity & "', '" & kota & "', '" & dtlexcel.Rows(i).Item("IDJarkom") & "', '" & dtlexcel.Rows(i).Item("IDSatelite") & "', '" & jnsTask & "','" & dtlexcel.Rows(i).Item("TelpPIC") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," & _
    '                "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglBerangkat")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglSelesai")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TglPulang")) & "','" & IdStatusTask & "'," & _
    '                "'" & dtlexcel.Rows(i).Item("TglStatus") & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("AlamatPengiriman")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TempatPenyimpanan")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("NamaPIC")) & "'," & _
    '                "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TelpPIC")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("UkuranAntena")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TempatAntena")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("KekuatanRoofTop")) & "'," & _
    '                "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Mounting")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Latitude")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Longitude")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("PengukuranListrikAwal")) & "'," & _
    '                "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("ACIndoor")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("PanjangKabel")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("TypeKabel")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("ArahAntena")) & "'," & _
    '                "'" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("Keterangan")) & "','" & clsg.ReplacePetik(dtlexcel.Rows(i).Item("StatusHasilSurvey")) & "','" & Session("UserName") & "',getdate(),1,1,1,1,1,1,1)"
    '                clsg.ExecuteNonQuery(strsql)
    '            Next
    '        End If
    '    Catch ex As Exception
    '        clsg.writedata("System", "Uplaod", "Excel", NamaSheet & " | " & strsql, ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

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
