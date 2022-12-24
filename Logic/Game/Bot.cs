namespace BattleCards
{
    public class Writer_02
    {
       public static bool PassTurn(Player player, Player Bot)
       {
            if(player.PassRound==true)
            {      
                if(Bot.TotalPoint>player.TotalPoint)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
       }
        public static int BestcardIndex(Player player1)
        {
        
            int bestCardIndex = 0;
            int bestCardValue = 0;
            for (int i = 0; i < player1.Hand.Count; i++)
            {
                if (player1.Hand[i].Power > bestCardValue)
                {
                    bestCardValue = player1.Hand[i].Power;
                    bestCardIndex = i;
                }
            }
            return bestCardIndex;
        }

        
    }
}
