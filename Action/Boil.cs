namespace OopLaba2.Action;

public class Boil : Action
{
    private readonly IElement _ingredient;
    
    public Boil(IElement element, IElement ingredient) : base(element)
    {
        _ingredient = ingredient;
    }

    public override void Execute()
    {
        base.Execute();
        Console.WriteLine($"Вскипаю {_ingredient.Describe()}");
    }

    public override List<string> GetDescriptionsSteps()
    {
        var steps = base.GetDescriptionsSteps();
        steps.Add($"Вскипятить {_ingredient.Describe()}");
        return steps;
    }
}