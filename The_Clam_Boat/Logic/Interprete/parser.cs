using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;

namespace BattleCards
{
    public class parser
    {
        public tokenizer Tokens;  
        public parser(tokenizer tokens)
        {
            Tokens=tokens;
        }

        private string url = Directory.GetCurrentDirectory();

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
              
                
                
                /*if(Tokens.tokens[i].Tipo==TokenTypes.effect_quitapoder)
                {
                    var effect = new QuitarPower(int.Parse(Tokens.tokens[i].Info));
                    ParsedCard.Efectos.Add(effect);
                    continue;
                }*/

                if(Tokens.tokens[i].Tipo==TokenTypes.effect_quitapoder)
                {
                    var effect = new RemovePower(int.Parse(Tokens.tokens[i].Info));
                    var aux = new CompositionoftheEffects();
                    aux.effects.Add(effect);
                    var aux2= EffectChecks(i+1,aux);
                    ParsedCard.Effects.Add(aux);
                    i+=aux2;
                    continue;
                }
                if(Tokens.tokens[i].Tipo==TokenTypes.siemprecuando)
                {
                    if(Tokens.tokens[i-1].Tipo!=TokenTypes.effect_quitapoder&&Tokens.tokens[i-1].Tipo!=TokenTypes.effect_subepoder)
                    {
                        throw new Exception("syntax error");
                    }
                    ParsedCard.Passive=true;
                    var aux= ChecksCondition(i+1,ParsedCard.Effects[ParsedCard.Effects.Count()-1].checks);
                    i+=aux;
                    continue;
                }
                if(Tokens.tokens[i].Tipo==TokenTypes.cuando)
                {
                    if(Tokens.tokens[i-1].Tipo!=TokenTypes.effect_quitapoder&&Tokens.tokens[i-1].Tipo!=TokenTypes.effect_subepoder)
                    {
                        throw new Exception("syntax error");
                    }
                    var aux= ChecksCondition(i+1,ParsedCard.Effects[ParsedCard.Effects.Count()-1].checks); //Modifique lo q esta a continuacion pd: TC
                    ParsedCard.Effects[ParsedCard.Effects.Count() - 1].effects[ParsedCard.Effects[ParsedCard.Effects.Count() - 1].effects.Count() - 1].checks = ParsedCard.Effects[ParsedCard.Effects.Count() - 1].checks;
                    i +=aux;
                    continue;
                }
                


                if(Tokens.tokens[i].Tipo==TokenTypes.effect_subepoder)
                {
                    var effect = new PowerUp(int.Parse(Tokens.tokens[i].Info));
                    var aux = new CompositionoftheEffects();
                    aux.effects.Add(effect);
                    var aux2= EffectChecks(i+1,aux);
                    ParsedCard.Effects.Add(aux);
                    i+=aux2;
                    continue;
                }


            }
            switch (ParsedCard.Faction)
            {

                //@"D:\Escuela\Cards Project\The_Clam_Boat\images\
                case 1:
                    ParsedCard.image.Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images_card\\IMG-20221229-WA0057.jpg");
                    break;
                case 2:
                    ParsedCard.image.Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images_card\\IMG-20221229-WA0056.jpg");
                    break;
                case 3:
                    ParsedCard.image.Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images_card\\IMG-20221229-WA0055.jpg");
                    break;
                case 4:
                    ParsedCard.image.Image = Image.FromFile(url.Substring(0, url.Length - 10) + "\\images_card\\IMG-20221229-WA0054.jpg");
                    break;

            }
            return ParsedCard;
        }
        public int EffectChecks(int index, CompositionoftheEffects Effects)
        {
            if (index >=Tokens.tokens.Count())
            {
                return 0;
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.ComposicionDeEfectos)
            {
                if(index ==Tokens.tokens.Count()-1)
                {

                    throw new Exception("syntax error");
                }
                if(Tokens.tokens[index+1].Tipo==TokenTypes.effect_quitapoder||Tokens.tokens[index+1].Tipo==TokenTypes.effect_subepoder)
                {
                   
                    if(Tokens.tokens[index+1].Tipo==TokenTypes.effect_quitapoder)
                    {
                        var effect = new RemovePower(int.Parse(Tokens.tokens[index+1].Info));
                        Effects.effects.Add(effect);
                        var aux =EffectChecks(index+2, Effects);
                        return aux +2;
                    }
                
                    if(Tokens.tokens[index+1].Tipo==TokenTypes.effect_subepoder)
                    {
                        var effect = new PowerUp(int.Parse(Tokens.tokens[index+1].Info));
                        Effects.effects.Add(effect);
                       var aux= EffectChecks(index+2, Effects);
                        return aux +2;
                    }
                }
                else{
                    throw new Exception("syntax error");
                }

            }
            return 0;
        }
        public int ChecksCondition(int index,List<Checks> Conditions)
        {
            if (index >=Tokens.tokens.Count())
            {
                return 0;
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.condicionfaccion)
            {
                Conditions.Add(p => p.Faction==int.Parse(Tokens.tokens[index].Info));
                var aux= ChecksCondition(index+1, Conditions);
                return aux+1;
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.menospoder)
            {
                Conditions.Add(p => p.Power<int.Parse(Tokens.tokens[index].Info));
                 var aux= ChecksCondition(index+1, Conditions);
                return aux+1;
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.maspoder)
            {
                Conditions.Add(p => p.Power>int.Parse(Tokens.tokens[index].Info));
                var aux= ChecksCondition(index+1, Conditions);
                return aux+1;
                
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.igualpoder)
            {
                Conditions.Add(p => p.Power==int.Parse(Tokens.tokens[index].Info));
                var aux= ChecksCondition(index+1, Conditions);
                return aux+1;
                
            }
            return 0;
        }

    }
  
}