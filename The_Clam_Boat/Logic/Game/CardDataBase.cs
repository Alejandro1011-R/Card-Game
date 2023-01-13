using System.Collections.Generic;
using System.IO;
using System.Linq;
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


        /// <summary>
        /// Recibe un int i, que corresponde al número de la faccion correspondiente
        /// 1: Monster
        /// 2: Neutral
        /// 3: Nilfgaard
        /// 4: Scoia'tael
        /// </summary>

        public static string AssociateFaction(int i)
        {
            switch (i)
            {
                case 1:
                    return "Monster";
                case 2:
                    return "Neutral";
                case 3:
                    return "Nilfgaard";
                case 4:
                    return "Scoia'tael";
            }
            return "Default";
        }
        /// <summary>
        /// Se encarga de añadir las cartas a la lista de cartas, para luego ser usadas en el juego, lee los archivos .txt que se encuentran en la carpeta CardDataBase
        /// ejecuta el metodo createCard para cada una de las lines del txt
        /// </summary>
        private static void addCards()
        {
            string url = Directory.GetCurrentDirectory(); //carga el url donde se encuentran ubicados los documentos
            string[] names = Directory
                .EnumerateFiles(url.Substring(0, url.Length-10) + "/CardDataBase")
                .ToArray(); //guarda cada documento en un array
            //crea una lista de cartas
            var stuffed = new List<string>();

            for (int i = 0; i < names.Length; i++)
            {
                StreamReader reader = new StreamReader(names[i]);
                string content = reader.ReadToEnd();
                stuffed.Add(content);
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
                if (i < 10)
                    CardList[i].Id = int.Parse("0" + i);
                else
                    CardList[i].Id = i;
            }
        }


        /// <summary>
        /// Recibe un string con la informacion de una carta, y la separa en sus atributos, para luego crear una carta con esos atributos
        /// todo esto a traves del tokenizer y del parser
        /// </summary>

        public static Card createCard(string card)
        {
            var aux = new tokenizer(card);
            var aux2 = new parser(aux);
            return aux2.CreateCard();
        }
    }
}
