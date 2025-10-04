Imports System
Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Bootstrap
Imports DevExpress.Web.BootstrapMode
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports DevExpress.Web.ASPxEdit
Imports System.Net
Imports System.Net.Mail
Partial Class testpopup
    Inherits System.Web.UI.Page
    Dim con, con1, con2 As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub popup_WindowCallback(source As Object, e As PopupWindowCallbackArgs)

    End Sub

  

    Protected Sub popup_grid_subtask_BeforePerformDataSelect(sender As Object, e As EventArgs)

    End Sub

    Protected Sub cbfilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbfilter.SelectedIndexChanged
        Dim strGetData As String
        strGetData = "SELECT trTask.NoTask, trtask.Provinsi, trtask.IdProject, trtask.TglMulai from trTask " & _
                    "where trTask.NoTask = '2018101007383'"
        com = New SqlCommand(strGetData, con)
        con.Open()
        dr = com.ExecuteReader
        dr.Read()
        Dim project As String = dr("IdProject").ToString
        Dim NamaProvinsi As String = dr("Provinsi").ToString
        Dim NoTask As String = dr("NoTask").ToString
        Dim tglmulai As String = dr("TglMulai").ToString
        'Session("notask") = dr("NoTask").ToString
        dr.Close()
        con.Close()
        litText.Text = "Provinsi : " & NamaProvinsi
        Session("NamaProvinsi") = NamaProvinsi
        Session("NoTask") = NoTask

        dssubtask.SelectCommand = "exec res_LokasiRemoteSiteSekitar 'DKI', '" & cbfilter.Value & "', '" & project & "', '" & tglmulai & "'"
    End Sub

    Protected Sub callbackPanelX_Callback(sender As Object, e As CallbackEventArgsBase) Handles callbackPanelX.Callback

    End Sub
End Class
