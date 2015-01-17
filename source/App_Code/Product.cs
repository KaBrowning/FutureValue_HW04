using System.Diagnostics;

/// <summary>
/// Gets and sets item information.
/// </summary>
/// <author>Kathryn Browning</author>
/// <version>January 17, 2015</version>
public class Product
{

    private string _productId;
    private string _name;
    private string _shortDescription;
    private string _longDescription;
    private decimal _unitPrice;
    private string _imageFile;

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
            Trace.Assert(value !=null, "Invalid Product ID of Item");
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

    /// <summary>
    /// Gets or sets the short description.
    /// </summary>
    /// <value>
    /// The short description.
    /// </value>
    public string ShortDescription
    {
        get { return this._shortDescription; }
        set
        {
            Trace.Assert(value != null, "Invalid Short Description of Item."); 
            this._shortDescription = value;
        }
    }

    /// <summary>
    /// Gets or sets the long description.
    /// </summary>
    /// <value>
    /// The long description.
    /// </value>
    public string LongDescription
    {
        get { return this._longDescription; }
        set
        {
            Trace.Assert(value != null, "Invalid Long Description of Item.");
            this._longDescription = value;
        }
    }


    /// <summary>
    /// Gets or sets the unit price.
    /// </summary>
    /// <value>
    /// The unit price.
    /// </value>
    public decimal UnitPrice
    {
        get { return this._unitPrice; }
        set
        {
            Trace.Assert(true, "Invalid Unit Price of Item.");
            this._unitPrice = value;
        }
    }

    /// <summary>
    /// Gets or sets the image file.
    /// </summary>
    /// <value>
    /// The image file.
    /// </value>
    public string ImageFile
    {
        get { return this._imageFile; }
        set
        {
            Trace.Assert(value != null, "Invalid Image File of Item.");
            this._imageFile = value;
        }
    }
}