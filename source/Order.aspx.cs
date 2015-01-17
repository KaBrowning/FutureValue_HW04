
using System.ComponentModel;
using System.Data;
using System.Web.UI;

public partial class Order : System.Web.UI.Page
{
    private Product selectedProduct;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        
    }

    private Product GetSelectedProduct()
    {
        //get row from SqlDataSource based on value in dropdown list
        DataView productsTable = (DataView)
            this.SqlDataSource.Select(DataSourceSelectArguments.Empty);
        productsTable.RowFilter = string.Format("ProductID = '{0}'",
            this.ddlProducts.SelectedValue);
        var row = (DataRowView) productsTable[0];

        //create a new product object and load with data from row
        Product p = new Product();
        p.ProductId = row["ProductID"].ToString();
        p.Name = row["Name"].ToString();
        p.ShortDescription = row["ShortDescription"].ToString();
        p.LongDescription = row["LongDescription"].ToString();
        p.UnitPrice = (decimal) row["UnitPrice"];
        p.ImageFile = row["ImageFile"].ToString();
        return p;
    }
}
