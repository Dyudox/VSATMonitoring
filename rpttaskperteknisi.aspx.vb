Imports Microsoft.VisualBasic
Imports System
Partial Class rpttaskperteknisi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dstaskteknisi.SelectCommand = "SELECT IdProject, NamaTeknisi, idJenisTask, Tahun, isnull([Jan], 0) AS 'Jan', isnull([Feb], 0) AS Feb, isnull([Mar], 0) AS Mar, isnull([Apr], 0) AS Apr, isnull([May], 0) AS May, isnull([Jun], 0) AS Jun, isnull([Jul], 0) AS Jul, isnull([Aug], 0) AS Aug, " & _
                                    "isnull([Sep], 0) AS Sep, isnull([Okt], 0) AS Okt, isnull([Nov], 0) AS Nov, isnull([Dec], 0) AS Dec " & _
                                    "FROM ( " & _
                                    "SELECT a.IdProject, a.NamaTeknisi, idJenisTask, count(jml) AS jml, Tahun, bulan " & _
                                    "FROM ( " & _
                                    "SELECT b.IdProject, b.NamaTeknisi, a.idJenisTask, count(a.idJenisTask) AS jml, datepart(year, a.TglSelesaiKerjaan) AS Tahun, LEFT(datename(MONTH, a.TglSelesaiKerjaan), 3) AS bulan " & _
                                    "FROM trDetail_Task a JOIN trTask b ON a.NoTask = b.NoTask GROUP BY b.NamaTeknisi, b.IdProject, a.idJenisTask, a.TglSelesaiKerjaan) a " & _
                                    "GROUP BY a.NamaTeknisi, idJenisTask, a.IdProject, Tahun, bulan) AS TableB " & _
                                    "PIVOT (sum(jml) FOR Bulan IN ([Jan], [Feb], [Mar], [Apr], [May], [Jun], [Jul], [Aug], [Sep], [Okt], [Nov], [Dec])) AS PivTable1"

    End Sub

    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting Task per Teknisi"
        Select Case auo
            Case "xlsx"
                reportexp.WriteXlsxToResponse()
            Case "xls"
                reportexp.WriteXlsToResponse()
            Case "pdf"
                reportexp.WritePdfToResponse()
        End Select
    End Sub

    Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If cbproject.Value <> "" Then
            dstaskteknisi.SelectCommand = "SELECT IdProject, NamaTeknisi, idJenisTask, Tahun, isnull([Jan], 0) AS 'Jan', isnull([Feb], 0) AS Feb, isnull([Mar], 0) AS Mar, isnull([Apr], 0) AS Apr, isnull([May], 0) AS May, isnull([Jun], 0) AS Jun, isnull([Jul], 0) AS Jul, isnull([Aug], 0) AS Aug, " & _
                                    "isnull([Sep], 0) AS Sep, isnull([Okt], 0) AS Okt, isnull([Nov], 0) AS Nov, isnull([Dec], 0) AS Dec " & _
                                    "FROM ( " & _
                                    "SELECT a.IdProject, a.NamaTeknisi, idJenisTask, count(jml) AS jml, Tahun, bulan " & _
                                    "FROM ( " & _
                                    "SELECT b.IdProject, b.NamaTeknisi, a.idJenisTask, count(a.idJenisTask) AS jml, datepart(year, a.TglSelesaiKerjaan) AS Tahun, LEFT(datename(MONTH, a.TglSelesaiKerjaan), 3) AS bulan " & _
                                    "FROM trDetail_Task a JOIN trTask b ON a.NoTask = b.NoTask GROUP BY b.NamaTeknisi, b.IdProject, a.idJenisTask, a.TglSelesaiKerjaan) a " & _
                                    "GROUP BY a.NamaTeknisi, idJenisTask, a.IdProject, Tahun, bulan) AS TableB " & _
                                    "PIVOT (sum(jml) FOR Bulan IN ([Jan], [Feb], [Mar], [Apr], [May], [Jun], [Jul], [Aug], [Sep], [Okt], [Nov], [Dec])) AS PivTable1 " & _
                                    "where IdProject = '" & cbproject.Value & "'"
        Else
            dstaskteknisi.SelectCommand = "SELECT IdProject, NamaTeknisi, idJenisTask, Tahun, isnull([Jan], 0) AS 'Jan', isnull([Feb], 0) AS Feb, isnull([Mar], 0) AS Mar, isnull([Apr], 0) AS Apr, isnull([May], 0) AS May, isnull([Jun], 0) AS Jun, isnull([Jul], 0) AS Jul, isnull([Aug], 0) AS Aug, " & _
                                    "isnull([Sep], 0) AS Sep, isnull([Okt], 0) AS Okt, isnull([Nov], 0) AS Nov, isnull([Dec], 0) AS Dec " & _
                                    "FROM ( " & _
                                    "SELECT a.IdProject, a.NamaTeknisi, idJenisTask, count(jml) AS jml, Tahun, bulan " & _
                                    "FROM ( " & _
                                    "SELECT b.IdProject, b.NamaTeknisi, a.idJenisTask, count(a.idJenisTask) AS jml, datepart(year, a.TglSelesaiKerjaan) AS Tahun, LEFT(datename(MONTH, a.TglSelesaiKerjaan), 3) AS bulan " & _
                                    "FROM trDetail_Task a JOIN trTask b ON a.NoTask = b.NoTask GROUP BY b.NamaTeknisi, b.IdProject, a.idJenisTask, a.TglSelesaiKerjaan) a " & _
                                    "GROUP BY a.NamaTeknisi, idJenisTask, a.IdProject, Tahun, bulan) AS TableB " & _
                                    "PIVOT (sum(jml) FOR Bulan IN ([Jan], [Feb], [Mar], [Apr], [May], [Jun], [Jul], [Aug], [Sep], [Okt], [Nov], [Dec])) AS PivTable1"
        End If
    End Sub
End Class
