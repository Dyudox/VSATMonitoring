Imports Microsoft.VisualBasic
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
Imports System.IO


Partial Class rptwajibpm
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand
    Dim tampungdata As String = ""

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsrptwajib.SelectCommand = "exec rptwajibpm '" & cbproject.Value & "', '" & cbPM.Value & "'"
        gridwajibpm.DataBind()
    End Sub

    Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        dsrptwajib.SelectCommand = "exec rptwajibpm '" & cbproject.Value & "', '" & cbPM.Value & "'"
        gridwajibpm.DataBind()

    End Sub

    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting Wajib PM"
        Select Case auo
            Case "xlsx"
                reportexp.WriteXlsxToResponse()
            Case "xls"
                reportexp.WriteXlsToResponse()
            Case "pdf"
                reportexp.WritePdfToResponse()
        End Select
    End Sub
End Class
