using MauiApp1.Model;

namespace MauiApp1.Services;

public class PizzaService
{
    private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>
    {
        new Pizza
        {
            Name = "Pepperoni",
            Image = "pizza2.png",
            Price = 10.99
        },
        new Pizza
        {
            Name = "Margherita",
            Image = "pizza1.png",
            Price = 9.99
        },
        new Pizza
        {
            Name = "Hawaiian",
            Image = "pizza3.png",
            Price = 11.99
        },
        new Pizza
        {
            Name = "Veggie",
            Image = "pizza1.png",
            Price = 8.99
        },
        new Pizza
        {
            Name = "BBQ Chicken",
            Image = "pizza2.png",
            Price = 12.99
        },
        new Pizza
        {
            Name = "Meat Lovers",
            Image = "pizza3.png",
            Price = 13.99
        },
        new Pizza
        {
            Name = "Supreme",
            Image = "pizza1.png",
            Price = 14.99
        },
    };
    
    public IEnumerable<Pizza> GetAllPizzas()  => _pizzas;
    
    public IEnumerable<Pizza> GetPopularPizzas(int count = 4) => 
        _pizzas.OrderBy(p => Guid.NewGuid()).Take(count);
    
    public IEnumerable<Pizza> SearchPizzas(string search) => 
        string.IsNullOrWhiteSpace(search) 
            ? _pizzas 
            : _pizzas.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    
}