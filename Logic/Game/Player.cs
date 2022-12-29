using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace BattleCards
{
    public class Player : IPlayer
    {
        public int DeckSize = 30;
        public int HandSize = 5;
        public Player(string name)
        {
            Deck = new List<Card>();
            Hand = new List<Card>();

            GetDeck();
            Name = name;
            RaundsWon = 0;
            TotalRounds = RaundsWon + "/5";
            PlayerM = new List<Card>(5);
            Graveyard = new List<Card>();
            PassRound = false;
            PlayerIsaBot = false;
            
        }
        public void Point(List<Card> PlayerM)
        {
            int point=0;
            for (var i = 0; i < PlayerM.Count; i++)
            {
                point += PlayerM[i].Power;
            }
            TotalPoint = point;
        }
        public void ResetPoint()
        {
            TotalPoint = 0;
        }
        public void Update()
        {
            TotalRounds = RaundsWon + "/5";
        }
        public void GetDeck()
        {
            var CardDB = CardDataBase.CardList.ToList();
            int XCard = 0;
            Random rnd = new Random();
            for (var i = 0; i < DeckSize; i++)
            {
                XCard = rnd.Next(0, CardDB.Count);
                Deck.Add(CardDB[XCard]);
                CardDB.RemoveAt(XCard);
            }
        }

        
    }
}
