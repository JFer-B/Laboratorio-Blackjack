using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dealer d;
        Player p;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrueba_Click(object sender, RoutedEventArgs e)
        {
            d = new Dealer();
            p = new Player();
            p.PlayerReady();
            txtPrueba.Text = "";
          
            d.Generate();
            d.Randomize();

            int count = 1;
            foreach (Card c in d.Deck)
            {
                
                if(count == 13)
                {
                    txtPrueba.Text += c.Symbol + c.Suit + "\n";
                    count = 1;
                }
                else
                {
                    txtPrueba.Text += c.Symbol + c.Suit + " ";
                    count++;
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Card card = d.Deal();
            d.AddCard(card);
            txtDealerHand.Text = "";
            foreach (Card c in d.Hand)
            {
                txtDealerHand.Text += c.Symbol + c.Suit + " ";
            }
            int count = 1;
            txtPrueba.Text = "";
            foreach (Card c in d.Deck)
            {

                if (count == 13)
                {
                    txtPrueba.Text += c.Symbol + c.Suit + "\n";
                    count = 1;
                }
                else
                {
                    txtPrueba.Text += c.Symbol + c.Suit + " ";
                    count++;
                }

            }
        }

        private void Init_Click(object sender, RoutedEventArgs e)
        {
            d.Init();
            txtDealerHand.Text = "";
            foreach (Card c in d.Hand)
            {
                txtDealerHand.Text += c.Symbol + c.Suit + " ";
            }
            int count = 1;
            txtPrueba.Text = "";
            foreach (Card c in d.Deck)
            {

                if (count == 13)
                {
                    txtPrueba.Text += c.Symbol + c.Suit + "\n";
                    count = 1;
                }
                else
                {
                    txtPrueba.Text += c.Symbol + c.Suit + " ";
                    count++;
                }

            }
        }

        private void btnDP_Click(object sender, RoutedEventArgs e)
        {
            Card card = d.Deal();
            p.AddCard(card);
            txtPlayer.Text = "";
            foreach (Card c in p.Hand)
            {
                txtPlayer.Text += c.Symbol + c.Suit + " ";
            }
            int count = 1;
            txtPrueba.Text = "";
            foreach (Card c in d.Deck)
            {

                if (count == 13)
                {
                    txtPrueba.Text += c.Symbol + c.Suit + "\n";
                    count = 1;
                }
                else
                {
                    txtPrueba.Text += c.Symbol + c.Suit + " ";
                    count++;
                }

            }
        }

        private void btnInitP_Click(object sender, RoutedEventArgs e)
        {
            p.Init(d.Deal(),d.Deal());
            txtPlayer.Text = "";
            foreach (Card c in p.Hand)
            {
                txtPlayer.Text += c.Symbol + c.Suit + " ";
            }
            int count = 1;
            txtPrueba.Text = "";
            foreach (Card c in d.Deck)
            {

                if (count == 13)
                {
                    txtPrueba.Text += c.Symbol + c.Suit + "\n";
                    count = 1;
                }
                else
                {
                    txtPrueba.Text += c.Symbol + c.Suit + " ";
                    count++;
                }

            }
        }
    }
}
