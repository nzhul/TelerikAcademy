// 10. In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:


using System;

class AllCardsFromDeck
{
    static void Main()
    {
        string[] ranks = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        string[] colors = {"Clubs", "Diamonds", "Hearts", "Spades" };
        foreach (var rank in ranks)
        {
            foreach (var color in colors)
            {
                Console.WriteLine(rank + " of " + color);
            }
        }
    }
}

