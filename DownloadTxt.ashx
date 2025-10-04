<%@ WebHandler Language="VB" Class="DownloadTxt" %>

Imports System
Imports System.Web
Imports System.IO

Public Class DownloadTxt : Implements IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try
            ' Ambil nama file dari query string
            Dim fileName As String = context.Request.QueryString("file")

            If String.IsNullOrEmpty(fileName) Then
                context.Response.Write("Parameter file tidak ditemukan.")
                Return
            End If

            Dim folderPath As String = "D:\OfficeSelindo\Backup server\BackupVsat\Export_Txt\"
            Dim filePath As String = Path.Combine(folderPath, fileName)

            If File.Exists(filePath) Then
                context.Response.Clear()
                context.Response.ContentType = "text/plain"
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" & Path.GetFileName(filePath))
                context.Response.TransmitFile(filePath)
                context.Response.Flush()
                context.ApplicationInstance.CompleteRequest()
            Else
                context.Response.Write("File tidak ditemukan.")
            End If

        Catch ex As Exception
            context.Response.Write("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class
