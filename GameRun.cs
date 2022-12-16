using System.Collections;
using System.Collections.Generic;
namespace BattleCards;

public class GameStatus
{   
    public static int turn {get; set;}

    public static string[,] BoardStatus {get; set;}

    public static List<(Card, Player)> CardsInGame {get; set;}

    public static List<(Card, Player)> CardsInHand {get; set;}

    public static List<(Card, Player)> CardsPlayedInTurn {get; set;}

    public static Player PlayerInTurn {get; set;}

    public static Player PlayerOpposing {get; set;}

    

    public static (int, Player) Advantage;

    public GameStatus()
    {
        turn = 0;
        BoardStatus = Board.board;
        CardsInGame = new List<(Card, Player)>();
        CardsInHand = new List<(Card, Player)>();
        CardsPlayedInTurn = new List<(Card, Player)>();
       
        
    }

    // public void Set(int turn, List<(Card, Player)> CardsInGame, List<(Card, Player)> CardsInHand, List<(Card, Player)> CardsPlayedInTurn, (int, Player) CardsPlayedInGame, (int, Player) Advantage)
    // {
    //     GameStatus.turn = turn;
    //     GameStatus.CardsInGame = CardsInGame;
    //     GameStatus.CardsInHand = CardsInHand;
    //     GameStatus.CardsPlayedInTurn = CardsPlayedInTurn;
        
    //     GameStatus.Advantage = Advantage;
    // }
    public void UpdateGameStatus(Player playerInTurn ,Player playerOpposing, int turn)
    {
        
        PlayerInTurn = playerInTurn;
        PlayerOpposing = playerOpposing;

        GameStatus.turn = turn;  
        
         
        for (var i = 0; i < playerInTurn.PlayerM.Count; i++)
        {
            if(i < playerInTurn.PlayerM.Count )GameStatus.CardsInGame.Add((playerInTurn.PlayerM[i], playerInTurn));
            if(i < playerInTurn.PlayerR.Count )GameStatus.CardsInGame.Add((playerInTurn.PlayerR[i], playerInTurn));
            if(i < playerOpposing.PlayerM.Count )GameStatus.CardsInGame.Add((playerOpposing.PlayerM[i], playerOpposing));
            if(i < playerOpposing.PlayerR.Count )GameStatus.CardsInGame.Add((playerOpposing.PlayerR[i], playerOpposing));

            
        }

        if(playerInTurn.Hand.Count != 0) playerInTurn.Hand.ForEach(card => GameStatus.CardsInHand.Add((card, playerInTurn)));
        if(playerOpposing.Hand.Count != 0) playerOpposing.Hand.ForEach(card => GameStatus.CardsInHand.Add((card, playerOpposing)));

        int playerInTurnPower = 0;
        int playerOpposingPower = 0;

        for (var j = 0; j < GameStatus.CardsInGame.Count; j++)
        {
            if (GameStatus.CardsInGame[j].Item2 == playerInTurn)
            {
                playerInTurnPower += GameStatus.CardsInGame[j].Item1.Power;
            }
            else
            {
                playerOpposingPower += GameStatus.CardsInGame[j].Item1.Power;
            }
            
        }

        GameStatus.Advantage = (playerInTurnPower - playerOpposingPower, playerInTurnPower > playerOpposingPower ? playerInTurn : playerOpposing);
        (int, Player) advantage = GameStatus.Advantage;


        
        
        List<(Card, Player)> CardsPlayedInTurnList = CardsPlayed();

        GameStatus.CardsPlayedInTurn = CardsPlayed();

       // gameStatus.Set(turn, GameStatus.CardsInGame, GameStatus.CardsInHand, GameStatus.CardsPlayedInTurn,  GameStatus.Advantage);
        
        


        
    }
    public static List<(Card,Player)> CardsPlayed()
    {
        Dictionary<GameStatus, (int, Player)> GameStatuses = CreatingGameStatus.GetGameStatuses;
        


        
        int turn = GameStatus.turn;

        List<(Card, Player)> CardsPlayedInTurnList = new List<(Card, Player)>();
    
        if (GameStatuses.Count == 0)
        {
            for (var k = 0; k < GameStatus.CardsInGame.Count; k++)
            {
    
                CardsPlayedInTurnList.Add(GameStatus.CardsInGame[k]);
                
            }

        }

        else{

            for (var k = 0; k < GameStatuses.Count; k++)
            {
                KeyValuePair<GameStatus, (int, Player)> gameStatus = GameStatuses.ElementAt(k);
                
                if (gameStatus.Value.Item1 == turn - 1)
                {
                    for (var i = 0; i < gameStatus.Key.GetCardsInHand.Count; i++)
                    {
                        for (var j = 0; j < GameStatus.CardsInGame.Count; j++)
                        {
                            if (gameStatus.Key.GetCardsInHand[i] == GameStatus.CardsInGame[j])
                            {
                                CardsPlayedInTurnList.Add(gameStatus.Key.GetCardsInHand[i]);
                            }
                        }
                    }
                }
                
            }

        
        }

        return CardsPlayedInTurnList;
        
        
        
    }
    
    

    // public int GetTurn
    // {
    //     get { return turn; }
    // }

    public List<(Card, Player)> GetCardsInHand
    {
        get { return CardsInHand; }
    }
    
    public List<(Card, Player)> GetCardsInGame
    {
        get { return CardsInGame; }
    }

    public List<(Card, Player)> GetCardsPlayedInTurn
    {
        get { return CardsPlayedInTurn; }
    }

    internal void Set(int turn, List<(Card, Player)> cardsInGame, List<(Card, Player)> cardsInHand, List<(Card, Player)> cardsPlayedInTurn, (int, Player) advantage)
    {
        throw new NotImplementedException();
    }
}


public class CreatingGameStatus
{
    public static Dictionary<GameStatus, (int, Player)> GameStatuses ;

    public static Dictionary<GameStatus, (int,Player)> GetGameStatuses
    {
        get { return GameStatuses; }
    }

    public CreatingGameStatus()
    {
        GameStatuses = new Dictionary<GameStatus, (int, Player)>();
        
    }

    public static void AddItems (GameStatus gameStatus, int turn, Player player)
    {
        GameStatuses.Add(gameStatus, (turn, player));
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



