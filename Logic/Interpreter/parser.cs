namespace BattleCards
{
    public class parser
    {
        public tokenizer Tokens;  
        public parser(tokenizer tokens)
        {
            Tokens=tokens;
        }

        public Card CreateCard()
        {
            var ParsedCard= new Card();
            for(int i=0;i<Tokens.tokens.Count();i++)
            {
                if(Tokens.tokens[i].Tipo==TokenTypes.name)
                {

                    ParsedCard.Name=Tokens.tokens[i].Info;
                    continue;

                }
                
                if(Tokens.tokens[i].Tipo==TokenTypes.info)
                {
                    ParsedCard.Description=Tokens.tokens[i].Info;
                    continue;
                }
                if(Tokens.tokens[i].Tipo==TokenTypes.power)
                {
                    ParsedCard.BasePower=int.Parse(Tokens.tokens[i].Info);
                    ParsedCard.Power=ParsedCard.BasePower;
                    continue;
                }
                
                if(Tokens.tokens[i].Tipo==TokenTypes.faction)
                {
                    ParsedCard.Faction=int.Parse(Tokens.tokens[i].Info);
                    continue;
                }
                
                if(Tokens.tokens[i].Tipo==TokenTypes.effect_quitapoder)
                {
                    var effect = new QuitarPower(int.Parse(Tokens.tokens[i].Info));
                    ParsedCard.Efectos.Add(effect);
                    continue;
                }

                if(Tokens.tokens[i].Tipo==TokenTypes.effect_quitapoder)
                {
                    var effect = new QuitarPower(int.Parse(Tokens.tokens[i].Info));
                    ParsedCard.Efectos.Add(effect);
                    continue;
                }
                
                if(Tokens.tokens[i].Tipo==TokenTypes.effect_subepoder)
                {
                    var effect = new SubirPoder(int.Parse(Tokens.tokens[i].Info));
                    ParsedCard.Efectos.Add(effect);
                    continue;
                }


            }
            return ParsedCard;
        }


    }
    // class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         var test =new tokenizer("(Salvaje)[Una carta super tixa que baja lo ultimo que trajo el barco] poder 5 que SubePoder 2");
    //         for(int i=0 ; i<test.tokens.Count();i++)
    //         {
    //             Console.WriteLine(test.tokens[i].Tipo + "  --  " + test.tokens[i].Info);
    //         }
    //     }
    // }
}