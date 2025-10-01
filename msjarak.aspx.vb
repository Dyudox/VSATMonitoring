Imports System
Imports System.Data.SqlClient
Partial Class msjarak
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub grid_jarak_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_jarak.RowDeleting
        dsjarak.DeleteCommand = "delete from msJarak where id = @id"
        grid_jarak.DataBind()
    End Sub

    Protected Sub grid_jarak_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_jarak.RowInserting
        dsjarak.InsertCommand = "insert into msJarak (Jarak, Description) VALUES (@Jarak, @Description)"
        grid_jarak.DataBind()
    End Sub

    Protected Sub grid_jarak_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_jarak.RowUpdating
        dsjarak.UpdateCommand = "update msJarak set Jarak = @Jarak, Description = @Description where id = @id"
        grid_jarak.DataBind()
    End Sub
End Class
