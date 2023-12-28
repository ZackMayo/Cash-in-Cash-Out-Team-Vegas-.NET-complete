Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics.Eventing.Reader
Imports System.Runtime.InteropServices

Public Class Blackjack
    Dim myConnectionString As String = "Provider=Microsoft.ACE.OleDb.12.0;Data Sourc=" & Application.StartupPath & "\TeamVegas.accdb"

    Public MyDataSet As DataSet

    Dim MyDataApdapter As OleDbDataAdapter
    Dim CurrentRow As Integer = 0

    Dim betamount As Integer

    Dim balance As Integer = 1000
    Public Class Card
        Public Property Name As String
        Public Property ImagePath As String
        Public Value As Integer

        Public Sub New(Name As String, ImagePath As String, Value As Integer)
            Me.Name = Name
            Me.ImagePath = ImagePath
            Me.Value = Value
        End Sub
    End Class

    Public cardDeck As List(Of Card)


    Private Sub GetDataSet()
        Dim mySQL As String = "SELECT * FROM Login"

        MyDataSet = New DataSet()

        MyDataApdapter = New OleDbDataAdapter(mySQL, myConnectionString)

        MyDataApdapter.Fill(MyDataSet, "Login")

    End Sub

    Private Sub ShowRecord(ByVal index As Integer)
        Dim CurrentDataRow As DataRow = MyDataSet.Tables("Login").Rows(index)

    End Sub

    Dim playerHand As Integer
    Dim dealerHand As Integer
    Dim playerCard1 As Card
    Dim playerCard2 As Card
    Dim dealercard1 As Card
    Dim dealercard2 As Card
    Dim newcard As Card
    Dim newcard2 As Card
    Dim newcard3 As Card
    Dim newDCard As Card
    Dim newDCard2 As Card
    Dim newDCard3 As Card

    Dim winnings As Integer
    Private rand As New Random
    Private Sub btnDeal_Click(sender As Object, e As EventArgs) Handles btnDeal.Click

        playerCard1 = cardDeck(rand.Next(cardDeck.Count))
        playerCard2 = cardDeck(rand.Next(cardDeck.Count))
        dealercard1 = cardDeck(rand.Next(cardDeck.Count))
        dealercard2 = cardDeck(rand.Next(cardDeck.Count))

        PictureBox2.Image = Image.FromFile(playerCard1.ImagePath)
        PictureBox2.Width = 100
        PictureBox2.Height = 145

        PictureBox1.Image = Image.FromFile(playerCard2.ImagePath)
        PictureBox1.Width = 100
        PictureBox1.Height = 145

        PictureBox6.Image = Image.FromFile(dealercard1.ImagePath)
        PictureBox6.Width = 100
        PictureBox6.Height = 145
        PictureBox6.Hide()

        PictureBox7.Image = Image.FromFile(dealercard2.ImagePath)
        PictureBox7.Width = 100
        PictureBox7.Height = 145


        playerHand = playerCard1.Value + playerCard2.Value
        txtPlayer.Text = playerHand

        dealerHand = dealercard1.Value + dealercard2.Value
        txtDealer.Text = dealerHand
        txtDealer.Hide()


        btnDeal.Enabled = False
        btnHit.Enabled = True
        btnStand.Enabled = True
        BtnReset.Enabled = False

        If txtPlayer.Text = "21" Then
            MessageBox.Show("Player Wins!", "Blackjack")
            btnHit.Enabled = False
            btnStand.Enabled = False
            BtnReset.Enabled = True
            winnings = betamount + betamount * 1.25
            txtBalance.Text = txtBalance.Text + winnings
        End If

        If txtDealer.Text = "21" Then
            MessageBox.Show("Dealer Wins!", "Dealer has blackjack")
            btnHit.Enabled = False
            btnStand.Enabled = False
            BtnReset.Enabled = True
            txtBalance.Text = txtBalance.Text
        End If
    End Sub

    Private Sub btnHit_Click(sender As Object, e As EventArgs) Handles btnHit.Click
        Dim Hitoption As DialogResult
        Hitoption = MessageBox.Show("Would you like to hit?", "Hit?", MessageBoxButtons.YesNo)
        If Hitoption = DialogResult.Yes Then
            newcard = cardDeck(rand.Next(cardDeck.Count))
            PictureBox3.Image = Image.FromFile(newcard.ImagePath)
            PictureBox3.Width = 100
            PictureBox3.Height = 145
            playerHand = playerHand + newcard.Value
            txtPlayer.Text = playerHand
            checkAces()

            If txtPlayer.Text > 21 Then
                MessageBox.Show("Bust." & vbCrLf & "Dealer Wins!", "Bust")
                btnHit.Enabled = False
                btnStand.Enabled = False
                BtnReset.Enabled = True
                txtBalance.Text = txtBalance.Text
                Exit Sub
            End If
            Dim hitAgain As DialogResult
            hitAgain = MessageBox.Show("Would you like to hit again?", "Continue", MessageBoxButtons.YesNo)
            If hitAgain = DialogResult.Yes Then
                newcard2 = cardDeck(rand.Next(cardDeck.Count))
                PictureBox4.Image = Image.FromFile(newcard2.ImagePath)
                PictureBox4.Width = 100
                PictureBox4.Height = 145
                playerHand = playerHand + newcard2.Value
                txtPlayer.Text = playerHand
                checkAces()
            End If
            If hitAgain = DialogResult.No Then
                btnHit.Enabled = False
                btnStand.Enabled = True
                Exit Sub

            End If
            If txtPlayer.Text > 21 Then
                MessageBox.Show("Bust." & vbCrLf & "Dealer Wins!", "Bust")
                btnHit.Enabled = False
                btnStand.Enabled = False
                BtnReset.Enabled = True
                txtBalance.Text = txtBalance.Text
                Exit Sub
            End If
            Dim hitAgain2 As DialogResult
            hitAgain2 = MessageBox.Show("Would you like to hit again?", "Continue", MessageBoxButtons.YesNo)
            If hitAgain2 = DialogResult.Yes Then
                newcard3 = cardDeck(rand.Next(cardDeck.Count))
                PictureBox5.Image = Image.FromFile(newcard3.ImagePath)
                PictureBox5.Width = 100
                PictureBox5.Height = 145
                playerHand = playerHand + newcard3.Value
                txtPlayer.Text = playerHand
                checkAces()
            End If
            If hitAgain2 = DialogResult.No Then
                MessageBox.Show("Turn Over", "Turn Over")
                btnHit.Enabled = False
                btnStand.Enabled = True
                Exit Sub
            End If
            If txtPlayer.Text > 21 Then
                MessageBox.Show("Bust." & vbCrLf & "Dealer Wins!", "Bust")
                btnHit.Enabled = False
                btnStand.Enabled = False
                BtnReset.Enabled = True
                txtBalance.Text = txtBalance.Text
                Exit Sub
            End If

        End If

        If Hitoption = DialogResult.No Then
            MessageBox.Show("Turn Over", "Turn Over")
            btnHit.Enabled = False
            btnStand.Enabled = True
        End If
    End Sub

    Private Sub btnStand_Click(sender As Object, e As EventArgs) Handles btnStand.Click

        PictureBox6.Show()
        txtDealer.Show()

        If txtDealer.Text < 17 Then
            newDCard = cardDeck(rand.Next(cardDeck.Count))
            PictureBox8.Image = Image.FromFile(newDCard.ImagePath)
            PictureBox8.Width = 100
            PictureBox8.Height = 145
            dealerHand = dealerHand + newDCard.Value
            txtDealer.Text = dealerHand
            checkDealerAces()
            If txtDealer.Text < 17 Then
                newDCard2 = cardDeck(rand.Next(cardDeck.Count))
                PictureBox9.Image = Image.FromFile(newDCard2.ImagePath)
                PictureBox9.Width = 100
                PictureBox9.Height = 145
                dealerHand = dealerHand + newDCard2.Value
                txtDealer.Text = dealerHand
                checkDealerAces()
            End If
            If txtDealer.Text < 17 Then
                newDCard3 = cardDeck(rand.Next(cardDeck.Count))
                PictureBox10.Image = Image.FromFile(newDCard3.ImagePath)
                PictureBox10.Width = 100
                PictureBox10.Height = 145
                dealerHand = dealerHand + newDCard3.Value
                txtDealer.Text = dealerHand
                checkDealerAces()
            End If
        End If


        If txtPlayer.Text > txtDealer.Text Then
            MessageBox.Show("Player Wins!", "Winner")
            winnings = betamount + betamount
            txtBalance.Text = winnings + txtBalance.Text
        ElseIf txtPlayer.Text = txtDealer.Text Then
            MessageBox.Show("Push!", "Push")
            txtBalance.Text = betamount + txtBalance.Text
        ElseIf txtDealer.Text > 21 Then
            MessageBox.Show("Dealer Busts!" & vbCr & "Player Wins!", "Dealer Busts")
            winnings = betamount + betamount
            txtBalance.Text = txtBalance.Text + winnings
        Else
            MessageBox.Show("Dealer Wins!", "Loss")
        End If
        btnHit.Enabled = False
        btnStand.Enabled = False
        BtnReset.Enabled = True


    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        txtDealer.Text = ""
        txtPlayer.Text = ""

        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing
        PictureBox7.Image = Nothing
        PictureBox8.Image = Nothing
        PictureBox9.Image = Nothing
        PictureBox10.Image = Nothing

        btnDeal.Enabled = True
        btnHit.Enabled = False
        btnStand.Enabled = False
        btnBet.Enabled = True

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If txtBalance.Text > 0 Then
            MsgBox("You cashed out with $" & txtBalance.Text & ". Congrats!")
        Else
            MsgBox("Try again next time.")
        End If

        Me.Close()
    End Sub

    Private Sub btnBet_Click(sender As Object, e As EventArgs) Handles btnBet.Click
        If txtBalance.Text = 0 Then
            Dim continueGame As DialogResult
            continueGame = MsgBox("You have no more money, do you want to continue with 1000 more?", vbYesNo)
            If continueGame = DialogResult.Yes Then
                InitializeBalance()
            ElseIf continueGame = DialogResult.No Then
                MsgBox("Better luck next time.")
                Me.Close()
                Exit Sub
            End If
        End If
        Try
            betamount = CInt(InputBox("Please enter a bet amount", "Place Bet", 0))
            If betamount > balance Then
                MsgBox("Insufficient funds")
            End If
        Catch ex As Exception
            MsgBox("Please enter a valid number")
        End Try

        txtBalance.Text = balance - betamount
        btnBet.Enabled = False


    End Sub

    Public Sub InitalizeDeck()
        cardDeck = New List(Of Card)()
        cardDeck.Add(New Card("2 of clubs", Application.StartupPath & "\Cards\2_of_clubs.png", 2))
        cardDeck.Add(New Card("2 of diamonds", "Cards/2_of_diamonds.png", 2))
        cardDeck.Add(New Card("2 of hearts", "Cards/2_of_hearts.png", 2))
        cardDeck.Add(New Card("2 of spades", "Cards/2_of_spades.png", 2))
        cardDeck.Add(New Card("3 of clubs", "Cards/3_of_clubs.png", 3))
        cardDeck.Add(New Card("3 of diamonds", "Cards/3_of_diamonds.png", 3))
        cardDeck.Add(New Card("3 of hearts", "Cards/3_of_hearts.png", 3))
        cardDeck.Add(New Card("3 of spades", "Cards/3_of_spades.png", 3))
        cardDeck.Add(New Card("4 of clubs", "Cards/4_of_clubs.png", 4))
        cardDeck.Add(New Card("4 of diamonds", "Cards/4_of_diamonds.png", 4))
        cardDeck.Add(New Card("4 of hearts", "Cards/4_of_hearts.png", 4))
        cardDeck.Add(New Card("4 of spades", "Cards/4_of_hearts.png", 4))
        cardDeck.Add(New Card("5 of clubs", "Cards/5_of_clubs.png", 5))
        cardDeck.Add(New Card("5 of diamonds", "Cards/5_of_diamonds.png", 5))
        cardDeck.Add(New Card("5 of hearts", "Cards/5_of_hearts.png", 5))
        cardDeck.Add(New Card("5 of spades", "Cards/5_of_spades.png", 5))
        cardDeck.Add(New Card("6 of clubs", "Cards/6_of_clubs.png", 6))
        cardDeck.Add(New Card("6 of diamonds", "Cards/6_of_diamonds.png", 6))
        cardDeck.Add(New Card("6 of hearts", "Cards/6_of_hearts.png", 6))
        cardDeck.Add(New Card("6 of spades", "Cards/6_of_spades.png", 6))
        cardDeck.Add(New Card("7 of clubs", "Cards/7_of_clubs.png", 7))
        cardDeck.Add(New Card("7 of diamonds", "Cards/7_of_diamonds.png", 7))
        cardDeck.Add(New Card("7 of hearts", "Cards/7_of_hearts.png", 7))
        cardDeck.Add(New Card("7 of spades", "Cards/7_of_spades.png", 7))
        cardDeck.Add(New Card("8 of clubs", "Cards/8_of_clubs.png", 8))
        cardDeck.Add(New Card("8 of diamonds", "Cards/8_of_diamonds.png", 8))
        cardDeck.Add(New Card("8 of hearts", "Cards/8_of_hearts.png", 8))
        cardDeck.Add(New Card("8 of spades", "Cards/8_of_spades.png", 8))
        cardDeck.Add(New Card("9 of clubs", "Cards/9_of_clubs.png", 9))
        cardDeck.Add(New Card("9 of diamonds", "Cards/9_of_diamonds.png", 9))
        cardDeck.Add(New Card("9 of hearts", "Cards/9_of_hearts.png", 9))
        cardDeck.Add(New Card("9 of spades", "Cards/9_of_spades.png", 9))
        cardDeck.Add(New Card("10 of clubs", "Cards/10_of_clubs.png", 10))
        cardDeck.Add(New Card("10 of diamonds", "Cards/10_of_diamonds.png", 10))
        cardDeck.Add(New Card("10 of hearts", "Cards/10_of_hearts.png", 10))
        cardDeck.Add(New Card("10 of spades", "Cards/10_of_spades.png", 10))
        cardDeck.Add(New Card("Jack of clubs", "Cards/jack_of_clubs.png", 10))
        cardDeck.Add(New Card("Jack of hearts", "Cards/jack_of_hearts.png", 10))
        cardDeck.Add(New Card("Jack of diamonds", "Cards/jack_of_diamonds.png", 10))
        cardDeck.Add(New Card("Jack of spades", "Cards/jack_of_spades.png", 10))
        cardDeck.Add(New Card("Queen of clubs", "Cards/queen_of_clubs.png", 10))
        cardDeck.Add(New Card("Queen of diamonds", "Cards/queen_of_diamonds.png", 10))
        cardDeck.Add(New Card("Queen of hearts", "Cards/queen_of_hearts.png", 10))
        cardDeck.Add(New Card("Queen of spades", "Cards/queen_of_spades.png", 10))
        cardDeck.Add(New Card("King of clubs", "Cards/king_of_clubs.png", 10))
        cardDeck.Add(New Card("King of diamonds", "Cards/king_of_diamonds.png", 10))
        cardDeck.Add(New Card("King of hearts", "Cards/king_of_hearts.png", 10))
        cardDeck.Add(New Card("King of spades", "Cards/king_of_spades.png", 10))
        cardDeck.Add(New Card("Ace of clubs", "Cards/ace_of_clubs.png", 11))
        cardDeck.Add(New Card("Ace of diamonds", "Cards/ace_of_diamonds.png", 11))
        cardDeck.Add(New Card("Ace of hearts", "Cards/ace_of_hearts.png", 11))
        cardDeck.Add(New Card("Ace of spades", "Cards/ace_of_spades.png", 11))
    End Sub

    Private Sub Blackjack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitalizeDeck()
        Me.WindowState = FormWindowState.Maximized
        btnHit.Enabled = False
        BtnReset.Enabled = False
        btnStand.Enabled = False
        InitializeBalance()



    End Sub

    Private Sub checkAces()
        If playerHand > 21 And (newcard.Value = 11 Or playerCard1.Value = 11 Or playerCard2.Value = 11) Then
            newcard.Value = 1
            playerCard1.Value = 1
            playerCard2.Value = 1
            playerHand = playerHand - 10
            txtPlayer.Text = playerHand
        End If

    End Sub
    Private Sub checkDealerAces()
        If dealercard1.Value = 11 Or dealercard2.Value = 11 Or newDCard.Value = 11 And dealerHand > 21 Then
            dealercard1.Value = 1
            dealercard2.Value = 1
            newDCard.Value = 1
            dealerHand = dealerHand - 10
            txtDealer.Text = dealerHand
        End If
    End Sub
    Public Sub InitializeBalance()
        txtBalance.Text = 1000
    End Sub

End Class