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
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Partial Class LaporanPekerjaan
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr, sqldr As SqlDataReader
    Dim com As SqlCommand
    Dim tbldata As DataTable
    Dim clsg As New cls_global
    Dim VID, NamaRemote, IPLAN, SID, ALamatInstall, strsql As String
    Dim tampung, NoSubtask As String
    Dim filePath As String = ConfigurationManager.AppSettings("filePath")
    Dim DocNo As String = "PSPD" & Now.Hour.ToString("D2") & Now.Year & Now.Minute.ToString("D2") & Now.Month.ToString("D2") & Now.Day.ToString("D2") & Now.Second.ToString("D2")

    Protected Sub btn_exportTxt_Click(sender As Object, e As EventArgs) Handles btn_exportTxt.Click
        Try
            '=== Ambil HTML dari divExport saja ===
            Dim html As String = RenderControlToString(divExport)

            '=== Siapkan output builder ===
            Dim sb As New StringBuilder()

            '=== Ambil judul utama ===
            Dim titleMatch = Regex.Match(html, "<label[^>]*>LAPORAN PEKERJAAN.*?<\/label>", RegexOptions.IgnoreCase)
            If titleMatch.Success Then
                Dim titleText As String = CleanHtml(titleMatch.Value)
                sb.AppendLine("*" & titleText & "*")
                sb.AppendLine()
            End If

            '=== Ambil jenis layanan dan pekerjaan ===
            Dim spanMatches = Regex.Matches(html, "<span[^>]*>(.*?)<\/span>", RegexOptions.IgnoreCase)
            For Each m As Match In spanMatches
                Dim text As String = CleanHtml(m.Groups(1).Value)
                Dim parts() As String = text.Split(":"c)
                If parts.Length = 2 Then
                    sb.AppendLine("*" & parts(0).Trim() & "* : " & parts(1).Trim())
                Else
                    sb.AppendLine(text)
                End If
            Next
            sb.AppendLine()

            '=== Ambil semua blok section (1. REMOTE SUPPORT TIM, 2. CUSTOMER, dst.) ===
            Dim sectionMatches = Regex.Matches(html, "<label[^>]*>\s*(\d+\..*?)<\/label>", RegexOptions.IgnoreCase)
            For Each section As Match In sectionMatches
                Dim sectionTitle As String = "*" & CleanHtml(section.Groups(1).Value) & "*"
                sb.AppendLine(sectionTitle)
                sb.AppendLine("==================================================")

                ' Cari label-input di bawah section ini
                Dim startIndex As Integer = section.Index + section.Length
                Dim nextSectionIndex As Integer = GetNextSectionIndex(section, sectionMatches, html)

                Dim sectionHtml As String = html.Substring(startIndex, nextSectionIndex - startIndex)

                ' Ambil pasangan label-input di dalam section
                Dim fieldMatches = Regex.Matches(sectionHtml,
                    "<label[^>]*>(.*?)<\/label>\s*<div[^>]*>\s*<input[^>]*value\s*=\s*""(.*?)""",
                    RegexOptions.IgnoreCase)

                For Each f As Match In fieldMatches
                    Dim lbl As String = CleanHtml(f.Groups(1).Value)
                    Dim val As String = CleanHtml(f.Groups(2).Value)
                    lbl = lbl.Trim().TrimEnd(":"c)
                    sb.AppendLine("*" & lbl & " :* " & val)
                Next

                sb.AppendLine("==================================================")
                sb.AppendLine()
            Next

            '=== Simpan ke file ===
            Dim outputText As String = sb.ToString().Trim()
            Dim fileName As String = "laporan_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
            Dim filePath As String = Server.MapPath("~/Export_Txt/" & fileName)
            File.WriteAllText(filePath, outputText, Encoding.UTF8)


            ' === Redirect ke handler download tag html .aspx ikut ke convert (handler harus ada: DownloadTxt.ashx) ===
            Dim downloadUrl As String = "DownloadTxt.ashx?file=" & HttpUtility.UrlEncode(fileName)
            Response.Redirect(downloadUrl, False)
            HttpContext.Current.ApplicationInstance.CompleteRequest()

            '=== Kirim ke browser ===
            'Response.Clear()
            'Response.ContentType = "text/plain"
            'Response.AppendHeader("Content-Disposition", "attachment; filename=" & fileName)
            'Response.Write(outputText)
            'Response.End()

        Catch ex As Exception
            Response.Write("Error: " & ex.Message)
        End Try
    End Sub

    '=== Helper: render control ke string ===
    Private Function RenderControlToString(ctrl As Control) As String
        Dim sb As New StringBuilder()
        Using sw As New StringWriter(sb)
            Using hw As New HtmlTextWriter(sw)
                ctrl.RenderControl(hw)
            End Using
        End Using
        Return sb.ToString()
    End Function

    '=== Helper: bersihkan tag HTML dan spasi ===
    Private Function CleanHtml(input As String) As String
        Dim text As String = Regex.Replace(input, "<.*?>", "")
        text = Server.HtmlDecode(text)
        text = Regex.Replace(text, "\s{2,}", " ").Trim()
        Return text
    End Function

    '=== Helper: cari posisi section berikutnya untuk pemisahan ===
    Private Function GetNextSectionIndex(currentSection As Match, allSections As MatchCollection, html As String) As Integer
        Dim currentIndex As Integer = currentSection.Index + currentSection.Length
        For Each s As Match In allSections
            If s.Index > currentSection.Index Then
                Return s.Index
            End If
        Next
        Return html.Length
    End Function


    'Protected Sub btn_exportTxt_Click(sender As Object, e As EventArgs)

    '    Try
    '        ' === Path penyimpanan ===
    '        Dim folderPath As String = "D:\OfficeSelindo\Backup server\BackupVsat\Export_Txt\"
    '        If Not Directory.Exists(folderPath) Then
    '            Directory.CreateDirectory(folderPath)
    '        End If

    '        ' === Nama file export ===
    '        Dim fileName As String = "Export_Data_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".txt"
    '        Dim filePath As String = Path.Combine(folderPath, fileName)

    '        ' === Header kolom ===
    '        Dim headers() As String = {"Pengeluaran", "Nominal", "Tanggal", "Note"}

    '        ' === Ambil data dari Literal ===
    '        Dim htmlContent As String = ltrisi.Text.Trim()
    '        If String.IsNullOrEmpty(htmlContent) Then
    '            Response.Write("<script>alert('Tidak ada data untuk diexport');</script>")
    '            Exit Sub
    '        End If

    '        ' === Bersihkan HTML ke format teks ===
    '        htmlContent = Regex.Replace(htmlContent, "</tr\s*>", vbCrLf, RegexOptions.IgnoreCase)
    '        htmlContent = Regex.Replace(htmlContent, "</td\s*>", "|", RegexOptions.IgnoreCase)
    '        htmlContent = Regex.Replace(htmlContent, "<.*?>", "")
    '        htmlContent = System.Net.WebUtility.HtmlDecode(htmlContent)
    '        htmlContent = htmlContent.Replace("&nbsp;", " ").Trim()

    '        ' === Pisahkan ke baris dan kolom ===
    '        Dim lines = htmlContent.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
    '        Dim rows As New List(Of String())
    '        For Each line In lines
    '            Dim parts = line.Split({"|"}, StringSplitOptions.RemoveEmptyEntries)
    '            If parts.Length > 0 Then rows.Add(parts.Select(Function(x) x.Trim()).ToArray())
    '        Next

    '        ' === Hitung lebar kolom ===
    '        Dim colWidths(headers.Length - 1) As Integer
    '        For i = 0 To headers.Length - 1
    '            colWidths(i) = headers(i).Length
    '        Next
    '        For Each row In rows
    '            For i = 0 To Math.Min(row.Length, headers.Length) - 1
    '                colWidths(i) = Math.Max(colWidths(i), row(i).Length)
    '            Next
    '        Next

    '        ' === Format teks sejajar ===
    '        Dim sb As New StringBuilder()
    '        For i = 0 To headers.Length - 1
    '            sb.Append(headers(i).PadRight(colWidths(i) + 2))
    '            If i < headers.Length - 1 Then sb.Append("| ")
    '        Next
    '        sb.AppendLine()
    '        sb.AppendLine(New String("-"c, sb.Length - 2))

    '        For Each row In rows
    '            For i = 0 To headers.Length - 1
    '                Dim val As String = If(i < row.Length, row(i), "")
    '                sb.Append(val.PadRight(colWidths(i) + 2))
    '                If i < headers.Length - 1 Then sb.Append("| ")
    '            Next
    '            sb.AppendLine()
    '        Next

    '        ' === Simpan file TXT ===
    '        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)

    '        ' === Simpan log export ===
    '        Dim logFolder As String = Path.Combine(folderPath, "Logs")
    '        If Not Directory.Exists(logFolder) Then
    '            Directory.CreateDirectory(logFolder)
    '        End If

    '        Dim logPath As String = Path.Combine(logFolder, "export_log_" & DateTime.Now.ToString("yyyyMM") & ".log")
    '        ' aman ambil username dari session (fallback ke "Unknown" kalau kosong)
    '        Dim userName As String = "Unknown"
    '        If Session IsNot Nothing AndAlso Session("username") IsNot Nothing Then
    '            userName = Session("username").ToString()
    '        ElseIf HttpContext.Current IsNot Nothing AndAlso HttpContext.Current.User IsNot Nothing AndAlso HttpContext.Current.User.Identity IsNot Nothing AndAlso HttpContext.Current.User.Identity.Name IsNot Nothing Then
    '            userName = HttpContext.Current.User.Identity.Name
    '        End If

    '        Dim logText As String = String.Format("{0} | User: {1} | File: {2} | Rows: {3}{4}",
    '                                          DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
    '                                          userName,
    '                                          fileName,
    '                                          rows.Count,
    '                                          Environment.NewLine)

    '        File.AppendAllText(logPath, logText, Encoding.UTF8)

    '        ' === Redirect ke handler download (handler harus ada: DownloadTxt.ashx) ===
    '        Dim downloadUrl As String = "DownloadTxt.ashx?file=" & HttpUtility.UrlEncode(fileName)
    '        Response.Redirect(downloadUrl, False)
    '        HttpContext.Current.ApplicationInstance.CompleteRequest()

    '    Catch ex As Exception
    '        Response.Write("<script>alert('Gagal export: " & ex.Message.Replace("'", "") & "');</script>")
    '    End Try
    'End Sub
End Class
