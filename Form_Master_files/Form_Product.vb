Imports System.Data
Imports System.Data.SqlClient



Public Class Form_Product
    Private Sub Form_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
        BindingNavigator1.DeleteItem = Nothing
        BindingData()

    End Sub

    Private Sub BindingData(Optional cmd As SqlCommand = Nothing)
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
            command.CommandText = "SELECT * FROM Products"
        Else
            command = cmd
        End If

        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet()
        adapter.Fill(dataSt, "products")
        bindingSrc = New BindingSource(dataSt, "products")

        TextID.DataBindings.Add("Text", bindingSrc, "ProductID")
        TextName.DataBindings.Add("Text", bindingSrc, "ProductName")
        'TextPrice.Text = String.Format("#,#")
        TextPrice.DataBindings.Add("Text", bindingSrc, "UnitPrice")
        TextStock.DataBindings.Add("Text", bindingSrc, "UnitsInStock")
        TextDetail.DataBindings.Add("Text", bindingSrc, "QuantityPerUnit")
        PictureBox1.DataBindings.Add("Image", bindingSrc, "Picture", True)
        DateTimePicker1.DataBindings.Add("Text", bindingSrc, "DateAdd") 'ทำการทับค่าโดยเอาค่าจาก DATABASE มาเป็น Text

        '-- Complex Binding for Category
        command.CommandText = "SELECT CategoryID, CategoryName FROM Categories"
        adapter.SelectCommand = command
        adapter.Fill(dataSt, "categories")
        ComboCategory.DataSource = dataSt.Tables("categories")
        ComboCategory.DisplayMember = "CategoryName"   '-- คอลัมน์ที่ใช้ในการแสดงผล
        ComboCategory.ValueMember = "CategoryID"       '-- คอลัมน์ที่ใช้เชื่อมโยงกับตารางอื่น
        ComboCategory.DataBindings.Add("SelectedValue", bindingSrc, "CategoryID")  '-- เพิ่มใน BindingSource
        BindingNavigator1.BindingSource = bindingSrc
        CreateAutoComplete()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        OpenFileDialog1.Filter =
            "Image File(*.jpg,*.png,*.gif,*.bmp)|*.jpg;*.png;*.gif;*.bmp"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Bitmap.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) 
        If TextID.Text = "" Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub
    Private Sub InsertData()
        sql = "INSERT INTO Products(CategoryID,  ProductName, UnitPrice, UnitsInStock, QuantityPerUnit, Picture,Date) 
               VALUES(@cid, @name, @prc, @stk, @dtl, @pic)"

        command.CommandText = sql
        command.Parameters.Clear()
        '-- ข้อมูลที่ทำ Complex Binding ต้องอ่านค่าจากพร็อปเพอร์ตี้ SelectedValue 
        '-- ซึ่งเป็นค่า CatID ที่เชื่อมโยงระหว่างตาราง Category กับตาราง Product
        '-- และ SupID ก็เชื่อมโยงระหว่างตาราง Supplier กับตาราง Product เช่นเดียวกัน
        command.Parameters.AddWithValue("cid", ComboCategory.SelectedValue)
        command.Parameters.AddWithValue("name", TextName.Text)
        command.Parameters.AddWithValue("prc", TextPrice.Text)
        command.Parameters.AddWithValue("stk", TextStock.Text)
        command.Parameters.AddWithValue("dtl", TextDetail.Text)
        command.Parameters.AddWithValue("date", DateTimePicker1.Value)

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
    Private Sub UpdateData()
        sql = "UPDATE Products SET CategoryID = @cid, ProductName = @name, 
			   UnitPrice = @prc, UnitsInStock = @stk, QuantityPerUnit = @dtl, Picture = @pic, DateAdd = @date 
               WHERE ProductID = @pid"

        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("pid", TextID.Text)
        command.Parameters.AddWithValue("cid", ComboCategory.SelectedValue)
        command.Parameters.AddWithValue("name", TextName.Text)
        command.Parameters.AddWithValue("prc", TextPrice.Text)
        command.Parameters.AddWithValue("stk", TextStock.Text)
        command.Parameters.AddWithValue("dtl", TextDetail.Text)
        command.Parameters.AddWithValue("date", DateTimePicker1.Value)

        ''เกี่ยวกับเวันที่เวลา
        'Dim dateStr = $"{DateTimePicker1.Value.Year}/
        '{DateTimePicker1.Value.Month}/
        '{DateTimePicker1.Value.Day}"

        'command.Parameters.AddWithValue("date", dateStr)
        ''

        If Not (PictureBox1.Image Is Nothing) Then
            Dim pic() As Byte = ReadImage()
            command.Parameters.AddWithValue("pic", pic)
        Else
            command.Parameters.AddWithValue("pic", DBNull.Value)
        End If

        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถแก้ไขข้อมูลได้")
        Else
            MessageBox.Show("ข้อมูลได้รับการแก้ไขแล้ว")
            BindingData()
        End If
    End Sub

    Private Function ReadImage() As Byte()
        Dim memStream As New IO.MemoryStream()
        PictureBox1.Image.Save(memStream, PictureBox1.Image.RawFormat)
        Return memStream.ToArray()
    End Function

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) 
        Dim result As DialogResult =
        MessageBox.Show("ท่านต้องการลบข้อมูลลูกค้ารายนี้จริงหรือไม่", "ยืนยันการลบ",
                         MessageBoxButtons.OKCancel)

        If result = DialogResult.Cancel Then
            Exit Sub
        End If

        sql = "DELETE FROM Products WHERE ProductID = @id"
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
        sql = "Select ProductName FROM Products"
        command.CommandText = sql
        reader = command.ExecuteReader()
        Dim autoComp As New AutoCompleteStringCollection()
        While reader.Read()
            autoComp.Add(reader("ProductName"))
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

        sql = "Select * FROM Products WHERE ProductName Like '%' + @n + '%'"
        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("n", TextSearch.Text)
        BindingData(command)
    End Sub


    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If TextID.Text = "" Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim result As DialogResult =
        MessageBox.Show("ท่านต้องการลบข้อมูลนี้จริงหรือไม่", "ยืนยันการลบ",
                         MessageBoxButtons.OKCancel)

        If result = DialogResult.Cancel Then
            Exit Sub
        End If

        sql = "DELETE FROM ProductsD WHERE ProductDID = @id"
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


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MF.Show()
    End Sub
End Class