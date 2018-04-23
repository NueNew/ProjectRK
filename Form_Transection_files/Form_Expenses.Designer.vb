<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Expenses
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Expenses))
        Dim ExpensesIDLabel As System.Windows.Forms.Label
        Dim ExpensesNameLabel As System.Windows.Forms.Label
        Dim ExpensesPriceLabel As System.Windows.Forms.Label
        Dim ExpensesDateLabel As System.Windows.Forms.Label
        Me.ProjectV2DataSet1 = New ProjectRK.ProjectV2DataSet1()
        Me.ExpensesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExpensesTableAdapter = New ProjectRK.ProjectV2DataSet1TableAdapters.ExpensesTableAdapter()
        Me.TableAdapterManager = New ProjectRK.ProjectV2DataSet1TableAdapters.TableAdapterManager()
        Me.ExpensesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.ExpensesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ExpensesIDTextBox = New System.Windows.Forms.TextBox()
        Me.ExpensesNameTextBox = New System.Windows.Forms.TextBox()
        Me.ExpensesPriceTextBox = New System.Windows.Forms.TextBox()
        Me.ExpensesDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        ExpensesIDLabel = New System.Windows.Forms.Label()
        ExpensesNameLabel = New System.Windows.Forms.Label()
        ExpensesPriceLabel = New System.Windows.Forms.Label()
        ExpensesDateLabel = New System.Windows.Forms.Label()
        CType(Me.ProjectV2DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpensesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpensesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpensesBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProjectV2DataSet1
        '
        Me.ProjectV2DataSet1.DataSetName = "ProjectV2DataSet1"
        Me.ProjectV2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ExpensesBindingSource
        '
        Me.ExpensesBindingSource.DataMember = "Expenses"
        Me.ExpensesBindingSource.DataSource = Me.ProjectV2DataSet1
        '
        'ExpensesTableAdapter
        '
        Me.ExpensesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CategoriesDTableAdapter = Nothing
        Me.TableAdapterManager.CategoriesTableAdapter = Nothing
        Me.TableAdapterManager.CustomersTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesTableAdapter = Nothing
        Me.TableAdapterManager.ExpensesTableAdapter = Me.ExpensesTableAdapter
        Me.TableAdapterManager.OrdersDetailsDTableAdapter = Nothing
        Me.TableAdapterManager.OrdersDetailsTableAdapter = Nothing
        Me.TableAdapterManager.OrdersDTableAdapter = Nothing
        Me.TableAdapterManager.OrdersTableAdapter = Nothing
        Me.TableAdapterManager.ProductsDTableAdapter = Nothing
        Me.TableAdapterManager.ProductsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ProjectRK.ProjectV2DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ExpensesBindingNavigator
        '
        Me.ExpensesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ExpensesBindingNavigator.BindingSource = Me.ExpensesBindingSource
        Me.ExpensesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ExpensesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ExpensesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ExpensesBindingNavigatorSaveItem})
        Me.ExpensesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ExpensesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ExpensesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ExpensesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ExpensesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ExpensesBindingNavigator.Name = "ExpensesBindingNavigator"
        Me.ExpensesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ExpensesBindingNavigator.Size = New System.Drawing.Size(784, 25)
        Me.ExpensesBindingNavigator.TabIndex = 0
        Me.ExpensesBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 15)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'ExpensesBindingNavigatorSaveItem
        '
        Me.ExpensesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExpensesBindingNavigatorSaveItem.Image = CType(resources.GetObject("ExpensesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ExpensesBindingNavigatorSaveItem.Name = "ExpensesBindingNavigatorSaveItem"
        Me.ExpensesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.ExpensesBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ExpensesIDLabel
        '
        ExpensesIDLabel.AutoSize = True
        ExpensesIDLabel.Location = New System.Drawing.Point(218, 217)
        ExpensesIDLabel.Name = "ExpensesIDLabel"
        ExpensesIDLabel.Size = New System.Drawing.Size(70, 13)
        ExpensesIDLabel.TabIndex = 1
        ExpensesIDLabel.Text = "Expenses ID:"
        '
        'ExpensesIDTextBox
        '
        Me.ExpensesIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "ExpensesID", True))
        Me.ExpensesIDTextBox.Location = New System.Drawing.Point(311, 214)
        Me.ExpensesIDTextBox.Name = "ExpensesIDTextBox"
        Me.ExpensesIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ExpensesIDTextBox.TabIndex = 2
        '
        'ExpensesNameLabel
        '
        ExpensesNameLabel.AutoSize = True
        ExpensesNameLabel.Location = New System.Drawing.Point(218, 243)
        ExpensesNameLabel.Name = "ExpensesNameLabel"
        ExpensesNameLabel.Size = New System.Drawing.Size(87, 13)
        ExpensesNameLabel.TabIndex = 3
        ExpensesNameLabel.Text = "Expenses Name:"
        '
        'ExpensesNameTextBox
        '
        Me.ExpensesNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "ExpensesName", True))
        Me.ExpensesNameTextBox.Location = New System.Drawing.Point(311, 240)
        Me.ExpensesNameTextBox.Name = "ExpensesNameTextBox"
        Me.ExpensesNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ExpensesNameTextBox.TabIndex = 4
        '
        'ExpensesPriceLabel
        '
        ExpensesPriceLabel.AutoSize = True
        ExpensesPriceLabel.Location = New System.Drawing.Point(218, 269)
        ExpensesPriceLabel.Name = "ExpensesPriceLabel"
        ExpensesPriceLabel.Size = New System.Drawing.Size(83, 13)
        ExpensesPriceLabel.TabIndex = 5
        ExpensesPriceLabel.Text = "Expenses Price:"
        '
        'ExpensesPriceTextBox
        '
        Me.ExpensesPriceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ExpensesBindingSource, "ExpensesPrice", True))
        Me.ExpensesPriceTextBox.Location = New System.Drawing.Point(311, 266)
        Me.ExpensesPriceTextBox.Name = "ExpensesPriceTextBox"
        Me.ExpensesPriceTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ExpensesPriceTextBox.TabIndex = 6
        '
        'ExpensesDateLabel
        '
        ExpensesDateLabel.AutoSize = True
        ExpensesDateLabel.Location = New System.Drawing.Point(218, 296)
        ExpensesDateLabel.Name = "ExpensesDateLabel"
        ExpensesDateLabel.Size = New System.Drawing.Size(82, 13)
        ExpensesDateLabel.TabIndex = 7
        ExpensesDateLabel.Text = "Expenses Date:"
        '
        'ExpensesDateDateTimePicker
        '
        Me.ExpensesDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ExpensesBindingSource, "ExpensesDate", True))
        Me.ExpensesDateDateTimePicker.Location = New System.Drawing.Point(311, 292)
        Me.ExpensesDateDateTimePicker.Name = "ExpensesDateDateTimePicker"
        Me.ExpensesDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ExpensesDateDateTimePicker.TabIndex = 8
        '
        'Form_Expenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(ExpensesIDLabel)
        Me.Controls.Add(Me.ExpensesIDTextBox)
        Me.Controls.Add(ExpensesNameLabel)
        Me.Controls.Add(Me.ExpensesNameTextBox)
        Me.Controls.Add(ExpensesPriceLabel)
        Me.Controls.Add(Me.ExpensesPriceTextBox)
        Me.Controls.Add(ExpensesDateLabel)
        Me.Controls.Add(Me.ExpensesDateDateTimePicker)
        Me.Controls.Add(Me.ExpensesBindingNavigator)
        Me.Name = "Form_Expenses"
        Me.Text = "Form_Expenses"
        CType(Me.ProjectV2DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpensesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpensesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpensesBindingNavigator.ResumeLayout(False)
        Me.ExpensesBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProjectV2DataSet1 As ProjectV2DataSet1
    Friend WithEvents ExpensesBindingSource As BindingSource
    Friend WithEvents ExpensesTableAdapter As ProjectV2DataSet1TableAdapters.ExpensesTableAdapter
    Friend WithEvents TableAdapterManager As ProjectV2DataSet1TableAdapters.TableAdapterManager
    Friend WithEvents ExpensesBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents ExpensesBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents ExpensesIDTextBox As TextBox
    Friend WithEvents ExpensesNameTextBox As TextBox
    Friend WithEvents ExpensesPriceTextBox As TextBox
    Friend WithEvents ExpensesDateDateTimePicker As DateTimePicker
End Class
