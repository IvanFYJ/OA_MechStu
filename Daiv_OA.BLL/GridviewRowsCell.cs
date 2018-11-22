using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
namespace Daiv_OA.BLL
{
 public static  class GridviewRowsCell
    {

           
            #region  合并某一行的所有列
            public static void GroupRow(GridView gridView)
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Text == previousRow.Cells[i].Text)
                        {
                            row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                                   previousRow.Cells[i].RowSpan + 1;
                            previousRow.Cells[i].Visible = false;
                        }
                    }
                }
            }
            ///　 <summary>　
            ///　合并GridView中某行相同信息的行（单元格）
            ///　 </summary>　
            ///　 <param　 name="GridView1">GridView对象</param>　
            ///　 <param　 name="cellNum">需要合并的行</param>
            public static void GroupRow(GridView gridView, int rows)
            {
                TableCell oldTc = gridView.Rows[rows].Cells[0];
                for (int i = 1; i < gridView.Rows[rows].Cells.Count; i++)
                {
                    TableCell tc = gridView.Rows[rows].Cells[i];　 //Cells[0]就是你要合并的列
                    if (oldTc.Text == tc.Text)
                    {
                        tc.Visible = false;
                        if (oldTc.ColumnSpan == 0)
                        {
                            oldTc.ColumnSpan = 1;
                        }
                        oldTc.ColumnSpan++;
                        oldTc.VerticalAlign = VerticalAlign.Middle;
                    }
                    else
                    {
                        oldTc = tc;
                    }
                }
            }
            #endregion
            #region  合并一行中的几列
            /// <summary>
            /// 合并单元格合并一行中的几列
            /// </summary>
            /// <param name="GridView1">GridView ID</param>
            /// <param name="rows">行</param>
            /// <param name="sCol">开始列</param>
            /// <param name="eCol">结束列</param>
            public static void GroupRow(GridView gridView, int rows, int sCol, int eCol)
            {
                TableCell oldTc = gridView.Rows[rows].Cells[sCol];
                for (int i = 1; i < eCol - sCol; i++)
                {
                    TableCell tc = gridView.Rows[rows].Cells[i + sCol];　 //Cells[0]就是你要合并的列
                    tc.Visible = false;
                    if (oldTc.ColumnSpan == 0)
                    {
                        oldTc.ColumnSpan = 1;
                    }
                    oldTc.ColumnSpan++;
                    oldTc.VerticalAlign = VerticalAlign.Middle;
                }
            }
            #endregion
            #region  合并某一列所有行
            /// <summary>
            /// 合并GridView中某列相同信息的行（单元格）
            /// </summary>
            /// <param name="GridView1"></param>
            /// <param name="cellNum"></param>
            public static void GroupCol(GridView gridView, int cols)
            {
                if (gridView.Rows.Count < 1 || cols > gridView.Rows[0].Cells.Count - 1)
                {
                    return;
                }
                TableCell oldTc = gridView.Rows[0].Cells[cols];
                for (int i = 1; i < gridView.Rows.Count; i++)
                {
                    TableCell tc = gridView.Rows[i].Cells[cols];
                    if (oldTc.Text == tc.Text)
                    {
                        tc.Visible = false;
                        if (oldTc.RowSpan == 0)
                        {
                            oldTc.RowSpan = 1;
                        }
                        oldTc.RowSpan++;
                        oldTc.VerticalAlign = VerticalAlign.Middle;
                    }
                    else
                    {
                        oldTc = tc;
                    }
                }
            }
            #endregion
            #region  合并某一列中的某些行
            /// <summary>
            /// 合并单元格合并某一列中的某些行
            /// </summary>
            /// <param name="GridView1">GridView ID</param>
            /// <param name="cellNum">列</param>
            /// <param name="sRow">开始行</param>
            /// <param name="eRow">结束列</param>
            public static void GroupCol(GridView gridView, int cols, int sRow, int eRow)
            {
                if (gridView.Rows.Count < 1 || cols > gridView.Columns.Count - 1)
                {
                    return;
                }
                TableCell oldTc = gridView.Rows[sRow].Cells[cols];
                for (int i = 1; i < eRow - sRow; i++)
                {
                    TableCell tc = gridView.Rows[sRow + i].Cells[cols];
                    tc.Visible = false;
                    if (oldTc.RowSpan == 0)
                    {
                        oldTc.RowSpan = 1;
                    }
                    oldTc.RowSpan++;
                    oldTc.VerticalAlign = VerticalAlign.Middle;
                }
            }
            #endregion
        }

}



