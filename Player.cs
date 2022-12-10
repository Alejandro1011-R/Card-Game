using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    public class Player
    {
        private string Name;
        public Player(string name)
        {
            Name = name;
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

    }   
}