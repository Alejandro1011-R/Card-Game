namespace BattleCards
{
    public class TurnSystem
    {
        public bool IsYourTurn;
        public int YourTurn;
        public int EnemyTurn;
        

        void Start ()
        {
            IsYourTurn = true;
            YourTurn = 1;
            EnemyTurn = 0;
        }

        void Update ()
        {
            if (IsYourTurn)
            {
                //Escribir
        }
    }
}
}