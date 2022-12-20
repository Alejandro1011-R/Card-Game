using System.Collections;
using System.Collections.Generic;
namespace BattleCards;



public class GameRun
{
    public static Dictionary<GameStatus, int> GameStatuses ;

    public static Player PlayerInTurn {get; set;}

    public static Player PlayerOpposing {get; set;}

    public static Dictionary<GameStatus, int> GetGameStatuses
    {
        get { return GameStatuses; }
    }

    public GameRun(Player playerInTurn, Player playerOpposing)
    {
        GameStatuses = new Dictionary<GameStatus, int>();
        PlayerInTurn = playerInTurn;
        PlayerOpposing = playerOpposing;
        
    }

    public static void AddItems (GameStatus gameStatus, int turn, Player player)
    {
        GameStatuses.Add(gameStatus, turn);
    }
    
    public static void SystemGame(Player player, int turn, int id, ConsoleKeyInfo option, int index) //asere que hace el 1er parametro, el player player??? no le veo sentido a eso
    {
            //player.Update(); // En cada turno repartir carta en cada turno
            bool temp = true;
              
                    
                    if (id == 1)
                    {
                       
                        //Esto lo puse asi xq el option me da x ejemplo 49 '1' y no vi otra via pa hacerlo si quieres modifica

                        for (var i = 0; i < 2; i++)
                        {
                            for (var j = 0; j < Board.board.GetLength(1); j++)
                            {
                                if (Board.board[i, j] == "[  ]")
                                {
                                    Board.board[i, j] =
                                        "[" + player.GetHands()[index].Id.ToString() + "]";
                                    
                                    KeyValuePair<Card, int> ACardInGame = new KeyValuePair<Card, int>(player.GetHands()[index],player.GetHands()[index].Id);
                                        
                                    if (!Board.CardsInGame.Contains(ACardInGame))
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
                     
                        for (var i = Board.board.GetLength(0) - 1; i > 2; i--)
                        {
                            for (var j = Board.board.GetLength(1) - 1; j >= 0; j--)
                            {
                                if (Board.board[i, j] == "[  ]")
                                {
                                    Board.board[i, j] =
                                        "[" + player.GetHands()[index].Id.ToString() + "]";

                                        KeyValuePair<Card, int> ACardInGame = new KeyValuePair<Card, int>(player.GetHands()[index],player.GetHands()[index].Id);
                                        
                                    if (!Board.CardsInGame.Contains(ACardInGame))
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
                          
    }

    public static bool CheckBoard (Player player, int id)
    {
        bool temp = true;
        if (id == 1)
        {
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (Board.board[i, j] == "[  ]")
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
        else if (id == 2)
        {
            for (var i = Board.board.GetLength(0) - 1; i > 2; i--)
            {
                for (var j = Board.board.GetLength(1) - 1; j >= 0; j--)
                {
                    if (Board.board[i, j] == "[  ]")
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
    
}



