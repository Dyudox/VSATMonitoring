
Partial Class ms_level_user
    Inherits System.Web.UI.Page


    Protected Sub gridleveluser_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridleveluser.RowDeleting
        dsleveluser.DeleteCommand = "delete from msleveluser where LevelUserID = @LevelUserID"
        gridleveluser.DataBind()

    End Sub

    Protected Sub gridleveluser_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gridleveluser.RowInserting
        dsleveluser.InsertCommand = "Insert into msleveluser (Name, Description) VALUES (@Name, @Description)"
        gridleveluser.DataBind()
    End Sub

    Protected Sub gridleveluser_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridleveluser.RowUpdating
        dsleveluser.UpdateCommand = "Update msleveluser set Name = @Name, Description = @Description where LevelUserID = @LevelUserID"
        gridleveluser.DataBind()
    End Sub
End Class
