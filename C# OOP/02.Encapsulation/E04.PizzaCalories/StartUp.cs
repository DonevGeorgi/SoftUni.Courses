
using E04.PizzaCaliries.Models;

try
{
    string[] pizzaTokens = Console.ReadLine().Split(" ");
    string[] doughTokens = Console.ReadLine().Split(" ");

    Dough dough = new(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));
    Pizza pizza = new(pizzaTokens[1], dough);

    string input = string.Empty;

    while ((input = Console.ReadLine()) != "END")
    {
        string[] inputArgs = input.Split();

        string toppingType = inputArgs[1];
        double grams = int.Parse(inputArgs[2]);

        Topping currTopping = new(toppingType, grams);
        pizza.AddTopping(currTopping);
    }

    Console.WriteLine(pizza.ToString());

}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    return;
}
