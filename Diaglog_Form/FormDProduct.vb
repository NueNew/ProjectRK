Public Class FormDProduct

    Public id_product As String 'ประกาศตัวแปร id_product เพื่อทำการ บอกว่าตัวแปรนี้สามารถใช้ส่งค่า Form อื่นๆได้

    Private Sub FormDProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProductsDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.ProductsDataSet.Products)

    End Sub

    'เมื่อทำการกดคลิ๊กเมาส์2ครั้ง ที่ข้อมูล จะให้ตัวแปร id_product มีค่าเป็นข้อมูลในตารางคอลัมแรกหรือข้อมูล id นั้นเอง
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim selectRow = DataGridView1.Rows(e.RowIndex)
        id_product = selectRow.Cells(0).Value.ToString
        Me.Close()
    End Sub
End Class