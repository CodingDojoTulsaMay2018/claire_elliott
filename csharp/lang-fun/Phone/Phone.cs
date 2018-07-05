using System;
namespace Phone
{
    public abstract class Phone
    {
        public string _versionNumber {get; private set; }
        public int _batteryPercentage {get; private set; }
        public string _carrier {get; private set; }
        public string _ringTone {get; private set; }
        public Phone(string versionNumber, int batteryPercentage, string carrier, string ringTone){
            _versionNumber = versionNumber;
            _batteryPercentage = batteryPercentage;
            _carrier = carrier;
            _ringTone = ringTone;
        }
        // abstract method. This method will be implemented by the subclasses
        public abstract void DisplayInfo();
    }
}