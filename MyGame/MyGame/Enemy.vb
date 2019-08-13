Public Class Enemy
    Private intHealth As Integer
    Public attackNum As Integer
    Public strName As String
    Public ReadOnly AttackDamage(3) As String
    Public Shared StartHealth As Integer = 100
    Public ReadOnly Attacks(3) As String
    Sub New()
        intHealth = StartHealth
    End Sub

    Public Overridable Sub Attack(ByRef userHealth As Integer)

        Dim gen As New Random
        attackNum = gen.Next(0, 1)
        Select Case attackNum
            Case 0
                userHealth -= 1
            Case 1
                userHealth -= 2
        End Select
    End Sub

    Public Property Health() As Integer
        Get
            Return intHealth
        End Get
        Set(value As Integer)
            intHealth = value
        End Set
    End Property

End Class
