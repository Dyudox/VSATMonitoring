Imports Microsoft.VisualBasic
Imports System
Partial Class rpttaskperprovinsi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dstaskprov.SelectCommand = "SELECT Provinsi, IdProject, isnull([SiteSurvey], 0) AS [SiteSurvey], isnull([Installation], 0) AS [Installation], isnull([MIGRASI], 0) AS [MIGRASI], isnull([CM], 0) AS [CM], isnull([DISMANTLE], 0) AS [DISMANTLE], " & _
                                    "isnull([SoftwareUpgrade], 0) AS [SoftwareUpgrade], isnull([PM], 0) AS [PM], isnull([OBSTACLE], 0) AS [OBSTACLE], isnull([RELOKASI], 0) AS [RELOKASI], isnull([BBD], 0) AS [BBD] " & _
                                    "FROM (SELECT b.IdProject, b.Provinsi, a.idJenisTask, count(a.idJenisTask) AS jml FROM trDetail_Task a " & _
                                    "LEFT OUTER JOIN trTask b ON a.NoTask = b.NoTask " & _
                                    "GROUP BY a.idJenisTask, b.Provinsi, b.IdProject) AS TableB PIVOT (sum(jml) FOR idJenisTask IN ([SiteSurvey], [Installation], [MIGRASI], [CM], [DISMANTLE], [SoftwareUpgrade], [PM], [OBSTACLE], [RELOKASI], [BBD])) " & _
                                    "AS PivTable1"

    End Sub

    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting Task per Provinsi"
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
            dstaskprov.SelectCommand = "SELECT Provinsi, IdProject, isnull([SiteSurvey], 0) AS [SiteSurvey], isnull([Installation], 0) AS [Installation], isnull([MIGRASI], 0) AS [MIGRASI], isnull([CM], 0) AS [CM], isnull([DISMANTLE], 0) AS [DISMANTLE], " & _
                                   "isnull([SoftwareUpgrade], 0) AS [SoftwareUpgrade], isnull([PM], 0) AS [PM], isnull([OBSTACLE], 0) AS [OBSTACLE], isnull([RELOKASI], 0) AS [RELOKASI], isnull([BBD], 0) AS [BBD] " & _
                                   "FROM (SELECT b.IdProject, b.Provinsi, a.idJenisTask, count(a.idJenisTask) AS jml FROM trDetail_Task a " & _
                                   "LEFT OUTER JOIN trTask b ON a.NoTask = b.NoTask " & _
                                   "GROUP BY a.idJenisTask, b.Provinsi, b.IdProject) AS TableB PIVOT (sum(jml) FOR idJenisTask IN ([SiteSurvey], [Installation], [MIGRASI], [CM], [DISMANTLE], [SoftwareUpgrade], [PM], [OBSTACLE], [RELOKASI], [BBD])) " & _
                                   "AS PivTable1 " & _
                                    "WHERE IdProject = '" & cbproject.Value & "'"
        Else
            dstaskprov.SelectCommand = "SELECT Provinsi, IdProject, isnull([SiteSurvey], 0) AS [SiteSurvey], isnull([Installation], 0) AS [Installation], isnull([MIGRASI], 0) AS [MIGRASI], isnull([CM], 0) AS [CM], isnull([DISMANTLE], 0) AS [DISMANTLE], " & _
                                   "isnull([SoftwareUpgrade], 0) AS [SoftwareUpgrade], isnull([PM], 0) AS [PM], isnull([OBSTACLE], 0) AS [OBSTACLE], isnull([RELOKASI], 0) AS [RELOKASI], isnull([BBD], 0) AS [BBD] " & _
                                   "FROM (SELECT b.IdProject, b.Provinsi, a.idJenisTask, count(a.idJenisTask) AS jml FROM trDetail_Task a " & _
                                   "LEFT OUTER JOIN trTask b ON a.NoTask = b.NoTask " & _
                                   "GROUP BY a.idJenisTask, b.Provinsi, b.IdProject) AS TableB PIVOT (sum(jml) FOR idJenisTask IN ([SiteSurvey], [Installation], [MIGRASI], [CM], [DISMANTLE], [SoftwareUpgrade], [PM], [OBSTACLE], [RELOKASI], [BBD])) " & _
                                   "AS PivTable1"
        End If
    End Sub
End Class
