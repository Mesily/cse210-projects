public class Product
{
    private string _name;
    private string _productid;
    private double _price;
    private int _quantity;

    public Product(string name, string productid, double price, int quantity)
    {
        _name = name;
        _productid = productid;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productid;
    }
}