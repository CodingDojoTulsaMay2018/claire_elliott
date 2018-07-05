using System;
using System.Linq;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Deck
    {
        public Dictionary<string,int> cards;
        public Card inst;

        public Deck()
        {
            inst = new Card();
            cards = new Dictionary<string, int>();
            int count = 0;
            while(count < 4)
            {
                for(int i = 0; i < inst.val.Length; i++)
                {
                    cards.Add(inst.stringVal[i] + " of " + inst.suit[count], inst.val[i]);
                }
                count++;
            }
            Random rand = new Random();
            cards = cards.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);
        }
        public Dictionary<string,int> Shuffle()
        {
            Random rand = new Random();
            cards = cards.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);
            return cards;
        }
        public List<object> Deal()
        {
            List<object> hand = new List<object>();
            for(int i = 0; i < cards.Count; i++)
            {
                if(i == 5)
                {
                    break;
                }
                else
                {
                    var first = cards.First();
                    hand.Add(first);
                    cards.Remove(first.Key);
                }
            }
            return hand;
        }
        public Dictionary<string,int> Reset()
        {
            cards = new Dictionary<string, int>();
            int count = 0;
            while(count < 4)
            {
                for(int i = 0; i < inst.val.Length; i++)
                {
                    cards.Add(inst.stringVal[i] + " of " + inst.suit[count], inst.val[i]);
                }
                count++;
            }
            Random rand = new Random();
            cards = cards.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);
            return cards;
        }
    }
}
