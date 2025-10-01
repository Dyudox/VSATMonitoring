Imports System
Imports System.Data.SqlClient
Partial Class ms_hub
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub grid_hub_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_hub.RowDeleting
        dshub.DeleteCommand = "delete from msHub where id = @id"
        grid_hub.DataBind()
    End Sub


    Protected Sub grid_hub_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_hub.RowInserting
        dshub.InsertCommand = "insert into msHub (Hub, Simbol_Read, Frekwensi, Desc_Hub, Datecreate, Usercreate) VALUES (@Hub, @Simbol_Read, @Frekwensi, @Desc_Hub, GETDATE(), '" & Session("username") & "')"
        grid_hub.DataBind()
    End Sub


    Protected Sub grid_hub_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_hub.RowUpdating
        dshub.UpdateCommand = "update msHub set Hub = @Hub, Simbol_Read = @Simbol_Read, Frekwensi = @Frekwensi, Desc_Hub = @Desc_Hub, Dateupdate = GETDATE(), Userupdate = '" & Session("username") & "' where id = @id"
        grid_hub.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
    End Sub
End Class
