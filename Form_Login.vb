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

            MessageBox.Show("Username Or Password Are Invalid")

        Else

            'MessageBox.Show("Login Successfully")

            Dim frm As New From_Main()

            Me.Hide()

            frm.Show()

        End If

    End Sub

End Class
