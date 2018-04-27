Imports CrystalDecisions.CrystalReports.Engine
Public Class Form1
    Dim dt As New DataClassesDataContext

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cat = From d In dt.Categories
                  Select d.CategoryName, d.CategoryID

        With ComboBox1
            .DisplayMember = "CategoryName"
            .ValueMember = "CategoryID"
            .DataSource = cat.ToList
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rpt As New ReportDocument
        Dim directory As String = My.Application.Info.DirectoryPath

        rpt.Load("C:\MYPROJECT\ProjectRK\Test\CrystalReport1.rpt")
        rpt.SetParameterValue("catname", Me.ComboBox1.Text)

        Form2.CrystalReportViewer1.ReportSource = rpt
        Form2.CrystalReportViewer1.Refresh()
        Form2.Show()
        Form2.WindowState = FormWindowState.Maximized
    End Sub
End Class