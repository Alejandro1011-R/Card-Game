using System.Reflection.Metadata;
namespace BattleCards
{
    public class Tokens
    {
        public int Tipo;
        public string Info;
        public Tokens( int tipo, string info)
        {
            Tipo=tipo;
            Info=info;
        }
    }

    static public class TokenTypes
    {
        public const int name =0;
        public const int info=1;
        public const int power=2;
        public const int faction =3;
        public const int effect_quitapoder = 4;
        public const int effect_subepoder = 5;
        public const int ComposicionDeEfectos =6;
        public const int cuando=7;
        public const int siemprecuando=8;
        public const int maspoder=9;
        public const int igualpoder=10;
        public const int menospoder=11;
        public const int condicionfaccion=12;

    }
}