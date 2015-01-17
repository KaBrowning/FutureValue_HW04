using System;
using System.Diagnostics;
using System.Security.Policy;

public class Product
{

    private string _productId;
    private string _name;
    private string _shortDescription;

    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    /// <value>
    /// The product identifier.
    /// </value>
    public string ProductId
    {
        get { return this._productId; }
        set
        {
            Trace.Assert(value !=null, "Invalid Product ID");
            this._productId = value;
        }
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name
    {
        get { return this._name; }
        set
        {
            Trace.Assert(value != null, "Invalid Name of Item");
            this._name = value;
        }

    }

    public string ShortDescription
    {
        get { return _shortDescription; }
        set
        {
            Trace.Assert(value != null, "Invalid Short Description of Item."); 
            this._shortDescription = value;
        }
    }



    public string LongDescription { get; set; }
    public decimal UnitPrice { get; set; }
    public string ImageFile { get; set; }
}