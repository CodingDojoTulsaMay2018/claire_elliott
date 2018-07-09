using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Dojodachi
{
    
// Somewhere in your namespace, outside other classes
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class Dojodachi
    {
        public string name { get; set; }
        public int fullness { get; set; }
        public int happiness { get; set; }
        public int meals { get; set; }
        public int energy { get; set; }
        public int chance {get; set; }
        public string message {get; set; }

        public Dojodachi(string IName)
        {
            name = IName;
            fullness = 20;
            happiness = 20;
            energy = 50;
            meals = 3;
        }

        public void Feed()
        {
            Random rand = new Random();
            chance = rand.Next(0,4);
            int fullnessPts = rand.Next(5,11);
            if(meals > 0 && chance != 3)
            {   
                fullness += fullnessPts;
                meals -= 1;
                message = "You fed " + name + "! Fullness +" + fullnessPts + ", Meals -1";
            }
            else if(meals > 0 && chance == 3)
            {
                meals -= 1;
                message = "You fed " + name + "! But he didn't like it. Meals -1";
            }
            else if(meals == 0)
            {
                message = "You have no meals left!";
            }
        }

        public void Play()
        {
            Random rand = new Random();
            chance = rand.Next(0,4);
            int happinessPts = rand.Next(5,11);
            if(energy > 5 && chance != 3)
            {
                happiness += happinessPts;
                energy -= 5;
                message = "You played with " + name + "! Happiness +" + happinessPts + ", Energy -5";
            }
            else if(energy > 5 && chance == 3)
            {
                energy -= 5;
                message = "You played with " + name + "! But it was boooring! Energy -5";
            }
            else if(energy < 5)
            {
                message = "You have don't have enough energy";
            }
        }

        public void Work()
        {
            Random rand = new Random();
            if(energy > 5)
            {
                meals += rand.Next(1,4);
                message = name + " gained " + meals + " meals! Energy -5";
                energy -= 5;
            }
            else
            {
                message = "You don't have enough energy!";
            }
        }

        public void Sleep()
        {
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            message = name + " took a nap. Energy +15, Fullnes -5, Happiness -5";
        }
    }
}