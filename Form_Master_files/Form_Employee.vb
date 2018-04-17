Imports System.Data
Imports System.Data.SqlClient


Public Class Form_Employee
    Private Sub Form_Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
        BindingNavigator1.DeleteItem = Nothing
        BindingData()
    End Sub

    Friend Sub BindingData(Optional cmd As SqlCommand = Nothing)
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
            command.CommandText = "SELECT * FROM Employees"
        Else
            command = cmd
        End If

        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet()
        adapter.Fill(dataSt, "employees")
        bindingSrc = New BindingSource(dataSt, "employees")

        TextID.DataBindings.Add("Text", bindingSrc, "EmployeeID")
        TextName.DataBindings.Add("Text", bindingSrc, "EmployeeName")
        TextPhone.DataBindings.Add("Text", bindingSrc, "Phone")
        TextAddress.DataBindings.Add("Text", bindingSrc, "Address")
        PictureBox1.DataBindings.Add("Image", bindingSrc, "Photo", True)
        TextUsername.DataBindings.Add("Text", bindingSrc, "Username")
        TextPassword.DataBindings.Add("Text", bindingSrc, "Password")


        BindingNavigator1.BindingSource = bindingSrc
        CreateAutoComplete()
    End Sub

    Private Sub LinkImage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkImage.LinkClicked
        OpenFileDialog1.Filter =
            "Image File(*.jpg,*.png,*.gif,*.bmp)|*.jpg;*.png;*.gif;*.bmp"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Bitmap.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        If TextID.Text = "" Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub

    Private Sub InsertData()
        sql = "INSERT INTO Employees( EmployeeName, Address, Phone, Username, Password, Photo) 
               VALUES(@fname, @add,@ph ,@username,@password, @pic)"

        command.CommandText = sql
        command.Parameters.Clear()

        command.Parameters.AddWithValue("fname", TextName.Text)
        command.Parameters.AddWithValue("ph", TextPhone.Text)
        command.Parameters.AddWithValue("add", TextAddress.Text)
        command.Parameters.AddWithValue("username", TextUsername.Text)
        command.Parameters.AddWithValue("password", TextPassword.Text)


        If Not (PictureBox1.Image Is Nothing) Then
            Dim pic() As Byte = ReadImage()
            command.Parameters.AddWithValue("pic", pic)
        Else
            command.Parameters.AddWithValue("pic", DBNull.Value)
        End If

        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถเพิ่มข้อมูลได้")
        Else
            MessageBox.Show("บันทึกข้อมูลแล้ว")
            BindingData()
        End If
    End Sub

    Private Function ReadImage() As Byte()
        Dim memStream As New IO.MemoryStream()
        PictureBox1.Image.Save(memStream, PictureBox1.Image.RawFormat)
        Return memStream.ToArray()
    End Function

    Private Sub UpdateData()

        sql = "UPDATE Employees Set EmployeeName = @fname,                Address = @add, Phone = @ph, Username = @username,               Password = @password, Photo = @pic WHERE EmployeeID = @eid "

        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("eid", TextID.Text)
        command.Parameters.AddWithValue("fname", TextName.Text)
        command.Parameters.AddWithValue("ph", TextPhone.Text)
        command.Parameters.AddWithValue("add", TextAddress.Text)
        command.Parameters.AddWithValue("username", TextUsername.Text)
        command.Parameters.AddWithValue("password", TextPassword.Text)


        If Not (PictureBox1.Image Is Nothing) Then
            Dim pic() As Byte = ReadImage()
            command.Parameters.AddWithValue("pic", pic)
        Else
            command.Parameters.AddWithValue("pic", DBNull.Value)
        End If

        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถเพิ่มข้อมูลได้")
        Else
            MessageBox.Show("บันทึกข้อมูลแล้ว")
            BindingData()
        End If
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        Dim result As DialogResult =
            MessageBox.Show("ท่านต้องการลบข้อมูลรายนี้จริงหรือไม่", "ยืนยันการลบ",
                            MessageBoxButtons.OKCancel)

        If result = DialogResult.Cancel Then
            Exit Sub
        End If

        sql = "DELETE FROM Employees WHERE EmployeeID = @id"
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
    Private Sub CreateAutoComplete()
        sql = "Select EmployeeName AS PerName FROM Employees"
        command.CommandText = sql
        reader = command.ExecuteReader()
        Dim autoComp As New AutoCompleteStringCollection()
        While reader.Read()
            autoComp.Add(reader("PerName"))
        End While
        reader.Close()
        TextSearch.AutoCompleteMode = AutoCompleteMode.Suggest
        TextSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextSearch.AutoCompleteCustomSource = autoComp
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If String.IsNullOrEmpty(TextSearch.Text) Then
            BindingData()
            Exit Sub
        End If

        sql = "SELECT * FROM Employees
               WHERE (EmployeeName LIKE '%' + @n + '%')"

        command.CommandText = sql
        command.Parameters.Clear()
        Dim name() = TextSearch.Text.Split(" ")

        command.Parameters.AddWithValue("n", name(0))

        BindingData(command)
    End Sub

    Private Sub Form_Employee_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim frm As New From_Main()
        frm.Show()
    End Sub
End Class