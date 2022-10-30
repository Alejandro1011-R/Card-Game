using System.Reflection.Emit;
namespace BattleCards
{
    
    public class Card
    {
        public int Id;
        public string Name;
        public string Description;
        public int Cost;
        public int Attack;
        public int Health;
        public int CardType;

        public Card()
        {
            Id = 0;
            Name = "Default";
            Description = "Default";
            Cost = 0;
            Attack = 0;
            Health = 0;
            CardType = 0;
        }

        public Card(int id, string name, string description, int cost, int attack, int health, int cardType)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            Attack = attack;
            Health = health;
            CardType = cardType;
        }

    }
}