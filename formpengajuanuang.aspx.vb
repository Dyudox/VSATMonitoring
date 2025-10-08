Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Bootstrap
'Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports DevExpress.Web.ASPxEdit
Imports System.Net
Imports System.Net.Mail
Partial Class formpengajuanuang
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr, sqldr As SqlDataReader
    Dim com As SqlCommand
    Dim emailAcc As String = ConfigurationManager.AppSettings("emailAcc")
    Dim emailPass As String = ConfigurationManager.AppSettings("emailPass")
    Dim emailHost As String = ConfigurationManager.AppSettings("emailHost")
    Dim emailPort As String = ConfigurationManager.AppSettings("emailPort")

    Protected Sub gv_detilpengajuan_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsdetilpengajuan.SelectCommand = "SELECT CONVERT(numeric(38, 0), trDetail_permintaanSPD.jumlahpengajuan) as jumlahpengajuan, trDetail_permintaanSPD.statustrf, " &
                                        "trDetail_permintaanSPD.tglpengajuan, trDetail_permintaanSPD.NoTask, tr_permintaanSPD.Perusahaan, " &
                                        "tr_permintaanSPD.Provider, trDetail_permintaanSPD.keterangan, trDetail_permintaanSPD.idtbl, trTask.IdStatusManager FROM trDetail_permintaanSPD " &
                                        "LEFT OUTER JOIN trTask on trTask.NoTask = trDetail_permintaanSPD.NoTask " &
                                        "LEFT OUTER JOIN tr_permintaanSPD ON trDetail_permintaanSPD.NoTask = tr_permintaanSPD.notask  where trDetail_permintaanSPD.NoTask = '" & tampungan & "'"
    End Sub

    Protected Sub gridpengajuanuang_Load(sender As Object, e As EventArgs) Handles gridpengajuanuang.Load
        If Request.QueryString("NoTask") = "" Then
            'dspengajuanuang.SelectCommand = "select  tr_permintaanSPD.NoTask, trtask.NamaTask, tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.Provider, TypeTeknisi, SUM(try_convert(numeric(38, 0), totalPaguSuk)) as totalPaguSuk1, total, trTask.TanggalTask from tr_permintaanSPD " & _
            '                                "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), jumlahpengajuan)) as total, notask as tot from trDetail_permintaanSPD group by notask) a on tr_permintaanSPD.NoTask = a.tot " & _
            '                                "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), Pagu)) as totalPaguSuk, NoTask from " & _
            '                                "(SELECT trTask.NoTask, trDetail_Task.VID, CAST(ms_Pagu.Pagu AS int) as Pagu, ms_Pagu.Provider FROM trTask " & _
            '                                "INNER JOIN trDetail_Task on trTask.NoTask = trDetail_Task.NoTask " & _
            '                                "INNER JOIN msEmployee ON trTask.IdTeknisi = msEmployee.NIK " & _
            '                                "INNER JOIN ms_Pagu ON msEmployee.IdStatusPegawai = ms_Pagu.TypeKaryawan ) as a group by NoTask, VID) b on tr_permintaanSPD.NoTask = b.NoTask " & _
            '                                "LEFT OUTER JOIN trTask on tr_permintaanSPD.NoTask = trTask.NoTask where trTask.IdStatusManager = 'Valid'" & _
            '                                "group by tr_permintaanSPD.NoTask, tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.Provider, tr_permintaanSPD.TypeTeknisi, a.total, trTask.TanggalTask, trTask.NamaTask"

            dspengajuanuang.SelectCommand = "select  trtask.NamaTask, trTask.NoTask, trTask.NamaTeknisi, trTask.TanggalTask, msEmployee.IdStatusPegawai, SUM(try_convert(numeric(38, 0), ms_pagu.Pagu)) as pagu, a.total, trtask.status, trTask.IdStatusManager from trTask " &
                                            "LEFT OUTER JOIN trDetail_Task on trTask.NoTask = trDetail_Task.NoTask " &
                                            "LEFT OUTER JOIN msEmployee on trTask.NamaTeknisi = msEmployee.Nama " &
                                            "LEFT OUTER JOIN ms_pagu on msEmployee.IdStatusPegawai = ms_Pagu.TypeKaryawan " &
                                            "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), jumlahpengajuan)) as total, notask as tot from trDetail_permintaanSPD group by notask) a on trTask.NoTask = a.tot " &
                                            "where  trTask.IdStatusManager = 'Valid' " &
                                            "group by trTask.NamaTask, trTask.NoTask, trtask.NamaTeknisi, trTask.TanggalTask, msEmployee.IdStatusPegawai, a.total, trtask.status, trTask.IdStatusManager"
        Else
            Dim tampungprovider As String
            Dim getdataprovider As String = "SELECT trTask.NoTask, trTask.IdProject, trProject.ProjectName, trProject.IdProvider " & _
                                            "FROM trTask LEFT OUTER JOIN " & _
                                            "trProject ON trTask.IdProject = trProject.IdProject where trTask.NoTask = '" & Request.QueryString("NoTask") & "'"
            com = New SqlCommand(getdataprovider, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            tampungprovider = RTrim(dr("IdProvider").ToString)
            dr.Close()
            con.Close()

            dspengajuanuang.SelectCommand = "select  trtask.NamaTask, trTask.NoTask, trTask.NamaTeknisi, trTask.TanggalTask, msEmployee.IdStatusPegawai, SUM(try_convert(numeric(38, 0), ms_pagu.Pagu)) as pagu, a.total, trTask.IdStatusManager from trTask " &
                                            "LEFT OUTER JOIN trDetail_Task on trTask.NoTask = trDetail_Task.NoTask " &
                                            "LEFT OUTER JOIN msEmployee on trTask.NamaTeknisi = msEmployee.Nama " &
                                            "LEFT OUTER JOIN ms_pagu on msEmployee.IdStatusPegawai = ms_Pagu.TypeKaryawan " &
                                            "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), jumlahpengajuan)) as total, notask as tot from trDetail_permintaanSPD group by notask) a on trTask.NoTask = a.tot " &
                                            "where trtask.NoTask = '" & Request.QueryString("NoTask") & "' and ms_pagu.Provider = '" & tampungprovider & "' and trTask.IdStatusManager = 'Valid' " &
                                            "group by trTask.NamaTask, trTask.NoTask, trtask.NamaTeknisi, trTask.TanggalTask, msEmployee.IdStatusPegawai, a.total, trTask.IdStatusManager"
            'dspengajuanuang.SelectCommand = "select  tr_permintaanSPD.NoTask, trtask.NamaTask, tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.Provider, TypeTeknisi, SUM(try_convert(numeric(38, 0), totalPaguSuk)) as totalPaguSuk1, total, trTask.TanggalTask from tr_permintaanSPD " & _
            '                                "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), jumlahpengajuan)) as total, notask as tot from trDetail_permintaanSPD group by notask) a on tr_permintaanSPD.NoTask = a.tot " & _
            '                                "LEFT OUTER JOIN (select SUM(try_convert(numeric(38, 0), Pagu)) as totalPaguSuk, NoTask from " & _
            '                                "(SELECT trTask.NoTask, trDetail_Task.VID, CAST(ms_Pagu.Pagu AS int) as Pagu, ms_Pagu.Provider FROM trTask " & _
            '                                "INNER JOIN trDetail_Task on trTask.NoTask = trDetail_Task.NoTask " & _
            '                                "INNER JOIN msEmployee ON trTask.IdTeknisi = msEmployee.NIK " & _
            '                                "INNER JOIN ms_Pagu ON msEmployee.IdStatusPegawai = ms_Pagu.TypeKaryawan " & _
            '                                "where trTask.NoTask='" & Request.QueryString("NoTask") & "' and ms_pagu.Provider='" & tampungprovider & "') as a group by NoTask, VID) b on tr_permintaanSPD.NoTask = b.NoTask " & _
            '                                "LEFT OUTER JOIN trTask on tr_permintaanSPD.NoTask = trTask.NoTask where trTask.IdStatusManager = 'Valid' and tr_permintaanSPD.NoTask = '" & Request.QueryString("NoTask") & "'" & _
            '                                "group by tr_permintaanSPD.NoTask, tr_permintaanSPD.NamaTeknisi, tr_permintaanSPD.Provider, tr_permintaanSPD.TypeTeknisi, a.total, trTask.TanggalTask, trTask.NamaTask"
        End If
    End Sub

    Protected Sub gv_subDetilpengajuan_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsSubdetilpengajuan.SelectCommand = "select convert(varchar,TglInputBiaya,103) as TglInputBiaya,format(convert(int,Nominal),'##,###') as Nominal, TRX_FILE.file_url,* from tr_penggunaanSPD " &
                                            "left outer JOIN TRX_FILE ON tr_penggunaanSPD.DocNo = TRX_FILE.DocNo " &
                                            "where tr_penggunaanSPD.VID = '" & tampungan & "'"

    End Sub

    Protected Sub gridlokasi_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")

        Dim getprovider As String
        Dim getsuk As String = "SELECT trTask.NoTask, trTask.IdProject, trProject.ProjectName, trProject.IdProvider " & _
                                            "FROM trTask LEFT OUTER JOIN " & _
                                            "trProject ON trTask.IdProject = trProject.IdProject where trTask.NoTask = '" & tampungan & "'"
        com = New SqlCommand(getsuk, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        getprovider = RTrim(dr("IdProvider").ToString)
        dr.Close()
        con.Close()

        dsgridlokasi.SelectCommand = "SELECT VID, IdStatusPegawai, Provider, Hotel, Transport, Paket  From " & _
                                    "(SELECT trDetail_Task.VID, msEmployee.IdStatusPegawai, ms_Pagu.TypeKaryawan, ms_Pagu.Deskripsi, CAST(ms_Pagu.Pagu AS int) as Pagu, ms_Pagu.Provider " & _
                                    "FROM trTask INNER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                    "INNER JOIN msEmployee ON trTask.IdTeknisi = msEmployee.NIK " & _
                                    "INNER JOIN ms_Pagu ON msEmployee.IdStatusPegawai = ms_Pagu.TypeKaryawan where trDetail_Task.NoTask= '" & tampungan & "' and ms_Pagu.Provider = '" & getprovider & "') as sourcetable " & _
                                    "PIVOT " & _
                                    "(SUM(Pagu) " & _
                                    "For Deskripsi In ([hotel], [Transport], [Paket])) as pivottable"
    End Sub

    Protected Sub gridpengajuanuang_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridpengajuanuang.RowDeleting
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsdetilpengajuan.DeleteCommand = "delete from trDetail_permintaanSPD where idtbl = @idtbl"
        dsdetilpengajuan.DataBind()
        gridpengajuanuang.DataBind()
        DevExpress.Web.ASPxWebControl.RedirectOnCallback(Request.RawUrl)
        'Dim deleteheader As String = "delete from tr_permintaanSPD where NoTask = '" & tampungan & "'"
        'com = New SqlCommand(deleteheader, con)
        'con.Open()
        'com.ExecuteNonQuery()
        'con.Close()
    End Sub

    Protected Sub gridpengajuanuang_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gridpengajuanuang.RowInserting
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsdetilpengajuan.InsertCommand = "insert into trDetail_permintaanSPD (jumlahpengajuan, notask, tglpengajuan, keterangan) VALUES (@jumlahpengajuan, '" & tampungan & "', @tglpengajuan, @keterangan)"
        'dspengajuanuang.InsertCommand = "insert into tr_permintaanSPD (NamaTeknisi, TypeTeknisi, NoTask, Provider, Perusahaan) VALUES ('" & e.NewValues("NamaTeknisi").ToString & "', '" & tampungteknisi & "', '" & idsuk & "', '" & namaprovider & "', '" & GetPerusahaan & "')"
        dsdetilpengajuan.DataBind()
        gridpengajuanuang.DataBind()


        Dim tanggalpengajuan, provider, total, namateknisi, namabank, namarekening, nomorrekening, catatan As String
        Dim gettask As String = "SELECT trDetail_permintaanSPD.idtbl, tr_permintaanSPD.NoTask, tr_permintaanSPD.Provider, trDetail_permintaanSPD.tglpengajuan, tr_permintaanSPD.NamaTeknisi, " & _
                                "trDetail_permintaanSPD.jumlahpengajuan, msEmployee.AccountBank, msEmployee.NamaBank, msEmployee.RekeningBank, trDetail_permintaanSPD.keterangan FROM tr_permintaanSPD " & _
                                "LEFT OUTER JOIN trDetail_permintaanSPD ON tr_permintaanSPD.NoTask = trDetail_permintaanSPD.notask " & _
                                "LEFT OUTER JOIN msEmployee ON tr_permintaanSPD.NamaTeknisi = msEmployee.Nama where tr_permintaanSPD.NoTask = '" & tampungan & "'"
        com = New SqlCommand(gettask, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            tanggalpengajuan = e.NewValues("tglpengajuan").ToString
            provider = dr("Provider").ToString
            total = e.NewValues("jumlahpengajuan").ToString
            namateknisi = dr("NamaTeknisi").ToString
            namabank = dr("NamaBank").ToString
            namarekening = dr("AccountBank").ToString
            nomorrekening = dr("RekeningBank").ToString
            catatan = e.NewValues("keterangan").ToString
        End If
       
        dr.Close()
        con.Close()

        Dim RequestTittle As String = "New Request SPD Task " & tampungan & ""
        Dim Body As String
        Body &= "<hr noshade='noshade' style='background-color:#515041; height: 5px;'/>" &
                "<p>Kami memohon untuk mencairkan dana SPD untuk task: </p>" &
                "<br/>" &
                "<p>No. Task : " & tampungan & " </p>" &
                "<p>Tanggal pengajuan : " & tanggalpengajuan & "</p>" &
                "<p>Provider : " & provider & "</p>" &
                "<p>Nama Teknisi : " & namateknisi & "</p>" &
                "<p>Nama Bank : " & namabank & "</p>" &
                "<p>Rekening Atas Nama : " & namarekening & " </p>" &
                "<p>Nomor Rekening : " & nomorrekening & "</p>" &
                "<p>Jumlah SPD yang harus di transfer : " & total & "</p>" &
                "<p>Note : " & catatan & " </p>" &
                "<br/>" &
                "<p>Thank you</p>" &
                "<hr noshade='noshade' style='background-color:#515041; height: 5px;'/>" &
                "<p style='text-align:center; margin-top:-60px;'><font size='1'>This email has been send from an automated system, Please do not reply</font></p>" &
                "<p style='text-align:center;'><font size='2'>© PT Semesta Citra Media</font></p>"
        Using mm As New MailMessage(emailAcc, "yudoharwendo@gmail.com")
            Try
                mm.Subject = RequestTittle
                mm.Body = Body
                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = emailHost
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential(emailAcc, emailPass)
                smtp.UseDefaultCredentials = True
                smtp.Credentials = NetworkCred
                smtp.Port = emailPort
                smtp.Send(mm)
                ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('The email has been successfully');", True)
            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email Not Delivered, There was a problem delivering your message to andri@tlt.co.id. See the technical details below');", True)
            End Try
        End Using
        DevExpress.Web.ASPxWebControl.RedirectOnCallback(Request.RawUrl)
    End Sub

    Protected Sub gridpengajuanuang_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridpengajuanuang.RowUpdating
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim tampungan As String = Session("ID")
        dsdetilpengajuan.UpdateCommand = "update trDetail_permintaanSPD set jumlahpengajuan = @jumlahpengajuan, tglpengajuan = @tglpengajuan, keterangan = @keterangan where idtbl = @idtbl"
        dsdetilpengajuan.DataBind()
        gridpengajuanuang.DataBind()
        DevExpress.Web.ASPxWebControl.RedirectOnCallback(Request.RawUrl)
    End Sub
End Class
