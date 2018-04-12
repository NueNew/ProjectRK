Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Public conStr As String =
        "Server= RK570815\SQLEXPRESS; Database = TestDB; Integrated Security = true" 'your sql server me is RK570815\SQLEXPRESS and my sql server dont use sa account.
    Public connection As New SqlConnection(conStr)
    Public command As New SqlCommand("", connection)
    Public adapter As New SqlDataAdapter
    Public dataset As DataSet
    Public bindingSrc As BindingSource
    Public reader As SqlDataReader
    Public sql As String
End Module
