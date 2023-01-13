﻿using BattleCards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace The_Clam_Boat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SoundPlayer sound = new SoundPlayer();
            string url = Directory.GetCurrentDirectory();
            sound.SoundLocation = url.Substring(0, url.Length - 10) + "/audio true/opening.wav";
            sound.Load();
            
            //sound.Stop();
            InitializeComponent();
            InstanciarDataBase();
            sound.Play();
        }
        public bool Multiplayer = false;
        
        

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
                           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Salir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void JvsJ_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer();
            string url = Directory.GetCurrentDirectory();
            sound.SoundLocation = url.Substring(0, url.Length - 10) + "/audio true/menus.wav";
            sound.Load();
            sound.Play();
            Multiplayer = true;
            Seleccion_Cartas selecc = new Seleccion_Cartas();
            selecc.Cambiar_Jugador.Visible = true;
            selecc.Cambiar_Jugador.Enabled = true;
            selecc.DeckAlAzar.Visible = true;
            selecc.DeckAlAzar.Enabled = true;
            
            selecc.Multiplayer = Multiplayer;
            selecc.Show();
            


        }

        private void JvsPC_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer();
            string url = Directory.GetCurrentDirectory();
            sound.SoundLocation = url.Substring(0, url.Length - 10) + "/audio true/menus.wav";
            sound.Load();
            sound.Play();
            Multiplayer = false;
            Seleccion_Cartas selecc = new Seleccion_Cartas();
            selecc.DeckAlAzar.Visible = true;
            selecc.DeckAlAzar.Enabled = true;
            selecc.Multiplayer = Multiplayer;
            selecc.Show();
            
            

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer();
            string url = Directory.GetCurrentDirectory();
            sound.SoundLocation = url.Substring(0, url.Length - 10) + "/audio true/menus.wav";
            sound.Load();
            sound.Play();
            Crear_Cartas crear = new Crear_Cartas();
            crear.Show();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer();
            string url = Directory.GetCurrentDirectory();
            sound.SoundLocation = url.Substring(0, url.Length - 10) + "/audio true/menus.wav";
            sound.Load();
            sound.Play();
            Reglas_Juego reglas = new Reglas_Juego();
            reglas.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InstanciarDataBase()
        {
            if (CardDataBase.CardList.Count == 0)
            {
                new CardDataBase();
            }
        }
    }

    
}
