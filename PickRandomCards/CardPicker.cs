using System;

namespace PickRandomCards
{
    internal class CardPicker
    {
        public static string[] PickSomeCards(int noOfCards)
        {
            string[] pickCards = new string[noOfCards];
            for (int i = 0; i < noOfCards; i++)
            {
                pickCards[i] = RandomValue() + " of " + RandomSuit();
            }
            return pickCards;
        }

        public static string RandomValue()
        {
            int value = Random.Shared.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString();
        }

        public static string RandomSuit()
        {
            int value = Random.Shared.Next(1, 5);
            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamonds";
        }
    }
}