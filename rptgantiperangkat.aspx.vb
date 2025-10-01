Imports Microsoft.VisualBasic
Imports System
Partial Class rptgantiperangkat
    Inherits System.Web.UI.Page

    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting Ganti Perangkat"
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
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsgantiperangkat.SelectCommand = "Select idproject, tahun, bulan, HARI, SUM(CAST(tot AS numeric)) as totaltask, sum(Adaptor) as Adaptor, sum(buc) as buc, sum(lnb) as lnb,sum(modem) as modem, SUM([MODEM HX50]) as HX50, sum([MODEM HX50L]) as HX50L from  " & _
                                        "(SELECT trtask.idProject, Year(CONVERT(DATE, trtask.tanggaltask)) as tahun, MONTH(CONVERT(DATE, trtask.tanggaltask)) as bulan, DAY(CONVERT(DATE, trtask.tanggaltask)) as HARI, COUNT(trTask.NoTask) as tot, trRemoteSite_D_Rusak.Type FROM trRemoteSite_D_Rusak  " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trRemoteSite_D_Rusak.VID = trDetail_Task.VID  " & _
                                        "LEFT OUTER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask  " & _
                                        "where Year(trTask.TanggalTask) Is Not null  " & _
                                        "Group by trTask.TanggalTask, trRemoteSite_D_Rusak.Type, MONTH(trTask.TanggalTask), Year(trTask.TanggalTask), trtask.idProject  " & _
                                        ") as aaa  " & _
                                        "PIVOT  " & _
                                        "(count([type]) for [type] in (Adaptor,BUC,LNB,Modem, [MODEM HX50], [MODEM HX50L]) " & _
                                        " ) as piv " & _
                                        "GROUP BY piv.tahun, piv.bulan,piv.HARI, piv.idproject " & _
                                        "order by piv.tahun"

    End Sub

    Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If cbproject.Value <> "" Then
            dsgantiperangkat.SelectCommand = "Select idproject, tahun, bulan, HARI, SUM(CAST(tot AS numeric)) as totaltask, sum(Adaptor) as Adaptor, sum(buc) as buc, sum(lnb) as lnb,sum(modem) as modem, SUM([MODEM HX50]) as HX50, sum([MODEM HX50L]) as HX50L from  " & _
                                        "(SELECT trtask.idProject, Year(CONVERT(DATE, trtask.tanggaltask)) as tahun, MONTH(CONVERT(DATE, trtask.tanggaltask)) as bulan, DAY(CONVERT(DATE, trtask.tanggaltask)) as HARI, COUNT(trTask.NoTask) as tot, trRemoteSite_D_Rusak.Type FROM trRemoteSite_D_Rusak  " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trRemoteSite_D_Rusak.VID = trDetail_Task.VID  " & _
                                        "LEFT OUTER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask  " & _
                                        "where Year(trTask.TanggalTask) Is Not null  " & _
                                        "Group by trTask.TanggalTask, trRemoteSite_D_Rusak.Type, MONTH(trTask.TanggalTask), Year(trTask.TanggalTask), trtask.idProject  " & _
                                        ") as aaa  " & _
                                        "PIVOT  " & _
                                        "(count([type]) for [type] in (Adaptor,BUC,LNB,Modem, [MODEM HX50], [MODEM HX50L]) " & _
                                        " ) as piv " & _
                                        "where piv.idproject = '" & cbproject.Value & "' " & _
                                        "GROUP BY piv.tahun, piv.bulan,piv.HARI, piv.idproject " & _
                                        "order by piv.tahun"
        Else
            dsgantiperangkat.SelectCommand = "Select idproject, tahun, bulan, HARI, SUM(CAST(tot AS numeric)) as totaltask, sum(Adaptor) as Adaptor, sum(buc) as buc, sum(lnb) as lnb,sum(modem) as modem, SUM([MODEM HX50]) as HX50, sum([MODEM HX50L]) as HX50L from  " & _
                                        "(SELECT trtask.idProject, Year(CONVERT(DATE, trtask.tanggaltask)) as tahun, MONTH(CONVERT(DATE, trtask.tanggaltask)) as bulan, DAY(CONVERT(DATE, trtask.tanggaltask)) as HARI, COUNT(trTask.NoTask) as tot, trRemoteSite_D_Rusak.Type FROM trRemoteSite_D_Rusak  " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trRemoteSite_D_Rusak.VID = trDetail_Task.VID  " & _
                                        "LEFT OUTER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask  " & _
                                        "where Year(trTask.TanggalTask) Is Not null  " & _
                                        "Group by trTask.TanggalTask, trRemoteSite_D_Rusak.Type, MONTH(trTask.TanggalTask), Year(trTask.TanggalTask), trtask.idProject  " & _
                                        ") as aaa  " & _
                                        "PIVOT  " & _
                                        "(count([type]) for [type] in (Adaptor,BUC,LNB,Modem, [MODEM HX50], [MODEM HX50L]) " & _
                                        " ) as piv " & _
                                        "GROUP BY piv.tahun, piv.bulan,piv.HARI, piv.idproject " & _
                                        "order by piv.tahun"
        End If
    End Sub
End Class
