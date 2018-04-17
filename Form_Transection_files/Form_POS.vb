Option Explicit On
Option Strict On
Imports System.Transactions
Imports System.Data
Imports System.Data.SqlClient

Public Class Form_POS
    Dim db As New DataClassesPosDataContext

    Public Shared Service_Bill As String = "" 'เป็นการประกาศตัวแปรเพื่อให้ใช้งานข้ามฟอร์มได้ แต่ในกรณีนี้นิว ให้ส่งค่า พารามิเตอร์ไปหา form Report เพื่อจะได้ปริ้น Report(ใบเสร็จออกมา)




    Private Sub Form_POS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '<<<ในส่วนนี้ นิว ประกาศไว้หาในส่วนของ ORDERID เพราะนิวใช้ LinQ แต่ลืม Binding ID เฉยๆ เริ่มแถนะครับ 
        'จะทำแบบว่าหาไอดีที่มากที่สุด แล้ว +1 เช่น ไอดีล่าสุดเป็น 1 ช่อง textboxID จะเป็น 2
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        command.CommandText = "SELECT * from Orders where OrderID = (select max(OrderID) from Orders)"
        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet 'ให้เอาคำสั่ง sql ที่อยุ่ในตัวแปร sql book มาเกบไว้ในตัวแปร da แบบ text
        adapter.Fill(dataSt, "Orders") 'แล้วเกบผลลัพท์ไว้ในบัพเฟิลผ่านตัวแปร ds
        Dim item As Integer
        item = CInt(dataSt.Tables("Orders").Rows(0).Item("OrderID").ToString())
        txtOrderID.Text = Format(item + 1)

        'ปิด>>>




        lsvProductList.Columns.Add("รหัสสินค้า", 100, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ชื่อสินค้า", 210, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ราคาขาย", 100, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("จำนวน", 90, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("รวมเป็นเงิน", 104, HorizontalAlignment.Left)
        lsvProductList.View = View.Details
        lsvProductList.GridLines = True
        lsvProductList.FullRowSelect = True

        Dim es = From em In db.Employees
                 Select em.EmployeeID, em.EmployeeName
        With cboEmployee
            .BeginUpdate()
            .DisplayMember = "EmployeeName"
            .ValueMember = "EmployeeID"
            .DataSource = es.ToList()
            .EndUpdate()
        End With
        txtAmount.ContextMenu = New ContextMenu()
        txtProductID.ContextMenu = New ContextMenu()
        ClearProductData()
        lblNet.Text = "0"
    End Sub

    Private Sub ClearProductData()
        txtProductID.Text = ""
        lblProductName.Text = ""
        lblSalePrice.Text = "0"
        txtAmount.Text = "1"
        lblTotal.Text = "0"
    End Sub

    Private Sub txtCustomerID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerID.KeyDown
        If txtCustomerID.Text.Trim() = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            Dim cs = From c In db.Customers Select c.CustomerID, c.CustomerName
                     Where CustomerID = CInt(txtCustomerID.Text)

            If cs.Count() > 0 Then
                txtCustomerID.Text = cs.FirstOrDefault.CustomerID.ToString 'ลองใส่เป็น tostring
                lblContactName.Text = cs.FirstOrDefault().CustomerName.Trim()
                txtProductID.Focus()
            Else
                MessageBox.Show("รหัสลูกค้าที่คุณป้อน ไม่มี !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearCustomerData()
                txtCustomerID.Focus()
            End If
        End If
    End Sub

    Private Sub ClearCustomerData()
        txtCustomerID.Text = ""
        lblContactName.Text = ""
    End Sub

    Private Sub txtProductID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductID.KeyDown
        If txtProductID.Text.Trim() = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            Dim ps = From p In db.Products Select p.ProductID, p.ProductName, p.UnitPrice
                     Where ProductID = CInt(txtProductID.Text)

            If ps.Count() > 0 Then
                txtProductID.Text = ps.FirstOrDefault().ProductID.ToString()
                lblProductName.Text = ps.FirstOrDefault().ProductName.Trim()
                lblSalePrice.Text = ps.FirstOrDefault().UnitPrice.ToString()
                CalculateTotal()
                txtAmount.Focus()
            Else
                MessageBox.Show("รหัสสินค้าที่คุณป้อน ไม่มี !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearCustomerData()
                txtProductID.Focus()
            End If
        End If
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If (txtAmount.Text.Trim() = "") Then
            txtAmount.Text = "1"
        End If
        If (CInt(txtAmount.Text) = 0) Then
            txtAmount.Text = "1"
        End If
        CalculateTotal()
    End Sub

    Private Sub CalculateTotal()
        Dim Total As Double
        Total = CDbl(lblSalePrice.Text) * CInt(txtAmount.Text)
        lblTotal.Text = Total.ToString("#,##0.00")
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If (txtProductID.Text.Trim() = "") Or (lblProductName.Text.Trim() = "") Then
            txtProductID.Focus()
            Exit Sub
        End If
        If CInt(txtAmount.Text) = 0 Then
            txtAmount.Focus()
            Exit Sub
        End If

        Dim i As Integer = 0
        Dim lvi As ListViewItem
        Dim tmpProductID As Integer = 0
        For i = 0 To lsvProductList.Items.Count - 1
            tmpProductID = CInt(lsvProductList.Items(i).SubItems(0).Text)
            If CInt(txtProductID.Text.Trim()) = tmpProductID Then
                MessageBox.Show("คุณเลือกสินค้าซ้ำกัน กรุณาเลือกใหม่ !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearProductData()
                txtProductID.Focus()
                txtProductID.SelectAll()
                Exit Sub
            End If
        Next

        Dim anyData() As String
        anyData = New String() {
            txtProductID.Text,
            lblProductName.Text,
            lblSalePrice.Text,
            txtAmount.Text,
            lblTotal.Text
        }
        lvi = New ListViewItem(anyData)
        lsvProductList.Items.Add(lvi)
        CalculateNet()
        ClearProductData()
        cmdSave.Enabled = True
        txtProductID.Focus()
    End Sub

    Private Sub lsvProductList_DoubleClick(sender As Object, e As EventArgs) Handles lsvProductList.DoubleClick
        Dim i As Integer = 0
        For i = 0 To lsvProductList.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = lsvProductList.SelectedItems(i)
            lsvProductList.Items.Remove(lvi)
        Next
        CalculateNet()
        txtProductID.Focus()
    End Sub

    Private Sub CalculateNet()
        Dim i As Integer = 0
        Dim tmpNetTotal As Double = 0
        For i = 0 To lsvProductList.Items.Count - 1
            tmpNetTotal += CDbl(lsvProductList.Items(i).SubItems(4).Text)
        Next
        lblNet.Text = tmpNetTotal.ToString("#,##0.00")
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        lsvProductList.Items.Clear()
        lblNet.Text = "0"
        txtProductID.Focus()
    End Sub

    Public Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtCustomerID.Text.Trim() = "" Then
            MessageBox.Show("กรุณาป้อนรหัสลูกค้า !!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCustomerID.Focus()
            Exit Sub
        End If

        If lsvProductList.Items.Count > 0 Then
            If MessageBox.Show("คุณต้องการบันทึกรายการสั่งซื้อสินค้า ใช่หรือไม่ ?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim o As New Order()
                o.CustomerID = CType(txtCustomerID.Text, Integer?) 'ลองแปลงค่าเป็น Integer
                o.EmployeeID = DirectCast(cboEmployee.SelectedValue, Integer?)
                o.OrderDate = Date.Now

                Dim i As Integer
                Dim od As OrdersDetail
                For i = 0 To lsvProductList.Items.Count - 1
                    od = New OrdersDetail()
                    od.ProductID = CInt(lsvProductList.Items(i).SubItems(0).Text)
                    od.UnitPrice = CDec(lsvProductList.Items(i).SubItems(2).Text)
                    od.Quantity = CShort(lsvProductList.Items(i).SubItems(3).Text)
                    od.Discount = 0
                    o.OrdersDetails.Add(od) 'ใช้คำสั่ง Add
                Next


                Using ts As New TransactionScope()
                    db.Orders.InsertOnSubmit(o)
                    db.SubmitChanges()
                    ts.Complete()
                End Using

                MessageBox.Show("บันทึกรายการสั่งซื้อสินค้า เรียบร้อยแล้ว !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Service_Bill = txtOrderID.Text
                Form_Report_POS.Show()

                lsvProductList.Clear()
                ClearCustomerData()
                ClearProductData()
                lblNet.Text = "0"
                txtCustomerID.Focus()

            End If
        End If
    End Sub

    Private Sub txtProductID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProductID.KeyPress
        If e.KeyChar < "0" Or e.KeyChar > "9" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar < "0" Or e.KeyChar > "9" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        db.Connection.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtOrderID.TextChanged

    End Sub

    Private Sub Form_POS_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim frm As New From_Main()
        frm.Show()
    End Sub
End Class