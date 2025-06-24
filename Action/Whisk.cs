namespace OopLaba2.Action;

public class Whisk : Action
{
    private readonly IElement _ingredient;
    
    public Whisk(IElement element, IElement ingredient) : base(element)
    {
        _ingredient = ingredient;
    }

    public override void Execute()
    {
        base.Execute();
        Console.WriteLine($"Взбиваю {_ingredient.Describe()}");
    }

    public override List<string> GetDescriptionsSteps()
    {
        var steps = base.GetDescriptionsSteps();
        steps.Add($"Взбить {_ingredient.Describe()}");
        return steps;
    }
}