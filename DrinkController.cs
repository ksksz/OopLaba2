namespace OopLaba2;

using OopLaba2.Action;
using OopLaba2.Ingredient;
using System.Linq; 

public class DrinkController
{
    private readonly DrinkService _drinkService;

    public DrinkController(DrinkService drinkService)
    {
        _drinkService = drinkService;
    }

    public void Run()
    {
        while (true)
        {
            ShowMenu();
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateDrink();
                    break;
                case "2":
                    UpdateDrink();
                    break;
                case "3":
                    DeleteDrink();
                    break;
                case "4":
                    ShowDrinkRecipe();
                    break;
                case "5":
                    ExecuteDrinkPreparation();
                    break;
                case "0":
                    return;

                default:
                    Console.WriteLine("Неправильный ввод. Пожалуйста, выберите опцию из меню.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("--- Управление Напитками ---");
        Console.WriteLine("1. Добавить напиток");
        Console.WriteLine("2. Обновить напиток");
        Console.WriteLine("3. Удалить напиток");
        Console.WriteLine("4. Посмотреть рецепт");
        Console.WriteLine("5. Приготовить напиток");
        Console.WriteLine("0. Выход");
        Console.Write("Ваш выбор: ");
    }

    private void CreateDrink()
    {
        Console.Clear();
        Console.WriteLine("--- Создание нового напитка ---");
        string name;
        while (true)
        {
            Console.Write("Введите название напитка: ");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.WriteLine("Название напитка не может быть пустым. Попробуйте снова.");
        }

        try
        {
            IElement recipe = BuildRecipe();
            _drinkService.Add(name, recipe);
            Console.WriteLine($"Напиток '{name}' успешно добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении напитка: {ex.Message}");
        }
    }

    private void UpdateDrink()
    {
        Console.Clear();
        Console.WriteLine("--- Обновление напитка ---");
        Console.Write("Введите название напитка для обновления: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название напитка не может быть пустым.");
            return;
        }

        try
        {
            _drinkService.GetDrink(name); 

            Console.WriteLine($"Начинаем создавать новый рецепт для '{name}'.");
            IElement newRecipe = BuildRecipe();
            _drinkService.Update(name, newRecipe);
            Console.WriteLine($"Рецепт для напитка '{name}' успешно обновлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обновлении напитка: {ex.Message}");
        }
    }

    private void DeleteDrink()
    {
        Console.Clear();
        Console.WriteLine("--- Удаление напитка ---");
        Console.Write("Введите название напитка для удаления: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название напитка не может быть пустым.");
            return;
        }

        try
        {
            _drinkService.Delete(name);
            Console.WriteLine($"Напиток '{name}' успешно удален.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении напитка: {ex.Message}");
        }
    }

    private void ShowDrinkRecipe()
    {
        Console.Clear();
        Console.WriteLine("--- Просмотр рецепта напитка ---");
        Console.Write("Введите название напитка, рецепт которого хотите увидеть: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название напитка не может быть пустым.");
            return;
        }

        try
        {
            var drink = _drinkService.GetDrink(name);
            Console.WriteLine($"\nРецепт для '{name}':");
            Console.WriteLine(drink.Recipe.Describe()); 

            Console.WriteLine("\nПошаговый рецепт:");
            foreach (var step in drink.Recipe.GetDescriptionsSteps())
            {
                Console.WriteLine($"- {step}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при получении рецепта: {ex.Message}");
        }
    }

    private void ExecuteDrinkPreparation()
    {
        Console.Clear();
        Console.WriteLine("--- Приготовление напитка ---");
        Console.Write("Введите название напитка, который хотите приготовить: ");
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название напитка не может быть пустым.");
            return;
        }

        try
        {
            Console.WriteLine($"\nНачинаю приготовление '{name}'...");
            _drinkService.ExecuteDrink(name);
            Console.WriteLine($"\nПриготовление '{name}' завершено!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при приготовлении напитка: {ex.Message}");
        }
    }

    private IElement BuildRecipe()
    {
        IElement recipe = new BaseAction(); 
        List<Ingredient.Ingredient> ingredientsAddedToCurrentRecipe = new List<Ingredient.Ingredient>();

        while (true)
        {
            Console.WriteLine("\n--- Построение рецепта ---");
            Console.WriteLine("Текущие шаги рецепта:");
            var currentSteps = recipe.GetDescriptionsSteps();
            if (currentSteps.Any())
            {
                foreach (var step in currentSteps)
                {
                    Console.WriteLine($"- {step}");
                }
            }
            else
            {
                Console.WriteLine("- Рецепт пока пуст (Начало рецепта)");
            }

            Console.WriteLine("\nДоступные ингредиенты для использования:");
            if (ingredientsAddedToCurrentRecipe.Any())
            {
                for (int i = 0; i < ingredientsAddedToCurrentRecipe.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}. {ingredientsAddedToCurrentRecipe[i].Describe()}");
                }
            }
            else
            {
                Console.WriteLine("  Пока нет добавленных ингредиентов для использования в действиях.");
            }


            Console.WriteLine("\nВыберите следующее действие или добавьте новый ингредиент:");
            Console.WriteLine("--- Добавить НОВЫЙ Ингредиент (Для последующего использования) ---");
            Console.WriteLine("N1. Вода");
            Console.WriteLine("N2. Кофейные зерна");
            Console.WriteLine("N3. Молоко");
            Console.WriteLine("N4. Сироп");
            Console.WriteLine("N5. Лед");
            Console.WriteLine("--- Действия (Используют ингредиенты или действуют сами по себе) ---");
            Console.WriteLine("A1. Добавить ингредиент (использует уже определенный)");
            Console.WriteLine("A2. Вскипятить (использует уже определенный)");
            Console.WriteLine("A3. Перемолоть (использует уже определенный)");
            Console.WriteLine("A4. Перемешать (не требует ингредиентов)");
            Console.WriteLine("A5. Пролить (требует два уже определенных ингредиента)");
            Console.WriteLine("A6. Взбить (использует уже определенный)");
            Console.WriteLine("0. Завершить рецепт");
            Console.Write("Ваш выбор (N1, A1, 0, и т.д.): ");
            var input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "0")
            {
                break;
            }

            Ingredient.Ingredient chosenIngredientForAction = null; 
            Ingredient.Ingredient chosenLiquidForPour = null;
            Ingredient.Ingredient chosenMediumForPour = null; 

    
            switch (input)
            {
                case "N1": 
                    chosenIngredientForAction = GetIngredientDetails<Water>("Введите вес воды (г): ");
                    if (chosenIngredientForAction != null)
                        ingredientsAddedToCurrentRecipe.Add(chosenIngredientForAction);
                    break;
                case "N2": 
                    chosenIngredientForAction =
                        GetIngredientDetails<CoffeBeans>("Введите сорт кофе: ", "Введите вес кофейных зерен (г): ");
                    if (chosenIngredientForAction != null)
                        ingredientsAddedToCurrentRecipe.Add(chosenIngredientForAction);
                    break;
                case "N3": 
                    chosenIngredientForAction =
                        GetIngredientDetails<Milk>("Введите тип молока (например, 'коровье', 'соевое'): ",
                            "Введите вес молока (г): ");
                    if (chosenIngredientForAction != null)
                        ingredientsAddedToCurrentRecipe.Add(chosenIngredientForAction);
                    break;
                case "N4": 
                    chosenIngredientForAction =
                        GetIngredientDetails<Syrop>("Введите тип сиропа (например, 'карамельный'): ",
                            "Введите вес сиропа (г): ");
                    if (chosenIngredientForAction != null)
                        ingredientsAddedToCurrentRecipe.Add(chosenIngredientForAction);
                    break;
                case "N5": 
                    chosenIngredientForAction = GetIngredientDetails<Ice>("Введите вес льда (г): ");
                    if (chosenIngredientForAction != null)
                        ingredientsAddedToCurrentRecipe.Add(chosenIngredientForAction);
                    break;
                case "A1": 
                    chosenIngredientForAction = SelectIngredientFromList(ingredientsAddedToCurrentRecipe, "добавления");
                    if (chosenIngredientForAction == null)
                    {
                        Console.WriteLine("Не выбран ингредиент.");
                        break;
                    }

                    recipe = new Add(recipe, chosenIngredientForAction);
                    break;
                case "A2": 
                    chosenIngredientForAction = SelectIngredientFromList(ingredientsAddedToCurrentRecipe, "кипячения");
                    if (chosenIngredientForAction == null)
                    {
                        Console.WriteLine("Не выбран ингредиент.");
                        break;
                    }

                    recipe = new Boil(recipe, chosenIngredientForAction);
                    break;
                case "A3": 
                    chosenIngredientForAction =
                        SelectIngredientFromList(ingredientsAddedToCurrentRecipe, "перемалывания");
                    if (chosenIngredientForAction == null)
                    {
                        Console.WriteLine("Не выбран ингредиент.");
                        break;
                    }

                    recipe = new Grind(recipe, chosenIngredientForAction);
                    break;
                case "A4": 
                    recipe = new Mix(recipe);
                    break;
                case "A5": 
                    chosenLiquidForPour =
                        SelectIngredientFromList(ingredientsAddedToCurrentRecipe, "проливания (жидкость)");
                    if (chosenLiquidForPour == null)
                    {
                        Console.WriteLine("Не выбрана жидкость для проливания.");
                        break;
                    }

                    chosenMediumForPour =
                        SelectIngredientFromList(ingredientsAddedToCurrentRecipe, "проливания (среда)");
                    if (chosenMediumForPour == null)
                    {
                        Console.WriteLine("Не выбрана среда для проливания.");
                        break;
                    }

                    recipe = new Pour(recipe, chosenLiquidForPour, chosenMediumForPour);
                    break;
                case "A6": 
                    chosenIngredientForAction = SelectIngredientFromList(ingredientsAddedToCurrentRecipe, "взбивания");
                    if (chosenIngredientForAction == null)
                    {
                        Console.WriteLine("Не выбран ингредиент.");
                        break;
                    }

                    recipe = new Whisk(recipe, chosenIngredientForAction);
                    break;
                default:
                    Console.WriteLine("Неправильный ввод. Попробуйте снова.");
                    break;
            }
        }

        return recipe;
    }

    private Ingredient.Ingredient SelectIngredientFromList(List<Ingredient.Ingredient> availableIngredients,
        string actionContext)
    {
        if (!availableIngredients.Any())
        {
            Console.WriteLine(
                $"Невозможно выполнить действие '{actionContext}': нет доступных ингредиентов. Сначала добавьте ингредиенты, используя опции N1-N5.");
            return null;
        }

        Console.WriteLine($"\nВыберите ингредиент для {actionContext}:");
        for (int i = 0; i < availableIngredients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableIngredients[i].Describe()}");
        }

        Console.Write("Ваш выбор (номер): ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out int choiceIndex) && choiceIndex > 0 && choiceIndex <= availableIngredients.Count)
        {
            return availableIngredients[choiceIndex - 1];
        }
        else
        {
            Console.WriteLine("Неверный выбор ингредиента.");
            return null;
        }
    }

    private T GetIngredientDetails<T>(string prompt1, string prompt2 = null) where T : Ingredient.Ingredient
    {
        Console.Write(prompt1);
        var param1 = Console.ReadLine();

        string param2 = null;
        if (prompt2 != null)
        {
            Console.Write(prompt2);
            param2 = Console.ReadLine();
        }
        
        Ingredient.Ingredient createdIngredient = null;

        try
        {
            if (typeof(T) == typeof(Water))
            {
                if (decimal.TryParse(param1, out decimal weight))
                {
                    createdIngredient = new Water(weight);
                }
            }
            else if (typeof(T) == typeof(CoffeBeans))
            {
                if (decimal.TryParse(param2, out decimal weight))
                {
                    createdIngredient = new CoffeBeans(param1, weight);
                }
            }
            else if (typeof(T) == typeof(Milk))
            {
                if (decimal.TryParse(param2, out decimal weight))
                {
                    createdIngredient = new Milk(param1, weight);
                }
            }
            else if (typeof(T) == typeof(Syrop))
            {
                if (decimal.TryParse(param2, out decimal weight))
                {
                    createdIngredient = new Syrop(param1, weight);
                }
            }
            else if (typeof(T) == typeof(Ice))
            {
                if (decimal.TryParse(param1, out decimal weight))
                {
                    createdIngredient = new Ice(weight);
                }
            }
            
            if (createdIngredient != null)
            {
                return (T)createdIngredient;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при создании ингредиента: {ex.Message}");
        }

        Console.WriteLine(
            "Некорректный ввод данных для ингредиента или тип ингредиента не распознан. Пожалуйста, попробуйте снова.");
        return null;
    }
}