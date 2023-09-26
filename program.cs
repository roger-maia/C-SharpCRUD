using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Product> products = new List<Product>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateProduct();
                        break;
                    case 2:
                        ReadProducts();
                        break;
                    case 3:
                        UpdateProduct();
                        break;
                    case 4:
                        DeleteProduct();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void CreateProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter product price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Product newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price
            };
            products.Add(newProduct);
            Console.WriteLine("Product added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid price format. Please enter a valid number.");
        }
    }

    static void ReadProducts()
    {
        Console.WriteLine("Product List:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
        }
    }

    static void UpdateProduct()
    {
        Console.Write("Enter the ID of the product to update: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            var productToUpdate = products.FirstOrDefault(p => p.Id == id);
            if (productToUpdate != null)
            {
                Console.Write("Enter new product name: ");
                productToUpdate.Name = Console.ReadLine();

                Console.Write("Enter new product price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    productToUpdate.Price = price;
                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid price format. Update failed.");
                }
            }
            else
            {
                Console.WriteLine("Product with the specified ID not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid GUID.");
        }
    }

    static void DeleteProduct()
    {
        Console.Write("Enter the ID of the product to delete: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            var productToDelete = products.FirstOrDefault(p => p.Id == id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product with the specified ID not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format. Please enter a valid GUID.");
        }
    }
}

class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
