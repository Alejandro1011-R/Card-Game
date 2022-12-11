
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
            CardList.Add(new Card(2,"Ciri", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 0, 2,false));
            CardList.Add(new Card(3,"Dorregaray", "Bloquea una unidad enemiga ",0,0,0,0,2,false));
            CardList.Add(new Card(4,"Drakkar"," Cada vez que tu rival juegue una unidad en su fila le inflige 1 de daño a la carta jugada(melee)",4,1,0,0,2,false));
            CardList.Add(new Card(5,"Dol Blathanna","Cancela el proximo ataque de una unidad enemiga",0,0,1,0,2,false));
            CardList.Add(new Card(6,"Cirilla", "Permite jugar otra carta de faction 1", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(7,"Yennefer", "Puedes tomar una carta del mazo", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(8,"Triss", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(9,"Dandelion", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(10,"Cahir", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(11,"Vesemir", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(12,"Vernon Roche", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(13,"Keira Metz", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(14,"Iorveth", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(15,"Regis", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(16,"Eredin", "Inflinge 2 de daño a una unidad enemiga", 2, 0, 0, 1, 2,false));
            CardList.Add(new Card(17,"Ghoul", "Ataca directamente al adversario", 2, 0, 0, 1, 2,false));



        }

    }
}