using System.Reflection.Emit;

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
        // Faction 1 : Monstruos
        // Faction 2 : Reinos del Norte
        // Faction 3 : Nilfgaard
        // Faction 4 : Scoia’tael
        public bool Passive;
        public List<effecto> Efectos;
        

        public Card()
        {
            Id = 0;
            Name = "Default";
            Description = "Default";
            Power = 0;
            Faction=0;
            Passive = false;
            BasePower=0;
            Efectos=new List<effecto>();
            
        }
    }

}
