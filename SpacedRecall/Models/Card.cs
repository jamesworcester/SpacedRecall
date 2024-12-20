namespace SpacedRecall.Models
{
    public class Card
    {
        int Id { get; set; }
        CardType CardType { get; set; }

        Deck Deck { get; set; }
    }
}
