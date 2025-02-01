public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const double USA_SHIPPING_COST = 5.00;
    private const double INTERNATIONAL_SHIPPING_COST = 35.00;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += _customer.LivesInUSA() ? USA_SHIPPING_COST : INTERNATIONAL_SHIPPING_COST;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in _products)
        {
            label += product.GetProductLabel() + "\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddressString()}";
    }
}
