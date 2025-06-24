namespace OopLaba2;

public class DrinkRepo
{
    private readonly List<Drink> drinks = new List<Drink>();
    
    public void Add(Drink drink)
    {
        var index = drinks.FindIndex(d => d.Name == drink.Name);
        if (index == -1)
        {
            drinks.Add(drink);
            return;
        }

        throw new Exception("Напиток с таким именем уже существует");
    }

    public void Update(Drink drink)
    {
        var index = drinks.FindIndex(d => d.Name == drink.Name);
        if (index != -1)
        {
            drinks[index] = drink;
            return;
        }

        throw new Exception("Такого напитка не существует");
    }

    public void Delete(Drink drink)
    {
        var index = drinks.FindIndex(d => d.Name == drink.Name);
        drinks.RemoveAt(index);
    }

    public List<string> GetNames()
    {
        return drinks.Select(d => d.Name).ToList();
    }

    public string GetRecipe(string name)
    {
        var index = drinks.FindIndex(d => d.Name == name);
        var recipe = drinks[index].Recipe;
        return recipe.Describe();
    }

    public Drink GetDrink(string name)
    {
        var drink = drinks.FirstOrDefault(d => d.Name == name);
        if (drink == null)
        {
            throw new Exception("Такого ингредиента нет");
        }
        return drink;
    }
}