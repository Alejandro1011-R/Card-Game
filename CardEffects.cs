using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace BattleCards
{
    public abstract class effecto{

        public virtual void effect(GameRun game){}
    }

    class QuitarPower :effecto
    {
        private int CantPower;
        public QuitarPower(int power) 
        {
            CantPower=power; 
        }

        public override void effect(GameRun game)
        {
            if(GameRun.PlayerOpposing.Hand.Count()>0)
            {
                int id=int.Parse(Console.ReadLine()!);
                foreach(var carta in GameRun.PlayerOpposing.PlayerM)
                {
                    if(carta.Id==id)
                    {
                        carta.Power-=CantPower;
                        return;
                    }
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
        }
        public override void effect(GameRun game)
        {
            
            int id=int.Parse(Console.ReadLine()!);
            foreach(var carta in GameRun.PlayerInTurn.PlayerM)
            {
                if(carta.Id==id)
                {
                    carta.Power-=CantPower;
                    return;
                }
            }
        }

    }
}
