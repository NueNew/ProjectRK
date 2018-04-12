<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class From_Main
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ทะเบยนToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายการToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายงานToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.เกยวกบToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ออกจากระบบToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ทะเบยนToolStripMenuItem, Me.รายการToolStripMenuItem, Me.รายงานToolStripMenuItem, Me.เกยวกบToolStripMenuItem, Me.ออกจากระบบToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 33)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ทะเบยนToolStripMenuItem
        '
        Me.ทะเบยนToolStripMenuItem.Name = "ทะเบยนToolStripMenuItem"
        Me.ทะเบยนToolStripMenuItem.Size = New System.Drawing.Size(79, 29)
        Me.ทะเบยนToolStripMenuItem.Text = "ทะเบียน"
        '
        'รายการToolStripMenuItem
        '
        Me.รายการToolStripMenuItem.Name = "รายการToolStripMenuItem"
        Me.รายการToolStripMenuItem.Size = New System.Drawing.Size(79, 29)
        Me.รายการToolStripMenuItem.Text = "รายการ"
        '
        'รายงานToolStripMenuItem
        '
        Me.รายงานToolStripMenuItem.Name = "รายงานToolStripMenuItem"
        Me.รายงานToolStripMenuItem.Size = New System.Drawing.Size(78, 29)
        Me.รายงานToolStripMenuItem.Text = "รายงาน"
        '
        'เกยวกบToolStripMenuItem
        '
        Me.เกยวกบToolStripMenuItem.Name = "เกยวกบToolStripMenuItem"
        Me.เกยวกบToolStripMenuItem.Size = New System.Drawing.Size(81, 29)
        Me.เกยวกบToolStripMenuItem.Text = "เกี่ยวกับ"
        '
        'ออกจากระบบToolStripMenuItem
        '
        Me.ออกจากระบบToolStripMenuItem.Name = "ออกจากระบบToolStripMenuItem"
        Me.ออกจากระบบToolStripMenuItem.Size = New System.Drawing.Size(122, 29)
        Me.ออกจากระบบToolStripMenuItem.Text = "ออกจากระบบ"
        '
        'From_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "From_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "From_Main"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ทะเบยนToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents รายการToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents รายงานToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents เกยวกบToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ออกจากระบบToolStripMenuItem As ToolStripMenuItem
End Class
