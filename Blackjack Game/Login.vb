Imports System.Data.Common
Imports System.Data.OleDb
Imports System.IO


Public Class Login

    Public myConnectionString As String = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=" & Application.StartupPath & "\VegasDB1.accdb"
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtUsername.Clear()
        txtPassword.Clear()
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click, btnLogin.Click
        Dim myConnection As New OleDbConnection(myConnectionString)
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim myQuery As String = "SELECT * FROM [DB] WHERE uname= @Username AND pass= @Password"

        Dim myCommand As New OleDbCommand
        myCommand.CommandText = myQuery
        myCommand.Connection = myConnection
        myCommand.Parameters.AddWithValue("@Username", username)
        myCommand.Parameters.AddWithValue("@Password", password)
        Dim myDataReader As OleDbDataReader = Nothing


        myConnection.Open()
        myDataReader = myCommand.ExecuteReader

        If myDataReader.HasRows Then
            Blackjack.Show()
            Me.Close()
            Exit Sub
        Else
            txtUsername.Clear()
            txtPassword.Clear()
            myDataReader.Close()
            Exit Sub
        End If




        myConnection.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class