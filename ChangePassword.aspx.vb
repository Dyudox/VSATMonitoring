Imports System.Data

Partial Class ChangePassword
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tbldata As DataTable
    Dim clsg As New cls_global

	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		'txtPassword.Value = Session("passAsli")
    End Sub
    Protected Sub Btn_update_Click(sender As Object, e As EventArgs) Handles Btn_update.Click
	
        Try
            lblChange.Visible = True
            if Session("username")="admin" then
				lblChange.InnerText = "Password tidak dapat di ubah!"
			ElseIf txtPassword.Value = "" Or TxtPasswordNew.Text = "" Or TxtPasswordConfirm.Text = "" Then
                lblChange.InnerText = "Data yang anda masukan tidak lengkap !"
            ElseIf TxtPasswordConfirm.Text <> TxtPasswordNew.Text Then
                lblChange.InnerText = "Konfirmasi password yang anda masukan tidak sesuai !"
            ElseIf TxtPasswordConfirm.Text = Session("passAsli") Then
                lblChange.InnerText = "Password baru tidak boleh sama dengan Password lama !"
            ElseIf txtPassword.Value <> Session("passAsli") Then
                lblChange.InnerText = "Password lama yang anda masukan tidak sesuai !"
            Else
                strsql = "update msuser set password='" & clsg.ReplacePetik(TxtPasswordNew.Text) & "' where username='" & Session("username") & "'"
                clsg.ExecuteNonQuery(strsql)
                lblChange.InnerText = "Change Password Success! Please Re-login!"
            End If
        Catch ex As Exception
            lblChange.InnerText = "Change Password Gagal System!"
            clsg.writedata(Session("username"), "Change Password", strsql, ex.Message, "")
        End Try
        'txtPassword.Disabled = True
        'TxtPasswordNew.Enabled = False
        'TxtPasswordConfirm.Enabled = False
    End Sub

    Protected Sub btn_batal_Click(sender As Object, e As EventArgs) Handles btn_batal.Click
        Response.Redirect("tasklistBootsraps.aspx?page=dattsklis")
    End Sub
End Class
