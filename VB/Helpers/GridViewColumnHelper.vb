Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls
Imports DevExpress.Web.Mvc

Namespace T362981MVC.Helpers
    Public Class GridViewColumnHelper
        Public Sub New(ByVal grid As MVCxGridView)
            GridInstance = grid
            ClientColumnsWidth = TryCast(HttpContext.Current.Session(grid.ID), IDictionary(Of Integer, Double))
            If ClientColumnsWidth Is Nothing Then
                ClientColumnsWidth = New Dictionary(Of Integer, Double)()
                HttpContext.Current.Session(grid.ID) = ClientColumnsWidth
            End If
        End Sub

        Private privateGrid As MVCxGridView
        Protected Property GridInstance() As MVCxGridView
            Get
                Return privateGrid
            End Get
            Private Set(ByVal value As MVCxGridView)
                privateGrid = value
            End Set
        End Property

        Private privateClientColumnsWidth As IDictionary(Of Integer, Double)
        Protected Property ClientColumnsWidth() As IDictionary(Of Integer, Double)
            Get
                Return privateClientColumnsWidth
            End Get
            Private Set(ByVal value As IDictionary(Of Integer, Double))
                privateClientColumnsWidth = value
            End Set
        End Property

        Public Sub RestoreColumnWidth()
            For Each keyPairValue In ClientColumnsWidth
                GridInstance.Columns(keyPairValue.Key).Width = Unit.Percentage(keyPairValue.Value)
            Next keyPairValue
        End Sub
        Public Function GetColumnToResetWidth() As GridViewDataColumn
            If GetTotalColumnPercentWidth() >= 100 Then
                Return Nothing
            End If
            Dim widestDataColumn As GridViewDataColumn = FindWidestDataColumn()

            ClientColumnsWidth(widestDataColumn.Index) = widestDataColumn.Width.Value
            Return widestDataColumn
        End Function
        Private Function GetTotalColumnPercentWidth() As Double
            Dim totalPercentWidth As Double = 0
            For Each dataColumn In GetVisibleUnGroupedColumns()
                If dataColumn.Width.Type <> UnitType.Percentage Then
                    Continue For
                End If
                totalPercentWidth += dataColumn.Width.Value
            Next dataColumn
            Return totalPercentWidth
        End Function
        Private Function FindWidestDataColumn() As GridViewDataColumn
            Dim widestColumn As GridViewDataColumn = Nothing
            For Each column In GetVisibleUnGroupedColumns()
                If column.Width.Type <> UnitType.Percentage Then
                    Continue For
                End If
                If widestColumn Is Nothing OrElse widestColumn.Width.Value < column.Width.Value Then
                    widestColumn = column
                End If
            Next column
            Return widestColumn
        End Function
        Private Function GetVisibleUnGroupedColumns() As IEnumerable(Of GridViewDataColumn)
            Return GridInstance.DataColumns.Where(Function(c) c.GroupIndex = -1 AndAlso c.Visible)
        End Function

    End Class
End Namespace