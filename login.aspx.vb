Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class login
    Inherits System.Web.UI.Page
    Dim Con, Con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim Com, com1 As SqlCommand
    Dim Dr, dr1 As SqlDataReader

    Protected Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim user As String
        Dim countuser As String = "select COUNT (ID) as UID from msuser where username='" & txtusername.Text & "' and password='" & txtpassword.Text & "'"
        com1 = New SqlCommand(countuser, Con1)
        Con1.Open()
        dr1 = com1.ExecuteReader()
        dr1.Read()
        user = dr1("UID").ToString
        dr1.Close()
        Con1.Close()

        If user > "0" Then    
			Session("passAsli")=txtpassword.Text        
			if (txtusername.Text = "admin" Or txtusername.Text = "Admin") and txtpassword.Text="admin"
				Session("level") = "admin"
				Session("username") = "admin"
				
				Response.Redirect("tasklistBootsraps.aspx?page=dattsklis")
				exit sub
			end if
			
			Dim cekuser As String = "select * from msuser a inner join msemployee b " & _
				"on a.username=b.NIK  where username='" & txtusername.Text & "' and a.password='" & txtpassword.Text & "'"
				Com = New SqlCommand(cekuser, Con)
				Con.Open()
				Dr = Com.ExecuteReader()
				Dr.Read()
				Session("level") = Dr("leveluser").ToString
				Session("username") = Dr("username").ToString
				session("Status")=dr("IdStatus").ToString
				Dr.Close()
				Con.Close()
				
			if session("Status")="Active" then				
				Response.Redirect("tasklistBootsraps.aspx?page=dattsklis")
				exit sub
			else
				lblAuth.Visible = True
				lblAuth.Text = "Username is Not Active"
			end if				
        Else
            lblAuth.Visible = True
            lblAuth.Text = "Username Or Password Are Incorrect!"
        End If
        txtusername.Text = ""
        txtpassword.Text = ""
    End Sub
End Class
