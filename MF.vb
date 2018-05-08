Public Class MF
    Private Sub ผบรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ผบรจาคToolStripMenuItem.Click
        Me.Hide()
        From_Customers.Show()
    End Sub

    Private Sub ประเภทบรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ประเภทบรจาคToolStripMenuItem.Click
        Me.Hide()
        Form_CategoryD.Show()
    End Sub

    Private Sub ประเภทวตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ประเภทวตถมงคลToolStripMenuItem.Click
        Me.Hide()
        Form_Category.Show()
    End Sub

    Private Sub วตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles วตถมงคลToolStripMenuItem.Click
        Me.Hide()
        Form_Product.Show()
    End Sub

    Private Sub ประเภทคาใชจายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ประเภทคาใชจายToolStripMenuItem.Click
        Me.Hide()
        Form_CategoryE.Show()
    End Sub

    Private Sub พนกงานวดมคนายกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles พนกงานวดมคนายกToolStripMenuItem.Click
        Me.Hide()
        Form_Employee.Show()
    End Sub

    Private Sub จำหนายวตถมงคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จำหนายวตถมงคลToolStripMenuItem.Click
        Me.Hide()
        Form_POS.Show()
    End Sub

    Private Sub บรจาคToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บรจาคToolStripMenuItem.Click
        Me.Hide()
        Form_Donate.Show()
    End Sub

    Private Sub รายจายToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายจายToolStripMenuItem.Click
        Me.Hide()
        Form_EXPE.Show()
    End Sub

    Private Sub ออกจากระบบToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ออกจากระบบToolStripMenuItem.Click
        Me.Hide()
        Form_Login.Show()
    End Sub
End Class