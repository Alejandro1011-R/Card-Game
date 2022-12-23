using System.Collections;
using System.Collections.Generic;

namespace BattleCards;

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

    // public static void AddItems (GameStatus gameStatus, int turn, Player player)
    // {
    //     GameStatuses.Add(gameStatus, turn);
    // }

    public static void SystemGame(Player player, int turn, int index) //asere que hace el 1er parametro, el player player??? no le veo sentido a eso
    {
        //player.Update(); // En cada turno repartir carta en cada turno
        bool temp = true;

        KeyValuePair<Card, int> ACardInGame = new KeyValuePair<Card, int>(
            player.Hand[index],
            player.Hand[index].Id
        );
        if (!CardsInGame.Contains(ACardInGame))
            CardsInGame.Add(player.Hand[index], player.Hand[index].Id);
        player.PlayerM.Add(player.Hand[index]);
        player.Hand.Remove(player.Hand[index]);

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

    public static bool FinalCheck(Player player1, Player player2)
    {
        if (
            player1.RaundsWon == 3
            || player2.RaundsWon == 3
            || player1.Hand.Count == 0
            || player2.Hand.Count == 0
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckBoard(Player player, int turn)
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
        player1.PassRound = false;
        player2.PassRound = false;
        player1.Point(player1.PlayerM);
        player2.Point(player2.PlayerM);
        player1.PlayerM.Clear();
        player2.PlayerM.Clear();
        if (player1.TotalPoint == player2.TotalPoint)
        {
            player1.Update();
            player2.Update();
        }
        else if (player1.TotalPoint > player2.TotalPoint)
        {
            player1.RaundsWon++;
            player1.Update();
            player2.Update();
        }
        else if (player2.TotalPoint > player1.TotalPoint)
        {
            player2.RaundsWon++;
            player2.Update();
            player1.Update();
        }
    }

    #region DealingCards
    public static void Update(Player player)
    {
        if (player.Deck.Count == player.DeckSize)
        {
            Stuffle(player);
            for (var i = 0; i < player.HandSize; i++)
            {
                DrawCard(player);
            }
        }
        else
        {
            DrawCard(player);
        }
    }

    public static void Stuffle(Player player)
    {
        Random rnd = new Random();
        var AuxCard = new Card();
        for (var i = 0; i < player.Deck.Count; i++)
        {
            AuxCard = player.Deck[i];
            int RandomIndex = rnd.Next(0, player.Deck.Count);
            player.Deck[i] = player.Deck[RandomIndex];
            player.Deck[RandomIndex] = AuxCard;
        }
    }

    public static void DrawCard(Player player)
    {
        if (player.Deck.Count > 0)
        {
            player.Hand.Add(player.Deck[0]);
            player.Deck.RemoveAt(0);
        }
    }
    #endregion
}
