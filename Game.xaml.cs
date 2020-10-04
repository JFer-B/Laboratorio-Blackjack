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
            btnHit.Visibility = System.Windows.Visibility.Collapsed;
            btnStand.Visibility = System.Windows.Visibility.Collapsed;
        }
        Dealer d;
        Player p;
        int PlayerScore;
        int DealerScore;
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = System.Windows.Visibility.Collapsed;

            PlayerScore = 0;
            DealerScore = 0;
            d = new Dealer();
            p = new Player();
            p.PlayerReady();

            d.Generate();
            d.Randomize();

            Card FirstPlayerCard = d.Deal();
            Card SecondPlayerCard = d.Deal();
            p.Init(FirstPlayerCard, SecondPlayerCard);
            lbPlayerCards.Content = lbPlayerCards.Content + FirstPlayerCard.Symbol + FirstPlayerCard.Suit + "   " + SecondPlayerCard.Symbol + SecondPlayerCard.Suit;
            PlayerScore = PlayerScore + FirstPlayerCard.Score + SecondPlayerCard.Score;
            lbPlayerScore.Content = "Total = " + PlayerScore.ToString();

            Card FirstDealerCard = d.Deal();
            lbDealerCards.Content = lbDealerCards.Content + FirstDealerCard.Symbol + FirstDealerCard.Suit;
            DealerScore = DealerScore + FirstDealerCard.Score;
            lbDealerScore.Content = "Total = " + DealerScore.ToString();

            if (PlayerScore == 21)
            {
                lbMatchResults.Foreground = Brushes.Yellow;
                lbMatchResults.Content = "You Win!";
            }
            btnHit.Visibility = System.Windows.Visibility.Visible;
            btnStand.Visibility = System.Windows.Visibility.Visible;

        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            Card card = d.Deal();
            p.AddCard(card);

            lbPlayerCards.Content = lbPlayerCards.Content + "   " + card.Symbol + card.Suit;
            PlayerScore = PlayerScore + card.Score;
            lbPlayerScore.Content = "Total = " + PlayerScore.ToString();

            if (PlayerScore > 21 && card.Score == 11)
            {
                PlayerScore = PlayerScore - 10;
            }
            if (PlayerScore > 21)
            {
                lbMatchResults.Foreground = Brushes.Red;
                lbMatchResults.Content = "You Lose!";
                btnHit.Visibility = System.Windows.Visibility.Collapsed;
                btnStand.Visibility = System.Windows.Visibility.Collapsed;
            }
            lbPlayerScore.Content = "Total = " + PlayerScore.ToString();
        }

        private void btnStand_Click(object sender, RoutedEventArgs e)
        {
            if(PlayerScore > 16)
            {
                while (DealerScore < 17)
                {
                    Card card = d.Deal();
                    lbDealerCards.Content = lbDealerCards.Content + "   " + card.Symbol + card.Suit;
                    DealerScore = DealerScore + card.Score;
                    if (DealerScore > 21 && card.Score == 11)
                    {
                        DealerScore = DealerScore - 10;
                    }
                }
                lbDealerScore.Content = "Total = " + DealerScore.ToString();
                if(PlayerScore > DealerScore || DealerScore > 21)
                {
                    lbMatchResults.Foreground = Brushes.Yellow;
                    lbMatchResults.Content = "You Win!";
                    
                } else
                {
                    lbMatchResults.Foreground = Brushes.Red;
                    lbMatchResults.Content = "You Lose!";
                }
                btnHit.Visibility = System.Windows.Visibility.Collapsed;
                btnStand.Visibility = System.Windows.Visibility.Collapsed;
            } else
            {
                MessageBox.Show("Your Score has to be higher than 16");
            }
        }
    }
}
