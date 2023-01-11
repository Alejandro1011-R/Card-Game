using BattleCards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Clam_Boat
{
    public partial class Crear_Cartas : Form
    {
        public Crear_Cartas()
        {
            InitializeComponent();
        }
        public string name = "";
        public string description = "";
        public int poder = 0;
        public int faccion = 1;
        public int faccion_afectadaN = 0;
        public int faccion_afectadaP = 0;
        public int quita_poder = 0;
        public int sube_poder = 0;
        public int mas_poder_queN = 0;
        public int mas_poder_queP = 0;
        public int menos_poder_queN = 0;
        public int menos_poder_queP = 0;
        public int igual_poder_queN = 0;
        public int igual_poder_queP = 0;

        

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CancelarCreacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void faction_TextChanged(object sender, EventArgs e)
        {

        }

        private void CrearCarta_Click(object sender, EventArgs e)
        {

            
            name = Name_Card.Text;
            description = Decription_Card.Text;
           // poder = int.Parse(Power_Card.Text);
            _ = int.TryParse(Power_Card.Text, out poder) ? poder : 0;
            _ = int.TryParse(Faction_Card.Text, out faccion) ? faccion : 1;
            _ = faccion == 0 || faccion > 4 ? faccion : 1;
            _ = int.TryParse(faction.Text, out faccion_afectadaN) ? faccion_afectadaN : 0;
            _ = faccion_afectadaN > 4 ? faccion : 0;
            _ = int.TryParse(faction_a.Text, out faccion_afectadaP) ? faccion_afectadaP : 0;
            _ = faccion_afectadaP > 4 ? faccion : 0;
            _ = int.TryParse(Quitar_poder.Text, out quita_poder) ? quita_poder : 0;
            _ = int.TryParse(Subir_Poder.Text, out sube_poder) ? sube_poder : 0;
            _ = int.TryParse(Mas_Poder_que.Text, out mas_poder_queN) ? mas_poder_queN : 0;
            _ = int.TryParse(Mas_poder_que_a.Text, out mas_poder_queP) ? mas_poder_queP : 0;
            _ = int.TryParse(Menos_Poder_que.Text, out menos_poder_queN) ? menos_poder_queN : 0;
            _ = int.TryParse(Menos_Poder_que_a.Text, out menos_poder_queP) ? menos_poder_queP : 0;
            _ = int.TryParse(Igual_Poder_que.Text, out igual_poder_queN) ? igual_poder_queN : 0;
            _ = int.TryParse(Igual_Poder_que_a.Text, out igual_poder_queP) ? igual_poder_queP : 0;

            /*faccion_afectadaN = int.Parse(faction.Text);
            faccion_afectadaP = int.Parse(faction_a.Text);
            quita_poder = int.Parse(Quitar_poder.Text);
            
            sube_poder = int.Parse(Subir_Poder.Text);
            mas_poder_queN = int.Parse(Mas_Poder_que.Text);
            mas_poder_queP = int.Parse(Mas_poder_que_a.Text);
            menos_poder_queN = int.Parse(Menos_Poder_que.Text);
            menos_poder_queP = int.Parse(Menos_Poder_que_a.Text);
            igual_poder_queN = int.Parse(Igual_Poder_que.Text);
            igual_poder_queP = int.Parse(Igual_Poder_que_a.Text);
            
            */



            string card = '(' + name + ')' + '[' + description + ']' + " poder " + poder + " faccion " + faccion;

            if (quita_poder != 0 || sube_poder != 0) card += " que";
            int index = card.Length - 1;



            if (quita_poder != 0)
            {
                card += " QuitePoder " + quita_poder;
                index = card.Length - 1;
                _ = menos_poder_queN == 0 ? card : card += " MenosPoderQue " + menos_poder_queN;
                _ = mas_poder_queN == 0 ? card : card += " MasPoderQue " + mas_poder_queN;
                _ = igual_poder_queN == 0 ? card : card += " IgualPoderQue " + igual_poder_queN;
                _ = faccion_afectadaN == 0 ? card : card += " faccion " + faccion_afectadaN;
                if (card.Length - 1 != index) card.Insert(index, " cuando");
            }
            if (sube_poder != 0)
            {

                card += " SubePoder " + sube_poder;
                index = card.Length - 1;
                _ = menos_poder_queP == 0 ? card : card += " MenosPoderQue " + menos_poder_queP;
                _ = mas_poder_queP == 0 ? card : card += " MasPoderQue " + mas_poder_queP;
                _ = igual_poder_queP == 0 ? card : card += " IgualPoderQue " + igual_poder_queP;
                _ = faccion_afectadaP == 0 ? card : card += " faccion " + faccion_afectadaP;
                if (card.Length - 1 != index) card.Insert(index, " cuando");
            }

            /*+ "cuando" 
                + " MenosPoderQue" + menos_poder_queN 
                + "MasPoderQue" + mas_poder_queN 
                + "IgualPoderQue" + igual_poder_queN 
                + "faccion" + faccion_afectadaN 
                + "SubePoder" + sube_poder 
                + "cuando" 
                + "MasPoderQue" + mas_poder_queP 
                + "MenosPoderQue" + menos_poder_queP 
                + "IgualPoderQue" + igual_poder_queN 
                + "faccion" + faccion_afectadaP;*/
            
           
           Card a = CardDataBase.createCard(card);
        }
    }
}
