Imports System
Imports System.Data.SqlClient
Partial Class ms_kota
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("username") = "" Then
            Response.Redirect("login.aspx")
        End If
        dskokab.SelectCommand = "SELECT msProvinsi.Provinsi, msProvinsi.IdProvinsi, msKota.IdKota, msKota.Kota, msKota.ID FROM msProvinsi INNER JOIN msKota ON msProvinsi.IdProvinsi = msKota.IdProvinsi"
        'dsprovinsi.SelectCommand = "select * from msProvinsi"
    End Sub

    Protected Sub grid_kokab_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_kokab.RowDeleting
        dskokab.DeleteCommand = "delete from msKota where ID = @ID"
        'dskokab.DataBind()
        grid_kokab.DataBind()
    End Sub


    Protected Sub grid_kokab_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_kokab.RowInserting
        Dim idprov As String = e.NewValues("IdProvinsi").ToString
        Dim getidakhir As String = "select * from msKota where SUBSTRING(idKota, 1,2)  = '" & idprov & "' order by idkota desc"
        com = New SqlCommand(getidakhir, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        Dim idakhir As String = dr("idKota").ToString
        dr.Close()
        con.Close()
        Dim idsuk As String = idakhir + 1
        dskokab.InsertCommand = "insert into msKota (IdProvinsi, IdKota, Kota, UserStamp, TimeStamp) VALUES (@IdProvinsi, '" & idsuk & "', @Kota, '" & Session("username") & "', GETDATE())"
        'dskokab.DataBind()
        grid_kokab.DataBind()
    End Sub

    Protected Sub grid_kokab_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_kokab.RowUpdating
        dskokab.UpdateCommand = "update msKota set IdProvinsi = @IdProvinsi, IdKota = @IdKota, Kota = @Kota, UserStamp = '" & Session("username") & "', TimeStamp = GETDATE() where ID = @ID"
        'dskokab.DataBind()
        grid_kokab.DataBind()
    End Sub
End Class
