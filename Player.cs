using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    public class Player
    {
        private string Name;
        private int Health;
        public Player(string name)
        {
            Name = name;
            Health = 5;
            PlayerM = new List<Card>();
            PlayerR = new List<Card>();
            Cementery = new List<Card>();
            Deck = new List<Card>();
            Deck=PlayerDeck.Start();
            PlayerHand = new List<Card>();
            PlayerHand=Deck.Take(5).ToList();
            Pass = false;
        }
                public List<Card> Stuffle(List<Card> Deck)
        {
            Random rnd = new Random();
            for (var i = 0; i < Deck.Count; i++)
            {
                AuxDeck = Deck;
                AuxDeck[0] = Deck[i];
                int RandomIndex = rnd.Next(0, Deck.Count);
                Deck[i] = Deck[RandomIndex];
                Deck[RandomIndex] = AuxDeck[0];

                
            }
        return Deck;

        }
        public List<Card> PlayerM; //melee row// fila de ataque cuerpo a cuerpo (max 9)
        public List<Card> PlayerR; //range row// ataque larga distancia (max 9)

        public List<Card> AuxDeck = new List<Card>();
        public List<Card> Cementery;

        public List<Card> PlayerHand; 
        public List<Card> Deck;
        public bool Pass;



        
        public string GetName()
        {
            return Name;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetPlayerHand()
        {
            return PlayerHand.Count;
        } 

public List<Card> GetPlayerHands()
        {
            return PlayerHand;
        }
        public int GetLife()
        {
            return Health;
        }

        public int GetDeckCount()
        {
            return Deck.Count;
        }

    
    }   
}