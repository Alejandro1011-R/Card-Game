# "The Clam Boat" - Informe de Proyecto
### Integrantes
* **Mauro Eduardo Campver Barrios** 
* **Alejandro Lamelas Delgado**
* **Alejandro Ramirez Trueba**

# Introducción
Gwent, un juego de cartas coleccionables desarrollado por CD Projekt RED, nos inspiró para crear mi propio juego de cartas coleccionables. La mecánica del juego es simple: creas una baraja de 40 cartas y te enfrentas a tu oponente en tres rondas. El objetivo es burlar a tu oponente con creatividad y estrategia. Con Gwent, vimos cuánto potencial hay para explorar dentro del género de los juegos de cartas coleccionables. Como tal, utilizamos nuestra experiencia con los juegos de mesa, así como nuestro interés en los juegos de estrategia, para diseñar mecánicas en torno a la gestión de recursos, la construcción de mazos y el pensamiento rápido que ayudaría a los jugadores a formar sus propias estrategias para la victoria. A través del ejemplo de Gwent, nos inspiramos para crear un nuevo tipo de juego de cartas coleccionables que no esté atado por reglas rígidas o cartas dominadas. Esto nos permitió desarrollar un meta en constante evolución donde los jugadores pueden crear mazos que son únicos y poderosos a su manera. Al ver lo que Gwent era capaz de hacer con su giro único en la fórmula tradicional del juego de cartas coleccionables, nos sentimos capacitados para hacer lo mismo y crear algo nuevo.

---
## Clases
El proyecto se desarrolla principalmente dentro de dos carpetas, *Logic* y *Visual*. La primera de ellas cuenta con una biblioteca de clases, en la cual se agrupan tanto el apartado Game como el Interpreter, mientras que en la segunda se lleva a cabo el apartado visual



*  ## [Logic](Logic)
     * ***Game*** 
        * Bot
        * CardDataBase
        * Cards          
        * GameRun
        * IPlayer
        * Player

    *  ***Interpreter*** 
        * CardEffects
        * Condiciones
        * Parser
        * Tokenizer
        * Tokens
* ## [Visual](Visual)
     * Board
     * Menu
     * PrintGame
     

>Primeramente analizaremos la parte Logica del proyecto


Dentro de Game, ...

Entre sus principales clases esta:
``` c#
public class GameRun
{
    //public static Dictionary<GameStatus, int> GameStatuses ;
    public static Card[,] BBoard;
    public static Player PlayerInTurn { get; set; }

    public static Player PlayerOpposide { get; set; }

    public static Dictionary<Card, int> CardsInGame;

    // public static Dictionary<GameStatus, int> GetGameStatuses
    // {
    //     get { return GameStatuses; }
    // }

    public GameRun(Player playerInTurn, Player playerOpposide)
    {
        CardsInGame = new Dictionary<Card, int>();
        BBoard = new Card[5, 5];
        PlayerInTurn = playerInTurn;
        PlayerOpposide = playerOpposide;
    }

    (...)

```
En esta clase corre todo el juego, cuenta con un tablero, un jugador y un oponente, y un diccionario de cartas en juego, el cual se utiliza para llevar un control de las cartas que estan en el tablero, y asi poder hacer las comprobaciones necesarias para el funcionamiento del juego.

``` c#
public class Card
{
    public int Id;
    public string Name;
    public string Description;
    public int BasePower;
    public int Power;
    public int Faction;
    
    public bool Passive;
    public List<effecto> Efectos;
    

    public Card()
    {
        Id = 0;
        Name = "Default";
        Description = "Default";
        Power = 0;
        Faction=0;
        Passive = false;
        BasePower=0;
        Efectos=new List<effecto>();
        
    }
}
```
Esta clase es la base de todas las cartas, cuenta con un id, un nombre, una descripcion, un poder, una faccion, un booleano que indica si es pasiva o no, y una lista de efectos, que es la que se utiliza para llevar un control de los efectos de las cartas.






---




>Con respecto al desarrollo del lenguaje para la implememtacion de nuevas cartas utilizamos las siguientes clases

``` c#
static public class TokenTypes
{
    public const int name =0;
    public const int info=1;
    public const int power=2;
    public const int faction =3;
    public const int effect_quitapoder = 4;
    public const int effect_subepoder = 5;
    public const int ComposicionDeEfectos =6;
    public const int cuando=7;
    public const int siemprecuando=8;
    public const int maspoder=9;
    public const int igualpoder=10;
    public const int menospoder=11;
    public const int condicionfaccion=12;

}
```
Esta clase es la que se utiliza para llevar un control de los tipos de tokens que se utilizan para el funcionamiento del interprete, y asi poder crear las cartas con su efecto usando estas palabras claves.




Creemos que por su importancia es importante desctacar el/los siguentes metodos


> De la clase SubirPoder (que es una clase que hereda de efecto)
De forma analoga se puede ver el metodo de la clase QuitaPoder

``` c#
 public override void effect(Player playerInTurn, Player playerOpposide)
        {
            if(comprobaciones.Count()==0)
            {
                int id=int.Parse(Console.ReadLine()!);
                foreach(var carta in playerInTurn.PlayerM)
                {
                    if(carta.Id==id)
                    {
                        carta.Power+=CantPower;
                        return;
                    }
                }
            }
            else
            {
                foreach(var carta in playerInTurn.PlayerM)
                {
                    for(int i=0;i<comprobaciones.Count();i++)
                    {
                        if(!comprobaciones[i](carta))
                        {
                            goto next;
                        }
                    }
                    carta.Power+=CantPower;
                    next:;

                }
            }
        }
```

``` c#
public static void SystemGame(Player player, int turn, int index) 
    {
        
        bool temp = true;
        PassiveEffect();
        DeleteCard();

        KeyValuePair<Card, int> ACardInGame = new KeyValuePair<Card, int>(
            player.Hand[index],
            player.Hand[index].Id
        );
        if (!CardsInGame.Contains(ACardInGame))
            CardsInGame.Add(player.Hand[index], player.Hand[index].Id);
        player.PlayerM.Add(player.Hand[index]);
        player.Hand.Remove(player.Hand[index]);

        foreach (var item in ACardInGame.Key.Efectos)
        {
            item.effect(PlayerInTurn, PlayerOpposide);
        }

        

        
        

        if (turn % 2 != 0)
        {
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < BBoard.GetLength(1); j++)
                {
                    if (BBoard[i, j] == null)
                    {
                        BBoard[i, j] = player.PlayerM[player.PlayerM.Count - 1];
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
            for (var i = BBoard.GetLength(0) - 1; i > 2; i--)
            {
                for (var j = BBoard.GetLength(1) - 1; j >= 0; j--)
                {
                    if (BBoard[i, j] == null)
                    {
                        BBoard[i, j] = player.PlayerM[player.PlayerM.Count - 1];
                        temp = false;
                        break;
                    }
                    
                }
                if (temp == false)
                    break;
            }
        }
    }

```
Estos metodos son los que se utilizan para el funcionamiento de las cartas, el primero es el que se utiliza para el efecto de las cartas, y el segundo es el que se utiliza para colocar las cartas en el tablero, aplicar los efectos de las cartas y eliminar las cartas del tablero cuando se acaba el turno, este metodo se aplicara para cada turno

``` c#

>Parte Visual

``` c#
public class Game
    {
       
        public Game()
        {
            Presentation();
        }
    }
```
Se imprime en pantalla una presentacion, se elige el modo de juego, se crean los jugadores y se inicia el juego





