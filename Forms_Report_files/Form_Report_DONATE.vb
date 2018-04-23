Imports CrystalDecisions.CrystalReports.Engine
'เพิ่มการใช้งาน CrystalReport
Imports System.Data.SqlClient 'บอกว่าใช้งาน SQL server

Public Class Form_Report_DONATE
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Dim rpt As New ReportDocument
        Dim directory As String = My.Application.Info.DirectoryPath
        rpt.Load("C:\MYPROJECT\ProjectRK\Forms_Report_files\CR_POS.rpt") 'ที่อยู่ของไฟล์ Report
        rpt.SetParameterValue("ORD", Me.txtSearch1.Text) 'ให้เอาค่าจาก txtSearch มา 
        'ORDERID ให้ไปใส่ใน Parametter ORDERID ที่เราสร้างไว้ใน Cystalreport
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Form_Report_DONATE_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtSearch1.Text = Form_Donate.Service_Bill1
        Dim rpt As New ReportDocument
        Dim directory As String = My.Application.Info.DirectoryPath
        rpt.Load("C:\MYPROJECT\ProjectRK\Forms_Report_files\CR_DON.rpt") 'ที่อยู่ของไฟล์ Report
        rpt.SetParameterValue("ORD", Me.txtSearch1.Text) 'ให้เอาค่าจาก txtSearch มา 
        'ORDERID ให้ไปใส่ใน Parametter ORDERID ที่เราสร้างไว้ใน Cystalreport
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Form_Report_DONATE_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub
End Class