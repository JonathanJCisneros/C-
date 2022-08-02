public class Food
{
    public string Name;
    public int Calories;
    public bool IsSpicy;
    public bool IsSweet;

    public Food(string name, int calories, bool spicy, bool sweet)
    {
        Name = name;
        Calories = calories;
        IsSpicy = spicy;
        IsSweet = sweet;
    }
}

public class Buffet
{
    public List<Food> Menu;
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Example", 1000, false, false),
            new Food("Example1", 2000, true, false),
            new Food("Example2", 3000, false, true),
            new Food("Example3", 4000, true, true),
            new Food("Example4", 5000, false, true),
            new Food("Example5", 6000, true, false),
            new Food("Example6", 7000, false, false)
        };
    }

    public Food Serve()
    {
        Random rand = new Random();
        return Menu[rand.Next(0, Menu.Count)];
    }
}

class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;

    public void Eat(Food item)
    {

    }

    public Ninja(int calorieintake = 0, object food, )
}


