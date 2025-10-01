Imports Microsoft.VisualBasic
Imports System
Partial Class ReportRekapTask
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        If Session("filter") = Nothing Then
            'dsrekaptask.SelectCommand = "select * from ( " & _
            '                       "SELECT trDetail_Task.idJenisTask, trRemoteSite.IdProject, COUNT(trDetail_Task.idJenisTask) as tot, YEAR(TglSelesaiKerjaan) as tahun, DATENAME(month, TglSelesaiKerjaan) as bulan " & _
            '                       "FROM trDetail_Task INNER JOIN trRemoteSite ON trDetail_Task.VID = trRemoteSite.VID " & _
            '                       "Group by trDetail_Task.idJenisTask, YEAR(TglSelesaiKerjaan), DATENAME(month, TglSelesaiKerjaan), trRemoteSite.IdProject) as a " & _
            '                       "PIVOT " & _
            '                       "( SUM(tot) FOR bulan in ( January, February, March, April, May, June, July, August, September, October, November, December) ) as p " & _
            '                       "where tahun is not null"
        Else
            dsrekaptask.SelectCommand = Session("filter")
        End If

        gridrekaptask.DataBind()
       
            'dsrekaptask.SelectCommand = "SELECT trDetail_Task.idJenisTask, trRemoteSite.IdProject, count(trdetail_task.VID) as tot, YEAR(TglSelesaiKerjaan) as tahun, DATENAME(month, TglSelesaiKerjaan) as bulan " & _
            '                            "FROM trDetail_Task INNER JOIN trRemoteSite ON trDetail_Task.VID = trRemoteSite.VID " & _
            '                            "Group by trDetail_Task.idJenisTask, YEAR(TglSelesaiKerjaan), DATENAME(month, TglSelesaiKerjaan), trRemoteSite.IdProject"
    End Sub

    Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If cbtask.Value = "" And cbproject.Value = "" Then
            dsrekaptask.SelectCommand = "select *, (ISNULL(January, 0) + ISNULL(February, 0) + ISNULL(March, 0) + ISNULL(April, 0) + ISNULL(May, 0) + ISNULL(June, 0) + ISNULL(July, 0) + ISNULL(August, 0) + ISNULL(September, 0) + ISNULL(October, 0) + ISNULL(November, 0) + ISNULL(December, 0)) as Total from ( " & _
                                    "SELECT trDetail_Task.idJenisTask, trRemoteSite.IdProject, COUNT(trDetail_Task.idJenisTask) as tot, YEAR(TglSelesaiKerjaan) as tahun, DATENAME(month, TglSelesaiKerjaan) as bulan " & _
                                    "FROM trDetail_Task INNER JOIN trRemoteSite ON trDetail_Task.VID = trRemoteSite.VID " & _
                                    "Group by trDetail_Task.idJenisTask, YEAR(TglSelesaiKerjaan), DATENAME(month, TglSelesaiKerjaan), trRemoteSite.IdProject) as a " & _
                                    "PIVOT " & _
                                    "( SUM(tot) FOR bulan in ( January, February, March, April, May, June, July, August, September, October, November, December) ) as p " & _
                                    "where tahun is not null"
        ElseIf cbtask.Value <> "" And cbproject.Value = "" Then
            dsrekaptask.SelectCommand = "select *, (ISNULL(January, 0) + ISNULL(February, 0) + ISNULL(March, 0) + ISNULL(April, 0) + ISNULL(May, 0) + ISNULL(June, 0) + ISNULL(July, 0) + ISNULL(August, 0) + ISNULL(September, 0) + ISNULL(October, 0) + ISNULL(November, 0) + ISNULL(December, 0)) as Total from ( " & _
                                    "SELECT trDetail_Task.idJenisTask, trRemoteSite.IdProject, COUNT(trDetail_Task.idJenisTask) as tot, YEAR(TglSelesaiKerjaan) as tahun, DATENAME(month, TglSelesaiKerjaan) as bulan " & _
                                    "FROM trDetail_Task INNER JOIN trRemoteSite ON trDetail_Task.VID = trRemoteSite.VID " & _
                                    "Group by trDetail_Task.idJenisTask, YEAR(TglSelesaiKerjaan), DATENAME(month, TglSelesaiKerjaan), trRemoteSite.IdProject) as a " & _
                                    "PIVOT " & _
                                    "( SUM(tot) FOR bulan in ( January, February, March, April, May, June, July, August, September, October, November, December) ) as p " & _
                                    "where tahun is not null and idJenisTask = '" & cbtask.Value & "'"
        ElseIf cbtask.Value = "" And cbproject.Value <> "" Then
            dsrekaptask.SelectCommand = "select *, (ISNULL(January, 0) + ISNULL(February, 0) + ISNULL(March, 0) + ISNULL(April, 0) + ISNULL(May, 0) + ISNULL(June, 0) + ISNULL(July, 0) + ISNULL(August, 0) + ISNULL(September, 0) + ISNULL(October, 0) + ISNULL(November, 0) + ISNULL(December, 0)) as Total from ( " & _
                                  "SELECT trDetail_Task.idJenisTask, trRemoteSite.IdProject, COUNT(trDetail_Task.idJenisTask) as tot, YEAR(TglSelesaiKerjaan) as tahun, DATENAME(month, TglSelesaiKerjaan) as bulan " & _
                                  "FROM trDetail_Task INNER JOIN trRemoteSite ON trDetail_Task.VID = trRemoteSite.VID " & _
                                  "Group by trDetail_Task.idJenisTask, YEAR(TglSelesaiKerjaan), DATENAME(month, TglSelesaiKerjaan), trRemoteSite.IdProject) as a " & _
                                  "PIVOT " & _
                                  "( SUM(tot) FOR bulan in ( January, February, March, April, May, June, July, August, September, October, November, December) ) as p " & _
                                  "where tahun is not null and IdProject = '" & cbproject.Value & "' "
        Else
            dsrekaptask.SelectCommand = "select *, (ISNULL(January, 0) + ISNULL(February, 0) + ISNULL(March, 0) + ISNULL(April, 0) + ISNULL(May, 0) + ISNULL(June, 0) + ISNULL(July, 0) + ISNULL(August, 0) + ISNULL(September, 0) + ISNULL(October, 0) + ISNULL(November, 0) + ISNULL(December, 0)) as Total from ( " & _
                                  "SELECT trDetail_Task.idJenisTask, trRemoteSite.IdProject, COUNT(trDetail_Task.idJenisTask) as tot, YEAR(TglSelesaiKerjaan) as tahun, DATENAME(month, TglSelesaiKerjaan) as bulan " & _
                                  "FROM trDetail_Task INNER JOIN trRemoteSite ON trDetail_Task.VID = trRemoteSite.VID " & _
                                  "Group by trDetail_Task.idJenisTask, YEAR(TglSelesaiKerjaan), DATENAME(month, TglSelesaiKerjaan), trRemoteSite.IdProject) as a " & _
                                  "PIVOT " & _
                                  "( SUM(tot) FOR bulan in ( January, February, March, April, May, June, July, August, September, October, November, December) ) as p " & _
                                  "where tahun is not null and IdProject = '" & cbproject.Value & "' and  idJenisTask = '" & cbtask.Value & "'"
        End If
        Session("filter") = dsrekaptask.SelectCommand
    End Sub

    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting Rekap Task"
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
