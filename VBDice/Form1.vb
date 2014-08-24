Public Class frmDice
    Private txtName(9) As TextBox
    Private txtNum(9) As TextBox
    Private lblNum(9) As Label
    Private txtSide(9) As TextBox
    Private lblSide(9) As Label
    Private txtMod(9) As TextBox
    Private lblMod(9) As Label
    Private cmdRoll(9) As Button
    Private lblResult(9) As Label
    Private I As Integer
    Private rnd As New Random

    Private Sub frmDice_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim NameSettings As System.Collections.Specialized.StringCollection = My.Settings.Name
        Dim NumSettings As System.Collections.Specialized.StringCollection = My.Settings.Num
        Dim SideSettings As System.Collections.Specialized.StringCollection = My.Settings.Side
        Dim ModSettings As System.Collections.Specialized.StringCollection = My.Settings.Modi

        For Me.I = 0 To 9
            NameSettings(I) = txtName(I).Text
            NumSettings(I) = txtNum(I).Text
            SideSettings(I) = txtSide(I).Text
            ModSettings(I) = txtMod(I).Text
        Next

        My.Settings.Name = NameSettings
        My.Settings.Num = NumSettings
        My.Settings.Side = SideSettings
        My.Settings.Modi = ModSettings
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Offset As Integer
        Dim VOffset As Integer = 25
        Dim NameSettings As System.Collections.Specialized.StringCollection = My.Settings.Name
        Dim NumSettings As System.Collections.Specialized.StringCollection = My.Settings.Num
        Dim SideSettings As System.Collections.Specialized.StringCollection = My.Settings.Side
        Dim ModSettings As System.Collections.Specialized.StringCollection = My.Settings.Modi

        For Me.I = 0 To 9
            Offset = 0

            txtName(I) = New TextBox
            txtName(I).Text = NameSettings(I)
            txtName(I).Location = New Point(Offset, I * VOffset)
            txtName(I).Size = New Size(120, 25)
            Me.Controls.Add(txtName(I))
            Offset += 120

            lblNum(I) = New Label
            lblNum(I).Text = ":"
            lblNum(I).Location = New Point(Offset, I * VOffset + 3)
            lblNum(I).Size = New Size(10, 20)
            Me.Controls.Add(lblNum(I))
            Offset += 15

            txtNum(I) = New TextBox
            txtNum(I).Text = NumSettings(I)
            txtNum(I).Location = New Point(Offset, I * VOffset)
            txtNum(I).Size = New Size(20, 25)
            Me.Controls.Add(txtNum(I))
            Offset += 20

            lblSide(I) = New Label
            lblSide(I).Text = "D"
            lblSide(I).Location = New Point(Offset, I * VOffset + 3)
            lblSide(I).Size = New Size(10, 20)
            Me.Controls.Add(lblSide(I))
            Offset += 15

            txtSide(I) = New TextBox
            txtSide(I).Text = SideSettings(I)
            txtSide(I).Location = New Point(Offset, I * VOffset)
            txtSide(I).Size = New Size(20, 25)
            Me.Controls.Add(txtSide(I))
            Offset += 20

            lblMod(I) = New Label
            lblMod(I).Text = "+/-"
            lblMod(I).Location = New Point(Offset, I * VOffset + 3)
            lblMod(I).Size = New Size(25, 20)
            Me.Controls.Add(lblMod(I))
            Offset += 25

            txtMod(I) = New TextBox
            txtMod(I).Text = ModSettings(I)
            txtMod(I).Location = New Point(Offset, I * VOffset)
            txtMod(I).Size = New Size(20, 25)
            Me.Controls.Add(txtMod(I))
            Offset += 25

            cmdRoll(I) = New Button
            cmdRoll(I).Text = "Roll"
            cmdRoll(I).Location = New Point(Offset, I * VOffset - 2)
            cmdRoll(I).Size = New Size(50, 25)
            cmdRoll(I).Tag = I
            AddHandler cmdRoll(I).Click, AddressOf Me.Roll
            Me.Controls.Add(cmdRoll(I))
            Offset += 50

            lblResult(I) = New Label
            lblResult(I).Text = "0"
            lblResult(I).Location = New Point(Offset, I * VOffset + 3)
            lblResult(I).Size = New Size(20, 20)
            Me.Controls.Add(lblResult(I))

        Next
        Me.Width = 350
        Me.Height = 300
    End Sub

    Private Sub Roll(sender As System.Object, e As System.EventArgs)
        Dim Index As Integer = sender.Tag
        lblResult(Index).Text = rnd.Next((Integer.Parse(txtNum(Index).Text)), (Integer.Parse(txtNum(Index).Text) * Integer.Parse(txtSide(Index).Text))) + Integer.Parse(txtMod(Index).Text)
    End Sub
End Class
