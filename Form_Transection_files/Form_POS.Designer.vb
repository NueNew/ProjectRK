<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_POS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSPro = New System.Windows.Forms.Button()
        Me.txtCate = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lsvProductList = New System.Windows.Forms.ListView()
        Me.num_exit = New System.Windows.Forms.NumericUpDown()
        Me.txtStockLeft = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSalePrice = New System.Windows.Forms.Label()
        Me.lblProductName = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnSCus = New System.Windows.Forms.Button()
        Me.lblContactName = New System.Windows.Forms.Label()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.lblNet = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtOrderID = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.num_exit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.btnSPro)
        Me.GroupBox2.Controls.Add(Me.txtCate)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lsvProductList)
        Me.GroupBox2.Controls.Add(Me.num_exit)
        Me.GroupBox2.Controls.Add(Me.txtStockLeft)
        Me.GroupBox2.Controls.Add(Me.lblTotal)
        Me.GroupBox2.Controls.Add(Me.lblSalePrice)
        Me.GroupBox2.Controls.Add(Me.lblProductName)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtProductID)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(112, 313)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(823, 391)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "รายการสั่งซื้อ"
        '
        'btnSPro
        '
        Me.btnSPro.Location = New System.Drawing.Point(20, 117)
        Me.btnSPro.Name = "btnSPro"
        Me.btnSPro.Size = New System.Drawing.Size(37, 36)
        Me.btnSPro.TabIndex = 142
        Me.btnSPro.Text = "ว"
        Me.btnSPro.UseVisualStyleBackColor = True
        '
        'txtCate
        '
        Me.txtCate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCate.Location = New System.Drawing.Point(200, 41)
        Me.txtCate.Name = "txtCate"
        Me.txtCate.ReadOnly = True
        Me.txtCate.Size = New System.Drawing.Size(175, 32)
        Me.txtCate.TabIndex = 13
        Me.txtCate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(170, 26)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "ประเภทวัตถุมงคล :"
        '
        'lsvProductList
        '
        Me.lsvProductList.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lsvProductList.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvProductList.Location = New System.Drawing.Point(20, 165)
        Me.lsvProductList.Name = "lsvProductList"
        Me.lsvProductList.Size = New System.Drawing.Size(773, 179)
        Me.lsvProductList.TabIndex = 10
        Me.lsvProductList.TabStop = False
        Me.lsvProductList.UseCompatibleStateImageBehavior = False
        '
        'num_exit
        '
        Me.num_exit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.num_exit.Location = New System.Drawing.Point(560, 123)
        Me.num_exit.Name = "num_exit"
        Me.num_exit.Size = New System.Drawing.Size(85, 32)
        Me.num_exit.TabIndex = 11
        '
        'txtStockLeft
        '
        Me.txtStockLeft.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtStockLeft.Location = New System.Drawing.Point(560, 41)
        Me.txtStockLeft.Name = "txtStockLeft"
        Me.txtStockLeft.ReadOnly = True
        Me.txtStockLeft.Size = New System.Drawing.Size(102, 32)
        Me.txtStockLeft.TabIndex = 1
        Me.txtStockLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Location = New System.Drawing.Point(657, 123)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(136, 32)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSalePrice
        '
        Me.lblSalePrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSalePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSalePrice.Location = New System.Drawing.Point(428, 123)
        Me.lblSalePrice.Name = "lblSalePrice"
        Me.lblSalePrice.Size = New System.Drawing.Size(120, 32)
        Me.lblSalePrice.TabIndex = 8
        Me.lblSalePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProductName
        '
        Me.lblProductName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductName.Location = New System.Drawing.Point(172, 123)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(250, 32)
        Me.lblProductName.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(408, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 26)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "จำนวนคงเหลือ :"
        '
        'txtProductID
        '
        Me.txtProductID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtProductID.Location = New System.Drawing.Point(63, 121)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(89, 32)
        Me.txtProductID.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(651, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 26)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "รวมเป็นเงิน :"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(554, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 26)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "จำนวน :"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(422, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 26)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "ราคาขาย :"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(167, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 26)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "ชื่อวัตถุมงคล:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 26)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "รหัสวัตถุมงคล :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.BtnSCus)
        Me.GroupBox1.Controls.Add(Me.lblContactName)
        Me.GroupBox1.Controls.Add(Me.txtCustomerID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(112, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(543, 168)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ข้อมูลผู้บริจาค"
        '
        'BtnSCus
        '
        Me.BtnSCus.Location = New System.Drawing.Point(98, 84)
        Me.BtnSCus.Name = "BtnSCus"
        Me.BtnSCus.Size = New System.Drawing.Size(40, 35)
        Me.BtnSCus.TabIndex = 142
        Me.BtnSCus.Text = "บ"
        Me.BtnSCus.UseVisualStyleBackColor = True
        '
        'lblContactName
        '
        Me.lblContactName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContactName.Location = New System.Drawing.Point(155, 84)
        Me.lblContactName.Name = "lblContactName"
        Me.lblContactName.Size = New System.Drawing.Size(372, 36)
        Me.lblContactName.TabIndex = 4
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCustomerID.Location = New System.Drawing.Point(15, 85)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(77, 32)
        Me.txtCustomerID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(149, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ชื่อ-สกุล :"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "รหัสผู้บริจาค :"
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(953, 441)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(102, 58)
        Me.cmdClear.TabIndex = 18
        Me.cmdClear.Text = "ล้าง"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(953, 360)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(102, 47)
        Me.cmdAdd.TabIndex = 17
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
        Me.lblNet.Location = New System.Drawing.Point(718, 213)
        Me.lblNet.Name = "lblNet"
        Me.lblNet.Size = New System.Drawing.Size(262, 53)
        Me.lblNet.TabIndex = 21
        Me.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(828, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 26)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "รวมเป็นเงิน :"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(953, 533)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(102, 54)
        Me.cmdSave.TabIndex = 19
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(384, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(181, 26)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "เลขที่ใบเสร็จรับเงิน :"
        '
        'txtOrderID
        '
        Me.txtOrderID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtOrderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderID.Location = New System.Drawing.Point(631, 58)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.ReadOnly = True
        Me.txtOrderID.Size = New System.Drawing.Size(127, 32)
        Me.txtOrderID.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Button1.Image = Global.ProjectRK.My.Resources.Resources._028_home1
        Me.Button1.Location = New System.Drawing.Point(132, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 79)
        Me.Button1.TabIndex = 141
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Form_POS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 729)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtOrderID)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.lblNet)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdSave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Form_POS"
        Me.Text = "Form_POS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.num_exit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lsvProductList As ListView
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSalePrice As Label
    Friend WithEvents lblProductName As Label
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblContactName As Label
    Friend WithEvents txtCustomerID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents lblNet As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtOrderID As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents num_exit As NumericUpDown
    Friend WithEvents txtStockLeft As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtCate As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents BtnSCus As Button
    Friend WithEvents btnSPro As Button
End Class
