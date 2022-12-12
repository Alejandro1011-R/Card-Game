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
       
        public int CardType;
        public int Faction;
       
        public bool Passive;
        

        public Card()
        {
            Id = 0;
            Name = "Default";
            Description = "Default";
            Power = 0;
            CardType = 0;
            Faction=0;
            Passive = false;
            BasePower=0;
            
        }

        public Card(int id, string name, string description, int power, int cardType, int faction,bool passive)
        {
            Id = id;
            Name = name;
            Description = description;
            BasePower=power;
            Power = power;
           
            CardType = cardType;
            Faction = faction;
         
            Passive =passive;
            
        }

    }

    public class EffectCard 
    {
        
    }
}
