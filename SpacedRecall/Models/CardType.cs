﻿namespace SpacedRecall.Models
{
    public class CardType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CardField cardFields { get; set; }

    }
}
