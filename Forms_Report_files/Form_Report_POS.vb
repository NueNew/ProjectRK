﻿Imports CrystalDecisions.CrystalReports.Engine
'เพิ่มการใช้งาน CrystalReport
Imports System.Data.SqlClient 'บอกว่าใช้งาน SQL server
Public Class Form_Report_POS

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Dim rpt As New ReportDocument
        Dim directory As String = My.Application.Info.DirectoryPath
        rpt.Load("C:\MYPROJECT\ProjectRK\Forms_Report_files\CR_POS.rpt") 'ที่อยู่ของไฟล์ Report
        rpt.SetParameterValue("ORDERID", Me.txtSearch.Text) 'ให้เอาค่าจาก txtSearch มา 
        'ORDERID ให้ไปใส่ใน Parametter ORDERID ที่เราสร้างไว้ใน Cystalreport
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()

    End Sub

    Private Sub Form_Report_POS_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'นี่คือคอยรับค่าจาก Form_POS หรือหน้าจอซื้อขายนั้นแหละ

        txtSearch.Text = Form_POS.Service_Bill
        Dim rpt As New ReportDocument
        Dim directory As String = My.Application.Info.DirectoryPath
        rpt.Load("C:\MYPROJECT\ProjectRK\Forms_Report_files\CR_POS.rpt") 'ที่อยู่ของไฟล์ Report
        rpt.SetParameterValue("ORDERID", Me.txtSearch.Text) 'ให้เอาค่าจาก txtSearch มา 
        'ORDERID ให้ไปใส่ใน Parametter ORDERID ที่เราสร้างไว้ใน Cystalreport
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Form_Report_POS_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim frm As New From_Main()
        frm.Show()
    End Sub
End Class