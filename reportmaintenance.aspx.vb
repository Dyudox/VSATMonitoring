Imports Microsoft.VisualBasic
Imports System
Partial Class reportmaintenance
    Inherits System.Web.UI.Page

   
    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting All Data Maintenance"
        Select Case auo
            Case "xlsx"
                reportexp.WriteXlsxToResponse()
            Case "xls"
                reportexp.WriteXlsToResponse()
            Case "pdf"
                reportexp.WritePdfToResponse()
        End Select
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        dsreport.SelectCommand = "SELECT trDetail_Task.NoListTask, trDetail_Task.NoTask, trDetail_Task.VID, trTask.TanggalTask, trDetail_Task.NAMAREMOTE, trDetail_Task.ALAMAT, trDetail_Task.PROVINSI, trDetail_Task.KOTA, msJenis_Task.Service, msStatus.Status, trDetail_Task.PIC " & _
                                "FROM trDetail_Task LEFT OUTER JOIN " & _
                                "msJenis_Task ON trDetail_Task.idJenisTask = msJenis_Task.ID " & _
                                "LEFT OUTER JOIN msStatus on trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                "left outer join trTask on trDetail_Task.NoTask = trTask.NoTask"
    End Sub
End Class
