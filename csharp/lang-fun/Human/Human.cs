using System;
namespace Human {
    public class Human {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int Health;

        public Human(object IName, int str = 3, int intell = 3, int dex = 3, int hp = 100)
        {
            Name = (string)IName;
            Strength = str;
            Intelligence = intell;
            Dexterity = dex;
            Health = hp;
        }

        public void Attack(Object arg)
        {
            if(arg is Human){
                Human human = arg as Human;
                human.Health -= Strength * 5;
            }
        }
    }
}