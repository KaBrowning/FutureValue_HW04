﻿
using System;
using System.Data;
using System.Web.UI;

/// <summary>
/// Creates the page load event as well as button click events for Order.aspx
/// </summary>
/// <author>Kathryn Browning</author>
/// <version>January 17, 2015</version>
public partial class Order : Page
{
    private Product _selectedProduct;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
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
        var productsTable = (DataView)
            this.SqlDataSource.Select(DataSourceSelectArguments.Empty);
        if (productsTable == null)
        {
            return null;
        }
        productsTable.RowFilter = string.Format("ProductID = '{0}'",
            this.ddlProducts.SelectedValue);
        var row = productsTable[0];
        
        var product = new Product
        {
            ProductId = row["ProductID"].ToString(),
            Name = row["Name"].ToString(),
            ShortDescription = row["ShortDescription"].ToString(),
            LongDescription = row["LongDescription"].ToString(),
            UnitPrice = (decimal) row["UnitPrice"],
            ImageFile = row["ImageFile"].ToString()
        };
        return product;
    }


    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        var cart = CartItemList.GetCart();
        var cartItem = cart[this._selectedProduct.ProductId];

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
