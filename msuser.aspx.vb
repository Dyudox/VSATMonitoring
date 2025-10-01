Imports System
Imports System.Data.SqlClient
Partial Class msuser
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        dsuser.SelectCommand = "select * from msUser"
    End Sub


    Protected Sub grid_kokab_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_kokab.RowDeleting
        dsuser.DeleteCommand = "delete from msUser where ID = @ID"
        'dskokab.DataBind()
        grid_kokab.DataBind()
    End Sub


    Protected Sub grid_kokab_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_kokab.RowInserting
        dsuser.InsertCommand = "insert into msuser (username, password, leveluser) VALUES (@UserName, @Password, @Leveluser)"
        grid_kokab.DataBind()
    End Sub


    Protected Sub grid_kokab_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_kokab.RowUpdating
        dsuser.UpdateCommand = "update msuser set username=@UserName, password=@Password, leveluser=@Leveluser where id=@id"
        grid_kokab.DataBind()
    End Sub
End Class
