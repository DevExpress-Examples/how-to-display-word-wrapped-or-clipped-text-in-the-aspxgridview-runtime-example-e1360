Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView

Namespace WebApplication1
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private grid As ASPxGridView = Nothing
		Private dt As DataTable = Nothing
		Protected Overrides Sub OnInit(ByVal e As EventArgs)
			MyBase.OnInit(e)
			grid = New ASPxGridView()
			Form.Controls.Add(grid)
			dt = New DataTable()
			dt.Columns.Add("Category", GetType(String))
			dt.Columns.Add("Product", GetType(String))
			dt.Columns.Add("Price", GetType(Single))
			dt.Columns.Add("Quantity", GetType(Single))

			dt.Rows.Add(New Object() { "Beverages", "Chai", 1.6, 319 })
			dt.Rows.Add(New Object() { "Beverages", "Chai", 6295.5, 399 })
			dt.Rows.Add(New Object() { "Beverages", "Ipoh Coffee", 10034.9, 228 })
			dt.Rows.Add(New Object() { "Confections", "Chocolade", 1282.1, 130 })
			dt.Rows.Add(New Object() { "Confections", "Chocolade", 86.7, 8 })
			dt.Rows.Add(New Object() { "Confections", "Scottish Longbreads", 3909.0, 380 })
			grid.KeyFieldName = "Category"
			grid.DataSource = dt.DefaultView
			grid.DataBind()
			CType(grid.Columns("Product"), GridViewDataColumn).DataItemTemplate = New MyDivTemplate()
		End Sub
	End Class
	Public Class MyDivTemplate
		Implements ITemplate
		Private Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			Dim gridContainer As GridViewDataItemTemplateContainer = CType(container, GridViewDataItemTemplateContainer)
			Dim div As New HtmlGenericControl()
			div.TagName = "div"
			div.Style("text-overflow") = "ellipsis"
			div.Style("color") = "red"
			div.Style("fond-weight") = "bold"
			div.Style("width") = "50px"
			div.Style("overflow") = "hidden"
			div.Style("white-space") = "nowrap"
			div.InnerText = gridContainer.Grid.GetRowValues(gridContainer.ItemIndex, "Product").ToString()
			container.Controls.Add(div)
		End Sub
	End Class
End Namespace