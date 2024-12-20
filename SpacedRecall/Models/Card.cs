namespace SpacedRecall.Models
{
    public class Card
    {
        public int Id { get; set; }
        public CardType Type { get; set; }
        public Deck ParentDeck { get; set; }
    }
}
