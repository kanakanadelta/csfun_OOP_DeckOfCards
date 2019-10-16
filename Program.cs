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

        public Card Deal()
        {
            int topIdx = Cards.Count-1;
            Card toDeal = Cards[topIdx];
            Cards.RemoveAt(topIdx);
            return toDeal;

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

        public List<Card> Reset()
        {
            List<Card> resetCards = MakeDeck();
            Cards = resetCards;
            Shuffle();
            return Cards;
        }
    }

    class Player
    {
        private string name;
        private List<Card> hand;

        public Player(string name){
            Name = name;
            Hand = new List<Card>();
        }

        //GETTERS AND SETTERS
        public string Name{get;set;}
        public List<Card> Hand{get;set;}

        //METHODS
        public Card Draw(Deck deck)
        {
            Card CardDrawn = deck.Deal();
            Hand.Add(CardDrawn);
            Console.WriteLine($"{Name} draws {CardDrawn.StringVal} of {CardDrawn.Suit}");
            return CardDrawn;
        }

        public Card Discard(int idx)
        {
            if(idx > Hand.Count-1)
            {
                return null;
            }
            else
            {
                Card toRemove = Hand[idx];
                Hand.RemoveAt(idx);
                System.Console.WriteLine($"{Name} discards {toRemove.StringVal} of {toRemove.Suit}");
                return toRemove;
            }
        }

    }
    //////////////
    // PROGRAM //
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deck of Cards!");
            Deck deck = new Deck();
            Player p1 = new Player("Player 1");
            Player p2 = new Player("Player 2");
            deck.Shuffle();
            // foreach(var card in deck.Cards)
            //     System.Console.WriteLine($"{card.Suit} : {card.StringVal}");

            System.Console.WriteLine($"{deck.Cards[deck.Cards.Count-1].StringVal} of {deck.Cards[deck.Cards.Count-1].Suit}");
            p1.Draw(deck);
            p2.Draw(deck);
            p1.Draw(deck);
            p2.Draw(deck);
            p1.Draw(deck);
            p2.Draw(deck);
            p1.Discard(0);
            p2.Discard(5);

            System.Console.WriteLine($"Current deck is at {deck.Cards.Count}");


        }
    }
}
