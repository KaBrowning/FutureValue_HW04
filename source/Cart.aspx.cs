
/// <summary>
/// Configures the page load event as well as button events for the Cart class.
/// </summary>
/// <author>Kathryn Browning</author>
/// <version>January 17, 2015</version>
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
        this._cart = CartItemList.GetCart();

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
        this.lstCart.Items.Clear();

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
        if (this._cart.Count <= 0)
        {
            return;
        }
        if (this.lstCart.SelectedIndex > -1)
        {
            this._cart.RemoveAt(this.lstCart.SelectedIndex);
            this.DisplayCart();
        }
        else
        {
            this.lblMessage.Text = "Please select an item to remove.";
        }
    }


    /// <summary>
    /// Handles the Click event of the btnEmpty control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnEmpty_Click(object sender, System.EventArgs e)
    {
        if (this._cart.Count <= 0)
        {
            return;
        }
        this._cart.Clear();
        this.lstCart.Items.Clear();
    }


    /// <summary>
    /// Handles the Click event of the btnCheckOut control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnCheckOut_Click(object sender, System.EventArgs e)
    {
        this.lblMessage.Text = "Sorry, that function hasn't been implemented yet.";
    }
}