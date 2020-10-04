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
            lbPlayerScore.Content += PlayerScore.ToString();
            d = new Dealer();
            p = new Player();
            p.PlayerReady();

            d.Generate();
            d.Randomize();

            Card FirstPlayerCard = d.Deal();
            Card SecondPlayerCard = d.Deal();
            p.Init(FirstPlayerCard, SecondPlayerCard);
            lbPCard1.Background = Brushes.White;
            if (FirstPlayerCard.Color == "red")
            {
                lbPCard1.Foreground = Brushes.Red;
            }
            lbPCard1.Content = FirstPlayerCard.Symbol + FirstPlayerCard.Suit;
            lbPCard2.Background = Brushes.White;
            if (SecondPlayerCard.Color == "red")
            {
                lbPCard2.Foreground = Brushes.Red;
            }
            lbPCard2.Content = SecondPlayerCard.Symbol + SecondPlayerCard.Suit;
            PlayerScore = PlayerScore + FirstPlayerCard.Score + SecondPlayerCard.Score;
            lbPlayerScore.Content = "Total = " + PlayerScore.ToString();

            Card FirstDealerCard = d.Deal();
            DealerScore = DealerScore + FirstDealerCard.Score;
            lbDCard1.Background = Brushes.White;
            if (FirstDealerCard.Color == "red")
            {
                lbDCard1.Foreground = Brushes.Red;
            }
            lbDCard1.Content = FirstDealerCard.Symbol + FirstDealerCard.Suit;

            if (PlayerScore == 21)
            {
                lbMatchResults.Foreground = Brushes.Yellow;
                lbMatchResults.Content = "You Win!";
            }
            btnHit.Visibility = System.Windows.Visibility.Visible;
            btnStand.Visibility = System.Windows.Visibility.Visible;

        }

        int PlayeCardCount = 3;
        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            Card card = d.Deal();
            p.AddCard(card);

            switch (PlayeCardCount)
            {
                case 3:
                    lbPCard3.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard3.Foreground = Brushes.Red;
                    }
                    lbPCard3.Content = card.Symbol + card.Suit;
                    break;
                case 4:
                    lbPCard4.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard4.Foreground = Brushes.Red;
                    }
                    lbPCard4.Content = card.Symbol + card.Suit;
                    break;
                case 5:
                    lbPCard5.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard5.Foreground = Brushes.Red;
                    }
                    lbPCard5.Content = card.Symbol + card.Suit;
                    break;
                case 6:
                    lbPCard6.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard6.Foreground = Brushes.Red;
                    }
                    lbPCard6.Content = card.Symbol + card.Suit;
                    break;
                case 7:
                    lbPCard7.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard7.Foreground = Brushes.Red;
                    }
                    lbPCard7.Content = card.Symbol + card.Suit;
                    break;
                case 8:
                    lbPCard8.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard8.Foreground = Brushes.Red;
                    }
                    lbPCard8.Content = card.Symbol + card.Suit;
                    break;
                case 9:
                    lbPCard9.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard9.Foreground = Brushes.Red;
                    }
                    lbPCard9.Content = card.Symbol + card.Suit;
                    break;
                case 10:
                    lbPCard10.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard10.Foreground = Brushes.Red;
                    }
                    lbPCard10.Content = card.Symbol + card.Suit;
                    break;
                case 11:
                    lbPCard11.Background = Brushes.White;
                    if (card.Color == "red")
                    {
                        lbPCard11.Foreground = Brushes.Red;
                    }
                    lbPCard11.Content = card.Symbol + card.Suit;
                    break;
            }
            PlayeCardCount++;
            PlayerScore = PlayerScore + card.Score;
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
            if(PlayerScore > 17)
            {
                if(PlayerScore > DealerScore)
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
                MessageBox.Show("Your Score has to be higher than 17");
            }
        }
    }
}
