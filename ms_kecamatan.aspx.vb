Imports System
Imports System.Data.SqlClient
Partial Class ms_kecamatan
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dskecamatan.SelectCommand = "select * from mskecamatan"
        'dskota.SelectCommand = "select * from v_kecamatan"
    End Sub

    Protected Sub grid_Kecamatan_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_Kecamatan.RowDeleting
        dskecamatan.DeleteCommand = "delete from msKecamatan where ID = @ID"
        grid_Kecamatan.DataBind()
    End Sub

    Protected Sub grid_Kecamatan_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_Kecamatan.RowInserting
        Dim idakhir As String
        Dim tampungidkota As String = e.NewValues("idKota")
        Dim getidakhir As String = "select * from msKecamatan where SUBSTRING(idKecamatan, 1,4) = '" & tampungidkota & "' order by idKecamatan desc"
        com = New SqlCommand(getidakhir, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            idakhir = dr("idKecamatan").ToString
        End If
        dr.Close()
        con.Close()

        If idakhir = "" Then
            dskecamatan.InsertCommand = "insert into msKecamatan(IdKota, IdKecamatan, Kecamatan, UserStamp, TimeStamp) VALUES (@IdKota, '" & tampungidkota & "100', @Kecamatan, '" & Session("username") & "', GETDATE())"
            grid_Kecamatan.DataBind()
        Else
            Dim idsuk As String = idakhir + 1

            dskecamatan.InsertCommand = "insert into msKecamatan(IdKota, IdKecamatan, Kecamatan, UserStamp, TimeStamp) VALUES (@IdKota, '" & idsuk & "', @Kecamatan, '" & Session("username") & "', GETDATE())"
            grid_Kecamatan.DataBind()
        End If
       
    End Sub

    Protected Sub grid_Kecamatan_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_Kecamatan.RowUpdating
        dskecamatan.UpdateCommand = " update msKecamatan set IdKota = @IdKota, IdKecamatan = @IdKecamatan, Kecamatan = @Kecamatan, UserStamp = '" & Session("username") & "', TimeStamp = GETDATE() where ID = @ID"
        grid_Kecamatan.DataBind()
    End Sub
End Class
