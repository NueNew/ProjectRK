Option Explicit On
Option Strict On
Imports System.Transactions
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine



Public Class Form_EXPE
    Dim db As New DataClassesDataContext




    Private Sub reloadEX()
        ''<<<ในส่วนนี้ นิว ประกาศไว้หาในส่วนของ ORDERID เพราะนิวใช้ LinQ แต่ลืม Binding ID เฉยๆ เริ่มแถนะครับ 
        ''จะทำแบบว่าหาไอดีที่มากที่สุด แล้ว +1 เช่น ไอดีล่าสุดเป็น 1 ช่อง textboxID จะเป็น 2
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        command.CommandText = "SELECT * from OrdersE where OrderEID = (select max(OrderEID) from OrdersE)"
        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet 'ให้เอาคำสั่ง sql ที่อยุ่ในตัวแปร sql book มาเกบไว้ในตัวแปร da แบบ text
        adapter.Fill(dataSt, "OrderE") 'แล้วเกบผลลัพท์ไว้ในบัพเฟิลผ่านตัวแปร ds
        If dataSt.Tables("OrderE").Rows.Count <> 0 Then
            Dim item As Integer
            item = CInt(dataSt.Tables("OrderE").Rows(0).Item("OrderEID").ToString())
            txtExpensesID.Text = Format(item + 1)
        Else
            txtExpensesID.Text = "1"
        End If

        ''ปิด>>>
        ClearData()
        ClearProductData()
    End Sub

    Private Sub Form_EXPE_Load(sender As Object, e As EventArgs) Handles Me.Load

        reloadEX()
        lsvProductList.Columns.Add("รหัส", 0, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("ประเภทค่าใช้จ่าย", 150, HorizontalAlignment.Left)
        lsvProductList.Columns.Add("รายละเอียดค่าใช้จ่าย", 300, HorizontalAlignment.Left)
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

        cboCatE.ContextMenu = New ContextMenu()
        ClearData()
        lblNet.Text = "0"
    End Sub

    Private Sub ClearData()
        cboCatE.SelectedValue = 0
        txtDetail.Text = ""
        txtPrice.Text = ""
    End Sub
    Private Sub ClearProductData()
        cboCatE.SelectedValue = 0
        txtPrice.Text = "0" 'ล้างค่าช่องจำนวนเงิน
    End Sub


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
        txtDetail.Text = ""
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

                Dim o As New OrdersE()
                'o.EmployeeID = DirectCast()
                o.OrderEDate = DateTime.Now
                o.EmployeeID = CType(Form_Login.emp_id, Integer?)

                Dim t As New TEST() 'ทำการประกาศตัวแปร T เป็นตาราง TEST
                Dim od As OrdersDetailsE

                Dim i As Integer 'เก็บข้อมูล เพื่อทำการนับลูป

                'ทำการ Loop เพื่อนับว่ามีครบไหม
                For i = 0 To lsvProductList.Items.Count - 1
                    od = New OrdersDetailsE()
                    od.CategoryEID = CInt(CType(lsvProductList.Items(i).SubItems(0).Text, Integer?))
                    od.Detail = lsvProductList.Items(i).SubItems(2).Text
                    od.Money = CType(lsvProductList.Items(i).SubItems(3).Text, Decimal?)
                    o.CBID = 3
                    o.OrdersDetailsEs.Add(od)

                Next

                'o.OrdersDetailsEs.Add(od) คือการที่บอกให้ส่งข้อมูลไป 2 ตาราง


                ''เอาข้อมูลเข้า BalanceSheet
                For i = 0 To lsvProductList.Items.Count - 1
                    sql = "INSERT INTO TEST(DATE,NAME,MONEY,CBID) VALUES(@DATT,@N,@M,@C)"
                    command.CommandText = sql
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("DATT", DateTime.Now.Date)
                    command.Parameters.AddWithValue("N", lsvProductList.Items(i).SubItems(1).Text)
                    command.Parameters.AddWithValue("M", CInt(lsvProductList.Items(i).SubItems(3).Text) * -1)
                    command.Parameters.AddWithValue("C", 3)
                    command.ExecuteNonQuery()
                Next
                Using ts As New TransactionScope
                    db.OrdersEs.InsertOnSubmit(o)
                    'db.TESTs.InsertOnSubmit(t)
                    db.SubmitChanges()
                    ts.Complete()
                End Using
                lsvProductList.Clear()

                ClearProductData()
                ClearData()
                lblNet.Text = "0"
                reloadEX()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MF.Show()
    End Sub

    Private Sub cboCatE_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCatE.SelectedValueChanged

        Dim i As Integer = 0
        Dim tmpProductID As Integer = 0
        For i = 0 To lsvProductList.Items.Count - 1
            tmpProductID = CInt(lsvProductList.Items(i).SubItems(0).Text)
            If CInt(cboCatE.SelectedValue) = tmpProductID Then
                MessageBox.Show("คุณเลือกรายการซ้ำกัน กรุณาเลือกใหม่ ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearProductData()
            End If
        Next
    End Sub


End Class