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
Partial Class editfoto
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr, sqldr As SqlDataReader
    Dim com As SqlCommand
    'Dim VID, NamaRemote, IPLAN, SID, ALamatInstall As String
    Dim tampungid, NoSubtask As String
    Dim path As String = Server.MapPath("~/UploadFoto/")

    Protected Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim getid As String = "select * from trx_file where file_url = '" & Request.QueryString("filename") & "'"
        com = New SqlCommand(getid, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        tampungid = dr("file_id").ToString
        dr.Close()
        con.Close()


        If FileUpload1.HasFile And txtjudul.Text <> "" Then
            Try
                FileUpload1.SaveAs(path + Replace(FileUpload1.FileName, " ", "_"))
            Catch ex As Exception
                Response.Write(DirectCast("", String))
            End Try
            Dim insert As String = "update TRX_FILE set file_url = '" & "UploadFoto/" + Replace(FileUpload1.FileName, " ", "_") & "', Description = '" & txtjudul.Text & "', Keterangan = '" & txtketgambar.InnerText & "' where file_id = '" & tampungid & "'"
            com = New SqlCommand(insert, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        ElseIf FileUpload1.HasFile Then
            Try
                FileUpload1.SaveAs(path + Replace(FileUpload1.FileName, " ", "_"))
            Catch ex As Exception
                Response.Write(DirectCast("", String))
            End Try
            Dim insert As String = "update TRX_FILE set file_url = '" & "UploadFoto/" + Replace(FileUpload1.FileName, " ", "_") & "', Keterangan = '" & txtketgambar.InnerText & "' where file_id = '" & tampungid & "'"
            com = New SqlCommand(insert, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Else
            Dim insert As String = "update TRX_FILE set Description = '" & txtjudul.Text & "', Keterangan = '" & txtketgambar.InnerText & "' where file_id = '" & tampungid & "'"
            com = New SqlCommand(insert, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        End If
        Response.Redirect("createdetiltask.aspx?order=" & Request.QueryString("order") & "&id=" & Request.QueryString("id") & "&VID=" & Request.QueryString("VID") & "&NoTask=" & Request.QueryString("NoTask") & "")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
    End Sub
End Class
