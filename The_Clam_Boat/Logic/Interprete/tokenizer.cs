using System;
using System.Collections.Generic;
using System.Windows;

namespace BattleCards
{
    public class tokenizer
    {
        public string Text;
        public string [] CleanText;
        public List<Tokens> tokens;
        public tokenizer(string text)
        {
            tokens = new List<Tokens>();
            Text=text;
            GetName();
            GetInfo();
            CleanText = TextLimp(Text);
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
            Text= Text.Substring(Text.IndexOf(']')+1);
        }

        private void GetStatsAndEffects()
        {
            int ControlPower=0;
            int ControlFaction=0;
            for(int i=0;i< CleanText.Length;i++)
            {
                if(CleanText[i]=="poder")
                {
                    ControlPower++;
                    if(int.TryParse(CleanText[i+1],out int intValue))
                    {
                        var power = new Tokens(TokenTypes.power, CleanText[i+1]);
                        tokens.Add(power);
                        i++;
                        continue;
                    }
                    else{ 
                        throw new Exception("power must receive an integer");
                    }   
                }
                
                if(CleanText[i]=="faccion")
                {
                    ControlFaction++;
                    if(int.TryParse(CleanText[i+1],out int intValue))
                    {
                        if(0<int.Parse(CleanText[i+1])&&int.Parse(CleanText[i+1])<=4)
                        {
                            var faction = new Tokens(TokenTypes.faction, CleanText[i+1]);
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
                if(CleanText[i]=="que")
                {
                    
                    for(int j=i+1;j< CleanText.Length;j++)
                    {
                        if(CleanText[j]=="QuitePoder")
                        {
                            if(j== CleanText.Length-1)
                            {
                                throw new Exception("QuitePoder must receive an integer");
                            }
                            if(int.TryParse(CleanText[j+1],out int intValue))
                            {
                                var RemovePower = new Tokens(TokenTypes.effect_quitapoder, CleanText[j+1]);
                                tokens.Add(RemovePower);
                                j++;
                                continue;
                            }
                            else{
                                throw new Exception("QuitePoder must receive an integer");
                            }

                        }
                        if(CleanText[j]=="y")
                        {
                            var conjunction = new Tokens(TokenTypes.ComposicionDeEfectos,"");
                            tokens.Add(conjunction);
                            continue;
                        }

                        if(CleanText[j]=="cuando")
                        {
                            var Conditions = new Tokens(TokenTypes.cuando,"");
                            tokens.Add(Conditions);
                            continue;
                        }
                        if(CleanText[j]=="siemprecuando")
                        {
                            var Conditions = new Tokens(TokenTypes.siemprecuando,"");
                            tokens.Add(Conditions);
                            continue;
                        }
                        if(CleanText[j]=="MasPoderQue")
                        {
                            if(j== CleanText.Length-1)
                            {
                                throw new Exception("MasPoderQue must receive an integer");
                            }
                            if(int.TryParse(CleanText[j+1],out int intValue))
                            {
                                var MorePower= new Tokens(TokenTypes.maspoder, CleanText[j+1]);
                                tokens.Add(MorePower);
                                j++;
                                continue;

                            }
                            else{
                                throw new Exception("MasPoderQue must receive an integer");
                            }

                        }
                        if(CleanText[j]=="PoderIgual")
                        {
                            if(j== CleanText.Length-1)
                            {
                                throw new Exception("PoderIgual must receive an integer");
                            }
                            if(int.TryParse(CleanText[j+1],out int intValue))
                            {
                                var EqualPower= new Tokens(TokenTypes.igualpoder, CleanText[j+1]);
                                tokens.Add(EqualPower);
                                j++;
                                continue;
                            }
                            else{
                                throw new Exception("PoderIgual must receive an integer");
                            }

                        }
                        if(CleanText[j]=="MenosPoderQue")
                        {
                            if(j== CleanText.Length-1)
                            {
                                throw new Exception("MenosPoderQue must receive an integer");
                            }
                            if(int.TryParse(CleanText[j+1],out int intValue))
                            {
                                var LessPower= new Tokens(TokenTypes.menospoder, CleanText[j+1]);
                                tokens.Add(LessPower);
                                j++;
                                continue;
                            }
                            else{
                                throw new Exception("MenosPoderQue must receive an integer");
                            }

                        }
                        if(CleanText[j]=="faccion")
                        {
                            if(j== CleanText.Length-1)
                            {
                                throw new Exception("faccion must receive an integer");
                            }
                            if(int.TryParse(CleanText[j+1],out int intValue))
                            {
                                var factionconditions = new Tokens(TokenTypes.condicionfaccion, CleanText[j+1]);
                                tokens.Add(factionconditions);
                                j++;
                                continue;
                            }
                            else{
                                throw new Exception("faccion must receive an integer");
                            }

                        }
                        
                        if(CleanText[j]=="SubePoder")
                        {
                            if(j== CleanText.Length-1)
                            {
                                throw new Exception("SubePoder must receive an integer");
                            }
                            if(int.TryParse(CleanText[j+1],out int intValue))
                            {
                                var PowerUp = new Tokens(TokenTypes.effect_subepoder, CleanText[j+1]);
                                tokens.Add(PowerUp);
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
            char[] RareCharacters = new char[]{' '}; 
            
            string[] subsequence = expr.Split(RareCharacters, System.StringSplitOptions.RemoveEmptyEntries);

            string[] LeesRareCharacters = new string[subsequence.Length];
            for(int j=0;j< LeesRareCharacters.Length;j++)
            {
                LeesRareCharacters[j]= subsequence[j];
            }

            return LeesRareCharacters;
        
        }   
    }
}