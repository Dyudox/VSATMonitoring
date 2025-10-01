
Partial Class masterpagu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        dspagu.SelectCommand = "select * from ms_pagu"
    End Sub

    Protected Sub gridpagu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridpagu.RowDeleting
        dspagu.DeleteCommand = "delete from ms_pagu where ID = @ID"
        gridpagu.DataBind()
    End Sub

    Protected Sub gridpagu_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gridpagu.RowInserting
        dspagu.InsertCommand = "insert into ms_pagu (Provider, TypeKaryawan, Deskripsi, Pagu) VALUES (@Provider, @TypeKaryawan, @Deskripsi, @Pagu)"
        gridpagu.DataBind()
    End Sub

    Protected Sub gridpagu_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridpagu.RowUpdating
        dspagu.UpdateCommand = "Update ms_pagu set Provider = @Provider, TypeKaryawan = @TypeKaryawan, Deskripsi = @Deskripsi, Pagu = @Pagu where ID = @ID"
        gridpagu.DataBind()
    End Sub
End Class
