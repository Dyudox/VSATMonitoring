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

Partial Class ms_Kelurahan
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        ' dskelurahan.SelectCommand = "SELECT a.Kecamatan, b.IdKelurahan, b.Kelurahan, b.ID, a.idKecamatan FROM msKecamatan as a INNER JOIN msKelurahan as b ON a.IdKecamatan = b.IdKecamatan order by ID"

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        'dskecamatan.SelectCommand = "select * from v_kecamatan"
        dskelurahan.SelectCommand = "SELECT msKelurahan.ID, msKelurahan.idKelurahan, msKelurahan.Kelurahan, msKecamatan.idKecamatan, msKecamatan.Kecamatan, msKota.idKota, msKota.Kota " & _
                                    "FROM msKelurahan INNER JOIN " & _
                                    "msKecamatan ON msKelurahan.idKecamatan = msKecamatan.idKecamatan INNER JOIN " & _
                                    "msKota ON msKecamatan.idKota = msKota.idKota"
    End Sub
    Protected Sub grid_kelurahan_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_kelurahan.RowDeleting
        dskelurahan.DeleteCommand = "delete from msKelurahan where ID = @ID"
        grid_kelurahan.DataBind()
    End Sub

    Protected Sub grid_kelurahan_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_kelurahan.RowInserting
        Dim idakhir As String
        Dim tampungidkecamatan As String = e.NewValues("idKecamatan")
        Dim getidakhir As String = "select * from msKelurahan where SUBSTRING(idKelurahan, 1,7) = '" & tampungidkecamatan & "' order by idKelurahan desc"
        com = New SqlCommand(getidakhir, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            idakhir = dr("idKelurahan").ToString
        End If
        dr.Close()
        con.Close()

        If idakhir = "" Then
            dskelurahan.InsertCommand = "Insert into msKelurahan (idKecamatan, idKelurahan, Kelurahan, UserStamp, TimeStamp) VALUES (@idKecamatan, '" & tampungidkecamatan & "101', @Kelurahan, '" & Session("username") & "', GETDATE())"
            grid_kelurahan.DataBind()
        Else
            Dim idsuk As String = idakhir + 1
            dskelurahan.InsertCommand = "Insert into msKelurahan (idKecamatan, idKelurahan, Kelurahan, UserStamp, TimeStamp) VALUES (@idKecamatan, '" & idsuk & "', @Kelurahan, '" & Session("username") & "', GETDATE())"
            grid_kelurahan.DataBind()
        End If

       
    End Sub


    Protected Sub grid_kelurahan_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_kelurahan.RowUpdating
        Dim tampungidkecamatan As String = e.NewValues("idKecamatan")
        Dim getidakhir As String = "select * from msKelurahan where SUBSTRING(idKelurahan, 1,7) = '" & tampungidkecamatan & "' order by idKelurahan desc"
        com = New SqlCommand(getidakhir, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        Dim idakhir As String = dr("idKelurahan").ToString
        dr.Close()
        con.Close()
        Dim idsuk As String = idakhir + 1

        dskelurahan.UpdateCommand = "Update msKelurahan set idKecamatan = @idKecamatan, idKelurahan = @idKelurahan, Kelurahan = @Kelurahan, UserStamp = '" & Session("username") & "', TimeStamp = GETDATE() where ID = @ID"
        grid_kelurahan.DataBind()
    End Sub

    'Protected Sub grid_kelurahan_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)
    '    Select Case e.Column.FieldName
    '        Case "idKecamatan"
    '            InitializeCombokota(e, "idKecamatan", dsloadkecamatan, AddressOf cmbCombo2_OnCallback)
    '            'Case "IdHomeBaseCity"
    '            '    InitializeComboCity(e, "IdHomeBaseCity", dskotahombase, AddressOf cmbCombo3_OnCallback)

    '        Case Else
    '    End Select
    '    If grid_kelurahan.IsNewRowEditing Then
    '        If e.Column.FieldName = "NA" Then
    '            e.Editor.Value = "Y"
    '        End If
    '    Else
    '    End If
    'End Sub
    'Protected Sub InitializeCombokota(ByVal e As ASPxGridViewEditorEventArgs, ByVal parentComboName As String, ByVal source As SqlDataSource, ByVal callBackHandler As CallbackEventHandlerBase)

    '    Dim id As String = String.Empty
    '    If (Not grid_kelurahan.IsNewRowEditing) Then
    '        Dim val As Object = grid_kelurahan.GetRowValuesByKeyValue(e.KeyValue, parentComboName)
    '        If (val Is Nothing OrElse val Is DBNull.Value) Then
    '            id = Nothing
    '        Else
    '            id = val.ToString()
    '        End If
    '    End If
    '    Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
    '    If combo IsNot Nothing Then
    '        ' unbind combo
    '        combo.DataSourceID = Nothing
    '        FillComboSubject(combo, id, source)
    '        AddHandler combo.Callback, callBackHandler
    '    End If
    '    Return
    'End Sub

    'Private Sub cmbCombo2_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
    '    FillComboUnitKerja(TryCast(source, ASPxComboBox), e.Parameter, dsloadkecamatan)
    'End Sub

    'Protected Sub FillComboUnitKerja(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
    '    cmb.Items.Clear()
    '    ' trap null selection
    '    If String.IsNullOrEmpty(id) Then
    '        Return
    '    End If

    '    ' get the values
    '    source.SelectParameters(0).DefaultValue = id
    '    Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
    '    For Each row As DataRowView In view
    '        cmb.Items.Add(row(3).ToString(), row(1))
    '    Next row
    'End Sub

    'Protected Sub FillComboSubject(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
    '    cmb.Items.Clear()
    '    ' trap null selection
    '    If String.IsNullOrEmpty(id) Then
    '        Return
    '    End If

    '    ' get the values
    '    source.SelectParameters(0).DefaultValue = id
    '    Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
    '    For Each row As DataRowView In view
    '        cmb.Items.Add(row(4).ToString(), row(2))
    '    Next row
    'End Sub
End Class
