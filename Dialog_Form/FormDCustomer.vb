Public Class FormDCustomer

    Public id_customer As String 'ประกาศตัวแปร id_product เพื่อทำการ บอกว่าตัวแปรนี้สามารถใช้ส่งค่า Form อื่นๆได้

    'เมื่อทำการกดคลิ๊กเมาส์2ครั้ง ที่ข้อมูล จะให้ตัวแปร id_customer มีค่าเป็นข้อมูลในตารางคอลัมแรกหรือข้อมูล id นั้นเอง
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim selectRow = DataGridView1.Rows(e.RowIndex)
        id_customer = selectRow.Cells(0).Value.ToString
        Me.Close()
    End Sub

    'เมื่อทำการเปิดฟอร์มนี้ขึ้นมาใน DGV จะแสดงข้อมูล CustomerDataset
    Private Sub FormDCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CustomerDataset.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.CustomerDataset.Customers)
    End Sub

End Class