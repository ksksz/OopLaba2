namespace OopLaba2.Action;

public abstract class Action : IElement
{
    protected IElement DecoratedElement;

    protected Action(IElement element)
    {
        DecoratedElement = element;
    }
    
    public virtual string Describe()
    {
        return string.Join(" -> ", GetDescriptionsSteps());
    }

    public virtual void Execute()
    {
        DecoratedElement.Execute();
    }

    public virtual List<string> GetDescriptionsSteps()
    {
        return DecoratedElement.GetDescriptionsSteps();
    }
}