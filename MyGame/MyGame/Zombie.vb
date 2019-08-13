﻿Public Class Zombie
    Inherits Enemy
    Sub New()
        strName = "Zombie"
        Attacks(0) = "Eat Brains"
        Attacks(1) = "Claw"
        Attacks(2) = "Throw Up"
        AttackDamage(0) = 10
        AttackDamage(1) = 5
        AttackDamage(2) = 2
    End Sub

    Public Overrides Sub Attack(ByRef userHealth As Integer)
        Dim gen As New Random
        attackNum = gen.Next(0, 3)
        Select Case attackNum
            Case 0
                userHealth -= 15
            Case 1
                userHealth -= 5
            Case 2
                userHealth -= 2
        End Select
    End Sub
End Class
