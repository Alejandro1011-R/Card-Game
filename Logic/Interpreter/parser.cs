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
                    var aux = new ComposicionDeEfectos();
                    aux.effects.Add(effect);
                    var aux2=comprobacionesEfecto(i+1,aux);
                    ParsedCard.Efectos.Add(aux);
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
                    var aux=comprobacionesCondicion(i+1,ParsedCard.Efectos[ParsedCard.Efectos.Count()-1].comprobaciones);
                    i+=aux;
                    continue;
                }
                if(Tokens.tokens[i].Tipo==TokenTypes.siemprecuando)
                {
                    if(Tokens.tokens[i-1].Tipo!=TokenTypes.effect_quitapoder&&Tokens.tokens[i-1].Tipo!=TokenTypes.effect_subepoder)
                    {
                        throw new Exception("syntax error");
                    }
                    var aux=comprobacionesCondicion(i+1,ParsedCard.Efectos[ParsedCard.Efectos.Count()-1].comprobaciones);
                    i+=aux;
                    continue;
                }
                


                if(Tokens.tokens[i].Tipo==TokenTypes.effect_subepoder)
                {
                    var effect = new SubirPoder(int.Parse(Tokens.tokens[i].Info));
                    var aux = new ComposicionDeEfectos();
                    aux.effects.Add(effect);
                    var aux2=comprobacionesEfecto(i+1,aux);
                    ParsedCard.Efectos.Add(aux);
                    i+=aux2;
                    continue;
                }


            }
            return ParsedCard;
        }
        public int comprobacionesEfecto(int index,ComposicionDeEfectos efectos)
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
                        var effect = new QuitarPower(int.Parse(Tokens.tokens[index+1].Info));
                        efectos.effects.Add(effect);
                        var aux=  comprobacionesEfecto(index+2,efectos);
                        return aux +2;
                    }
                
                    if(Tokens.tokens[index+1].Tipo==TokenTypes.effect_subepoder)
                    {
                        var effect = new SubirPoder(int.Parse(Tokens.tokens[index+1].Info));
                        efectos.effects.Add(effect);
                       var aux=  comprobacionesEfecto(index+2,efectos);
                        return aux +2;
                    }
                }
                else{
                    throw new Exception("syntax error");
                }

            }
            return 0;
        }
        public int comprobacionesCondicion(int index,List<Comprobacion> condiciones)
        {
            if (index >=Tokens.tokens.Count())
            {
                return 0;
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.condicionfaccion)
            {
                condiciones.Add(p => p.Faction==int.Parse(Tokens.tokens[index].Info));
                var aux= comprobacionesCondicion(index+1,condiciones);
                return aux+1;
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.menospoder)
            {
                condiciones.Add(p => p.Power<int.Parse(Tokens.tokens[index].Info));
                 var aux= comprobacionesCondicion(index+1,condiciones);
                return aux+1;
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.maspoder)
            {
                condiciones.Add(p => p.Power>int.Parse(Tokens.tokens[index].Info));
                var aux= comprobacionesCondicion(index+1,condiciones);
                return aux+1;
                
            }
            if(Tokens.tokens[index].Tipo==TokenTypes.igualpoder)
            {
                condiciones.Add(p => p.Power==int.Parse(Tokens.tokens[index].Info));
                var aux= comprobacionesCondicion(index+1,condiciones);
                return aux+1;
                
            }
            return 0;
        }

    }
  
}