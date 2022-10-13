namespace CSharpOOP;

public class Buffet
{
    public List<Food> Menu;

    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Subway Sandwich", 700, false, false),
            new Food("Big Mac", 500, false, false),
            new Food("Sushi", 1200, true, false),
            new Food("Apple Pie", 400, false, true),
            new Food("Chocolate", 350, false, true),
            new Food("Banana", 180, false, true),
            new Food("Chex Mix", 400, false, false)
        };
    }

    public string AddToMenu(Food item)
    {
        Menu.Add(item);
        return $"{item.Name} is now part of the menu!";
    }

    public Food Serve()
    {
        Random rand = new Random();
        return Menu[rand.Next(0, Menu.Count)];
    }
}