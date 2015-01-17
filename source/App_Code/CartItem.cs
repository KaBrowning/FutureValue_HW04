/// <summary>
/// 
/// </summary>
/// <author>Kathryn Browning</author>
/// <version>January 17, 2015</version>
public class CartItem
{
    public CartItem() {}

    /// <summary>
    /// Initializes a new instance of the <see cref="CartItem"/> class.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <param name="quantity">The quantity.</param>
    public CartItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }

    //TODO FIX
    public Product Product { get; set; }
    public int Quantity { get; set; }

    /// <summary>
    /// Adds the quantity.
    /// </summary>
    /// <param name="quantity">The quantity.</param>
    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    /// <summary>
    /// Displays this instance.
    /// </summary>
    /// <returns>How many of an item were selected, the item name, and how much an item costs</returns>
    public string Display()
    {
        var displayString = string.Format("{0} ({1} at {2} each)", 
            this.Product.Name, this.Quantity.ToString(), 
            this.Product.UnitPrice.ToString("c"));
        return displayString;
    }
    
}