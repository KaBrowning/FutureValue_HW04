public class CartItem
{
    public CartItem() {}

    public CartItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }

    public Product Product { get; set; }
    public int Quantity { get; set; }

    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    public string Display()
    {
        var displayString =
            this.Product.Name + " (" + this.Quantity.ToString()
            + " at " + this.Product.UnitPrice.ToString("c") + " each)";

        return displayString;
    }
    
}