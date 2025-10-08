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
Partial Class listpenggunaanspd
    Inherits System.Web.UI.Page

    Protected Sub gv_detilpengajuan_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsdetilpengajuan.SelectCommand = "SELECT trDetail_Task.NoTask, trDetail_Task.IPLAN, trDetail_Task.NAMAREMOTE, trDetail_Task.VID, SUM(try_convert(numeric(38, 0),  tr_penggunaanSPD.Nominal)) as TotalPengeluaran " &
                                        "FROM trDetail_Task LEFT OUTER JOIN tr_penggunaanSPD ON trDetail_Task.VID = tr_penggunaanSPD.VID and trDetail_Task.NoTask = tr_penggunaanSPD.NoTask " &
                                        "where trDetail_Task.NoTask = '" & tampungan & "' group by trDetail_Task.NoTask, trDetail_Task.VID, trDetail_Task.IPLAN, trDetail_Task.NAMAREMOTE "
        'dsdetilpengajuan.SelectCommand = "Select VID, SUM(try_convert(numeric(38, 0), Nominal)) as TotalPengeluaran, NoTask from tr_penggunaanSPD where NoTask = '" & tampungan & "' group by VID, NoTask"
    End Sub
    Protected Sub gv_subDetilpengajuan_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsSubdetilpengajuan.SelectCommand = "select convert(varchar,TglInputBiaya,103) as TglInputBiaya,format(convert(int,Nominal),'##,###') as Nominal, TRX_FILE.file_url,* from tr_penggunaanSPD " &
                                            "left outer JOIN TRX_FILE ON tr_penggunaanSPD.DocNo = TRX_FILE.DocNo " &
                                            "where tr_penggunaanSPD.VID = '" & tampungan & "'"

        'dsSubdetilpengajuan.SelectCommand = "SELECT TRX_FILE.file_url, TRX_FILE.Description, tr_penggunaanSPD.CatatanApproval, tr_penggunaanSPD.NamaTeknisi, " &
        '                                "tr_penggunaanSPD.JenisBiaya, CONVERT(numeric(38, 0), tr_penggunaanSPD.Nominal) as Nominal, CONVERT(numeric(38, 0), " &
        '                                "tr_penggunaanSPD.ApprovalNominal) as ApprovalNominal, tr_penggunaanSPD.NamaAdmin, convert(date,tr_penggunaanSPD.TglInputBiaya) TglInputBiaya, " &
        '                                "tr_penggunaanSPD.TglApproveBiaya, * FROM trDetail_Task " &
        '                                "inner join tr_penggunaanSPD on trDetail_Task.VID = tr_penggunaanSPD.VID " &
        '                                "left outer JOIN TRX_FILE ON tr_penggunaanSPD.DocNo = TRX_FILE.DocNo " &
        '                                "where trDetail_Task.notask = '" & tampungan & "'"
    End Sub
    Protected Sub gridpengajuanuang_Load(sender As Object, e As EventArgs) Handles gridpengajuanuang.Load
        If Session("username") = "admin" Then
            dspengajuanuang.SelectCommand = "SELECT NoTask, NamaTeknisi, IdTeknisi, TypeTeknisi, total, approve, TanggalTask, SUM(try_convert(numeric(38, 0), TotalPengeluaran)) as totalsuk, (total - approve) as sisa  from ( " & _
                                        "select tr_permintaanSPD.NoTask, trTask.IdTeknisi, approve, tr_permintaanSPD.NamaTeknisi, TypeTeknisi, total, trTask.TanggalTask, TotalPengeluaran from tr_permintaanSPD " & _
                                        "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), jumlahtrf)) as total, notask as tot from trDetail_permintaanSPD where statustrf = 'DONE' group by notask) a on tr_permintaanSPD.NoTask = a.tot " & _
                                        "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), Nominal)) as TotalPengeluaran, NoTask, VID from tr_penggunaanSPD group by NoTask, VID) b on tr_permintaanSPD.NoTask = b.NoTask " & _
                                        "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), ApprovalNominal)) as approve, notask as notaskapp from tr_penggunaanSPD where Status = 'Approve' group by notask) c on tr_permintaanSPD.NoTask = c.notaskapp " & _
                                        "LEFT OUTER JOIN trTask on tr_permintaanSPD.NoTask = trTask.NoTask where trTask.IdStatusManager = 'Valid') a " & _
                                        "group by NoTask, NamaTeknisi, TypeTeknisi, total, TanggalTask, IdTeknisi, approve"
        Else
            dspengajuanuang.SelectCommand = "SELECT NoTask, NamaTeknisi, IdTeknisi, TypeTeknisi, total, approve, TanggalTask, SUM(try_convert(numeric(38, 0), TotalPengeluaran)) as totalsuk, (total - approve) as sisa  from ( " & _
                                       "select tr_permintaanSPD.NoTask, trTask.IdTeknisi, approve, tr_permintaanSPD.NamaTeknisi, TypeTeknisi, total, trTask.TanggalTask, TotalPengeluaran from tr_permintaanSPD " & _
                                       "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), jumlahtrf)) as total, notask as tot from trDetail_permintaanSPD where statustrf = 'DONE' group by notask) a on tr_permintaanSPD.NoTask = a.tot " & _
                                       "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), Nominal)) as TotalPengeluaran, NoTask, VID from tr_penggunaanSPD group by NoTask, VID) b on tr_permintaanSPD.NoTask = b.NoTask " & _
                                       "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), ApprovalNominal)) as approve, notask as notaskapp from tr_penggunaanSPD where Status='Approve' group by notask) c on tr_permintaanSPD.NoTask = c.notaskapp " & _
                                       "LEFT OUTER JOIN trTask on tr_permintaanSPD.NoTask = trTask.NoTask where trTask.IdStatusManager = 'Valid') a " & _
                                       "where IdTeknisi = '" & Session("username") & "'" & _
                                       "group by NoTask, NamaTeknisi, TypeTeknisi, total, TanggalTask, IdTeknisi, approve"
        End If
       
    End Sub
End Class
