using System;
using System.Linq;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Player
    {
        public string name;
        public List<object> hand;

        public Player(string Iname, Deck IDeck)
        {
            name = Iname;
            hand = IDeck.Deal();
        }
        public List<object> Draw(int num, Deck IDeck)
        {
            for(int i = 0; i < IDeck.cards.Count; i++)
            {
                if(i == num)
                {
                    break;
                }
                else
                {
                    var first = IDeck.cards.First();
                    hand.Add(first);
                    IDeck.cards.Remove(first.Key);
                }
            }
            return hand;
        }
        public object Discard(params int[] idx)
        {
           foreach(int i in idx)
           {
               if(idx.Contains(i))
               {
                   hand.Remove(hand.ElementAt(i));
                return hand.ElementAt(i);
               }
               else
               {
                   return null;
               }   
           }
           return hand;
        }
    }
}