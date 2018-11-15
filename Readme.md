<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [GridViewColumnHelper.cs](./CS/Helpers/GridViewColumnHelper.cs) (VB: [GridViewColumnHelper.vb](./VB/Helpers/GridViewColumnHelper.vb))
* **[GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)**
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to correct the grouped table layout if column widths are set in percentages


This example illustrates the solution for the first issue described at <a href="https://www.devexpress.com/Support/Center/p/T362981">ASPxGridView - Why column layout may become broken after user actions if certain column widths are set in percentages</a>. <br>The main idea is to determine the widest column and delete its width setting. As a result, the widest column will fill the space that appears after moving one of the columns to the Group panel. <br>For this, we implemented the GridViewColumnHelper class and use Session  to preserve information about column width between requests to the server.

<br/>


