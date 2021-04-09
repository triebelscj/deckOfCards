using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Card card = new Card();
            Deck deck = new Deck();
            Player cj = new Player("cj");
            Player zoe = new Player("zoe");
            cj.draw(deck);
            cj.draw(deck);
            cj.draw(deck);
            cj.draw(deck);
            cj.draw(deck);
            cj.draw(deck);
            cj.draw(deck);
            cj.draw(deck);
            zoe.draw(deck);
            zoe.draw(deck);

            Console.WriteLine($"Cj holding {cj.Hand[0].suit} of {cj.Hand[0].stringVal}");
            Console.WriteLine($"Zoe is holding {zoe.Hand[0].suit} of {zoe.Hand[0].stringVal}");

            Console.WriteLine($"zoe is holding {zoe.Hand[1].suit} of {zoe.Hand[1].stringVal}");

            Console.WriteLine(cj.Hand.Count);
            Console.WriteLine($"Cj holding {cj.Hand[0].suit} of {cj.Hand[0].stringVal}");
        }

        class Card
        {
            //Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a string.
            public string stringVal; // should this be StringVal {get; set;}????
            //Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds).
            public string suit;
            //Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers.
            public int val;
            public Card(string name, string suitType, int value)
            {
                stringVal = name;
                suit = suitType;
                val = value;
            }
        }

        class Deck
        {
            // Give the Deck class a property called "cards" which is a list of Card objects.
            public List<Card> cards;
            // When initializing the deck, make sure that it has a list of 52 unique cards as its "cards" property.
            public Deck()
            {
                reset();
                shuffle();
                deal();
                // Console.WriteLine($" AFTER REMOVING FIRST CARD: {cards[0].stringVal} {cards[0].suit}");
                // Console.WriteLine($" SHUFFLED?: {cards[1].stringVal} {cards[1].suit}");
            }

            // Give the Deck a reset method that resets the cards property to contain the original 52 cards.
            public Deck reset()
            {
                cards = new List<Card>();

                string[] suits = { "Clubs", "Spades", "Hearts", "Diamonds" };
                string[] stringVals = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

                for (int i = 0; i < suits.Length; i++)
                {
                    for (int j = 0; j < stringVals.Length; j++)
                    {
                        Card newDeck = new Card(suits[i], stringVals[j], i + j);
                        cards.Add(newDeck);
                        // Console.WriteLine($"{suits[i]}, {stringVals[j]}");
                    }
                }
                return this;
            }
            // Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card.


            public Card deal()
            {
                if (cards.Count > 0)
                {
                    Card topMost = cards[0];
                    cards.RemoveAt(0);
                    return topMost;
                }
                else
                {
                    Console.WriteLine("No cards left!!");
                    return null;
                }
            }
            // Give the Deck a shuffle method that randomly reorders the deck's cards.
            public List<Card> shuffle() 
            {
                Random rand = new Random();
                int n = cards.Count;
                while (n > 1)
                {
                    n--;
                    int i = rand.Next(n);
                    Card shuffleCard = cards[i];
                    cards[i] = cards[n];
                    cards[n] = shuffleCard;
                }
                return cards;
            }
        }

        class Player
        {
            // Give the Player class a name property.
            public string Name { get; set; }
            // Give the Player a hand property that is a List of type Card.
            public List<Card> Hand { get; set; }

            public Player(string eachPlayer)
            {
                Name = eachPlayer;
                Hand = new List<Card>();
            }

            public bool IsFull // Conditional - each player can only draw 5 cards
            {
                get
                {
                    if (Hand.Count >= 5)
                    {
                        // Console.WriteLine("their hands are full");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card. Note this method will require reference to a deck object
            public Card draw(Deck cardDrawn)
            {
                if (IsFull)
                {
                    Console.WriteLine("Can't draw any more cards. Their hands card full");
                    return null;
                }
                else
                {
                    Card newCards = cardDrawn.deal();
                    Hand.Add(newCards);
                    return newCards;
                }
            }
            // Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.

            public Card discard(int index)
            {
                if (index < 0 || index > Hand.Count - 1) 
                {
                    Console.WriteLine("index doesn't exist");
                    return null;
                }
                else
                {
                    Card temp = Hand[index];
                    Hand.RemoveAt(index);
                    return temp;
                }
            }

        }

    }
}