namespace BattleCards;

public abstract class IPlayer
{
    public string Name { get; set; }
    public int RaundsWon { get; set; }
    public string TotalRounds { get; set; }
    public List<Card> PlayerM { get; set; }
    public List<Card> Graveyard { get; set; }
    public List<Card> Hand { get; set; }
    public List<Card> Deck { get; set; }
    public int TotalPoint { get; set; }
    public bool PassRound { get; set; }
}