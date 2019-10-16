using System.Linq;
using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Card 
    {
        private string stringVal;
        private string suit;
        private int val;

        //Constructor for Card
        public Card(){
        }

        public string StringVal{get;set;}
        public string Suit{get;set;}
        public int Val{get;set;}
    }

    class Deck 
    {
        private List<Card> cards;

        public Deck(){
            cards = MakeDeck();
        }

         // Getters and Setters
        public List<Card> Cards{get;set;}

        // Methods
        public List<Card> MakeDeck()
        {
            List<Card> deckMake = new List<Card>();

            string[] stringVals = new string[]{"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen", "King"};
            string[] suits = new string[]{"Clubs", "Spades", "Hearts", "Diamonds"};

            for(int suitIdx = 0; suitIdx < suits.Length; suitIdx++)
            {
                for(int cardVal = 0; cardVal < 13; cardVal++)
                {
                    Card card = new Card();
                    card.Suit = suits[suitIdx];
                    card.StringVal = stringVals[cardVal];
                    card.Val = cardVal + 1;
                    deckMake.Add(card);
                }
            }

            Cards = deckMake;
            return deckMake;
        }

        public List<Card> Shuffle()
        {
            Random r = new Random();
            for(int idx = 0; idx < Cards.Count; idx++)
            {
                Card holdCard = Cards[idx];
                int rIdx = r.Next(0, 51);
                Cards[idx] = Cards[rIdx];
                Cards[rIdx] = holdCard;
            }
            return Cards;
        }
    }

    class Player
    {

    }
    //////////////
    // PROGRAM //
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deck of Cards!");
            Deck deck = new Deck();
            deck.Shuffle();
            foreach(var card in deck.Cards)
            {
                System.Console.WriteLine($"{card.Suit} : {card.StringVal}");
            }
        }
    }
}
