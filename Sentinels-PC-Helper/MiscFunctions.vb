Module MiscFunctions
    Public Function GetDieIndexFromStr(DieCode As String) As Integer
        Select Case DieCode
            Case "d4"
                Return 0
            Case "d6"
                Return 1
            Case "d8"
                Return 2
            Case "d10"
                Return 3
            Case "d12"
                Return 4
            Case Else
                Return 0
        End Select
    End Function
    'Public Function GetTalentFromString(strNewTalent As String) As Talent

    'End Function
End Module
