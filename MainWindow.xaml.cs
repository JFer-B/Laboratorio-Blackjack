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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrueba_Click(object sender, RoutedEventArgs e)
        {
            Dealer d = new Dealer();

            d.Generate();

            foreach (Card c in d.Deck)
            {
                txtPrueba.Text += c.Symbol + c.Suit + " ";
                if(c.Symbol == "K")
                {
                    txtPrueba.Text += c.Symbol + c.Suit + "\n";
                }
            }
        }
    }
}
