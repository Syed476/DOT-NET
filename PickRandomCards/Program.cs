using System;
namespace PickRandomCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter no of cards to pick: ");
            string? line = Console.ReadLine();
            if (int.TryParse(line, out int noOfCards))
            {
                string[] cards = CardPicker.PickSomeCards(noOfCards);
                foreach (string card in cards)
                {
                    Console.WriteLine(card);
                }
            }
            else
            {
                Console.WriteLine("Invalid no entered!");
            }
        }
    }
}