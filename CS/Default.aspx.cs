using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;

namespace WebApplication1 {
    public partial class _Default : System.Web.UI.Page {
        private ASPxGridView grid = null;
        private DataTable dt = null;
        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            grid = new ASPxGridView();
            Form.Controls.Add(grid);
            dt = new DataTable();
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Quantity", typeof(float));

            dt.Rows.Add(new object[] { "Beverages", "Chai", 1.6, 319 });
            dt.Rows.Add(new object[] { "Beverages", "Chai", 6295.5, 399 });
            dt.Rows.Add(new object[] { "Beverages", "Ipoh Coffee", 10034.9, 228 });
            dt.Rows.Add(new object[] { "Confections", "Chocolade", 1282.1, 130 });
            dt.Rows.Add(new object[] { "Confections", "Chocolade", 86.7, 8 });
            dt.Rows.Add(new object[] { "Confections", "Scottish Longbreads", 3909.0, 380 });
            grid.KeyFieldName = "Category";
            grid.DataSource = dt.DefaultView;
            grid.DataBind();
            ((GridViewDataColumn)grid.Columns["Product"]).DataItemTemplate = new MyDivTemplate();
        }
    }
    public class MyDivTemplate : ITemplate {
        void ITemplate.InstantiateIn(Control container) {
            GridViewDataItemTemplateContainer gridContainer = (GridViewDataItemTemplateContainer)container;
            HtmlGenericControl div = new HtmlGenericControl();
            div.TagName = "div";
            div.Style["text-overflow"] = "ellipsis";
            div.Style["color"] = "red";
            div.Style["fond-weight"] = "bold";
            div.Style["width"] = "50px";
            div.Style["overflow"] = "hidden";
            div.Style["white-space"] = "nowrap";
            div.InnerText = gridContainer.Grid.GetRowValues(gridContainer.ItemIndex, "Product").ToString();
            container.Controls.Add(div);
        }
    }
}