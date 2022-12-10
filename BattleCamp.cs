using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    public class BattleCamp
    {
        public CardDataBase CardCollection;


        public Player Player1;
        public Player Player2; 

        

        public Card[,] BattleField = new Card[5, 5];

        
    }
}