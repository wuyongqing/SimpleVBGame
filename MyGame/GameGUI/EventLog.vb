Public Class EventLog
    Private Sub EventLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListEvents.Items.Add("Event logger has successfully loaded")
        ListEvents.Items.Add("---------------------------------------------------------------")
    End Sub
    Public Sub AddEvent(ByVal strEvent As String)
        ListEvents.Items.Add(strEvent)
    End Sub

    Private Sub ListEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListEvents.SelectedIndexChanged

    End Sub

    Private Sub EventLog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub
End Class