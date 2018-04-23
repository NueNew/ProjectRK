Public Class Form_Expenses
    Private Sub ExpensesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ExpensesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProjectV2DataSet1)

    End Sub

    Private Sub Form_Expenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProjectV2DataSet1.Expenses' table. You can move, or remove it, as needed.
        Me.ExpensesTableAdapter.Fill(Me.ProjectV2DataSet1.Expenses)
        'TODO: This line of code loads data into the 'ProjectV2DataSet1.Expenses' table. You can move, or remove it, as needed.
        Me.ExpensesTableAdapter.Fill(Me.ProjectV2DataSet1.Expenses)

    End Sub

    Private Sub ExpensesBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs) Handles ExpensesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ExpensesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProjectV2DataSet1)

    End Sub
End Class