using E03.Telephony;
using System;

namespace P03.Telephony.Models.Classes
{
    public class StationaryPhone : Calling
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
