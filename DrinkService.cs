namespace OopLaba2;

public class DrinkService
{
    private readonly DrinkRepo _drinkRepo;

    public DrinkService(DrinkRepo drinkRepo)
    {
        _drinkRepo = drinkRepo;
    }

    public void Add(string name, IElement recipe)
    {
        _drinkRepo.Add(new Drink(name, recipe));
    }

    public void Update(string name, IElement recipe)
    {
        _drinkRepo.Update(new Drink(name, recipe));
    }

    public void Delete(string name)
    {
        var drink = _drinkRepo.GetDrink(name);
        _drinkRepo.Delete(drink);
    }

    public string ShowRecipe(string name)
    {
        var drink = _drinkRepo.GetDrink(name);
        return drink.Recipe.Describe();
    }

    public void ExecuteDrink(string name)
    {
        var drink = _drinkRepo.GetDrink(name);
        drink.Execute();
    }

    public Drink GetDrink(string name)
    {
        return _drinkRepo.GetDrink(name);
    }
}