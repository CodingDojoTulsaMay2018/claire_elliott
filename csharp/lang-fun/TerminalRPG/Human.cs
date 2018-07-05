using System;
namespace TerminalRPG {
    public class Human 
    {
        public string name { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int max_health { get; set; }
        public int current_health { get; set; }

        public Human(string IName, int str = 3, int intell = 3, int dex = 3, int hp = 100)
        {
            name = IName;
            strength = str;
            intelligence = intell;
            dexterity = dex;
            current_health = hp;
            max_health = hp;
        }
    }
    public class Wizard : Human
    {
        public Wizard(string IName, int IHealth = 100) : base(IName)
        {
            intelligence = 10;
            max_health = IHealth;
            current_health = IHealth;
        }
        public void Heal()
        {
            int healed_health = 5 * intelligence;
            if(current_health + healed_health >= max_health)
            {
                current_health = max_health;
                Console.WriteLine($"{name} healed to max health\n");
            }
            else{
                current_health += healed_health;
                Console.WriteLine($"{name} healed for {healed_health} health.\n");
            } 
        }
        public void Fireball(Object arg)
        {
            Random rand = new Random();
            if(arg is Spider)
            {
                var victim = arg as Spider;
                int damage = rand.Next(10, 41);
                if(victim.current_health - damage <= 0)
                {
                    victim.current_health = 0;
                }
                else{
                    victim.current_health -= damage;
                }
                
                Console.WriteLine($"{name} hit {victim.name} with a fireball for {damage} damage.\n");
            }
            else if(arg is Zombie)
            {
                var victim = arg as Zombie;
                int damage = rand.Next(20, 51);
                if(victim.current_health - damage <= 0)
                {
                    victim.current_health = 0;
                }
                else{
                    victim.current_health -= damage;
                }
                
                Console.WriteLine($"{name} hit {victim.name} with a fireball for {damage} damage. It's super effective!\n");
            }
            else
            {
                Console.WriteLine($"{name}'s fireball failed!\n");
            }
        }
    }

    public class Ninja : Human
    {
        public Ninja(string IName, int IHealth = 150) : base(IName)
        {
            max_health = IHealth;
            current_health = IHealth;
            dexterity = 175;
        }
        public void Stealth(Object arg)
        {
            Random rand = new Random();
            // attack
            if(arg is Spider)
            {
                var victim = arg as Spider;
                int damage = rand.Next(10, 51);
                if(damage - victim.current_health < 0)
                {
                    victim.current_health = 0;
                }
                else
                {
                    victim.current_health -= damage;
                }
                // heal
                if(10 + current_health >= max_health)
                    {
                        current_health = max_health;
                        Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed to max health.\n");
                    }
                    else
                    {
                        current_health += 10;
                        Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed 10 health.\n");
                    }
                
            }
            else if(arg is Zombie)
            {
                var victim = arg as Zombie;
                int damage = rand.Next(10, 51);
                if(damage - victim.current_health < 0)
                    {
                        victim.current_health = 0;
                    }
                    else
                    {
                        victim.current_health -= damage;
                    }
                if(10 + current_health >= max_health)
                    {
                        current_health = max_health;
                        Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed to max health.\n");
                    }
                current_health += 10;
                Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed 10 health.\n");
            }
            else
            {
                Console.WriteLine($"{name}'s stealth failed!\n");
            }
        }
    }

    public class Samurai : Human
    {
        public Samurai(string IName, int IHealth=200) : base(IName)
        {
            max_health = IHealth;
            current_health = IHealth;
        }
        public void Meditate()
        {
            if(current_health + 100 >= max_health)
            {
                current_health = max_health;
                Console.WriteLine($"{name} return to max health.\n");
            }
            else{
                current_health += 100;
                Console.WriteLine($"{name} meditated for 100 health.\n");
            }
        }
        public void DeathBlow(Object arg)
        {
            if(arg is Spider)
            {
                var victim = arg as Spider;
                if(victim.current_health < victim.max_health/3)
                {
                    victim.current_health = 0;
                    Console.WriteLine($"{name} killed {victim.name}!");
                }
            Console.WriteLine($"{name}'s death blow on {victim.name} failed!\n");
            }
            else if(arg is Zombie)
            {
                var victim = arg as Zombie;
                if(victim.current_health < victim.max_health/3)
                {
                    victim.current_health = 0;
                    Console.WriteLine($"{name} killed {victim.name}!");
                }
            Console.WriteLine($"{name}'s death blow on {victim.name} failed!\n");
            }
            else
            {
                Console.WriteLine($"{name}'s death blow failed!\n");
            }
        }
    }
}