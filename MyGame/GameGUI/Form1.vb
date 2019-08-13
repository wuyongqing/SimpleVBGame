Imports MyGame

Public Class Form1
    Private currentEnemy As Enemy
    Private logShown As Boolean = True
    Private Hero As New Popeye
    Private intSpinach As Integer = 3
    Private newLog As New EventLog
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenerateEnemy()
    End Sub

    Private Sub GenerateEnemy()
        Dim generator As New Random
        Dim enemyType As Integer = generator.Next(1, 4)
        Select Case enemyType
            Case 1
                If Not PictureBox2.Image.Equals(My.Resources.zombie) Then
                    currentEnemy = New MyGame.Zombie
                    ProgressBar2.Value = Enemy.StartHealth
                    PictureBox2.Image = My.Resources.zombie
                Else
                    GenerateEnemy()
                End If
            Case 2
                If Not PictureBox2.Image.Equals(My.Resources.dragon) Then
                    currentEnemy = New MyGame.Dragon
                    ProgressBar2.Value = Enemy.StartHealth
                    PictureBox2.Image = My.Resources.dragon
                Else
                    GenerateEnemy()
                End If
            Case 3
                If Not PictureBox2.Image.Equals(My.Resources.vampire) Then
                    currentEnemy = New MyGame.villain
                    ProgressBar2.Value = Enemy.StartHealth
                    PictureBox2.Image = My.Resources.vampire
                Else
                    GenerateEnemy()
                End If
        End Select
        UpdateEnemyHealth()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newLog.Show()
        newLog.Location = New Point(Me.Location.X, Me.Location.Y + 345)
        Timer1.Stop()
        UpdatePopHealth()
        GenerateEnemy()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        If intSpinach = 0 Then
            RadioButton1.Enabled = False
        ElseIf RadioButton1.Checked = True And intSpinach > 0 Then
            Hero.hasSpinach = True
            intSpinach -= 1
            Label1.Text = "spinach left: " & intSpinach.ToString
        End If
        Hero.Attack(currentEnemy.Health)
        newLog.AddEvent(CreateEvent(Popeye.Name))
        Hero.hasSpinach = False
        Try
            UpdateEnemyHealth()
        Catch ex As Exception
            ProgressBar2.Value = 0
            MessageBox.Show("Popeye has won!")
            newLog.AddEvent("---------------------------------------------------------------")
            newLog.AddEvent("Popeye has won!")
            GenerateEnemy()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        EnemyAttack()
    End Sub
    Private Sub EnemyAttack()
        Timer1.Stop()
        If currentEnemy.Health >= 0 Then
            currentEnemy.Attack(Hero.Health)
            newLog.AddEvent(CreateEvent(currentEnemy.strName))
        End If
        Try
            UpdatePopHealth()
        Catch ex As Exception
            ProgressBar1.Value = 0
            MessageBox.Show("Popeye has lost!")
            newLog.AddEvent("---------------------------------------------------------------")
            newLog.AddEvent("Popeye has lost!")
            Hero.Health = Hero.StartHealth
            UpdatePopHealth()
        End Try
    End Sub

    Private Sub UpdateEnemyHealth()
        ProgressBar2.Value = currentEnemy.Health
        Label3.Text = "Health: " & currentEnemy.Health.ToString
    End Sub
    Private Sub UpdatePopHealth()
        If Hero.Health = 0 Then
            Throw New Exception
        End If
        ProgressBar1.Value = Hero.Health
        Label2.Text = "Health: " + Hero.Health.ToString
    End Sub
    Private Function CreateEvent(ByVal strName As String)
        If strName = Popeye.Name Then
            Dim useSpinach As String = Nothing
            Dim damage As Integer = Hero.AttackDamage(Hero.attackNum)
            If Hero.hasSpinach Then
                damage = Hero.AttackDamage(Hero.attackNum) * 2
                useSpinach = "with using spinach"
            End If
            Return strName + " has used [" + Hero.Attacks(Hero.attackNum).ToString + "] for [" + damage.ToString + "] damage " + useSpinach
        Else
            Return strName + " has used [" + currentEnemy.Attacks(currentEnemy.attackNum).ToString + "] for [" + currentEnemy.AttackDamage(Hero.attackNum).ToString + "] damage"
        End If
    End Function

    Private Sub Form1_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        newLog.Location = New Point(Me.Location.X, Me.Location.Y + 345)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If logShown Then
            newLog.Hide()
            Button3.Text = "Show log"
            logShown = Not logShown
        Else
            newLog.Show()
            Button3.Text = "Hide log"
            logShown = Not logShown
        End If
    End Sub
End Class
