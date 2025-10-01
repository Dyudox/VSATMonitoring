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
Partial Class tasklistBootsraps
    Inherits System.Web.UI.Page
    Dim tampungan, tampungheader As String
    Dim con, con1, con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr, dr1, dr2 As SqlDataReader
    Dim com, com1, com2 As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If

        If Session("Level") = "Coordinator" Then
            Dim getdataopen As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(getdataopen, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lbl_open.Text = dr("tot").ToString
            Else
                dr.Read()
                lbl_open.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim dataonprogress As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "')
            com = New SqlCommand(dataonprogress, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblonprogress.Text = dr("tot").ToString
            Else
                dr.Read()
                lblonprogress.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datafinish As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "')
            com = New SqlCommand(datafinish, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblfinish.Text = dr("tot").ToString
            Else
                dr.Read()
                lblfinish.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim dataverified As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "')
            com = New SqlCommand(dataverified, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblverified.Text = dr("tot").ToString
            Else
                dr.Read()
                lblverified.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datareschedule As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "')
            com = New SqlCommand(datareschedule, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblreschedule.Text = dr("tot").ToString
            Else
                dr.Read()
                lblreschedule.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datapending As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Pending' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "')
            com = New SqlCommand(datapending, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblpending.Text = dr("tot").ToString
            Else
                dr.Read()
                lblpending.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datacancel As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
            com = New SqlCommand(datacancel, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblcancel.Text = dr("tot").ToString
            Else
                dr.Read()
                lblcancel.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim alldata As String = "SELECT SUM(tot) as tot from ( " & _
                                    "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task " & _
                                    "INNER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask " & _
                                    "INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID  " & _
                                    " where trtask.IdStatusManager = 'Valid' and trDetail_Task.VID <> '' GROUP BY msStatus.Status, IdStatusTask ) a"
            'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
            com = New SqlCommand(alldata, con)
            con.Open()
            dr = com.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                If dr("tot").ToString = "" Then

                    lblalldata.Text = 0

                Else

                    lblalldata.Text = dr("tot").ToString
                End If
            Else
                If dr("tot").ToString = "" Then

                    lblalldata.Text = 0

                Else

                    lblalldata.Text = dr("tot").ToString
                End If
            End If

            dr.Close()
            con.Close()

            If Request.QueryString("status") = "open" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask, " &
                                        "trDetail_Task.PROVINSI,trDetail_Task.NAMAREMOTE, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                        "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                        "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim open As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                        "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                        "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Open'  and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(open, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "onprogress" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask,trDetail_Task.NAMAREMOTE, " &
                                       "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim onprogress As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                                "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                                "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                                "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'On Progress' and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(onprogress, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "finish" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask, " &
                                       "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim finish As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                                "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                                "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                                "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Finish' and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(finish, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Obscatle" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask, " &
                                       "trDetail_Task.PROVINSI,trDetail_Task.NAMAREMOTE, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim verified As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                                "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                                "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                                "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Obscatle' and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(verified, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Reschedule" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask, " &
                                       "trDetail_Task.PROVINSI,trDetail_Task.NAMAREMOTE, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim reschedule As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                                "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                                "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                                "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Reschedule' and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(reschedule, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                  "<th>No. Task</th>" & _
                '                                  "<th class='text-center'>VID</th>" & _
                '                                  "<th>Tanggal Task</th>" & _
                '                                   "<th>Provinsi</th>" & _
                '                                  "<th>Order</th>" & _
                '                                  "<th>Koordinator</th>" & _
                '                                  "<th>Teknisi</th>" & _
                '                                  "<th>Status</th>" & _
                '                              "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Pending" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask, " &
                                       "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'pending' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim pending As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                                "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                                "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                                "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'pending' and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(pending, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Cancel" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask, " &
                                       "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim Cancel As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                                "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                                "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                                "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Cancel' and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(Cancel, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "all" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(datetime,trTask.TanggalTask) as TanggalTask, " &
                                       "trDetail_Task.PROVINSI,trDetail_Task.NAMAREMOTE, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " &
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " &
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and trDetail_Task.VID <> '' order by trTask.TanggalTask desc"
                'and (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') 
                gridtask.DataBind()
                '    Dim all As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                                "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                                "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                                "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where (trTask.IdKoordinator = '" & Session("username") & "' or trTask.NamaKoordinator = '" & Session("username") & "') and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(all, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan
            End If

        ElseIf Session("level") = "Teknisi" Then
            Dim getdataopen As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                      "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''" & _
                                      "GROUP BY msStatus.Status "
            com = New SqlCommand(getdataopen, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lbl_open.Text = dr("tot").ToString
            Else
                dr.Read()
                lbl_open.Text = 0
            End If

            dr.Close()
            con.Close()

            Dim dataonprogress As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(dataonprogress, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblonprogress.Text = dr("tot").ToString
            Else
                dr.Read()
                lblonprogress.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datafinish As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datafinish, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblfinish.Text = dr("tot").ToString
            Else
                dr.Read()
                lblfinish.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim dataverified As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(dataverified, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblverified.Text = dr("tot").ToString
            Else
                dr.Read()
                lblverified.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datareschedule As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datareschedule, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblreschedule.Text = dr("tot").ToString
            Else
                dr.Read()
                lblreschedule.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datapending As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Pending' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datapending, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblpending.Text = dr("tot").ToString
            Else
                dr.Read()
                lblpending.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datacancel As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datacancel, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblcancel.Text = dr("tot").ToString
            Else
                dr.Read()
                lblcancel.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim alldata As String = "select SUM(tot) as tot , 'All data' as status from ( " & _
                                    "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task " & _
                                    "INNER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask " & _
                                    "INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                    "where trtask.IdStatusManager = 'Valid' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> '' GROUP BY msStatus.Status, IdStatusTask ) a"
            com = New SqlCommand(alldata, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblalldata.Text = dr("tot").ToString
            Else
                dr.Read()
                lblalldata.Text = 0
            End If
            dr.Close()
            con.Close()

            If Request.QueryString("status") = "open" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                         "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open'  and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim open As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Open'  and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(open, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "onprogress" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                         "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim onprogress As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'On Progress' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(onprogress, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "finish" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                         "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim finish As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Finish' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(finish, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Obscatle" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                         "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim verified As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Obscatle' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(verified, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Reschedule" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                         "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim reschedule As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Reschedule' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(reschedule, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Pending" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                         "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'pending' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim pending As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'pending' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(pending, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Cancel" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                       "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                       "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                       "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim Cancel As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Cancel' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(Cancel, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "all" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                         "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                '    Dim all As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                         "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                         "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                         "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where (trTask.IdTeknisi = '" & Session("username") & "' or trTask.NamaTeknisi = '" & Session("username") & "' ) and trDetail_Task.VID <> ''"
                '    com = New SqlCommand(all, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                                 "<th>No. Task</th>" & _
                '                                 "<th class='text-center'>VID</th>" & _
                '                                 "<th>Tanggal Task</th>" & _
                '                                  "<th>Provinsi</th>" & _
                '                                 "<th>Order</th>" & _
                '                                 "<th>Koordinator</th>" & _
                '                                 "<th>Teknisi</th>" & _
                '                                 "<th>Status</th>" & _
                '                             "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                            "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                            "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                             "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                            "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                             "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                         "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan
            End If

        ElseIf Session("level") = "Helpdesk" Then
            Dim getdataopen As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan  <> '' " & _
                                        "GROUP BY msStatus.Status, trtask.NomorPengaduan"
            com = New SqlCommand(getdataopen, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lbl_open.Text = dr("tot").ToString
            Else
                dr.Read()
                lbl_open.Text = 0
            End If

            dr.Close()
            con.Close()

            Dim dataonprogress As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan  <> '' " & _
                                        "GROUP BY msStatus.Status, trtask.NomorPengaduan"
            com = New SqlCommand(dataonprogress, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblonprogress.Text = dr("tot").ToString
            Else
                dr.Read()
                lblonprogress.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datafinish As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> '' " & _
                                        "GROUP BY msStatus.Status, trtask.NomorPengaduan"
            com = New SqlCommand(datafinish, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblfinish.Text = dr("tot").ToString
            Else
                dr.Read()
                lblfinish.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim dataverified As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> '' " & _
                                        "GROUP BY msStatus.Status, trtask.NomorPengaduan"
            com = New SqlCommand(dataverified, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblverified.Text = dr("tot").ToString
            Else
                dr.Read()
                lblverified.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datareschedule As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> '' " & _
                                        "GROUP BY msStatus.Status, trtask.NomorPengaduan"
            com = New SqlCommand(datareschedule, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblreschedule.Text = dr("tot").ToString
            Else
                dr.Read()
                lblreschedule.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datapending As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Pending' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> '' " & _
                                        "GROUP BY msStatus.Status, trtask.NomorPengaduan"
            com = New SqlCommand(datapending, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblpending.Text = dr("tot").ToString
            Else
                dr.Read()
                lblpending.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datacancel As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> '' " & _
                                        "GROUP BY msStatus.Status, trtask.NomorPengaduan"
            com = New SqlCommand(datacancel, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblcancel.Text = dr("tot").ToString
            Else
                dr.Read()
                lblcancel.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim alldata As String = "SELECT SUM(tot) as total, 'all data' as status from ( " & _
                                    "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task " & _
                                    "INNER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask " & _
                                    "INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID  " & _
                                    "where trtask.IdStatusManager = 'Valid' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> '' GROUP BY msStatus.Status, IdStatusTask ) a"
            com = New SqlCommand(alldata, con)
            con.Open()
            dr = com.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                If dr("total").ToString = "" Then
                    lblalldata.Text = 0
                Else
                    lblalldata.Text = dr("total").ToString
                End If

            Else
                lblalldata.Text = 0

            End If
            dr.Close()
            con.Close()

            If Request.QueryString("status") = "open" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan,trDetail_Task.NAMAREMOTE, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open'  and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim open As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where msStatus.Status = 'Open'  and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(open, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                            "<th>No. Pengaduan</th>" & _
                '                            "<th class='text-center'>No Task</th>" & _
                '                            "<th>Tanggal Task</th>" & _
                '                            "<th>Alamat</th>" & _
                '                            "<th>Status</th>" & _
                '                        "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '        "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '        "<td style='width:100px'>" & dr("TanggalTask").ToString & "</td>" & _
                '         "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '     "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "onprogress" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan, trDetail_Task.NAMAREMOTE,trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim onprogress As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where msStatus.Status = 'On Progress' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(onprogress, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                           "<th>No. Pengaduan</th>" & _
                '                           "<th class='text-center'>No Task</th>" & _
                '                           "<th>Tanggal Task</th>" & _
                '                           "<th>Alamat</th>" & _
                '                           "<th>Status</th>" & _
                '                       "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '        "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '         "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '     "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "finish" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan, trDetail_Task.NAMAREMOTE,trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim finish As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where msStatus.Status = 'Finish' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(finish, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                          "<th>No. Pengaduan</th>" & _
                '                          "<th class='text-center'>No Task</th>" & _
                '                          "<th>Tanggal Task</th>" & _
                '                          "<th>Alamat</th>" & _
                '                          "<th>Status</th>" & _
                '                      "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                  "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '          "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '           "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '           "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '           "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '       "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Obscatle" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan, trDetail_Task.NAMAREMOTE,trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim verified As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where msStatus.Status = 'Obscatle' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(verified, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                          "<th>No. Pengaduan</th>" & _
                '                          "<th class='text-center'>No Task</th>" & _
                '                          "<th>Tanggal Task</th>" & _
                '                          "<th>Alamat</th>" & _
                '                          "<th>Status</th>" & _
                '                      "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                  "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '          "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '           "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '           "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '           "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '       "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Reschedule" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan, trDetail_Task.NAMAREMOTE,trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim reschedule As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where msStatus.Status = 'Reschedule' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(reschedule, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                         "<th>No. Pengaduan</th>" & _
                '                         "<th class='text-center'>No Task</th>" & _
                '                         "<th>Tanggal Task</th>" & _
                '                         "<th>Alamat</th>" & _
                '                         "<th>Status</th>" & _
                '                     "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '        "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '         "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '         "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '     "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Pending" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan, trDetail_Task.NAMAREMOTE,trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'pending' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim pending As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where msStatus.Status = 'pending' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(pending, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                        "<th>No. Pengaduan</th>" & _
                '                        "<th class='text-center'>No Task</th>" & _
                '                        "<th>Tanggal Task</th>" & _
                '                        "<th>Alamat</th>" & _
                '                        "<th>Status</th>" & _
                '                    "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '        "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '         "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '         "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '     "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Cancel" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan, trDetail_Task.NAMAREMOTE,trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim Cancel As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where msStatus.Status = 'Cancel' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(Cancel, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                       "<th>No. Pengaduan</th>" & _
                '                       "<th class='text-center'>No Task</th>" & _
                '                       "<th>Tanggal Task</th>" & _
                '                       "<th>Alamat</th>" & _
                '                       "<th>Status</th>" & _
                '                   "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                  "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '          "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '           "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '           "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '           "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '       "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "all" Then
                dstask.SelectCommand = "SELECT trTask.NomorPengaduan, trDetail_Task.NAMAREMOTE,trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trtask.IdStatusManager = 'Valid' and trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                gridtask.DataBind()
                '    Dim all As String = "SELECT trTask.NomorPengaduan, trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                        "trDetail_Task.ALAMAT, msStatus.Status AS StatusTask FROM trTask " & _
                '                        "LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask " & _
                '                        "LEFT OUTER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                '                        "LEFT OUTER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi where trTask.UserStamp = '" & Session("username") & "' and trTask.NomorPengaduan <> ''"
                '    com = New SqlCommand(all, con)
                '    con.Open()
                '    dr = com.ExecuteReader()
                '    If dr.HasRows Then
                '        tampungheader &= "<tr>" & _
                '                       "<th>No. Pengaduan</th>" & _
                '                       "<th class='text-center'>No Task</th>" & _
                '                       "<th>Tanggal Task</th>" & _
                '                       "<th>Alamat</th>" & _
                '                       "<th>Status</th>" & _
                '                   "</tr>"
                '        While dr.Read()
                '            tampungan &= "<tr class='odd gradeX'>" & _
                '                "<td align='center' style='width:100px'>" & dr("NomorPengaduan").ToString & "</a></td>" & _
                '        "<td align='center' style='width:100px'>" & dr("NoTask").ToString & "</a></td>" & _
                '         "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '         "<td style='width:100px'>" & dr("ALAMAT").ToString & "</td>" & _
                '         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '     "</tr>"
                '        End While
                '    End If
                '    dr.Close()
                '    con.Close()
                '    ltrheader.Text = tampungheader
                '    ltr_email.Text = tampungan
            End If

        Else
            Dim getdataopen As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(getdataopen, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lbl_open.Text = dr("tot").ToString
            Else
                dr.Read()
                lbl_open.Text = "0"
            End If

            dr.Close()
            con.Close()

            Dim dataonprogress As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(dataonprogress, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblonprogress.Text = dr("tot").ToString
            Else
                dr.Read()
                lblonprogress.Text = "0"
            End If
            dr.Close()
            con.Close()

            Dim datafinish As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datafinish, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblfinish.Text = dr("tot").ToString
            Else
                dr.Read()
                lblfinish.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim dataverified As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(dataverified, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblverified.Text = dr("tot").ToString
            Else
                dr.Read()
                lblverified.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datareschedule As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datareschedule, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblreschedule.Text = dr("tot").ToString
            Else
                dr.Read()
                lblreschedule.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datapending As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Pending' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datapending, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblpending.Text = dr("tot").ToString
            Else
                dr.Read()
                lblpending.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim datacancel As String = "SELECT COUNT(trDetail_Task.VID) as tot, msStatus.Status FROM  trDetail_Task INNER JOIN " & _
                                        "trTask ON trDetail_Task.NoTask = trTask.NoTask INNER JOIN msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID " & _
                                        "WHERE trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and trDetail_Task.VID <> ''" & _
                                        "GROUP BY msStatus.Status "
            com = New SqlCommand(datacancel, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblcancel.Text = dr("tot").ToString
            Else
                dr.Read()
                lblcancel.Text = 0
            End If
            dr.Close()
            con.Close()

            Dim alldata As String = "SELECT   COUNT(trDetail_Task.NoListTask) as tot FROM trDetail_Task INNER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask where trtask.IdStatusManager = 'Valid' and trDetail_Task.VID <> ''"
            com = New SqlCommand(alldata, con)
            con.Open()
            dr = com.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                lblalldata.Text = dr("tot").ToString
            Else
                dr.Read()
                lblalldata.Text = 0
            End If
            dr.Close()
            con.Close()

            If Request.QueryString("status") = "open" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.NAMAREMOTE,trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                    "trDetail_Task.PROVINSI,trDetail_Task.NAMAREMOTE, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Open' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim open As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Open' and trDetail_Task.VID <> ''"
                'com = New SqlCommand(open, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "onprogress" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.NAMAREMOTE,trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'On Progress' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim onprogress As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'On Progress' and trDetail_Task.VID <> ''"
                'com = New SqlCommand(onprogress, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "finish" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                    "trDetail_Task.PROVINSI,trDetail_Task.NAMAREMOTE, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Finish' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim finish As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Finish' and trDetail_Task.VID <> ''" & _
                '                    "ORDER BY id OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY"
                'com = New SqlCommand(finish, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Obscatle" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.NAMAREMOTE,trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                   "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                   "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                  "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Obstacle' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim verified As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Obscatle' and trDetail_Task.VID <> ''"
                'com = New SqlCommand(verified, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Reschedule" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.NAMAREMOTE,trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Reschedule' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim reschedule As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Reschedule' and trDetail_Task.VID <> ''"
                'com = New SqlCommand(reschedule, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Pending" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.NAMAREMOTE,trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'pending' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim pending As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'pending' and trDetail_Task.VID <> ''"
                'com = New SqlCommand(pending, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "Cancel" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                    "trDetail_Task.PROVINSI, trDetail_Task.NAMAREMOTE,trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and msStatus.Status = 'Cancel' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim Cancel As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where msStatus.Status = 'Cancel' and trDetail_Task.VID <> ''"
                'com = New SqlCommand(Cancel, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan

            ElseIf Request.QueryString("status") = "all" Then
                dstask.SelectCommand = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                                  "trDetail_Task.PROVINSI,trDetail_Task.NAMAREMOTE, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trtask.IdStatusManager = 'Valid' and trDetail_Task.VID <> ''"
                gridtask.DataBind()
                'Dim all As String = "SELECT trTask.NoTask, trDetail_Task.VID, trDetail_Task.NoListTask as ID, CONVERT(DATE,trTask.TanggalTask) as TanggalTask, " & _
                '                    "trDetail_Task.PROVINSI, trDetail_Task.idJenisTask, trTask.NamaKoordinator, trTask.NamaTeknisi, msStatus.Status AS StatusTask " & _
                '                    "FROM trTask LEFT OUTER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask LEFT OUTER JOIN " & _
                '                    "msStatus ON trDetail_Task.IdStatusPerbaikan = msStatus.ID where trDetail_Task.VID <> ''"
                'com = New SqlCommand(all, con)
                'con.Open()
                'dr = com.ExecuteReader()
                'If dr.HasRows Then
                '    tampungheader &= "<tr>" & _
                '                             "<th>No. Task</th>" & _
                '                             "<th class='text-center'>VID</th>" & _
                '                             "<th>Tanggal Task</th>" & _
                '                              "<th>Provinsi</th>" & _
                '                             "<th>Order</th>" & _
                '                             "<th>Koordinator</th>" & _
                '                             "<th>Teknisi</th>" & _
                '                             "<th>Status</th>" & _
                '                         "</tr>"
                '    While dr.Read()
                '        tampungan &= "<tr class='odd gradeX'>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("NoTask").ToString & "</a></td>" & _
                '                        "<td align='center' style='width:100px'><a href='createdetiltask.aspx?id=" & dr("ID").ToString & "&VID=" & dr("VID").ToString & "&NoTask=" & dr("NoTask").ToString & "'>" & dr("VID").ToString & "</a></td>" & _
                '                        "<td style='width:100px'>" & CDate(dr("TanggalTask").ToString) & "</td>" & _
                '                         "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
                '                        "<td style='width:100px'>" & dr("idJenisTask").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaKoordinator").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("NamaTeknisi").ToString & "</td>" & _
                '                         "<td style='width:100px'>" & dr("StatusTask").ToString & "</td>" & _
                '                     "</tr>"
                '    End While
                'End If
                'dr.Close()
                'con.Close()
                'ltrheader.Text = tampungheader
                'ltr_email.Text = tampungan
            End If
        End If


    End Sub


End Class
