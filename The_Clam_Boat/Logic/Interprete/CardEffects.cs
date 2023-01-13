using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace BattleCards
{

    /*
    	monster     Neutral	   Nilfgard	  Scoia'tael
monster 	0	      -1          1	        -1
Neutral  	1          0         -1          1                     en total hay 60 cartas, 15 por cada faccion, de ellas 8 con efectos y 7 sin efectos
Nilfgard   -1	       1 	      0	        -1
Scoia'tael	1	      -1          1          0
 */
    public abstract class Effect
    {
        public List<Checks> checks;
        public List<Effect> effects; //Puse esto aqui en vez de en comp de efectos pd: TC
        public virtual void effect(Player playerInTurn, Player playerOpposide){}
    }

    public class CompositionoftheEffects : Effect
    {
        
        public CompositionoftheEffects()
        {
            effects = new List<Effect>();
            checks = new List<Checks>();
        }
        public override void effect(Player playerInTurn, Player playerOpposide)
        {
            foreach( var effect in effects)
            {
                effect.effect(playerInTurn, playerOpposide);
            }
        }
    }
    class RemovePower : Effect
    {
        private int CountPower;
        public RemovePower(int power) 
        {
            CountPower=power;
            checks = new List<Checks>(); 
        }

        public override void effect(Player playerInTurn, Player playerOpposide)
        {

            if(checks.Count()==0)
            {
                if(playerOpposide.Hand.Count()>0)
                {

                    int id = 0;//int.Parse(Console.ReadLine()!);
                    foreach(var card in playerOpposide.PlayerM)
                    {
                        if(card.Id==id)
                        {
                            card.Power-=CountPower;
                            return;
                        }
                    }
                }
            }
            else
            {
                foreach(var card in playerOpposide.PlayerM)
                {
                    for(int i=0;i< checks.Count();i++)
                    {
                        if(!checks[i](card))
                        {
                            goto next;
                        }
                    }
                    card.Power-=CountPower;
                    next:;

                }
            }

        }

    }



    class PowerUp : Effect
    {
        private int CountPower;

        
        public PowerUp(int power)
        {
            CountPower=power;
            checks = new List<Checks>(); 
        }
        public override void effect(Player playerInTurn, Player playerOpposide)
        {
            if(checks.Count()==0)
            {

                int id = 0;//int.Parse(Console.ReadLine()!);
                    foreach(var card in playerInTurn.PlayerM)
                    {
                        if(card.Id==id)
                        {
                            card.Power+=CountPower;
                            return;
                        }
                    }
                
                
               
            }
            else
            {
                foreach(var card in playerInTurn.PlayerM)
                {
                    for(int i=0;i< checks.Count();i++)
                    {
                        if(!checks[i](card))
                        {
                            goto next;
                        }
                    }
                    card.Power+=CountPower;
                    next:;

                }
            }
        }

    }
}
