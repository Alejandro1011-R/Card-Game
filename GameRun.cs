using System.Collections;
using System.Collections.Generic;
namespace BattleCards;



public class GameRun
{
    //public static Dictionary<GameStatus, int> GameStatuses ;
    public static Card[,] BBoard;
    public static Player PlayerInTurn {get; set;}

    public static Player PlayerOpposide {get; set;}

    public static Dictionary<Card, int> CardsInGame;

    // public static Dictionary<GameStatus, int> GetGameStatuses
    // {
    //     get { return GameStatuses; }
    // }

    public GameRun(Player playerInTurn, Player playerOpposide)
    {
        CardsInGame =  new Dictionary<Card, int>();
        BBoard = new Card[5,5];
        PlayerInTurn = playerInTurn;
        PlayerOpposide = playerOpposide;
        
    }

    // public static void AddItems (GameStatus gameStatus, int turn, Player player)
    // {
    //     GameStatuses.Add(gameStatus, turn);
    // }
    
    public static void SystemGame(Player player, int turn, int index) //asere que hace el 1er parametro, el player player??? no le veo sentido a eso
    {
            //player.Update(); // En cada turno repartir carta en cada turno
            bool temp = true;
            
            KeyValuePair<Card, int> ACardInGame = new KeyValuePair<Card, int>(player.GetHands()[index],player.GetHands()[index].Id);                           
                if (!CardsInGame.Contains(ACardInGame))
                CardsInGame.Add(
                    player.GetHands()[index],
                    player.GetHands()[index].Id
                );
            player.PlayerM.Add(player.GetHands()[index]);
            player.Hand.Remove(player.GetHands()[index]);

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

    public static bool FinalCheck (Player player1, Player player2)
    {
        if (player1.GetRoundsWon == 3 || player2.GetRoundsWon == 3 || player1.GetHand() == 0 || player2.GetHand() == 0)
        {
            
            return true;
            
        }
        else
        {
            return false;
        }
    }

    

    public static bool CheckBoard (Player player, int turn)
    {
        bool temp = true;
        if (turn % 2 != 0)
        {
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < BBoard.GetLength(1); j++)
                {
                    if (BBoard[i, j] == null)
                    {
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
        else
        {
            for (var i = BBoard.GetLength(0) - 1; i > 2; i--)
            {
                for (var j = BBoard.GetLength(1) - 1; j >= 0; j--)
                {
                    if (BBoard[i, j] == null)
                    {
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

        return temp;
    }
    public static void GameRule(Player player1, Player player2)
        {
            //si los 2 se pasan, termina ese turno y se elige el ganador de acuerdo a la cantidad de poder en el campo

            
            GameRun.BBoard = new Card[5, 5];
            GameRun.CardsInGame.Clear();
            player1.PassedRound = false;
            player2.PassedRound = false;
            player1.Point(player1.PlayerM);
            player2.Point(player2.PlayerM);
            player1.DeletePlayer();
            player2.DeletePlayer();
            if (player1.Points == player2.Points)
            {
                player1.Actualizar();
                player2.Actualizar();
            
            }
            else if (player1.Points > player2.Points)
            {
                player1.GetRoundsWon++;
                player1.Actualizar();

                
            }
            else if (player2.Points > player1.Points)
            {
                player2.GetRoundsWon++;
                player2.Actualizar();

                
            }
        }
    
}



