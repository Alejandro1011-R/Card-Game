namespace BattleCards;

public class GameStatus
{   
    public static int turn {get; set;}

    public static string[,] BoardStatus {get; set;}

    public static List<(Card, Player)> CardsInGame {get; set;}

    public static List<(Card, Player)> CardsInHand {get; set;}

    public static List<(Card, Player)> CardsPlayedInTurn {get; set;}

    

    

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
        Dictionary<GameStatus, int> GameStatuses = GameRun.GetGameStatuses;
        


        
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
                KeyValuePair<GameStatus, int> gameStatus = GameStatuses.ElementAt(k);
                
                if (gameStatus.Value == turn - 1)
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
