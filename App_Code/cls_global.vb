Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class cls_global
    Inherits System.Web.UI.Page
    Protected Da As SqlDataAdapter
    Protected Ds As DataSet
    Protected Dt, tbldata As DataTable
    Dim mycom As New SqlCommand()
    Dim mycon As New SqlConnection()
    Dim cs, TmpStr As String
    Dim f As System.IO.FileStream
    Dim p As DirectoryInfo
    Dim objreader As System.IO.StreamWriter
    Dim try_i As Integer = 1

    Private Sub BukaKoneksi()
        TutupKoneksi()
        Try
            cs = WebConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString()
            mycon.ConnectionString = cs
            mycon.Open()
            mycom.Connection = mycon
        Catch ex As Exception
            Session("Error") = ex.Message
            writedata("Error", "Open Database", cs, ex.Message, "")

            If try_i <= 3 Then
                try_i = try_i + 1
                Session("Error") = Nothing
                Me.BukaKoneksi()
            End If
        End Try
    End Sub
    Private Sub TutupKoneksi()
        mycon.Close()
        SqlConnection.ClearAllPools()
    End Sub

    Public Function BackupPath() As String
        TmpStr = Server.MapPath(ConfigurationManager.AppSettings.Item("BackupDB"))
        If System.IO.Directory.Exists(TmpStr) = False Then
            p = Directory.CreateDirectory(TmpStr)
            p.Create()
        End If
        TmpStr = Server.MapPath(ConfigurationManager.AppSettings.Item("BackupDB") & Date.Now.ToString("MM-yyyy") & "/")
        If System.IO.Directory.Exists(TmpStr) = False Then
            p = Directory.CreateDirectory(TmpStr)
            p.Create()
        End If
        Return Server.MapPath(ConfigurationManager.AppSettings.Item("BackupDB") & Date.Now.ToString("MM-yyyy") & "/")
    End Function

    Public Function ReplacePetik(ByVal str)
        If IsDBNull(str) = False Then
            str = Replace(str, "'", "''")
        End If

        Return str
    End Function

    Public Function ExecuteQuery(ByVal Query As String) As DataTable
        BukaKoneksi()
        If Session("Error") <> "" Then Exit Function
        Try
            mycom.CommandText = Query
            Da = New SqlDataAdapter
            Da.SelectCommand = mycom

            Ds = New Data.DataSet
            Da.Fill(Ds)

            Dt = Ds.Tables(0)

            Return Dt
        Catch ex As Exception
            Session("Error") = ex.Message
            writedata("System", "ExecuteQuery", ex.Message, Query, Session("dbName"))

            Session("Error") = Nothing
        End Try
    End Function
    Public Function ExecuteNonQuery(ByVal Query As String)
        BukaKoneksi()
        If Session("Error") <> "" Then Exit Function
        Try
            mycom.CommandText = Query
            mycom.ExecuteNonQuery()
        Catch ex As Exception
            Session("Error") = ex.Message
            writedata("System", "ExecuteNonQuery", ex.Message, Query, Session("dbName"))

            Session("Error") = Nothing
        End Try
    End Function

    Public Sub writedata(ByVal id_user As String, ByVal action As String, ByVal keterangan As String, ByVal query As String, ByVal ChName As String)
        Dim strdata As String = id_user & " | " & action & " | " & keterangan & " | " & query & " | " & ChName

        Dim dt As String = Date.Now.ToString("MM-dd-yyyy")
        Dim namalog, nmdir As String
        Try
            nmdir = Server.MapPath(ConfigurationManager.AppSettings.Item("Logsys") & Date.Now.ToString("MM-yyyy") & "/")
            If System.IO.Directory.Exists(nmdir) = False Then
                p = Directory.CreateDirectory(nmdir)
                p.Create()
            End If
            nmdir = ConfigurationManager.AppSettings.Item("Logsys") & Date.Now.ToString("MM-yyyy") & "/"
            namalog = Server.MapPath(nmdir & "logFile--" & dt & ".txt")
            'namalog = Server.MapPath(nmdir & "logFile-" & dt & ".txt")
            If System.IO.File.Exists(namalog) = False Then
                f = File.Create(namalog)
                f.Close()
            End If
            objreader = New System.IO.StreamWriter(namalog, True)
            objreader.Write(Now & " : " & strdata)
            objreader.WriteLine()
            objreader.Close()
        Catch ex As Exception
            writedata("System", "WriteData", ex.Message, strdata, Session("dbName"))
        End Try
    End Sub
End Class
