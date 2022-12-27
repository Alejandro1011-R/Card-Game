namespace BattleCards
{
    public static class juego
    {
        public static void Main()
        {
            /*CardDataBase cardDataBase = new CardDataBase();
            Game game = new Game();*/
            var aux = new tokenizer("(Vampiro: katakan) [Lo ultimo de la nueva generacion] poder 4 faccion 1 que QuitePoder 6 cuando MenosPoderQue 2 MasPoderQue 0 SubePoder 1 cuando MasPoderQue 2 faccion 2");
            var aux2= new parser(aux);
            var a = aux2.CreateCard();
            foreach (var ll in a.Efectos)
            {
               Console.WriteLine (ll.comprobaciones.Count());
            }
        }
        // prueba
    }
}
// static List<int> Orden(List<int> cartas)
//  {
//     Random rnd = new Random();
//     List<int> orden = new List<int>();
//     int i = 0;
//     while (i < cartas.Count)                                   //Método para perartir aleatoriamente las cartas
//     {
//         int carta = rnd.Next(0, cartas.Count);
//         if (!orden.Contains(cartas[carta]))
//         {
//             orden.Add(cartas[carta]);
//             i++;
//         }
//     }
//     return orden;
//  }
