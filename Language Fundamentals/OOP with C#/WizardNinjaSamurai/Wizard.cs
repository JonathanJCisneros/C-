namespace WizardNinjaSamurai;

public class Wizard : Human
{
    public Wizard(string name, int str,  int dex, int intel = 25, int hp = 50) : base(name, str, intel, dex, hp){}

    public override int Attack(Human target)
    {
        int damage = target.Health -= (5*Intelligence);
        Health += damage;
        return damage;
    }

    public int Heal(Human target)
    {
        target.Intelligence += (10*Intelligence);
        return target.Health;
    }
}