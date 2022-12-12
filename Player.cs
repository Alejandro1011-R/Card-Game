using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    public class Player
    {
       
        private string Name;
        private int Health;
        public Player(string name)
        {
            Start();
            Name = name;
            Health = 5;
            PlayerM = new List<Card>();
            PlayerR = new List<Card>();
            Cementery = new List<Card>();
            

            
            
            Pass = false;
        }

       
        //         public List<Card> Stuffle(List<Card> Deck)
        // {
        //     Random rnd = new Random();
        //     for (var i = 0; i < Deck.Count; i++)
        //     {
        //         AuxDeck = Deck;
        //         AuxDeck[0] = Deck[i];
        //         int RandomIndex = rnd.Next(0, Deck.Count);
        //         Deck[i] = Deck[RandomIndex];
        //         Deck[RandomIndex] = AuxDeck[0];

                
        //     }
        // return Deck;

        // }
        public List<Card> PlayerM; //melee row// fila de ataque cuerpo a cuerpo (max 9)
        public List<Card> PlayerR; //range row// ataque larga distancia (max 9)

        public List<Card> AuxDeck = new List<Card>();
        public List<Card> Cementery = new List<Card>();

        public List<Card> Hand = new List<Card>(); 
        public List<Card> Deck = new List<Card>();
        public bool Pass;

        public int DeckSize;
        public int HandSize;
        public int XCard;



        
        public string GetName()
        {
            return Name;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetHand()
        {
            return Hand.Count;
        } 

public List<Card> GetHands()
        {
            return Hand;
        }
        public int GetLife()
        {
            return Health;
        }

        public int GetDeckCount()
        {
            return Deck.Count;
        }

        public void Start()
        {
            var CardDB = CardDataBase.CardList.ToList();
            DeckSize = 15;
            HandSize = 5;
            XCard = 0;
            Random rnd = new Random();
            for (var i = 0; i < DeckSize ; i++)
            {
            
                XCard = rnd.Next(0, CardDB.Count);
                Deck.Add(CardDB[XCard]);
                CardDB.RemoveAt(XCard);
                
            }
        }
      public  void Update() {   //cambio de turno

            if (Deck.Count == DeckSize){

                Stuffle();
                for (var i = 0; i < HandSize; i++)
                {
                    DrawCard();
                }
            }
            else {
                
                DrawCard();

            }
            
        }

        public void Stuffle()
        {
            Random rnd = new Random();
            var AuxCard = new Card();
            for (var i = 0; i < Deck.Count; i++)
            {
                
                AuxCard = Deck[i];
                int RandomIndex = rnd.Next(0, Deck.Count);
                Deck[i] = Deck[RandomIndex];
                Deck[RandomIndex] = AuxCard;

                
            }
        

        }
       

        public void DrawCard()
        {
            if (Deck.Count > 0)
            {
                Hand.Add(Deck[0]);
                Deck.RemoveAt(0);
            }
        }

    
    }   
}