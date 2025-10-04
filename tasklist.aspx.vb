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
Partial Class tasklist
    Inherits System.Web.UI.Page
    Dim tampungan As String
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        dstasklist.SelectCommand = "SELECT trTask.NoTask, CONVERT(date, trTask.TanggalTask) as tanggal, msProvinsi.Provinsi, trTask.IdKoordinator, trTask.IdTeknisi, COUNT(NoTask) as tot " & _
                                    "FROM trTask INNER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi INNER JOIN msStatus ON trTask.IdStatusTask = msStatus.ID where IdStatusTask <> '5' " & _
                                    "group by trTask.NoTask, CONVERT(date, trTask.TanggalTask), msProvinsi.Provinsi, trTask.IdKoordinator, trTask.IdTeknisi"
        'Dim getdata As String = "SELECT trTask.NoTask, trtask.NoSubTask, CONVERT(date, trTask.TanggalTask) as TanggalTask, msProvinsi.Provinsi, trTask.IdKoordinator, trTask.IdStatusTask, trTask.IdTeknisi, msStatus.Status " & _
        '                        "FROM trTask INNER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi INNER JOIN msStatus ON trTask.IdStatusTask = msStatus.ID where IdStatusTask <> '5'"
        'com = New SqlCommand(getdata, con)
        'con.Open()
        'dr = com.ExecuteReader()
        'If dr.HasRows Then
        '    While dr.Read()
        '        tampungan &= "<tr class='odd gradeX'>" & _
        '            "<td align='center' style='width:100px'><a href='createdetiltask.aspx'>" & dr("NoTask").ToString & "</a></td>" & _
        '             "<td style='width:100px' align='center'>" & dr("NoSubTask").ToString & "</td>" & _
        '            "<td style='width:100px'>" & dr("TanggalTask").ToString & "</td>" & _
        '            "<td style='width:100px'>" & dr("Provinsi").ToString & "</td>" & _
        '             "<td style='width:100px'>" & dr("IdKoordinator").ToString & "</td>" & _
        '             "<td style='width:100px'>" & dr("IdTeknisi").ToString & "</td>" & _
        '             "<td style='width:100px'>" & dr("Status").ToString & "</td>" & _
        '         "</tr>"
        '    End While
        'End If
        'dr.Close()
        'con.Close()

        'ltr_email.Text = tampungan


    End Sub

    Protected Sub gridalltask_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("getid") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()

        dsalltask.SelectCommand = "SELECT trTask.ID, trTask.NoTask, trtask.NoSubTask, CONVERT(date, trTask.TanggalTask) as TanggalTask, msProvinsi.Provinsi, trTask.IdKoordinator,  trTask.IdTeknisi, msStatus.Status " & _
                                "FROM trTask INNER JOIN msProvinsi ON trTask.IdProvinsi = msProvinsi.IdProvinsi INNER JOIN msStatus ON trTask.IdStatusTask = msStatus.ID where NoTask = '" & Session("getid") & "'"

    End Sub
End Class
