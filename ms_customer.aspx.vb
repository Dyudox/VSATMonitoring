Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports System.Web

Partial Class ms_customer
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dscustomer.SelectCommand = "select * from msCustomer"
    End Sub
    Protected Sub gv_customer_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles gv_customer.RowDeleting
        dscustomer.DeleteCommand = "delete from msCustomer where IdCustomer = @IdCustomer"
        gv_customer.DataBind()
    End Sub

    Protected Sub gv_customer_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles gv_customer.RowInserting
        dscustomer.InsertCommand = "insert into msCUstomer (Customer, UserStamp, TimeStamp) VALUES ( @Customer, '" & Session("username") & "', GETDATE())"
        gv_customer.DataBind()
    End Sub


    Protected Sub gv_customer_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles gv_customer.RowUpdating
        dscustomer.UpdateCommand = "Update msCustomer set Customer = @Customer, UserStamp = '" & Session("username") & "', TimeStamp = GETDATE() where IdCustomer = @IdCustomer"
        gv_customer.DataBind()
    End Sub
    Protected Sub gv_detilcustomer_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("idcustomer") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        Dim idcustomer As String = ""
        Dim getidcustomer As String = "select IdCustomer from msCustomer where IdCustomer = '" & Session("idcustomer") & "'"
        com = New SqlCommand(getidcustomer, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        idcustomer = dr("IdCustomer").ToString
        dr.Close()
        con.Close()

        dscustomersub.SelectCommand = "select * from msCustomer_Sub WHERE IdCustomer='" & idcustomer & "'"
        dscustomersub.InsertCommand = "INSERT INTO msCustomer_Sub (IdCustomer, Customer_Sub, DateStamp, UserStamp) VALUES ('" & idcustomer & "', @Customer_Sub, GETDATE(), '" & Session("username") & "')"
        dscustomersub.UpdateCommand = "UPDATE msCustomer_Sub SET Customer_Sub=@Customer_Sub, DateStamp = GETDATE(), UserStamp = '" & Session("username") & "' WHERE IdCustomer_Sub=@IdCustomer_Sub"
        dscustomersub.DeleteCommand = "DELETE FROM msCustomer_Sub WHERE IdCustomer_Sub = @IdCustomer_Sub"
    End Sub
End Class
