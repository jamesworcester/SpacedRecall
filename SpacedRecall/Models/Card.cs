namespace SpacedRecall.Models
{
    public class Card
    {
        public int Id { get; set; }
        public CardType CardType { get; set; }

        public Deck Deck { get; set; }
    }
}
