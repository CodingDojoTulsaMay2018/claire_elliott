using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace TerminalRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
        }
        static void Game()
        {
            Random rand = new Random();
            List<Human> heroes = new List<Human> 
            {
                new Ninja("Ninja"),
                new Samurai("Samurai"),
                new Wizard("Wizard"),
            };
            List<Enemy> enemies = new List<Enemy> 
            {
                new Spider("Spider"),
                new Zombie("Zombie")
            };
            List<object> turnSystem = new List<object>();

            // creating heroes/enemies. 
            // Ran into trouble with duplicate instances of enemies in Game. 
            // Hardcoded spider and zombie into turnSystem idx [1] and [3].
            for(int i = 0; i < 4; i++)
            {
                if(i % 2 == 0)
                {
                    turnSystem.Add(heroes[rand.Next(0,3)]);
                }
                else if(i == 1)
                {
                    turnSystem.Add(enemies[0]);
                }
                else
                {
                    turnSystem.Add(enemies[1]);
                }
            }
            Console.WriteLine($"{turnSystem[0].GetType().Name} and {turnSystem[2].GetType().Name} -- VS -- {turnSystem[1].GetType().Name} and {turnSystem[3].GetType().Name}");
            // using turn system
            List<string> dead = new List<string>();
            bool isAlive = true;
            int battleRound = 0;
            while(isAlive)
            {
                battleRound++;
                Console.WriteLine($"###########\nR O U N D {battleRound}\n###########\n");
                for(int i = 0; i < turnSystem.Count; i++)
                {
                    if(i % 2 == 0)
                    {
                        if(turnSystem[i] is Samurai)
                        {
                            var samurai = turnSystem[i] as Samurai;
                            if(samurai.current_health == 0)
                            {
                                dead.Add("Human");
                                Console.WriteLine($"{samurai.name} is dead. Next up...");
                            }
                            else
                            {
                                Console.Write($"{samurai.name} (HP: {samurai.current_health}) is ready. Use \"deathblow\" or \"meditate\"?  ");
                                string attack = Console.ReadLine().ToLower();

                                if(attack == "meditate")
                                {
                                    samurai.Meditate();
                                }
                                if(attack == "deathblow")
                                {
                                    Console.Write($"Use \"deathblow\" on {turnSystem[1].GetType().Name} or {turnSystem[3].GetType().Name}?  ");
                                    string enemy = Console.ReadLine().ToLower();

                                    if(enemy == turnSystem[1].GetType().Name.ToString().ToLower())
                                    {
                                        samurai.DeathBlow(turnSystem[1]);
                                    }
                                    if(enemy == turnSystem[3].GetType().Name.ToString().ToLower())
                                    {
                                        samurai.DeathBlow(turnSystem[3]);
                                    }
                                }
                            }
                            
                        }
                        else if(turnSystem[i] is Ninja)
                        {
                            var ninja = turnSystem[i] as Ninja;
                            if(ninja.current_health == 0)
                            {
                                dead.Add("Human");
                                Console.WriteLine($"{ninja.name} is dead. Next up...");
                            }
                            else
                            {
                                Console.Write($"{ninja.name} (HP: {ninja.current_health}) is ready. Use \"stealth\" on {turnSystem[1].GetType().Name} or {turnSystem[3].GetType().Name}?  ");
                                string enemy = Console.ReadLine().ToLower();
                                if(enemy == turnSystem[1].GetType().Name.ToString().ToLower())
                                {
                                    ninja.Stealth(turnSystem[1]);
                                }
                                if(enemy == turnSystem[3].GetType().Name.ToString().ToLower())
                                {
                                    ninja.Stealth(turnSystem[3]);
                                }
                            } 
                        }
                        else
                        {
                            var wizard = turnSystem[i] as Wizard;
                            if(wizard.current_health == 0)
                            {
                                dead.Add("Human");
                                Console.WriteLine($"{wizard.name} is dead. Next up...");
                            }
                            else
                            {
                                Console.Write($"{wizard.name} (HP: {wizard.current_health}) is ready. Use \"fireball\" or \"heal\"?  ");
                                string attack = Console.ReadLine().ToLower();

                                if(attack == "heal")
                                {
                                    wizard.Heal();
                                }
                                if(attack == "fireball")
                                {
                                    Console.Write($"Use \"fireball\" on {turnSystem[1].GetType().Name} or {turnSystem[3].GetType().Name}?  ");
                                    string enemy = Console.ReadLine().ToLower();

                                    if(enemy == turnSystem[1].GetType().Name.ToString().ToLower())
                                    {
                                        wizard.Fireball(turnSystem[1]);
                                    }
                                    if(enemy == turnSystem[3].GetType().Name.ToString().ToLower())
                                    {
                                        wizard.Fireball(turnSystem[3]);
                                    }
                                }
                            }
                        }
                    }
                    
                    else
                    {
                        if(turnSystem[i] is Spider)
                        {
                            var spider = turnSystem[i] as Spider;
                            if(spider.current_health == 0)
                            {
                                dead.Add("Enemy");
                                Console.WriteLine($"{spider.name} is dead. Next up...");
                            }
                            else
                            {
                                Human player1;
                                Human player2;
                                Console.WriteLine($"{spider.name} (HP: {spider.current_health}) readies to attack.");
                                // cast player1
                                if(turnSystem[0] is Samurai)
                                {
                                    player1 = turnSystem[0] as Samurai;
                                }
                                else if(turnSystem[0] is Wizard)
                                {
                                    player1 = turnSystem[0] as Wizard;
                                }
                                else
                                {
                                    player1 = turnSystem[0] as Ninja;
                                }
                                // cast player2
                                if(turnSystem[2] is Samurai)
                                {
                                    player2 = turnSystem[2] as Samurai;
                                }
                                else if(turnSystem[2] is Wizard)
                                {
                                    player2 = turnSystem[2] as Wizard;
                                }
                                else
                                {
                                    player2 = turnSystem[2] as Ninja;
                                }
                                // attack
                                if(player1.current_health < player2.current_health)
                                {
                                    Console.WriteLine(spider.Attack(player1));
                                }
                                else if(player1.current_health > player2.current_health)
                                {
                                    Console.WriteLine(spider.Attack(player2));
                                }
                                else
                                {
                                    Random num = new Random();
                                    List<object> whichPlayer = new List<object> {turnSystem[0], turnSystem[2]};
                                    Console.WriteLine(spider.Attack(whichPlayer[num.Next(0,2)]));
                                }
                            }
                        }

                        if(turnSystem[i] is Zombie)
                        {
                            var zombie = turnSystem[i] as Zombie;
                            if(zombie.current_health == 0)
                            {
                                dead.Add("Enemy");
                                Console.WriteLine($"{zombie.name} is dead. Next up...");
                            }
                            else
                            {
                                Human player1;
                                Human player2;
                                Console.WriteLine($"{zombie.name} (HP: {zombie.current_health}) readies to attack.");
                                // cast player1
                                if(turnSystem[0] is Samurai)
                                {
                                    player1 = turnSystem[0] as Samurai;
                                }
                                else if(turnSystem[0] is Wizard)
                                {
                                    player1 = turnSystem[0] as Wizard;
                                }
                                else
                                {
                                    player1 = turnSystem[0] as Ninja;
                                }
                                // cast player2
                                if(turnSystem[2] is Samurai)
                                {
                                    player2 = turnSystem[2] as Samurai;
                                }
                                else if(turnSystem[2] is Wizard)
                                {
                                    player2 = turnSystem[2] as Wizard;
                                }
                                else
                                {
                                    player2 = turnSystem[2] as Ninja;
                                }
                                // attack
                                if(player1.current_health < player2.current_health)
                                {
                                    Console.WriteLine(zombie.Attack(player1));
                                }
                                else if(player1.current_health > player2.current_health)
                                {
                                    Console.WriteLine(zombie.Attack(player2));
                                }
                                else
                                {
                                    Random num = new Random();
                                    List<object> whichPlayer = new List<object> {turnSystem[0], turnSystem[2]};
                                    Console.WriteLine(zombie.Attack(whichPlayer[num.Next(0,2)]));
                                }
                            }
                        }
                    }
                }
                int countHuman = 0;
                int countEnemy = 0;
                for(int i = 0; i < dead.Count; i++)
                {
                    if(dead[i] == "Human")
                    {
                        countHuman++;
                    }
                    else
                    {
                        countEnemy++;
                    }
                }
                if(countHuman == 2)
                {
                    Console.WriteLine($"Aw shucks! {turnSystem[0].GetType().Name} and {turnSystem[2].GetType().Name} died. Game over!");
                    isAlive = false;
                }
                if(countEnemy == 2)
                {
                    Console.WriteLine($"Congrats! {turnSystem[1].GetType().Name} and {turnSystem[3].GetType().Name} have been felled. Game over!");
                    isAlive = false;
                }
            }
        }
    }
}
