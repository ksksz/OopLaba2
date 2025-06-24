namespace OopLaba2;

public class Drink
{
    public string Name { get; set; }
    public IElement Recipe { get; set; }

    public Drink(string name, IElement recipe)
    {
        Name = name;
        Recipe = recipe;
    }

    public void Execute()
    {
        Recipe.Execute();
    }
}