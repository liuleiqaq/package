using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerApiDemo.Tools
{
    public class DataTablHelper
    {

        /// <summary>
        /// datatable 行转列
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public DataTable RowsToCol(DataTable DT)
        {
            DataTable result = new DataTable();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                result.Columns.Add(i.ToString());
            }
            result.Columns.Add(DT.Rows.Count.ToString());

            foreach (DataColumn col in DT.Columns)
            {
                object[] newRow = new object[DT.Rows.Count + 1];
                newRow[0] = col.ColumnName;
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    newRow[i + 1] = DT.Rows[i][col];
                }
                result.Rows.Add(newRow);
            }
            return result;

        }

    }
}
