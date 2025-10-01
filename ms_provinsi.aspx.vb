Imports System
Imports System.Data.SqlClient
Partial Class ms_provinsi
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsprovinsi.SelectCommand = "select * from msProvinsi"
    End Sub


    Protected Sub grid_provinsi_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_provinsi.RowDeleting
        dsprovinsi.DeleteCommand = "delete from msProvinsi where ID = @ID"
        grid_provinsi.DataBind()
    End Sub


    Protected Sub grid_provinsi_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_provinsi.RowInserting
        Dim idakhir, idsuk As String
        Dim getidakhir As String = "select IdProvinsi from msProvinsi order by IdProvinsi desc"
        com = New SqlCommand(getidakhir, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        idakhir = dr("IdProvinsi").ToString
        dr.Close()
        con.Close()

        idsuk = idakhir + 1

        dsprovinsi.InsertCommand = "INSERT INTO msProvinsi (IdProvinsi, Provinsi, UserStamp, TimeStamp) VALUES ('" & idsuk & "', @Provinsi, '" & Session("username") & "', GETDATE())"
        grid_provinsi.DataBind()
    End Sub


    Protected Sub grid_provinsi_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_provinsi.RowUpdating
        dsprovinsi.UpdateCommand = "Update msProvinsi SET IdProvinsi = @IdProvinsi, Provinsi = @Provinsi, UserStamp = '" & Session("username") & "', TimeStamp = GETDATE() where ID = @ID"
        grid_provinsi.DataBind()
    End Sub
End Class
