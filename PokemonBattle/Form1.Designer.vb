<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        lblMyPkmn = New Label()
        lblOppPkmn = New Label()
        cbOpponent = New ComboBox()
        lblOppType1 = New Label()
        lblOppType2 = New Label()
        lblType1h = New Label()
        lblType2h = New Label()
        lblTotal = New Label()
        cbPkmn1 = New ComboBox()
        cbPkmn2 = New ComboBox()
        cbPkmn3 = New ComboBox()
        cbPkmn4 = New ComboBox()
        cbPkmn5 = New ComboBox()
        cbPkmn6 = New ComboBox()
        lblPkmn1Type1 = New Label()
        lblPkmn1Type2 = New Label()
        lblPkmn2Type1 = New Label()
        lblPkmn2Type2 = New Label()
        lblPkmn3Type1 = New Label()
        lblPkmn3Type2 = New Label()
        lblPkmn4Type1 = New Label()
        lblPkmn4Type2 = New Label()
        lblPkmn5Type1 = New Label()
        lblPkmn5Type2 = New Label()
        lblPkmn6Type1 = New Label()
        lblPkmn6Type2 = New Label()
        lblP1T1vO = New Label()
        lblP1T2vO = New Label()
        lblP2T1vO = New Label()
        lblP2T2vO = New Label()
        lblP3T1vO = New Label()
        lblP3T2vO = New Label()
        lblP4T1vO = New Label()
        lblP4T2vO = New Label()
        lblP5T1vO = New Label()
        lblP5T2vO = New Label()
        lblP6T1vO = New Label()
        lblP6T2vO = New Label()
        pbPkmn = New PictureBox()
        lblPkmn1Tot = New Label()
        lblPkmn2Tot = New Label()
        lblPkmn3Tot = New Label()
        lblPkmn4Tot = New Label()
        lblPkmn5Tot = New Label()
        lblPkmn6Tot = New Label()
        CType(pbPkmn, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblMyPkmn
        ' 
        lblMyPkmn.AutoSize = True
        lblMyPkmn.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        lblMyPkmn.Location = New Point(41, 20)
        lblMyPkmn.Name = "lblMyPkmn"
        lblMyPkmn.Size = New Size(135, 28)
        lblMyPkmn.TabIndex = 0
        lblMyPkmn.Text = "My Pokemon"
        ' 
        ' lblOppPkmn
        ' 
        lblOppPkmn.AutoSize = True
        lblOppPkmn.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        lblOppPkmn.Location = New Point(815, 20)
        lblOppPkmn.Name = "lblOppPkmn"
        lblOppPkmn.Size = New Size(106, 28)
        lblOppPkmn.TabIndex = 1
        lblOppPkmn.Text = "Opponent"
        ' 
        ' cbOpponent
        ' 
        cbOpponent.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbOpponent.Font = New Font("Segoe UI", 12F)
        cbOpponent.FormattingEnabled = True
        cbOpponent.Location = New Point(776, 66)
        cbOpponent.Name = "cbOpponent"
        cbOpponent.Size = New Size(192, 36)
        cbOpponent.TabIndex = 2
        ' 
        ' lblOppType1
        ' 
        lblOppType1.AutoSize = True
        lblOppType1.Font = New Font("Segoe UI", 12F)
        lblOppType1.Location = New Point(815, 133)
        lblOppType1.Name = "lblOppType1"
        lblOppType1.RightToLeft = RightToLeft.No
        lblOppType1.Size = New Size(113, 28)
        lblOppType1.TabIndex = 9
        lblOppType1.Text = "Opp Type 1"
        ' 
        ' lblOppType2
        ' 
        lblOppType2.AutoSize = True
        lblOppType2.Font = New Font("Segoe UI", 12F)
        lblOppType2.Location = New Point(815, 189)
        lblOppType2.Name = "lblOppType2"
        lblOppType2.RightToLeft = RightToLeft.No
        lblOppType2.Size = New Size(113, 28)
        lblOppType2.TabIndex = 10
        lblOppType2.Text = "Opp Type 2"
        ' 
        ' lblType1h
        ' 
        lblType1h.AutoSize = True
        lblType1h.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        lblType1h.Location = New Point(239, 20)
        lblType1h.Name = "lblType1h"
        lblType1h.RightToLeft = RightToLeft.No
        lblType1h.Size = New Size(75, 28)
        lblType1h.TabIndex = 11
        lblType1h.Text = "Type 1"
        ' 
        ' lblType2h
        ' 
        lblType2h.AutoSize = True
        lblType2h.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        lblType2h.Location = New Point(405, 20)
        lblType2h.Name = "lblType2h"
        lblType2h.RightToLeft = RightToLeft.No
        lblType2h.Size = New Size(75, 28)
        lblType2h.TabIndex = 12
        lblType2h.Text = "Type 2"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Underline)
        lblTotal.Location = New Point(588, 20)
        lblTotal.Name = "lblTotal"
        lblTotal.RightToLeft = RightToLeft.No
        lblTotal.Size = New Size(59, 28)
        lblTotal.TabIndex = 13
        lblTotal.Text = "Total"
        ' 
        ' cbPkmn1
        ' 
        cbPkmn1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbPkmn1.Font = New Font("Segoe UI", 12F)
        cbPkmn1.FormattingEnabled = True
        cbPkmn1.Location = New Point(12, 66)
        cbPkmn1.Name = "cbPkmn1"
        cbPkmn1.Size = New Size(192, 36)
        cbPkmn1.TabIndex = 14
        ' 
        ' cbPkmn2
        ' 
        cbPkmn2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbPkmn2.Font = New Font("Segoe UI", 12F)
        cbPkmn2.FormattingEnabled = True
        cbPkmn2.Location = New Point(12, 133)
        cbPkmn2.Name = "cbPkmn2"
        cbPkmn2.Size = New Size(192, 36)
        cbPkmn2.TabIndex = 15
        ' 
        ' cbPkmn3
        ' 
        cbPkmn3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbPkmn3.Font = New Font("Segoe UI", 12F)
        cbPkmn3.FormattingEnabled = True
        cbPkmn3.Location = New Point(12, 200)
        cbPkmn3.Name = "cbPkmn3"
        cbPkmn3.Size = New Size(192, 36)
        cbPkmn3.TabIndex = 16
        ' 
        ' cbPkmn4
        ' 
        cbPkmn4.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbPkmn4.Font = New Font("Segoe UI", 12F)
        cbPkmn4.FormattingEnabled = True
        cbPkmn4.Location = New Point(12, 268)
        cbPkmn4.Name = "cbPkmn4"
        cbPkmn4.Size = New Size(192, 36)
        cbPkmn4.TabIndex = 17
        ' 
        ' cbPkmn5
        ' 
        cbPkmn5.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbPkmn5.Font = New Font("Segoe UI", 12F)
        cbPkmn5.FormattingEnabled = True
        cbPkmn5.Location = New Point(12, 338)
        cbPkmn5.Name = "cbPkmn5"
        cbPkmn5.Size = New Size(192, 36)
        cbPkmn5.TabIndex = 18
        ' 
        ' cbPkmn6
        ' 
        cbPkmn6.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbPkmn6.Font = New Font("Segoe UI", 12F)
        cbPkmn6.FormattingEnabled = True
        cbPkmn6.Location = New Point(12, 409)
        cbPkmn6.Name = "cbPkmn6"
        cbPkmn6.Size = New Size(192, 36)
        cbPkmn6.TabIndex = 19
        ' 
        ' lblPkmn1Type1
        ' 
        lblPkmn1Type1.AutoSize = True
        lblPkmn1Type1.Font = New Font("Segoe UI", 10F)
        lblPkmn1Type1.Location = New Point(248, 66)
        lblPkmn1Type1.Name = "lblPkmn1Type1"
        lblPkmn1Type1.Size = New Size(149, 23)
        lblPkmn1Type1.TabIndex = 20
        lblPkmn1Type1.Text = "Pokemon 1 Type 1"
        ' 
        ' lblPkmn1Type2
        ' 
        lblPkmn1Type2.AutoSize = True
        lblPkmn1Type2.Font = New Font("Segoe UI", 10F)
        lblPkmn1Type2.Location = New Point(414, 66)
        lblPkmn1Type2.Name = "lblPkmn1Type2"
        lblPkmn1Type2.Size = New Size(149, 23)
        lblPkmn1Type2.TabIndex = 21
        lblPkmn1Type2.Text = "Pokemon 1 Type 2"
        ' 
        ' lblPkmn2Type1
        ' 
        lblPkmn2Type1.AutoSize = True
        lblPkmn2Type1.Font = New Font("Segoe UI", 10F)
        lblPkmn2Type1.Location = New Point(248, 133)
        lblPkmn2Type1.Name = "lblPkmn2Type1"
        lblPkmn2Type1.Size = New Size(149, 23)
        lblPkmn2Type1.TabIndex = 22
        lblPkmn2Type1.Text = "Pokemon 2 Type 1"
        ' 
        ' lblPkmn2Type2
        ' 
        lblPkmn2Type2.AutoSize = True
        lblPkmn2Type2.Font = New Font("Segoe UI", 10F)
        lblPkmn2Type2.Location = New Point(414, 133)
        lblPkmn2Type2.Name = "lblPkmn2Type2"
        lblPkmn2Type2.Size = New Size(149, 23)
        lblPkmn2Type2.TabIndex = 23
        lblPkmn2Type2.Text = "Pokemon 2 Type 2"
        ' 
        ' lblPkmn3Type1
        ' 
        lblPkmn3Type1.AutoSize = True
        lblPkmn3Type1.Font = New Font("Segoe UI", 10F)
        lblPkmn3Type1.Location = New Point(248, 200)
        lblPkmn3Type1.Name = "lblPkmn3Type1"
        lblPkmn3Type1.Size = New Size(149, 23)
        lblPkmn3Type1.TabIndex = 24
        lblPkmn3Type1.Text = "Pokemon 3 Type 1"
        ' 
        ' lblPkmn3Type2
        ' 
        lblPkmn3Type2.AutoSize = True
        lblPkmn3Type2.Font = New Font("Segoe UI", 10F)
        lblPkmn3Type2.Location = New Point(414, 197)
        lblPkmn3Type2.Name = "lblPkmn3Type2"
        lblPkmn3Type2.Size = New Size(149, 23)
        lblPkmn3Type2.TabIndex = 25
        lblPkmn3Type2.Text = "Pokemon 3 Type 2"
        ' 
        ' lblPkmn4Type1
        ' 
        lblPkmn4Type1.AutoSize = True
        lblPkmn4Type1.Font = New Font("Segoe UI", 10F)
        lblPkmn4Type1.Location = New Point(248, 268)
        lblPkmn4Type1.Name = "lblPkmn4Type1"
        lblPkmn4Type1.Size = New Size(149, 23)
        lblPkmn4Type1.TabIndex = 26
        lblPkmn4Type1.Text = "Pokemon 4 Type 1"
        ' 
        ' lblPkmn4Type2
        ' 
        lblPkmn4Type2.AutoSize = True
        lblPkmn4Type2.Font = New Font("Segoe UI", 10F)
        lblPkmn4Type2.Location = New Point(414, 268)
        lblPkmn4Type2.Name = "lblPkmn4Type2"
        lblPkmn4Type2.Size = New Size(149, 23)
        lblPkmn4Type2.TabIndex = 27
        lblPkmn4Type2.Text = "Pokemon 4 Type 2"
        ' 
        ' lblPkmn5Type1
        ' 
        lblPkmn5Type1.AutoSize = True
        lblPkmn5Type1.Font = New Font("Segoe UI", 10F)
        lblPkmn5Type1.Location = New Point(248, 338)
        lblPkmn5Type1.Name = "lblPkmn5Type1"
        lblPkmn5Type1.Size = New Size(149, 23)
        lblPkmn5Type1.TabIndex = 28
        lblPkmn5Type1.Text = "Pokemon 5 Type 1"
        ' 
        ' lblPkmn5Type2
        ' 
        lblPkmn5Type2.AutoSize = True
        lblPkmn5Type2.Font = New Font("Segoe UI", 10F)
        lblPkmn5Type2.Location = New Point(414, 338)
        lblPkmn5Type2.Name = "lblPkmn5Type2"
        lblPkmn5Type2.Size = New Size(149, 23)
        lblPkmn5Type2.TabIndex = 29
        lblPkmn5Type2.Text = "Pokemon 5 Type 2"
        ' 
        ' lblPkmn6Type1
        ' 
        lblPkmn6Type1.AutoSize = True
        lblPkmn6Type1.Font = New Font("Segoe UI", 10F)
        lblPkmn6Type1.Location = New Point(248, 409)
        lblPkmn6Type1.Name = "lblPkmn6Type1"
        lblPkmn6Type1.Size = New Size(149, 23)
        lblPkmn6Type1.TabIndex = 30
        lblPkmn6Type1.Text = "Pokemon 6 Type 1"
        ' 
        ' lblPkmn6Type2
        ' 
        lblPkmn6Type2.AutoSize = True
        lblPkmn6Type2.Font = New Font("Segoe UI", 10F)
        lblPkmn6Type2.Location = New Point(414, 409)
        lblPkmn6Type2.Name = "lblPkmn6Type2"
        lblPkmn6Type2.Size = New Size(149, 23)
        lblPkmn6Type2.TabIndex = 31
        lblPkmn6Type2.Text = "Pokemon 6 Type 2"
        ' 
        ' lblP1T1vO
        ' 
        lblP1T1vO.AutoSize = True
        lblP1T1vO.Font = New Font("Segoe UI", 8F)
        lblP1T1vO.Location = New Point(248, 89)
        lblP1T1vO.Name = "lblP1T1vO"
        lblP1T1vO.Size = New Size(91, 19)
        lblP1T1vO.TabIndex = 32
        lblP1T1vO.Text = "vs Opp Types"
        ' 
        ' lblP1T2vO
        ' 
        lblP1T2vO.AutoSize = True
        lblP1T2vO.Font = New Font("Segoe UI", 8F)
        lblP1T2vO.Location = New Point(414, 89)
        lblP1T2vO.Name = "lblP1T2vO"
        lblP1T2vO.Size = New Size(91, 19)
        lblP1T2vO.TabIndex = 33
        lblP1T2vO.Text = "vs Opp Types"
        ' 
        ' lblP2T1vO
        ' 
        lblP2T1vO.AutoSize = True
        lblP2T1vO.Font = New Font("Segoe UI", 8F)
        lblP2T1vO.Location = New Point(248, 156)
        lblP2T1vO.Name = "lblP2T1vO"
        lblP2T1vO.Size = New Size(91, 19)
        lblP2T1vO.TabIndex = 34
        lblP2T1vO.Text = "vs Opp Types"
        ' 
        ' lblP2T2vO
        ' 
        lblP2T2vO.AutoSize = True
        lblP2T2vO.Font = New Font("Segoe UI", 8F)
        lblP2T2vO.Location = New Point(414, 156)
        lblP2T2vO.Name = "lblP2T2vO"
        lblP2T2vO.Size = New Size(91, 19)
        lblP2T2vO.TabIndex = 35
        lblP2T2vO.Text = "vs Opp Types"
        ' 
        ' lblP3T1vO
        ' 
        lblP3T1vO.AutoSize = True
        lblP3T1vO.Font = New Font("Segoe UI", 8F)
        lblP3T1vO.Location = New Point(248, 223)
        lblP3T1vO.Name = "lblP3T1vO"
        lblP3T1vO.Size = New Size(91, 19)
        lblP3T1vO.TabIndex = 36
        lblP3T1vO.Text = "vs Opp Types"
        ' 
        ' lblP3T2vO
        ' 
        lblP3T2vO.AutoSize = True
        lblP3T2vO.Font = New Font("Segoe UI", 8F)
        lblP3T2vO.Location = New Point(414, 223)
        lblP3T2vO.Name = "lblP3T2vO"
        lblP3T2vO.Size = New Size(91, 19)
        lblP3T2vO.TabIndex = 37
        lblP3T2vO.Text = "vs Opp Types"
        ' 
        ' lblP4T1vO
        ' 
        lblP4T1vO.AutoSize = True
        lblP4T1vO.Font = New Font("Segoe UI", 8F)
        lblP4T1vO.Location = New Point(248, 291)
        lblP4T1vO.Name = "lblP4T1vO"
        lblP4T1vO.Size = New Size(91, 19)
        lblP4T1vO.TabIndex = 38
        lblP4T1vO.Text = "vs Opp Types"
        ' 
        ' lblP4T2vO
        ' 
        lblP4T2vO.AutoSize = True
        lblP4T2vO.Font = New Font("Segoe UI", 8F)
        lblP4T2vO.Location = New Point(414, 291)
        lblP4T2vO.Name = "lblP4T2vO"
        lblP4T2vO.Size = New Size(91, 19)
        lblP4T2vO.TabIndex = 39
        lblP4T2vO.Text = "vs Opp Types"
        ' 
        ' lblP5T1vO
        ' 
        lblP5T1vO.AutoSize = True
        lblP5T1vO.Font = New Font("Segoe UI", 8F)
        lblP5T1vO.Location = New Point(248, 361)
        lblP5T1vO.Name = "lblP5T1vO"
        lblP5T1vO.Size = New Size(91, 19)
        lblP5T1vO.TabIndex = 40
        lblP5T1vO.Text = "vs Opp Types"
        ' 
        ' lblP5T2vO
        ' 
        lblP5T2vO.AutoSize = True
        lblP5T2vO.Font = New Font("Segoe UI", 8F)
        lblP5T2vO.Location = New Point(414, 361)
        lblP5T2vO.Name = "lblP5T2vO"
        lblP5T2vO.Size = New Size(91, 19)
        lblP5T2vO.TabIndex = 41
        lblP5T2vO.Text = "vs Opp Types"
        ' 
        ' lblP6T1vO
        ' 
        lblP6T1vO.AutoSize = True
        lblP6T1vO.Font = New Font("Segoe UI", 8F)
        lblP6T1vO.Location = New Point(248, 432)
        lblP6T1vO.Name = "lblP6T1vO"
        lblP6T1vO.Size = New Size(91, 19)
        lblP6T1vO.TabIndex = 42
        lblP6T1vO.Text = "vs Opp Types"
        ' 
        ' lblP6T2vO
        ' 
        lblP6T2vO.AutoSize = True
        lblP6T2vO.Font = New Font("Segoe UI", 8F)
        lblP6T2vO.Location = New Point(414, 432)
        lblP6T2vO.Name = "lblP6T2vO"
        lblP6T2vO.Size = New Size(91, 19)
        lblP6T2vO.TabIndex = 43
        lblP6T2vO.Text = "vs Opp Types"
        ' 
        ' pbPkmn
        ' 
        pbPkmn.Image = My.Resources.Resources._128px_Poké_Ball
        pbPkmn.Location = New Point(815, 268)
        pbPkmn.Name = "pbPkmn"
        pbPkmn.Size = New Size(127, 128)
        pbPkmn.TabIndex = 44
        pbPkmn.TabStop = False
        ' 
        ' lblPkmn1Tot
        ' 
        lblPkmn1Tot.AutoSize = True
        lblPkmn1Tot.Font = New Font("Segoe UI", 12F)
        lblPkmn1Tot.Location = New Point(588, 69)
        lblPkmn1Tot.Name = "lblPkmn1Tot"
        lblPkmn1Tot.Size = New Size(157, 28)
        lblPkmn1Tot.TabIndex = 45
        lblPkmn1Tot.Text = "Pokemon 1 Total"
        lblPkmn1Tot.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPkmn2Tot
        ' 
        lblPkmn2Tot.AutoSize = True
        lblPkmn2Tot.Font = New Font("Segoe UI", 12F)
        lblPkmn2Tot.Location = New Point(588, 136)
        lblPkmn2Tot.Name = "lblPkmn2Tot"
        lblPkmn2Tot.Size = New Size(157, 28)
        lblPkmn2Tot.TabIndex = 46
        lblPkmn2Tot.Text = "Pokemon 2 Total"
        lblPkmn2Tot.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPkmn3Tot
        ' 
        lblPkmn3Tot.AutoSize = True
        lblPkmn3Tot.Font = New Font("Segoe UI", 12F)
        lblPkmn3Tot.Location = New Point(588, 203)
        lblPkmn3Tot.Name = "lblPkmn3Tot"
        lblPkmn3Tot.Size = New Size(157, 28)
        lblPkmn3Tot.TabIndex = 47
        lblPkmn3Tot.Text = "Pokemon 3 Total"
        lblPkmn3Tot.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPkmn4Tot
        ' 
        lblPkmn4Tot.AutoSize = True
        lblPkmn4Tot.Font = New Font("Segoe UI", 12F)
        lblPkmn4Tot.Location = New Point(588, 271)
        lblPkmn4Tot.Name = "lblPkmn4Tot"
        lblPkmn4Tot.Size = New Size(157, 28)
        lblPkmn4Tot.TabIndex = 48
        lblPkmn4Tot.Text = "Pokemon 4 Total"
        lblPkmn4Tot.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPkmn5Tot
        ' 
        lblPkmn5Tot.AutoSize = True
        lblPkmn5Tot.Font = New Font("Segoe UI", 12F)
        lblPkmn5Tot.Location = New Point(588, 341)
        lblPkmn5Tot.Name = "lblPkmn5Tot"
        lblPkmn5Tot.Size = New Size(157, 28)
        lblPkmn5Tot.TabIndex = 49
        lblPkmn5Tot.Text = "Pokemon 5 Total"
        lblPkmn5Tot.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPkmn6Tot
        ' 
        lblPkmn6Tot.AutoSize = True
        lblPkmn6Tot.Font = New Font("Segoe UI", 12F)
        lblPkmn6Tot.Location = New Point(588, 412)
        lblPkmn6Tot.Name = "lblPkmn6Tot"
        lblPkmn6Tot.Size = New Size(157, 28)
        lblPkmn6Tot.TabIndex = 50
        lblPkmn6Tot.Text = "Pokemon 6 Total"
        lblPkmn6Tot.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Info
        ClientSize = New Size(1004, 477)
        Controls.Add(lblPkmn6Tot)
        Controls.Add(lblPkmn5Tot)
        Controls.Add(lblPkmn4Tot)
        Controls.Add(lblPkmn3Tot)
        Controls.Add(lblPkmn2Tot)
        Controls.Add(lblPkmn1Tot)
        Controls.Add(pbPkmn)
        Controls.Add(lblP6T2vO)
        Controls.Add(lblP6T1vO)
        Controls.Add(lblP5T2vO)
        Controls.Add(lblP5T1vO)
        Controls.Add(lblP4T2vO)
        Controls.Add(lblP4T1vO)
        Controls.Add(lblP3T2vO)
        Controls.Add(lblP3T1vO)
        Controls.Add(lblP2T2vO)
        Controls.Add(lblP2T1vO)
        Controls.Add(lblP1T2vO)
        Controls.Add(lblP1T1vO)
        Controls.Add(lblPkmn6Type2)
        Controls.Add(lblPkmn6Type1)
        Controls.Add(lblPkmn5Type2)
        Controls.Add(lblPkmn5Type1)
        Controls.Add(lblPkmn4Type2)
        Controls.Add(lblPkmn4Type1)
        Controls.Add(lblPkmn3Type2)
        Controls.Add(lblPkmn3Type1)
        Controls.Add(lblPkmn2Type2)
        Controls.Add(lblPkmn2Type1)
        Controls.Add(lblPkmn1Type2)
        Controls.Add(lblPkmn1Type1)
        Controls.Add(cbPkmn6)
        Controls.Add(cbPkmn5)
        Controls.Add(cbPkmn4)
        Controls.Add(cbPkmn3)
        Controls.Add(cbPkmn2)
        Controls.Add(cbPkmn1)
        Controls.Add(lblTotal)
        Controls.Add(lblType2h)
        Controls.Add(lblType1h)
        Controls.Add(lblOppType2)
        Controls.Add(lblOppType1)
        Controls.Add(cbOpponent)
        Controls.Add(lblOppPkmn)
        Controls.Add(lblMyPkmn)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Pokemon Battle Type Analyzer"
        CType(pbPkmn, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblMyPkmn As Label
    Friend WithEvents lblOppPkmn As Label
    Friend WithEvents cbOpponent As ComboBox
    Friend WithEvents lblOppType1 As Label
    Friend WithEvents lblOppType2 As Label
    Friend WithEvents lblType1h As Label
    Friend WithEvents lblType2h As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents cbPkmn1 As ComboBox
    Friend WithEvents cbPkmn2 As ComboBox
    Friend WithEvents cbPkmn3 As ComboBox
    Friend WithEvents cbPkmn4 As ComboBox
    Friend WithEvents cbPkmn5 As ComboBox
    Friend WithEvents cbPkmn6 As ComboBox
    Friend WithEvents lblPkmn1Type1 As Label
    Friend WithEvents lblPkmn1Type2 As Label
    Friend WithEvents lblPkmn2Type1 As Label
    Friend WithEvents lblPkmn2Type2 As Label
    Friend WithEvents lblPkmn3Type1 As Label
    Friend WithEvents lblPkmn3Type2 As Label
    Friend WithEvents lblPkmn4Type1 As Label
    Friend WithEvents lblPkmn4Type2 As Label
    Friend WithEvents lblPkmn5Type1 As Label
    Friend WithEvents lblPkmn5Type2 As Label
    Friend WithEvents lblPkmn6Type1 As Label
    Friend WithEvents lblPkmn6Type2 As Label
    Friend WithEvents lblP1T1vO As Label
    Friend WithEvents lblP1T2vO As Label
    Friend WithEvents lblP2T1vO As Label
    Friend WithEvents lblP2T2vO As Label
    Friend WithEvents lblP3T1vO As Label
    Friend WithEvents lblP3T2vO As Label
    Friend WithEvents lblP4T1vO As Label
    Friend WithEvents lblP4T2vO As Label
    Friend WithEvents lblP5T1vO As Label
    Friend WithEvents lblP5T2vO As Label
    Friend WithEvents lblP6T1vO As Label
    Friend WithEvents lblP6T2vO As Label
    Friend WithEvents pbPkmn As PictureBox
    Friend WithEvents lblPkmn1Tot As Label
    Friend WithEvents lblPkmn2Tot As Label
    Friend WithEvents lblPkmn3Tot As Label
    Friend WithEvents lblPkmn4Tot As Label
    Friend WithEvents lblPkmn5Tot As Label
    Friend WithEvents lblPkmn6Tot As Label

End Class
