using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Nokia nokia = new Nokia("1100", 60, "Metro PCS", "RING RING RIIIING");
            Galaxy galaxy = new Galaxy("s8", 100, "T-Mobile", "Dooo do doo dooo");

            nokia.DisplayInfo();
            Console.WriteLine(nokia.Ring());
            Console.WriteLine(nokia.Unlock());
            Console.WriteLine("\n");
            galaxy.DisplayInfo();
            Console.WriteLine(galaxy.Ring());
            Console.WriteLine(galaxy.Unlock());
            Console.WriteLine("\n");
        }
    }
}
