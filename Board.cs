namespace BattleCards
{
    public class Board
    {
        public static string[,] board = new string[5, 5] {
            { "[  ]", "[  ]", "[  ]", "[  ]", "[  ]" },
            { "[  ]", "[  ]", "[  ]", "[  ]", "[  ]" },
            { "---", "---", "---", "---", "---" },
            { "[  ]", "[  ]", "[  ]", "[  ]", "[  ]" },
            { "[  ]", "[  ]", "[  ]", "[  ]", "[  ]" }

            
        };
        
        
        private int turn;

        public static Dictionary<Card, int> CardsInGame = new Dictionary<Card, int>();//Recuerdame modificar esto-- Es mejor llamar al del GameStatus
        // private int player1health { get; set; }
        // private int player2health { get; set; }

        public Board()
        {
            
        }

        public static void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i <= 1)
                    {
                        //Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.Write(board[i, j]);
                        if (j == 4)
                            System.Console.WriteLine("");
                    }
                    else if (i == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        System.Console.Write(board[i, j]);
                        if (j == 4)
                            System.Console.WriteLine("");
                    }
                    else
                    {
                        //Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        System.Console.Write(board[i, j]);
                        if (j == 4)
                        {
                            System.Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }

        public static void BoardInfo(Player player1, Player player2)
        {
            System.Console.WriteLine("Tablero de juego:");
            PrintBoard();
            System.Console.WriteLine(
                  player1.GetName()    +"                             "     + player2.GetName()
            );
            System.Console.WriteLine(
                "Cartas en mano: "
                    + player1.GetHand()
                    + "         Cartas en mano: "
                    + player2.GetHand()
            );
                   System.Console.WriteLine( "Rondas ganadas: "+ player1.GetRoundsWon + "         Rondas ganadas: "+ player2.GetRoundsWon);
            // System.Console.WriteLine("Vida: "+ player1.GetHealth() + "                   Vida: "+ player2.GetHealth());
            System.Console.WriteLine("");
            for (var i = 0; i < CardsInGame.Count; i++)
            {
                KeyValuePair<Card, int> card = CardsInGame.ElementAt(i);
                System.Console.WriteLine("Cartas en juego:");
                System.Console.WriteLine(
                    card.Value
                        + ". "
                        + card.Key.Name
                        + ": "
                        + card.Key.Description
                        + ", Power: "
                        + card.Key.Power
                        + ", Faction: "
                        + card.Key.Faction
                );
            }
            
        }

        
    }
}
