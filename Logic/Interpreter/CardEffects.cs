using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace BattleCards
{
    public abstract class effecto{
        public List<Comprobacion> comprobaciones;
        public virtual void effect(GameRun game){}
    }

    public class ComposicionDeEfectos :effecto
    {
        public List<effecto> effects;
        public ComposicionDeEfectos()
        {
            effects = new List<effecto>();
            comprobaciones = new List<Comprobacion>();
        }
        public override void effect(GameRun game)
        {
            foreach( var effect in effects)
            {
                effect.effect(game);
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

        public override void effect(GameRun game)
        {
            if(comprobaciones.Count()==0)
            {
                if(GameRun.PlayerOpposide.Hand.Count()>0)
                {
                    int id=int.Parse(Console.ReadLine()!);
                    foreach(var carta in GameRun.PlayerOpposide.PlayerM)
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
                foreach(var carta in GameRun.PlayerOpposide.PlayerM)
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
        public override void effect(GameRun game)
        {
            if(comprobaciones.Count()==0)
            {
                int id=int.Parse(Console.ReadLine()!);
                foreach(var carta in GameRun.PlayerInTurn.PlayerM)
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
                foreach(var carta in GameRun.PlayerInTurn.PlayerM)
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
