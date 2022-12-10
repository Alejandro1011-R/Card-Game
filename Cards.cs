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
        public int Armour;
        public int CardType;
        public int Faction;
        public int Colour;
        public bool Passive;
        

        public Card()
        {
            Id = 0;
            Name = "Default";
            Description = "Default";
            Power = 0;
            Armour = 0;
            CardType = 0;
            Faction=0;
            Colour=0;
            Passive = false;
            BasePower=0;
            
        }

        public Card(int id, string name, string description, int power, int armour, int cardType, int faction, int colour,bool passive)
        {
            Id = id;
            Name = name;
            Description = description;
            BasePower=power;
            Power = power;
            Armour = armour;
            CardType = cardType;
            Faction = faction;
            Colour =colour;
            Passive =passive;
            
        }

    }

    public class EffectCard 
    {
        
    }
}
