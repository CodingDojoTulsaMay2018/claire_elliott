using System;
namespace Phone
{
    public class Nokia : Phone, IRingable
    {
        public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) : base(versionNumber, batteryPercentage, carrier, ringTone) {}
        public string Ring()
        {
            return $"... {_ringTone} ...";
        }
        public string Unlock()
        {
            return $"Nokia {_versionNumber} unlocked with passcode";
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("####################");
            Console.WriteLine($"Nokia {_versionNumber}");
            Console.WriteLine($"Battery Percentage: {_batteryPercentage}");
            Console.WriteLine($"Carrier: {_carrier}");
            Console.WriteLine($"Ring Tone: {_ringTone}");
            Console.WriteLine("####################\n");
        }
    }
}