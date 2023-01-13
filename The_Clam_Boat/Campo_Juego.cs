using BattleCards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Clam_Boat
{
    public partial class Campo_Juego : Form
    {
        public Campo_Juego()
        {
            InitializeComponent();
            generic = BoardP1_8;
          //  genericHand = HandP1_1;
            
            if (Seleccion_Cartas.RealOrden)
            {
                new GameRun(Seleccion_Cartas.player1, Seleccion_Cartas.player2);
                
            }
            else
            {
                new GameRun(Seleccion_Cartas.player2, Seleccion_Cartas.player1);
               
            }
            CompleteBoard();
            CompleteHand();
            GameRun.Update(Seleccion_Cartas.player1);
            GameRun.Update(Seleccion_Cartas.player2);
            ShowHandOrNot();
               
            //AsociarHand();

        }

        
        public static int turn = 1;
        public static Player P1;
        public static Player P2;

        

        #region Tablero De Juego

        private static PictureBox generic;
        private static PictureBox genericHand;

        public static PictureBox[,] BoardP1 = new PictureBox[2, 5];
        public static PictureBox[,] BoardP2 = new PictureBox[2, 5];

        private static List<PictureBox> HandP1 = new List<PictureBox>(5);
        private static List<PictureBox> HandP2 = new List<PictureBox>(5);


        private void CompleteBoard ()
        {
            BoardP2[0, 0] = BoardP2_5;
            BoardP2[0, 1] = BoardP2_4;
            BoardP2[0, 2] = BoardP2_3;
            BoardP2[0, 3] = BoardP2_2;
            BoardP2[0, 4] = BoardP2_1;
            BoardP2[1, 0] = BoardP2_0;
            BoardP2[1, 1] = BoardP2_9;
            BoardP2[1, 2] = BoardP2_8;
            BoardP2[1, 3] = BoardP2_7;
            BoardP2[1, 4] = BoardP2_6;
            BoardP1[0, 0] = BoardP1_1;
            BoardP1[0, 1] = BoardP1_2;
            BoardP1[0, 2] = BoardP1_3;
            BoardP1[0, 3] = BoardP1_4;
            BoardP1[0, 4] = BoardP1_5;
            BoardP1[1, 0] = BoardP1_6;
            BoardP1[1, 1] = BoardP1_7;
            BoardP1[1, 2] = BoardP1_8;
            BoardP1[1, 3] = BoardP1_9;
            BoardP1[1, 4] = BoardP1_0;

            

        }

        public static void DeleteCompleteBoard()
        {
            for (int i = 0; i < BoardP1.GetLength(0); i++)
            {
               for(int j =0; j < BoardP1.GetLength(1); j++)
                {
                    BoardP1[i, j].Image = null;
                    BoardP1[i, j].Name.Substring(0, 9);
                    BoardP2[i, j].Image = null;
                    BoardP2[i, j].Name.Substring(0, 9);
                }
            }
        }

        public static void DeleteBoardCard (int a, Card card)
        {
            bool k = false;
            if (a == 0)
            {
                for (int i = 0; i < BoardP1.GetLength(0); i++)
                {
                    for (int j = 0; j < BoardP1.GetLength(1); j++)
                    {
                        if (card.Name == BoardP1[i, j].Name.Substring(9))
                        {
                            BoardP1[i, j].Image = null;
                            BoardP1[i, j].Name.Substring(0, 9);
                            break;
                            k = true;
                        }
                        
                    }
                    if (k) break;
                }
                
            }
            else
            {
                for (int i = 0; i < BoardP2.GetLength(0); i++)
                {
                    for (int j = 0; j < BoardP2.GetLength(1); j++)
                    {
                        if (card.Name == BoardP2[i, j].Name.Substring(9))
                        {
                            BoardP2[i, j].Image = null;
                            BoardP2[i, j].Name.Substring(0, 9);
                            break;
                            k = true;
                        }
                    }
                    if (k) break;
                }
            }

        }
        #endregion

        private void CompleteHand ()
        {
            
            HandP1.Add(HandP1_1);
            HandP1.Add(HandP1_2);
            HandP1.Add(HandP1_3);
            HandP1.Add(HandP1_4);
            HandP1.Add(HandP1_5);
            HandP2.Add(HandP2_1);
            HandP2.Add(HandP2_2);
            HandP2.Add(HandP2_3);
            HandP2.Add(HandP2_4);
            HandP2.Add(HandP2_5);

            
        }
        public static void DeleteBothHands ()
        {
            for (int i = 0; i < HandP1.Count; i++)
            {
                HandP1[i].Image = null;
                HandP1[i].Name = HandP1[i].Name.Substring(0, 8);
                HandP2[i].Image = null;
                HandP2[i].Name = HandP2[i].Name.Substring(0, 8);
            }

        }

        public static void ShowHandOrNot()
        {
            string url = Directory.GetCurrentDirectory();
            if (turn % 2 != 0)
            {
                if (Seleccion_Cartas.RealOrden)
                {
                    for (int i = 0, k = 0; i < HandP1.Count; i++)
                    {
                        if (HandP1[i].Image != null)
                        {
                            HandP1[i].Image = Seleccion_Cartas.player1.Hand[k].image.Image; k++;
                        }
                            

                    }
                    for (int i = 0; i < HandP2.Count; i++)
                    {
                        if (HandP2[i].Image != null)
                            HandP2[i].Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images\\backcard.jpg");
                        else if(Seleccion_Cartas.player2.PlayerIsaBot)
                            HandP2[i].Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images\\backcard.jpg");

                    }

                }
                else
                {
                    for (int i = 0, k = 0; i < HandP1.Count; i++)
                    {
                        if (HandP1[i].Image != null)
                        {
                            HandP1[i].Image = Seleccion_Cartas.player2.Hand[k].image.Image; k++;
                        }
                            

                    }
                    for (int i = 0; i < HandP2.Count; i++)
                    {
                        if (HandP2[i].Image != null)
                            HandP2[i].Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images\\backcard.jpg");

                    }

                }
            }
            else
            {
                if (Seleccion_Cartas.RealOrden)
                {
                    for (int i = 0, k = 0; i < HandP2.Count; i++)
                    {
                        if (HandP2[i].Image != null)
                        {
                            HandP2[i].Image = Seleccion_Cartas.player2.Hand[k].image.Image; k++;
                        }
                            
                        

                    }
                    for (int i = 0; i < HandP1.Count; i++)
                    {
                        if (HandP1[i].Image != null)
                            HandP1[i].Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images\\backcard.jpg");

                    }

                }
                else
                {
                    for (int i = 0, k = 0; i < HandP2.Count; i++)
                    {
                        if (HandP2[i].Image != null)
                        {
                            HandP2[i].Image = Seleccion_Cartas.player1.Hand[k].image.Image; k++;
                        }
                            

                    }
                    for (int i = 0; i < HandP1.Count; i++)
                    {
                        if (HandP1[i].Image != null)
                            HandP1[i].Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images\\backcard.jpg");
                        else if (Seleccion_Cartas.player2.PlayerIsaBot)
                            HandP2[i].Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images\\backcard.jpg");

                    }

                }

            }



        }
        
        public static void DeleteVisualHand (Card card, Player player)
        {

            if (player == Seleccion_Cartas.player1)
            {
                if (Seleccion_Cartas.RealOrden)
                {
                    for (int i = 0; i < HandP1.Count; i++)
                    {
                        string tmp = HandP1[i].Name.Remove(0, 8);
                        if (tmp == card.Name)
                        {
                            // HandP1[i].Name = HandP1[i].Name.Substring(0, HandP1[i].Name.Length - 3);
                            HandP1[i].Image = null;
                            HandP1[i].Name = HandP1[i].Name.Substring(0, 8);
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < HandP2.Count; i++)
                    {
                        string tmp = HandP2[i].Name.Remove(0, 8);
                        if (tmp == card.Name)
                        {
                            // HandP1[i].Name = HandP1[i].Name.Substring(0, HandP1[i].Name.Length - 3);
                            HandP2[i].Image = null;
                            HandP2[i].Name = HandP2[i].Name.Substring(0, 8);
                            break;
                        }
                    }
                }
            }
            else
            {
                if (Seleccion_Cartas.RealOrden)
                {
                    for (int i = 0; i < HandP2.Count; i++)
                    {
                        string tmp = HandP2[i].Name.Remove(0, 8);
                        if (tmp == card.Name)
                        {

                            HandP2[i].Image = null;
                            HandP2[i].Name = HandP2[i].Name.Substring(0, 8);
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < HandP1.Count; i++)
                    {
                        string tmp = HandP1[i].Name.Remove(0, 8);
                        if (tmp == card.Name)
                        {
                            // HandP1[i].Name = HandP1[i].Name.Substring(0, HandP1[i].Name.Length - 3);
                            HandP1[i].Image = null;
                            HandP1[i].Name = HandP1[i].Name.Substring(0, 8);
                            break;
                        }
                    }
                }
            }

        }

        public static void AddVisualCardToHand(Card card, Player player)
        {

            if (player == Seleccion_Cartas.player1)
            {
                if (Seleccion_Cartas.RealOrden)
                {
                    for (int i = 0; i < HandP1.Count; i++)
                    {
                        if (HandP1[i].Image == null)
                        {
                            HandP1[i].Image = card.image.Image;
                            HandP1[i].Name += card.Name;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0;i < HandP2.Count ; i++)
                    {
                        if (HandP2[i].Image == null)
                        {
                            HandP2[i].Image = card.image.Image;
                            HandP2[i].Name += card.Name;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (Seleccion_Cartas.RealOrden)
                {
                    for (int i = 0; i < HandP2.Count; i++)
                    {
                        if (HandP2[i].Image == null)
                        {

                            HandP2[i].Image = card.image.Image;
                            HandP2[i].Name += card.Name;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0;  i < HandP1.Count ; i++)
                    {
                        if (HandP1[i].Image == null)
                        {
                            HandP1[i].Image = card.image.Image;
                            HandP1[i].Name += card.Name;
                            break;
                        }
                    }
                    
                   
                }
            }
        }

        public void CloseWindow ()
        {
            this.Close();
        }
        

        private void label9_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }
        
        private void BotPlay ( PictureBox[,] Board)
        {
            Random index = new Random();
            int i = index.Next(0, Seleccion_Cartas.player2.Hand.Count);
            Card card = Seleccion_Cartas.player2.Hand[i];
            GameRun.SystemGame(Seleccion_Cartas.player2, Seleccion_Cartas.player1, Board, card);
            GameRun.Update(Seleccion_Cartas.player2);


        }

        private void Jugar_Carta(object sender, EventArgs e)
        {
            
            if (((PictureBox)sender).Name.Contains("P1") && turn % 2 != 0 )
            {
                
                if (Seleccion_Cartas.RealOrden && !Seleccion_Cartas.player2.PlayerIsaBot)
                {
                    Card card = CardDataBase.CardList.Find(x => x.Name == ((PictureBox)sender).Name.Substring(8));
                    GameRun.SystemGame(Seleccion_Cartas.player1, Seleccion_Cartas.player2, BoardP1, card);
                    if (Seleccion_Cartas.player2.PassRound)
                    {
                        turn += 2;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player1);
                    }
                    
                    else
                    {
                        turn++;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player2);
                    }
                }
                else if(Seleccion_Cartas.RealOrden && Seleccion_Cartas.player2.PlayerIsaBot)
                {
                    Card card = CardDataBase.CardList.Find(x => x.Name == ((PictureBox)sender).Name.Substring(8));
                    GameRun.SystemGame(Seleccion_Cartas.player1, Seleccion_Cartas.player2 , BoardP1, card);
                    turn ++;
                    CheckGame();
                    
                    BotPlay(BoardP2);
                    turn++;
                    ShowHandOrNot();
                    GameRun.Update(Seleccion_Cartas.player1);
                    
                }
                else if(!Seleccion_Cartas.RealOrden && !Seleccion_Cartas.player2.PlayerIsaBot)
                {
                    Card card = CardDataBase.CardList.Find(x => x.Name == ((PictureBox)sender).Name.Substring(8));
                    GameRun.SystemGame(Seleccion_Cartas.player2, Seleccion_Cartas.player1, BoardP1, card);
                    if (Seleccion_Cartas.player1.PassRound == true)
                    {
                        turn += 2;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player2);
                    }
                    
                    else
                    {
                        turn++;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player1);
                    }
                }
               
                
                
            }
            else if (((PictureBox)sender).Name.Contains("P2") && turn % 2 == 0)
            {
                
                if (Seleccion_Cartas.RealOrden && !Seleccion_Cartas.player2.PlayerIsaBot)
                {
                    Card card = CardDataBase.CardList.Find(x => x.Name == ((PictureBox)sender).Name.Substring(8));
                    GameRun.SystemGame(Seleccion_Cartas.player2, Seleccion_Cartas.player1, BoardP2, card);
                    if (Seleccion_Cartas.player1.PassRound == true)
                    {
                        turn += 2;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player2);
                    }
                    else
                    {
                        turn++;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player1);
                    }
                }
                else if (!Seleccion_Cartas.RealOrden && Seleccion_Cartas.player2.PlayerIsaBot)
                {
                    Card card = CardDataBase.CardList.Find(x => x.Name == ((PictureBox)sender).Name.Substring(8));
                    GameRun.SystemGame(Seleccion_Cartas.player1,Seleccion_Cartas.player2, BoardP2, card);
                    turn ++;
                    CheckGame();
                    
                    BotPlay(BoardP1);
                    turn++;
                    ShowHandOrNot();
                    GameRun.Update(Seleccion_Cartas.player1);

                }
                else if (!Seleccion_Cartas.RealOrden && !Seleccion_Cartas.player2.PlayerIsaBot)
                {
                    Card card = CardDataBase.CardList.Find(x => x.Name == ((PictureBox)sender).Name.Substring(8));
                    GameRun.SystemGame(Seleccion_Cartas.player1, Seleccion_Cartas.player2, BoardP2, card);
                    if (Seleccion_Cartas.player2.PassRound == true)
                    {
                        turn += 2;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player1);
                    }
                    else
                    {
                        turn++;
                        CheckGame();
                        ShowHandOrNot();
                        GameRun.Update(Seleccion_Cartas.player2);
                    }
                }
               
                
            }
            UpdateTotalPower();
            
            
        }

        private void CheckGame ()
        {
           if(GameRun.FinalCheck(Seleccion_Cartas.player1, Seleccion_Cartas.player2))
            {
                if (Seleccion_Cartas.player1.RaundsWon == 3) MessageBox.Show("El jugador " + Seleccion_Cartas.player1.Name + " ha ganado el juego");
                else if (Seleccion_Cartas.player2.RaundsWon == 3) MessageBox.Show("El jugador " + Seleccion_Cartas.player2.Name + " ha ganado el juego");
            }
          /* else
            {
                if(Seleccion_Cartas.player1.PassRound && Seleccion_Cartas.player2.PassRound)
                {
                    GameRun.GameRule(Seleccion_Cartas.player1, Seleccion_Cartas.player2);
                }
                else
                {
                    GameRun.Update(p);
                }
            }*/
        }



        private void Mostrar_DescripcionCarta(object sender, EventArgs e)
        {
            Card card = CardDataBase.CardList.Find(x => x.image.Image == ((PictureBox)sender).Image);
            // string name_card = ((PictureBox)sender).Name;
            if (card != null)
            {
                Imagen_infoCarta.Image = ((PictureBox)sender).Image;
                Nombre_Carta.Text = card.Name;
                Faccion_Carta.Text = CardDataBase.AsociarFaccion(card.Faction);
                Poder_n.Text = card.Power.ToString();
                Descripcion_Carta.Text = card.Description;
            }

        }
        private void No_MostrarDescripcioncarta(object sender, EventArgs e)
        {
            Nombre_Carta.Text = " ";
            Imagen_infoCarta.Image = BackgroundImage;

        }

        private void TerminarRonda (object sender, EventArgs e)
        {
            if (Seleccion_Cartas.RealOrden)
            {
                if (turn % 2 != 0)
                {
                    Seleccion_Cartas.player1.PassRound = true;
                    turn++;
                    
                    if (Seleccion_Cartas.player2.PlayerIsaBot)
                    {
                        while (Seleccion_Cartas.player2.TotalPoint <= Seleccion_Cartas.player1.TotalPoint && Seleccion_Cartas.player2.Deck.Count > 0 && Seleccion_Cartas.player2.PlayerM.Count < 10)
                        {
                            BotPlay(BoardP2);
                            turn += 2;
                            UpdateTotalPower();
                        }
                        Seleccion_Cartas.player2.PassRound = true;

                    }
                    else ShowHandOrNot();
                }

                else
                {
                    Seleccion_Cartas.player2.PassRound = true;
                    turn++;
                    ShowHandOrNot();
                }
            }
            else
            {
                if (turn % 2 == 0)
                {
                    Seleccion_Cartas.player1.PassRound = true;
                    turn++;
                    if (Seleccion_Cartas.player2.PlayerIsaBot)
                    {
                        while (Seleccion_Cartas.player2.TotalPoint <= Seleccion_Cartas.player1.TotalPoint && Seleccion_Cartas.player2.Deck.Count > 0 && Seleccion_Cartas.player2.PlayerM.Count < 10)
                        {
                            BotPlay(BoardP2);
                            turn += 2;
                            UpdateTotalPower();
                        }
                        Seleccion_Cartas.player2.PassRound = true;

                    }
                    else ShowHandOrNot();
                }

                else
                {
                    Seleccion_Cartas.player2.PassRound = true;
                    turn++;
                    ShowHandOrNot();
                }
            }
            if (Seleccion_Cartas.player1.PassRound && Seleccion_Cartas.player2.PassRound)
            {
                if (Seleccion_Cartas.player1.TotalPoint == Seleccion_Cartas.player2.TotalPoint)
                {
                    MessageBox.Show("La ronda ha quedado en empate");
                }
                else if (Seleccion_Cartas.player1.TotalPoint > Seleccion_Cartas.player2.TotalPoint)
                {
                    MessageBox.Show("El jugador "+ Seleccion_Cartas.player1.Name + " ha ganado la ronda");

                }
                else if (Seleccion_Cartas.player2.TotalPoint > Seleccion_Cartas.player1.TotalPoint)
                {
                    MessageBox.Show("El jugador " + Seleccion_Cartas.player2.Name + " ha ganado la ronda");
                }
                GameRun.GameRule(Seleccion_Cartas.player1, Seleccion_Cartas.player2);
                UpdateTotalPower();
                UpdateTotalRounds();

            }
            

        }
        public void UpdateTotalPower ()
        {
            if (Seleccion_Cartas.RealOrden)
            {
                
                    totalPowerP1.Text = Seleccion_Cartas.player1.TotalPoint.ToString();
                
                    totalPowerP2.Text = Seleccion_Cartas.player2.TotalPoint.ToString();
                
            }
            else
            {
                
                    totalPowerP1.Text = Seleccion_Cartas.player2.TotalPoint.ToString();
               
                    totalPowerP2.Text = Seleccion_Cartas.player1.TotalPoint.ToString();
                
            }
        }
        public void UpdateTotalRounds()
        {
            if (Seleccion_Cartas.RealOrden)
            {

                roundsWonP1.Text = Seleccion_Cartas.player1.RaundsWon.ToString();

                roundsWonP2.Text = Seleccion_Cartas.player2.RaundsWon.ToString();

            }
            else
            {

                roundsWonP1.Text = Seleccion_Cartas.player2.RaundsWon.ToString();

                roundsWonP2.Text = Seleccion_Cartas.player1.RaundsWon.ToString();
                
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
