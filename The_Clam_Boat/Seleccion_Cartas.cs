using BattleCards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace The_Clam_Boat
{
    public partial class Seleccion_Cartas : Form
    {
        public Seleccion_Cartas()
        {
            
            
            InitializeComponent();
            player1 = new Player("");
            player2 = new Player("");
            LlenarCartas();
            Contador_de_Cartas.Text = "0/30";
           
            
        }
        
        public static bool RealOrden;
        public static Player player1;
        public static Player player2;
        public static int contador_cartas = 0;
        int poder_carta = 0;
        string descripcion_carta = "";
        string faccion_carta = "";
        public string nombre_jugador1 = "";
        public string nombre_jugador2 = "";
        public bool Multiplayer;
        
        private int CantidadDeCartas = 0;
     

        private List<PictureBox> pictureBoxes = new List<PictureBox>();



        private void Seleccion_Cartas_Load(object sender, EventArgs e)
        {

        }
        
        
        
        private void LlenarCartas()
        {
            
            for (int i = 2; i < 62; i++)
            {
                pictureBoxes.Add((PictureBox)Controls.Find("pictureBox" + i, true)[0]);
            }
            for (int i = 0; i < CardDataBase.CardList.Count; i++)
            {

                pictureBoxes[i].Image = CardDataBase.CardList[i].image.Image;
                
                CardDataBase.CardList[i].image = pictureBoxes[i];
                CantidadDeCartas++;
            }


        }

        private void SeleccionCarta(object sender, EventArgs e)
        {
            
        }

        private void InfoCartaSeleccion(object sender, EventArgs e)
        {

        }

        private void Empezar_Juego_Click(object sender, EventArgs e)
        {
            /* if (contador_cartas == 30 && NombreJugador.Texts!="")
             {
                 Campo_Juego juego = new Campo_Juego();
                 juego.Show();
                 nombre_jugador2 = NombreJugador.Texts;
                 juego.NombreJ1.Text = nombre_jugador1;
                 juego.NombreJ2.Text = nombre_jugador2;
             }
              else
              {
                  MessageBox.Show("Revise bien que tenga el numero correcto de cartas seleccionadas y el campo del nombre no este vacio");
              }*/
            if (contador_cartas == 30 && NombreJugador.Texts != "" && Nombre_Jugador.Text == "Nombre Jugador 2:")
            {
                Campo_Juego juego = new Campo_Juego();
                juego.Show();

                //ramdom select who starts


                if (Multiplayer == true)
                {
                    nombre_jugador2 = NombreJugador.Texts;

                    player1.Name = nombre_jugador1;

                    player2.Name = nombre_jugador2;

                }
                if (Multiplayer == false)
                {

                    player1.Name = NombreJugador.Texts;

                    player2.Name = "PC";
                }

                Random random = new Random();
                int randomInt = random.Next(0, 2);
                if (randomInt == 0)
                {
                    RealOrden = true;
                    juego.NombreJ1.Text = nombre_jugador1;
                    juego.NombreJ2.Text = nombre_jugador2;
                }
                else
                {
                    RealOrden = false;
                    juego.NombreJ1.Text = nombre_jugador2;
                    juego.NombreJ2.Text = nombre_jugador1;
                }
                this.Close();
            }
            
            else
            {
                if (Nombre_Jugador.Text == "Nombre Jugador 1:")
                {
                    MessageBox.Show("Usted no va a jugar solo, por favor ingrese el nombre del jugador 2");
                }
                else if (NombreJugador.Texts == "")
                {
                    MessageBox.Show("El campo del nombre no puede estar vacio");
                }
                else
                {
                    MessageBox.Show("Revise bien que tenga el numero correcto de cartas seleccionadas");
                }
            }
            

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Cambiar_Jugador_Click(object sender, EventArgs e)
        {
            if (contador_cartas == 30 && NombreJugador.Texts != "")
            {
                for (int i = 0; i < CantidadDeCartas; i++)
                {
                    if (pictureBoxes[i].BorderStyle == BorderStyle.None)
                    {
                        pictureBoxes[i].BorderStyle = BorderStyle.Fixed3D;
                        pictureBoxes[i].BackColor = Color.White;

                        contador_cartas = 0;
                        Contador_de_Cartas.Text = contador_cartas + "/30";

                       

                        if (contador_cartas == 30)
                        {
                            Contador_de_Cartas.BackColor = Color.Green;
                        }
                        if (contador_cartas > 30)
                        {
                            Contador_de_Cartas.BackColor = Color.Red;
                        }
                        if (contador_cartas < 30)
                        {
                            Contador_de_Cartas.BackColor = Color.Transparent;
                        }
                    }
                }
                
                nombre_jugador1 = NombreJugador.Texts;
                NombreJugador.Texts = "";
                Nombre_Jugador.Text = "Nombre Jugador 2:";
                Cambiar_Jugador.Enabled = false;
            }
            else
            {
                if (NombreJugador.Texts == "")
                {
                    MessageBox.Show("El campo del nombre no puede estar vacio");
                }
                else
                {
                    MessageBox.Show("Revise bien que tenga el numero correcto de cartas seleccionadas");
                }
            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Mostrar_DescripcionCarta(object sender, EventArgs e)
        {
            Card card = CardDataBase.CardList.Find(x => x.image.Image == ((PictureBox)sender).Image);
            if (card != null)
            {
                Imagen_infoCarta.Image = ((PictureBox)sender).Image;
                Nombre_Carta.Text = card.Name;
                Faccion_Carta.Text = CardDataBase.AsociarFaccion(card.Faction);
                Poder_n.Text = card.Power.ToString();
                Descripcion_Carta.Text = card.Description;
            }

        }
        
        private void AddOrDeleteCards (bool adiciona, object sender)
        {
            switch (Nombre_Jugador.Text)
            {
                case "Nombre Jugador 1:":
                    foreach (Card carta in CardDataBase.CardList)
                    {
                        if (carta.image.Name == ((PictureBox)sender).Name)
                        {
                            player1.CreateDeck(carta, adiciona);
                            break;
                        }
                    }
                    
                    break;
                case "Nombre Jugador 2:":
                    foreach (Card carta in CardDataBase.CardList)
                    {
                        if (carta.image.Name == ((PictureBox)sender).Name)
                        {
                            player2.CreateDeck(carta, adiciona);
                            break;
                        }
                    }
                    
                    break;
            }

        }

        private void Seleccion_Carta(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BorderStyle != BorderStyle.None && ((PictureBox)sender).Image != null)
            {
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
                contador_cartas++;
                bool addOrDelete = true;
                AddOrDeleteCards(addOrDelete, sender);




                Contador_de_Cartas.Text = contador_cartas + "/30";
                if (contador_cartas == 30)
                {
                    Contador_de_Cartas.BackColor = Color.Green;
                }
                if (contador_cartas > 30)
                {
                    Contador_de_Cartas.BackColor = Color.Red;
                }
                if (contador_cartas < 30)
                {
                    Contador_de_Cartas.BackColor = Color.Transparent;
                }
            }
            //string url = Directory.GetCurrentDirectory();
            //((PictureBox)sender).Image = Image.FromFile("D:\\Escuela\\Cards Project\\The_Clam_Boat\\images_card\\IMG-20221229-WA0057.jpg");
            //((PictureBox)sender).Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images_card\\IMG-20221229-WA0057.jpg");
            

        }

        private void No_MostrarDescripcioncarta(object sender, EventArgs e)
        {
            Nombre_Carta.Text = " ";
            Imagen_infoCarta.Image = BackgroundImage;

        }

        private void Deseleccionar_Carta(object sender, EventArgs e)
        {
            if (((PictureBox)sender).BorderStyle == BorderStyle.None && ((PictureBox)sender).Image != null)
            {
                ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
                ((PictureBox)sender).BackColor = Color.White;
                
                contador_cartas--;
                Contador_de_Cartas.Text = contador_cartas + "/30";
                
                bool addOrDelete = false;
                AddOrDeleteCards(addOrDelete, sender);

                if (contador_cartas == 30)
                {
                    Contador_de_Cartas.BackColor = Color.Green;
                }
                if (contador_cartas > 30)
                {
                    Contador_de_Cartas.BackColor = Color.Red;
                }
                if (contador_cartas < 30)
                {
                    Contador_de_Cartas.BackColor = Color.Transparent;
                }
            }
            
        }

        private void RandomClick(object sender, EventArgs e)
        {
            if (NombreJugador.Texts != "")
            {
                Random random = new Random();
                int index = random.Next(0, CantidadDeCartas);
                while (contador_cartas < 30)
                {
                    if (pictureBoxes[index].BorderStyle == BorderStyle.Fixed3D)
                    {
                        pictureBoxes[index].BorderStyle = BorderStyle.None;
                        pictureBoxes[index].BackColor = Color.White;
                        contador_cartas++;
                        bool addOrDelete = true;
                        AddOrDeleteCards(addOrDelete, pictureBoxes[index]);
                    }
                    index = random.Next(0, CantidadDeCartas);
                }
                Contador_de_Cartas.Text = contador_cartas + "/30";
                if (contador_cartas == 30)
                {
                    Contador_de_Cartas.BackColor = Color.Green;
                }
                if (contador_cartas > 30)
                {
                    Contador_de_Cartas.BackColor = Color.Red;
                }
                if (contador_cartas < 30)
                {
                    Contador_de_Cartas.BackColor = Color.Transparent;
                }
            }
            else
            {
                MessageBox.Show("El campo del nombre no puede estar vacio");
            }
            
        }


        private void Nombre_Jugador_Click(object sender, EventArgs e)
        {

        }

        private void NombreJugador__TextChanged(object sender, EventArgs e)
        {

        }

        private void Faccion_Carta_TextChanged(object sender, EventArgs e)
        {

        }

        private void Descripcion_Carta_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
