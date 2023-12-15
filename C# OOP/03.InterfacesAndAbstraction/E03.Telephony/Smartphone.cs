using E03.Telephony;
using System;

namespace P03.Telephony.Models.Classes
{
    public class Smartphone : Calling, WorldWideWeb
    {
        public void Browsing(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
