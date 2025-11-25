using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeDecorator
{
    // ----------------------------
    // 1. Component Interface
    // ----------------------------
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // ----------------------------
    // 2. Concrete Component
    // ----------------------------
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 50.0; // base price
    }
    // ----------------------------
    // 3. Base Decorator
    // ----------------------------
    public abstract class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual double GetCost() => _coffee.GetCost();
    }
    // ----------------------------
    // 4. Concrete Decorators
    // ----------------------------

    // Milk
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", Milk";
        public override double GetCost() => _coffee.GetCost() + 10.0;
    }
    // Sugar
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", Sugar";
        public override double GetCost() => _coffee.GetCost() + 5.0;
    }

    // Whipped Cream
    public class WhippedCreamDecorator : CoffeeDecorator
    {
        public WhippedCreamDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", Whipped Cream";
        public override double GetCost() => _coffee.GetCost() + 20.0;
    }

    // Chocolate
    public class ChocolateDecorator : CoffeeDecorator
    {
        public ChocolateDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", Chocolate";
        public override double GetCost() => _coffee.GetCost() + 15.0;
    }

    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("=== COFFEE DECORATOR DEMO ===\n");

            // Scenario 1 — ALL 4 TOPPINGS
            ICoffee coffee1 = new SimpleCoffee();
            coffee1 = new MilkDecorator(coffee1);
            coffee1 = new SugarDecorator(coffee1);
            coffee1 = new WhippedCreamDecorator(coffee1);
            coffee1 = new ChocolateDecorator(coffee1);

            Console.WriteLine("With ALL 4 toppings:");
            Console.WriteLine("Description: " + coffee1.GetDescription());
            Console.WriteLine("Total Price: ₹" + coffee1.GetCost());
            Console.WriteLine();

            // Scenario 2 — Skip one topping (skip WhippedCream)
            ICoffee coffee2 = new SimpleCoffee();
            coffee2 = new MilkDecorator(coffee2);
            coffee2 = new SugarDecorator(coffee2);
            coffee2 = new ChocolateDecorator(coffee2); // skipping whipped cream

            Console.WriteLine("Skipping Whipped Cream:");
            Console.WriteLine("Description: " + coffee2.GetDescription());
            Console.WriteLine("Total Price: ₹" + coffee2.GetCost());
            Console.WriteLine();
        }
    }
}
