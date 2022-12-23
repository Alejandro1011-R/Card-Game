       namespace BattleCards
{
    public class Menu
    {
        private int SelectedIndex;
        private string[] Options;

        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        private void Display()
        {
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine(Prompt);
            Console.ResetColor();
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    prefix = "*";
                  Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} << {currentOption} >>");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Display();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
 
        
        /*
        public static void Action(string[] mn)
        {
            int x;
            int y;
            bool loop = true;
            int Counter = 0;
            ConsoleKeyInfo keyInfo;
            Console.CursorVisible = false;
            System.Console.WriteLine("selecione una opcion" + System.Environment.NewLine);
            x = Console.CursorLeft;
            y = Console.CursorTop;
            string[] nuevo = new string[mn.Length];
            nuevo = copiararray(mn, nuevo);
            string Resultado = menu(mn, Counter);
            Console.ReadKey();
            while (loop)
            {
                while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (Counter == 0)
                                continue;
                            Counter--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (Counter == mn.Length - 1)
                                continue;
                            Counter++;
                            break;
                    }
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Resultado = menu(mn, Counter);
                }
            }
        }

        static string[] copiararray(string[] a, string[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
            return b;
        }

        private static string menu(string[] menu, int option)
        {
            string SeleccionActual = string.Empty;
            int destacado = 0;
            Array.ForEach(
                menu,
                item =>
                {
                    if (destacado == option)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        System.Console.WriteLine("> " + item + " <");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        SeleccionActual = item;
                    }
                    else
                    {
                        System.Console.Write(new string(' ', Console.WindowWidth));
                        Console.CursorLeft = 0;
                        System.Console.Write(item);
                    }
                    destacado++;
                }
            );
            return SeleccionActual;
        }
       */ //
    }
}
