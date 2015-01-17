using System.Diagnostics;

/// <summary>
/// Gets and sets the product and the quantity of that product and displays the result in the cart.
/// </summary>
/// <author>Kathryn Browning</author>
/// <version>January 17, 2015</version>
public class CartItem
{
    private Product _product;
    private int _quantity;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartItem"/> class.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>
    /// The product.
    /// </value>
    public Product Product
    {
        get { return this._product; }
        set
        {
            Trace.Assert(value != null, "Invalid Product.");
            this._product = value;
        }
    }

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    /// <value>
    /// The quantity.
    /// </value>
    public int Quantity
    {
        get { return this._quantity; }
        set
        {
            Trace.Assert(true, "Invalid Quantity of Item.");
            this._quantity = value;
        }
    }

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