using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Lógica de interacción para Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
            btnHit.Visibility = Visibility.Collapsed;
            btnStand.Visibility = Visibility.Collapsed;
            btnNewRound.Visibility = Visibility.Collapsed;
        }
        Dealer d;
        Player p;
        int PlayerScore;
        int DealerScore;
        int MatchesCount;
        int VictoryCount;
        int DefeatCount;
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Collapsed;
            MatchesCount = 0;
            VictoryCount = 0;
            DefeatCount = 0;
            PlayerScore = 0;
            DealerScore = 0;
            d = new Dealer();
            p = new Player();
            p.PlayerReady();

            d.Generate();
            d.Randomize();
            lbCardsCount.Content = "Cards In Deck = " + d.Deck.Count.ToString();

            Card FirstPlayerCard = d.Deal();
            Card SecondPlayerCard = d.Deal();
            p.Init(FirstPlayerCard, SecondPlayerCard);
            lbPlayerCards.Content = lbPlayerCards.Content + FirstPlayerCard.Symbol + FirstPlayerCard.Suit + "   " + SecondPlayerCard.Symbol + SecondPlayerCard.Suit;
            PlayerScore = PlayerScore + FirstPlayerCard.Score + SecondPlayerCard.Score;
            lbPlayerScore.Content = "Total = " + PlayerScore.ToString();
            lbCardsCount.Content = "Cards In Deck = " + d.Deck.Count.ToString();

            Card FirstDealerCard = d.Deal();
            d.AddCard(FirstDealerCard);
            lbDealerCards.Content = lbDealerCards.Content + FirstDealerCard.Symbol + FirstDealerCard.Suit;
            DealerScore = DealerScore + FirstDealerCard.Score;
            lbDealerScore.Content = "Total = " + DealerScore.ToString();
            lbCardsCount.Content = "Cards In Deck = " + d.Deck.Count.ToString();

            btnHit.Visibility = Visibility.Visible;
            btnStand.Visibility = Visibility.Visible;

            if (PlayerScore == 21)
            {
                lbMatchResults.Foreground = Brushes.Yellow;
                lbMatchResults.Content = "You Win!";
                MatchesCount++;
                VictoryCount++;
                lbTotalMatches.Content = "Total Matches = " + MatchesCount.ToString();
                lbVictoryCount.Content = "V = " + VictoryCount.ToString();
                btnHit.Visibility = Visibility.Collapsed;
                btnStand.Visibility = Visibility.Collapsed;
                btnNewRound.Visibility = Visibility.Visible;
            }

        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            if (p.Hand.Count < 11)
            {
                Card card = d.Deal();
                p.AddCard(card);

                lbPlayerCards.Content = lbPlayerCards.Content + "   " + card.Symbol + card.Suit;
                PlayerScore = PlayerScore + card.Score;

                if (PlayerScore > 21)
                {
                    PlayerScore = 0;
                    foreach (Card c in p.Hand)
                    {
                        if (c.Score == 11)
                        {
                            c.Score = 1;
                        }
                        PlayerScore = PlayerScore + c.Score;
                    }
                }
                if (PlayerScore > 21)
                {
                    lbMatchResults.Foreground = Brushes.Red;
                    lbMatchResults.Content = "You Lose!";
                    MatchesCount++;
                    DefeatCount++;
                    lbTotalMatches.Content = "Total Matches = " + MatchesCount.ToString();
                    lbDefeatCount.Content = "D = " + DefeatCount.ToString();
                    btnHit.Visibility = Visibility.Collapsed;
                    btnStand.Visibility = Visibility.Collapsed;
                    btnNewRound.Visibility = Visibility.Visible;
                }
                lbPlayerScore.Content = "Total = " + PlayerScore.ToString();
                lbCardsCount.Content = "Cards In Deck = " + d.Deck.Count.ToString();
            } else
            {
                MessageBox.Show("Card limit reach!" + "\n" + "Press Stand");
            }
        }

        private void btnStand_Click(object sender, RoutedEventArgs e)
        {
            if(PlayerScore > 16)
            {
                while (DealerScore < 17)
                {
                    Card card = d.Deal();
                    d.AddCard(card);
                    lbDealerCards.Content = lbDealerCards.Content + "   " + card.Symbol + card.Suit;
                    DealerScore = DealerScore + card.Score;
                    if (DealerScore > 21)
                    {
                        DealerScore = 0;
                        foreach (Card c in d.Hand)
                        {
                            if (c.Score == 11)
                            {
                                c.Score = 1;
                            }
                            DealerScore = DealerScore + c.Score;
                        }
                    }
                }
                lbDealerScore.Content = "Total = " + DealerScore.ToString();
                lbCardsCount.Content = "Cards In Deck = " + d.Deck.Count.ToString();
                if (PlayerScore > DealerScore || DealerScore > 21)
                {
                    lbMatchResults.Foreground = Brushes.Yellow;
                    lbMatchResults.Content = "You Win!";
                    MatchesCount++;
                    VictoryCount++;
                    lbTotalMatches.Content = "Total Matches = " + MatchesCount.ToString();
                    lbVictoryCount.Content = "V = " + VictoryCount.ToString();
                } else
                {
                    lbMatchResults.Foreground = Brushes.Red;
                    lbMatchResults.Content = "You Lose!";
                    MatchesCount++;
                    DefeatCount++;
                    lbTotalMatches.Content = "Total Matches = " + MatchesCount.ToString();
                    lbDefeatCount.Content = "D = " + DefeatCount.ToString();
                }
                btnHit.Visibility = Visibility.Collapsed;
                btnStand.Visibility = Visibility.Collapsed;
                btnNewRound.Visibility = Visibility.Visible;
            } else
            {
                MessageBox.Show("Your Score has to be higher than 16");
            }
        }

        private void btnNewRound_Click(object sender, RoutedEventArgs e)
        {
            btnNewRound.Visibility = Visibility.Collapsed;
            lbMatchResults.Content = "";
            d.Hand.Clear();
            p.Hand.Clear();
            lbDealerCards.Content = "";
            lbPlayerCards.Content = "";
            PlayerScore = 0;
            DealerScore = 0;

            Card FirstPlayerCard = d.Deal();
            Card SecondPlayerCard = d.Deal();
            p.Init(FirstPlayerCard, SecondPlayerCard);
            lbPlayerCards.Content = lbPlayerCards.Content + FirstPlayerCard.Symbol + FirstPlayerCard.Suit + "   " + SecondPlayerCard.Symbol + SecondPlayerCard.Suit;
            PlayerScore = PlayerScore + FirstPlayerCard.Score + SecondPlayerCard.Score;
            lbPlayerScore.Content = "Total = " + PlayerScore.ToString();
            lbCardsCount.Content = "Cards In Deck = " + d.Deck.Count.ToString();

            Card FirstDealerCard = d.Deal();
            d.AddCard(FirstDealerCard);
            lbDealerCards.Content = lbDealerCards.Content + FirstDealerCard.Symbol + FirstDealerCard.Suit;
            DealerScore = DealerScore + FirstDealerCard.Score;
            lbDealerScore.Content = "Total = " + DealerScore.ToString();
            lbCardsCount.Content = "Cards In Deck = " + d.Deck.Count.ToString();

            btnHit.Visibility = Visibility.Visible;
            btnStand.Visibility = Visibility.Visible;

            if (PlayerScore == 21)
            {
                lbMatchResults.Foreground = Brushes.Yellow;
                lbMatchResults.Content = "You Win!";
                MatchesCount++;
                VictoryCount++;
                lbTotalMatches.Content = "Total Matches = " + MatchesCount.ToString();
                lbVictoryCount.Content = "V = " + VictoryCount.ToString();
                btnHit.Visibility = Visibility.Collapsed;
                btnStand.Visibility = Visibility.Collapsed;
                btnNewRound.Visibility = Visibility.Visible;
            }
            
        }
    }
}
