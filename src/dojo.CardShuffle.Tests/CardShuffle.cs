using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dojo.CardShuffle.Tests
{
    [TestClass]
    public class CardShuffle
    {
        [TestMethod]
        public void DeckBuilder_Is_Correct_Length()
        {
            var deck = new Deck();
            var expectedLenth = 52;

            Assert.AreEqual(expectedLenth, deck.DeckBuilder().Length);
        }
        [TestMethod]
        public void IsDeckValid_Should_Return_False()
        {
            var deck = new Deck();
            var cards = new Card[4];
            cards[0] = new Card("Harts", "1");
            cards[1] = new Card("Harts", "1");
            cards[2] = new Card("Harts", "2");
            cards[3] = new Card("Harts", "9");

            Assert.IsFalse(deck.IsDeckValid(cards));
        }
        [TestMethod]
        public void Deck_Should_Be_Without_Duplicates_After_Shuffle()
        {
            var deck = new Deck();
            var shuffledDeck = deck.Shuffle(deck.DeckBuilder());

            Assert.IsTrue(deck.IsDeckValid(shuffledDeck));
        }
        [TestMethod]
        public void Shuffle_Ordered_Deck_And_Return_False_If_Deck_Are_Not_Shuffled()
        {
            var deck = new Deck();
            var orderedDeck = deck.DeckBuilder();
            var shuffledDeck = deck.Shuffle(deck.DeckBuilder());

            Assert.IsFalse(Deck.AreDeckEquals(orderedDeck, shuffledDeck));
        }

#region Duplicated tests for second shuffle method

        [TestMethod]
        public void Shuffle2_Ordered_Deck_And_Return_False_If_Deck_Are_Not_Shuffled()
        {
            var deck = new Deck();
            var orderedDeck = deck.DeckBuilder();
            var shuffledDeck = deck.Shuffle2(deck.DeckBuilder());

            Assert.IsFalse(Deck.AreDeckEquals(orderedDeck,shuffledDeck));
        }

        [TestMethod]
        public void Shuffle_Two_Decks_To_Insure_Decks_Are_Random_Should_Return_False()
        {
            var deck = new Deck();
            var shuffledDeck1 = deck.Shuffle(deck.DeckBuilder());
            var shuffledDeck2 = deck.Shuffle(deck.DeckBuilder());

            Assert.IsFalse(Deck.AreDeckEquals(shuffledDeck1,shuffledDeck2));
        }

        [TestMethod]
        public void Shuffle_Two_Decks_To_Insure_Decks_Are_Random_Should_Return_True()
        {
            var deck = new Deck();
            var shuffledDeck1 = deck.Shuffle(deck.DeckBuilder());
            var shuffledDeck2 = deck.Shuffle(deck.DeckBuilder());

            Assert.IsFalse(Deck.AreDeckEquals(shuffledDeck1, shuffledDeck2));
        }

        [TestMethod]
        public void Shuffle2_Deck_Should_Return_Two_Random_Decks_Should_Return_False()
        {
            var interval = new TimeSpan(0,0,1);
            var deck = new Deck();
            var shuffledDeck1 = deck.Shuffle2(deck.DeckBuilder());
            Thread.Sleep(interval);
            var shuffledDeck2 = deck.Shuffle2(deck.DeckBuilder());

            Assert.IsFalse(Deck.AreDeckEquals(shuffledDeck1, shuffledDeck2));
        }

        [TestMethod]
        public void Shuffle2_Deck_Should_Return_Two_Random_Decks_Should_Fail_Due_Randon_Seeding()
        {

            var deck = new Deck();
            var shuffledDeck1 = deck.Shuffle2(deck.DeckBuilder());
            var shuffledDeck2 = deck.Shuffle2(deck.DeckBuilder());
            Assert.IsFalse(Deck.AreDeckEquals(shuffledDeck1, shuffledDeck2));
        }


        [TestMethod]
        public void DecksEqual_Should_Return_True()
        {
            var deck = new Deck();
            var deck1 = deck.DeckBuilder();

            Assert.IsTrue(Deck.AreDeckEquals(deck1,deck1));
        }

        [TestMethod]
        public void DecksEqual_Should_Return_False()
        {
            var deck = new Deck();
            var deck1 = deck.DeckBuilder();
            var deck2 = deck1.Reverse().ToArray();

            Assert.IsFalse(Deck.AreDeckEquals(deck1,deck2));
        }
        [TestMethod]
        public void Check_Shffuled_Deck_For_Each_Suit()
        {
            var deck = new Deck();
            var shuffledDeck1 = deck.Shuffle2(deck.DeckBuilder());
            var shuffledDeck2 = deck.Shuffle2(deck.DeckBuilder());

            var suits = shuffledDeck2.GroupBy(s => s.Suit);

            Assert.IsNotNull(suits);

        }


#endregion
    }
}