namespace OopLaba2.Action;

public class Mix : Action
{
    public Mix(IElement element) : base(element)
    {
    }

    public override void Execute()
    {
        base.Execute();
        Console.WriteLine("Перемешиваю");
    }

    public override List<string> GetDescriptionsSteps()
    {
        var steps = base.GetDescriptionsSteps();
        steps.Add("Перемешать");
        return steps;
    }
}