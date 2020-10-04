using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Animation;

namespace BlackJack
{
    public class Dealer
    {
        private List<Card> deck;
        private List<Card> hand;

        public List<Card> Deck { get => deck; set => deck = value; }
        public List<Card> Hand { get => hand; set => hand = value; }

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

        public void Randomize()
        {
            List<Card> OrderDeck = deck;
            deck = new List<Card>();

            Random num = new Random();
            while (OrderDeck.Count > 0)
            {
                int val = num.Next(0, OrderDeck.Count - 1);
                deck.Add(OrderDeck[val]);
                OrderDeck.RemoveAt(val);
            }
        }
    }
}
