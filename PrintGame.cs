using GameRun = BattleCards.GameRun;

namespace BattleCards
{
    public class Game
    {
       
        public Game()
        {
            
            //new CardDataBase();
            Presentation();
        }

        static void Presentation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            /*    Write(
                    1,
                    @"
                    ██████  ██ ███████ ███    ██ ██    ██ ███████ ███    ██ ██ ██████   ██████       █████      ██████   █████  ████████ ████████ ██      ███████  ██████  █████  ██████  ██████  ███████ ██
                    ██   ██ ██ ██      ████   ██ ██    ██ ██      ████   ██ ██ ██   ██ ██    ██     ██   ██     ██   ██ ██   ██    ██       ██    ██      ██      ██      ██   ██ ██   ██ ██   ██ ██      ██
                    ██████  ██ █████   ██ ██  ██ ██    ██ █████   ██ ██  ██ ██ ██   ██ ██    ██     ███████     ██████  ███████    ██       ██    ██      █████   ██      ███████ ██████  ██   ██ ███████ ██
                    ██   ██ ██ ██      ██  ██ ██  ██  ██  ██      ██  ██ ██ ██ ██   ██ ██    ██     ██   ██     ██   ██ ██   ██    ██       ██    ██      ██      ██      ██   ██ ██   ██ ██   ██      ██
                    ██████  ██ ███████ ██   ████   ████   ███████ ██   ████ ██ ██████   ██████      ██   ██     ██████  ██   ██    ██       ██    ███████ ███████  ██████ ██   ██ ██   ██ ██████  ███████ ██
                    "
               );*/
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            // bool correcto = true;
            // while (correcto)
            // {

            string pront= "Hola, a continuación podrá seleccionar lo que desea hacer en el juego:";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string [] options = new string[] {"Jugar", "Instrucciones", "Salir"};
            Menu menu = new Menu(pront, options);
          int option=  menu.Run()+1;

           // int option = Number(1, 3);
            // ConsoleKey option = Console.ReadKey().Key;
            System.Console.Clear();

            //if (option == ConsoleKey.D1)
            if (option == 1)
            {
                //   correcto = false;
                //  bool correctD1 = true;
                // while (correctD1)
                // {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string pront1="Seleccione el modo de juego?";
                string [] options1 = new string[] {"Jugador vs Jugador", "Jugador vs PC", "PC vs PC"};
                Menu menu1 = new Menu(pront1, options1);
                // ConsoleKeyInfo option2 = Console.ReadKey();

                int option2 = menu1.Run()+1;
                System.Console.Clear();
                if (option2 == 1)
                {
                    //    correctD1 = false;
                    StartGameVsPerson();
                }
                else if (option2 == 2)
                {
                    //  correctD1 = false;
                    StartGameVsComputer();
                }
                else if (option2 == 3)
                {
                    StartGameComputerVsComputer();
                }
            }
            else if (option == 3)
            {
                //  correcto = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Gracias por jugar!");
                System.Console.WriteLine("Presione cualquier tecla para salir...");
                System.Console.ReadKey();
                System.Console.Clear();
            }
            else if (option == 2)
            {
                //  correcto = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Reglas del juego: ");
                System.Console.WriteLine("1. Cada jugador tiene 5 cartas en su mano.");
                System.Console.WriteLine("2. Cada jugador tiene 3 turnos para ganar.");
                System.Console.WriteLine("3. Cada turno se juega una carta.");
                System.Console.WriteLine("4. Cada carta tiene un poder y una faccion.");
            }
            /*
            else
            {
                System.Console.WriteLine(
                    "Opcion invalida, presione cualquier tecla para volver al menu..."
                );
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
            }
            */
        }

        // }

        static void StartGameComputerVsComputer()
        {
            string pront="Elija el primer adversario:";
string[] options = new string[] {"Writer_02", "The_Creation", "Artagos"};
            Menu menu = new Menu(pront, options);

            Console.ForegroundColor = ConsoleColor.White;
            int option = menu.Run()+1;
            System.Console.Clear();
            if (option == 1)
            {
                string pront1="Elija el segundo adversario:";
                string[] options1 = new string[] {"The_Creation", "Artagos"};
                Menu menu1 = new Menu(pront1, options1);
                Console.ForegroundColor = ConsoleColor.White;
                int option2 = menu1.Run()+1;
                System.Console.Clear();
                if (option2 == 1)
                {
                    Player player1 = new Player("Writer_02");
                    Player player2 = new Player("The_Creation");
                    player1.PlayerIsaBot = true;
                    player2.PlayerIsaBot = true;
                    GameRun game = new GameRun(player1, player2);
                    Board board = new Board();
                    GameLoop(player1, player2, 1);
                }
                else if (option2 == 2)
                {
                    Player player1 = new Player("Writer_02");
                    Player player2 = new Player("Artagos");
                    player1.PlayerIsaBot = true;
                    player2.PlayerIsaBot = true;
                    GameRun game = new GameRun(player1, player2);
                    Board board = new Board();
                    GameLoop(player1, player2, 1);
                }
            }
            else if (option == 2)
            {
                string pront1="Elija el segundo adversario:";
                string[] options1 = new string[] {"Writer_02", "Artagos"};
                Menu menu1 = new Menu(pront1, options1);
                Console.ForegroundColor = ConsoleColor.White;
                int option2 = menu1.Run()+1;
           
          System.Console.Clear();
                if (option2 == 1)
                {
                    Player player1 = new Player("The_Creation");
                    Player player2 = new Player("Writer_02");
                    player1.PlayerIsaBot = true;
                    player2.PlayerIsaBot = true;
                    GameRun game = new GameRun(player1, player2);
                    Board board = new Board();
                    GameLoop(player1, player2, 1);
                }
                else if (option2 == 2)
                {
                    Player player1 = new Player("The_Creation");
                    Player player2 = new Player("Artagos");
                    player1.PlayerIsaBot = true;
                    player2.PlayerIsaBot = true;
                    GameRun game = new GameRun(player1, player2);
                    Board board = new Board();
                    GameLoop(player1, player2, 1);
                }
            }
            else if (option == 3)
            {
                string pront1="Elija el segundo adversario:";
                string[] options1 = new string[] {"Writer_02", "The_Creation"};
                Menu menu1 = new Menu(pront1, options1);
                Console.ForegroundColor = ConsoleColor.White;
                int option2 = menu1.Run()+1;

                System.Console.Clear();
                if (option2 == 1)
                {
                    Player player1 = new Player("Artagos");
                    Player player2 = new Player("Writer_02");
                    player1.PlayerIsaBot = true;
                    player2.PlayerIsaBot = true;
                    GameRun game = new GameRun(player1, player2);
                    Board board = new Board();
                    GameLoop(player1, player2, 1);
                }
                else if (option2 == 2)
                {
                    Player player1 = new Player("Artagos");
                    Player player2 = new Player("The_Creation");
                    player1.PlayerIsaBot = true;
                    player2.PlayerIsaBot = true;
                    GameRun game = new GameRun(player1, player2);
                    Board board = new Board();
                    GameLoop(player1, player2, 1);
                }
            }
        }

        static void StartGameVsPerson()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Ingrese el nombre del primer jugador:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string player1Name = System.Console.ReadLine().Trim();
            System.Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Ingrese el nombre del segundo jugador:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string player2Name = System.Console.ReadLine().Trim();
            System.Console.Clear();
            Player player1 = new Player(player1Name);
            Player player2 = new Player(player2Name);
            //  bool optionCorrect = true;
            //  while (optionCorrect)
            //   {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(
                "Hola "
                    + player1.Name
                    + " y "
                    + player2.Name
                    + "! a continuacion se elegira al azar quien comenzara el juego."
            );
            
            string pront= player1.Name + " elija cara o cruz:";
            string[] options = new string[] {"Cara", "Cruz"};
            Menu menu = new Menu(pront, options);
            Console.ForegroundColor = ConsoleColor.White;
            int option = menu.Run()+1;
          
            // ConsoleKey option = Console.ReadKey().Key;

            //me aburro
           
            System.Console.Clear();
            string optionString = " ";
            if (option == 1)
                optionString = "Cara";
            else
                optionString = "Cruz";
            // optionCorrect = false;
            string moneda = CaraoCruz();
            if (moneda == optionString)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("El resultado fue " + moneda + "!");
                System.Console.WriteLine(player1.Name + " comenzara el juego!");
                System.Console.WriteLine("Presione cualquier tecla para continuar...");
                System.Console.ReadKey();
                System.Console.Clear();
                GameRun game = new GameRun(player1, player2);
                Board board = new Board();
                GameLoop(player1, player2, 1);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("El resultado fue " + moneda + "!");
                System.Console.WriteLine(player2.Name + " comenzara el juego!");

                System.Console.WriteLine("Presione cualquier tecla para continuar...");
                System.Console.ReadKey();
                System.Console.Clear();
                GameRun game = new GameRun(player2, player1);
                Board board = new Board();
                GameLoop(player2, player1, 1);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Presione cualquier tecla para comenzar...");
            System.Console.ReadKey();
            System.Console.Clear();
            //  }
        }

        static void StartGameVsComputer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Write(25, "Ingrese el nombre del jugador:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string player1Name = System.Console.ReadLine().Trim();
            System.Console.Clear();

            string pront="Elija el adversario contra el que desea jugar";
            string[] options = new string[] {"Writer_02", "The_Creation", "Artagos"};
            Menu menu = new Menu(pront, options);
            Console.ForegroundColor = ConsoleColor.White;
            int option = menu.Run()+1;

           
            System.Console.Clear();
            if (option == 1)
            {
                Player player1 = new Player(player1Name);
                Player player2 = new Player("Writer_02");
                player2.PlayerIsaBot = true;
                GameRun game = new GameRun(player1, player2);
                Board board = new Board();
                GameLoop(player1, player2, 1);
            }
            else if (option == 2)
            {
                Player player1 = new Player("Player");
                Player player2 = new Player("The_Creation");
                player2.PlayerIsaBot = true;
                GameRun game = new GameRun(player1, player2);
                Board board = new Board();
                GameLoop(player1, player2, 1);
            }
            else if (option == 3)
            {
                Player player1 = new Player("Player");
                Player player2 = new Player("Artagos");
                player2.PlayerIsaBot = true;
                GameRun game = new GameRun(player1, player2);
                Board board = new Board();
                GameLoop(player1, player2, 1);
            }
        }

        static string CaraoCruz()
        {
            Random rnd = new Random();
            int coin = rnd.Next(0, 2);
            if (coin == 0)
            {
                return "cara";
            }
            else
            {
                return "cruz";
            }
        }

        public static void CheckPlayerInGame(Player player1, Player player2, int turn)
        {
            if (turn % 2 == 0)
            {
                GameRun.PlayerInTurn = player2;
                GameRun.PlayerOpposide = player1;
            }
            else
            {
                GameRun.PlayerInTurn = player1;
                GameRun.PlayerOpposide = player2;
            }
        }

        static void GameLoop(Player player1, Player player2, int turn)
        {
            //     if(EndGame(player1, player2)) return;
            CheckPlayerInGame(player1, player2, turn);
            if (player1.PassRound == false)
            {
                bool correctOrder = true;
                PlayNow(player1, player2, turn, correctOrder);
                turn++;
            }
            else
                turn++;

            CheckPlayerInGame(player1, player2, turn);
            if (player2.PassRound == false)
            {
                bool correctOrder = false;
                PlayNow(player2, player1, turn, correctOrder);
                turn++;
            }
            else
                turn++;

            //      System.Console.WriteLine("Presione cualquier tecla para continuar...");

            if (player1.PassRound == true && player2.PassRound == true)
            {
                GameRun.GameRule(player1, player2);
                RoundResult(player1, player2);
            }

            if (GameRun.FinalCheck(player1, player2))
                EndGame(player1, player2);

            GameLoop(player1, player2, turn);
        }

        static int Number(int a, int b)
        {
            ConsoleKey option = Console.ReadKey(true).Key;

            int number = (int)option - 48;
            if (number >= a && number <= b)
            { //Console.Clear();
                return number;
            }
            else
            {
                //  Console.Clear();
                return Number(a, b);
            }
        }

        static void PlayNow(Player playerInGame, Player playerOpposing, int turn, bool correctOrder)
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Turno de " + playerInGame.Name);
            // Board board = new Board();
            // board.BoardInfo(player1, player2);
            bool FullHand = false;
            if (playerInGame.Hand.Count == 5)
            {
                FullHand = true;
            }
            else
                GameRun.Update(playerInGame);

            if (correctOrder)
            {
                Board.BoardInfo(playerInGame, playerOpposing, FullHand);
            }
            else
            {
                Board.BoardInfo(playerOpposing, playerInGame, FullHand);
            }
            PrintTurnInfo(playerInGame, turn);
            // ConsoleKeyInfo option = Console.ReadKey();
            // System.Console.Clear();
            if (playerInGame.PlayerIsaBot == false)
            {
                int option = Number(1, 6);
                //  bool correct = true;
                //  while (correct)
                //    {
                //       correct = false;
                if (option == 6)
                {
                    //  correct = false;
                    playerInGame.PassRound = true;
                    System.Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Turno pasado");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }
                else if (
                    option == 1 || option == 2 || option == 3 || option == 4 || option == 5 //arreglar esta posibilidad
                )
                {
                    int index = 0;
                    switch (option)
                    {
                        case 1:
                            index = 0;
                            break;
                        case 2:
                            index = 1;
                            break;
                        case 3:
                            index = 2;
                            break;
                        case 4:
                            index = 3;
                            break;
                        case 5:
                            index = 4;
                            break;
                    }
                    if (GameRun.CheckBoard(playerInGame, turn))
                    {
                        System.Console.WriteLine(
                            "Todas las casillas estan ocupadas, seleccione otra opcion"
                        );
                        // option = System.Console.ReadKey();
                        //    correct = true;
                    }
                    else
                    {
                        GameRun.SystemGame(playerInGame, turn, index);
                        playerInGame.Point(playerInGame.PlayerM);
                        PrintBoardPerTurn();
                        //GameStatus gameStatus = new GameStatus();
                        // gameStatus.UpdateGameStatus(playerInGame, playerOpposing, turn);
                        // GameRun.AddItems(gameStatus, turn, playerInGame);
                    }
                }
                else
                {
                    System.Console.WriteLine("Opcion invalida, seleccione una opcion valida");
                    //  option = System.Console.ReadKey();
                    //   correct = true;
                }
                System.Console.Clear();
            }
            else
            {
                if (Writer_02.PassTurn(playerOpposing, playerInGame))
                {
                    playerInGame.PassRound = true;
                    System.Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Write(100, "Turno pasado");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }
                else
                {
                    int index = Writer_02.BestcardIndex(playerInGame);
                    GameRun.SystemGame(playerInGame, turn, index);
                    playerInGame.Point(playerInGame.PlayerM);
                    PrintBoardPerTurn();
                }
            }
        }

        // System.Console.ReadKey();

        // }

        private static void PrintBoardPerTurn()
        {
            for (var i = 0; i < Board.board.GetLength(0); i++)
            {
                for (var j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (GameRun.BBoard[i, j] != null)
                    {
                        Board.board[i, j] = "[" + GameRun.BBoard[i, j].Id.ToString() + "]";
                    }
                }
            }
        }

        public static void PrintTurnInfo(Player player, int turn)
        {
            if (turn == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(
                    player.Name
                        + " Ha recibido 5 cartas, Seleccione una carta para jugar o 6 para pasar turno"
                );
            }

            for (int i = 0; i < player.Hand.Count; i++) // imprime las cartas en mano del jugador que este jugando
            {
                // var dic = new Dictionary<Card, int>();
                // dic.Add(player.Hand[i], i + 1);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine(
                    i
                        + 1
                        + ". "
                        + player.Hand[i].Name
                        + ": "
                        + player.Hand[i].Description
                        + ", Power: "
                        + player.Hand[i].Power
                        + ", Faction: "
                        + player.Hand[i].Faction
                );
            }
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("6: Pasar turno");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Write(int val, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                System.Console.Write(text[i]);
                Thread.Sleep(val);
            }
            System.Console.WriteLine();
        }

        static void NewBoard()
        {
            for (var i = 0; i < GameRun.BBoard.GetLength(0); i++)
            {
                if (i == 2)
                {
                    for (var j = 0; j < GameRun.BBoard.GetLength(1); j++)
                    {
                        Board.board[i, j] = "----";
                    }
                }
                else
                {
                    for (var j = 0; j < GameRun.BBoard.GetLength(1); j++)
                    {
                        Board.board[i, j] = "[  ]";
                    }
                }
            }
        }

        static void RoundResult(Player player1, Player player2)
        {
            NewBoard();
            if (player1.TotalPoint == player2.TotalPoint)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Write(25, player1.Name + " puntos: " + player1.TotalPoint);

                Write(25, player2.Name + " puntos: " + player2.TotalPoint);

                player1.ResetPoint();
                player2.ResetPoint();
                Write(50, "Empate!");
                Console.ResetColor();
                System.Console.ReadKey();
                Console.Clear();
            }
            else if (player1.TotalPoint > player2.TotalPoint)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Write(25, player1.Name + " puntos: " + player1.TotalPoint);

                Write(25, player2.Name + " puntos: " + player2.TotalPoint);

                player1.ResetPoint();
                player2.ResetPoint();
                Write(50, player1.Name + " ha ganado el turno!");
                Console.ResetColor();
                System.Console.ReadKey();
                Console.Clear();
            }
            else if (player2.TotalPoint > player1.TotalPoint)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Write(25, player1.Name + " puntos: " + player1.TotalPoint);

                Write(25, player2.Name + " puntos: " + player2.TotalPoint);

                player1.ResetPoint();
                player2.ResetPoint();
                Write(50, player2.Name + " ha ganado el turno!");
                Console.ResetColor();
                System.Console.ReadKey();
                Console.Clear();
            }
        }

        static bool EndGame(Player player1, Player player2) //Condiciones de fin de juego
        {
            if (player1.RaundsWon == 3)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player1.Name + " ha ganado la partida!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
                return true;
            }
            else if (player2.RaundsWon == 3)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player2.Name + " ha ganado la partida!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
                return true;
            }
            else if (player1.Hand.Count == 0 || player2.Hand.Count == 0)
            {
                if (player1.RaundsWon > player2.RaundsWon)
                {
                    System.Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(player1.Name + " ha ganado la partida!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    Game game = new Game();
                    return true;
                }
                else if (player2.RaundsWon > player1.RaundsWon)
                {
                    System.Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(player2.Name + " ha ganado la partida!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    Game game = new Game();
                    return true;
                }
                else
                {
                    System.Console.WriteLine("Empate!");
                    System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    Game game = new Game();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
