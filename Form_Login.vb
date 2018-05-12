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
        '


        Dim command As New SqlCommand("select * from Employees where Username = @username and Password = @password", connection)

        command.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBoxUsername.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBoxPassword.Text


        Dim ds As DataSet
        adapter = New SqlDataAdapter(command)
        dataSt = New DataSet()
        adapter.Fill(dataSt, "Employees")
        If dataSt.Tables("Employees").Rows.Count() <= 0 Then

            MessageBox.Show("Username Or Password Are Invalid")

        Else

            'MessageBox.Show("Login Successfully")
            emp_id = dataSt.Tables("Employees").Rows(0).Item("EmployeeID").ToString()
            emp_name = dataSt.Tables("Employees").Rows(0).Item("EmployeeName").ToString
            MessageBox.Show(Me.emp_id)

            Dim frm As New MF()
            Me.Hide()
            frm.Show()

        End If

        '

        'sql = "select * from Employees where Username = @username and Password = @password"
        'command.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBoxUsername.Text
        'command.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBoxPassword.Text

        'Dim da As SqlDataAdapter
        'Dim ds As DataSet
        'da = New SqlDataAdapter(sql, connection)
        'ds = New DataSet
        'da.Fill(ds, "Employees")

        'If ds.Tables("Employees").Rows.Count < 0 Then
        '    MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง", "ข้อความจากระบบ")
        'Else
        '    emp_id = ds.Tables("Employees").Rows(0).Item("EmployeeID").ToString()
        '    emp_name = ds.Tables("Employees").Rows(0).Item("EmployeeName").ToString
        '    emp_phone = ds.Tables("Employess").Rows(0).Item("Phone").ToString
        '    Me.Hide()
        '    MF.Show()
        'End If
        'TextBoxUsername.Text = ""
        'TextBoxPassword.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()

    End Sub


End Class
