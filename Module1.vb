Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Public conStr As String =
        "Server= .\SQLEXPRESS; Database = ProjectV2; Integrated Security = true" 'your sql server me is RK570815\SQLEXPRESS and my sql server dont use sa account.
    'เปลี่ยนจาก RK570815\SQLEXPRESS เป็น server ของคุณ
    Public connection As New SqlConnection(conStr)
    Public command As New SqlCommand("", connection)
    Public adapter As New SqlDataAdapter
    Public dataSt As DataSet
    Public bindingSrc As BindingSource
    Public reader As SqlDataReader
    Public sql As String

End Module
