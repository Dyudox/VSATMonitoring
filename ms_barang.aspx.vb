
Partial Class ms_barang
    Inherits System.Web.UI.Page

    Protected Sub gridbarang_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gridbarang.RowDeleting
        dsbarang.DeleteCommand = "delete from msBarang where ID = @ID"
        gridbarang.DataBind()
    End Sub

    Protected Sub gridbarang_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gridbarang.RowInserting
        dsbarang.InsertCommand = "Insert into msBarang (IdBarang, Barang) VALUES (@IdBarang, @Barang)"
        gridbarang.DataBind()
    End Sub

    Protected Sub gridbarang_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gridbarang.RowUpdating
        dsbarang.UpdateCommand = "Update msBarang set IdBarang = @IdBarang, Barang = @Barang where ID = @ID"
        gridbarang.DataBind()
    End Sub
End Class
