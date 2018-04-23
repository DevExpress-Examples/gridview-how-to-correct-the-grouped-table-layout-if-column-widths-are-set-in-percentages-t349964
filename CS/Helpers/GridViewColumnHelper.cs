using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace T362981MVC.Helpers
{
    public class GridViewColumnHelper
    {
        public GridViewColumnHelper(ASPxGridView grid)
        {
            Grid = grid;
            ClientColumnsWidth = HttpContext.Current.Session[Grid.ID] as IDictionary<int, double>;
            if (ClientColumnsWidth == null)
            {
                HttpContext.Current.Session[Grid.ID] = ClientColumnsWidth = new Dictionary<int, double>();
            }
        }

        protected ASPxGridView Grid { get; private set; }

        protected IDictionary<int, double> ClientColumnsWidth { get; private set; }

        public void RestoreColumnWidth()
        {
            foreach (var keyPairValue in ClientColumnsWidth)
            {
                Grid.Columns[keyPairValue.Key].Width = Unit.Percentage(keyPairValue.Value);
            }
        }
        public GridViewDataColumn GetColumnToResetWidth()
        {
            if (GetTotalColumnPercentWidth() >= 100)
                return null;
            GridViewDataColumn widestDataColumn = FindWidestDataColumn();;
            ClientColumnsWidth[widestDataColumn.Index] = widestDataColumn.Width.Value;
            return widestDataColumn;
        }
        double GetTotalColumnPercentWidth()
        {
            double totalPercentWidth = 0;
            foreach (var dataColumn in GetVisibleUnGroupedColumns())
            {
                if (dataColumn.Width.Type != UnitType.Percentage) continue;
                totalPercentWidth += dataColumn.Width.Value;
            }
            return totalPercentWidth;
        }
        GridViewDataColumn FindWidestDataColumn()
        {
            GridViewDataColumn widestColumn = null;
            foreach (var column in GetVisibleUnGroupedColumns())
            {
                if (column.Width.Type != UnitType.Percentage) continue;
                if (widestColumn == null || widestColumn.Width.Value < column.Width.Value)
                    widestColumn = column;
            }
            return widestColumn;
        }
        IEnumerable<GridViewDataColumn> GetVisibleUnGroupedColumns()
        {
            return Grid.DataColumns.Where(c => c.GroupIndex == -1 && c.Visible);
        }

    }
}