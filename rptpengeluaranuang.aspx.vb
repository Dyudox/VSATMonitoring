Imports Microsoft.VisualBasic
Imports System
Partial Class rptpengeluaranuang
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        dsuang.SelectCommand = "SELECT tr_biaya.NoTask, SUM(tr_biaya.JumlahPengajuan) as totalbiaya, trTask.TanggalTask, trTask.IdProject, trTask.IdTeknisi, trTask.IdKoordinator, trTask.IdProvinsi, trTask.IdCity " & _
                                "FROM tr_biaya LEFT OUTER JOIN trTask ON tr_biaya.NoTask = trTask.NoTask " & _
                                "GROUP BY tr_biaya.NoTask, trtask.TanggalTask, trTask.IdProject, trTask.IdTeknisi, trTask.IdKoordinator, trTask.IdProvinsi, trTask.IdCity"
    End Sub

    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting All Data SPJ"
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
