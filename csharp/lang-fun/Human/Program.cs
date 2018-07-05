using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("Claire");
            Human human2 = new Human("Troy");
            human.Attack(human2);
            Console.WriteLine(human2.Health);
        }
    }
}
