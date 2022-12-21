
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    
    public class CardDataBase
    {
        public static List<Card> CardList = new List<Card>();

        public CardDataBase()
        {
            addCards();
        }

        
        
        //     CardList.Add(aux2.CreateCard());
            
        //      //int id, string name, string description, int power, int armour, int cardType, int faction, int colour
        //     //faction 0 skelije
        //     //faction 1 monstruos
        //     //0 oro, 1 plata, 2  bronze (colour)
        //     //tipos no definidos aun(quizas se es mejor quitarlo no se \(._.)/)
            
        // }

       

        private static void addCards ()
        {
            string url = Directory.GetCurrentDirectory();                                                      //carga el url donde se encuentran ubicados los documentos
            string[] names = Directory.EnumerateFiles(url.Substring(0,url.Length)+"/CardDataBase").ToArray();    //guarda cada documento en un array
                                                                             //crea una lista de cartas
            var stuffed = new List<string>();  

            for(int i = 0;i<names.Length; i++)
            {
                StreamReader reader = new StreamReader(names[i]);
                string content = reader.ReadToEnd();
                stuffed.Add (content);               

            }
            for (var j = 0; j < stuffed.Count; j++)
            {
                string[] aux = stuffed[j].Split('\n', '\r'); 
                for (var i = 0; i < aux.Length; i++)
                {
                    if (aux[i] != "")
                       CardList.Add(createCard(aux[i]));
                }
            }
            for (var i = 0; i < CardList.Count; i++)
            {
                CardList[i].Id = i;
                
            }
            
        }




        private static Card createCard(string card)
        {
            var aux = new tokenizer(card);
            var aux2= new parser(aux);
            return aux2.CreateCard();
        }

       
    }
}