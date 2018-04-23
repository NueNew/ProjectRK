<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class T_1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtIDproduct = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.Accept = New System.Windows.Forms.Button()
        Me.Clear = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(277, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสใบเสร็จ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "รหัสสินค้า"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(277, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ชื่อสินค้า"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(516, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "จำนวน"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(516, 414)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ราคา"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(391, 45)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 29)
        Me.txtID.TabIndex = 1
        '
        'txtIDproduct
        '
        Me.txtIDproduct.Location = New System.Drawing.Point(152, 138)
        Me.txtIDproduct.Name = "txtIDproduct"
        Me.txtIDproduct.Size = New System.Drawing.Size(100, 29)
        Me.txtIDproduct.TabIndex = 1
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(391, 143)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(100, 29)
        Me.txtname.TabIndex = 1
        '
        'txtamount
        '
        Me.txtamount.Location = New System.Drawing.Point(630, 143)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(100, 29)
        Me.txtamount.TabIndex = 1
        '
        'txtprice
        '
        Me.txtprice.Location = New System.Drawing.Point(630, 411)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(100, 29)
        Me.txtprice.TabIndex = 1
        '
        'Accept
        '
        Me.Accept.Location = New System.Drawing.Point(51, 414)
        Me.Accept.Name = "Accept"
        Me.Accept.Size = New System.Drawing.Size(180, 38)
        Me.Accept.TabIndex = 2
        Me.Accept.Text = "Accept"
        Me.Accept.UseVisualStyleBackColor = True
        '
        'Clear
        '
        Me.Clear.Location = New System.Drawing.Point(237, 414)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(180, 38)
        Me.Clear.TabIndex = 2
        Me.Clear.Text = "Clear"
        Me.Clear.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(42, 198)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(688, 192)
        Me.DataGridView1.TabIndex = 3
        '
        'T_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 468)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Clear)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.txtprice)
        Me.Controls.Add(Me.txtamount)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.txtIDproduct)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "T_1"
        Me.Text = "T_1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtIDproduct As TextBox
    Friend WithEvents txtname As TextBox
    Friend WithEvents txtamount As TextBox
    Friend WithEvents txtprice As TextBox
    Friend WithEvents Accept As Button
    Friend WithEvents Clear As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
