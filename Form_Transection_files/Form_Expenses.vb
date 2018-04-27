Imports System.Data
Imports System.Data.SqlClient 'ให้ใช้คำสั่ง Sql

Public Class Form_Expenses

    Private Sub Form_Expenses_Load(sender As Object, e As EventArgs) Handles Me.Load 'เมื่อเปิดฟอร์มนี้ขึ้นมาจะทำตามคำสั่งด้านล่าง
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
        BindingNavigator1.DeleteItem = Nothing
        BindingData()
    End Sub

    Private Sub BindingData(Optional cmd As SqlCommand = Nothing) 'ทำการผูกเพื่อแปะข้อมูลตามช่อง
        Dim tbx As TextBox
        Dim pbx As PictureBox
        Dim dpk As DateTimePicker
        Dim cmb As ComboBox

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                tbx = CType(ctrl, TextBox)
                tbx.DataBindings.Clear()
                tbx.Text = ""
            ElseIf TypeOf ctrl Is PictureBox Then
                pbx = CType(ctrl, PictureBox)
                pbx.DataBindings.Clear()
                pbx.Image = Nothing
            ElseIf TypeOf ctrl Is DateTimePicker Then
                dpk = CType(ctrl, DateTimePicker)
                dpk.DataBindings.Clear()
                dpk.Value = DateTime.Now
            ElseIf TypeOf ctrl Is ComboBox Then
                cmb = CType(ctrl, ComboBox)
                cmb.DataBindings.Clear()
                IIf(cmb.Items.Count > 0, cmb.SelectedIndex = 0, Nothing)
            End If
        Next

        If cmd Is Nothing Then
            command.CommandText = "SELECT * FROM Expenses"
        Else
            command = cmd
        End If

        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet()
        adapter.Fill(dataSt, "Expenses")
        bindingSrc = New BindingSource(dataSt, "Expenses")
        txtID.DataBindings.Add("Text", bindingSrc, "ExpensesID")
        txtDetail.DataBindings.Add("Text", bindingSrc, "ExpensesName")
        txtMoney.DataBindings.Add("text", bindingSrc, "ExpensesPrice")
        DateTimePicker1.DataBindings.Add("Text", bindingSrc, "ExpensesDate")
        BindingNavigator1.BindingSource = bindingSrc
        CreateAutoComplete()
    End Sub

    Private Sub CreateAutoComplete()
        sql = "Select ExpensesName FROM Expenses"
        command.CommandText = sql
        reader = command.ExecuteReader()
        Dim autoComp As New AutoCompleteStringCollection()
        While reader.Read()
            autoComp.Add(reader("ExpensesName"))
        End While
        reader.Close()
        TextSearch.AutoCompleteMode = AutoCompleteMode.Suggest
        TextSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextSearch.AutoCompleteCustomSource = autoComp
    End Sub 'เมื่อพิมพ์ในช่องค้นหาจะแสดงข้อมูล

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        'ถ้าในช่อง id ว่าง ให้เพิ่มข้อมูล ถ้าไม่ก็แก้ไขข้อมูล
        If txtID.Text = "" Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub 'ทำตามคำสั่งเมื่อกดปุ่ม save บนแถบเมนู

    Private Sub InsertData()
        sql = "INSERT INTO Expenses(ExpensesName, ExpensesPrice, ExpensesDate) 
               VALUES(@name, @prc, @date)"

        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("name", txtDetail.Text)
        command.Parameters.AddWithValue("prc", txtMoney.Text)
        command.Parameters.AddWithValue("date", DateTimePicker1.Value)
        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถเพิ่มข้อมูลได้")
        Else
            MessageBox.Show("บันทึกข้อมูลแล้ว")
            BindingData()
        End If
    End Sub

    Private Sub UpdateData()
        sql = "UPDATE Expenses SET  ExpensesName = @name, 
			   ExpensesPrice = @prc, ExpensesDate = @date 
               WHERE ExpensesID = @pid"

        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("pid", txtID.Text)
        command.Parameters.AddWithValue("name", txtDetail.Text)
        command.Parameters.AddWithValue("prc", txtMoney.Text)
        command.Parameters.AddWithValue("date", DateTimePicker1.Value)

        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถแก้ไขข้อมูลได้")
        Else
            MessageBox.Show("ข้อมูลได้รับการแก้ไขแล้ว")
            BindingData()
        End If
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        Dim result As DialogResult =
        MessageBox.Show("ท่านต้องการลบข้อมูลนี้จริงหรือไม่", "ยืนยันการลบ",
                         MessageBoxButtons.OKCancel)

        If result = DialogResult.Cancel Then
            Exit Sub
        End If

        sql = "DELETE FROM Expenses WHERE ExpensesID = @id"
        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("id", txtID.Text)

        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถลบข้อมูลได้")
        Else
            MessageBox.Show("ข้อมูลถูกลบแล้ว")
            BindingData()
        End If
    End Sub

End Class