public class Product : ISearchable
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Order> PurchaseHistory { get; set; } = new List<Order>();
}
public class Order
{
    public List<Product> Products { get; set; } = new List<Product>();
    public int Quantity { get; set; }
    public double TotalCost => Products.Sum(p => p.Price * Quantity);
    public string Status { get; set; }
}
public interface ISearchable
{
    List<Product> SearchByCriteria(string criteria);
}
public class Shop : ISearchable
{
    public List<User> Users { get; set; } = new List<User>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Order> Orders { get; set; } = new List<Order>();

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void PlaceOrder(User user, List<Product> products, int quantity)
    {
        var order = new Order
        {
            Products = products,
            Quantity = quantity,
            Status = "Pending" 
        };

        user.PurchaseHistory.Add(order);
        Orders.Add(order);
    }

    public List<Product> SearchByCriteria(string criteria)
    {  
        return Products.Where(p => p.Name.Contains(criteria) || p.Category.Contains(criteria)).ToList();
    }
}