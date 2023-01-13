using System;
using System.Collections.Generic;
using System.Linq;
//using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace BattleCards
{
    public class Player : IPlayer
    {
        public int DeckSize = 30;
        public int HandSize = 5;
        public Card[,] BoardSeccion = new Card[2,5];
        public Player(string name)
        {
            Deck = new List<Card>();
            Hand = new List<Card>();

           
            Name = name;
            RaundsWon = 0;
            TotalRounds = RaundsWon + "/5";
            PlayerM = new List<Card>(5);
            Graveyard = new List<Card>();
            PassRound = false;
            PlayerIsaBot = false;

            //recoorrer BoardSeccion
            for (int i = 0; i < BoardSeccion.GetLength(0); i++)
            {
                for (int j = 0; j < BoardSeccion.GetLength(1); j++)
                {
                    BoardSeccion[i, j] = null;
                }

            }
            
        }
        /// <summary>
        /// LLeva el conteo del power de las cartas en el tablero
        /// </summary>
      
        public void Point(List<Card> PlayerM)
        {
            int point=0;
            for (var i = 0; i < PlayerM.Count; i++)
            {
                point += PlayerM[i].Power;
            }
            if (point <= 0)
                point = 0;
            TotalPoint = point;
        }
        /// <summary>
        /// Reinicia el contador de power
        /// </summary>
        public void ResetPoint()
        {
            TotalPoint = 0;
        }
        
        /// <summary>
        /// Actualiza las rondas ganadas
        /// </summary>
        public void Update()
        {
            TotalRounds = RaundsWon + "/5";
        }
        /// <summary>
        /// Comprueba si hay que quitar o poner la carta en el deck
        /// </summary>

        public void CreateDeck(Card card, bool PutOrRemove)
        {
            if (PutOrRemove)
            {
                if (!Deck.Contains(card))
                {
                    Deck.Add(card);
                }
                
            }
            else
            {
                if (Deck.Contains(card))
                {
                    Deck.Remove(card);
                }
               
            }
        }
        /// <summary>
        /// Forma el deck llamando a CardDataBase.CardList
        /// </summary>
        public void GetDeck()
        {
            var CardDB = CardDataBase.CardList.ToList();
            int XCard = 0;
            Random rnd = new Random();
            for (var i = 0; i < DeckSize; i++)
            {
                XCard = rnd.Next(0, CardDB.Count);
                Deck.Add(CardDB[XCard]);
                CardDB.RemoveAt(XCard);
            }
        }

      //  internal void Point(List<Card> playerM)
        //{
         //   throw new NotImplementedException();
        //}
    }
}
