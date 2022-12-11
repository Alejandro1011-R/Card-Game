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
            PlayerHand = new List<Card>();
            Deck = new List<Card>();
            Pass = false;
        }
        public List<Card> PlayerM; //melee row// fila de ataque cuerpo a cuerpo (max 9)
        public List<Card> PlayerR; //range row// ataque larga distancia (max 9)
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