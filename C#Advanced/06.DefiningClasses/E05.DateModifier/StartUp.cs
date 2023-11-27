namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            Console.WriteLine(DateModifier.DifferenceInDate(startDate, endDate));
        }
    }
}