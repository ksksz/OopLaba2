namespace OopLaba2.Action;

public class Add : Action
{
    private readonly IElement _ingredient;
    
    public Add(IElement element, IElement ingredient) : base(element)
    {
        _ingredient = ingredient;
    }

    public override void Execute()
    {
        base.Execute();
        Console.WriteLine($"Добавляю {_ingredient.Describe()}");
    }

    public override List<string> GetDescriptionsSteps()
    {
        var steps = base.GetDescriptionsSteps();
        steps.Add($"Добавить {_ingredient.Describe()}");
        return steps;
    }
}