using System;
using System.Linq;

namespace dojo.CardShuffle
{
    public class Card
    {
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public string Suit { get; set; }
        public string Rank { get; set; }
    }

    public class Deck
    {
        private static readonly Random _random = new Random();
        private readonly string[] _rank = GetRanks;
        private readonly string[] _suits = GetSuits;
        internal static string[] GetSuits => new[] {"Hart", "Club", "Spade", "Diamond"};

        internal static string[] GetRanks
            => new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

        public Card[] DeckBuilder()
        {
            var deck = new Card[52];
            for (var i = 0; i < deck.Length; i++)
            {
                deck[i] = new Card(_suits[i/13], _rank[i%13]);
            }
            return deck;
        }

        public Card[] Shuffle(Card[] deck)
        {
            var rand = _random;

            for (var i = deck.Length; i > 1; i--)
            {
                var v = rand.Next(i);
                var tmp = deck[v];

                deck[v] = deck[i - 1];
                deck[i - 1] = tmp;
            }

            return deck;
        }

        public Card[] Shuffle2(Card[] deck)
        {
            var r = new Random();

            for (var i = 0; i < deck.Length - 1; i++)
            {
                var j = r.Next(deck.Length - 1);
                var temp = deck[j];

                deck[i] = deck[j];
                deck[j] = temp;
            }

            return deck;
        }

        public bool IsDeckValid(Card[] deck)
        {
            var d = deck
                .GroupBy(x => new {x.Suit, x.Rank}).Count(g => g.Count() > 1);
            return d < 1;
        }

        public static bool AreDeckEquals(Card[] actual, Card[] expected)
        {
            if (expected.Length != actual.Length)
            {
                return false;
            }

            for (var i = 0; i < actual.Length; i++)
            {
                if (!actual[i].Rank.Equals(expected[i].Rank) && !actual[i].Suit.Equals(expected[i].Suit))
                    return false;
            }
            return true;
        }
    }
}