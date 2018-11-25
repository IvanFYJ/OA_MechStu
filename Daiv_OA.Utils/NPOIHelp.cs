﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Daiv_OA.Utils
{

    /// <summary>
    /// 使用NOPI读取Excel数据
    /// </summary>
    /// <author>范永坚 2017-08-09</author>
    public class ImportExcel
    {
        private NPOI.SS.UserModel.IWorkbook _workbook;
        private string _filePath;

        public List<string> SheetNames { get; set; }

        public ImportExcel()
        {
            SheetNames = new List<string>();
            //LoadFile(_filePath);
        }

        #region Excel信息

        /// <summary>
        /// 获取Excel信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <author>范永坚 2017-08-09</author>
        public List<string> LoadFile(string filePath)
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            _filePath = filePath;
            SheetNames = new List<string>();
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                _workbook = NPOI.SS.UserModel.WorkbookFactory.Create(fs);
            }
            return GetSheetNames();
        }

        public List<string> LoadStream(Stream stream)
        {
            _workbook = NPOI.SS.UserModel.WorkbookFactory.Create(stream);
            return GetSheetNames();
        }

        /// <summary>
        /// 获取SHeet名称
        /// </summary>
        /// <returns></returns>
        /// <author>范永坚 2017-08-09</author>
        private List<string> GetSheetNames()
        {
            var count = _workbook.NumberOfSheets;
            for (int i = 0; i < count; i++)
            {
                SheetNames.Add(_workbook.GetSheetName(i));
            }
            return SheetNames;
        }

        #endregion


        #region 获取数据源

        /// <summary>
        /// 获取所有数据，所有sheet的数据转化为datatable。
        /// </summary>
        /// <param name="isFirstRowCoumn">是否将第一行作为列标题</param>
        /// <returns></returns>
        /// <author>范永坚 2017-08-09</author>
        public DataSet GetAllTables(bool isFirstRowCoumn)
        {

            var ds = new DataSet();

            foreach (var sheetName in SheetNames)
            {
                ds.Tables.Add(ExcelToDataTable(sheetName, isFirstRowCoumn));
            }
            return ds;
        }

        /// <summary>
        /// 获取第<paramref name="idx"/>的sheet的数据
        /// </summary>
        /// <param name="idx">Excel文件的第几个sheet表</param>
        /// <param name="isFirstRowCoumn">是否将第一行作为列标题</param>
        /// <returns></returns>
        /// <author>范永坚 2017-08-09</author>
        public DataTable GetTable(int idx, bool isFirstRowCoumn)
        {
            if (idx >= SheetNames.Count || idx < 0)
                throw new Exception("Do not Get This Sheet");
            return ExcelToDataTable(SheetNames[idx], isFirstRowCoumn);
        }

        /// <summary>
        /// 获取sheet名称为<paramref name="sheetName"/>的数据
        /// </summary>
        /// <param name="sheetName">Sheet名称</param>
        /// <param name="isFirstRowColumn">是否将第一行作为列标题</param>
        /// <returns></returns>
        /// <author>范永坚 2017-08-09</author>
        public DataTable GetTable(string sheetName, bool isFirstRowColumn)
        {
            return ExcelToDataTable(sheetName, isFirstRowColumn);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        /// <author>范永坚 2017-08-09</author>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            NPOI.SS.UserModel.ISheet sheet = null;
            var data = new DataTable();
            data.TableName = sheetName;
            int startRow = 0;
            try
            {
                sheet = sheetName != null ? _workbook.GetSheet(sheetName) : _workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    var firstRow = sheet.GetRow(0);
                    if (firstRow == null)
                        return data;
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    startRow = isFirstRowColumn ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;

                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        //.StringCellValue;
                        var column = new DataColumn(Convert.ToChar(((int)'A') + i).ToString());
                        if (isFirstRowColumn)
                        {
                            var columnName = firstRow.GetCell(i).StringCellValue;
                            column = new DataColumn(columnName);
                        }
                        data.Columns.Add(column);
                    }


                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        NPOI.SS.UserModel.IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j, NPOI.SS.UserModel.MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                else throw new Exception("Don not have This Sheet");

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        #endregion
    }
}
