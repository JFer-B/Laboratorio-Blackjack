using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Table
    {
        private List<Card> hand;
        public List<Card> Hand { get => hand; set => hand = value; }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }
    }
}
