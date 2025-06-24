namespace OopLaba2.Action;

public class Pour : Action
{
    private readonly IElement _liquid;
    private readonly IElement _medium;
    
    public Pour(IElement element, IElement liquid, IElement medium) : base(element)
    {
        _liquid = liquid;
        _medium = medium;
    }

    public override void Execute()
    {
        base.Execute();
        Console.WriteLine($"Проливаю {_liquid.Describe()} через {_medium.Describe()}");
    }

    public override List<string> GetDescriptionsSteps()
    {
        var steps = base.GetDescriptionsSteps();
        steps.Add($"Пролить {_liquid.Describe()} через {_medium.Describe()}");
        return steps;
    }
}