using System;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int DifferenceInDate(string start, string end)
        {
            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);

            TimeSpan difference = startDate - endDate;

            return Math.Abs(difference.Days);
        }
    }
}
