using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Animation;

namespace BlackJack
{
    public class Dealer
    {
        private List<Card> deck;

        public List<Card> Deck { get => deck; set => deck = value; }

        public void Generate()
        {
            deck = new List<Card>();
            char[] suits = { '♥', '♦', '♣', '♠' };
            string[] symbols = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (char suit in suits)
            {
                foreach (string symbol in symbols)
                {
                    deck.Add(new Card(suit, symbol));
                }
            }
        }
    }
}
