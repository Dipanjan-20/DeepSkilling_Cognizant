using System;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product[] products = new Product[]
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(203, "Shoes", "Apparel"),
            new Product(150, "Watch", "Accessories"),
            new Product(120, "Phone", "Electronics")
        };

        Console.WriteLine(" Linear Search for ProductId 150:");
        var linearResult = LinearSearch(products, 150);

        if (linearResult != null)
            Console.WriteLine($"Found: {linearResult.ProductName} in {linearResult.Category}");
        else
            Console.WriteLine("Product not found.");

        var sortedProducts = products.OrderBy(p => p.ProductId).ToArray();

        Console.WriteLine("\n Binary Search for ProductId 150:");
        var binaryResult = BinarySearch(sortedProducts, 150);

        if (binaryResult != null)
            Console.WriteLine($"Found: {binaryResult.ProductName} in {binaryResult.Category}");
        else
            Console.WriteLine("Product not found.");
    }

    public static Product LinearSearch(Product[] products, int targetId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == targetId)
            {
                return product;
            }
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, int targetId)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (products[mid].ProductId == targetId)
            {
                return products[mid];
            }
            else if (products[mid].ProductId < targetId)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return null;
    }
}
