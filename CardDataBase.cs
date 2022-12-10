
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    
    public class CardDataBase
    {
        public static List<Card> CardList = new List<Card>();


        void awake()
        {  //int id, string name, string description, int power, int armour, int cardType, int faction, int colour
            //faction 0 skelije
            //faction 1 monstruos
            //0 oro, 1 plata, 2  bronze (colour)
            //tipos no definidos aun(quizas se es mejor quitarlo no se \(._.)/)
            CardList.Add(new Card(0,"Geralt", "Destruye una unidad enemiga con 9 o más de poder ", 3, 0, 0, 0, 2,false));
            CardList.Add(new Card(1,"Lugos el Loco", "Inflinge a una unidad enemiga un daño igual al doble del numero de enemigos dañados",4,0,0,0,2,false));
            CardList.Add(new Card(3,"Dorregaray", "Bloquea una unidad enemiga ",0,0,0,0,2,false));
            //CardList.Add(new Card(4,"Drakkar"," Cada vez que tu rival juegue una unidad en su fila le inflige 1 de daño a la carta jugada(melee)",4,1,0,0,2,false));
        }

    }
}