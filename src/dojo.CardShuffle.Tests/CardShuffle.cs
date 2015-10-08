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
        public void Shffle_Ordered_Deck()
        {
            var deck = new Deck();
            var orderedDeck = deck.DeckBuilder();
            var shuffledDeck = deck.Shuffle(deck.DeckBuilder());

            Assert.AreEqual(true, (orderedDeck[0] != shuffledDeck[0] ||
                                   orderedDeck[1] != shuffledDeck[1] ||
                                   orderedDeck[2] != shuffledDeck[2] ||
                                   orderedDeck[3] != shuffledDeck[3] ||
                                   orderedDeck[4] != shuffledDeck[4]));
        }

        [TestMethod]
        public void Shuffle_Two_Decks_To_Insure_Decks_Are_Random()
        {
            var deck = new Deck();
            var deck1 = deck.DeckBuilder();
            var deck2 = deck.DeckBuilder();

            var shuffledDeck1 = deck.Shuffle(deck1);
            var shuffledDeck2 = deck.Shuffle(deck2);

            Assert.AreEqual(true,(shuffledDeck1[0] != shuffledDeck2[0] ||
                                  shuffledDeck1[1] != shuffledDeck2[1] ||
                                  shuffledDeck1[2] != shuffledDeck2[2] ||
                                  shuffledDeck1[3] != shuffledDeck2[3] ||
                                  shuffledDeck1[4] != shuffledDeck2[4]));
        }
    }
}