﻿Option Explicit On 'คำสั่งนี้เป็นการบังคับให้ทุกๆตัวแปรที่ถูกใช้งานในโปรแกรมนี้ต้องถูกประกาศด้วยคำสั่ง Dim
Option Strict On 'กาหนดให้มีการตรวจสอบโค้ดของภาษา VB อย่างเคร่งครัด ให้ภาษา VB มีระดับเช่นเดียวกับภาษา VC#
Imports System.Transactions
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class Form_POS
    Dim db As New DataClassesDataContext

    Private Sub cc() 'เชื่อมกับฐานข้อมูล SQL SERVER
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
    End Sub

    Private Sub reloadPOS()
        '<<<ในส่วนนี้ นิว ประกาศไว้หาในส่วนของ ORDERID เพราะนิวใช้ LinQ แต่ลืม Binding ID เฉยๆ เริ่มแถนะครับ 
        'จะทำแบบว่าหาไอดีที่มากที่สุด แล้ว +1 เช่น ไอดีล่าสุดเป็น 1 ช่อง textboxID จะเป็น 2
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        command.CommandText = "SELECT * from Orders where OrderID = (select max(OrderID) from Orders)"
        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet 'ให้เอาคำสั่ง sql ที่อยุ่ในตัวแปร sql book มาเกบไว้ในตัวแปร da แบบ text
        adapter.Fill(dataSt, "Orders") 'แล้วเกบผลลัพท์ไว้ในบัพเฟิลผ่านตัวแปร ds
        If dataSt.Tables("Orders").Rows.Count <> 0 Then
            Dim item As Integer
            item = CInt(dataSt.Tables("Orders").Rows(0).Item("OrderID").ToString())
            txtOrderID.Text = Format(item + 1)
        Else
            txtOrderID.Text = "1"
        End If
        'ปิด>>>

        lsvProductList.Columns.Add("ประเภทสินค้า", 0, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("รหัสสินค้า", 150, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ชื่อสินค้า", 272, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ราคาขาย", 100, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("จำนวน", 90, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("รวมเป็นเงิน", 154, HorizontalAlignment.Left)
        lsvProductList.View = View.Details
        lsvProductList.GridLines = True
        lsvProductList.FullRowSelect = True

        txtProductID.ContextMenu = New ContextMenu()
        ClearProductData()
        lblNet.Text = "0"


    End Sub

    Private Sub Form_POS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cc()
        reloadPOS()
    End Sub

    Private Sub ClearProductData()
        txtProductID.Text = ""
        lblProductName.Text = ""
        lblSalePrice.Text = "0"
        lblTotal.Text = "0"
        txtStockLeft.Text = "0"
        txtCate.Text = ""
        num_exit.Value = 1
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
            Dim ps = From p In db.Products Join c In db.Categories On p.CategoryID Equals c.CategoryID Select p.ProductID, p.ProductName, p.UnitPrice, p.UnitsInStock, c.CategoryName
                     Where ProductID = CInt(txtProductID.Text)

            If ps.Count() > 0 Then
                txtProductID.Text = ps.FirstOrDefault().ProductID.ToString()
                lblProductName.Text = ps.FirstOrDefault().ProductName.Trim()
                lblSalePrice.Text = ps.FirstOrDefault().UnitPrice.ToString()
                txtStockLeft.Text = ps.FirstOrDefault().UnitsInStock.ToString()
                txtCate.Text = ps.FirstOrDefault().CategoryName.ToString()

                num_exit.Maximum = Convert.ToInt16(txtStockLeft.Text) 'ให้ค่าไม่เกินกับข้อมูลสินค้าในฐานข้อมูล 
                'ให้การเลือกจำนวนไม่เกิน ข้อมูลในตารางสินค้า โดยที่ได้แปลงค่าจาก String เป็น Decimal
                CalculateTotal()
                num_exit.Focus()
            Else
                MessageBox.Show("รหัสสินค้าที่คุณป้อน ไม่มี !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearCustomerData()
                txtProductID.Focus()
            End If
        End If
    End Sub

    Private Sub CalculateTotal()
        Dim Total As Double
        Total = CDbl(lblSalePrice.Text) * num_exit.Value
        lblTotal.Text = Total.ToString("#,##0.00")
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If (txtProductID.Text.Trim() = "") Or (lblProductName.Text.Trim() = "") Then
            txtProductID.Focus()
            Exit Sub
        End If


        Dim i As Integer = 0
        Dim lvi As ListViewItem
        Dim tmpProductID As Integer = 0
        For i = 0 To lsvProductList.Items.Count - 1
            tmpProductID = CInt(lsvProductList.Items(i).SubItems(1).Text)
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
            txtCate.Text,
            txtProductID.Text,
            lblProductName.Text,
            lblSalePrice.Text,
            num_exit.Value.ToString,
            lblTotal.Text
        }
        'งงจ้าตอนนี้ คิดว่าจะเปลี่ยนเป็น numexit
        ' num_exit.Value.ToString, '
        'ลองเปลี่ยน txtAmount.Text เป็น num_exit.value.ToString

        lvi = New ListViewItem(anyData)
        lsvProductList.Items.Add(lvi)
        CalculateNet()
        ClearProductData()
        cmdSave.Enabled = True
        txtProductID.Focus()
    End Sub

    'ถ้า ดับเบิลคลิกเลือกใน listview จะทำการนำรายการนั้นออก
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

    'รวมจำนวนเงินใน listview
    Private Sub CalculateNet()
        Dim i As Integer = 0
        Dim tmpNetTotal As Double = 0
        For i = 0 To lsvProductList.Items.Count - 1
            tmpNetTotal += CDbl(lsvProductList.Items(i).SubItems(5).Text)
        Next
        lblNet.Text = tmpNetTotal.ToString("#,##0.00")
    End Sub

    'ปุ่มล้างค่าใน listview
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
                o.EmployeeID = CType(Form_Login.emp_id, Integer?)
                o.OrderDate = DateTime.Now
                o.CBID = 2
                Dim p As New Product() 'บอกว่า p คือตาราง Product 

                Dim i As Integer
                Dim od As OrdersDetail
                For i = 0 To lsvProductList.Items.Count - 1
                    od = New OrdersDetail()
                    p = New Product()
                    od.ProductID = CInt(lsvProductList.Items(i).SubItems(1).Text)
                    od.UnitPrice = CDec(lsvProductList.Items(i).SubItems(3).Text)
                    od.Quantity = CShort(lsvProductList.Items(i).SubItems(4).Text)

                    o.OrdersDetails.Add(od) 'ใช้คำสั่ง Add
                Next


                'ตัดสต็อก
                For i = 0 To lsvProductList.Items.Count - 1
                    Dim cmdU As New SqlCommand("Update P set P.UnitsInStock = P.UnitsInStock - " & CInt(lsvProductList.Items(i).SubItems(4).Text) & " FROM Products AS P INNER JOIN OrdersDetails AS S ON (P.ProductID = S.ProductID) WHERE S.ProductID='" & CStr(lsvProductList.Items(i).SubItems(1).Text) & "'", connection)
                    cmdU.ExecuteNonQuery()
                Next

                'เอาข้อมูลเข้า BalanceSheet
                For i = 0 To lsvProductList.Items.Count - 1
                    sql = "INSERT INTO TEST(DATE,NAME,MONEY,CBID) VALUES(@DATT,@N,@M,@C)"
                    command.CommandText = sql
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("DATT", DateTime.Now.Date)
                    command.Parameters.AddWithValue("N", lsvProductList.Items(i).SubItems(0).Text)
                    command.Parameters.AddWithValue("M", lsvProductList.Items(i).SubItems(5).Text)
                    command.Parameters.AddWithValue("C", 2)
                    command.ExecuteNonQuery()
                Next



                Using ts As New TransactionScope()
                    db.Orders.InsertOnSubmit(o)
                    db.SubmitChanges()
                    ts.Complete()
                End Using

                MessageBox.Show("บันทึกรายการสั่งซื้อสินค้า เรียบร้อยแล้ว !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)


                lsvProductList.Clear()
                ClearCustomerData()
                ClearProductData()
                lblNet.Text = "0"
                txtCustomerID.Focus()

                Dim rpt As New ReportDocument 'บอกว่า rpt คือ Report
                Dim directory As String = My.Application.Info.DirectoryPath

                rpt.Load("C:\MYPROJECT\ProjectRK\Forms_Report_files\CR_POS.rpt") 'หาที่อยู่ของไฟล์Report
                rpt.SetParameterValue("ORDERID", Me.txtOrderID.Text) 'ส่งค่าจาก  txtOrderId จาก Form นี้ไปหา ตัวรับ ORDERIDในไฟล์Report

                Form_Report_CR_POS.CrystalReportViewer1.ReportSource = rpt
                Form_Report_CR_POS.CrystalReportViewer1.Refresh()
                Form_Report_CR_POS.Show()
                Form_Report_CR_POS.WindowState = FormWindowState.Maximized
                reloadPOS()

            End If
        End If
    End Sub

    'ถ้าจำนวนที่เลือกเปลี่ยน
    Private Sub num_exit_ValueChanged(sender As Object, e As EventArgs) Handles num_exit.ValueChanged
        CalculateTotal()
    End Sub

    'ปุ่มกลับบ้าน
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MF.Show()
    End Sub

    'เมื่อทำการกดปุ่มเลือกข้อมูลผู้บริจาคจะให้แสดง FormDCustomer ขึ้นมาแล้วรับค่าตามที่เลือกใน FormDCustomer
    Private Sub BtnSCus_Click(sender As Object, e As EventArgs) Handles BtnSCus.Click
        FormDCustomer.ShowDialog()
        Me.txtCustomerID.Text = CType(FormDCustomer.id_customer, String)
    End Sub

    'เมื่อข้อมูลใน txtCustomerID เปลี่ยน ให้ใส่ข้อมูลที่นำมาจาก DB 
    Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerID.TextChanged
        If txtCustomerID.Text.Trim() = "" Then Exit Sub

        Dim cs = From c In db.Customers Select c.CustomerID, c.CustomerName
                 Where CustomerID = CInt(txtCustomerID.Text)

        If cs.Count() > 0 Then
            txtCustomerID.Text = cs.FirstOrDefault.CustomerID.ToString 'ลองใส่เป็น tostring
            lblContactName.Text = cs.FirstOrDefault().CustomerName.Trim()
            txtProductID.Focus()
        Else
            MessageBox.Show("รหัสผู้บริจาคที่คุณป้อน ไม่มี !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearCustomerData()
            txtCustomerID.Focus()
        End If

    End Sub

    'เมื่อทำการกด ปุ่ม เลือกวัตถุมงคล จะให้แสดง FormDProduct ขึ้นมาแล้วรับค่าตามที่เลือกใน FormDProduct
    Private Sub btnSPro_Click(sender As Object, e As EventArgs) Handles btnSPro.Click
        FormDProduct.ShowDialog()
        Me.txtProductID.Text = CType(FormDProduct.id_product, String)
    End Sub

    'เมื่อข้อมูลใน txtProductID เปลี่ยน ให้ใส่ข้อมูลที่นำมาจาก DB
    Private Sub txtProductID_TextChanged(sender As Object, e As EventArgs) Handles txtProductID.TextChanged
        If txtProductID.Text.Trim() = "" Then Exit Sub

        Dim ps = From p In db.Products Join c In db.Categories On p.CategoryID Equals c.CategoryID Select p.ProductID, p.ProductName, p.UnitPrice, p.UnitsInStock, c.CategoryName
                 Where ProductID = CInt(txtProductID.Text)

        If ps.Count() > 0 Then
            txtProductID.Text = ps.FirstOrDefault().ProductID.ToString()
            lblProductName.Text = ps.FirstOrDefault().ProductName.Trim()
            lblSalePrice.Text = ps.FirstOrDefault().UnitPrice.ToString()
            txtStockLeft.Text = ps.FirstOrDefault().UnitsInStock.ToString()
            txtCate.Text = ps.FirstOrDefault().CategoryName.ToString()

            num_exit.Maximum = Convert.ToInt16(txtStockLeft.Text) 'ให้ค่าไม่เกินกับข้อมูลสินค้าในฐานข้อมูล 
            'ให้การเลือกจำนวนไม่เกิน ข้อมูลในตารางสินค้า โดยที่ได้แปลงค่าจาก String เป็น Decimal
            CalculateTotal()
            num_exit.Focus()

        End If
    End Sub
End Class