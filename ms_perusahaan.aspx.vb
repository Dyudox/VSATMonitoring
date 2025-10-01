Imports System
Imports System.Data.SqlClient
Imports System.Data

Partial Class ms_perusahaan
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand
	Dim clsg As New cls_global
    Dim strsql As String
    Dim tbldata As DataTable

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsperusahaan.SelectCommand = "select * from msPerusahaan"
    End Sub
    Protected Sub grid_perusahaan_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_perusahaan.RowDeleting
        dsperusahaan.DeleteCommand = "delete from msPerusahaan where Id = @Id"
        grid_perusahaan.DataBind()
    End Sub

    Protected Sub grid_perusahaan_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_perusahaan.RowInserting
        strsql = "select max(Id) as Id from msPerusahaan"
        tbldata = clsg.ExecuteQuery(strsql)
        If IsDBNull(tbldata.Rows(0).Item(0)) Then
            strsql = 1001
        Else
            strsql = tbldata.Rows(0).Item(0) + 1
        End If
        dsperusahaan.InsertCommand = "insert into msPerusahaan (Id, NamaPerusahaan, inisialPerusahaan, Alamat, Telp, Email, Fax, Description, Datecreate, Usercreate) VALUES " & _
            "('" & strsql & "',@NamaPerusahaan, @inisialPerusahaan, @Alamat, @Telp, @Email, @Fax, @Description, GETDATE(), '" & Session("username") & "')"
        grid_perusahaan.DataBind()
    End Sub

    Protected Sub grid_perusahaan_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_perusahaan.RowUpdating
        dsperusahaan.UpdateCommand = "update msPerusahaan set inisialPerusahaan=@inisialPerusahaan, NamaPerusahaan = @NamaPerusahaan, Alamat = @Alamat, Telp = @Telp, Email = @Email, Fax = @Fax, Description = @Description, Dateupdate = GETDATE(), Userupdate = '" & Session("username") & "' where Id = @Id "
        grid_perusahaan.DataBind()
    End Sub
End Class
