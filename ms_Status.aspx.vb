Imports System
Imports System.Data.SqlClient
Partial Class ms_Status
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsstatus.SelectCommand = "select * from msStatus"
    End Sub

    Protected Sub gridstatus_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridstatus.RowDeleting
        dsstatus.DeleteCommand = "delete from msStatus where ID = @ID"
        gridstatus.DataBind()
    End Sub


    Protected Sub gridstatus_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gridstatus.RowInserting
        dsstatus.InsertCommand = "insert into msStatus (Status, UserStamp, TimeStamp, FlagUser, FlagUnitKerja) VALUES (@Status, '" & Session("username") & "', GETDATE(), @FlagUser, @FlagUnitKerja)"
        gridstatus.DataBind()
    End Sub


    Protected Sub gridstatus_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridstatus.RowUpdating
        dsstatus.UpdateCommand = "update msStatus SET Status = @Status, UserStamp = '" & Session("Username") & "', TimeStamp = GETDATE(), FlagUser = @FlagUser, FlagUnitKerja = @FlagUnitKerja where ID=@ID"
        gridstatus.DataBind()
    End Sub
End Class
