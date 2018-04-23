Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace T362981MVC
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
		End Function
		Public Function GridViewPartial() As ActionResult
		   Dim model = Enumerable.Range(0, 10).Select(Function(i) New With {Key .ProductID = i, Key .ProductName1 = "ProductName " & i, Key .ProductName2 = "ProductName " & i, Key .ProductName3 = "ProductName " & i, Key .ProductName4 = "ProductName " & i, Key .ProductName5 = "ProductName " & i})
			Return PartialView(model)
		End Function
	End Class
End Namespace