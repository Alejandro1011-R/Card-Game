using System.Runtime.InteropServices;
using System.Linq;

namespace BattleCards
{
    public class Game
    {
        public Game()
        {
            Presentation();
        }

        static void Presentation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Bienvenido a BattleCards!");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            bool correcto = true;
            while (correcto)
            {
                System.Console.WriteLine(
                    "Hola, a continuación podrá seleccionar lo que desea hacer en el juego:"
                );
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
                        System.Console.WriteLine(
                            "Desea jugar contra la computadora o contra otro jugador?"
                        );
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
                    System.Console.WriteLine("Gracias por jugar!");
                    System.Console.WriteLine("Presione cualquier tecla para salir...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }
                else if (option == ConsoleKey.D3)
                {
                    correcto = false;

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
            System.Console.WriteLine("Ingrese el nombre del primer jugador:");
            string player1Name = System.Console.ReadLine().Trim();
            System.Console.Clear();
            System.Console.WriteLine("Ingrese el nombre del segundo jugador:");
            string player2Name = System.Console.ReadLine().Trim();
            System.Console.Clear();
            Player player1 = new Player(player1Name);
            Player player2 = new Player(player2Name);
            bool optionCorrect = true;
            while (optionCorrect)
            {
                System.Console.WriteLine(
                    "Hola "
                        + player1.GetName()
                        + " y "
                        + player2.GetName()
                        + "! a continuacion se elegira al hazar quien comenzara el juego."
                );
                System.Console.WriteLine(player1.GetName() + " elija cara o cruz:");
                System.Console.WriteLine("1. Cara");
                System.Console.WriteLine("2. Cruz");
                ConsoleKey option = Console.ReadKey().Key;
                System.Console.Clear();

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
                        System.Console.WriteLine("El resultado fue " + moneda + "!");
                        System.Console.WriteLine(player1.GetName() + " comenzara el juego!");

                        System.Console.WriteLine("Presione cualquier tecla para continuar...");
                        System.Console.ReadKey();
                        System.Console.Clear();
                        GameLoop(player1, player2, 1);
                    }
                    else
                    {
                        System.Console.WriteLine("El resultado fue " + moneda + "!");
                        System.Console.WriteLine(player2.GetName() + " comenzara el juego!");

                        System.Console.WriteLine("Presione cualquier tecla para continuar...");
                        System.Console.ReadKey();
                        System.Console.Clear();
                        GameLoop(player2, player1, 1);
                    }
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
            System.Console.WriteLine("Presione cualquier tecla para comenzar...");
            System.Console.ReadKey();
            System.Console.Clear();
        }

        static void StartGameVsComputer()
        {
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

        static void SystemGame(Player player, int turn, int id, Player player1, Player player2) //asere que hace el 1er parametro, el player player??? no le veo sentido a eso
        {
            player.Update(); // En cada turno repartir carta en cada turno
            bool temp = true;
            Board board = new Board(player1, player2);
            var dic = new Dictionary<Card, int>();
            if (turn == 1)
            {
                System.Console.WriteLine(
                    player.GetName()
                        + " Ha recibido 5 cartas, Seleccione una carta para jugar o 6 para pasar turno"
                );
            }

            for (int i = 0; i < player.GetHand(); i++) // imprime las cartas en mano del jugador que este jugando
            {
                dic.Add(player.GetHands()[i], i + 1);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
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

            bool correcto = true;
            while (correcto)
            {
                ConsoleKeyInfo option = Console.ReadKey();
                if (option.KeyChar == '6')
                {
                    correcto = false;
                    player.PassedTurn = true;
                    System.Console.Clear();
                    System.Console.WriteLine("Turno pasado");
                    System.Console.ReadKey();
                    System.Console.Clear();
                }
                //Se activa la carta jugada en el campo y se remueve de la mano
                else if (
                    option.KeyChar == '1'
                    || option.KeyChar == '2'
                    || option.KeyChar == '3'
                    || option.KeyChar == '4'
                    || option.KeyChar == '5' //arreglar esta posibilidad
                )
                {
                    correcto = false;
                    if (id == 1)
                    {
                        int index = (48 - ((int)option.Key)) * (-1); //Esto lo puse asi xq el option me da x ejemplo 49 '1' y no vi otra via pa hacerlo si quieres modifica

                        for (var i = 0; i < 2; i++)
                        {
                            for (var j = 0; j < Board.board.GetLength(1); j++)
                            {
                                if (Board.board[i, j] == "[  ]")
                                {
                                    Board.board[i, j] =
                                        "[" + player.GetHands()[index].Id.ToString() + "]";
                                    Board.CardsInGame.Add(
                                        player.GetHands()[index],
                                        player.GetHands()[index].Id
                                    );
                                    player.PlayerM.Add(player.GetHands()[index]);
                                    player.Hand.Remove(player.GetHands()[index]);
                                    temp = false;
                                    break;
                                }
                            }
                            if (temp == false)
                            {
                                break;
                            }
                        }
                    }
                    else if (id == 2)
                    {
                        int index = (48 - ((int)option.Key)) * (-1);
                        for (var i = Board.board.GetLength(0) - 1; i > 2; i--)
                        {
                            for (var j = Board.board.GetLength(1) - 1; j >= 0; j--)
                            {
                                if (Board.board[i, j] == "[  ]")
                                {
                                    Board.board[i, j] =
                                        "[" + player.GetHands()[index].Id.ToString() + "]";
                                    Board.CardsInGame.Add(
                                        player.GetHands()[index],
                                        player.GetHands()[index].Id
                                    );
                                    player.PlayerM.Add(player.GetHands()[index]);
                                    player.Hand.Remove(player.GetHands()[index]);
                                    temp = false;
                                    break;
                                }
                            }
                            if (temp == false)
                            {
                                break;
                            }
                        }
                    }
                    /* else
                     {
                         System.Console.WriteLine(
                             "Opcion invalida, presione cualquier tecla para volver al menu..."
                         );
                         System.Console.ReadKey();
                         System.Console.Clear();
                         Game game = new Game();
                     }
                   */
                    Console.Clear();
                    // Board board2 = new Board(player1, player2);
                    board.PrintBoard();
                }
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

        static void GameLoop(Player player1, Player player2, int turn)
        {
            //     if(EndGame(player1, player2)) return;

            if (player1.PassedTurn == false)
            {
                System.Console.WriteLine("Turno de " + player1.GetName());
                // Board board = new Board();
                // board.BoardInfo(player1, player2);

                SystemGame(player1, turn, 1, player1, player2);
                System.Console.ReadKey();
                System.Console.Clear();
            }
            if (player2.PassedTurn == false)
            {
                System.Console.WriteLine("Turno de " + player2.GetName());
                SystemGame(player2, turn, 2, player1, player2);
                System.Console.ReadKey();
                System.Console.Clear();
                //   System.Console.WriteLine("Presione cualquier tecla para continuar...");
            }
            //      System.Console.WriteLine("Presione cualquier tecla para continuar...");


            GameRule(player1, player2);
            EndGame(player1, player2);
            GameLoop(player1, player2, turn++);
        }

        static void GameRule(Player player1, Player player2)
        {
            if (player1.PassedTurn == true && player2.PassedTurn == true) //si los 2 se pasan, termina ese turno y se elige el ganador de acuerdo a la cantidad de poder en el campo
            {
                player1.PassedTurn = false;
                player2.PassedTurn = false;
                player1.Point(player1.PlayerM, player2.PlayerR);
                player2.Point(player2.PlayerM, player1.PlayerR);
                player1.DeletePlayer();
                player2.DeletePlayer();
                if (player1.Points > player2.Points)
                {
                    player1.Turns_wons++;
                    player1.Actualizar();

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(player1.GetName() + " ha ganado el turno!");
                    Console.ResetColor();
                }
                else if (player2.Points > player1.Points)
                {
                    player2.Turns_wons++;
                    player2.Actualizar();

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(player2.GetName() + " ha ganado el turno!");
                    Console.ResetColor();
                }
            }
        }

        static bool EndGame(Player player1, Player player2) //Condiciones de fin de juego
        {
            if (player1.Turns_wons == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player1.GetName() + " ha ganado!");
                Console.ResetColor();
                System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
                return true;
            }
            else if (player2.Turns_wons == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(player2.GetName() + " ha ganado!");
                Console.ResetColor();
                System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
                return true;
            }
            else if (player1.GetDeckCount() == 0 && player2.GetDeckCount() == 0)
            {
                System.Console.WriteLine("Empate!");
                System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
