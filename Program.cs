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
            cards = ShuffleIn();
        }

         // Getters and Setters
        public List<Card> Cards{get;set;}

        // Methods
        public List<Card> ShuffleIn()
        {
            List<Card> shuffledCards = new List<Card>();

            Random r = new Random();
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
                    shuffledCards.Insert(r.Next(0, shuffledCards.Count), card);
                }
            }

            Cards = shuffledCards;
            return shuffledCards;
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
            foreach(var card in deck.Cards)
            {
                System.Console.WriteLine($"{card.Suit} : {card.StringVal}");
            }
        }
    }
}
