Imports System
Imports System.Data.SqlClient
Partial Class ms_provider
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsprovider.SelectCommand = "select * from msProvider"
    End Sub

    Protected Sub grid_provider_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_provider.RowDeleting
        dsprovider.DeleteCommand = "delete from msProvider where id = @id"
        grid_provider.DataBind()
    End Sub


    Protected Sub grid_provider_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_provider.RowInserting
        dsprovider.InsertCommand = "insert into msProvider (Nama_Provider, Alamat, Telp, Email, Fax, Desc_Provider, Usercreate, Datecreate) VALUES (@Nama_Provider, @Alamat, @Telp, @Email, @Fax, @Desc_Provider, '" & Session("username") & "', GETDATE())"
        grid_provider.DataBind()
    End Sub


    Protected Sub grid_provider_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_provider.RowUpdating
        dsprovider.UpdateCommand = "update msProvider set Nama_Provider = @Nama_Provider, Alamat = @Alamat, Telp = @Telp, Email = @Email, Fax = @Fax, Desc_Provider = @Desc_Provider, Userupdate = '" & Session("Userupdate") & "', Dateupdate = GETDATE() where id = @id"
        grid_provider.DataBind()
    End Sub
End Class
