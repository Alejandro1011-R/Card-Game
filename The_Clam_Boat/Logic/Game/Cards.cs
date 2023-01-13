using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Windows.Forms;

namespace BattleCards
{
    public class Card
    {
        public int Id;
        public string Name;
        public string Description;
        public int BasePower;
        public int Power;
        public int Faction;
        public PictureBox image;
        
        public bool Passive;
        public List<Effect> Effects;
        

        public Card()
        {
            Id = 0;
            Name = "Default";
            Description = "Default";
            Power = 0;
            Faction=0;
            image = new PictureBox();
            string url = Directory.GetCurrentDirectory();
            image.Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images_card\\IMG-20221229-WA0057.jpg");
            Passive = false;
            BasePower=0;
            Effects = new List<Effect>();
            
        }

        
    }

}
