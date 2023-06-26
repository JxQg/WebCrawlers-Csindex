using Csindex.WebCrawlers.entity;
using MiniExcelLibs;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Csindex.WebCrawlers
{
    internal class ExcelService
    {
        public ExcelService() { }
        public void MergeExcelData(String sourseFileName, String destFileName)
        {
            if (!File.Exists(destFileName))
            {
                File.Move(sourseFileName, destFileName);
                return;
            }
            Console.WriteLine("读取下载文件");
            List<IndicatorEntity> sourceIndicatorList = this.getEntityByFileName(sourseFileName);
            Console.WriteLine("读取源文件");
            List<IndicatorEntity> destIndicatorList = this.getEntityByFileName(destFileName);
            List<IndicatorEntity> mergeDataList = new List<IndicatorEntity>(sourceIndicatorList.Count);
            sourceIndicatorList.ForEach(indicator =>
            {
                if (indicator.date.CompareTo(destIndicatorList[0].date) > 0)
                {
                    mergeDataList.Add(indicator);
                }
            });
            Console.WriteLine("开始合并");
            this.mergeDataThenSaveToDir(destFileName, mergeDataList);
        }

        private List<IndicatorEntity> getEntityByFileName(String fileName)
        {
            using (var sourceStream = File.OpenRead(fileName))
            {
                Workbook book = new Workbook();
                book.LoadFromStream(sourceStream);
                var sourceStreamXlsx = new MemoryStream();
                book.SaveToStream(sourceStreamXlsx, FileFormat.Version2016);
                return sourceStreamXlsx.Query<IndicatorEntity>().ToList();
            }
        }

        private void mergeDataThenSaveToDir(String destFileName, List<IndicatorEntity> mergeDataList)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(destFileName);
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.InsertRow(2, mergeDataList.Count);
            for (int i = 0; i < mergeDataList.Count; i++)
            {
                IndicatorEntity mergeData = mergeDataList[i];
                PropertyInfo[] propertyList = mergeData.GetType().GetProperties();
                for (int j = 0; j < propertyList.Length; j++)
                {
                    PropertyInfo property = propertyList[j];
                    Object value = property.GetValue(mergeData);
                    if (value.GetType() == typeof(String))
                    {
                        worksheet.Range[i + 2, j + 1].Text = value.ToString();
                    }
                    if (value.GetType() == typeof(Double))
                    {
                        worksheet.Range[i + 2, j + 1].NumberValue = (double)value;
                    }
                    // 设置格式刷
                    worksheet.Range[i + 2, j + 1].Style = worksheet.Range[i + 2 + mergeDataList.Count, j + 1].Style;
                }
            }
            worksheet.AllocatedRange.AutoFitColumns();//列宽自适应
            workbook.Save();
            Console.WriteLine("合并成功！位置：" + destFileName);
        }
    }
}
