using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Player : Table
    {
        public void PlayerReady()
        {
            Hand = new List<Card>();
        }

        public void Init(Card firstcard, Card secondcard)
        {
            AddCard(firstcard);
            AddCard(secondcard);
        }
    }
}
