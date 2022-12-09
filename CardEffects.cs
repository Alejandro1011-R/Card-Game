using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
namespace BattleCards
{
    public abstract class Effect
    {
        public virtual void effect(Player player1, Player player2, int poscard, int row){}
    }
//row :fila en la que se encuentra la carta sobre la que carta(opcional), 1 o 2.
//poscard carta sobre la que cae el efecto (opcional).
//player1 el jugador que ejecuta el efecto
// sobre el que cae(excepto cuando el efecto es sobre el propio jugador o sus propias cartas)
    public class Geralt :Effect{
    
    public override void effect(Player player1, Player player2, int poscard, int row){

        for(int i=0;i<Math.Max(player2.PlayerM.Count(),player2.PlayerR.Count());i++)
        {
            if(player2.PlayerR[i].Power>=9)
            {
                player2.PlayerR.RemoveAt(i);
                break;
            }   
            if(player2.PlayerM[i].Power>=9)
            {
                player2.PlayerM.RemoveAt(i);
                break;
            }
        }
    }
    
    }

    public class LugosElLoco :Effect{
        public override void effect(Player player1, Player player2, int poscard, int row){
            int count =0;
            
            for(int i=0, j=0;i<player1.PlayerM.Count();i++)
            {
                if(player1.PlayerM[i].BasePower>player1.PlayerM[i].Power)
                {
                    count++;
                }
                
            }
            for(int i=0;i<player1.PlayerR.Count();i++)
            {
                if(player1.PlayerR[i].BasePower>player1.PlayerR[i].Power)
                {
                    count++;
                }
            }

            count = 2*count;
            if(row==1){
                if(player2.PlayerM[poscard].Power-count<=0)
                {
                    player2.PlayerM.RemoveAt(poscard);
                }
                else
                {
                    player2.PlayerM[poscard].Power-=count;
                }
                return;
            }
            if(row==2){
                if(player2.PlayerR[poscard].Power-count<=0)
                {
                    player2.PlayerR.RemoveAt(poscard);
                }
                else
                {
                    player2.PlayerR[poscard].Power-=count;
                }
                return;
            }

            return;
        }
    }

    public class Dorregaray : Effect{
        public override void effect(Player player1, Player player2, int poscard, int row){
            
            if(row==1)player2.PlayerM[poscard].Passive=false;
            else{player2.PlayerR[poscard].Passive=false;}
            return;
        }
    }
}