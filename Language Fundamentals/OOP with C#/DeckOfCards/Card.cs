namespace DeckOfCards;

public class Card
{
    public string Name;
    public string Suit;
    public int Value;

    public Card(string suit, int value)
    {
        switch (value)
        {
            case 11:
                Name = "Jack";
                break;
            case 12:
                Name = "Queen";
                break;
            case 13:
                Name = "King";
                break;
            case 1:
                Name = "Ace";
                break;
            default:
                Name = value.ToString();
                break;
        }
        Suit = suit;
        Value = value;
    }

    public override string ToString()
    {
        return $@"
        Name: {Name}
        Suit: {Suit}
        Value: {Value}";
    }

    public void Print()
    {
        Console.WriteLine($"Your card is {Value}{Name} of {Suit}");
    }
}