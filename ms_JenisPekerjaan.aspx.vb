Imports System
Imports System.Data.SqlClient
Partial Class ms_JenisPekerjaan
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsjeniskerja.SelectCommand = "Select * from msJenis_Task order by KodeService asc"
    End Sub

    Protected Sub grid_jeniskerja_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_jeniskerja.RowDeleting
        dsjeniskerja.DeleteCommand = "delete from msJenis_Task where ID = @ID"
        grid_jeniskerja.DataBind()
    End Sub


    Protected Sub grid_jeniskerja_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_jeniskerja.RowInserting
        dsjeniskerja.InsertCommand = "Insert into msJenis_Task (KodeService, Service, UserStamp, TimeStamp) VALUES (@KodeService, @Service, '" & Session("username") & "', GETDATE())"
        grid_jeniskerja.DataBind()
    End Sub


    Protected Sub grid_jeniskerja_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_jeniskerja.RowUpdating
        dsjeniskerja.UpdateCommand = "update msJenis_Task set KodeService = @KodeService, Service = @Service, UserStamp = '" & Session("username") & "', TimeStamp = GETDATE() where ID = @ID"
        grid_jeniskerja.DataBind()
    End Sub
End Class
