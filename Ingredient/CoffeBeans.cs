namespace OopLaba2.Ingredient;

public class CoffeBeans : Ingredient
{
    public CoffeBeans(string sort, decimal weight) : base($"Кофе сорта {sort}", weight)
    {
        
    }
}