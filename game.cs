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
System.Console.WriteLine("Bienvenido a BattleCards!");
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            System.Console.WriteLine("Hola, a continuacion podra seleccionar lo que desea hacer en el juego:");
            System.Console.WriteLine("1. Jugar");
            System.Console.WriteLine("2. Salir");
            string option = System.Console.ReadLine();
            System.Console.Clear();
            if (option == "1")
            {
                StartGame();
            }
            else if (option == "2")
            {
                System.Console.WriteLine("Gracias por jugar!");
                System.Console.WriteLine("Presione cualquier tecla para salir...");
                System.Console.ReadKey();
                System.Console.Clear();
            }
            else
            {
                System.Console.WriteLine("Opcion invalida, presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
            }
        }
        static void StartGame()
        {
            System.Console.WriteLine("Ingrese el nombre del primer jugador:");
            string player1Name = System.Console.ReadLine();
            System.Console.Clear();
            System.Console.WriteLine("Ingrese el nombre del segundo jugador:");
            string player2Name = System.Console.ReadLine();
            System.Console.Clear();

            Player player1 = new Player(player1Name);
            Player player2 = new Player(player2Name);
            System.Console.WriteLine("Hola " + player1.GetName() + " y " + player2.GetName() + "! a continuacion se elegira al hazar quien comenzara el juego.");
            System.Console.WriteLine(player1.GetName() + " eliga cara o cruz:");
            string option = System.Console.ReadLine();
            System.Console.Clear();
            if (option == "cara" || option == "cruz")
            {
                Random rnd = new Random();
                int coin = rnd.Next(0, 2);
                if (coin == 0)
                {
                    System.Console.WriteLine("El resultado fue cara!");
                    System.Console.WriteLine(player1.GetName() + " comenzara el juego!");
                    System.Console.WriteLine("Presione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    GameLoop(player1.GetName(), player2.GetName());
                }
                else
                {
                    System.Console.WriteLine("El resultado fue cruz!");
                    System.Console.WriteLine(player2.GetName() + " comenzara el juego!");
                    System.Console.WriteLine("Presione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    GameLoop(player2.GetName(), player1.GetName());
                }
            }
            else
            {
                System.Console.WriteLine("Opcion invalida, presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
            }
            
            System.Console.WriteLine("Presione cualquier tecla para comenzar...");
            System.Console.ReadKey();
            System.Console.Clear();
        }

        static void GameLoop(string a, string b)
        {
            System.Console.WriteLine("Turno de " + a);

            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            System.Console.WriteLine("Turno de " + b);
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            GameLoop(a, b);

        }
        static bool EndTurn()
        {
            
          return true;
        }
    }
}