namespace WizardNinjaSamurai;

public class Samurai : Human
{
    public Samurai(string name, int str, int intel, int dex, int hp = 200) : base(name, str, intel, dex, hp){}

    public override int Attack(Human target)
    {
        base.Attack(target);
        if(target.Health <= 50)
        {
            target.Health = 0;
        }
        return target.Health;
    }

    public int Meditate()
    {
        Health = 200;
        return Health;
    }
}