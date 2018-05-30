Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Public conStr As String = "Server = .\ SQLEXPRESS; Database = ProjectV2; Integrated Security = True"
    'หรือ "Server= .\SQLEXPRESS; Database = ProjectV2; Integrated Security = true" 
    ' "Server=(localDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\database\ProjectV2.mdf"
    Public connection As New SqlConnection(conStr)
    Public command As New SqlCommand("", connection)
    Public adapter As New SqlDataAdapter
    Public dataSt As DataSet
    Public bindingSrc As BindingSource
    Public reader As SqlDataReader
    Public sql As String

End Module
