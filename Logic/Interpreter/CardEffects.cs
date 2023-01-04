using System.ComponentModel.DataAnnotations;
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
    public abstract class effecto{
        public List<Comprobacion> comprobaciones;
        public virtual void effect(Player playerInTurn, Player playerOpposide){}
    }

    public class ComposicionDeEfectos :effecto
    {
        public List<effecto> effects;
        public ComposicionDeEfectos()
        {
            effects = new List<effecto>();
            comprobaciones = new List<Comprobacion>();
        }
        public override void effect(Player playerInTurn, Player playerOpposide)
        {
            foreach( var effect in effects)
            {
                effect.effect(playerInTurn, playerOpposide);
            }
        }
    }
    class QuitarPower :effecto
    {
        private int CantPower;
        public QuitarPower(int power) 
        {
            CantPower=power;
            comprobaciones = new List<Comprobacion>(); 
        }

        public override void effect(Player playerInTurn, Player playerOpposide)
        {
            if(comprobaciones.Count()==0)
            {
                if(playerOpposide.Hand.Count()>0)
                {
                    
                    int id=int.Parse(Console.ReadLine()!);
                    foreach(var carta in playerOpposide.PlayerM)
                    {
                        if(carta.Id==id)
                        {
                            carta.Power-=CantPower;
                            return;
                        }
                    }
                }
            }
            else
            {
                foreach(var carta in playerOpposide.PlayerM)
                {
                    for(int i=0;i<comprobaciones.Count();i++)
                    {
                        if(!comprobaciones[i](carta))
                        {
                            goto next;
                        }
                    }
                    carta.Power-=CantPower;
                    next:;

                }
            }

        }

    }

    class SubirPoder :effecto
    {
        private int CantPower;

        public SubirPoder(int power)
        {
            CantPower=power;
            comprobaciones = new List<Comprobacion>(); 
        }
        public override void effect(Player playerInTurn, Player playerOpposide)
        {
            if(comprobaciones.Count()==0)
            {
                    
                    int id=int.Parse(Console.ReadLine()!);
                    foreach(var carta in playerInTurn.PlayerM)
                    {
                        if(carta.Id==id)
                        {
                            carta.Power+=CantPower;
                            return;
                        }
                    }
                
                
               
            }
            else
            {
                foreach(var carta in playerInTurn.PlayerM)
                {
                    for(int i=0;i<comprobaciones.Count();i++)
                    {
                        if(!comprobaciones[i](carta))
                        {
                            goto next;
                        }
                    }
                    carta.Power+=CantPower;
                    next:;

                }
            }
        }

    }
}
