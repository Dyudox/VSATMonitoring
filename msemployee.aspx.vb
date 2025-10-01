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

Partial Class msemployee
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbVsatConnectionString").ConnectionString)
    Dim dr As SqlDataReader
    Dim com As SqlCommand
    Dim tampungidprov, tampungidkota As String

  
    Protected Sub grid_employee_CellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs) Handles grid_employee.CellEditorInitialize
        Select Case e.Column.FieldName
            Case "idKota"
                InitializeCombokota(e, "idKota", dsKota, AddressOf cmbCombo2_OnCallback)
            Case "IdHomeBaseCity"
                InitializeComboCity(e, "IdHomeBaseCity", dskotahombase, AddressOf cmbCombo3_OnCallback)

            Case Else
        End Select
        If grid_employee.IsNewRowEditing Then
            If e.Column.FieldName = "NA" Then
                e.Editor.Value = "Y"
            End If
        Else
        End If
    End Sub

    Protected Sub InitializeCombokota(ByVal e As ASPxGridViewEditorEventArgs, ByVal parentComboName As String, ByVal source As SqlDataSource, ByVal callBackHandler As CallbackEventHandlerBase)

        Dim id As String = String.Empty
        If (Not grid_employee.IsNewRowEditing) Then
            Dim val As Object = grid_employee.GetRowValuesByKeyValue(e.KeyValue, parentComboName)
            If (val Is Nothing OrElse val Is DBNull.Value) Then
                id = Nothing
            Else
                id = val.ToString()
            End If
        End If
        Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
        If combo IsNot Nothing Then
            ' unbind combo
            combo.DataSourceID = Nothing
            FillComboSubject(combo, id, source)
            AddHandler combo.Callback, callBackHandler
        End If
        Return
    End Sub

    Protected Sub InitializeComboCity(ByVal e As ASPxGridViewEditorEventArgs, ByVal parentComboName As String, ByVal source As SqlDataSource, ByVal callBackHandler As CallbackEventHandlerBase)

        Dim id As String = String.Empty
        If (Not grid_employee.IsNewRowEditing) Then
            Dim val As Object = grid_employee.GetRowValuesByKeyValue(e.KeyValue, parentComboName)
            If (val Is Nothing OrElse val Is DBNull.Value) Then
                id = Nothing
            Else
                id = val.ToString()
            End If
        End If
        Dim combo As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
        If combo IsNot Nothing Then
            ' unbind combo
            combo.DataSourceID = Nothing
            FillComboSubject(combo, id, source)
            AddHandler combo.Callback, callBackHandler
        End If
        Return
    End Sub

    Private Sub cmbCombo3_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
        FillComboUnitKerja(TryCast(source, ASPxComboBox), e.Parameter, dskotahombase)
    End Sub

    Private Sub cmbCombo2_OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
        FillComboUnitKerja(TryCast(source, ASPxComboBox), e.Parameter, dsKota)
    End Sub

    Protected Sub FillComboUnitKerja(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
        cmb.Items.Clear()
        ' trap null selection
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        ' get the values
        source.SelectParameters(0).DefaultValue = id
        Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
        For Each row As DataRowView In view
            cmb.Items.Add(row(3).ToString(), row(1))
        Next row
    End Sub

    Protected Sub FillComboSubject(ByVal cmb As ASPxComboBox, ByVal id As String, ByVal source As SqlDataSource)
        cmb.Items.Clear()
        ' trap null selection
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        ' get the values
        source.SelectParameters(0).DefaultValue = id
        Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
        For Each row As DataRowView In view
            cmb.Items.Add(row(4).ToString(), row(2))
        Next row
    End Sub

    'Private Sub combo_Callback(ByVal sender As Object, ByVal e As CallbackEventArgsBase)
    '    FillCitiesComboBox(TryCast(sender, ASPxComboBox), e.Parameter, dsprovinsi)
    'End Sub

    'Protected Sub FillCitiesComboBox(ByVal combo As ASPxComboBox, ByVal IdProvinsi As Integer, ByVal source As SqlDataSource)
    '    combo.Items.Clear()
    '    ' trap null selection
    '    If String.IsNullOrEmpty(ID) Then
    '        Return
    '    End If

    '    ' get the values
    '    source.SelectParameters(0).DefaultValue = ID
    '    Dim view As DataView = CType(source.Select(DataSourceSelectArguments.Empty), DataView)
    '    For Each row As DataRowView In view
    '        combo.Items.Add(row(3).ToString(), row(2))
    '    Next row
    'End Sub

    'Protected Sub grid_detil_employee_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
    '    Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
    '    Dim idcustomer As String = ""
    '    Dim getidcustomer As String = "select ID from msemployee where ID = '" & Session("ID") & "'"
    '    com = New SqlCommand(getidcustomer, con)
    '    con.Open()
    '    dr = com.ExecuteReader()
    '    dr.Read()
    '    idcustomer = dr("ID").ToString
    '    dr.Close()
    '    con.Close()

    '    dsdetilemployee.SelectCommand = "select * from msemployee WHERE ID='" & idcustomer & "'"
    '    dsdetilemployee.InsertCommand = "INSERT INTO msemployee (AlamatHomeBase, IdHomeBaseProvinsi, IdHomeBaseCity, IdHomeBaseKecamatan, IdHomeBaseKelurahan, DateStamp, UserStamp) VALUES (@AlamatHomeBase, @IdHomeBaseProvinsi, @IdHomeBaseCity, @IdHomeBaseKecamatan, @IdHomeBaseKelurahan, GETDATE(), '" & Session("username") & "')"
    '    dsdetilemployee.UpdateCommand = "UPDATE msemployee SET AlamatHomeBase=@AlamatHomeBase, IdHomeBaseProvinsi=@IdHomeBaseProvinsi, IdHomeBaseCity = @IdHomeBaseCity, IdHomeBaseKecamatan = @IdHomeBaseKecamatan, IdHomeBaseKelurahan = @IdHomeBaseKelurahan,  DateStamp = GETDATE(), UserStamp = '" & Session("username") & "' WHERE ID=@ID"
    '    'dsdetilemployee.DeleteCommand = "DELETE FROM msemployee WHERE ID=@ID"
    'End Sub


    Protected Sub grid_employee_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles grid_employee.RowDeleting
        dsemployee.DeleteCommand = "Delete from msemployee where ID = @ID"
        grid_employee.DataBind()
    End Sub

    Protected Sub grid_employee_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grid_employee.RowInserting
        dsemployee.InsertCommand = "Insert Into msemployee ( NIK, Nama, Coordinator, IdHomeBaseProvinsi, AlamatHomeBase, IdHomeBaseCity, IdStatus, email, NomorHP, alamat, IdProvinsi, idKota, EmployeeType, AccountBank, NamaBank, RekeningBank, IdPerusahaan, IdStatusPegawai, UserStamp, TimeStamp) VALUES (@NIK, @Nama, @Coordinator, @IdHomeBaseProvinsi, @AlamatHomeBase, @IdHomeBaseCity, @IdStatus, @email, @NomorHP, @alamat, @IdProvinsi, @idKota, @EmployeeType, @AccountBank, @NamaBank, @RekeningBank, @IdPerusahaan, @IdStatusPegawai, '" & Session("username") & "', GETDATE())"

        grid_employee.DataBind()
    End Sub


    Protected Sub grid_employee_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles grid_employee.RowUpdating
        Dim cekprov As String = e.NewValues("IdHomeBaseCity").ToString
        Dim lamaprov As String = e.OldValues("IdHomeBaseCity").ToString
        Dim cekkota As String = e.NewValues("IdHomeBaseProvinsi").ToString
        Dim lamakota As String = e.OldValues("IdHomeBaseProvinsi").ToString

        Dim getidprov As String = "select * from msProvinsi where Provinsi = '" & cekkota & "' or IdProvinsi = '" & cekkota & "'"
        com = New SqlCommand(getidprov, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        tampungidprov = dr("idProvinsi").ToString
        dr.Close()
        con.Close()

        Dim getidkota As String = "select * from msKota where Kota = '" & cekprov & "' or idKota = '" & cekprov & "'"
        com = New SqlCommand(getidkota, con)
        con.Open()
        dr = com.ExecuteReader()
        dr.Read()
        tampungidkota = dr("idKota").ToString
        dr.Close()
        con.Close()

        dsemployee.UpdateCommand = " update msemployee set NIK = @NIK, Nama = @Nama, Coordinator = @Coordinator, AlamatHomeBase = @AlamatHomeBase, IdStatus = @IdStatus, IdHomeBaseProvinsi = '" & tampungidprov & "', IdHomeBaseCity = '" & tampungidkota & "',  UserStamp = '" & Session("username") & "', email = @email, NomorHP = @NomorHP, alamat = @alamat, IdProvinsi = @IdProvinsi, idKota = @idKota, EmployeeType = @EmployeeType, AccountBank = @AccountBank, NamaBank = @NamaBank, RekeningBank = @RekeningBank, IdPerusahaan = @IdPerusahaan, IdStatusPegawai = @IdStatusPegawai, TimeStamp = GETDATE() where ID = @ID"
        grid_employee.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserName") = "" Then
            Response.Redirect("~/login.aspx")
        End If
        dsemployee.SelectCommand = "select * from msEmployee"

        'If (Not IsPostBack) Then
        '    grid_employee.StartEdit(0)
        'End If
    End Sub

    Private Sub FillCitiesComboBox(aSPxComboBox As ASPxComboBox, p2 As String, sqlDataSource As SqlDataSource)
        Throw New NotImplementedException
    End Sub

    Protected Sub gv_detilemployee_DataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("ID") = (TryCast(sender, ASPxGridView)).GetMasterRowKeyValue()
        dsdetilemployee.SelectCommand = "select * from msEmployee where ID = '" & Session("ID") & "'"
    End Sub

    'Protected Sub gv_detilemployee_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
    '    dsdetilemployee.InsertCommand = "UPDATE msEmployee SET email = @email, NomorHP = @NomorHP, alamat = @alamat, IdProvinsi = @IdProvinsi, idKota = @idKota, EmployeeType = @EmployeeType, AccountBank = @AccountBank, NamaBank = @NamaBank, RekeningBank = @RekeningBank, IdPerusahaan = @IdPerusahaan, IdStatusPegawai = @IdStatusPegawai,  TimeStamp = GETDATE(), UserStamp = '" & Session("username") & "' WHERE ID='" & Session("ID") & "'"

    'End Sub

    'Protected Sub gv_detilemployee_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)

    'End Sub

    'Protected Sub gv_detilemployee_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)

    '    dsdetilemployee.DeleteCommand = "DELETE FROM msEmployee WHERE ID='" & Session("ID") & "'"
    'End Sub

    'Protected Sub gv_detilemployee_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
    '    dsdetilemployee.UpdateCommand = "UPDATE msEmployee SET email = @email, NomorHP = @NomorHP, alamat = @alamat, IdProvinsi = @IdProvinsi, idKota = @idKota, EmployeeType = @EmployeeType, AccountBank = @AccountBank, NamaBank = @NamaBank, RekeningBank = @RekeningBank, IdPerusahaan = @IdPerusahaan, IdStatusPegawai = @IdStatusPegawai,  TimeStamp = GETDATE(), UserStamp = '" & Session("username") & "' WHERE ID='" & Session("ID") & "'"
    'End Sub

    Protected Sub grid_employee_RowValidating(sender As Object, e As DevExpress.Web.Data.ASPxDataValidationEventArgs)

    End Sub
End Class
