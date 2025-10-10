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
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Partial Class formpenggunaanuang
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr, sqldr As SqlDataReader
    Dim com As SqlCommand
    Dim tbldata As DataTable
    Dim clsg As New cls_global
    Dim VID, NamaRemote, IPLAN, SID, ALamatInstall, strsql As String
    Dim tampung, NoSubtask As String
    Dim filePath As String = ConfigurationManager.AppSettings("filePath")
    Dim DocNo As String = "PSPD" & Now.Hour.ToString("D2") & Now.Year & Now.Minute.ToString("D2") & Now.Month.ToString("D2") & Now.Day.ToString("D2") & Now.Second.ToString("D2")


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If

        If Request.QueryString("order") = "new" Then
            txtnotask.Text = Request.QueryString("notask")
            txtnotask.Enabled = True
            txtvid.Visible = False
            cb_vid.Visible = True
            sql_ddVID.SelectCommand = "select vid,NAMAREMOTE from trDetail_Task where NoTask='" & Request.QueryString("notask") & "' group by vid,NAMAREMOTE"
            cb_vid.DataBind()
            If Request.QueryString("VID") <> Nothing Then
                cb_vid.Value = Request.QueryString("VID")
                room_image()
                getdataisi()
            End If
            btnupdate.Visible = False
            btnsimpan.Visible = True
        ElseIf Request.QueryString("order") = "edit" Then
            btnupdate.Visible = True
            btnsimpan.Visible = False
        End If

        If Request.QueryString("VID") <> Nothing Then
            txtvid.Visible = True
            cb_vid.Visible = False
            Dim cekconfirm = "select flagconfirm from tr_penggunaanSPD where NoTask = '" & Request.QueryString("notask") & "' and VID = '" & Request.QueryString("VID") & "'"
            com = New SqlCommand(cekconfirm, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                If dr("flagconfirm").ToString = True Then
                    btnsimpan.Visible = False
                    btnupdate.Visible = False
                    'btnconfirm.Enabled = False
                    btnconfirm.CssClass = "btn btn-info disabled"
                    cbjenispengeluaran.Attributes.Add("Readonly", "True")
                    txtcatatantransaksi.Attributes.Add("Readonly", "True")
                    txtnominal.Attributes.Add("Readonly", "True")

                Else
                    btnsimpan.Visible = True
                    'btnupdate.Visible = True
                    btnconfirm.Visible = True
                End If
            End If

            dr.Close()
            con.Close()

            btnupdate.Visible = False
            If Not Page.IsPostBack Then
                If Request.QueryString("status") = "edit" Then
                    tableisi.Visible = False
                    txtnotask.Text = Request.QueryString("notask")
                    txtvid.Text = Request.QueryString("VID")

                    btnsimpan.Visible = False
                    btnupdate.Visible = True

                    Session("jenpeng") = cbjenispengeluaran.Value
                    Session("Nomnom") = txtnominal.Text
                    Session("catatantransaksi") = txtcatatantransaksi.Text
                    Session("TglKwitansi") = tglkwitansi.Value


                    'Dim tahunkwitansi, bulankwitansi, tanggalkwitansi As String
                    'Dim valuekwitansi As System.DateTime
                    'If tglkwitansi.Value = "" Then
                    '    valuekwitansi = Date.Now
                    'Else
                    '    valuekwitansi = tglkwitansi.Value
                    'End If

                    'tahunkwitansi = valuekwitansi.Year.ToString()
                    'bulankwitansi = valuekwitansi.Month.ToString()
                    'tanggalkwitansi = valuekwitansi.Day.ToString()
                    'Session("TglKwitansi") = tahunkwitansi & "-" & bulankwitansi & "-" & tanggalkwitansi & ""

                    Dim getsuk As String = "select convert(date,TglInputBiaya) cTglInputBiaya,* from tr_penggunaanSPD where ID = " & Request.QueryString("ID") & ""
                    com = New SqlCommand(getsuk, con)
                    con.Open()
                    dr = com.ExecuteReader()
                    dr.Read()
                    cbjenispengeluaran.Text = dr("JenisBiaya").ToString
                    txtnominal.Text = dr("Nominal").ToString
                    txtcatatantransaksi.Text = dr("CatatanTransaksi").ToString
                    tglkwitansi.Value = dr("cTglInputBiaya")
                    Session("flagtime") = dr("flagtime").ToString
                    Session("DocNo") = dr("DocNo").ToString
                    dr.Close()
                    con.Close()
                End If
            End If


            If Request.QueryString("status") = "delete" Then
                Dim deletesuk As String = "delete from tr_penggunaanSPD where ID = " & Request.QueryString("ID") & ""
                com = New SqlCommand(deletesuk, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()

                Dim delefefoto As String = "delete from TRX_FILE where VID = '" & Request.QueryString("VID") & "' and Description = '" & Request.QueryString("jenpeng") & "'"
                com = New SqlCommand(delefefoto, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()

                Response.Redirect("formpenggunaanuang.aspx?VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "")
            End If

            Dim tampungan As String = ""

            txtnotask.Text = Request.QueryString("notask")
            txtvid.Text = Request.QueryString("VID")

            Dim getdataheader As String = "SELECT trTask.NamaTask, trDetail_Task.NAMAREMOTE, trDetail_Task.IPLAN, trDetail_Task.NoListTask, trDetail_Task.ALAMAT " & _
                                            "FROM  trTask INNER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask where trtask.notask = '" & Request.QueryString("notask") & "' and trdetail_task.VID = '" & Request.QueryString("VID") & "'"
            com = New SqlCommand(getdataheader, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            Dim flaggambar As String = dr("NoListTask").ToString
            txtnamatask.Text = dr("NamaTask").ToString
            txtnamaremote.Text = dr("NAMAREMOTE").ToString
            txtiplan.Text = dr("IPLAN").ToString
            txtlokasi.Text = dr("ALAMAT").ToString
            dr.Close()
            con.Close()

            If Request.QueryString("order") = "new" Then
                txtnotask.Text = Request.QueryString("notask")
                txtnotask.Enabled = True
                txtvid.Visible = False
                cb_vid.Visible = True
                sql_ddVID.SelectCommand = "select vid,NAMAREMOTE from trDetail_Task where NoTask='" & Request.QueryString("notask") & "' group by vid,NAMAREMOTE"
                cb_vid.DataBind()
                btnupdate.Visible = False
                btnsimpan.Visible = True
            ElseIf Request.QueryString("order") = "edit" Then
                btnupdate.Visible = True
                btnsimpan.Visible = False
            End If

            room_image()
            getdataisi()
        End If
    End Sub
    Private Sub getdataisi()

        Dim tampungan As String
        Dim getdataduit As String

        If Request.QueryString("order") = "new" Then
            getdataduit = "select convert(varchar,TglInputBiaya,103) as aa,format(convert(int,Nominal),'##,###') as fNominal,* from tr_penggunaanSPD where VID = '" & cb_vid.Value & "'"
        Else
            getdataduit = "select convert(varchar,TglInputBiaya,103) as aa,format(convert(int,Nominal),'##,###') as fNominal,* from tr_penggunaanSPD where VID = '" & Request.QueryString("VID") & "'"
        End If

        com = New SqlCommand(getdataduit, con)
        con.Open()
        dr = com.ExecuteReader
        While dr.Read
            If dr.HasRows Then
                If dr("flagconfirm").ToString = True Then
                    tampungan &= "<tr>" &
                                    "<td style='width:200px'>" & dr("JenisBiaya").ToString & "</td>" &
                                    "<td style='width:200px'>" & dr("fNominal").ToString & ",-</td>" &
                                    "<td style='width:200px'>" & dr("aa").ToString & "</td>" &
                                    "<td style='width:250px'>" & dr("CatatanTransaksi").ToString & "</td>" &
                                    "<td>" &
                                        "<a id='btnedit' runat='server' class='btn btn-success disabled' " &
                                        "href='#' style='text-align:center; pointer-events:none; opacity:0.5;'>Edit</a>&nbsp;&nbsp;" &
                                        "<a class='btn btn-danger disabled' href='#' style='text-align:center; pointer-events:none; opacity:0.5;'>Delete</a>" &
                                    "</td>" &
                                "</tr>"
                Else
                    tampungan &= "<tr>" & _
                                "<td style='width:200px'>" & dr("JenisBiaya").ToString & "</td>" & _
                                "<td style='width:200px'>" & dr("fNominal").ToString & ",-</td>" & _
                                "<td style='width:200px'>" & dr("aa").ToString & "</td>" & _
                                "<td style='width:250px'>" & dr("CatatanTransaksi").ToString & "</td>" & _
                                "<td>"
                    If Request.QueryString("order") = "new" Then
                        tampungan &= "<a id='btnedit' runat='server' style='align:center' href='formpenggunaanuang.aspx?order=edit&VID=" & cb_vid.Value & "&notask=" & Request.QueryString("notask") & "&status=edit&ID=" & dr("ID").ToString & "' class='btn btn-success'>Edit</a> &nbsp; &nbsp; " &
                                "<a href='formpenggunaanuang.aspx?order=new&VID=" & cb_vid.Value & "&notask=" & Request.QueryString("notask") & "&status=delete&ID=" & dr("ID").ToString & "&jenpeng=" & dr("JenisBiaya").ToString & "' style='align:center' class='btn btn-success' onclick='confirm_click();'>Delete</a></td>" &
                             "</tr>"
                    ElseIf Request.QueryString("order") = "edit" Then
                        tampungan &= "<a id='btnedit' runat='server' style='align:center' href='formpenggunaanuang.aspx?order=edit&VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "&status=edit&ID=" & dr("ID").ToString & "' class='btn btn-success'>Edit</a> &nbsp; &nbsp; " &
                                "<a href='formpenggunaanuang.aspx?order=edit&VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "&status=delete&ID=" & dr("ID").ToString & "&jenpeng=" & dr("JenisBiaya").ToString & "' style='align:center' class='btn btn-success' onclick='confirm_click();'>Delete</a></td>" &
                             "</tr>"
                    Else
                        tampungan &= "<a id='btnedit' runat='server' style='align:center' href='formpenggunaanuang.aspx?VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "&status=edit&ID=" & dr("ID").ToString & "' class='btn btn-success'>Edit</a> &nbsp; &nbsp; " &
                                "<a href='formpenggunaanuang.aspx?VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "&status=delete&ID=" & dr("ID").ToString & "&jenpeng=" & dr("JenisBiaya").ToString & "' style='align:center' class='btn btn-success' onclick='confirm_click();'>Delete</a></td>" &
                             "</tr>"
                    End If
                End If
                
            End If
        End While
        dr.Close()
        con.Close()

        ltrisi.Text = tampungan

    End Sub

    Private Sub room_image()
        'Dim strGambar As String
        Dim img As String = ""
        'strGambar = "select * from trx_file where VID='" & Request.QueryString("VID") & "'"
        'Try
        '    com = New SqlCommand(strGambar, con)
        '    con.Open()
        '    sqldr = com.ExecuteReader()
        '    'sqldr.Read()
        '    img = "<ul style='left: 0px; top: 0px;'>"
        '    While sqldr.Read()
        '        img &= "<li style='width: 200px; height:400px; text-align:center'>" &
        '                    "<a href=UploadFoto/20181106014824neonbox.jpg><img src=UploadFoto/20181106014824neonbox.jpg></a>" & _
        '                    "<label style='color:Black'><b>" & sqldr("Description").ToString & "</b></label>" & _
        '                    "<p>" & sqldr("Keterangan").ToString & "</p>" & _
        '                    "<center><a class='label label-success' style='width:50%; align:center' href='editfoto.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&filename=" & sqldr("file_url") & "'>Edit</a></center>" & _
        '                    "<center><a class='label label-danger' onclick='if (!UserCustomerConfirmation()) return false;' style='width:50%; align:center' href='createdetiltask.aspx?id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "&status=delete&filename=" & sqldr("file_url") & "'>Delete</a></center>" & _
        '               "</li> &nbsp;&nbsp;"
        '    End While
        '    img &= "</ul>"
        '    sqldr.Close()
        '    con.Close()
        'Catch ex As Exception
        '    Response.Write(ex.Message)
        'End Try

        'Dim getgambar As String = "SELECT TRX_FILE.file_url, TRX_FILE.Description, tr_penggunaanSPD.VID, tr_penggunaanSPD.CatatanTransaksi FROM tr_penggunaanSPD " & _
        '                        "INNER JOIN TRX_FILE ON tr_penggunaanSPD.VID = TRX_FILE.VID and tr_penggunaanSPD.VID = TRX_FILE.VID and tr_penggunaanSPD.flagtime = " & _
        '                        "TRX_FILE.flagtime where tr_penggunaanSPD.VID='" & Request.QueryString("VID") & "' and Keterangan='Penggunaan Uang SPD'"
        Dim getgambar As String
        If Request.QueryString("order") = "new" Then
            getgambar = "SELECT TRX_FILE.file_url, TRX_FILE.Description, tr_penggunaanSPD.VID, tr_penggunaanSPD.CatatanTransaksi FROM tr_penggunaanSPD " & _
        "INNER JOIN TRX_FILE ON tr_penggunaanSPD.DocNo = TRX_FILE.DocNo where tr_penggunaanSPD.VID='" & cb_vid.Value & "' and TRX_FILE.file_url is not null"
        Else
            getgambar = "SELECT TRX_FILE.file_url, TRX_FILE.Description, tr_penggunaanSPD.VID, tr_penggunaanSPD.CatatanTransaksi FROM tr_penggunaanSPD " & _
        "INNER JOIN TRX_FILE ON tr_penggunaanSPD.DocNo = TRX_FILE.DocNo where tr_penggunaanSPD.VID='" & Request.QueryString("VID") & "' and TRX_FILE.file_url is not null"
        End If

        Try
            com = New SqlCommand(getgambar, con)
            con.Open()
            dr = com.ExecuteReader()
            img &= "<ul style='left: 0px; top: 0px;'>"
            While dr.Read
                img &= "<li style='width: 250px; height:250px; text-align:center'>" &
                     "<a href=" & dr("file_url").ToString & " data-lightbox='example-1'><img width='200px' height='200px' src=" & dr("file_url").ToString & "></a>" & _
                "<label style='color:Black'><b>" & dr("Description").ToString & "</b></label>" & _
                 "</li> &nbsp;&nbsp;"
                '"<div class='gallery-container'>" &
                    '"<div class='gallery-item'>" &
                    '"<a class='image-wrapper gallery-zoom' href=" & dr("file_url").ToString & ">" & dr("file_url").ToString & "</a>" &
                    '    "<img src='" & dr("file_url").ToString & ">" &
                    '        "<div class='image-overlay'>" &
                    '            "<div class='image-info'>" &
                    '                "<div class='h3'>" & dr("Description").ToString & "</div>" &
                    '                "<span>" & dr("CatatanTransaksi").ToString & "</span>" &
                    '            "</div>" &
                    '        "</div>" &
                    '    "</img>" &
                    '"</div>" &
                    '"</div>" &

               

            End While
            dr.Close()
            con.Close()
            img &= "</ul>"
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        'img &= "<ul style='left: 0px; top: 0px;'>" & _
        '        "<li style='width: 200px; height:200px; text-align:center'>" &
        '                    "<a href=UploadFoto/20181106014824neonbox.jpg><img src=UploadFoto/20181106014824neonbox.jpg></a>" & _
        '                    "<label style='color:Black'><b>Judul Gambar</b></label>" & _
        '               "</li> &nbsp;&nbsp;" & _
        ' "</ul>"
        ltr_image_room.Text = img
    End Sub


    Protected Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        
        Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
        Dim path As String = Server.MapPath("~/UploadFoto/")

        'Dim tahunkwitansi, bulankwitansi, tanggalkwitansi As String
        'Dim valuekwitansi As System.DateTime
        'If tglkwitansi.Value = "" Then
        '    valuekwitansi = Date.Now
        'Else
        '    valuekwitansi = tglkwitansi.Value
        'End If

        'tahunkwitansi = valuekwitansi.Year.ToString()
        'bulankwitansi = valuekwitansi.Month.ToString()
        'tanggalkwitansi = valuekwitansi.Day.ToString()
        'Dim kwitansisuk As String = tahunkwitansi & "-" & bulankwitansi & "-" & tanggalkwitansi & ""
        If Request.QueryString("order") = "new" Then
            '"update tr_penggunaanSPD set ApprovalNominal = @ApprovalNominal, TglApproveBiaya = GETDATE(), Status = @Status, CatatanApproval = @CatatanApproval where ID = @ID"
            'strsql = "select * from trTask where notask='" & Request.QueryString("NoTask") & "' and idproject='" & cb_vid.Value & "'"
            strsql = "select NamaTeknisi from trTask a inner join trDetail_Task b on a.NoTask=b.NoTask " & _
            "where b.notask='" & Request.QueryString("NoTask") & "' and b.vid='" & cb_vid.Value & "'"
            tbldata = clsg.ExecuteQuery(strsql)

            If IsNothing(tbldata) Then
                Exit Sub
            End If

            If IsDBNull(tbldata.Rows(0).Item("NamaTeknisi")) Then
                Exit Sub
            End If

            strsql = "insert into tr_penggunaanSPD (NoTask, VID, NamaTeknisi, JenisBiaya, Nominal, TglInputBiaya, NamaRemote, IPLAN, CatatanTransaksi, flagtime,DocNo, " & _
                "ApprovalNominal,TglApproveBiaya,Status,CatatanApproval,userstamp) VALUES " & _
                    "('" & Request.QueryString("NoTask") & "', '" & cb_vid.Value & "', '" & tbldata.Rows(0).Item("NamaTeknisi") & "', '" &
                    cbjenispengeluaran.Value & "', '" & txtnominal.Text & "', '" & tglkwitansi.Value & "', '" & txtnamaremote.Text & "', '" &
                    txtiplan.Text & "', '" & clsg.ReplacePetik(txtcatatantransaksi.Text) & "',convert(VARCHAR(10), getdate(), 108),'" & DocNo & "', " & _
                    "'" & txtnominal.Text & "',getdate(),'Approve','" & clsg.ReplacePetik(txtcatatantransaksi.Text) & "','" & Session("username") & "')"
            clsg.ExecuteNonQuery(strsql)

        Else
            Dim simpantransaksi As String = "insert into tr_penggunaanSPD (NoTask, VID, NamaTeknisi, JenisBiaya, Nominal, TglInputBiaya, NamaRemote, IPLAN, CatatanTransaksi, flagtime,DocNo) VALUES " & _
                                        "('" & Request.QueryString("NoTask") & "', '" & Request.QueryString("VID") & "', '" & Session("username") & "', '" & cbjenispengeluaran.Value & "', '" &
                                        txtnominal.Text & "', '" & tglkwitansi.Value & "', '" & txtnamaremote.Text & "', '" & txtiplan.Text & "', '" & clsg.ReplacePetik(txtcatatantransaksi.Text) & "', " & _
                                        "convert(VARCHAR(10), getdate(), 108),'" & DocNo & "')"
            com = New SqlCommand(simpantransaksi, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        End If
        Dim insertpath As String
        If FileUpload1.HasFile Then
            Try
                FileUpload1.SaveAs(path + Time + Replace(FileUpload1.FileName, " ", "_"))
            Catch ex As Exception
                Response.Write(DirectCast("", String))
            End Try
            If Request.QueryString("order") = "new" Then
                insertpath = "Insert into TRX_FILE (file_url, file_usercreate, file_datecreate, VID, Description, Keterangan, flagtime,DocNo) VALUES " & _
                                        "('UploadFoto/" & Time + Replace(FileUpload1.FileName, " ", "_") & "', '" & Session("username") & "', GETDATE(), '" & cb_vid.Value & "', '" &
                                        cbjenispengeluaran.Text & "', 'Penggunaan Uang SPD', convert(VARCHAR(10), getdate(), 108),'" & DocNo & "')"
                strsql = "update trDetail_Task set FlagUploadPhoto=1 where NoTask='" & Request.QueryString("NoTask") & "' and vid='" & cb_vid.Value & "'"
                clsg.ExecuteNonQuery(strsql)

                strsql = "update tr_penggunaanSPD set flagupload='true' where NoTask='" & Request.QueryString("NoTask") & "' and vid='" & cb_vid.Value & "'"
                clsg.ExecuteNonQuery(strsql)
            Else
                insertpath = "Insert into TRX_FILE (file_url, file_usercreate, file_datecreate, VID, Description, Keterangan, flagtime,DocNo) VALUES " & _
                                        "('UploadFoto/" & Time + Replace(FileUpload1.FileName, " ", "_") & "', '" & Session("username") & "', GETDATE(), '" & Request.QueryString("VID") & "', '" &
                                        cbjenispengeluaran.Text & "', 'Penggunaan Uang SPD', convert(VARCHAR(10), getdate(), 108),'" & DocNo & "')"
                strsql = "update trDetail_Task set FlagUploadPhoto=1 where NoTask='" & Request.QueryString("NoTask") & "' and vid='" & Request.QueryString("VID") & "'"
                clsg.ExecuteNonQuery(strsql)

                strsql = "update tr_penggunaanSPD set flagupload='true' where NoTask='" & Request.QueryString("NoTask") & "' and vid='" & Request.QueryString("VID") & "'"
                clsg.ExecuteNonQuery(strsql)
            End If
        Else
            insertpath = "Insert into TRX_FILE ( file_usercreate, file_datecreate, VID, Description, Keterangan, flagtime,DocNo) VALUES " & _
            "( '" & Session("username") & "', GETDATE(), '" & cb_vid.Value & "', '" &
             cbjenispengeluaran.Text & "', 'Penggunaan Uang SPD', convert(VARCHAR(10), getdate(), 108),'" & DocNo & "')"
        End If
        com = New SqlCommand(insertpath, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        
        getdataisi()
        room_image()
       
        If Request.QueryString("VID") <> Nothing Then
            Response.Redirect(Request.Url.AbsoluteUri)
        Else
            Response.Redirect(Request.Url.AbsoluteUri & "&VID=" & cb_vid.Value)
        End If
    End Sub

    Protected Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim Time As String = DateTime.Now.ToString("yyyyMMddhhmmss")
        Dim path As String = Server.MapPath("~/UploadFoto/")

        strsql = "select * from tr_penggunaanSPD where VID ='" & Request.QueryString("VID") & "' and NoTask='" & Request.QueryString("NoTask") & "'"
        tbldata = clsg.ExecuteQuery(strsql)

        If FileUpload1.HasFile Then
            Try
                FileUpload1.SaveAs(path + Time + Replace(FileUpload1.FileName, " ", "_"))
            Catch ex As Exception
                Response.Write(DirectCast("", String))
            End Try
            Dim updatepath As String
            If IsDBNull(tbldata.Rows(0).Item("flagupload")) Then
                updatepath = "Insert into TRX_FILE (file_url, file_usercreate, file_datecreate, VID, Description, Keterangan, flagtime,DocNo) VALUES " & _
                                        "('UploadFoto/" & Time + Replace(FileUpload1.FileName, " ", "_") & "', '" & Session("username") & "', GETDATE(), '" & cb_vid.Value & "', '" &
                                        cbjenispengeluaran.Text & "', 'Penggunaan Uang SPD', convert(VARCHAR(10), getdate(), 108),'" & Session("DocNo") & "')"
            Else
                updatepath = "update TRX_FILE set file_url = 'UploadFoto/" & Time + Replace(FileUpload1.FileName, " ", "_") & "', file_usercreate = '" &
                Session("username") & "', file_datecreate =  GETDATE() where VID = '" & Request.QueryString("VID") & "' and DocNo='" & Session("DocNo") & "'"
            End If
            
            'Dim insertpath As String = "Insert into TRX_FILE (file_url, file_usercreate, file_datecreate, VID, Description, Keterangan) VALUES " & _
            '                            "('UploadFoto/" & Time + FileUpload1.FileName & "', '" & Session("username") & "', GETDATE(), '" & Request.QueryString("VID") & "', '" & cbjenispengeluaran.Text & "', 'Penggunaan Uang SPD')"
            com = New SqlCommand(updatepath, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Else
            Dim updatepath As String = "update TRX_FILE set file_usercreate = '" & Session("username") & "', file_datecreate =  GETDATE(), Description = '" &
                Session("jenpeng") & "' where VID = '" & Request.QueryString("VID") & "' and DocNo='" & Session("DocNo") & "'"
            'Dim insertpath As String = "Insert into TRX_FILE (file_url, file_usercreate, file_datecreate, VID, Description, Keterangan) VALUES " & _
            '                            "('UploadFoto/" & Time + FileUpload1.FileName & "', '" & Session("username") & "', GETDATE(), '" & Request.QueryString("VID") & "', '" & cbjenispengeluaran.Text & "', 'Penggunaan Uang SPD')"
            com = New SqlCommand(updatepath, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()

        End If

        '
        If Request.QueryString("order") = "edit" Then
            If Session("level") <> "Teknisi" Then

                If tbldata.Rows(0).Item("userStamp") = Session("username") Then
                    strsql = "update tr_penggunaanSPD set ApprovalNominal = '" & txtnominal.Text & "', Nominal='" & txtnominal.Text & "', TglApproveBiaya = GETDATE(), Status = 'Approve', CatatanApproval = '" & clsg.ReplacePetik(txtcatatantransaksi.Text) & "' " & _
               ", DocNo='" & Session("DocNo") & "' where VID ='" & Request.QueryString("VID") & "' and NoTask='" & Request.QueryString("NoTask") & "'"
                Else
                    strsql = "update tr_penggunaanSPD set Nominal = '" & txtnominal.Text & "', TglApproveBiaya = GETDATE(), Status = 'Approve', CatatanApproval = '" & clsg.ReplacePetik(txtcatatantransaksi.Text) & "' " & _
               ", DocNo='" & Session("DocNo") & "' where VID ='" & Request.QueryString("VID") & "' and NoTask='" & Request.QueryString("NoTask") & "'"
                End If
            End If

            clsg.ExecuteNonQuery(strsql)
        Else
            Dim updatedata As String = "update tr_penggunaanSPD set JenisBiaya='" & cbjenispengeluaran.Value & "', Nominal='" & txtnominal.Text & "', TglInputBiaya='" &
                tglkwitansi.Value & "',CatatanTransaksi='" & clsg.ReplacePetik(txtcatatantransaksi.Text) & "' where ID = '" & Request.QueryString("ID") & "' and DocNo='" & Session("DocNo") & "'"
            com = New SqlCommand(updatedata, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        End If

        Response.Redirect("formpenggunaanuang.aspx?VID=" & Request.QueryString("VID") & "&notask=" & Request.QueryString("notask") & "")
    End Sub

    Protected Sub btnconfirm_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        Dim updateflag As String = "update tr_penggunaanSPD set flagconfirm = '1' where NoTask = '" & Request.QueryString("notask") & "' and VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(updateflag, con)
        con.Open()
        com.ExecuteNonQuery()
        con.Close()

        Dim cekconfirm = "select flagconfirm from tr_penggunaanSPD where NoTask = '" & Request.QueryString("notask") & "' and VID = '" & Request.QueryString("VID") & "'"
        com = New SqlCommand(cekconfirm, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        If dr("flagconfirm").ToString = True Then
            btnsimpan.Visible = False
            btnupdate.Visible = False
            btnconfirm.Enabled = False
            cbjenispengeluaran.Attributes.Add("Readonly", "True")
            txtcatatantransaksi.Attributes.Add("Readonly", "True")
            txtnominal.Attributes.Add("Readonly", "True")
            'tglkwitansi.Attribute.Add("disabled")
        Else
            btnsimpan.Visible = True
            'btnupdate.Visible = True
            btnconfirm.Enabled = True
        End If
        dr.Close()
        con.Close()
        getdataisi()
    End Sub

    Protected Sub cb_vid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_vid.SelectedIndexChanged
        strsql = "select * from trTask a inner join trDetail_Task b " &
        "on a.NoTask=b.NoTask where b.NoTask='" & Request.QueryString("notask") & "' and b.VID='" & cb_vid.Value & "'"
        tbldata = clsg.ExecuteQuery(strsql)
        If IsNothing(tbldata) = False Then
            If tbldata.Rows.Count > 0 Then
                txtnamatask.Text = tbldata.Rows(0).Item("NamaTask").ToString
                txtnamaremote.Text = tbldata.Rows(0).Item("NAMAREMOTE").ToString
                txtiplan.Text = tbldata.Rows(0).Item("IPLAN").ToString
                txtlokasi.Text = tbldata.Rows(0).Item("ALAMAT").ToString
                getdataisi()
                room_image()
            End If
        Else
            clsg.writedata("Formpenggunaanuang.aspx", "Cari VID", Session("Error"), cb_vid.Value, strsql)
        End If


    End Sub

    Protected Sub btn_exportTxt_Click(sender As Object, e As EventArgs)

        Try
            ' === Path penyimpanan ===
            Dim folderPath As String = "~/Export_Txt/"
            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            ' === Nama file export ===
            Dim fileName As String = "Export_Data_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)

            ' === Header kolom ===
            Dim headers() As String = {"Pengeluaran", "Nominal", "Tanggal", "Note"}

            ' === Ambil data dari Literal ===
            Dim htmlContent As String = ltrisi.Text.Trim()
            If String.IsNullOrEmpty(htmlContent) Then
                Response.Write("<script>alert('Tidak ada data untuk diexport');</script>")
                Exit Sub
            End If

            ' === Bersihkan HTML ke format teks ===
            htmlContent = Regex.Replace(htmlContent, "</tr\s*>", vbCrLf, RegexOptions.IgnoreCase)
            htmlContent = Regex.Replace(htmlContent, "</td\s*>", "|", RegexOptions.IgnoreCase)
            htmlContent = Regex.Replace(htmlContent, "<.*?>", "")
            htmlContent = System.Net.WebUtility.HtmlDecode(htmlContent)
            htmlContent = htmlContent.Replace("&nbsp;", " ").Trim()

            ' === Pisahkan ke baris dan kolom ===
            Dim lines = htmlContent.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
            Dim rows As New List(Of String())
            For Each line In lines
                Dim parts = line.Split({"|"}, StringSplitOptions.RemoveEmptyEntries)
                If parts.Length > 0 Then rows.Add(parts.Select(Function(x) x.Trim()).ToArray())
            Next

            ' === Hitung lebar kolom ===
            Dim colWidths(headers.Length - 1) As Integer
            For i = 0 To headers.Length - 1
                colWidths(i) = headers(i).Length
            Next
            For Each row In rows
                For i = 0 To Math.Min(row.Length, headers.Length) - 1
                    colWidths(i) = Math.Max(colWidths(i), row(i).Length)
                Next
            Next

            ' === Format teks sejajar ===
            Dim sb As New StringBuilder()
            For i = 0 To headers.Length - 1
                sb.Append(headers(i).PadRight(colWidths(i) + 2))
                If i < headers.Length - 1 Then sb.Append("| ")
            Next
            sb.AppendLine()
            sb.AppendLine(New String("-"c, sb.Length - 2))

            For Each row In rows
                For i = 0 To headers.Length - 1
                    Dim val As String = If(i < row.Length, row(i), "")
                    sb.Append(val.PadRight(colWidths(i) + 2))
                    If i < headers.Length - 1 Then sb.Append("| ")
                Next
                sb.AppendLine()
            Next

            ' === Simpan file TXT ===
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)

            ' === Simpan log export ===
            Dim logFolder As String = Path.Combine(folderPath, "Logs")
            If Not Directory.Exists(logFolder) Then
                Directory.CreateDirectory(logFolder)
            End If

            Dim logPath As String = Path.Combine(logFolder, "export_log_" & DateTime.Now.ToString("yyyyMM") & ".log")
            ' aman ambil username dari session (fallback ke "Unknown" kalau kosong)
            Dim userName As String = "Unknown"
            If Session IsNot Nothing AndAlso Session("username") IsNot Nothing Then
                userName = Session("username").ToString()
            ElseIf HttpContext.Current IsNot Nothing AndAlso HttpContext.Current.User IsNot Nothing AndAlso HttpContext.Current.User.Identity IsNot Nothing AndAlso HttpContext.Current.User.Identity.Name IsNot Nothing Then
                userName = HttpContext.Current.User.Identity.Name
            End If

            Dim logText As String = String.Format("{0} | User: {1} | File: {2} | Rows: {3}{4}",
                                              DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                              userName,
                                              fileName,
                                              rows.Count,
                                              Environment.NewLine)

            File.AppendAllText(logPath, logText, Encoding.UTF8)

            ' === Redirect ke handler download (handler harus ada: DownloadTxt.ashx) ===
            Dim downloadUrl As String = "DownloadTxt.ashx?file=" & HttpUtility.UrlEncode(fileName)
            Response.Redirect(downloadUrl, False)
            HttpContext.Current.ApplicationInstance.CompleteRequest()

        Catch ex As Exception
            Response.Write("<script>alert('Gagal export: " & ex.Message.Replace("'", "") & "');</script>")
        End Try

        'Try
        '    ' === Path penyimpanan ===
        '    Dim folderPath As String = "D:\OfficeSelindo\Backup server\BackupVsat\Export_Txt\"
        '    If Not Directory.Exists(folderPath) Then
        '        Directory.CreateDirectory(folderPath)
        '    End If

        '    ' === Nama file export ===
        '    Dim fileName As String = "Export_Data_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
        '    Dim filePath As String = Path.Combine(folderPath, fileName)

        '    ' === Header kolom ===
        '    Dim headers() As String = {"Pengeluaran", "Nominal", "Tanggal", "Note"}

        '    ' === Ambil data dari Literal ===
        '    Dim htmlContent As String = ltrisi.Text.Trim()
        '    If String.IsNullOrEmpty(htmlContent) Then
        '        Response.Write("<script>alert('Tidak ada data untuk diexport');</script>")
        '        Exit Sub
        '    End If

        '    ' === Bersihkan HTML ke format teks ===
        '    htmlContent = Regex.Replace(htmlContent, "</tr\s*>", vbCrLf, RegexOptions.IgnoreCase)
        '    htmlContent = Regex.Replace(htmlContent, "</td\s*>", "|", RegexOptions.IgnoreCase)
        '    htmlContent = Regex.Replace(htmlContent, "<.*?>", "")
        '    htmlContent = System.Net.WebUtility.HtmlDecode(htmlContent)
        '    htmlContent = htmlContent.Replace("&nbsp;", " ").Trim()

        '    ' === Pisahkan ke baris dan kolom ===
        '    Dim lines = htmlContent.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        '    Dim rows As New List(Of String())
        '    For Each line In lines
        '        Dim parts = line.Split({"|"}, StringSplitOptions.RemoveEmptyEntries)
        '        If parts.Length > 0 Then rows.Add(parts.Select(Function(x) x.Trim()).ToArray())
        '    Next

        '    ' === Hitung lebar kolom ===
        '    Dim colWidths(headers.Length - 1) As Integer
        '    For i = 0 To headers.Length - 1
        '        colWidths(i) = headers(i).Length
        '    Next
        '    For Each row In rows
        '        For i = 0 To Math.Min(row.Length, headers.Length) - 1
        '            colWidths(i) = Math.Max(colWidths(i), row(i).Length)
        '        Next
        '    Next

        '    ' === Format teks sejajar ===
        '    Dim sb As New StringBuilder()
        '    For i = 0 To headers.Length - 1
        '        sb.Append(headers(i).PadRight(colWidths(i) + 2))
        '        If i < headers.Length - 1 Then sb.Append("| ")
        '    Next
        '    sb.AppendLine()
        '    sb.AppendLine(New String("-"c, sb.Length - 2))

        '    For Each row In rows
        '        For i = 0 To headers.Length - 1
        '            Dim val As String = If(i < row.Length, row(i), "")
        '            sb.Append(val.PadRight(colWidths(i) + 2))
        '            If i < headers.Length - 1 Then sb.Append("| ")
        '        Next
        '        sb.AppendLine()
        '    Next

        '    ' === Simpan file ===
        '    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)

        '    ' === Redirect ke handler download ===
        '    Dim downloadUrl As String = "DownloadTxt.ashx?file=" & fileName
        '    Response.Redirect(downloadUrl, False)
        '    HttpContext.Current.ApplicationInstance.CompleteRequest()

        'Catch ex As Exception
        '    Response.Write("<script>alert('Gagal export: " & ex.Message.Replace("'", "") & "');</script>")
        'End Try

    End Sub


    'Protected Sub btn_exportTxt_Click(sender As Object, e As EventArgs)
    '    ' Ambil isi literal
    '    Dim content As String = ltrisi.Text.Trim()

    '    If String.IsNullOrEmpty(content) Then
    '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Tidak ada data untuk diexport.');", True)
    '        Exit Sub
    '    End If

    '    ' Ubah HTML <td> dan <tr> jadi teks biasa
    '    Dim plainText As String = content
    '    plainText = plainText.Replace("<tr>", "").Replace("</tr>", vbCrLf)
    '    plainText = plainText.Replace("<td>", "").Replace("</td>", " | ")
    '    plainText = plainText.Replace("&nbsp;", " ")

    '    ' Simpan ke file sementara di folder Temp
    '    Dim fileName As String = "DataPengeluaran_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
    '    Dim folderPath As String = Server.MapPath("~/Temp/")

    '    If Not Directory.Exists(folderPath) Then
    '        Directory.CreateDirectory(folderPath)
    '    End If

    '    Dim filePath As String = Path.Combine(folderPath, fileName)
    '    File.WriteAllText(filePath, plainText, Encoding.UTF8)

    '    ' Kirim ke browser
    '    Response.Clear()
    '    Response.ContentType = "text/plain"
    '    Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
    '    Response.TransmitFile(filePath)
    '    Response.Flush()
    '    HttpContext.Current.ApplicationInstance.CompleteRequest()
    'End Sub

End Class
