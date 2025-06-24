namespace OopLaba2.Action;

public class Grind : Action
{
    private readonly IElement _ingredient;
    
    public Grind(IElement element, IElement ingredient) : base(element)
    {
        _ingredient = ingredient;
    }

    public override void Execute()
    {
        base.Execute();
        Console.WriteLine($"Перемалываю {_ingredient.Describe()}");
    }

    public override List<string> GetDescriptionsSteps()
    {
        var steps = base.GetDescriptionsSteps();
        steps.Add($"Перемолоть {_ingredient.Describe()}");
        return steps;
    }
}