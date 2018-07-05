using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard claire = new Wizard("Claire");
            Wizard troy = new Wizard("Troy");
            Ninja frank = new Ninja("Frank");
            Samurai evan = new Samurai("Evan");
            Samurai phil = new Samurai("Phil");

            Console.WriteLine(frank.current_health);
            claire.Fireball(frank);
            claire.Fireball(3);
            evan.Attack(claire);
            claire.Heal();
            evan.DeathBlow(claire);
            evan.HowMany(claire,troy,frank,evan,phil);
            frank.GetAway();
            frank.Stealth(phil);
            troy.Fireball(frank);
            troy.Fireball(frank);
        }
    }
}
