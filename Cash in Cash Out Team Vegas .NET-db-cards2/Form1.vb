
Imports System.Data.OleDb

Public Class Form1

    Private Sub btnReturningUser_Click(sender As Object, e As EventArgs) Handles btnReturningUser.Click
        Dim Login As New Login()
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click

        Form2.Show()
        Me.Hide()




    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub
End Class
