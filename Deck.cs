using System.Collections.Generic;
namespace BattleCards
{
    public class PlayerDeck
    {
        public List<Card> Deck = new List<Card>();
        public List<Card> AuxDeck = new List<Card>();
        public List<Card> Hand = new List<Card>();

        public int DeckSize;
        public int HandSize;
        public int XCard;

        void Start()
        {
            DeckSize = 40;
            HandSize = 5;
            XCard = 0;
            for (var i = 0; i < CardDataBase.CardList.Count ; i++)
            {
                Random rnd = new Random();
                XCard = rnd.Next(0, CardDataBase.CardList.Count);
                Deck.Add(CardDataBase.CardList[XCard]);
                
            }
        }

        public void Stuffle()
        {
            
            for (var i = 0; i < Deck.Count; i++)
            {
                Random rnd = new Random();
                AuxDeck[0] = Deck[i];
                int RandomIndex = rnd.Next(0, Deck.Count);
                Deck[i] = Deck[RandomIndex];
                Deck[RandomIndex] = AuxDeck[0];

                
            }
            Deck = AuxDeck;

        }
       

        public void DrawCard()
        {
            if (Deck.Count > 0)
            {
                Hand.Add(Deck[0]);
                Deck.RemoveAt(0);
            }
        }

        

        
       

    }
}