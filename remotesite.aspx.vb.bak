Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.Bootstrap
Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports System.Data
Imports DevExpress.Web.ASPxEdit
Partial Class remotesite
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If

        dsRemoteSite.SelectCommand = "SELECT a.IdProject, a.IdPelanggan, a.IdAM, a.NoKontrak, a.ProjectName, b.VID, b.SID, b.IPLAN, b.KANWIL, b.KANCAINDUK, b.NAMAREMOTE, b.AlamatInstall, b.PROVINSI, b.ID, b.KOTA, b.IdJarkom, b.Skala FROM trRemoteSite b LEFT OUTER JOIN trProject a ON b.IdProject = a.IdProject"
    End Sub

    Protected Sub gridhistory_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("VID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim VID As String
        Dim getidproject As String = "select * from TrRemoteSite where ID = '" & Session("VID") & "'"
        com = New SqlCommand(getidproject, con)
        con.Open()
        dr = com.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            VID = dr("VID").ToString
        End If
        dr.Close()
        con.Close()

        dsgridhistory.SelectCommand = "SELECT trDetail_Task.NoListTask, trDetail_Task.VID, trDetail_Task.NoTask, trTask.NamaTeknisi, trDetail_Task.TglSelesaiKerjaan, trDetail_Task.idJenisTask " & _
                                        "FROM trTask INNER JOIN trDetail_Task ON trTask.NoTask = trDetail_Task.NoTask where trDetail_Task.VID = '" & VID & "'"
    End Sub

    Protected Sub grid_barang_on_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("VID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim VID As String
        Dim getidproject As String = "select * from TrRemoteSite where ID = '" & Session("VID") & "'"
        com = New SqlCommand(getidproject, con)
        con.Open()
        dr = com.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            VID = dr("VID").ToString
        End If
        dr.Close()
        con.Close()

        dsbarang_on.SelectCommand = "select * from trRemoteSite_D where VID = '" & VID & "'"
    End Sub

    Protected Sub grid_barang_rusak_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Session("VID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim VID As String
        Dim getidproject As String = "select * from TrRemoteSite where ID = '" & Session("VID") & "'"
        com = New SqlCommand(getidproject, con)
        con.Open()
        dr = com.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            VID = dr("VID").ToString
        End If
        dr.Close()
        con.Close()

        dsbarangreplace.SelectCommand = "select * from trRemoteSite_D_Rusak where VID = '" & VID & "'"
    End Sub

    Protected Sub grid_project_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_project.RowDeleting
        dsRemoteSite.DeleteCommand = "delete from trRemoteSite where ID = @ID"
        grid_project.DataBind()
    End Sub

    Protected Sub grid_project_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_project.RowInserting
        'dsRemoteSite.InsertCommand = "insert into trRemoteSite (VID, SID, IPLAN, KANWIL, KANCAINDUK, NAMAREMOTE, AlamatInstall, PROVINSI, KOTA, IdJarkom, Skala) VALUES (@VID, @SID, @IPLAN, @KANWIL, @KANCAINDUK, @NAMAREMOTE, @AlamatInstall, @PROVINSI, @KOTA, @IdJarkom, @Skala)"
        'grid_project.DataBind()

        Dim tampungnamaproject, tampungprovider As String
        Dim dataproject As String = "select * from trProject where IdProject = '" & e.NewValues("ProjectName").ToString & "'"
        com = New SqlCommand(dataproject, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            tampungnamaproject = dr("ProjectName").ToString
            tampungprovider = dr("IdProvider").ToString
        End If
        dr.Close()
        con.Close()

        dsRemoteSite.InsertCommand = "insert into trRemoteSite (VID, SID, IPLAN, KANWIL, KANCAINDUK, NAMAREMOTE, AlamatInstall, PROVINSI, KOTA, IdJarkom, Skala, IdProject, ProjectName, IdProvider) VALUES (@VID, @SID, @IPLAN, @KANWIL, @KANCAINDUK, @NAMAREMOTE, @AlamatInstall, @PROVINSI, @KOTA, @IdJarkom, @Skala, '" & e.NewValues("ProjectName").ToString & "', '" & tampungnamaproject & "', '" & tampungprovider & "')"
        grid_project.DataBind()
    End Sub

    Protected Sub grid_project_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_project.RowUpdating
        Dim tampungnamaproject, tampungprovider, tampungidproject As String
        

        If e.NewValues("ProjectName") = "" Then
            Dim dataproject As String = "select * from trProject where ProjectName = '" & e.NewValues("ProjectName").ToString & "'"
            com = New SqlCommand(dataproject, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                tampungnamaproject = dr("ProjectName").ToString
                tampungprovider = dr("IdProvider").ToString
            End If
            dr.Close()
            con.Close()
        Else
            Dim dataproject As String = "select * from trProject where IdProject = '" & e.NewValues("ProjectName").ToString & "' or ProjectName = '" & e.NewValues("ProjectName").ToString & "'"
            com = New SqlCommand(dataproject, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                tampungidproject = dr("IdProject").ToString
                tampungnamaproject = dr("ProjectName").ToString
                tampungprovider = dr("IdProvider").ToString
            End If
            dr.Close()
            con.Close()
        End If

        dsRemoteSite.UpdateCommand = "Update trRemoteSite set VID = @VID, SID = @SID, IPLAN = @IPLAN, KANWIL = @KANWIL, KANCAINDUK = @KANCAINDUK, NAMAREMOTE = @NAMAREMOTE, AlamatInstall = @AlamatInstall, PROVINSI = @PROVINSI, KOTA = @KOTA, IdJarkom = @IdJarkom, Skala = @Skala, IdProject = '" & tampungidproject & "', ProjectName = '" & tampungnamaproject & "', IdProvider = '" & tampungprovider & "' where ID = @ID"
        grid_project.DataBind()
    End Sub

 
End Class
