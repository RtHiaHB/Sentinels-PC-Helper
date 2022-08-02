Imports System.IO
Imports System.Text
Public Class Form1
    Private HoldCurrentHealth As Boolean = False
    Private PowerDieRadioGroup As List(Of RadioButton)
    Private QualityDieRadioGroup As List(Of RadioButton)
    Private ConditionDieRadioGroup As List(Of RadioButton)
    Private PowerDieValue As Integer
    Private ConditionDieValue As Integer
    Private QualityDieValue As Integer
    Private PowersList As List(Of Talent)
    Private QualitiesList As List(Of Talent)
    Public Enum ConditionEnum
        GREEN
        YELLOW
        RED
    End Enum
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        PowerDieRadioGroup = New List(Of RadioButton)
        QualityDieRadioGroup = New List(Of RadioButton)
        ConditionDieRadioGroup = New List(Of RadioButton)
        PowerDieRadioGroup.Add(PowerD4)
        PowerDieRadioGroup.Add(PowerD6)
        PowerDieRadioGroup.Add(PowerD8)
        PowerDieRadioGroup.Add(PowerD10)
        PowerDieRadioGroup.Add(PowerD12)
        QualityDieRadioGroup.Add(QualityD4)
        QualityDieRadioGroup.Add(QualityD6)
        QualityDieRadioGroup.Add(QualityD8)
        QualityDieRadioGroup.Add(QualityD10)
        QualityDieRadioGroup.Add(QualityD12)
        ConditionDieRadioGroup.Add(ConditionD4)
        ConditionDieRadioGroup.Add(ConditionD6)
        ConditionDieRadioGroup.Add(ConditionD8)
        ConditionDieRadioGroup.Add(ConditionD10)
        ConditionDieRadioGroup.Add(ConditionD12)
        CurrentHealth.Text = GreenHealthMax.Text
        PowersList = New List(Of Talent)
        QualitiesList = New List(Of Talent)
    End Sub

    Public Function RollDice(d1 As Integer, d2 As Integer, d3 As Integer) As List(Of Integer)
        Dim results As New List(Of Integer)
        Dim die As New Random
        results.Add(die.Next(1, d1 + 1))
        results.Add(die.Next(1, d2 + 1))
        results.Add(die.Next(1, d3 + 1))
        results.Sort()
        Return results

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ConditionDieValue = GetDieValue(ConditionDieRadioGroup)
        PowerDieValue = GetDieValue(PowerDieRadioGroup)
        QualityDieValue = GetDieValue(QualityDieRadioGroup)
        Dim res As List(Of Integer)
        res = RollDice(PowerDieValue, QualityDieValue, ConditionDieValue)
        MinResult.Text = res(0).ToString()
        MidResult.Text = res(1).ToString()
        MaxResult.Text = res(2).ToString()
    End Sub

    Private Function GetDieValue(buttons As List(Of RadioButton)) As Integer
        If buttons.Count() <> 5 Then Err.Raise(1024 + 35, "GetDieValue", "Not the proper number of die possibilities counted")
        Dim rv As Integer
        If buttons(0).Checked = True Then rv = 4
        If buttons(1).Checked = True Then rv = 6
        If buttons(2).Checked = True Then rv = 8
        If buttons(3).Checked = True Then rv = 10
        If buttons(4).Checked = True Then rv = 12
        Return rv
    End Function

    Private Sub TakeDmgBtn_Click(sender As Object, e As EventArgs) Handles TakeDmgBtn.Click
        If YellowHealthMax.Text = "" Or RedHealthMax.Text = "" Or GreenHealthMax.Text = "" Then
            Dim reply As MsgBoxResult
            reply = MsgBox("You have to complete your damage categories (Red, Yellow, Green) before you can do this", vbOKOnly)
            Exit Sub
        End If
        Dim dtstr As String = InputBox("Damage Taken:")
        If dtstr = "" Then Exit Sub
        Dim dtint As Integer = CInt(dtstr)
        Dim DamageTaken As Integer
        'DamageTaken = dtint - IIf(dtint < 0, 0, DefenseUpDown.Value)
        'If (DamageTaken < 0 And dtint > 0) Then DamageTaken = 0
        DamageTaken = IIf(dtint < 0, dtint, IIf(dtint < DefenseUpDown.Value, 0, dtint - DefenseUpDown.Value))
        If dtint > 0 Then DefenseUpDown.Value = 0
        Dim CurrHealth As Integer = CurrentHealth.Text
        CurrentHealth.Text = (CurrHealth - DamageTaken).ToString()

    End Sub

    Private Sub CurrentHealth_TextChanged(sender As Object, e As EventArgs) Handles CurrentHealth.TextChanged
        Dim ch As Integer
        Dim iYellowMax As Integer
        Dim iRedMax As Integer
        Dim iGreenMax As Integer
        Dim ghmult As Integer
        Dim yhmult As Integer
        Dim rhmult As Integer
        If YellowHealthMax.Text = "" Or RedHealthMax.Text = "" Or GreenHealthMax.Text = "" Then Exit Sub

        iGreenMax = CInt(GreenHealthMax.Text)
        iYellowMax = CInt(YellowHealthMax.Text)
        iRedMax = CInt(RedHealthMax.Text)
        If CInt(IIf(CurrentHealth.Text = "", "0", CurrentHealth.Text)) > iGreenMax Then CurrentHealth.Text = iGreenMax.ToString()
        ghmult = CInt(Math.Round(333 / (iGreenMax - iYellowMax)))
        yhmult = CInt(Math.Round(333 / (iYellowMax - iRedMax)))
        rhmult = CInt(Math.Round(333 / iRedMax))
        Dim hbv As Integer = HealthBar.Value

        'Debug.Print("HealthBar Before: " + hbv.ToString())
        'MsgBox("HealthBar Before = " + hbv.ToString())
        If CurrentHealth.Text <> "" Then
            ch = CInt(CurrentHealth.Text)
        Else
            ch = 0
        End If
        If ch >= iGreenMax Then
            HealthBar.Value = HealthBar.Maximum
        ElseIf ch < iGreenMax And ch > iYellowMax Then
            HealthBar.Value = 999 - ((iGreenMax - ch) * ghmult)
        ElseIf ch <= iYellowMax And ch > iRedMax Then
            HealthBar.Value = 666 - ((iYellowMax - ch) * yhmult)

        ElseIf ch > 0 And ch <= iRedMax Then
            HealthBar.Value = 333 - ((iRedMax - ch) * rhmult)
        Else
            HealthBar.Value = 0
            CurrentHealth.Text = "0"
        End If
        hbv = HealthBar.Value
        'Debug.Print("HealthBar after = " + hbv.ToString())
        'MsgBox("HealthBar after = " + hbv.ToString())
        UpdateCondition()
        'Debug.Print("HealthBar After = " + HealthBar.Value.ToString())
        'MsgBox(HealthBar.Value.ToString())
    End Sub

    Private Sub AddBoostsHinders_Click(sender As Object, e As EventArgs) Handles AddBoostsHinders.Click
        Dim dw As New Boosts_Selector With {
            .Owner = Me
        }

        dw.ShowDialog()
        Dim b As Integer
        Dim bonstr As String
        If dw.DialogResult = DialogResult.Cancel Then
            dw = Nothing
            Exit Sub
        End If
        b = dw.BoostHinderLvl.Value
        bonstr = b.ToString("+0;-0;+0") + IIf(dw.PersistentChk.Checked, " (Persistent)", "")
        BoostsHindersList.Items.Add(bonstr)
        dw.Hide()
        dw = Nothing
    End Sub

    Private Sub UseBoostsHinders_Click(sender As Object, e As EventArgs) Handles UseBoostsHinders.Click
        If BoostsHindersList.SelectedItems.Count = 0 Then
            MsgBox("You need to select a bonus first!", vbOKOnly, "Nothing Selected")
            Exit Sub
        End If
        Dim col = BoostsHindersList.SelectedIndices
        Dim i As Integer
        For i = col.Count - 1 To 0 Step -1
            If InStr(BoostsHindersList.Items(i).ToString(), "(Persistent)") = 0 Then
                BoostsHindersList.Items.RemoveAt(col(i))
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim col = BoostsHindersList.Items
        Dim i As Integer
        For i = col.Count - 1 To 0 Step -1
            BoostsHindersList.Items.RemoveAt(i)

        Next
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim filename As String = ""
        OpenSEN.RestoreDirectory = True
        If OpenSEN.ShowDialog() = DialogResult.OK Then
            filename = OpenSEN.FileName
        End If
        If filename <> "" Then
            Dim buffer As String
            Dim rs As New StreamReader(filename)
            Dim value As String
            'read character's name
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            CharacterName.Text = value
            'read power die
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            SelectDieFromStr(value, PowerDieRadioGroup)
            'read Quality die
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            SelectDieFromStr(value, QualityDieRadioGroup)
            'read condition die
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            SelectDieFromStr(value, ConditionDieRadioGroup)
            'Environment Condition
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            EnvironmentCondition.Value = Convert.ToInt32(value)
            'Green Health Max
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            GreenHealthMax.Text = value
            'green health die
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            GreenHealthDice.Text = value
            'yellow health max
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            YellowHealthMax.Text = value
            'Yellow Health Die
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            YellowHealthDice.Text = value
            'Red health max
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            RedHealthMax.Text = value
            'Red health die
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            RedHealthDice.Text = value
            'Health Bar position
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            HealthBar.Value = Convert.ToInt32(value)
            'Current Health
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            CurrentHealth.Text = value
            'HeroPt1
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            DefenseUpDown.Value = CInt(value)
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            HPChk1.Checked = (value = "True")
            'HeroPt2
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            HPChk2.Checked = (value = "True")
            'HeroPt3
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            HPChk3.Checked = (value = "True")
            'HeroPt4
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            HPChk4.Checked = (value = "True")
            'HeroPt5
            buffer = rs.ReadLine()
            value = buffer.Substring(InStr(buffer, "="))
            HPChk5.Checked = (value = "True")
            If BoostsHindersList.Items.Count > 0 Then
                Dim col = BoostsHindersList.Items
                Dim i As Integer
                For i = col.Count - 1 To 0 Step -1
                    BoostsHindersList.Items.RemoveAt(i)
                Next
            End If
            If Not rs.EndOfStream Then
                buffer = rs.ReadLine()
                Do While buffer <> "Boosts/Hinders End"
                    If buffer <> "Boosts/Hinders Begin" And buffer <> "" Then BoostsHindersList.Items.Add(buffer)
                    buffer = rs.ReadLine()
                Loop
            End If
            If Not rs.EndOfStream Then
                buffer = rs.ReadLine()

                If buffer = "Powers Begin" Then
                    Do While buffer <> "Powers End"
                        If buffer <> "Powers Begin" Then
                            PowersCmb.Items.Add(buffer)
                            Dim p As New Talent(buffer)
                            PowersList.Add(p)

                        End If
                        buffer = rs.ReadLine
                    Loop
                End If
            End If
            If Not rs.EndOfStream Then
                buffer = rs.ReadLine()
                If buffer = "Qualities Begin" Then
                    Do While buffer <> "Qualities End"
                        If buffer <> "Qualities Begin" Then
                            QualitiesCmb.Items.Add(buffer)
                            Dim q As New Talent(buffer)
                            QualitiesList.Add(q)
                        End If
                        buffer = rs.ReadLine
                    Loop
                End If
            End If
            rs.Close()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim filename As String = ""
        SaveSEN.RestoreDirectory = True
        If SaveSEN.ShowDialog() = DialogResult.OK Then
            filename = SaveSEN.FileName
        End If
        If filename <> "" Then
            If File.Exists(filename) Then
                File.Delete(filename)
            End If
            Dim fs As FileStream = File.Create(filename)
            AddText(fs, "Name=" + CharacterName.Text + Environment.NewLine)
            AddText(fs, "Power die=d" + GetDieValue(PowerDieRadioGroup).ToString() + Environment.NewLine)
            AddText(fs, "Quality die=d" + GetDieValue(QualityDieRadioGroup).ToString() + Environment.NewLine)
            AddText(fs, "Condition die=d" + GetDieValue(ConditionDieRadioGroup).ToString() + Environment.NewLine)
            AddText(fs, "Environment Condition=" + EnvironmentCondition.Value.ToString() + Environment.NewLine)
            AddText(fs, "Green Health Max=" + GreenHealthMax.Text.ToString() + Environment.NewLine)
            AddText(fs, "Green Health Die=" + GreenHealthDice.Text.ToString() + Environment.NewLine)
            AddText(fs, "Yellow Health Max=" + YellowHealthMax.Text + Environment.NewLine)
            AddText(fs, "Yellow Health Die=" + YellowHealthDice.Text + Environment.NewLine)
            AddText(fs, "Red Health Max=" + RedHealthMax.Text + Environment.NewLine)
            AddText(fs, "Red Health Die=" + RedHealthDice.Text + Environment.NewLine)
            AddText(fs, "Health Bar Position=" + HealthBar.Value.ToString() + Environment.NewLine)
            AddText(fs, "Current Health=" + CurrentHealth.Text + Environment.NewLine)
            AddText(fs, "Defense=" + DefenseUpDown.Value.ToString() + Environment.NewLine)
            AddText(fs, "HeroPt 1=" + HPChk1.Checked.ToString() + Environment.NewLine)
            AddText(fs, "HeroPt 2=" + HPChk2.Checked.ToString() + Environment.NewLine)
            AddText(fs, "HeroPt 3=" + HPChk3.Checked.ToString() + Environment.NewLine)
            AddText(fs, "HeroPt 4=" + HPChk4.Checked.ToString() + Environment.NewLine)
            AddText(fs, "HeroPt 5=" + HPChk5.Checked.ToString() + Environment.NewLine)
            Dim i As Integer
            AddText(fs, "Boosts/Hinders Begin" + Environment.NewLine)
            If BoostsHindersList.Items.Count > 0 Then

                For i = 0 To BoostsHindersList.Items.Count - 1 Step 1
                    AddText(fs, BoostsHindersList.Items(i).ToString() + Environment.NewLine)

                Next

            End If
            AddText(fs, "Boosts/Hinders End" + Environment.NewLine)
            AddText(fs, "Powers Begin" + Environment.NewLine)
            If PowersList.Count > 0 Then
                For i = 0 To PowersList.Count - 1 Step 1
                    AddText(fs, PowersList(i).ToString() + Environment.NewLine)
                Next
            End If
            AddText(fs, "Powers End" + Environment.NewLine)
            AddText(fs, "Qualities Begin" + Environment.NewLine)
            If QualitiesList.Count > 0 Then
                For i = 0 To QualitiesList.Count - 1 Step 1
                    AddText(fs, QualitiesList(i).ToString() + Environment.NewLine)
                Next

            End If
            AddText(fs, "Qualities End" + Environment.NewLine)
            fs.Close()
        End If
    End Sub
    Private Shared Sub AddText(ByVal fs As FileStream, ByVal Value As String)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(Value)
        fs.Write(info, 0, info.Length)
    End Sub
    Private Sub SelectDieFromStr(DieCodeStr As String, RadioButtonList As List(Of RadioButton))
        'If DieCodeStr = "d4" Then RadioButtonList(0).Checked = True
        'If DieCodeStr = "d6" Then RadioButtonList(1).Checked = True
        'If DieCodeStr = "d8" Then RadioButtonList(2).Checked = True
        'If DieCodeStr = "d10" Then RadioButtonList(3).Checked = True
        'If DieCodeStr = "d12" Then RadioButtonList(4).Checked = True
        RadioButtonList(GetDieIndexFromStr(DieCodeStr)).Checked = True
    End Sub

    Private Sub RollPowerDieBtn_Click(sender As Object, e As EventArgs) Handles RollPowerDieBtn.Click
        ClearResults()
        MinResult.Text = RollDie(GetDieValue(PowerDieRadioGroup)).ToString()

    End Sub

    Private Function RollDie(iSize As Integer) As Integer
        Dim die As New Random
        Randomize()
        Return die.Next(1, iSize + 1)
    End Function

    Private Sub ClearResults()
        MinResult.Text = ""
        MidResult.Text = ""
        MaxResult.Text = ""
    End Sub

    Private Sub RollQualityDieBtn_Click(sender As Object, e As EventArgs) Handles RollQualityDieBtn.Click
        ClearResults()
        MinResult.Text = RollDie(GetDieValue(QualityDieRadioGroup)).ToString()
    End Sub

    Private Sub RollConditionDieBtn_Click(sender As Object, e As EventArgs) Handles RollConditionDieBtn.Click
        ClearResults()
        MinResult.Text = RollDie(GetDieValue(ConditionDieRadioGroup)).ToString()
    End Sub

    Private Sub EnvironmentCondition_Scroll(sender As Object, e As EventArgs) Handles EnvironmentCondition.Scroll
        UpdateCondition()
    End Sub

    Private Sub UpdateCondition()

        Select Case CurrentCondition()
            Case ConditionEnum.GREEN
                ConditionDieRadioGroup(GetDieIndexFromStr(GreenHealthDice.Text)).Checked = True
            Case ConditionEnum.YELLOW
                ConditionDieRadioGroup(GetDieIndexFromStr(YellowHealthDice.Text)).Checked = True
            Case ConditionEnum.RED
                ConditionDieRadioGroup(GetDieIndexFromStr(RedHealthDice.Text)).Checked = True
        End Select
    End Sub



    Public Function CurrentCondition() As ConditionEnum
        'this is returning red when it should be returning yellow
        If (EnvironmentCondition.Value = 0 Or HealthBar.Value <= 333) Then
            Return ConditionEnum.RED
        End If
        If EnvironmentCondition.Value = 1 Or (HealthBar.Value <= 666 And HealthBar.Value > 333) Then
            Return ConditionEnum.YELLOW
        End If
        'If EnvironmentCondition.Value = 0 Or HealthBar.Value <= 333 Then
        Return ConditionEnum.GREEN
        'End If

    End Function

    Public Function ConditionDefense() As Integer
        Select Case CurrentCondition()
            Case ConditionEnum.GREEN
                Return IIf(GreenDefenseTxt.Text = "", 0, CInt(GreenDefenseTxt.Text))
            Case ConditionEnum.YELLOW
                Return IIf(YellowDefenseTxt.Text = "", 0, CInt(YellowDefenseTxt.Text))
            Case ConditionEnum.RED
                Return IIf(RedDefenseTxt.Text = "", 0, CInt(RedDefenseTxt.Text))

        End Select
        Return 0
    End Function

    Private Sub AddPowerBtn_Click(sender As Object, e As EventArgs) Handles AddPowerBtn.Click
        AddTalent(PowersList, PowersCmb)
    End Sub

    Private Function CreateTalent() As Talent
        Dim nt As NewTalent = New NewTalent()
        Dim dr As DialogResult
        dr = nt.ShowDialog()
        If dr = DialogResult.OK Then
            Dim tal As Talent = New Talent() With {
            .Name = nt.TalentName.Text,
            .Die = nt.TalentDie.Text}
            Return tal
        Else
            Return Nothing
        End If

    End Function

    Private Sub PowersCmb_TextChanged(sender As Object, e As EventArgs) Handles PowersCmb.TextChanged
        SelectDieFromStr(PowersList(PowersCmb.SelectedIndex).Die, PowerDieRadioGroup)
        Dim iDieIndex As Integer = PowersList(PowersCmb.SelectedIndex).DieIndex
        PowerDieRadioGroup(iDieIndex).Checked = True
    End Sub

    Public Sub AddTalent(TalentList As List(Of Talent), TalCmb As ComboBox)
        Dim tal As Talent = CreateTalent()
        If Not tal Is Nothing Then
            TalentList.Add(tal)
            TalCmb.Items.Add(tal.ToString())
        End If
    End Sub

    Private Sub AddQualBtn_Click(sender As Object, e As EventArgs) Handles AddQualBtn.Click
        AddTalent(QualitiesList, QualitiesCmb)
    End Sub

    Private Sub QualitiesCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QualitiesCmb.SelectedIndexChanged
        Dim iDieIndex As Integer = QualitiesList(QualitiesCmb.SelectedIndex).DieIndex
        QualityDieRadioGroup(iDieIndex).Checked = True
    End Sub

    Private Sub CharacterName_TextChanged(sender As Object, e As EventArgs) Handles CharacterName.TextChanged
        Me.Text = CharacterName.Text + " - Sentinels RPG PC Helper"
    End Sub
End Class
