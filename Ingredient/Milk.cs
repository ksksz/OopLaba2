namespace OopLaba2.Ingredient;

public class Milk : Ingredient
{
    public Milk(string type, decimal weight) : base($"Молоко {type}", weight)
    {
    }
}