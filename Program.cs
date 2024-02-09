// See https://aka.ms/new-console-template for more information
string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";
Console.WriteLine(greeting);

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product() 
    { 
        Name = "Hockey Stick", 
        Price = 12.99M, 
        Sold = false,
        StockDate = new DateTime(2022, 12, 30),
        ManufactureYear = 2015,
        Condition = 4.5
        
    },
    new Product()
    {
        Name = "Boomerang",
        Price = 10.75M,
        Sold = false,
        StockDate = new DateTime(2023, 8, 18),
        ManufactureYear = 2017,
        Condition = 3.2
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 5.50M,
        Sold = false,
        StockDate = new DateTime(2023, 11, 13),
        ManufactureYear = 2012,
        Condition = 4.0
    },
    new Product()
    {
        Name = "Golf Putter",
        Price = 45.00M,
        Sold = true,
        StockDate = new DateTime(2023, 12, 26),
        ManufactureYear = 2020,
        Condition = 4.9
    },
    new Product()
    {
        Name = "Baseball Glove",
        Price = 35.55M,
        Sold = false,
        StockDate = new DateTime(2024, 1, 21),
        ManufactureYear = 2022,
        Condition = 3.5
    }
};

decimal totalValue = 0.0M;
foreach (Product product in products) {
    if (!product.Sold) 
    {
        totalValue += product.Price;
    }
}

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products
                        4. Purchase Product");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
    else if (choice == "4")
    {
        PurchaseProduct();
    }
    
}



void ViewProductDetails()
{
    ListProducts();

    Console.WriteLine($"Total inventory value: ${totalValue}");

    Console.WriteLine("Products:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    DateTime now = DateTime.Now;

    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: 
    {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
    It is {now.Year - chosenProduct.ManufactureYear} years old. 
    It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through the products
    foreach (Product product in products)
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

void PurchaseProduct()
{
    Console.WriteLine("Enter the number of the product you would like to purchase:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    int response = 0;
    Product purchasedProduct = null;
    try
        {
            response = int.Parse(Console.ReadLine().Trim());
            purchasedProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    
    Console.WriteLine($"Enjoy your {purchasedProduct.Name}!");
    products.RemoveAt(response - 1);
}