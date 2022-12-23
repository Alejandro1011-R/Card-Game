namespace BattleCards
{
    public class tokenizer
    {
        public string Text;
        public string [] TextoLimpio;
        public List<Tokens> tokens;
        public tokenizer(string text)
        {
            tokens = new List<Tokens>();
            Text=text;
            GetName();
            GetInfo();
            TextoLimpio=TextLimp(Text);
            GetStatsAndEffects();

        }
        private void GetName()
        {
            var aux =getText('(',')',Text);
            tokens.Add(new Tokens(TokenTypes.name,aux));
        }
        private void GetInfo()
        {
            var aux = getText('[',']',Text);
            tokens.Add(new Tokens(TokenTypes.info,aux));
            Text= Text.Substring(Text.IndexOf(']')+1, Text.Length-Text.IndexOf(']')-1);
        }

        private void GetStatsAndEffects()
        {
            int ControlPower=0;
            int ControlFaction=0;
            for(int i=0;i<TextoLimpio.Length;i++)
            {
                if(TextoLimpio[i]=="poder")
                {
                    ControlPower++;
                    if(int.TryParse(TextoLimpio[i+1],out int intValue))
                    {
                        var poder = new Tokens(TokenTypes.power, TextoLimpio[i+1]);
                        tokens.Add(poder);
                        i++;
                        continue;
                    }
                    else{ 
                        throw new Exception("power must receive an integer");
                    }   
                }
                
                if(TextoLimpio[i]=="faccion")
                {
                    ControlFaction++;
                    if(int.TryParse(TextoLimpio[i+1],out int intValue))
                    {
                        if(0 < int.Parse(TextoLimpio[i+1]) && int.Parse(TextoLimpio[i+1]) <= 4)
                        {
                            var faction = new Tokens(TokenTypes.faction, TextoLimpio[i+1]);
                            tokens.Add(faction);
                            i++;
                            continue;
                        }
                    }
                    else{ 
                        throw new Exception("faccion must receive an integer");
                    }
                    
                }
                if(ControlFaction>1||ControlPower>1)
                {
                    throw new Exception("syntax error");
                }
                if(TextoLimpio[i]=="que")
                {
                    
                    for(int j=i+1;j<TextoLimpio.Length;j++)
                    {
                        if(TextoLimpio[j]=="QuitePoder")
                        {
                            if(int.TryParse(TextoLimpio[j+1],out int intValue))
                            {
                                var quitapoder= new Tokens(TokenTypes.effect_quitapoder,TextoLimpio[j+1]);
                                tokens.Add(quitapoder);
                                j++;
                                continue;
                            }
                            else{
                                throw new Exception("QuitePoder must receive an integer");
                            }

                        }
                        if(TextoLimpio[j]=="SubePoder")
                        {
                            if(int.TryParse(TextoLimpio[j+1],out int intValue))
                            {
                                var subepoder= new Tokens(TokenTypes.effect_subepoder,TextoLimpio[j+1]);
                                tokens.Add(subepoder);
                                j++;
                                continue;
                            }
                            else{
                                throw new Exception("QuitePoder must receive an integer");
                            }
                        }
                        throw new Exception("syntax error");

                    }
                    break;
                }
                throw new Exception ("syntax error");
            }
        }
        private string getText(char beguining, char end,string text)
        {
            int startInfo=0, endInfo=0;
            for(int i=0;i<text.Length;i++)
            {
                if(text[i]==beguining)
                {
                    startInfo= i;
                    for(int j=i+1;j<text.Length;j++)
                    {
                        if(Text[j]==end)
                        {
                            endInfo=j;
                            break;
                        }
                        if(j==text.Length-1)
                        {
                            throw new Exception("syntax error");
                        }
                    }
                    break;
                }
            }
            if(endInfo==0)
            {
                return string.Empty;
            }

            return text.Substring(startInfo+1,endInfo-startInfo-1);

        }

        public static string[] TextLimp(string expr)
        {
            char[] cosasraras = new char[]{' '}; 
            
            string[] subsequence = expr.Split(cosasraras , System.StringSplitOptions.RemoveEmptyEntries);

            string[] sincosasraras= new string[subsequence.Length];
            for(int j=0;j<sincosasraras.Length;j++)
            {
                sincosasraras[j]= subsequence[j];
            }

            return sincosasraras;
        
        }   
    }
}