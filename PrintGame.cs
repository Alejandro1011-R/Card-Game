using System.Runtime.InteropServices;
using System.Linq;

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
            Write(
                1,
                @"
██████  ██ ███████ ███    ██ ██    ██ ███████ ███    ██ ██ ██████   ██████       █████      ██████   █████  ████████ ████████ ██      ███████  ██████  █████  ██████  ██████  ███████ ██ 
██   ██ ██ ██      ████   ██ ██    ██ ██      ████   ██ ██ ██   ██ ██    ██     ██   ██     ██   ██ ██   ██    ██       ██    ██      ██      ██      ██   ██ ██   ██ ██   ██ ██      ██ 
██████  ██ █████   ██ ██  ██ ██    ██ █████   ██ ██  ██ ██ ██   ██ ██    ██     ███████     ██████  ███████    ██       ██    ██      █████   ██      ███████ ██████  ██   ██ ███████ ██ 
██   ██ ██ ██      ██  ██ ██  ██  ██  ██      ██  ██ ██ ██ ██   ██ ██    ██     ██   ██     ██   ██ ██   ██    ██       ██    ██      ██      ██      ██   ██ ██   ██ ██   ██      ██    
██████  ██ ███████ ██   ████   ████   ███████ ██   ████ ██ ██████   ██████      ██   ██     ██████  ██   ██    ██       ██    ███████ ███████  ██████ ██   ██ ██   ██ ██████  ███████ ██ 
  "
            );
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            bool correcto = true;
            while (correcto)
            {
                System.Console.WriteLine(
                    "Hola, a continuación podrá seleccionar lo que desea hacer en el juego:"
                );
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                System.Console.WriteLine("1. Jugar ");
                System.Console.WriteLine("2. Salir");

                System.Console.WriteLine("3. Instrucciones");
                ConsoleKey option = Console.ReadKey().Key;
                System.Console.Clear();

                if (option == ConsoleKey.D1)
                {
                    correcto = false;
                    bool correctD1 = true;
                    while (correctD1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine(
                            "Desea jugar contra la computadora o contra otro jugador?"
                        );
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        System.Console.WriteLine("1. Computadora");
                        System.Console.WriteLine("2. Jugador");
                        ConsoleKeyInfo option2 = Console.ReadKey();
                        System.Console.Clear();
                        if (option2.KeyChar == '2')
                        {
                            correctD1 = false;
                            StartGameVsPerson();
                        }
                        else if (option2.KeyChar == '1')
                        {
                            correctD1 = false;
                            StartGameVsComputer();
                        }
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
                else if (option == ConsoleKey.D2)
                {
                    correcto = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("Gracias por jugar!");
                    System.Console.WriteLine("Presione cualquier tecla para salir...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }
                else if (option == ConsoleKey.D3)
                {
                    correcto = false;
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
            bool optionCorrect = true;
            while (optionCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(
                    "Hola "
                        + player1.GetName()
                        + " y "
                        + player2.GetName()
                        + "! a continuacion se elegira al azar quien comenzara el juego."
                );
                System.Console.WriteLine(player1.GetName() + " elija cara o cruz:");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine("1. Cara");
                System.Console.WriteLine("2. Cruz");
                ConsoleKey option = Console.ReadKey().Key;
                System.Console.Clear();
                //me aburro

                if (option == ConsoleKey.D1 || option == ConsoleKey.D2)
                {
                    string optionString = " ";
                    if (option == ConsoleKey.D1)
                        optionString = "Cara";
                    else
                        optionString = "Cruz";
                    optionCorrect = false;
                    string moneda = CaraoCruz();
                    if (moneda == optionString)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine("El resultado fue " + moneda + "!");
                        System.Console.WriteLine(player1.GetName() + " comenzara el juego!");

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
                        System.Console.WriteLine(player2.GetName() + " comenzara el juego!");

                        System.Console.WriteLine("Presione cualquier tecla para continuar...");
                        System.Console.ReadKey();
                        System.Console.Clear();
                        GameRun game = new GameRun(player2, player1);
                        Board board = new Board();
                        GameLoop(player2, player1, 1);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Presione cualquier tecla para comenzar...");
            System.Console.ReadKey();
            System.Console.Clear();
        }

        static void StartGameVsComputer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Elija el adversario contra el que desea jugar");
            System.Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("1. Writer_02");
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("2. The_Creation");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("3. Artagos");
            Console.ForegroundColor = ConsoleColor.White;
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

        static void CheckPlayerInGame(Player player1, Player player2, int turn)
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
            if (player1.PassedRound == false)
            {
                bool correctOrder = true;
                PlayNow(player1, player2, turn, correctOrder);
                turn++;
            }
            else
                turn++;

            CheckPlayerInGame(player1, player2, turn);
            if (player2.PassedRound == false)
            {
                bool correctOrder = false;
                PlayNow(player2, player1, turn, correctOrder);
                turn++;
            }
            else
                turn++;

            //      System.Console.WriteLine("Presione cualquier tecla para continuar...");

            if (player1.PassedRound == true && player2.PassedRound == true)
            {   
                GameRun.GameRule(player1, player2);
                RoundResult(player1, player2);
            }
                

            if(GameRun.FinalCheck(player1, player2)) EndGame(player1, player2);
            
            GameLoop(player1, player2, turn);
        }

        static void PlayNow(Player playerInGame, Player playerOpposing, int turn, bool correctOrder)
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Turno de " + playerInGame.GetName());
            // Board board = new Board();
            // board.BoardInfo(player1, player2);
            bool FullHand = false;
            if (playerInGame.Hand.Count == 5)
            {
                FullHand = true;
            }
            else
                playerInGame.Update();

            if (correctOrder)
            {
                Board.BoardInfo(playerInGame, playerOpposing, FullHand);
            }
            else
            {
                Board.BoardInfo(playerOpposing, playerInGame, FullHand);
            }
            PrintTurnInfo(playerInGame, turn);
            ConsoleKeyInfo option = Console.ReadKey();
            // System.Console.Clear();
            bool correct = true;
            while (correct)
            {
                correct = false;
                if (option.KeyChar == '6')
                {
                    correct = false;
                    playerInGame.PassedRound = true;
                    System.Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Turno pasado");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }
                else if (
                    option.KeyChar == '1'
                    || option.KeyChar == '2'
                    || option.KeyChar == '3'
                    || option.KeyChar == '4'
                    || option.KeyChar == '5' //arreglar esta posibilidad
                )
                {
                    int index = 0;
                    switch (option.KeyChar)
                    {
                        case '1':
                            index = 0;
                            break;
                        case '2':
                            index = 1;
                            break;
                        case '3':
                            index = 2;
                            break;
                        case '4':
                            index = 3;
                            break;
                        case '5':
                            index = 4;
                            break;
                    }
                    if (GameRun.CheckBoard(playerInGame, turn))
                    {
                        System.Console.WriteLine(
                            "Todas las casillas estan ocupadas, seleccione otra opcion"
                        );
                        option = System.Console.ReadKey();
                        correct = true;
                    }
                    else
                    {
                        GameRun.SystemGame(playerInGame, turn, index);
                        
                        PrintBoardPerTurn(playerInGame, turn, index);
                        //GameStatus gameStatus = new GameStatus();
                        // gameStatus.UpdateGameStatus(playerInGame, playerOpposing, turn);
                        // GameRun.AddItems(gameStatus, turn, playerInGame);
                        
                    }
                }
                else
                {
                    System.Console.WriteLine("Opcion invalida, seleccione una opcion valida");
                    option = System.Console.ReadKey();
                    correct = true;
                }
            }

            // System.Console.ReadKey();
            System.Console.Clear();
        }

        private static void PrintBoardPerTurn (Player player, int turn, int index)
        {
            bool temp = true;
            if (turn % 2 != 0)
            {
                for (var i = 0; i < 2; i++)
                {
                    for (var j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if (Board.board[i, j] == "[  ]")
                        {
                            Board.board[i, j] =
                                "[" + player.PlayerM[player.PlayerM.Count - 1].Id.ToString() + "]";
                            temp = false;
                            break;
                        }
                    }
                    if (temp == false)
                        break;
                    
                }
            }
            else 
            {
                for (var i = Board.board.GetLength(0) - 1; i > 2; i--)
                {
                    for (var j = Board.board.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (Board.board[i, j] == "[  ]")
                        {
                            Board.board[i, j] =
                                "[" + player.PlayerM[player.PlayerM.Count - 1].Id.ToString() + "]";
                            temp = false;
                            break;

                        }

                    }
                    if (temp == false)
                        break;
                }
            }
        }

        static void PrintTurnInfo(Player player, int turn)
        {
            if (turn == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(
                    player.GetName()
                        + " Ha recibido 5 cartas, Seleccione una carta para jugar o 6 para pasar turno"
                );
            }

            for (int i = 0; i < player.GetHand(); i++) // imprime las cartas en mano del jugador que este jugando
            {
                // var dic = new Dictionary<Card, int>();
                // dic.Add(player.GetHands()[i], i + 1);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine(
                    i
                        + 1
                        + ". "
                        + player.GetHands()[i].Name
                        + ": "
                        + player.GetHands()[i].Description
                        + ", Power: "
                        + player.GetHands()[i].Power
                        + ", Faction: "
                        + player.GetHands()[i].Faction
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
        }

        static void NewBoard()
        {
            for (var i = 0; i < Board.board.GetLength(0); i++)
            {
                if (i == 2)
                {
                    for (var j = 0; j < Board.board.GetLength(1); j++)
                    {
                        Board.board[i, j] = "----";
                    }
                }
                else
                    for (var j = 0; j < Board.board.GetLength(1); j++)
                    {
                        Board.board[i, j] = "[  ]";
                    }
            }
        }

        static void RoundResult (Player player1, Player player2)
        {
            NewBoard();
            if (player1.Points == player2.Points)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Empate!");
                Console.ResetColor();
            }
            else if (player1.Points > player2.Points)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player1.GetName() + " ha ganado el turno!");
                Console.ResetColor();
                
            }
            else if (player2.Points > player1.Points)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player2.GetName() + " puntos: " + player2.Points);
                System.Console.WriteLine(player2.GetName() + " ha ganado el turno!");
                Console.ResetColor();
            }
        }

        

        static bool EndGame(Player player1, Player player2) //Condiciones de fin de juego
        {
            if (player1.GetRoundsWon == 3)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player1.GetName() + " ha ganado la partida!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
                return true;
            }
            else if (player2.GetRoundsWon == 3)
            {
                System.Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player2.GetName() + " ha ganado la partida!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
                return true;
            }
            else if (player1.GetHand() == 0 || player2.GetHand() == 0)
            {
                if (player1.GetRoundsWon > player2.GetRoundsWon)
                {
                    System.Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(player1.GetName() + " ha ganado la partida!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    Game game = new Game();
                    return true;
                }
                else if (player2.GetRoundsWon > player1.GetRoundsWon)
                {
                    System.Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(player2.GetName() + " ha ganado la partida!");
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
