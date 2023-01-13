using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using The_Clam_Boat;

namespace BattleCards
{
    public class GameRun
    {
        
        public static Player PlayerInTurn { get; set; }

        public static Player PlayerOpposide { get; set; }

        public static Dictionary<Card, int> CardsInGame;

      
        
        



        public GameRun(Player playerInTurn, Player playerOpposide)
        {
            CardsInGame = new Dictionary<Card, int>();
           
            PlayerInTurn = playerInTurn;
            PlayerOpposide = playerOpposide;
        }


        public static void SystemGame(Player player, Player playerOpposide, PictureBox[,] visualBoard, Card card)
        {
           
                
            bool temp = true; //comprobar si jugo la carta
            ;
            //PassiveEffect();
            

            KeyValuePair<Card, int> ACardInGame = new KeyValuePair<Card, int>(
                card,
                card.Id
            );
            if (!CardsInGame.Contains(ACardInGame))
            {
                CardsInGame.Add(card, card.Id);
            }

            player.PlayerM.Add(card);
            player.Hand.Remove(card);
            if(!player.PlayerIsaBot)
                Campo_Juego.DeleteVisualHand(card, player);


            foreach (var item in ACardInGame.Key.Efectos)
            {
                item.effect(player, playerOpposide);
            }
            
            DeleteCard(player, playerOpposide);






            for (var i = 0; i < player.BoardSeccion.GetLength(0); i++)
            {
                for (var j = 0; j < player.BoardSeccion.GetLength(1); j++)
                {
                    if (player.BoardSeccion[i, j] == null)
                    {
                        player.BoardSeccion[i, j] = card;
                        visualBoard[i, j].Image = card.image.Image;
                        if (visualBoard == Campo_Juego.BoardP1) visualBoard[i, j].Name += card.Name;
                        else visualBoard[i, j].Name += card.Name;
                        temp = false;
                        break;
                    }


                }
                if (temp == false) break;

                else if (i == player.BoardSeccion.GetLength(0) - 1 && temp == true)
                {
                    player.Hand.Add(card);
                    Campo_Juego.AddVisualCardToHand(card, player);
                    player.PlayerM.Remove(card);
                    MessageBox.Show("No hay espacio en el tablero el tablero, pasa la ronda");
                    //aqui se debe de poner un mensaje de que no hay espacio en el tablero
                }
            }





        }

        public static bool FinalCheck(Player player1, Player player2)
        {
            if (
                player1.RaundsWon == 3
                || player2.RaundsWon == 3
                || player1.Deck.Count == 0
                || player2.Deck.Count == 0
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      /* public static bool CheckBoard(Player player, int turn)
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

       public static void PassiveEffect()
        {
            for (var i = 0; i < BBoard.GetLength(0); i++)
            {
                for (var j = 0; j < BBoard.GetLength(1); j++)
                {
                    if (BBoard[i, j] != null)
                    {
                        if (BBoard[i, j].Passive && BBoard[i, j].Power > 0)
                            foreach (var item in BBoard[i, j].Efectos)
                            {
                                item.effect(PlayerInTurn, PlayerOpposide);
                            }
                    }
                }

            }
        }*/
        public static void DeleteCard(Player playerInTurn, Player playerOpposide)
        {
            
            for (var i = 0; i < playerInTurn.BoardSeccion.GetLength(0); i++)
            {
                for (var j = 0; j < playerInTurn.BoardSeccion.GetLength(1); j++)
                {
                    if (playerInTurn.BoardSeccion[i, j] != null)
                    {
                        
                        if (playerInTurn.BoardSeccion[i, j].Power <= 0)
                        {

                            playerInTurn.PlayerM.Remove(playerInTurn.BoardSeccion[i, j]);
                            
                            if (Seleccion_Cartas.RealOrden)
                            {
                                if (playerInTurn == Seleccion_Cartas.player1)
                                    Campo_Juego.DeleteBoardCard(0, playerInTurn.BoardSeccion[i, j]);
                                else
                                    Campo_Juego.DeleteBoardCard(1, playerInTurn.BoardSeccion[i, j]);
                            }
                            else
                            {
                                if (playerInTurn == Seleccion_Cartas.player1)
                                    Campo_Juego.DeleteBoardCard(1, playerInTurn.BoardSeccion[i, j]);
                                else
                                    Campo_Juego.DeleteBoardCard(0, playerInTurn.BoardSeccion[i, j]);

                            }
                            playerInTurn.BoardSeccion[i, j] = null;




                        }
                        
                    }
                    else if (playerOpposide.BoardSeccion[i, j] != null)
                    {
                        
                        if (playerOpposide.BoardSeccion[i, j].Power <= 0 )
                        {
                            playerOpposide.PlayerM.Remove(playerOpposide.BoardSeccion[i, j]);
                       
                            if (Seleccion_Cartas.RealOrden)
                            {
                                if (playerOpposide == Seleccion_Cartas.player1)
                                    Campo_Juego.DeleteBoardCard(0, playerOpposide.BoardSeccion[i, j]);
                                else
                                    Campo_Juego.DeleteBoardCard(1, playerOpposide.BoardSeccion[i, j]);
                            }
                            else
                            {
                                if (playerOpposide == Seleccion_Cartas.player1)
                                    Campo_Juego.DeleteBoardCard(1, playerOpposide.BoardSeccion[i, j]);
                                else
                                    Campo_Juego.DeleteBoardCard(0, playerOpposide.BoardSeccion[i, j]);

                            }
                            playerOpposide.BoardSeccion[i, j] = null;
                        }
                        
                    }


                }
                

               
                
            }
            playerInTurn.Point(playerInTurn.PlayerM);
            playerOpposide.Point(playerOpposide.PlayerM);


        }

        public static void GameRule(Player player1, Player player2)
        {


            Campo_Juego.DeleteCompleteBoard();
            Campo_Juego.DeleteBothHands();
            player1.BoardSeccion = new Card[2, 5];
            player2.BoardSeccion = new Card[2, 5];
            GameRun.CardsInGame.Clear();
            player1.PassRound = false;
            player2.PassRound = false;
            player1.Point(player1.PlayerM);
            player2.Point(player2.PlayerM);
            player1.PlayerM.Clear();
            player2.PlayerM.Clear();
            ReturnCardsToDeck(player1);
            ReturnCardsToDeck(player2);
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

            if (FinalCheck(Seleccion_Cartas.player1, Seleccion_Cartas.player2))
            {
                if (Seleccion_Cartas.player1.RaundsWon == 3) MessageBox.Show("El jugador " + Seleccion_Cartas.player1.Name + " ha ganado el juego, regrese al menu principal");
                else if (Seleccion_Cartas.player2.RaundsWon == 3) MessageBox.Show("El jugador " + Seleccion_Cartas.player2.Name + " ha ganado el juego, regrese al menu principal");

            }
            else
            {
                Campo_Juego.turn = 1;
                Update(Seleccion_Cartas.player1);
                Update(Seleccion_Cartas.player2);
                Campo_Juego.ShowHandOrNot();

            }
        }

        #region DealingCards
        public static void Update(Player player)
        {
            if (player.Hand.Count == 0)
            {
                Stuffle(player);
                for (var i = 0; i < player.HandSize; i++)
                {
                    DrawCard(player);
                    if(!player.PlayerIsaBot)
                        Campo_Juego.AddVisualCardToHand(player.Hand[player.Hand.Count - 1], player);
                }
            }
            else if (player.Hand.Count < player.HandSize)
            {
                DrawCard(player);
                if (!player.PlayerIsaBot)
                    Campo_Juego.AddVisualCardToHand(player.Hand[player.Hand.Count - 1], player);
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

        public static void ReturnCardsToDeck (Player player)
        {
            for (int i = 0; i< player.Hand.Count; i++)
            {
                player.Deck.Add(player.Hand[i]);
            }
            player.Hand.Clear();
            Stuffle(player);
        }
        #endregion
    }
}