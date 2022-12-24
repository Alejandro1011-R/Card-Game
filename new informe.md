
# Proyecto TCG.... Mauro, ale, el barco

muela introductoria, luego te la mando


---
## Clases
El proyecto se desarrolla principalmente dentro de dos carpetas, *Logic* y *Visual*. La primera de ellas cuenta con una biblioteca de clases, en la cual se agrupan tanto el apartado Game como el Interpreter, mientras que en la segunda se lleva a cabo el apartado visual


*  ## [Logic](Logic)
     * ***Game*** 
        * Bot
        * CardDataBase
        * Cards          
        * GameRun
        * IPlayer
        * Player

    *  ***Interpreter*** 
        * CardEffects
        * Condiciones
        * Parser
        * Tokenizer
        * Tokens
* ## [Visual](Visual)
     * Board
     * Menu
     * PrintGame
     

>Primeramente analizaremos la parte Logica del proyecto


Dentro de Game, ...

Sus principales clases son...(No pongas todas, señala las que veas más importante

---
>Con respecto al desarrollo del lenguaje para la implememtacion de nuevas cartas utilizamos las siguientes clases

(aqui si pon todo lo que puedas, esto es importante creo, puedes hacerlo de la siguiete manera)

# ***[CardEffects](https://github.com/AleTheCreation/Card-Game/blob/62c4d308109b356c1aa96be08cba380fabc6f1f2/Logic/Interpreter/CardEffects.cs)***

Dentro de cardeffect se desarrollan los efectos....

Creemos que por su importancia es importante desctacar el/los siguentes metodos

* Efect
>Muela sobre lo que hace efect
``` c#
 public override void effect(Player playerInTurn, Player playerOpposide)
        {
            if(comprobaciones.Count()==0)
            {
                int id=int.Parse(Console.ReadLine()!);
                foreach(var carta in playerInTurn.PlayerM)
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
                foreach(var carta in playerInTurn.PlayerM)
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
```

* y asi con cada metodo importante



