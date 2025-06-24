namespace OopLaba2.Ingredient;

public abstract class Ingredient : IElement
{
    public string Name { get; }
    public decimal Weight { get; }

    public Ingredient(string name, decimal weight)
    {
        Name = name;
        Weight = weight;
    }
    
    
    public string Describe()
    {
        return $"{Name} ({Weight} г)";
    }

    public void Execute()
    {
        
    }

    public List<string> GetDescriptionsSteps()
    {
        return new List<string>();
    }
}