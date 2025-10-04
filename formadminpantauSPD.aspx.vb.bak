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
Partial Class formadminpantauSPD
    Inherits System.Web.UI.Page
    Dim clsg As New cls_global

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        Session("NamaForm") = IO.Path.GetFileName(Request.Path)
        If IsNothing(Session("filter")) Then
            dspantauspd.SelectCommand = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " & _
                                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0 order by trDetail_permintaanSPD.tglpengajuan desc"
        Else
            dspantauspd.SelectCommand = Session("filter")
        End If
        gridpantauSPD.DataBind()
    End Sub

    Protected Sub gridpantauSPD_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridpantauSPD.RowDeleting

    End Sub

    Protected Sub gridpantauSPD_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridpantauSPD.RowUpdating
        dspantauspd.UpdateCommand = "update trDetail_permintaanSPD set jumlahtrf = @jumlahtrf, tgltrf = @tgltrf, NoReferensi = @NoReferensi, statustrf = @statustrf, notekeuangan = @notekeuangan where idtbl = @idtbl"
    End Sub

    Protected Sub btnfilter_Click(sender As Object, e As EventArgs) Handles btnfilter.Click
        If IsNothing(startdate.Value) = False Then
            If startdate.Value > enddate.Value Then Exit Sub
        End If

        If dd_statusTransfer.Text = "DONE" And startdate.Value <> Nothing Then
            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " & _
                                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0 and tglpengajuan between '" & startdate.Value & "' and '" & enddate.Value & "' and statustrf='" & dd_statusTransfer.Text & "' order by trDetail_permintaanSPD.tglpengajuan desc"
        ElseIf dd_statusTransfer.Text = "kosong" And startdate.Value <> Nothing Then
            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " & _
                                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0 and tglpengajuan between '" & startdate.Value & "' and '" & enddate.Value & "' and statustrf is null order by trDetail_permintaanSPD.tglpengajuan desc"
        ElseIf dd_statusTransfer.Text = "" And startdate.Value <> Nothing Then
            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " & _
                                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0 and tglpengajuan between '" & startdate.Value & "' and '" & enddate.Value & "' order by trDetail_permintaanSPD.tglpengajuan desc"
        ElseIf dd_statusTransfer.Text = "DONE" Then
            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " & _
                                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0  and statustrf='" & dd_statusTransfer.Text & "' order by trDetail_permintaanSPD.tglpengajuan desc"
        ElseIf dd_statusTransfer.Text = "kosong" Then
            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " & _
                                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0  and statustrf is null order by trDetail_permintaanSPD.tglpengajuan desc"
        Else
            Session("filter") = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.Provider, tr_permintaanSPD.Perusahaan, tr_permintaanSPD.NoTask, trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.notekeuangan, trDetail_permintaanSPD.tgltrf, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahtrf,'.',''),',','')) jumlahtrf, tr_permintaanSPD.NamaTeknisi, " & _
                                    "tr_permintaanSPD.TypeTeknisi, try_convert(numeric(38, 0), REPLACE(REPLACE(trDetail_permintaanSPD.jumlahpengajuan,'.',''),',','')) jumlahpengajuan, trDetail_permintaanSPD.NoReferensi, trDetail_permintaanSPD.statustrf,trDetail_permintaanSPD.keterangan " & _
                                    "FROM tr_permintaanSPD INNER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask where jumlahpengajuan<>0 order by trDetail_permintaanSPD.tglpengajuan desc"
        End If
        dspantauspd.SelectCommand = Session("filter")
        gridpantauSPD.DataBind()
        clsg.writedata("FormadminpantauSPD.aspx", Session("username"), "Store Filter", Session("filter"), "")
    End Sub

    Protected Sub grid_DetailSPD_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim notask As String = TryCast(sender, ASPxGridView).GetMasterRowFieldValues("NoTask")
        dsdetailspd.SelectCommand = "select c.ProjectName,a.* from trDetail_Task a inner join trtask b on a.NoTask=b.NoTask inner join trProject c on b.IdProject=c.IdProject where a.notask= '" & notask & "'"
    End Sub
End Class
