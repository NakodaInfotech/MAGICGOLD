<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class companymaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(companymaster))
        Me.txtcstno = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcmpname = New System.Windows.Forms.TextBox
        Me.lblgroup = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.txtlegalname = New System.Windows.Forms.TextBox
        Me.txtadd1 = New System.Windows.Forms.TextBox
        Me.txtadd2 = New System.Windows.Forms.TextBox
        Me.cmbcountry = New System.Windows.Forms.ComboBox
        Me.cmbstate = New System.Windows.Forms.ComboBox
        Me.cmbcity = New System.Windows.Forms.ComboBox
        Me.txtzipcode = New System.Windows.Forms.TextBox
        Me.txttel1 = New System.Windows.Forms.TextBox
        Me.txtfax = New System.Windows.Forms.TextBox
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.txtwebsite = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdnext = New System.Windows.Forms.Button
        Me.cmdleave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtinvinitials = New System.Windows.Forms.TextBox
        Me.txtdisplayedname = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.rbpropautho = New System.Windows.Forms.RadioButton
        Me.rbpartner = New System.Windows.Forms.RadioButton
        Me.rbautho = New System.Windows.Forms.RadioButton
        Me.rbprop = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtpanno = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdedit = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbcountryid = New System.Windows.Forms.ComboBox
        Me.txtvatno = New System.Windows.Forms.TextBox
        Me.cmbstateid = New System.Windows.Forms.ComboBox
        Me.cmdback = New System.Windows.Forms.Button
        Me.cmbcityid = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtcstno
        '
        Me.txtcstno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcstno.Location = New System.Drawing.Point(301, 141)
        Me.txtcstno.Name = "txtcstno"
        Me.txtcstno.Size = New System.Drawing.Size(117, 20)
        Me.txtcstno.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(5, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 14)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Concerned Person"
        '
        'txtcmpname
        '
        Me.txtcmpname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcmpname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcmpname.Location = New System.Drawing.Point(104, 17)
        Me.txtcmpname.MaxLength = 100
        Me.txtcmpname.Name = "txtcmpname"
        Me.txtcmpname.Size = New System.Drawing.Size(314, 20)
        Me.txtcmpname.TabIndex = 0
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(13, 21)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(89, 14)
        Me.lblgroup.TabIndex = 91
        Me.lblgroup.Text = "* Company Name"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(301, 33)
        Me.lbl.TabIndex = 92
        Me.lbl.Text = "Enter Your Company Information"
        '
        'txtlegalname
        '
        Me.txtlegalname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlegalname.Location = New System.Drawing.Point(104, 44)
        Me.txtlegalname.MaxLength = 100
        Me.txtlegalname.Name = "txtlegalname"
        Me.txtlegalname.Size = New System.Drawing.Size(314, 20)
        Me.txtlegalname.TabIndex = 1
        '
        'txtadd1
        '
        Me.txtadd1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd1.Location = New System.Drawing.Point(104, 193)
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(314, 20)
        Me.txtadd1.TabIndex = 11
        '
        'txtadd2
        '
        Me.txtadd2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd2.Location = New System.Drawing.Point(104, 220)
        Me.txtadd2.Name = "txtadd2"
        Me.txtadd2.Size = New System.Drawing.Size(314, 20)
        Me.txtadd2.TabIndex = 12
        '
        'cmbcountry
        '
        Me.cmbcountry.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcountry.FormattingEnabled = True
        Me.cmbcountry.Location = New System.Drawing.Point(301, 275)
        Me.cmbcountry.MaxDropDownItems = 14
        Me.cmbcountry.Name = "cmbcountry"
        Me.cmbcountry.Size = New System.Drawing.Size(117, 22)
        Me.cmbcountry.TabIndex = 16
        '
        'cmbstate
        '
        Me.cmbstate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstate.FormattingEnabled = True
        Me.cmbstate.Location = New System.Drawing.Point(104, 275)
        Me.cmbstate.MaxDropDownItems = 14
        Me.cmbstate.Name = "cmbstate"
        Me.cmbstate.Size = New System.Drawing.Size(117, 22)
        Me.cmbstate.TabIndex = 15
        '
        'cmbcity
        '
        Me.cmbcity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcity.FormattingEnabled = True
        Me.cmbcity.Location = New System.Drawing.Point(104, 247)
        Me.cmbcity.MaxDropDownItems = 14
        Me.cmbcity.Name = "cmbcity"
        Me.cmbcity.Size = New System.Drawing.Size(117, 22)
        Me.cmbcity.TabIndex = 13
        '
        'txtzipcode
        '
        Me.txtzipcode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtzipcode.Location = New System.Drawing.Point(301, 248)
        Me.txtzipcode.Name = "txtzipcode"
        Me.txtzipcode.Size = New System.Drawing.Size(117, 20)
        Me.txtzipcode.TabIndex = 14
        '
        'txttel1
        '
        Me.txttel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttel1.Location = New System.Drawing.Point(104, 303)
        Me.txttel1.Name = "txttel1"
        Me.txttel1.Size = New System.Drawing.Size(117, 20)
        Me.txttel1.TabIndex = 17
        '
        'txtfax
        '
        Me.txtfax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.Location = New System.Drawing.Point(301, 303)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(117, 20)
        Me.txtfax.TabIndex = 18
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(104, 330)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(314, 20)
        Me.txtemail.TabIndex = 19
        '
        'txtwebsite
        '
        Me.txtwebsite.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwebsite.Location = New System.Drawing.Point(104, 392)
        Me.txtwebsite.Name = "txtwebsite"
        Me.txtwebsite.Size = New System.Drawing.Size(314, 20)
        Me.txtwebsite.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(78, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "City"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(228, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "C.S.T. Tin No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(44, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 14)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "Address 1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(70, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 14)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "State"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(255, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 14)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Country"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(275, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 14)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "Fax"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(250, 252)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 14)
        Me.Label9.TabIndex = 149
        Me.Label9.Text = "Zip Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(45, 307)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 14)
        Me.Label10.TabIndex = 150
        Me.Label10.Text = "Telephone"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(22, 334)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 14)
        Me.Label11.TabIndex = 151
        Me.Label11.Text = "E-mail Address"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(52, 396)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 14)
        Me.Label12.TabIndex = 152
        Me.Label12.Text = "Web Site"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(101, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(284, 26)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "Enter Chairman's / Proprietor's / Partner's Name."
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Green
        Me.Label13.Location = New System.Drawing.Point(101, 353)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(317, 36)
        Me.Label13.TabIndex = 154
        Me.Label13.Text = "Enter E-mail Address                                                             " & _
            "    (e.g.  abc@gmail.com, xyz@yahoo.com..., etc. )"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Green
        Me.Label14.Location = New System.Drawing.Point(101, 415)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(317, 20)
        Me.Label14.TabIndex = 155
        Me.Label14.Text = "Enter Website. (e.g.  www.abc.com, www.xyz.com..., etc. )"
        '
        'cmdnext
        '
        Me.cmdnext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnext.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdnext.Location = New System.Drawing.Point(338, 445)
        Me.cmdnext.Name = "cmdnext"
        Me.cmdnext.Size = New System.Drawing.Size(80, 24)
        Me.cmdnext.TabIndex = 21
        Me.cmdnext.Text = "&Next >"
        Me.cmdnext.UseVisualStyleBackColor = True
        '
        'cmdleave
        '
        Me.cmdleave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdleave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdleave.Location = New System.Drawing.Point(50, 445)
        Me.cmdleave.Name = "cmdleave"
        Me.cmdleave.Size = New System.Drawing.Size(80, 24)
        Me.cmdleave.TabIndex = 22
        Me.cmdleave.Text = "&Leave.."
        Me.cmdleave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtinvinitials)
        Me.GroupBox1.Controls.Add(Me.txtdisplayedname)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.rbpropautho)
        Me.GroupBox1.Controls.Add(Me.rbpartner)
        Me.GroupBox1.Controls.Add(Me.rbautho)
        Me.GroupBox1.Controls.Add(Me.rbprop)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtpanno)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmdedit)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmbcountryid)
        Me.GroupBox1.Controls.Add(Me.txtvatno)
        Me.GroupBox1.Controls.Add(Me.cmbstateid)
        Me.GroupBox1.Controls.Add(Me.cmdback)
        Me.GroupBox1.Controls.Add(Me.cmbcityid)
        Me.GroupBox1.Controls.Add(Me.cmdnext)
        Me.GroupBox1.Controls.Add(Me.cmdleave)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtwebsite)
        Me.GroupBox1.Controls.Add(Me.txtemail)
        Me.GroupBox1.Controls.Add(Me.txtfax)
        Me.GroupBox1.Controls.Add(Me.txttel1)
        Me.GroupBox1.Controls.Add(Me.txtzipcode)
        Me.GroupBox1.Controls.Add(Me.cmbcountry)
        Me.GroupBox1.Controls.Add(Me.cmbstate)
        Me.GroupBox1.Controls.Add(Me.cmbcity)
        Me.GroupBox1.Controls.Add(Me.txtadd2)
        Me.GroupBox1.Controls.Add(Me.txtadd1)
        Me.GroupBox1.Controls.Add(Me.txtlegalname)
        Me.GroupBox1.Controls.Add(Me.txtcstno)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtcmpname)
        Me.GroupBox1.Controls.Add(Me.lblgroup)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(463, 475)
        Me.GroupBox1.TabIndex = 159
        Me.GroupBox1.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(29, 145)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 14)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Invoice Initials"
        '
        'txtinvinitials
        '
        Me.txtinvinitials.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtinvinitials.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvinitials.Location = New System.Drawing.Point(104, 141)
        Me.txtinvinitials.MaxLength = 50
        Me.txtinvinitials.Name = "txtinvinitials"
        Me.txtinvinitials.Size = New System.Drawing.Size(117, 20)
        Me.txtinvinitials.TabIndex = 7
        '
        'txtdisplayedname
        '
        Me.txtdisplayedname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdisplayedname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdisplayedname.Location = New System.Drawing.Point(104, 115)
        Me.txtdisplayedname.MaxLength = 100
        Me.txtdisplayedname.Name = "txtdisplayedname"
        Me.txtdisplayedname.Size = New System.Drawing.Size(314, 20)
        Me.txtdisplayedname.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtdisplayedname, "Name to be Displayed on Reports")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(11, 119)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 14)
        Me.Label19.TabIndex = 166
        Me.Label19.Text = "* Displayed Name"
        '
        'rbpropautho
        '
        Me.rbpropautho.AutoSize = True
        Me.rbpropautho.Location = New System.Drawing.Point(291, 88)
        Me.rbpropautho.Name = "rbpropautho"
        Me.rbpropautho.Size = New System.Drawing.Size(155, 18)
        Me.rbpropautho.TabIndex = 5
        Me.rbpropautho.Text = "Proprietor/Authorised Sign."
        Me.rbpropautho.UseVisualStyleBackColor = True
        '
        'rbpartner
        '
        Me.rbpartner.AutoSize = True
        Me.rbpartner.Location = New System.Drawing.Point(226, 88)
        Me.rbpartner.Name = "rbpartner"
        Me.rbpartner.Size = New System.Drawing.Size(60, 18)
        Me.rbpartner.TabIndex = 4
        Me.rbpartner.Text = "Partner"
        Me.rbpartner.UseVisualStyleBackColor = True
        '
        'rbautho
        '
        Me.rbautho.AutoSize = True
        Me.rbautho.Location = New System.Drawing.Point(116, 88)
        Me.rbautho.Name = "rbautho"
        Me.rbautho.Size = New System.Drawing.Size(105, 18)
        Me.rbautho.TabIndex = 3
        Me.rbautho.Text = "Authorised Sign."
        Me.rbautho.UseVisualStyleBackColor = True
        '
        'rbprop
        '
        Me.rbprop.AutoSize = True
        Me.rbprop.Checked = True
        Me.rbprop.Location = New System.Drawing.Point(39, 88)
        Me.rbprop.Name = "rbprop"
        Me.rbprop.Size = New System.Drawing.Size(72, 18)
        Me.rbprop.TabIndex = 2
        Me.rbprop.TabStop = True
        Me.rbprop.Text = "Proprietor"
        Me.rbprop.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(256, 171)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 14)
        Me.Label17.TabIndex = 164
        Me.Label17.Text = "Pan No."
        '
        'txtpanno
        '
        Me.txtpanno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpanno.Location = New System.Drawing.Point(301, 167)
        Me.txtpanno.Name = "txtpanno"
        Me.txtpanno.Size = New System.Drawing.Size(117, 20)
        Me.txtpanno.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(44, 224)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 14)
        Me.Label16.TabIndex = 162
        Me.Label16.Text = "Address 2"
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(136, 445)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(67, 24)
        Me.cmdedit.TabIndex = 161
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(42, 171)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 14)
        Me.Label15.TabIndex = 160
        Me.Label15.Text = "Vat Tin No."
        '
        'cmbcountryid
        '
        Me.cmbcountryid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcountryid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcountryid.FormattingEnabled = True
        Me.cmbcountryid.Items.AddRange(New Object() {"Bank", "Accounts Receivable", "Other Current Asset", "Fixed Asset", "Account Payable", "Other Current Liability", "Long Term Liability", "Equity", "Income", "Cost of Goods Sold", "Expense", "Other Income", "Other Expense"})
        Me.cmbcountryid.Location = New System.Drawing.Point(424, 253)
        Me.cmbcountryid.MaxDropDownItems = 14
        Me.cmbcountryid.Name = "cmbcountryid"
        Me.cmbcountryid.Size = New System.Drawing.Size(40, 22)
        Me.cmbcountryid.TabIndex = 136
        Me.cmbcountryid.Visible = False
        '
        'txtvatno
        '
        Me.txtvatno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvatno.Location = New System.Drawing.Point(104, 167)
        Me.txtvatno.Name = "txtvatno"
        Me.txtvatno.Size = New System.Drawing.Size(117, 20)
        Me.txtvatno.TabIndex = 9
        '
        'cmbstateid
        '
        Me.cmbstateid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstateid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstateid.FormattingEnabled = True
        Me.cmbstateid.Items.AddRange(New Object() {"Bank", "Accounts Receivable", "Other Current Asset", "Fixed Asset", "Account Payable", "Other Current Liability", "Long Term Liability", "Equity", "Income", "Cost of Goods Sold", "Expense", "Other Income", "Other Expense"})
        Me.cmbstateid.Location = New System.Drawing.Point(227, 277)
        Me.cmbstateid.MaxDropDownItems = 14
        Me.cmbstateid.Name = "cmbstateid"
        Me.cmbstateid.Size = New System.Drawing.Size(40, 22)
        Me.cmbstateid.TabIndex = 135
        Me.cmbstateid.Visible = False
        '
        'cmdback
        '
        Me.cmdback.Enabled = False
        Me.cmdback.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdback.Location = New System.Drawing.Point(252, 445)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(80, 24)
        Me.cmdback.TabIndex = 23
        Me.cmdback.Text = "< &Back"
        Me.cmdback.UseVisualStyleBackColor = True
        '
        'cmbcityid
        '
        Me.cmbcityid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcityid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcityid.FormattingEnabled = True
        Me.cmbcityid.Items.AddRange(New Object() {"Bank", "Accounts Receivable", "Other Current Asset", "Fixed Asset", "Account Payable", "Other Current Liability", "Long Term Liability", "Equity", "Income", "Cost of Goods Sold", "Expense", "Other Income", "Other Expense"})
        Me.cmbcityid.Location = New System.Drawing.Point(227, 244)
        Me.cmbcityid.MaxDropDownItems = 14
        Me.cmbcityid.Name = "cmbcityid"
        Me.cmbcityid.Size = New System.Drawing.Size(40, 22)
        Me.cmbcityid.TabIndex = 134
        Me.cmbcityid.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(84, 17)
        Me.ToolStripStatusLabel1.Text = "* Required Field"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 507)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(470, 22)
        Me.StatusStrip1.TabIndex = 160
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'companymaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.Magic_Gold.My.Resources.Resources.lgn_pnl
        Me.ClientSize = New System.Drawing.Size(470, 529)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "companymaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New Company"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtcstno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcmpname As System.Windows.Forms.TextBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents txtlegalname As System.Windows.Forms.TextBox
    Friend WithEvents txtadd1 As System.Windows.Forms.TextBox
    Friend WithEvents txtadd2 As System.Windows.Forms.TextBox
    Friend WithEvents cmbcountry As System.Windows.Forms.ComboBox
    Friend WithEvents cmbstate As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcity As System.Windows.Forms.ComboBox
    Friend WithEvents txtzipcode As System.Windows.Forms.TextBox
    Friend WithEvents txttel1 As System.Windows.Forms.TextBox
    Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents txtwebsite As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdnext As System.Windows.Forms.Button
    Friend WithEvents cmdleave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtvatno As System.Windows.Forms.TextBox
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtpanno As System.Windows.Forms.TextBox
    Friend WithEvents rbpropautho As System.Windows.Forms.RadioButton
    Friend WithEvents rbpartner As System.Windows.Forms.RadioButton
    Friend WithEvents rbautho As System.Windows.Forms.RadioButton
    Friend WithEvents rbprop As System.Windows.Forms.RadioButton
    Friend WithEvents txtdisplayedname As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtinvinitials As System.Windows.Forms.TextBox
    Friend WithEvents cmbcountryid As System.Windows.Forms.ComboBox
    Friend WithEvents cmbstateid As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcityid As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
End Class
