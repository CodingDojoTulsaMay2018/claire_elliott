using System.Collections.Generic;
namespace DeckOfCards
{
    public class Card 
    {
        public List<string> stringVal;
        public string[] suit;
        public int[] val;

        public Card()
        {
            stringVal = new List<string> {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            suit = new string[] {"Clubs", "Spades", "Hearts", "Diamonds"};
            val = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        }
    }

}