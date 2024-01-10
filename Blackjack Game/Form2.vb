Imports System.Data.OleDb
Imports System.IO
Imports System.Data
Imports System.Diagnostics.Eventing.Reader

Public Class Form2

    Public myConnectionString As String = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=" & Application.StartupPath & "\VegasDB1.accdb"

    Public MyDataSet As DataSet

    Public MyDataAdapter As OleDbDataAdapter

    Dim CurrentRow As Integer = 0
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim aNewRow As DataRow = MyDataSet.Tables("DB").NewRow

        aNewRow.BeginEdit()

        aNewRow("uname") = txtnewusername.Text
        aNewRow("pass") = txtnewpass.Text

        aNewRow.EndEdit()

        MyDataSet.Tables(0).Rows.Add(aNewRow)

        txtnewpass.Clear()
        txtnewusername.Clear()



        MsgBox("New user Success!", vbInformation)



    End Sub
    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Dim MyCommandBuilder As New OleDbCommandBuilder(MyDataAdapter)

        MyDataAdapter.InsertCommand = MyCommandBuilder.GetInsertCommand()
        MyDataAdapter.UpdateCommand = MyCommandBuilder.GetUpdateCommand()


        Dim UpdateCount As Integer = MyDataAdapter.Update(MyDataSet, "DB")

        Form1.Show()

        Me.Hide()




    End Sub

    Public Sub getDataSet()

        Dim mySQL As String = "SELECT * FROM DB"


        MyDataSet = New DataSet()

        MyDataAdapter = New OleDbDataAdapter(mySQL, myConnectionString)


        MyDataAdapter.Fill(MyDataSet, "DB")
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getDataSet()


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class