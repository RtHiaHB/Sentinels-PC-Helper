Public Class Talent
    Private myName As String
    Private myDie As String

    Public Sub New()
        myName = ""
        myDie = ""
    End Sub
    Public Sub New(blurb As String)
        Dim openparenpos As Integer
        Dim closeparenpos As Integer
        openparenpos = blurb.IndexOf("(")
        closeparenpos = blurb.IndexOf(")")
        myName = Left(blurb, openparenpos - 1)
        myDie = Mid(blurb, openparenpos + 2, closeparenpos - openparenpos - 1)

    End Sub

    Public Property Name As String
        Get
            Return myName
        End Get
        Set(value As String)
            myName = value
        End Set
    End Property
    Public Property Die As String
        Get
            Return myDie
        End Get
        Set(value As String)
            myDie = value
        End Set
    End Property
    Public ReadOnly Property DieIndex As Integer
        Get
            Return GetDieIndexFromStr(myDie)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return myName + " (" + myDie + ")"
    End Function
End Class
