using System;
namespace WizardNinjaSamurai {
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

        public void Attack(Object arg)
        {
            if(arg is Human){
                Human human = arg as Human;
                human.current_health -= strength * 5;
                Console.WriteLine(name + " attacked " + human.name + "\n");
            }
            else
            {
                Console.WriteLine($"Attack failed!\n");
            }
        }
    }
    public class Wizard : Human
    {
        public Wizard(string IName, int IHealth = 50) : base(IName)
        {
            intelligence = 25;
            max_health = IHealth;
            current_health = IHealth;
        }
        public void Heal()
        {
            int healed_health = 10 * intelligence;
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
            if(arg is Samurai)
            {
                var victim = arg as Samurai;
                int damage = rand.Next(20, 51);
                if(victim.current_health - damage <= 0)
                {
                    victim.current_health = 0;
                }
                else{
                    victim.current_health -= damage;
                }
                
                Console.WriteLine($"{name} hit {victim.name} with a fireball for {damage} damage.\n");
            }
            else if(arg is Ninja)
            {
                var victim = arg as Ninja;
                int damage = rand.Next(20, 51);
                if(victim.current_health - damage <= 0)
                    {
                        victim.current_health = 0;
                    }
                    else 
                    {
                        victim.current_health -= damage;
                    }
                
                Console.WriteLine($"{name} hit {victim.name} with a fireball for {damage} damage.\n");
            }
            else if(arg is Wizard)
            {
                var victim = arg as Wizard;
                int damage = rand.Next(20, 51);
                if(victim.current_health - damage <= 0)
                    {
                        victim.current_health = 0;
                    }
                    else
                    {
                        victim.current_health -= damage;
                    }
                Console.WriteLine($"{name} hit {victim.name} with a fireball for {damage} damage.\n");
            }
            else
            {
                Console.WriteLine($"{name}'s fireball failed!\n");
            }
        }
    }

    public class Ninja : Human
    {
        public Ninja(string IName, int IHealth = 100) : base(IName)
        {
            max_health = IHealth;
            current_health = IHealth;
            dexterity = 175;
        }
        public void GetAway()
        {
            if(current_health < 15)
            {
                Console.WriteLine(name + " couldn't get away.\n");
            }
            else{
                current_health -= 15;
                Console.WriteLine(name + " dashed away for 15 health.\n");
            }
        }
        public void Stealth(Object arg)
        {
            Random rand = new Random();
            if(arg is Samurai)
            {
                var victim = arg as Samurai;
                int damage = rand.Next(5, 51);
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
                        Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed to maxe health.\n");
                    }
                current_health += 10;
                Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed 10 health.\n");
            }
            else if(arg is Ninja)
            {
                var victim = arg as Ninja;
                int damage = rand.Next(5, 51);
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
                        Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed to maxe health.\n");
                    }
                current_health += 10;
                Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed 10 health.\n");
            }
            else if(arg is Wizard)
            {
                var victim = arg as Wizard;
                int damage = rand.Next(5, 51);
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
                        Console.WriteLine($"{name} attacked {victim.name} for {damage} damage, and then healed to maxe health.\n");
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
            if(current_health + 200 >= max_health)
            {
                current_health = max_health;
                Console.WriteLine($"{name} return to max health.\n");
            }
            else{
                current_health += 200;
                Console.WriteLine($"{name} meditated for 200 health.\n");
            }
            
        }
        public void DeathBlow(Object arg)
        {
            if(arg is Samurai)
            {
                var victim = arg as Samurai;
                if(victim.current_health < 50)
                {
                    victim.current_health = 0;
                    Console.WriteLine($"{name} killed {victim.name}!");
                }
            Console.WriteLine($"{name}'s death blow on {victim.name} failed!\n");
            }
            else if(arg is Ninja)
            {
                var victim = arg as Ninja;
                if(victim.current_health < 50)
                    {
                        victim.current_health = 0;
                        Console.WriteLine($"{name} killed {victim.name}!");
                    }
                Console.WriteLine($"{name}'s death blow on {victim.name} failed!\n");
            }
            else if(arg is Wizard)
            {
                var victim = arg as Wizard;
                if(victim.current_health < 50)
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

        public void HowMany(params object[] humans)
        {
            int count = 0;
            foreach(object i in humans)
            {
                if(i is Samurai)
                {
                    count++;
                }
            }
            Console.WriteLine($"{name} counted {count} samurai.\n");
        }
    }
}