namespace CSharpOOP;

class Ninja
{
    private int CalorieIntake;
    public List<Food> FoodHistory;
    
    public bool IsFull 
    {
        get
        {
            if(CalorieIntake > 1200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public Ninja()
    {
        CalorieIntake = 0;
        FoodHistory = new List<Food>();
    }



    public void Eat(Food item)
    {
        if(!IsFull)
        {
            CalorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine($"This ninja just ate a {item.Name}!");
            if(item.IsSpicy)
            {
                Console.WriteLine("This food is spicy...");
            }
            if(item.IsSweet)
            {
                Console.WriteLine("This food is sweet");
            }
        }
        else
        {
            Console.WriteLine("This ninja is already full");
        }
    }


    public void stats()
    {
        Console.WriteLine($"This ninja has eaten {CalorieIntake} calories");
        foreach (Food i in FoodHistory)
        {
            Console.WriteLine(i.Name);
        }
    }
}