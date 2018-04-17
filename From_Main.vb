Public Class From_Main
    Private Sub ออกจากระบบToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ออกจากระบบToolStripMenuItem.Click


        If MessageBox.Show("คุณต้องการบันทึกรายการสั่งซื้อสินค้า ใช่หรือไม่ ?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Information) =
            DialogResult.Yes Then

            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If


            Dim frm As New Form_Login()
            Me.Close()
            frm.Show()
        End If
    End Sub

    Private Sub ผบรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ผบรจาคToolStripMenuItem.Click
        Dim frm As New From_Customers()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub เรองบรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เรองบรจาคToolStripMenuItem.Click
        Dim frm As New Form_ProductD()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub ประเภทบรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ประเภทบรจาคToolStripMenuItem.Click
        Dim frm As New Form_CategoryD()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub วตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles วตถมงคลToolStripMenuItem.Click
        Dim frm As New Form_Product()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub ประเภทวตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ประเภทวตถมงคลToolStripMenuItem.Click
        Dim frm As New Form_Category
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub พนกงานวดมคนายกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles พนกงานวดมคนายกToolStripMenuItem.Click
        Dim frm As New Form_Employee
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub บรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บรจาคToolStripMenuItem.Click
        Dim frm As New Form_Donate()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub จำหนายวตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จำหนายวตถมงคลToolStripMenuItem.Click
        Dim frm As New Form_POS()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub ใบอนโมทนาบญToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ใบอนโมทนาบญToolStripMenuItem.Click
        Dim frm As New Form_Report_DONATE()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub ใบเสรจวตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ใบเสรจวตถมงคลToolStripMenuItem.Click
        Dim frm As New Form_Report_POS()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub From_Main_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim frm As New Form_Login()
        frm.Show()
    End Sub
End Class