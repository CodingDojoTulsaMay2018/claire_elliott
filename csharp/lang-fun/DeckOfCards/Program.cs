using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            Console.WriteLine(string.Join(", ",deck.cards));
            Console.WriteLine("\n");
            Player player1 = new Player("Claire", deck);
            Player player2 = new Player("Troy", deck);
            Console.WriteLine(string.Join(", ",player1.hand));
            Console.WriteLine("\n");
            Console.WriteLine(string.Join(", ",player2.hand));
            Console.WriteLine("\n");
            Console.WriteLine(string.Join(", ",deck.cards));
            Console.WriteLine("\n");
            player2.Draw(2, deck);
            Console.WriteLine(string.Join(", ",player2.hand));
            Console.WriteLine("\n");
            player2.Discard(2,4);
            Console.WriteLine(string.Join(", ",player2.hand));
        }
    }
}
