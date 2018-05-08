Imports System.Data.SqlClient


Public Class Form_Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As New SqlConnection("Server= RK570815\SQLEXPRESS; Database = ProjectV2; Integrated Security = true")

        Dim command As New SqlCommand("select * from Employees where Username = @username and Password = @password", connection)

        command.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBoxUsername.Text 'บอกให้ 
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBoxPassword.Text

        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            MessageBox.Show("กรุณาใส่ข้อมูลผู้ใช้และรหัสผ่านให้ถูกต้อง")

        Else

            'MessageBox.Show("Login Successfully")

            Dim frm As New MF()



            frm.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class
