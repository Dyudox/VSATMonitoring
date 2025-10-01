Imports DevExpress.Web
Imports System.Data

Partial Class rpttask
    Inherits System.Web.UI.Page
    Dim strsql, strFilter As String
    Dim clsg As New cls_global
    Dim tbldata As DataTable

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            cb_perusahaan.DataSourceID = "ds_perusahaan"
            cb_perusahaan.DataBind()
            cb_perusahaan.Items.Insert(0, New ListEditItem("All"))
            strsql = "select MAX(convert(date,TglStatusManager)) MxDate,min(convert(date,TglStatusManager)) MnDate from trTask"
            tbldata = clsg.ExecuteQuery(strsql)
            strsql = "exec reporttaskdataentry '" & tbldata.Rows(0).Item("MnDate") & "','" & tbldata.Rows(0).Item("MxDate") & "',''"
            Session("Fstr") = strsql
        End If
        ds_RptTaskDataEntry.SelectCommand = Session("Fstr")
        gv_rptTaskDataEntry.DataBind()
    End Sub

    Protected Sub B_notError_ServerClick(sender As Object, e As EventArgs) Handles B_notError.ServerClick
        lblError.Visible = False
    End Sub

    Protected Sub bconvert_Click(sender As Object, e As EventArgs) Handles bconvert.Click
        Try
            If cb_perusahaan.Value = "All" Or IsNothing(cb_perusahaan.Value) = True Then
                strsql = "select MAX(convert(date,TglStatusManager)) MxDate,min(convert(date,TglStatusManager)) MnDate from trTask"
                tbldata=clsg.ExecuteQuery(strsql)
                strFilter &= "REPORT PENGISIAN TASK" & Environment.NewLine
                strFilter &= "Perusahaan = All Data Record" & Environment.NewLine
                strFilter &= "Start Date = " & Format(tbldata.Rows(0).Item("MnDate"), "MMM dd yyyy") & Environment.NewLine
                strFilter &= "End Date = " & Format(tbldata.Rows(0).Item("MxDate"), "MMM dd yyyy") & Environment.NewLine
                strsql = "exec reporttaskdataentry '" & tbldata.Rows(0).Item("MnDate") & "','" & tbldata.Rows(0).Item("MxDate") & "',''"
            Else
                strFilter &= "REPORT PENGISIAN TASK" & Environment.NewLine
                strFilter &= "Perusahaan = " & cb_perusahaan.Text & Environment.NewLine
                strFilter &= "Start Date = " & Format(StarDate.Value, "MMM dd yyyy") & Environment.NewLine
                strFilter &= "End Date = " & Format(enddate.Value, "MMM dd yyyy") & Environment.NewLine
                strsql = "exec reporttaskdataentry '" & StarDate.Value & "','" & enddate.Value & "','" & cb_perusahaan.Value & "'"
            End If
            Session("Fstr") = strsql
            ds_RptTaskDataEntry.SelectCommand = Session("Fstr")
            gv_rptTaskDataEntry.DataBind()

            GVExpTax.ReportHeader = strFilter

            GVExpTax.FileName = "Report Task Data Entry_" & Now.ToString("dd-MM-yyyy")

            Select Case cbExpLogin.Value
                Case "xlsx"
                    GVExpTax.WriteXlsxToResponse()
                Case "xls"
                    GVExpTax.WriteXlsToResponse()
                Case "pdf"
                    GVExpTax.WritePdfToResponse()
                Case "csv"
                    GVExpTax.WriteCsvToResponse()
                Case "Rtf"
                    GVExpTax.WriteRtfToResponse()
            End Select
        Catch ex As Exception
            lblError.Visible = True
            lbl_Error.Text = "Gagal Load Data " & StarDate.Value & ", " & enddate.Value & ", " & cb_perusahaan.Text
        End Try
    End Sub

    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try
            If enddate.Value < StarDate.Value Then
                lblError.Visible = True
                lbl_Error.Text = "End Date harus lebih besar dari Start Date"
            Else
                If cb_perusahaan.Value = "All" Then
                    strsql = "exec reporttaskdataentry '" & StarDate.Value & "','" & enddate.Value & "',''"
                Else
                    strsql = "exec reporttaskdataentry '" & StarDate.Value & "','" & enddate.Value & "','" & cb_perusahaan.Value & "'"
                End If
                Session("Fstr") = strsql
                ds_RptTaskDataEntry.SelectCommand = Session("Fstr")
				clsg.writedata("System", "Report Entry Task", "Load Data", Session("Fstr"), "")
                gv_rptTaskDataEntry.DataBind()
            End If
        Catch ex As Exception
            lblError.Visible = True
            lbl_Error.Text = "Gagal Load Data " & StarDate.Value & ", " & enddate.Value & ", " & cb_perusahaan.Text
        End Try
    End Sub
End Class
