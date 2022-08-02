namespace DeckOfCards;

public class Deck
{
    public List<Card> Cards = new List<Card>();
    public Deck()
    {
        Reset();
    }
    public List<Card> Reset()
    {
        Cards.Clear();

        string[] suits =
        {
            "Hearts",
            "Diamonds",
            "Spades",
            "Clubs"
        };

        foreach (string suit in suits)
        {
            for (int i = 1; i < 14; i++)
            {
                Cards.Add(new Card(suit, i));
            }
        }
        return Cards;
    }

    public Card Deal()
    {
        Card cardDealt = Cards[0];
        Cards.RemoveAt(0);
        return cardDealt;
    }

    public void Shuffle()
    {
        List<Card> unshuffled = this.Cards;
        List<Card> shuffled = new List<Card>();
        Random rand = new Random();
        while (unshuffled.Count > 0)
        {
            int idx = rand.Next(0, unshuffled.Count);
            shuffled.Add(unshuffled[idx]);
            unshuffled.RemoveAt(idx);
        }
        this.Cards = shuffled;
    }
}