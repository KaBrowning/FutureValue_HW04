
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI;

public partial class Order : System.Web.UI.Page
{
    private Product _selectedProduct;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, System.EventArgs e)
    {
        //bind drop-down list on first load
        //get and show product on every load
        if (!IsPostBack) this.ddlProducts.DataBind();
        this._selectedProduct = this.GetSelectedProduct();
        this.lblName.Text = this._selectedProduct.Name;
        this.lblShortDescription.Text = this._selectedProduct.ShortDescription;
        this.lblLongDescription.Text = this._selectedProduct.LongDescription;
        this.lblUnitPrice.Text = this._selectedProduct.UnitPrice.ToString("c") + " each";
        this.imgProduct.ImageUrl = "Images/Products/" + this._selectedProduct.ImageFile;
    }

    /// <summary>
    /// Gets the selected product.
    /// </summary>
    /// <returns>The new product item</returns>
    private Product GetSelectedProduct()
    {
        //get row from SqlDataSource based on value in dropdown list
        var productsTable = (DataView)
            this.SqlDataSource.Select(DataSourceSelectArguments.Empty);
        productsTable.RowFilter = string.Format("ProductID = '{0}'",
            this.ddlProducts.SelectedValue);
        var row = (DataRowView) productsTable[0];

        //create a new product object and load with data from row
        var p = new Product
        {
            ProductId = row["ProductID"].ToString(),
            Name = row["Name"].ToString(),
            ShortDescription = row["ShortDescription"].ToString(),
            LongDescription = row["LongDescription"].ToString(),
            UnitPrice = (decimal) row["UnitPrice"],
            ImageFile = row["ImageFile"].ToString()
        };
        return p;
    }


    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, System.EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        //get cart from session state and selected item from cart
        var cart = CartItemList.GetCart();
        var cartItem = cart[this._selectedProduct.ProductId];

        //if item isn't in cart, add it; otherwise, increase its quantity
        if (cartItem == null)
        {
            cart.AddItem(this._selectedProduct, Convert.ToInt32(this.txtQuantity.Text));
        }
        else
        {
            cartItem.AddQuantity(Convert.ToInt32(this.txtQuantity.Text));
        }
        Response.Redirect("Cart.aspx");
    }
}
