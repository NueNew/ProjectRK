Imports System.Data
Imports System.Data.SqlClient

Public Class From_Customers

    Private Sub From_Customers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        BindingData()
    End Sub

    'แปะข้อมูล
    Private Sub BindingData(Optional cmd As SqlCommand = Nothing)
        '-- ก่อนการ Binding ให้เคลียร์ข้อมูลและการ Binding เดิมเพื่อป้องกันข้อผิดพลาด
        Dim tbx As TextBox
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                tbx = CType(ctrl, TextBox)
                tbx.DataBindings.Clear()
                tbx.Text = ""
            End If
        Next
        '-- ถ้าไม่มีออบเจ็กต์ SqlCommand ส่งเข้ามาให้อ่านข้อมูลทั้งหมด แต่ถ้ามีให้ใช้ออบเจ็กต์นั้น
        If cmd Is Nothing Then
            command.CommandText = "SELECT * FROM Customers"
        Else
            command = cmd
        End If

        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet()
        adapter.Fill(dataSt, "Customers")

        bindingSrc = New BindingSource(dataSt, "Customers")
        TextID.DataBindings.Add("Text", bindingSrc, "CustomerID")
        TextName.DataBindings.Add("Text", bindingSrc, "CustomerName")
        TextPhone.DataBindings.Add("Text", bindingSrc, "Phone")
        TextAddress.DataBindings.Add("Text", bindingSrc, "Address")
        BindingNavigator1.BindingSource = bindingSrc
        CreateAutoComplete()


    End Sub

    'Sub เพิ่มข้อมูล
    Private Sub InsertData()
        sql = "INSERT INTO Customers(CustomerName, Phone , Address) 
               VALUES(@n, @p, @a)"

        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("n", TextName.Text)
        command.Parameters.AddWithValue("p", TextPhone.Text)
        command.Parameters.AddWithValue("a", TextAddress.Text)

        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถเพิ่มข้อมูลได้")
        Else
            MessageBox.Show("บันทึกข้อมูลแล้ว")
            BindingData()
        End If
    End Sub

    'Sub แก้ไขข้อมูล
    Private Sub UpdateData()
        sql = "UPDATE Customers SET CustomerName = @n, Phone = @p,  Address = @a 
               WHERE CustomerID = @i"

        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("n", TextName.Text)
        command.Parameters.AddWithValue("p", TextPhone.Text)
        command.Parameters.AddWithValue("a", TextAddress.Text)
        command.Parameters.AddWithValue("i", TextID.Text)

        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถแก้ไขข้อมูลได้")
        Else
            MessageBox.Show("ข้อมูลได้รับการแก้ไขแล้ว")
            BindingData()
        End If
    End Sub

    '-- สร้าง AutoComplete สำหรับช่องค้นหา
    Private Sub CreateAutoComplete()
        sql = "SELECT CustomerName FROM Customers"
        command.CommandText = sql
        reader = command.ExecuteReader()
        Dim autoComp As New AutoCompleteStringCollection()
        While reader.Read()
            autoComp.Add(reader("CustomerName"))
        End While
        reader.Close()
        TextSearch.AutoCompleteMode = AutoCompleteMode.Suggest
        TextSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextSearch.AutoCompleteCustomSource = autoComp
    End Sub

    '-- ค้นหาข้อมูล
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If String.IsNullOrEmpty(TextSearch.Text) Then
            BindingData()
            Exit Sub
        End If

        sql = "SELECT * FROM Customers WHERE CustomerName LIKE '%' + @n + '%'"
        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("n", TextSearch.Text)
        BindingData(command)
    End Sub

    'เมื่อกดปุ่มบันทึกข้อมูล
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If TextID.Text = "" Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub

    'เมื่อกดปุ่มบ้านจะกลับไปหน้าหลัก
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MF.Show()
    End Sub

    'ปุ่มลบ
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click

        Dim result As DialogResult =
        MessageBox.Show("ท่านต้องการลบข้อมูลนี้จริงหรือไม่", "ยืนยันการลบ",
                         MessageBoxButtons.OKCancel)

        If result = DialogResult.Cancel Then
            Exit Sub
        End If

        sql = "DELETE FROM Customers WHERE CustomerID = @id"
        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("id", TextID.Text)


        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถลบข้อมูลได้")
        Else
            MessageBox.Show("ข้อมูลถูกลบแล้ว")
            BindingData()
        End If
    End Sub
End Class