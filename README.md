# ☕ Coffee Decorator Pattern (C#)

This project demonstrates the **Decorator Design Pattern** using a Coffee Pricing example in C#.  
The Decorator pattern allows you to **add features dynamically** without modifying existing classes.

This is one of the most commonly asked System Design + OOP interview topics.

---

##  What Problem Does Decorator Solve?

When you want to add new behaviors (like Milk, Sugar, Chocolate, etc.) to an object **dynamically**, without:

- modifying the original class  
- creating subclasses for every combination  

Instead of:

❌ Creating classes like:
- `CoffeeWithMilk`
- `CoffeeWithMilkAndSugar`
- `CoffeeWithChocolateAndCreamAndSugar`

You build behavior **dynamically with decorators**.

---

#  Decorator Pattern Structure

┌────────────────────────┐
│ ICoffee │ <-- Component
└──────────┬─────────────┘
│
┌──────────▼─────────────┐
│ SimpleCoffee │ <-- Concrete Component
└──────────┬─────────────┘
│
│ wraps
▼
┌────────────────────────┐
│ CoffeeDecorator │ <-- Base Decorator
└──────────┬─────────────┘
│
├──────────────────────────┐
▼ ▼
┌──────────────────┐ ┌──────────────────┐
│ MilkDecorator │ │ SugarDecorator │
└──────────────────┘ └──────────────────┘
... More decorators ...

yaml
Copy code

Each decorator wraps a coffee object and adds:
- Extra description
- Extra cost

---

#  Features Implemented

✔ Base Coffee  
✔ Four decorators:
- Milk  
- Sugar  
- Chocolate  
- Whipped Cream  

✔ Dynamic composition  
✔ Price calculation  
✔ Two scenarios:
- All toppings  
- Skipping some toppings  

---

#  Code Example

### Creating a coffee with all toppings:

```csharp
ICoffee coffee = new SimpleCoffee();
coffee = new MilkDecorator(coffee);
coffee = new SugarDecorator(coffee);
coffee = new WhippedCreamDecorator(coffee);
coffee = new ChocolateDecorator(coffee);

Console.WriteLine(coffee.GetDescription());
Console.WriteLine(coffee.GetCost());
Output:
nginx
Copy code
Simple Coffee, Milk, Sugar, Whipped Cream, Chocolate  
100
 Sample Output (Full Program)
yaml
Copy code
=== COFFEE DECORATOR DEMO ===

With ALL 4 toppings:
Description: Simple Coffee, Milk, Sugar, Whipped Cream, Chocolate
Total Price: ₹100

Skipping Whipped Cream:
Description: Simple Coffee, Milk, Sugar, Chocolate
Total Price: ₹80
