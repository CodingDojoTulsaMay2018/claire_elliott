using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            // There is only one artist in this collection from Mount Vernon, what is their name and age?
            var foundArtist = from artist in Artists
            where artist.Hometown == "Mount Vernon"
            select new { name = artist.ArtistName, age = artist.Age };
            foreach(var artist in foundArtist)
            {
                Console.WriteLine($"{artist.name}, {artist.age}\n");
            }
            
            //Who is the youngest artist in our collection of artists?
            var youngestArtist = (from artist in Artists
            orderby artist.Age descending
            select artist.ArtistName).First();

            Console.WriteLine($"{youngestArtist}\n");

            //Display all artists with 'William' somewhere in their real name
            var withWilliam = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach(var artist in withWilliam)
            {
                Console.Write($"{artist.RealName}, ");
                
            }
            Console.WriteLine("\n");

            //Display the 3 oldest artist from Atlanta
            var fromAtlanta = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3);
            foreach(var artist in fromAtlanta)
            {
                Console.Write($"{artist.ArtistName}, ");
            }
            Console.WriteLine("\n");

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            // var combo = Artists.Join(Groups, a => a.GroupId, b => b.Id, (a,b) => new {a,b}).Any(a => a.Hometown != "New York City");

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var wuTangClan = Groups.Where(g => g.GroupName == "Wu-Tang Clan").Join(Artists, g => g.Id, a => a.GroupId, (g,a) => new {a.ArtistName});
            foreach(var i in wuTangClan)
            {
                Console.Write($"{i.ArtistName}, ");
            }
        }
    }
}
