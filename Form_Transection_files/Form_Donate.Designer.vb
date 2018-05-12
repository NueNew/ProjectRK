<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Donate
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCatD = New System.Windows.Forms.ComboBox()
        Me.txtDetail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lsvProductList = New System.Windows.Forms.ListView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDon = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblContactName = New System.Windows.Forms.Label()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEmployee = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.lblNet = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.txtOrderDID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.cboCatD)
        Me.GroupBox2.Controls.Add(Me.txtDetail)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lsvProductList)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtDon)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(111, 329)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(672, 395)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "รายการบริจาค"
        '
        'cboCatD
        '
        Me.cboCatD.FormattingEnabled = True
        Me.cboCatD.Location = New System.Drawing.Point(44, 86)
        Me.cboCatD.Name = "cboCatD"
        Me.cboCatD.Size = New System.Drawing.Size(174, 34)
        Me.cboCatD.TabIndex = 43
        '
        'txtDetail
        '
        Me.txtDetail.Location = New System.Drawing.Point(238, 86)
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.Size = New System.Drawing.Size(280, 32)
        Me.txtDetail.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(235, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 26)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "รายละเอียด :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(172, 26)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "ประเภทการบริจาค:"
        '
        'lsvProductList
        '
        Me.lsvProductList.Location = New System.Drawing.Point(44, 141)
        Me.lsvProductList.Name = "lsvProductList"
        Me.lsvProductList.Size = New System.Drawing.Size(600, 170)
        Me.lsvProductList.TabIndex = 10
        Me.lsvProductList.TabStop = False
        Me.lsvProductList.UseCompatibleStateImageBehavior = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(522, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 26)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "จำนวนเงิน :"
        '
        'txtDon
        '
        Me.txtDon.Location = New System.Drawing.Point(524, 87)
        Me.txtDon.Name = "txtDon"
        Me.txtDon.Size = New System.Drawing.Size(120, 32)
        Me.txtDon.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.lblContactName)
        Me.GroupBox1.Controls.Add(Me.txtCustomerID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(111, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(475, 209)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ข้อมูลลูกค้า"
        '
        'lblContactName
        '
        Me.lblContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContactName.Location = New System.Drawing.Point(192, 105)
        Me.lblContactName.Name = "lblContactName"
        Me.lblContactName.Size = New System.Drawing.Size(210, 30)
        Me.lblContactName.TabIndex = 4
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Location = New System.Drawing.Point(61, 103)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(77, 32)
        Me.txtCustomerID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ชื่อ-สกุล :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสลูกค้า :"
        '
        'cboEmployee
        '
        Me.cboEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboEmployee.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboEmployee.FormattingEnabled = True
        Me.cboEmployee.Location = New System.Drawing.Point(615, 261)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(307, 32)
        Me.cboEmployee.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(611, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "พนักงานขาย :"
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(832, 415)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(118, 49)
        Me.cmdClear.TabIndex = 25
        Me.cmdClear.Text = "ล้าง"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(832, 344)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(118, 48)
        Me.cmdAdd.TabIndex = 24
        Me.cmdAdd.Text = "เพิ่มรายการ"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'lblNet
        '
        Me.lblNet.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNet.BackColor = System.Drawing.Color.Black
        Me.lblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblNet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNet.Location = New System.Drawing.Point(615, 163)
        Me.lblNet.Name = "lblNet"
        Me.lblNet.Size = New System.Drawing.Size(205, 53)
        Me.lblNet.TabIndex = 28
        Me.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(682, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 24)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "รวมเป็นเงิน :"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(832, 488)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(118, 51)
        Me.cmdSave.TabIndex = 26
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txtOrderDID
        '
        Me.txtOrderDID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtOrderDID.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderDID.Location = New System.Drawing.Point(536, 45)
        Me.txtOrderDID.Name = "txtOrderDID"
        Me.txtOrderDID.ReadOnly = True
        Me.txtOrderDID.Size = New System.Drawing.Size(127, 32)
        Me.txtOrderDID.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(346, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 26)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "เลขที่ใบบริจาค :"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Button1.Image = Global.ProjectRK.My.Resources.Resources._028_home1
        Me.Button1.Location = New System.Drawing.Point(111, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 79)
        Me.Button1.TabIndex = 141
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form_Donate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.cboEmployee)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtOrderDID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.lblNet)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdSave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Form_Donate"
        Me.Text = "Form_Donate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lsvProductList As ListView
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboEmployee As ComboBox
    Friend WithEvents lblContactName As Label
    Friend WithEvents txtCustomerID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents lblNet As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents txtDon As TextBox
    Friend WithEvents txtOrderDID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboCatD As ComboBox
    Friend WithEvents txtDetail As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
End Class
