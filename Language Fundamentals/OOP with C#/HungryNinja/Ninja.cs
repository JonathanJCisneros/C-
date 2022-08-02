namespace HungryNinja;

class Ninja
{
    private int CalorieIntake;
    public List<Food> FoodHistory;

    public Ninja()
    {
        CalorieIntake = 0;
        FoodHistory = new List<Food>();
    }

    public bool IsFull
    {
        get
        {
            return CalorieIntake > 1200;
        }
    }

    public void Eat(Food item)
    {
        if(IsFull == false)
        {
            CalorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine($"This ninja just ate {item.Name}...");
            if(item.IsSpicy)
            {
                Console.WriteLine("This food is spicy...");
            }
            if(item.IsSweet)
            {
                Console.WriteLine("This food is sweet!");
            }
        }
        else
        {
            Console.WriteLine("This Ninja is already full");
        }
    }
}