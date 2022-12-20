
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    
    public class CardDataBase
    {
        public static List<Card> CardList = new List<Card>();


        public void awake()
        { 
            var aux = new tokenizer("(Almeja) [Lo ultimo de la nueva generacion] power 4 faccion 2 que QuitePoder 6 SubePoder 1");
            var aux2= new parser(aux);

            CardList.Add(aux2.CreateCard());
            
             //int id, string name, string description, int power, int armour, int cardType, int faction, int colour
            //faction 0 skelije
            //faction 1 monstruos
            //0 oro, 1 plata, 2  bronze (colour)
            //tipos no definidos aun(quizas se es mejor quitarlo no se \(._.)/)
            
        }

       
    }
}