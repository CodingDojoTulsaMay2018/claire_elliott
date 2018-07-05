using System;
namespace TerminalRPG
{
    public class Enemy
    {
        public string name { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int max_health { get; set; }
        public int current_health { get; set; }

        public Enemy(string IName, int str = 3, int intell = 3, int dex = 3, int hp = 100)
        {
            name = IName;
            strength = str;
            intelligence = intell;
            dexterity = dex;
            current_health = hp;
            max_health = hp;
        }

        public interface CanAttack
        {
            void Attack();
        } 
    }

    public class Zombie : Enemy
    {
        public Zombie(string IName, int hp = 300) : base(IName)
        {
            current_health = hp;
            max_health = hp;
        }

        public string Attack(Object arg)
        {
            if(arg is Human)
            {
                Human victim = arg as Human;
                Random rand = new Random();
                int times = rand.Next(0,4);
                int damage = strength * times;
                if(victim.current_health - damage <= 0)
                {
                    victim.current_health = 0;
                    return $"{name} killed {victim.name}.\n";
                }
                else
                {
                    victim.current_health -= damage;
                    return $"{name} attacked {victim.name} {times} times for {damage} damage.\n";
                }
                
            }
            else
            {
                return $"Attack failed!\n";
            }
        }
    }
    public class Spider : Enemy
    {
        public Spider(string IName, int hp = 150) : base(IName)
        {
            current_health = hp;
            max_health = hp;
            strength = 10;
        }

        public string Attack(Object arg)
        {
            if(arg is Human)
            {
                Human victim = arg as Human;
                Random rand = new Random();
                int damage = strength * rand.Next(1,5);
                // heal
                if((damage/2) + current_health >= max_health)
                {
                    current_health = max_health;
                }
                else
                {
                    current_health += damage/2;
                }
                // attack
                if(victim.current_health - damage <= 0)
                {
                    victim.current_health = 0;
                    return $"{name} killed {victim.name}.\n";
                }
                else
                {
                    victim.current_health -= damage;
                    return $"{name} attacked {victim.name} for {damage} damage and healed {damage/2} points.\n";
                }
            }
            else
            {
                return $"Attack failed!\n";
            }
        }
    }
}