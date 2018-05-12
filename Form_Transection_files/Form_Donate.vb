Option Explicit On
Option Strict On
Imports System.Transactions

Imports System.Data
Imports System.Data.SqlClient

Imports CrystalDecisions.CrystalReports.Engine


Public Class Form_Donate
    Dim db As New DataClassesDataContext

    Private Sub reloadDon()
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        '
        command.CommandText = "SELECT * from OrdersD where OrderDID = (select max(OrderDID) from OrdersD)"
        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet 'ให้เอาคำสั่ง sql ที่อยุ่ในตัวแปร sql book มาเกบไว้ในตัวแปร da แบบ text
        adapter.Fill(dataSt, "OrdersD") 'แล้วเกบผลลัพท์ไว้ในบัพเฟิลผ่านตัวแปร ds
        Dim item As Integer
        item = CInt(dataSt.Tables("OrdersD").Rows(0).Item("OrderDID").ToString())
        txtOrderDID.Text = Format(item + 1)
        '
    End Sub
    Private Sub Form_Donate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show(Form_Login.emp_id)

        reloadDon()

        lsvProductList.Columns.Add("รหัส", 0, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ประเภทบริจาค", 200, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("รายละเอียด", 250, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("จำนวนเงิน", 100, HorizontalAlignment.Right)
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

        cboEmployee.SelectedValue = Form_Login.emp_id

        'ทำการเอาค่าจาก table CategoriesD มาแปะใน combobox เลือกประเภทบริจาค
        Dim es1 = From em1 In db.CategoriesDs
                  Select em1.CategoryDID, em1.CategoryDName
        With cboCatD
            .BeginUpdate()
            .DisplayMember = "CategoryDName"
            .ValueMember = "CategoryDID"
            .DataSource = es1.ToList
            .EndUpdate()
        End With


        ' txtProductDID.ContextMenu = New ContextMenu()
        ClearProductData()
        lblNet.Text = "0"
    End Sub

    Private Sub ClearProductData()

        txtDon.Text = "0" 'ล้างค่าช่องจำนวนเงิน
    End Sub

    Private Sub txtCustomerID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCustomerID.KeyDown
        If txtCustomerID.Text.Trim() = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            Dim cs = From c In db.Customers Select c.CustomerID, c.CustomerName
                     Where CustomerID = CInt(txtCustomerID.Text)

            If cs.Count() > 0 Then
                txtCustomerID.Text = cs.FirstOrDefault.CustomerID.ToString 'ลองใส่เป็น tostring
                lblContactName.Text = cs.FirstOrDefault().CustomerName.Trim()

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


    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        'If (txtProductDID.Text.Trim() = "") Or (lblProductDName.Text.Trim() = "") Then
        '    txtProductDID.Focus()
        '    Exit Sub
        'End If

        Dim i As Integer = 0
        Dim lvi As ListViewItem
        Dim tmpProductDID As Integer = 0
        'For i = 0 To lsvProductList.Items.Count - 1
        '    tmpProductDID = CInt(lsvProductList.Items(i).SubItems(0).Text)
        '    If CInt(txtProductDID.Text.Trim()) = tmpProductDID Then
        '        MessageBox.Show("คุณเลือกสินค้าซ้ำกัน กรุณาเลือกใหม่ !!!", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        ClearProductData()
        '        txtProductDID.Focus()
        '        txtProductDID.SelectAll()
        '        Exit Sub
        '    End If
        'Next

        Dim anyData() As String
        anyData = New String() {
            cboCatD.SelectedValue.ToString,
            cboCatD.Text.ToString,
            txtDetail.Text,
            txtDon.Text
        }
        lvi = New ListViewItem(anyData)
        lsvProductList.Items.Add(lvi)
        CalculateNet()
        ClearProductData()
        cmdSave.Enabled = True
        txtDetail.Focus()
    End Sub

    Private Sub lsvProductList_DoubleClick(sender As Object, e As EventArgs) Handles lsvProductList.DoubleClick
        Dim i As Integer = 0
        For i = 0 To lsvProductList.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = lsvProductList.SelectedItems(i)
            lsvProductList.Items.Remove(lvi)
        Next
        CalculateNet()

    End Sub

    Private Sub CalculateNet()
        Dim i As Integer = 0
        Dim tmpNetTotal As Double = 0
        For i = 0 To lsvProductList.Items.Count - 1
            tmpNetTotal += CDbl(lsvProductList.Items(i).SubItems(3).Text)
        Next
        lblNet.Text = tmpNetTotal.ToString("#,##0.00")
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        lsvProductList.Items.Clear()
        lblNet.Text = "0"
        cboCatD.SelectedValue = 0
        txtDetail.Focus()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtCustomerID.Text.Trim() = "" Then
            MessageBox.Show("กรุณาป้อนรหัสผู้บริจาค !!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCustomerID.Focus()
            Exit Sub
        End If

        If lsvProductList.Items.Count > 0 Then
            If MessageBox.Show("คุณต้องการบันทึกรายการสั่งซื้อสินค้า ใช่หรือไม่ ?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim o As New OrdersD()
                o.CustomerID = CType(txtCustomerID.Text, Integer?) 'ลองแปลงค่าเป็น Integer
                o.EmployeeID = DirectCast(cboEmployee.SelectedValue, Integer?)
                o.OrderDDate = Date.Now

                Dim i As Integer
                Dim od As OrdersDetailsD

                For i = 0 To lsvProductList.Items.Count - 1
                    od = New OrdersDetailsD()
                    od.CategoryDID = CInt(lsvProductList.Items(i).SubItems(0).Text)
                    od.Donation = CType(lsvProductList.Items(i).SubItems(3).Text, Decimal?) 'จำนวนเงินที่บริจาค 0 1 2
                    o.CBID = CType(3, Integer?)
                    o.OrdersDetailsDs.Add(od) 'ทำการใส่ข้อมูลลงในตาราง OrdersDeatailsD
                Next

                Using ts As New TransactionScope()
                    db.OrdersDs.InsertOnSubmit(o)
                    db.SubmitChanges()
                    ts.Complete()
                End Using
                MessageBox.Show("บันทึกรายการสั่งซื้อสินค้า เรียบร้อยแล้ว !!!", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)


                'เอาข้อมูลเข้า TEST
                For i = 0 To lsvProductList.Items.Count - 1
                    sql = "INSERT INTO TEST(DATE,NAME,MONEY,CBID) VALUES(@D,@N,@M,@C)"
                    command.CommandText = sql
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("D", DateTime.Now.Date)
                    command.Parameters.AddWithValue("N", lsvProductList.Items(i).SubItems(1).Text)
                    command.Parameters.AddWithValue("M", lsvProductList.Items(i).SubItems(3).Text)
                    command.Parameters.AddWithValue("C", 1)
                    command.ExecuteNonQuery()
                Next

                lsvProductList.Clear()
                ClearCustomerData()
                ClearProductData()
                lblNet.Text = "0"
                txtCustomerID.Focus()

                'ทำการส่งค่าจาก Transaction นี้ไปยัง Crystalreport
                Dim rpt As New ReportDocument
                Dim directory As String = My.Application.Info.DirectoryPath

                rpt.Load("C:\MYPROJECT\ProjectRK\Forms_Report_files\R_DON.rpt")
                rpt.SetParameterValue("ORD", Me.txtOrderDID.Text)

                Form_Report_CR_DON.CrystalReportViewer1.ReportSource = rpt
                Form_Report_CR_DON.CrystalReportViewer1.Refresh()
                Form_Report_CR_DON.Show()
                Form_Report_CR_DON.WindowState = FormWindowState.Maximized
                '
                reloadDon()
            End If
        End If
    End Sub

    Private Sub txtProductID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDon.KeyPress
        If e.KeyChar < "0" Or e.KeyChar > "9" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar < "0" Or e.KeyChar > "9" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MF.Show()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class