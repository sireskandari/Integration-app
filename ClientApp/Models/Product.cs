namespace ClientApp.Models;

public sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public int Stock { get; set; }
    public Category Category { get; set; } = new();
}

public sealed class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}