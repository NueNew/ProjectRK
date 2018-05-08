Public Class From_Main
    Private Sub ออกจากระบบToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ออกจากระบบToolStripMenuItem.Click


        If MessageBox.Show("คุณต้องการออกจากระบบ ใช่หรือไม่ ?", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Information) =
            DialogResult.Yes Then


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

    Private Sub ประเภทบรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ประเภทบรจาคToolStripMenuItem.Click
        Dim frm As New Form_CategoryD()
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
        'Dim frm As New Form()
        'Me.Hide()
        'frm.Show()
    End Sub

    Private Sub ใบเสรจวตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ใบเสรจวตถมงคลToolStripMenuItem.Click
        'Dim frm As New Form_Report_POS()
        'Me.Hide()
        'frm.Show()
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim frm As New Form_CategoryE()
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub รายจายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายจายToolStripMenuItem.Click
        Dim frm As New Form_EXPE
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub From_Main_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim frm As New Form_Category
        Me.Hide()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim frm As New Form_Product
        frm.Show()
    End Sub
End Class