Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Class proses
    Inherits System.Web.UI.Page

    Dim strsql As String = String.Empty
    Dim sqldr, reader As SqlDataReader
    Dim sqlcon, con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim cmd As New SqlCommand
    Dim dr, dr1 As SqlDataReader
    Dim com As SqlCommand
    Dim VID, NamaRemote, IPLAN, SID, ALamatInstall, NoTask, Provinsi, Kota, IDJARKOM, PIC, CustPhone As String
    Dim tampung, NoSubtask As String

    Dim Namabarang, Hargabarang As String
    Dim idate As String = DateTime.Now.ToString("yyyyMMddhhmmss")
    Dim Data As String = String.Empty
    Dim ID_TEMP As String = String.Empty
    Dim idGenerate As String = String.Empty
    Dim strsqlcek As String = String.Empty

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        If Request.QueryString("ket") = "insert" Then

            'Response.Write("OKe" & Request.QueryString("id"))

            Dim getdetiltask As String = "select * from trRemoteSite where ID = '" & Request.QueryString("id") & "'"
            Try
                com = New SqlCommand(getdetiltask, sqlcon)
                sqlcon.Open()
                dr = com.ExecuteReader()
                dr.Read()

                VID = dr("VID").ToString
                NamaRemote = dr("NAMAREMOTE").ToString
                IPLAN = dr("IPLAN").ToString
                SID = dr("SID").ToString
                ALamatInstall = dr("AlamatInstall").ToString
                Provinsi = dr("PROVINSI").ToString
                Kota = dr("KOTA").ToString
                IDJARKOM = dr("idjarkom").ToString
                PIC = dr("PIC").ToString
                CustPhone = dr("CustPhone").ToString
                dr.Close()
                sqlcon.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            Dim tampungPMSUK As String = ""
            Dim cekPMSUK As String = "SELECT trDetail_Task.idJenisTask " & _
                                    "FROM trRemoteSite LEFT OUTER JOIN " & _
                                     "trDetail_Task ON trRemoteSite.VID = trDetail_Task.VID " & _
                                     "where trRemoteSite.VID = '" & VID & "'"
            com = New SqlCommand(cekPMSUK, con)
            con.Open()
            dr = com.ExecuteReader()
            dr.Read()
            If dr.HasRows Then

                If dr("idJenisTask").ToString <> "PM" Then
                    tampungPMSUK = "PM"
                Else
                    tampungPMSUK = ""
                End If

            Else

            End If
            dr.Close()
            con.Close()

            Dim cekdata As String = "select * from trDetail_Task where VID = '" & VID & "' and NoTask ='" & Session("notask") & "'"
            com = New SqlCommand(cekdata, con)
            con.Open()
            dr1 = com.ExecuteReader()
            dr1.Read()
            If dr1.HasRows() Then

            Else
                Dim insertIntoTrdetailTask As String = "insert into trDetail_Task (NoTask, VID, NAMAREMOTE, IPLAN, SID, ALAMAT, PROVINSI, KOTA, IdJarkom, IdStatusPerbaikan, PIC, NoHpPic, UserStamp, DateStamp, idJenisTask) VALUES ('" & Session("NoTask") & "', '" & VID & "', '" & NamaRemote & "', '" & IPLAN & "', '" & SID & "', '" & ALamatInstall & "', '" & Provinsi & "', '" & Kota & "', '" & IDJARKOM & "', '1', '" & PIC & "', '" & CustPhone & "', '" & Session("username") & "', GETDATE(), '" & tampungPMSUK & "')"
                Try
                    cmd = New SqlCommand(insertIntoTrdetailTask, sqlcon)
                    sqlcon.Open()
                    cmd.ExecuteNonQuery()
                    sqlcon.Close()
                    'Response.Write("1")
                Catch ex As Exception
                    Response.Write("11" & ex.Message)
                End Try
            End If
            dr.Close()
            sqlcon.Close()

            'Dim insertIntoTrdetailTask As String = "insert into trDetail_Task (NoTask, VID, NAMAREMOTE, IPLAN, SID, ALAMAT, PROVINSI, KOTA, IdJarkom, IdStatusPerbaikan, PIC, NoHpPic, UserStamp, DateStamp) VALUES ('" & Session("NoTask") & "', '" & VID & "', '" & NamaRemote & "', '" & IPLAN & "', '" & SID & "', '" & ALamatInstall & "', '" & Provinsi & "', '" & Kota & "', '" & IDJARKOM & "', '1', '" & PIC & "', '" & CustPhone & "', '" & Session("username") & "', GETDATE())"
            'Try
            '    cmd = New SqlCommand(insertIntoTrdetailTask, sqlcon)
            '    sqlcon.Open()
            '    cmd.ExecuteNonQuery()
            '    sqlcon.Close()
            '    'Response.Write("1")
            'Catch ex As Exception
            '    Response.Write("11" & ex.Message)
            'End Try
        End If
    End Sub


End Class
