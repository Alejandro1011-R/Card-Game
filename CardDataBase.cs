
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    
    public class CardDataBase
    {
        public static List<Card> CardList = new List<Card>();


        public void awake()
        {  //int id, string name, string description, int power, int armour, int cardType, int faction, int colour
            //faction 0 skelije
            //faction 1 monstruos
            //0 oro, 1 plata, 2  bronze (colour)
            //tipos no definidos aun(quizas se es mejor quitarlo no se \(._.)/)
            
        }

       
    }
}