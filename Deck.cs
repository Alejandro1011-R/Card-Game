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
            Random rnd = new Random();
            for (var i = 0; i < DeckSize ; i++)
            {
               
                XCard = rnd.Next(0, CardDataBase.CardList.Count);
                Deck.Add(CardDataBase.CardList[XCard]);
                CardDataBase.CardList.RemoveAt(XCard);
                
            }
        }

        public void Stuffle()
        {
            Random rnd = new Random();
            for (var i = 0; i < Deck.Count; i++)
            {
                
                AuxDeck[0] = Deck[i];
                int RandomIndex = rnd.Next(0, Deck.Count);
                Deck[i] = Deck[RandomIndex];
                Deck[RandomIndex] = AuxDeck[0];

                
            }
        

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