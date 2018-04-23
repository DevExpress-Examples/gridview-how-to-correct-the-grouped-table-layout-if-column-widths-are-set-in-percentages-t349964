@Imports T362981MVC.Helpers
@Code
    Dim helper As GridViewColumnHelper
    Dim grid = Html.DevExpress().GridView(Sub(settings)
    
                                                  settings.Name = "GridView"
                                                  settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
                                                  settings.Width = Unit.Percentage(100)
                                                  settings.Settings.ShowGroupPanel = True
                                                  settings.SettingsBehavior.ColumnResizeMode = ColumnResizeMode.NextColumn
                                                  settings.KeyFieldName = "ProductID"
                                                  settings.Columns.Add(Sub(column)
        
                                                                               column.FieldName = "ProductID"
                                                                               column.Width = Unit.Percentage(10)
                                                                               column.GroupIndex = 0

                                                                       End Sub)

                                                  settings.Columns.Add(Sub(column)
        
                                                                               column.FieldName = "ProductName1"
                                                                               column.Width = Unit.Percentage(40)
                                                                               column.GroupIndex = 1
                                                                       End Sub)

                                                  settings.Columns.Add(Sub(column)
        
                                                                               column.FieldName = "ProductName2"
                                                                               column.Width = Unit.Percentage(40)

                                                                       End Sub)

                                                  settings.Columns.Add(Sub(column)
        
                                                                               column.FieldName = "ProductName3"
                                                                               column.Width = Unit.Percentage(10)

                                                                       End Sub)

                                                  settings.Columns.Add(Sub(column)
        
                                                                               column.FieldName = "ProductName4"
                                                                               column.Width = Unit.Percentage(10)
                                                                       End Sub)

                                                  settings.Columns.Add(Sub(column)
        
                                                                               column.FieldName = "ProductName5"
                                                                               column.Width = Unit.Percentage(10)

                                                                       End Sub)
                                                  settings.Init = Sub(s, e)
                                                                          helper = New GridViewColumnHelper(TryCast(s, MVCxGridView))
                                                                          helper.RestoreColumnWidth()
                                                                  End Sub

                                                  
                                                  settings.BeforeGetCallbackResult = Sub(s, e)
        
                                                                                             helper = New GridViewColumnHelper(s)
                                                                                             Dim column = helper.GetColumnToResetWidth()
                                                                                             If column IsNot Nothing Then
                                                                                                 column.Width = Unit.Empty
                                                                                             End If
                                                                                     End Sub
                                                  settings.PreRender = settings.BeforeGetCallbackResult
                                          End Sub)

End Code
@grid.Bind(Model).GetHtml()
