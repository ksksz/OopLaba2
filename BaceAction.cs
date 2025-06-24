namespace OopLaba2;

public class BaseAction : IElement
{
    public string Describe()
    {
        return "Начало рецепта";
    }

    public void Execute()
    {
        Console.WriteLine("Начинаю выполнение рецепта");
    }

    public List<string> GetDescriptionsSteps()
    {
        return new List<string>();
    }
}