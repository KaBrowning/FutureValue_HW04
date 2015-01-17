
public partial class Cart : System.Web.UI.Page
{
    private CartItemList _cart;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, System.EventArgs e)
    {
        //retrieve cart object from session state on every post back
        this._cart = CartItemList.GetCart();

        //on initial page load, add cart items to list control
        if (!IsPostBack)
        {
            this.DisplayCart();
        }
    }

    /// <summary>
    /// Displays the cart.
    /// </summary>
    private void DisplayCart()
    {
        //remove all current items from list control
        this.lstCart.Items.Clear();

        //loop thorugh cart and add each item's Display value to the control
        for (var i = 0; i < this._cart.Count; i++)
        {
            this.lstCart.Items.Add(this._cart[i].Display());
        }
            
    }


    /// <summary>
    /// Handles the Click event of the btnRemove control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnRemove_Click(object sender, System.EventArgs e)
    {
        //if cart contains items and user has selected an item...
        if (this._cart.Count <= 0)
        {
            return;
        }
        if (this.lstCart.SelectedIndex > -1)
        {
            //remove selected items from cart and re-add cart items
            this._cart.RemoveAt(this.lstCart.SelectedIndex);
            this.DisplayCart();
        }
        else
        {
            //if no items is selected, notify user
            this.lblMessage.Text = "Please select an item to remove.";
        }
    }
}