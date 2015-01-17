using System.Collections.Generic;
using System.Web;

public class CartItemList
{
    private readonly List<CartItem> _cartItems;

    public CartItemList()
    {
        this._cartItems = new List<CartItem>();
    }

    public int Count {
        get
        {
            return this._cartItems.Count;
        }
    }

    public CartItem this[int index]
    {
        get
        {
            return this._cartItems[index];
        }
        set
        {
            this._cartItems[index] = value;
        }
    }

    public CartItem this[string id]
    {
        get {
            foreach (var c in this._cartItems)
                if (c.Product.ProductId == id) return c;
            return null;
        }
    }

    public static CartItemList GetCart()
    {
        var cart = (CartItemList) HttpContext.Current.Session["Cart"];
        if (cart == null)
            HttpContext.Current.Session["Cart"] = new CartItemList();
        return (CartItemList) HttpContext.Current.Session["Cart"];
    }

    public void AddItem(Product product, int quantity)
    {
        var newItem = new CartItem(product, quantity);
        this._cartItems.Add(newItem);
    }

    public void RemoveAt(int index)
    {
        this._cartItems.RemoveAt(index);
    }

    public void Clear()
    {
        this._cartItems.Clear();
    }
}