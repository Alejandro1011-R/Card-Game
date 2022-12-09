using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    public class Player
    {
        public List<Card> PlayerM; //melee row// fila de ataque cuerpo a cuerpo (max 9)
        public List<Card> PlayerR; //range row// ataque larga distancia (max 9)
        public List<Card> Cementery;
        public List<Card> PlayerHand; 
        public List<Card> Deck;
        public bool Pass;

    }   
}