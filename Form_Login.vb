Imports System.Data.SqlClient


Public Class Form_Login

    Public emp_id As String
    Public emp_name As String
    Public emp_phone As String

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("select * from Employees where Username = @username and Password = @password", connection)
        command.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBoxUsername.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBoxPassword.Text

        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet()
        adapter.Fill(dataSt, "Employees")
        If dataSt.Tables("Employees").Rows.Count() <= 0 Then
            MessageBox.Show("กรุณาใส่ข้อมูลให้ถูกต้อง")
        Else

            emp_id = dataSt.Tables("Employees").Rows(0).Item("EmployeeID").ToString() 'เก็บค่า EmployeeID
            emp_name = dataSt.Tables("Employees").Rows(0).Item("EmployeeName").ToString
            TextBoxUsername.Text = ""
            TextBoxPassword.Text = ""

            Dim frm As New MF()
            Me.Hide()
            frm.Show()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class
