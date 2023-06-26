using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;

namespace Csindex.WebCrawlers.entity
{
    internal class IndicatorEntity
    {
        [ExcelColumnName("日期Date")]
        public String date { get; set; }

        [ExcelColumnName("指数代码Index Code")]
        public String indexCode { get; set; }

        [ExcelColumnName("指数中文全称Chinese Name(Full)")]
        public String chineseName { get; set; }

        [ExcelColumnName("指数中文简称Index Chinese Name")]
        public String indexChineseName { get; set; }

        [ExcelColumnName("指数英文全称English Name(Full)")]
        public String englishName { get; set; }

        [ExcelColumnName("指数英文简称Index English Name")]
        public String indexEnglishName { get; set; }

        [ExcelColumnName("市盈率1（总股本）P/E1")]
        public Double priceEarningRatioFirst { get; set; }

        [ExcelColumnName("市盈率2（计算用股本）P/E2")]
        public Double priceEarningRatioSecond { get; set; }

        [ExcelColumnName("股息率1（总股本）D/P1")]
        public Double dividendYieldFirst { get; set; }

        [ExcelColumnName("股息率2（计算用股本）D/P2")]
        public Double dividendYieldSecond { get; set; }

        public IndicatorEntity()
        {
        }

        public IndicatorEntity(String date, String indexCode, String chineseName, String indexChineseName, String englishName, String indexEnglishName, Double priceEarningRatioFirst, Double priceEarningRatioSecond, Double dividendYieldFirst, Double dividendYieldSecond)
        {
            this.date = date;
            this.indexCode = indexCode;
            this.chineseName = chineseName;
            this.indexChineseName = indexChineseName;
            this.englishName = englishName;
            this.indexEnglishName = indexEnglishName;
            this.priceEarningRatioFirst = priceEarningRatioFirst;
            this.priceEarningRatioSecond = priceEarningRatioSecond;
            this.dividendYieldFirst = dividendYieldFirst;
            this.dividendYieldSecond = dividendYieldSecond;
        }

        public static Dictionary<String, String> buildReadHeaderAlias()
        {
            Dictionary<String, String> headerAlias = new Dictionary<String,String>(10);
            headerAlias.Add("日期Date", "date");
            headerAlias.Add("指数代码Index Code", "indexCode");
            headerAlias.Add("指数中文全称Chinese Name(Full)", "chineseName");
            headerAlias.Add("指数中文简称Index Chinese Name", "indexChineseName");
            headerAlias.Add("指数英文全称English Name(Full)", "englishName");
            headerAlias.Add("指数英文简称Index English Name", "indexEnglishName");
            headerAlias.Add("市盈率1（总股本）P/E1", "priceEarningRatioFirst");
            headerAlias.Add("市盈率2（计算用股本）P/E2", "priceEarningRatioSecond");
            headerAlias.Add("股息率1（总股本）D/P1", "dividendYieldFirst");
            headerAlias.Add("股息率2（计算用股本）D/P2", "dividendYieldSecond");
            return headerAlias;
        }

        public static Dictionary<String, String> buildWriteHeaderAlias()
        {
            Dictionary<String, String> headerAlias = new Dictionary<String, String>(10);
            headerAlias.Add("date", "日期Date");
            headerAlias.Add("indexCode", "指数代码Index Code");
            headerAlias.Add("chineseName", "指数中文全称Chinese Name(Full)");
            headerAlias.Add("indexChineseName", "指数中文简称Index Chinese Name");
            headerAlias.Add("englishName", "指数英文全称English Name(Full)");
            headerAlias.Add("indexEnglishName", "指数英文简称Index English Name");
            headerAlias.Add("priceEarningRatioFirst", "市盈率1（总股本）P/E1");
            headerAlias.Add("priceEarningRatioSecond", "市盈率2（计算用股本）P/E2");
            headerAlias.Add("dividendYieldFirst", "股息率1（总股本）D/P1");
            headerAlias.Add("dividendYieldSecond", "股息率2（计算用股本）D/P2");
            return headerAlias;
        }
    }
}
