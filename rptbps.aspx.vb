Imports Microsoft.VisualBasic
Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.Bootstrap
Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports System.Data
Imports DevExpress.Web.ASPxEdit
Imports System.Net
Imports System.Net.Mail
Partial Class rptbps
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        If IsNothing(Session("query")) = False Then
            dsbps.SelectCommand = Session("query")
            grid_bps.DataBind()
        End If
        Session("NamaForm") = IO.Path.GetFileName(Request.Path)
    End Sub


    Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If cbperusahaan.Value = "" And strdate.Text = "" And enddate.Text = "" Then
            dsbps.SelectCommand = "select Perusahaan, tgltrf, tglpengajuan, jumlahtrf, NamaTeknisi, NoReferensi, statustrf, a.NoTask as NoTask, b.total as totalsite from " & _
                                "(SELECT tr_permintaanSPD.Perusahaan, trDetail_permintaanSPD.tgltrf, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, tr_permintaanSPD.NoTask " & _
                                "FROM tr_permintaanSPD " & _
                                "INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask) a " & _
                                "INNER JOIN " & _
                                "(select count(NoListTask) as total, NoTask from trDetail_Task " & _
                                "group by NoTask) b " & _
                                "on a.notask = b.notask where a.tgltrf is not null"
        ElseIf cbperusahaan.Value <> "" And strdate.Text = "" And enddate.Text = "" Then
            dsbps.SelectCommand = "select Perusahaan, tgltrf, tglpengajuan, jumlahtrf, NamaTeknisi, NoReferensi, statustrf, a.NoTask as NoTask, b.total as totalsite from " & _
                                "(SELECT tr_permintaanSPD.Perusahaan, trDetail_permintaanSPD.tgltrf, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, tr_permintaanSPD.NoTask " & _
                                "FROM tr_permintaanSPD " & _
                                "INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask) a " & _
                                "INNER JOIN " & _
                                "(select count(NoListTask) as total, NoTask from trDetail_Task " & _
                                "group by NoTask) b " & _
                                "on a.notask = b.notask " & _
                                "where a.Perusahaan = '" & cbperusahaan.Value & "' and a.tgltrf is not null"
        ElseIf cbperusahaan.Value = "" And strdate.Text <> "" And enddate.Text <> "" Then
            dsbps.SelectCommand = "select Perusahaan, tgltrf, tglpengajuan, jumlahtrf, NamaTeknisi, NoReferensi, statustrf, a.NoTask as NoTask, b.total as totalsite from " & _
                                "(SELECT tr_permintaanSPD.Perusahaan, trDetail_permintaanSPD.tgltrf, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, tr_permintaanSPD.NoTask " & _
                                "FROM tr_permintaanSPD " & _
                                "INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask) a " & _
                                "INNER JOIN " & _
                                "(select count(NoListTask) as total, NoTask from trDetail_Task " & _
                                "group by NoTask) b " & _
                                "on a.notask = b.notask " & _
                                    "where a.tgltrf BETWEEN '" & strdate.Value & "' and '" & enddate.Value & "'"
           
        Else
            dsbps.SelectCommand = "select Perusahaan, tgltrf, tglpengajuan, jumlahtrf, NamaTeknisi, NoReferensi, statustrf, a.NoTask as NoTask, b.total as totalsite from " & _
                                "(SELECT tr_permintaanSPD.Perusahaan, trDetail_permintaanSPD.tgltrf, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                "trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf, tr_permintaanSPD.NoTask " & _
                                "FROM tr_permintaanSPD " & _
                                "INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask) a " & _
                                "INNER JOIN " & _
                                "(select count(NoListTask) as total, NoTask from trDetail_Task " & _
                                "group by NoTask) b " & _
                                "on a.notask = b.notask " & _
                                "where a.Perusahaan = '" & cbperusahaan.Value & "' and a.tgltrf BETWEEN '" & strdate.Value & "' and '" & enddate.Value & "'"
           
        End If
        Session("query") = dsbps.SelectCommand
        grid_bps.DataBind()
    End Sub

    Protected Sub bconvertTin_Click(sender As Object, e As EventArgs) Handles bconvertTin.Click
        Dim auo As String = cbexpTin.Value
        reportexp.ReportHeader = "Reporting Rekap BPS"
        Select Case auo
            Case "xlsx"
                reportexp.WriteXlsxToResponse()
            Case "xls"
                reportexp.WriteXlsToResponse()
            Case "pdf"
                reportexp.WritePdfToResponse()
        End Select
    End Sub

    Protected Sub grid_VID_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim notask As String = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        dsdetailtask.SelectCommand = "select * from trDetail_Task where NoTask = '" & notask & "'"
    End Sub
End Class
