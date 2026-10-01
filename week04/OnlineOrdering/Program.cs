using System;
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Dallas",
            "Texas",
            "USA"
        );

        Customer customer1 = new Customer("John Smith", address1);
   
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P001", 500, 1));
        order1.AddProduct(new Product("Mouse", "P002", 20, 4));
        order1.AddProduct(new Product("Keyboard", "P003", 30, 1));

        
        Address address2 = new Address(
            "2 Akpoha Street",
            "Abakaliki",
            "Ebonyi",
            "Nigeria"
        );

        Customer customer2 = new Customer("Mercy Ani", address2);

       
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Phone", "P004", 300, 1));
        order2.AddProduct(new Product("Charger", "P005", 25, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}