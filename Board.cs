namespace BattleCards
{
    public class Board
    {
       static public bool [,] board = {{false,false,false,false,false},{false,false,false,false,false},{false,false,false,false,false},{false,false,false,false,false},{false,false,false,false,false}};
         private int turn;
         private int player1health{get;set;}
        private int player2health{get;set;} 

        public void PrintBoard()
        {

        
            for (int i=0; i<board.GetLength(0); i++)
            {
                for(int j=0; j<board.GetLength(1); j++)
                {
                    if(i<=1)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.Write("[]");
                        if(j==4) System.Console.WriteLine("");

                    }
                    else if(i==2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        System.Console.Write("--");
                        if(j==4) System.Console.WriteLine("");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        System.Console.Write("[]");
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
            System.Console.WriteLine("Vida: "+ player1.GetHealth() + "                   Vida: "+ player2.GetHealth());
        }
    }
}
