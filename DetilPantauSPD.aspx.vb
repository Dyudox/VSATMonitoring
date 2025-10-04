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
Partial Class DetilPantauSPD
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim clsg As New cls_global
    Dim tbldata As DataTable

    Protected Sub gv_detilpengajuan_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsdetilpengajuan.SelectCommand = "Select idtbl, notask, CONVERT(numeric(38, 0), jumlahpengajuan) as jumlahpengajuan, statustrf, tglpengajuan, keterangan, tgltrf, NoReferensi, CONVERT(numeric(38, 0), jumlahtrf) as jumlahtrf, notekeuangan from trDetail_permintaanSPD where NoTask = '" & tampungan & "'"
    End Sub
    Protected Sub gridpengajuanuang_Load(sender As Object, e As EventArgs) Handles gridpengajuanuang.Load
        'dspengajuanuang.SelectCommand = "SELECT trTask.NoTask, trTask.TanggalTask, trTask.NamaTask, tr_permintaanSPD.Provider, tr_permintaanSPD.NamaTeknisi " & _
        '                                "FROM trTask INNER JOIN tr_permintaanSPD ON trTask.NoTask = tr_permintaanSPD.NoTask"
        dspengajuanuang.SelectCommand = "SELECT NoTask, NamaTeknisi, total, NamaTask, approve, Provider, TanggalTask, SUM(try_convert(numeric(38, 0), TotalPengeluaran)) as totalsuk, (total - approve) as sisa  from ( " & _
                                        "select tr_permintaanSPD.NoTask, tr_permintaanSPD.NamaTeknisi, approve, tr_permintaanSPD.Provider, total, trTask.TanggalTask, trTask.NamaTask, TotalPengeluaran from tr_permintaanSPD " & _
                                        "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), jumlahtrf)) as total, NoTask from trDetail_permintaanSPD where statustrf = 'DONE' group by notask) a on tr_permintaanSPD.NoTask = a.NoTask " & _
                                        "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), Nominal)) as TotalPengeluaran, NoTask, VID from tr_penggunaanSPD group by NoTask, VID) b on tr_permintaanSPD.NoTask = b.NoTask " & _
                                        "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), ApprovalNominal)) as approve, notask as notaskapp from tr_penggunaanSPD where Status = 'Approve' group by notask) c on tr_permintaanSPD.NoTask = c.notaskapp " & _
                                        "LEFT OUTER JOIN trTask on tr_permintaanSPD.NoTask = trTask.NoTask) a " & _
                                        "group by NoTask, NamaTask, Provider, NamaTeknisi, total, TanggalTask, approve"
    End Sub
   
    Protected Sub gv_detailpenggunaanSPD_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dspenggunaanSPD.SelectCommand = "SELECT TRX_FILE.file_url, TRX_FILE.Description, tr_penggunaanSPD.CatatanApproval, tr_penggunaanSPD.NamaTeknisi, " & _
                                        "tr_penggunaanSPD.JenisBiaya, CONVERT(numeric(38, 0), tr_penggunaanSPD.Nominal) as Nominal, CONVERT(numeric(38, 0), " & _
                                        "tr_penggunaanSPD.ApprovalNominal) as ApprovalNominal, tr_penggunaanSPD.NamaAdmin, convert(date,tr_penggunaanSPD.TglInputBiaya) TglInputBiaya, " & _
                                        "tr_penggunaanSPD.TglApproveBiaya, * FROM trDetail_Task " & _
                                        "inner join tr_penggunaanSPD on trDetail_Task.VID = tr_penggunaanSPD.VID " & _
                                        "left outer JOIN TRX_FILE ON tr_penggunaanSPD.DocNo = TRX_FILE.DocNo " & _
                                        "where trDetail_Task.notask = '" & tampungan & "'"

    End Sub

    Protected Sub gv_detailpenggunaanSPD_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        dspenggunaanSPD.UpdateCommand = "update tr_penggunaanSPD set ApprovalNominal = @ApprovalNominal, TglApproveBiaya = GETDATE(), Status = @Status, CatatanApproval = @CatatanApproval where ID = @ID"
        dspenggunaanSPD.DataBind()
    End Sub

    Protected Sub gv_detailpenggunaanSPD_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        dspenggunaanSPD.DeleteCommand = "delete from tr_penggunaanSPD where ID = @ID"
        dspenggunaanSPD.DataBind()
    End Sub

    Protected Sub buttonDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        Dim values() As Object = CType(container.Grid.GetRowValues(container.VisibleIndex, New String() {"ID", "VID"}), Object())

        strsql = "delete from tr_penggunaanSPD where ID='" & values(0) & "' and VID='" & values(1) & "'"
        clsg.ExecuteNonQuery(strsql)
        dspenggunaanSPD.DataBind()

    End Sub

    Protected Sub b_new_Click(sender As Object, e As EventArgs)
        'formpenggunaanuang.aspx?VID=SCM201800010002000638&notask=100044
        strsql = "formpenggunaanuang.aspx?notask=" & Session("ID") & "&order=new"
        Response.Redirect(strsql)
    End Sub

    Protected Sub b_edit_Click(sender As Object, e As EventArgs)
        Dim btn As ASPxButton = CType(sender, ASPxButton)
        Dim container As GridViewDataItemTemplateContainer = CType(btn.NamingContainer, GridViewDataItemTemplateContainer)
        Dim values() As Object = CType(container.Grid.GetRowValues(container.VisibleIndex, New String() {"ID", "VID"}), Object())

        strsql = "formpenggunaanuang.aspx?notask=" & Session("ID") & "&order=edit&VID=" & values(1) & ""
        Response.Redirect(strsql)
    End Sub
End Class
