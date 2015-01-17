
using System.ComponentModel;
using System.Data;
using System.Web.UI;

public partial class Order : System.Web.UI.Page
{
    private Product selectedProduct;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        //bind drop-down list on first load
        //get and show product on every load
        if (!IsPostBack) this.ddlProducts.DataBind();
        this.selectedProduct = this.GetSelectedProduct();
        this.lblName.Text = this.selectedProduct.Name;
        this.lblShortDescription.Text = this.selectedProduct.ShortDescription;
        this.lblLongDescription.Text = this.selectedProduct.LongDescription;
        this.lblUnitPrice.Text = this.selectedProduct.UnitPrice.ToString("c") + "each";
        this.imgProduct.ImageUrl = "Images/Products/" + this.selectedProduct.ImageFile;
    }

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
}
