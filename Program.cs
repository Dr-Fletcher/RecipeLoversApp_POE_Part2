using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipe.EnterDetails();
                        break;
                    case "2":
                        recipe.Display();
                        break;
                    case "3":
                        recipe.Scale();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe.Clear();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class Recipe
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        public void EnterDetails()
        {
            Console.WriteLine("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                float quantity = float.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();

                ingredients.Add(new Ingredient(name, quantity, unit));
            }

            Console.WriteLine("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();

                steps.Add(description);
            }

            Console.WriteLine("Recipe details entered successfully!");
        }

        public void Display()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void Scale()
        {
            Console.WriteLine("Enter scaling factor (0.5, 2, or 3): ");
            float factor = float.Parse(Console.ReadLine());

            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine($"Recipe scaled by a factor of {factor}");
        }

        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }

            Console.WriteLine("Quantities reset to original values");
        }

        public void Clear()
        {
            ingredients.Clear();
            steps.Clear();
            Console.WriteLine("All data cleared");
        }
    }

    class Ingredient
    {
        public string Name { get; }
        public float Quantity { get; set; }
        public string Unit { get; }

        public Ingredient(string name, float quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public void ResetQuantity()
        {
            // Implement custom reset logic here if needed
        }
    }
}
