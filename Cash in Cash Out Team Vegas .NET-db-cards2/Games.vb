Public Class Games
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnRoulette.Click

    End Sub

    Private Sub btnBlackJack_Click(sender As Object, e As EventArgs) Handles btnBlackJack.Click
        Dim Blackjack As New Blackjack()
        Blackjack.Show()
        Me.Hide()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub
End Class