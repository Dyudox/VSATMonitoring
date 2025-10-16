<%@ WebHandler Language="VB" Class="DownloadTxt" %>

Imports System
Imports System.Web
Imports System.IO
Imports System.Threading

Public Class DownloadTxt
    Implements IHttpHandler

    ' ====== Pengaturan umum ======
    Private Const DELETE_DELAY_MINUTES As Integer = 5  ' waktu tunda sebelum file dihapus otomatis
    Private Const EXPORT_FOLDER As String = "~/Export_Txt/"

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try
            ' ===== Ambil parameter file =====
            Dim fileName As String = context.Request.QueryString("file")

            If String.IsNullOrEmpty(fileName) Then
                context.Response.StatusCode = 400
                context.Response.Write("Bad Request: filename required.")
                Return
            End If

            ' ===== Sanitasi nama file (hindari directory traversal) =====
            fileName = Path.GetFileName(fileName)
            Dim exportPath As String = context.Server.MapPath(EXPORT_FOLDER)
            Dim filePath As String = Path.Combine(exportPath, fileName)

            ' ===== Cek apakah file ada =====
            If Not File.Exists(filePath) Then
                context.Response.StatusCode = 404
                context.Response.Write("File not found.")
                Return
            End If

            ' ===== Kirim file ke browser =====
            context.Response.Clear()
            context.Response.ContentType = "text/plain"
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
            context.Response.WriteFile(filePath)
            context.Response.Flush()
            context.ApplicationInstance.CompleteRequest()

            ' ===== Bersihkan file lama di folder export =====
            CleanupOldFiles(exportPath)

            ' ===== Jadwalkan penghapusan otomatis (1x per file) =====
            ScheduleFileDeletion(context, filePath, fileName)

        Catch ex As Exception
            context.Response.StatusCode = 500
            context.Response.Write("Error: " & ex.Message)
        End Try
    End Sub

    ' ===== Jadwalkan penghapusan otomatis file =====
    Private Sub ScheduleFileDeletion(context As HttpContext, filePath As String, fileName As String)
        Dim deleteKey As String = "Delete_" & fileName

        ' Cegah thread delete ganda
        SyncLock context.Application
            If context.Application(deleteKey) IsNot Nothing Then Exit Sub
            context.Application(deleteKey) = True
        End SyncLock

        ThreadPool.QueueUserWorkItem(
            Sub(state)
                Try
                    Thread.Sleep(DELETE_DELAY_MINUTES * 60 * 1000)
                    If File.Exists(filePath) Then
                        File.Delete(filePath)
                    End If
                Catch
                Finally
                    ' Hapus flag delete dari Application agar bisa dipakai lagi
                    SyncLock context.Application
                        context.Application.Remove(deleteKey)
                    End SyncLock
                End Try
            End Sub
        )
    End Sub

    ' ===== Bersihkan file lama dari folder Export =====
    Private Sub CleanupOldFiles(exportPath As String)
        Try
            Dim dir As New DirectoryInfo(exportPath)
            For Each f As FileInfo In dir.GetFiles("*.txt")
                ' hapus jika file lebih tua dari X menit
                If DateTime.Now.Subtract(f.LastWriteTime).TotalMinutes > DELETE_DELAY_MINUTES Then
                    Try
                        f.Delete()
                    Catch
                        ' Abaikan error jika file sedang dipakai
                    End Try
                End If
            Next
        Catch
            ' Abaikan error folder
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class
