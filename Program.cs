using OopLaba2;
using OopLaba2.Action;
using OopLaba2.Ingredient;

class Program
{
    static void Main(string[] args)
    {
        var repo = new DrinkRepo();
        var service = new DrinkService(repo);
        var controller = new DrinkController(service);
        controller.Run();
    }
}