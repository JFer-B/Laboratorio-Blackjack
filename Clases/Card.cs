using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Card
    {
        private char suit;
        private string symbol;
        private int score;
        private string color;

        public char Suit { get => suit; set => suit = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public int Score { get => score; set => score = value; }
        public string Color { get => color; set => color = value; }

        public Card(char suit, string symbol)
        {
            this.suit = suit;
            this.symbol = symbol;

            if(suit == '♣' || suit == '♠')
            {
                this.color = "black";
            }
            else
            {
                this.color = "red";
            }

            int value;

            try
            {
                value = Convert.ToInt32(symbol);
            } catch(FormatException fe)
            {
                if(symbol == "A")
                {
                    value = 1;
                }
                else
                {
                    value = 10;
                }
            }

            this.score = value;
        }
    }
}
