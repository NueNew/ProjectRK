Option Explicit On
Option Strict On
Imports System.Transactions
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine



Public Class Form_EXPE
    Dim db As New DataClassesDataContext

    Private Sub Form_EXPE_Load(sender As Object, e As EventArgs) Handles Me.Load


        lsvProductList.Columns.Add("รหัส", 100, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ประเภทค่าใช้จ่าย", 150, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ชื่อรายการค่าใช้จ่าย", 300, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("จำนวนเงิน", 104, HorizontalAlignment.Right)
        lsvProductList.View = View.Details
        lsvProductList.GridLines = True
        lsvProductList.FullRowSelect = True

        Dim es = From catE In db.CategoriesEs
                 Select catE.CategoryEID, catE.CategoryEName



        With cboCatE
            .BeginUpdate()
            .DisplayMember = "CategoryEName"
            .ValueMember = "CategoryEID"
            .DataSource = es.ToList
            .EndUpdate()
        End With

        txtOrderDID.ContextMenu = New ContextMenu()
        ClearData()
        lblNet.Text = "0"
    End Sub

    Private Sub ClearData()
        txtOrderDID.Text = ""

    End Sub
    Private Sub ClearProductData()

        txtPrice.Text = "0" 'ล้างค่าช่องจำนวนเงิน
    End Sub


    'Private Sub txtProductDID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductDID.KeyDown
    '    If txtProductDID.Text.Trim() = "" Then Exit Sub
    '    If e.KeyCode = Keys.Enter Then
    '        Dim catE = From ce In db.CategoriesEs Select ce.CategoryEID, ce.CategoryEName
    '                   Where CategoryEID = CInt(txtProductDID.Text)

    '        If catE.Count() > 0 Then
    '            txtProductDID.Text = catE.FirstOrDefault().CategoryEID.ToString
    '            lblProductDName.Text = catE.FirstOrDefault().CategoryEName.Trim
    '        Else
    '            MessageBox.Show("รหัสนี้ไม่มี", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    End If
    'End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click


        Dim i As Integer = 0
        Dim lvi As ListViewItem
        Dim anyData() As String
        anyData = New String() {
            cboCatE.SelectedValue.ToString,
            cboCatE.Text.ToString,
            txtDetail.Text,
            txtPrice.Text
        }
        lvi = New ListViewItem(anyData)
        lsvProductList.Items.Add(lvi)
        CalculateNet()
        ClearProductData()
        cmdSave.Enabled = True
        txtDetail.Focus()

        'Dim i As Integer = 0
        'Dim lvi As ListViewItem
        'Dim tmpCategoryE As Integer = 0
        'For i = 0 To lsvProductList.Items.Count - 1
        '    tmpCategoryE = CInt(lsvProductList.Items(i).SubItems(0).Text)
        '    If CInt(txtProductDID.Text.Trim()) = tmpCategoryE Then
        '        MessageBox.Show("สิ่งที่คุณเลือก ซ้ำกัน กรุณาเลือกใหม่ ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        ClearProductData()
        '        txtProductDID.Focus()
        '        txtProductDID.SelectAll()
        '    End If
        'Next

        'Dim anyData() As String
        'anyData = New String() {
        'txtProductDID.Text,
        'lblProductDName.Text,
        'txtDon.Text
        '}
        'lvi = New ListViewItem(anyData)
        'lsvProductList.Items.Add(lvi)
        'CalculateNet()
        'ClearProductData()
        'cmdSave.Enabled = True
        'txtProductDID.Focus()
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
        cboCatE.SelectedValue = 0
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

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If lsvProductList.Items.Count > 0 Then
            If MessageBox.Show("คุณต้องการบันทึกรายการ ค่าใช้จ่าย ใช่หรือไม่ ?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim expe As New Expense()
                expe.ExpensesDate = Date.Now 'เก็บข้อมูลเวลาปัจจุบัน

                Dim t As New TEST() 'ทำการประกาศตัวแปร T เป็นตาราง TEST
                t.DATE = Date.Now 'DATE ตัวนี้คือ Colum ในตารางครับ 

                Dim i As Integer 'เก็บข้อมูล เพื่อทำการนับลูป



                'ทำการ Loop เพื่อนับว่ามีครบไหม
                For i = 0 To lsvProductList.Items.Count - 1
                    t = New TEST()
                    expe.CategoryEID = CType(lsvProductList.Items(i).SubItems(0).Text, Integer?)
                    t.NAME = lsvProductList.Items(i).SubItems(1).Text
                    expe.ExpensesName = lsvProductList.Items(i).SubItems(2).Text
                    expe.ExpensesPrice = CType(lsvProductList.Items(i).SubItems(3).Text, Decimal?)
                    t.MONEY = CType(lsvProductList.Items(i).SubItems(3).Text, Decimal?) * -1
                    t.DATE = Date.Now
                    expe.CBID = CType(3, Integer?)
                    t.CBID = CType(3, Integer?)

                Next
                Using ts As New TransactionScope
                    db.Expenses.InsertOnSubmit(expe)
                    db.TESTs.InsertOnSubmit(t)
                    db.SubmitChanges()
                    ts.Complete()
                End Using
                lsvProductList.Clear()

                '            ClearProductData()
                '            lblNet.Text = "0"
                '            txtProductDID.Focus()

                ''ทำการส่งค่าจาก Transaction นี้ไปยัง Crystalreport
                Dim rpt As New ReportDocument
                Dim directory As String = My.Application.Info.DirectoryPath

                rpt.Load("C:\MYPROJECT\ProjectRK\Forms_Report_files\CR_EXPE.rpt")
                '            'rpt.SetParameterValue("ORD", Me.txtOrderDID.Text)

                '            'Form_Report_CR_DON.CrystalReportViewer1.ReportSource = rpt
                '            'Form_Report_CR_DON.CrystalReportViewer1.Refresh()
                '            'Form_Report_CR_DON.Show()
                '            'Form_Report_CR_DON.WindowState = FormWindowState.Maximized
                '            ''

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MF.Show()
    End Sub


End Class