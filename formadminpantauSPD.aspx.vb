Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Bootstrap
Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports DevExpress.Web.ASPxEdit
Partial Class formadminpantauSPD
    Inherits System.Web.UI.Page
    Dim clsg As New cls_global

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        Session("NamaForm") = IO.Path.GetFileName(Request.Path)

        If IsNothing(Session("filter")) Then
            If Request.QueryString("status") = "DONE" Then
                Dim getNoReferensi As String = replaceParty(Request.QueryString("NoReferensi"))

                dspantauspd.SelectParameters.Clear()

                If getNoReferensi <> "" Then
                    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
                                                "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
                                                "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
                                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, ISNULL(trDetail_permintaanSPD.fileTransf_url, '') AS fileTransf_url " &
                                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD " &
                                                "ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask " &
                                                "WHERE trDetail_permintaanSPD.NoReferensi = @NoReferensi " &
                                                "ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"

                    dspantauspd.SelectParameters.Add(New Parameter("NoReferensi", TypeCode.String, getNoReferensi))

                Else
                    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
                                                "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
                                                "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
                                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, ISNULL(trDetail_permintaanSPD.fileTransf_url, '') AS fileTransf_url " &
                                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD " &
                                                "ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask WHERE 1=0"
                End If

                'Dim getNoReferensi As String = replaceParty(Request.QueryString("NoReferensi"))

                'If getNoReferensi <> "" Then
                '    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
                '                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
                '                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where NoReferensi= " & getNoReferensi & " order by trDetail_permintaanSPD.tglpengajuan desc"

                '    If IsNumeric(getNoReferensi) AndAlso CLng(getNoReferensi) <= Integer.MaxValue Then
                '        dspantauspd.SelectParameters.Add(New Parameter("NoReferensi", TypeCode.Int32, getNoReferensi))
                '    Else
                '        dspantauspd.SelectParameters.Add(New Parameter("NoReferensi", TypeCode.String, getNoReferensi))
                '    End If

                'Else
                '    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
                '                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
                '                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask WHERE 1=0"
                'End If
                searchSPD.Visible = False
            ElseIf Request.QueryString("status") = "PENDING" Then
                Dim getNoReferensi As String = replaceParty(Request.QueryString("NoReferensi"))

                dspantauspd.SelectParameters.Clear()

                If getNoReferensi <> "" Then
                    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
                                                "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
                                                "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
                                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, ISNULL(trDetail_permintaanSPD.fileTransf_url, '') AS fileTransf_url " &
                                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD " &
                                                "ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask " &
                                                "WHERE trDetail_permintaanSPD.NoReferensi = @NoReferensi " &
                                                "ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"

                    dspantauspd.SelectParameters.Add(New Parameter("NoReferensi", TypeCode.String, getNoReferensi))
                    searchSPD.Visible = False

                Else
                    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
                                                "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
                                                "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
                                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, ISNULL(trDetail_permintaanSPD.fileTransf_url, '') AS fileTransf_url " &
                                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD " &
                                                "ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask " &
                                                "WHERE trDetail_permintaanSPD.statustrf='PENDING'"
                    searchSPD.Visible = False
                End If
                searchSPD.Visible = False
            ElseIf Request.QueryString("status") = "Open" Then
                Dim getNoReferensi As String = replaceParty(Request.QueryString("NoReferensi"))

                dspantauspd.SelectParameters.Clear()

                If getNoReferensi <> "" Then
                    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
                                                "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
                                                "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
                                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, ISNULL(trDetail_permintaanSPD.fileTransf_url, '') AS fileTransf_url " &
                                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD " &
                                                "ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask " &
                                                "WHERE trDetail_permintaanSPD.NoReferensi = @NoReferensi " &
                                                "ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"

                    dspantauspd.SelectParameters.Add(New Parameter("NoReferensi", TypeCode.String, getNoReferensi))

                Else
                    dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
                                                "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
                                                "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
                                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, ISNULL(trDetail_permintaanSPD.fileTransf_url, '') AS fileTransf_url " &
                                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD " &
                                                "ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask " &
                                                "WHERE trDetail_permintaanSPD.statustrf='Open'"
                End If
                searchSPD.Visible = False
            Else
                dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
                                                "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
                                                "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
                                                "TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
                                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, ISNULL(trDetail_permintaanSPD.fileTransf_url, '') AS fileTransf_url " &
                                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD " &
                                                "ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask " &
                                                "WHERE TRY_CONVERT(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) <> 0 " &
                                                "ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"

            End If

        Else
            dspantauspd.SelectCommand = Session("filter")
        End If
        gridpantauSPD.DataBind()
    End Sub

    Public Function replaceParty(ByVal str2 As String) As String
        Dim TmpStr As String = str2

        ' Ganti karakter dengan spasi
        TmpStr = Replace(TmpStr, """", "")
        TmpStr = Replace(TmpStr, "'", "")
        'TmpStr = Replace(TmpStr, ";", " ")

        Return TmpStr
    End Function
    Protected Sub gridpantauSPD_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridpantauSPD.RowDeleting

    End Sub

    'Protected Sub gridpantauSPD_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridpantauSPD.RowUpdating
    '    Try
    '        '=== Ambil kontrol upload dari row yang sedang di-edit ===
    '        Dim upload As DevExpress.Web.ASPxUploadControl =
    '        TryCast(gridpantauSPD.FindEditRowCellTemplateControl(
    '            gridpantauSPD.Columns("fileTransf_url"), "UploadBukti"),
    '        DevExpress.Web.ASPxUploadControl)

    '        '=== Jika ada file baru diupload ===
    '        If Session("UploadedPath") IsNot Nothing Then
    '            e.NewValues("fileTransf_url") = Session("UploadedPath").ToString()
    '            Session.Remove("UploadedPath")
    '        Else
    '            e.NewValues("fileTransf_url") = e.OldValues("fileTransf_url")
    '        End If

    '        System.Diagnostics.Debug.WriteLine("=== Nilai fileTransf_url baru: " & e.NewValues("fileTransf_url").ToString())
    '        '=== UpdateCommand (pastikan sesuai field di database) ===
    '        'dspantauspd.UpdateCommand =
    '        '"UPDATE trDetail_permintaanSPD " &
    '        '"SET jumlahtrf = @jumlahtrf, " &
    '        '"    tgltrf = @tgltrf, " &
    '        '"    NoReferensi = @NoReferensi, " &
    '        '"    statustrf = @statustrf, " &
    '        '"    notekeuangan = @notekeuangan, " &
    '        '"    fileTransf_url = @fileTransf_url " &
    '        '"WHERE idtbl = @idtbl"

    '        Using conn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    '            conn.Open()
    '            Using cmd As New SqlClient.SqlCommand("UPDATE trDetail_permintaanSPD SET jumlahtrf = @jumlahtrf, tgltrf = @tgltrf, NoReferensi = @NoReferensi,statustrf = @statustrf,notekeuangan = @notekeuangan,fileTransf_url = @fileTransf_url WHERE idtbl = @idtbl", conn)

    '                cmd.Parameters.AddWithValue("@jumlahtrf", e.NewValues("jumlahtrf"))
    '                cmd.Parameters.AddWithValue("@tgltrf", e.NewValues("tgltrf"))
    '                cmd.Parameters.AddWithValue("@NoReferensi", e.NewValues("NoReferensi"))
    '                cmd.Parameters.AddWithValue("@statustrf", e.NewValues("statustrf"))
    '                cmd.Parameters.AddWithValue("@notekeuangan", e.NewValues("notekeuangan"))
    '                cmd.Parameters.AddWithValue("@fileTransf_url", e.NewValues("fileTransf_url"))
    '                cmd.Parameters.AddWithValue("@idtbl", e.Keys("idtbl"))
    '                cmd.ExecuteNonQuery()
    '            End Using
    '        End Using

    '        e.Cancel = True
    '        gridpantauSPD.CancelEdit()
    '        gridpantauSPD.DataBind()

    '    Catch ex As Exception
    '        Throw New Exception("Gagal upload file bukti transfer: " & ex.Message)
    '    End Try
    'End Sub

    Protected Sub gridpantauSPD_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridpantauSPD.RowUpdating
        Try
            Dim newFileUrl As String = Nothing

            ' 🔹 Cara baru: cari kolom dengan Caption atau Index, bukan FieldName
            Dim upload As DevExpress.Web.ASPxUploadControl =
            TryCast(gridpantauSPD.FindEditFormTemplateControl("UploadBukti"),
            DevExpress.Web.ASPxUploadControl)

            '=== Jika user upload file baru ===
            If upload IsNot Nothing AndAlso upload.UploadedFiles.Count > 0 Then
                Dim ufile = upload.UploadedFiles(0)
                Dim folderPath As String = Server.MapPath("~/UploadFoto/")
                If Not IO.Directory.Exists(folderPath) Then IO.Directory.CreateDirectory(folderPath)

                Dim fileName As String = DateTime.Now.ToString("yyyyMMddHHmmss") & "_" & IO.Path.GetFileName(ufile.FileName)
                Dim savePath As String = IO.Path.Combine(folderPath, fileName)

                ufile.SaveAs(savePath)
                newFileUrl = "UploadFoto/" & fileName
            Else
                '=== Tidak ada upload baru → ambil dari DB === newFileUrl=Nothing
                Dim idtbl As Integer = Convert.ToInt32(e.Keys("idtbl"))
                newFileUrl = GetOldFileUrlFromDatabase(idtbl)
            End If

            ' Ambil hidden field dari EditForm
            Dim hidden As DevExpress.Web.ASPxHiddenField =
            TryCast(gridpantauSPD.FindEditRowCellTemplateControl(
                gridpantauSPD.Columns(FindColumnIndexByFieldName(gridpantauSPD, "fileTransf_url")),
                "hiddenFileUrl"),
            DevExpress.Web.ASPxHiddenField)

            If hidden IsNot Nothing AndAlso hidden.Contains("fileTransf_url") Then
                newFileUrl = hidden("fileTransf_url").ToString()
            Else
                ' tidak ada upload baru → ambil dari DB
                Dim idtbl As Integer = Convert.ToInt32(e.Keys("idtbl"))
                newFileUrl = GetOldFileUrlFromDatabase(idtbl)
            End If

            e.NewValues("fileTransf_url") = newFileUrl

            'dspantauspd.UpdateCommand =
            '"UPDATE trDetail_permintaanSPD " &
            '"SET jumlahtrf = @jumlahtrf, " &
            '"    tgltrf = @tgltrf, " &
            '"    NoReferensi = @NoReferensi, " &
            '"    statustrf = @statustrf, " &
            '"    notekeuangan = @notekeuangan, " &
            '"    fileTransf_url = @fileTransf_url " &
            '"WHERE idtbl = @idtbl"

            Using conn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand("UPDATE trDetail_permintaanSPD SET jumlahtrf = @jumlahtrf, tgltrf = @tgltrf, NoReferensi = @NoReferensi,statustrf = @statustrf,notekeuangan = @notekeuangan,fileTransf_url = @fileTransf_url WHERE idtbl = @idtbl", conn)

                    cmd.Parameters.AddWithValue("@jumlahtrf", e.NewValues("jumlahtrf"))
                    cmd.Parameters.AddWithValue("@tgltrf", e.NewValues("tgltrf"))
                    cmd.Parameters.AddWithValue("@NoReferensi", e.NewValues("NoReferensi"))
                    cmd.Parameters.AddWithValue("@statustrf", e.NewValues("statustrf"))
                    cmd.Parameters.AddWithValue("@notekeuangan", e.NewValues("notekeuangan"))
                    cmd.Parameters.AddWithValue("@fileTransf_url", e.NewValues("fileTransf_url"))
                    cmd.Parameters.AddWithValue("@idtbl", e.Keys("idtbl"))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            e.Cancel = True
            gridpantauSPD.CancelEdit()
            gridpantauSPD.DataBind()
        Catch ex As Exception
            Throw New Exception("Gagal upload file bukti transfer: " & ex.Message)
        End Try
    End Sub

    Private Function FindColumnIndexByFieldName(grid As ASPxGridView, fieldName As String) As Integer
        For i As Integer = 0 To grid.Columns.Count - 1
            If TypeOf grid.Columns(i) Is GridViewDataColumn Then
                Dim col = CType(grid.Columns(i), GridViewDataColumn)
                If col.FieldName = fieldName Then Return i
            End If
        Next
        Return -1
    End Function

    Protected Sub UploadBukti_FileUploadComplete(sender As Object, e As DevExpress.Web.FileUploadCompleteEventArgs)
        Try
            Dim uploadFolder As String = Server.MapPath("~/UploadFoto/")
            If Not IO.Directory.Exists(uploadFolder) Then IO.Directory.CreateDirectory(uploadFolder)

            Dim fileName As String = DateTime.Now.ToString("yyyyMMddHHmmss") & "_" & IO.Path.GetFileName(e.UploadedFile.FileName)
            Dim savePath As String = IO.Path.Combine(uploadFolder, fileName)

            ' Simpan file ke server
            e.UploadedFile.SaveAs(savePath)

            ' hasil upload dikirim ke client (JS)
            e.CallbackData = "UploadFoto/" & fileName
        Catch ex As Exception
            e.IsValid = False
            e.ErrorText = "Gagal upload file: " & ex.Message
        End Try
    End Sub


    'Protected Sub UploadBukti_FileUploadComplete(sender As Object, e As DevExpress.Web.FileUploadCompleteEventArgs)
    '    Try
    '        Dim uploadFolder As String = Server.MapPath("~/UploadFoto/")
    '        If Not IO.Directory.Exists(uploadFolder) Then IO.Directory.CreateDirectory(uploadFolder)

    '        Dim fileName As String = DateTime.Now.ToString("yyyyMMddHHmmss") & "_" & IO.Path.GetFileName(e.UploadedFile.FileName)
    '        Dim savePath As String = IO.Path.Combine(uploadFolder, fileName)

    '        ' Simpan file ke folder server
    '        e.UploadedFile.SaveAs(savePath)

    '        ' Simpan URL virtual ke session dan callback
    '        Dim virtualPath As String = "UploadFoto/" & fileName
    '        Session("UploadedPath") = virtualPath
    '        e.CallbackData = virtualPath
    '    Catch ex As Exception
    '        e.IsValid = False
    '        e.ErrorText = "Gagal upload file: " & ex.Message
    '    End Try
    'End Sub

    Private Function GetOldFileUrlFromDatabase(idtbl As Integer) As String
        Dim result As String = Nothing
        Dim connStr As String = ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString
        Using conn As New SqlClient.SqlConnection(connStr)
            Dim cmd As New SqlClient.SqlCommand("SELECT fileTransf_url FROM trDetail_permintaanSPD WHERE idtbl = @idtbl", conn)
            cmd.Parameters.AddWithValue("@idtbl", idtbl)
            conn.Open()
            Dim obj = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                result = obj.ToString()
            End If
        End Using
        Return result
    End Function

    'Protected Sub gridpantauSPD_RowUpdated(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatedEventArgs) Handles gridpantauSPD.RowUpdated
    '    If e.Exception Is Nothing Then
    '        gridpantauSPD.JSProperties("cpMessage") = "✅ Data berhasil diperbarui!"
    '    Else
    '        gridpantauSPD.JSProperties("cpMessageError") = "❌ Gagal memperbarui data: " & e.Exception.Message
    '        e.ExceptionHandled = True
    '    End If
    'End Sub

    Protected Sub gridpantauSPD_RowValidating(sender As Object, e As DevExpress.Web.Data.ASPxDataValidationEventArgs) Handles gridpantauSPD.RowValidating
        ' Contoh validasi kolom satu per satu
        ' Ubah sesuai nama field di tabel kamu

        If e.NewValues("jumlahtrf") Is Nothing OrElse String.IsNullOrWhiteSpace(e.NewValues("jumlahtrf").ToString()) Then
            e.Errors(gridpantauSPD.Columns("jumlahtrf")) = "Jumlah transfer wajib diisi."
        End If

        If e.NewValues("tgltrf") Is Nothing OrElse String.IsNullOrWhiteSpace(e.NewValues("tgltrf").ToString()) Then
            e.Errors(gridpantauSPD.Columns("tgltrf")) = "Tanggal transfer wajib diisi."
        End If

        If e.NewValues("NoReferensi") Is Nothing OrElse String.IsNullOrWhiteSpace(e.NewValues("NoReferensi").ToString()) Then
            e.Errors(gridpantauSPD.Columns("NoReferensi")) = "Nomor referensi wajib diisi."
        End If

        If e.NewValues("statustrf") Is Nothing OrElse String.IsNullOrWhiteSpace(e.NewValues("statustrf").ToString()) Then
            e.Errors(gridpantauSPD.Columns("statustrf")) = "Status transfer wajib diisi."
        End If

        If e.NewValues("notekeuangan") Is Nothing OrElse String.IsNullOrWhiteSpace(e.NewValues("notekeuangan").ToString()) Then
            e.Errors(gridpantauSPD.Columns("notekeuangan")) = "Catatan keuangan wajib diisi."
        End If

        ' Contoh jika ingin wajib upload file juga:
        'If e.NewValues("fileTransf_url") Is Nothing OrElse String.IsNullOrWhiteSpace(e.NewValues("fileTransf_url").ToString()) Then
        '    e.Errors(gridpantauSPD.Columns("fileTransf_url")) = "Bukti transfer wajib diupload."
        'End If

        ' Jika ada error, cegah proses update
        If e.Errors.Count > 0 Then
            e.RowError = "Mohon lengkapi semua field yang wajib diisi sebelum menyimpan."
        End If
    End Sub


    Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If Request.QueryString("status") <> "" Then
            searchSPD.Visible = False
        End If

        ' Validasi rentang tanggal
        If startdate.Value IsNot Nothing AndAlso enddate.Value IsNot Nothing Then
            If startdate.Value > enddate.Value Then Exit Sub
        End If

        '=== Ambil nilai tanggal ===
        Dim tglstartdate As String = ""
        Dim tglenddate As String = ""

        If startdate.Value IsNot Nothing AndAlso startdate.Value.ToString() <> "" Then
            tglstartdate = Convert.ToDateTime(startdate.Value).ToString("yyyy-MM-dd")
        End If

        If enddate.Value IsNot Nothing AndAlso enddate.Value.ToString() <> "" Then
            tglenddate = Convert.ToDateTime(enddate.Value).ToString("yyyy-MM-dd")
        End If

        '=== Bangun parameter tanggal ===
        Dim strParam As String = ""
        If tglstartdate <> "" AndAlso tglenddate = "" Then
            strParam = "AND tglpengajuan >= '" & tglstartdate & "'"
        ElseIf tglstartdate = "" AndAlso tglenddate <> "" Then
            strParam = "AND tglpengajuan <= DATEADD(day,1,'" & tglenddate & "')"
        ElseIf tglstartdate <> "" AndAlso tglenddate <> "" Then
            strParam = "AND tglpengajuan >= '" & tglstartdate & "' AND tglpengajuan <= DATEADD(day,1,'" & tglenddate & "')"
        End If

        '=== Filter berdasarkan status ===
        Dim baseQuery As String =
        "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, " &
        "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, " &
        "TRY_CONVERT(NUMERIC(38,0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, " &
        "tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.TypeTeknisi, " &
        "TRY_CONVERT(NUMERIC(38,0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, " &
        "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, trDetail_permintaanSPD.keterangan, trDetail_permintaanSPD.fileTransf_url " &
        "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask "

        If dd_statusTransfer.Text = "DONE" Then
            Session("filter") = baseQuery & "WHERE statustrf = 'Done' " & strParam & " ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"
        ElseIf dd_statusTransfer.Text = "PENDING" Then
            Session("filter") = baseQuery & "WHERE statustrf = 'PENDING' " & strParam & " ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"

        ElseIf dd_statusTransfer.Text = "Open" Then
            Session("filter") = baseQuery & "WHERE statustrf = 'Open' " & strParam & " ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"

        Else
            Session("filter") = baseQuery & "WHERE jumlahpengajuan <> 0 ORDER BY trDetail_permintaanSPD.tglpengajuan DESC"
        End If

        dspantauspd.SelectCommand = Session("filter")
        gridpantauSPD.DataBind()
        clsg.writedata("FormadminpantauSPD.aspx", Session("username"), "Store Filter", Session("filter"), "")
    End Sub


    'Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click

    '    If Request.QueryString("status") <> "" Then
    '        searchSPD.Visible = False
    '    End If

    '    If IsNothing(startdate.Value) = False Then
    '        If startdate.Value > enddate.Value Then Exit Sub
    '    End If

    '    Dim tglstartdate As String = ""
    '    If startdate.Value IsNot Nothing AndAlso startdate.Value.ToString() <> "" Then
    '        tglstartdate = Convert.ToDateTime(startdate.Value).ToString("yyyy-MM-dd")
    '    Else
    '        tglstartdate = DateTime.Now.ToString("yyyy-MM-dd")
    '    End If

    '    Dim tglenddate As String = ""
    '    If enddate.Value IsNot Nothing AndAlso enddate.Value.ToString() <> "" Then
    '        tglenddate = Convert.ToDateTime(enddate.Value).ToString("yyyy-MM-dd")
    '    Else
    '        tglenddate = DateTime.Now.ToString("yyyy-MM-dd")
    '    End If


    '    Dim strParam As String = ""
    '    If tglstartdate <> "" And tglenddate = "" Then
    '        strParam = "and tglpengajuan >= '" & tglstartdate & "'"
    '    ElseIf tglstartdate = "" And tglenddate <> "" Then
    '        strParam = "and tglpengajuan <= dateadd(day,1,'" & tglenddate & "')"
    '    ElseIf tglstartdate <> "" And tglenddate <> "" Then
    '        strParam = "and tglpengajuan >= '" & tglstartdate & "' and tglpengajuan <= dateadd(day,1,'" & tglenddate & "')"
    '    End If

    '    If dd_statusTransfer.Text = "DONE" Then
    '        If strParam <> "" Then
    '            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan as tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
    '                                "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
    '                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where statustrf = 'Done' " & strParam & " order by trDetail_permintaanSPD.tglpengajuan desc"
    '        Else
    '            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan as tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
    '                                "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
    '                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where statustrf = 'Done' order by trDetail_permintaanSPD.tglpengajuan desc"
    '        End If
    '    ElseIf dd_statusTransfer.Text = "Pending" And startdate.Value <> Nothing Then
    '        Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
    '                                "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
    '                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where statustrf = 'Pending' and tglpengajuan between '" & tglstartdate & "' and '" & tglenddate & "' and statustrf is null order by trDetail_permintaanSPD.tglpengajuan desc"
    '        'ElseIf dd_statusTransfer.Text = "Open" And startdate.Value <> Nothing Then
    '        '    Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
    '        '                            "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
    '        '                            "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0 and tglpengajuan between '" & tglstartdate & "' and '" & tglenddate & "' order by trDetail_permintaanSPD.tglpengajuan desc"
    '        'ElseIf dd_statusTransfer.Text = "DONE" Then
    '        '    Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
    '        '                            "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
    '        '                            "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0  and statustrf='" & dd_statusTransfer.Text & "' order by trDetail_permintaanSPD.tglpengajuan desc"
    '    ElseIf dd_statusTransfer.Text = "Open" Then
    '        Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
    '                                "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
    '                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where statustrf = 'Open'  and statustrf is null order by trDetail_permintaanSPD.tglpengajuan desc"
    '    Else
    '        Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " &
    '                                "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " &
    '                                "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0 order by trDetail_permintaanSPD.tglpengajuan desc"
    '    End If
    '    dspantauspd.SelectCommand = Session("filter")
    '    gridpantauSPD.DataBind()
    '    clsg.writedata("FormadminpantauSPD.aspx", Session("username"), "Store Filter", Session("filter"), "")
    'End Sub

    Protected Sub grid_DetailSPD_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim notask As String = TryCast(sender, ASPxGridView).GetMasterRowFieldValues("NoTask")
        dsdetailspd.SelectCommand = "select c.ProjectName,a.* from trDetail_Task a inner join trtask b on a.NoTask=b.NoTask inner join trProject c on b.IdProject=c.IdProject where a.notask= '" & notask & "'"
    End Sub
End Class
