Imports System.Data
Imports System.Data.SqlClient

Public Class Form_ProductD
    Private Sub Form_ProductD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
        BindingNavigator1.DeleteItem = Nothing
        BindingData()

        'Bangkok-Vector
        'For Each ctrl As Control In Me.Controls
        '    If TypeOf ctrl Is MdiClient Then
        '        ctrl.BackgroundImage = My.Resources.Bangkok_Vector
        '    End If
        'Next

        'Me.BackgroundImage = My.Resources.Bangkok_Vector
    End Sub
    Private Sub BindingData(Optional cmd As SqlCommand = Nothing)
        Dim tbx As TextBox
        Dim cmb As ComboBox

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                tbx = CType(ctrl, TextBox)
                tbx.DataBindings.Clear()
                tbx.Text = ""
            ElseIf TypeOf ctrl Is ComboBox Then
                cmb = CType(ctrl, ComboBox)
                cmb.DataBindings.Clear()
                IIf(cmb.Items.Count > 0, cmb.SelectedIndex = 0, Nothing)
            End If
        Next

        If cmd Is Nothing Then
            command.CommandText = "SELECT * FROM ProductsD"
        Else
            command = cmd
        End If

        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet()
        adapter.Fill(dataSt, "productsd")
        bindingSrc = New BindingSource(dataSt, "productsd")

        TextID.DataBindings.Add("Text", bindingSrc, "ProductDID")
        TextName.DataBindings.Add("Text", bindingSrc, "ProductDName")
        TextDetail.DataBindings.Add("Text", bindingSrc, "QuantityPerUnit")

        '-- Complex Binding for Category
        command.CommandText = "SELECT CategoryDID, CategoryDName FROM CategoriesD"
        adapter.SelectCommand = command
        adapter.Fill(dataSt, "categories")
        ComboCategory.DataSource = dataSt.Tables("categories")
        ComboCategory.DisplayMember = "CategoryDName"   '-- คอลัมน์ที่ใช้ในการแสดงผล
        ComboCategory.ValueMember = "CategoryDID"       '-- คอลัมน์ที่ใช้เชื่อมโยงกับตารางอื่น
        ComboCategory.DataBindings.Add("SelectedValue", bindingSrc, "CategoryDID")  '-- เพิ่มใน BindingSource
        BindingNavigator1.BindingSource = bindingSrc
        CreateAutoComplete()
    End Sub
    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        If TextID.Text = "" Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub

    Private Sub InsertData()
        sql = "INSERT INTO ProductsD(CategoryDID,  ProductDName,  QuantityPerUnit) 
               VALUES(@cid, @name, @dtl)"

        command.CommandText = sql
        command.Parameters.Clear()
        '-- ข้อมูลที่ทำ Complex Binding ต้องอ่านค่าจากพร็อปเพอร์ตี้ SelectedValue 
        '-- ซึ่งเป็นค่า CatID ที่เชื่อมโยงระหว่างตาราง Category กับตาราง Product
        '-- และ SupID ก็เชื่อมโยงระหว่างตาราง Supplier กับตาราง Product เช่นเดียวกัน
        command.Parameters.AddWithValue("cid", ComboCategory.SelectedValue)
        command.Parameters.AddWithValue("name", TextName.Text)
        command.Parameters.AddWithValue("dtl", TextDetail.Text)


        Dim r As Integer = command.ExecuteNonQuery()
        If r = -1 Then
            MessageBox.Show("เกิดข้อผิดพลาด ไม่สามารถเพิ่มข้อมูลได้")
        Else
            MessageBox.Show("บันทึกข้อมูลแล้ว")
            BindingData()
        End If
    End Sub

    Private Sub UpdateData()
        sql = "UPDATE ProductsD SET CategoryDID = @cid, ProductDName = @name, 
			   QuantityPerUnit = @dtl
               WHERE ProductDID = @pid"

        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("pid", TextID.Text)
        command.Parameters.AddWithValue("cid", ComboCategory.SelectedValue)
        command.Parameters.AddWithValue("name", TextName.Text)
        command.Parameters.AddWithValue("dtl", TextDetail.Text)



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
        MessageBox.Show("ท่านต้องการลบข้อมูลลูกค้ารายนี้จริงหรือไม่", "ยืนยันการลบ",
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
    Private Sub CreateAutoComplete()
        sql = "Select ProductDName FROM ProductsD"
        command.CommandText = sql
        reader = command.ExecuteReader()
        Dim autoComp As New AutoCompleteStringCollection()
        While reader.Read()
            autoComp.Add(reader("ProductDName"))
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

        sql = "Select * FROM ProductsD WHERE ProductDName Like '%' + @n + '%'"
        command.CommandText = sql
        command.Parameters.Clear()
        command.Parameters.AddWithValue("n", TextSearch.Text)
        BindingData(command)
    End Sub

    Private Sub Form_ProductD_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Dim frm As New From_Main()
        'frm.Show()
    End Sub
End Class