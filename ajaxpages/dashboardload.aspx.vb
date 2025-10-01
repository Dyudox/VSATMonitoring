Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

Partial Class ajaxpages_dashboardload
    Inherits System.Web.UI.Page
    Dim MyConnsosmed As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim MyConn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim MyConn1 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim MyConn2 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim myInsert, mySelect, mySelect2, myUpdate, com As SqlCommand
    Dim sqlDr, sqlDr2, sqlDrx As SqlDataReader
    Dim querySelectData, querySelectData2, dataNya, queryUpdateData As String
    Dim lastIDdesc, dataChart, dataClean As String
    Dim inqNya, reqNya, comNya, ootNya, dayNya, labelNya As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString("source") = "taskyesterday" Then
            Try
                MyConn.Open()
                'querySelectData = "select left(Tme, len(Tme)-3) as Tme,CategoryName,Jml from v_CreateTicketHours"
                querySelectData = "SELECT COUNT(trDetail_Task.NoListTask) as TOT, CONVERT(DATE, trTask.TanggalTask) as tanggal FROM  trDetail_Task " & _
                                "LEFT OUTER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask " & _
                                "where trTask.TanggalTask between DATEADD(day, -1, convert(date, GETDATE())) and  DATEADD(day, 0, convert(date, GETDATE())) " & _
                                "group by trTask.TanggalTask"
                mySelect = New SqlCommand(querySelectData, MyConn)
                sqlDr = mySelect.ExecuteReader()
                dataChart &= ""
                sqlDr.Read()
                If sqlDr.HasRows Then
                    dataChart &= "<div class='value'>" & sqlDr("TOT").ToString & "</div> " & _
                            "<div class='title'>Task Yesterday</div>"
                Else
                    dataChart &= "<div class='value'>0</div> " & _
                            "<div class='title'>Task Yesterday</div>"
                End If
                'dataChart &= "<div class='value'>" & sqlDr("TOT").ToString & "</div> " & _
                '            "<div class='title'>Task Yesterday</div>"

                sqlDr.Close()
                MyConn.Close()
                dataChart = dataChart.Substring(0, dataChart.Length)
                dataChart = dataChart & ""
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Response.Write(dataChart)

        ElseIf Request.QueryString("source") = "tasktoday" Then
            Try
                MyConn.Open()
                'querySelectData = "select left(Tme, len(Tme)-3) as Tme,CategoryName,Jml from v_CreateTicketHours"
                querySelectData = "SELECT COUNT(trDetail_Task.NoListTask) as TOT, CONVERT(DATE, trTask.TanggalTask) as tanggal FROM  trDetail_Task " & _
                                "LEFT OUTER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask " & _
                                "where trTask.TanggalTask between DATEADD(day, 0, convert(date, GETDATE())) and DATEADD(day, 1, convert(date, GETDATE()))" & _
                                "group by trTask.TanggalTask"
                mySelect = New SqlCommand(querySelectData, MyConn)
                sqlDr = mySelect.ExecuteReader()
                dataChart &= ""
                sqlDr.Read()
                If sqlDr.HasRows Then
                    dataChart &= "<div class='value'>" & sqlDr("TOT").ToString & "</div> " & _
                            "<div class='title'>Task Today</div>"

                Else
                    dataChart &= "<div class='value'>0</div> " & _
                         "<div class='title'>Task Today</div>"
                End If


                sqlDr.Close()
                MyConn.Close()
                dataChart = dataChart.Substring(0, dataChart.Length)
                dataChart = dataChart & ""
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Response.Write(dataChart)

        ElseIf Request.QueryString("source") = "tasktomorrow" Then
            Try
                MyConn.Open()
                'querySelectData = "select left(Tme, len(Tme)-3) as Tme,CategoryName,Jml from v_CreateTicketHours"
                querySelectData = "SELECT COUNT(trDetail_Task.NoListTask) as TOT, CONVERT(DATE, trTask.TanggalTask) as tanggal FROM  trDetail_Task " & _
                                "LEFT OUTER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask " & _
                                "where trTask.TanggalTask between DATEADD(day, 1, convert(date, GETDATE())) and DATEADD(day, 2, convert(date, GETDATE()))" & _
                                "group by trTask.TanggalTask"
                mySelect = New SqlCommand(querySelectData, MyConn)
                sqlDr = mySelect.ExecuteReader()
                dataChart &= ""
                sqlDr.Read()
                If sqlDr.HasRows Then
                    dataChart &= "<div class='value'>" & sqlDr("TOT").ToString & "</div> " & _
                            "<div class='title'>Task Tomorrow</div>"
                Else
                    dataChart &= "<div class='value'>0</div> " & _
                            "<div class='title'>Task Tomorrow</div>"
                End If
                sqlDr.Close()
                MyConn.Close()
                dataChart = dataChart.Substring(0, dataChart.Length)
                dataChart = dataChart & ""
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Response.Write(dataChart)

        ElseIf Request.QueryString("source") = "alltask" Then
            Try
                MyConn.Open()
                'querySelectData = "select left(Tme, len(Tme)-3) as Tme,CategoryName,Jml from v_CreateTicketHours"
                querySelectData = "SELECT   COUNT(trDetail_Task.NoListTask) as TOT FROM trDetail_Task INNER JOIN trTask ON trDetail_Task.NoTask = trTask.NoTask where trDetail_Task.VID <> ''"
                mySelect = New SqlCommand(querySelectData, MyConn)
                sqlDr = mySelect.ExecuteReader()
                dataChart &= ""
                sqlDr.Read()
                If sqlDr.HasRows Then
                    dataChart &= "<div class='value'>" & sqlDr("TOT").ToString & "</div> " & _
                            "<div class='title'>All Task</div>"
                Else
                    dataChart &= "<div class='value'>0</div> " & _
                            "<div class='title'>All Task</div>"
                End If
                sqlDr.Close()
                MyConn.Close()
                dataChart = dataChart.Substring(0, dataChart.Length)
                dataChart = dataChart & ""
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Response.Write(dataChart)

        ElseIf Request.QueryString("source") = "dataaktivitas" Then
            Try
                MyConn.Open()
                'querySelectData = "select left(Tme, len(Tme)-3) as Tme,CategoryName,Jml from v_CreateTicketHours"
                querySelectData = "select count(NoListTask) as tot, idJenisTask from trDetail_Task " & _
                                    "group by idJenisTask"
                mySelect = New SqlCommand(querySelectData, MyConn)
                sqlDr = mySelect.ExecuteReader()
                dataChart &= ""
                If sqlDr.HasRows Then
                    While sqlDr.Read()
                        dataChart &= "<tr>" & _
                                    "<td><b>" & sqlDr("idJenisTask").ToString & "</b></td>" & _
                                    "<td><span class='badge badge-info'>" & sqlDr("tot").ToString & "</span></td>" & _
                                "</tr>"
                    End While
                End If
                sqlDr.Close()
                MyConn.Close()
                dataChart = dataChart.Substring(0, dataChart.Length)
                dataChart = dataChart & ""
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Response.Write(dataChart)

        ElseIf Request.QueryString("source") = "datawilayah" Then
            Try
                MyConn.Open()
                'querySelectData = "select left(Tme, len(Tme)-3) as Tme,CategoryName,Jml from v_CreateTicketHours"
                querySelectData = "SELECT COUNT(trDetail_Task.NoListTask) as TOT, msProvinsi.Provinsi FROM trDetail_Task " & _
                                  "INNER JOIN msProvinsi ON trDetail_Task.PROVINSI = msProvinsi.Provinsi " & _
                                  "group by msProvinsi.Provinsi"
                mySelect = New SqlCommand(querySelectData, MyConn)
                sqlDr = mySelect.ExecuteReader()
                dataChart &= ""
                If sqlDr.HasRows Then
                    While sqlDr.Read()
                        dataChart &= "<tr>" & _
                                         "<td>" & sqlDr("Provinsi").ToString & "</td>" & _
                                         "<td>" & sqlDr("TOT").ToString & "</td>" & _
                                     "</tr>"
                    End While
                End If
                sqlDr.Close()
                MyConn.Close()
                dataChart = dataChart.Substring(0, dataChart.Length)
                dataChart = dataChart & ""
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
            Response.Write(dataChart)
        End If
    End Sub
End Class
