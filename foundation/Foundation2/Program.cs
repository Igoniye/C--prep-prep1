using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");
    }
}
using System;
using System.Collections.Generic;

// Define a class for an Address
public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}

// Define a class for a Customer
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public override string ToString()
    {
        return $"{name}\n{address}";
    }
}

// Define a class for a Product
public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public override string ToString()
    {
        return $"{name} ({productId}) - ${price} x {quantity} = ${GetTotalCost()}";
    }
}

// Define a class for an Order
public class Order
{
    private List<Product> products;
    private Customer customer;
    private const decimal shippingCostUSA = 5.00m;
    private const decimal shippingCostInternational = 35.00m;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.GetTotalCost();
        }
        if (customer.IsInUSA())
        {
            totalCost += shippingCostUSA;
        }
        else
        {
            totalCost += shippingCostInternational;
        }
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"{product.name} ({product.productId})\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return customer.ToString();
    }

    public override string ToString()
    {
        string orderSummary = "Order Summary:\n";
        foreach (Product product in products)
        {
            orderSummary += product.ToString() + "\n";
        }
        orderSummary += $"Total Cost: ${GetTotalCost():F2}";
        return orderSummary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create customers
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 Elm St", "Othertown", "NY", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Product 1", "P001", 19.99m, 2);
        Product product2 = new Product("Product 2", "P002", 9.99m, 3);
        Product product3 = new Product("Product 3", "P003", 29.99m, 1);

        Product product4 = new Product("Product 4", "P004", 14.99m, 4);
        Product product5 = new Product("Product 5", "P005", 24.99m, 2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display order information
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine(order1.ToString());
        Console
