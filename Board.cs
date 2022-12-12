namespace BattleCards
{
    public class Board
    {
        public static string [,] board = {{"[  ]","[  ]","[  ]","[  ]","[  ]"},{"[  ]","[  ]","[  ]","[  ]","[  ]"},{"--","--","--","--","--"},{"[  ]","[  ]","[  ]","[  ]","[  ]"},{"[  ]","[  ]","[  ]","[  ]","[  ]"}};
         private int turn;

        public static Dictionary<Card, int> CardsInGame = new Dictionary<Card, int>();
         private int player1health{get;set;}
        private int player2health{get;set;} 

        public Board(Player player1, Player player2)
        {
            BoardInfo(player1, player2);
            
        }

        public void PrintBoard()
        {

        
            for (int i=0; i<board.GetLength(0); i++)
            {
                for(int j=0; j<board.GetLength(1); j++)
                {
                    
                    if(i<=1)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.Write(board[i,j]);
                        if(j==4) System.Console.WriteLine("");

                    }
                    else if(i==2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        System.Console.Write(board[i,j]);
                        if(j==4) System.Console.WriteLine("");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        System.Console.Write(board[i,j]);
                        if(j==4) {
                            System.Console.WriteLine("");
                            Console.ForegroundColor=ConsoleColor.White;
                        }
                    }
                    
                }
            }
        }
         public void BoardInfo(Player player1, Player player2)
        {

            System.Console.WriteLine("Tablero de juego:");
            PrintBoard();
            System.Console.WriteLine("Jugador 1: "+ player1.GetName() + "               Jugador 2: "+ player2.GetName());
            System.Console.WriteLine("Cartas en mano: "+ player1.GetHand() + "         Cartas en mano: "+ player2.GetHand());
           // System.Console.WriteLine("Vida: "+ player1.GetHealth() + "                   Vida: "+ player2.GetHealth());
            System.Console.WriteLine("");
            for (var i = 0; i < CardsInGame.Count; i++)
            {
                KeyValuePair<Card, int> card = CardsInGame.ElementAt(i);
                System.Console.WriteLine("Cartas en juego:");
                System.Console.WriteLine(card.Value + ": " + card.Key.Name + " " + card.Key.Description + " " + card.Key.Power + " " + card.Key.Faction);
                
            }
        }
    }
}
