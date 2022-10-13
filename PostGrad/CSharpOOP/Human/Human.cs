namespace CSharpOOP;

public class Human
{
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public int Health;

    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }

    public Human(string name, int strength, int intelligence, int dexterity, int health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        Health = health;
    }

    public string Attack(Human target)
    {
        if(target.Health > 0)
        {
            target.Health -= (Strength * 3);
            if(target.Health <= 0)
            {
                target.Health = 0;
                return $"{target.Name} is dead!";
            }
            return $"{target.Name}'s health is now {target.Health}";
        }
        return $"{target.Name} is dead!";
    }

    public string Status()
    {
        return $"{Name}'s stats are: Strength: {Strength}, Intelligence: {Intelligence}, Dexterity: {Dexterity}, Health: {Health}";
    }
}