using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerApiDemo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TempDataController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetList(DateTime? StartTime = null, DateTime? EndTime = null)
        {
            List<TempClass> list = new List<TempClass>() {
                new TempClass(){Id=1,Name="1",Date=DateTime.Now.Date},
                new TempClass(){Id=2,Name="2",Date=DateTime.Now.AddMonths(-1).Date},
                new TempClass(){Id=3,Name="3",Date=DateTime.Now.AddMonths(-2).Date},
                new TempClass(){Id=4,Name="4",Date=DateTime.Now.AddMonths(-3).Date},
                new TempClass(){Id=5,Name="5",Date=DateTime.Now.AddMonths(-4).Date},
                new TempClass(){Id=6,Name="6",Date=DateTime.Now.AddMonths(-5).Date},
                new TempClass(){Id=7,Name="7",Date=DateTime.Now.AddMonths(-6).Date},
                new TempClass(){Id=8,Name="8",Date=DateTime.Now.AddMonths(-7).Date},
                new TempClass(){Id=9,Name="9",Date=DateTime.Now.AddMonths(-8).Date},
                new TempClass(){Id=10,Name="10",Date=DateTime.Now.AddMonths(-9).Date},
                new TempClass(){Id=11,Name="11",Date=DateTime.Now.AddMonths(-10).Date},
                new TempClass(){Id=12,Name="11",Date=DateTime.Now.AddMonths(-10).Date},
                new TempClass(){Id=13,Name="12",Date=DateTime.Now.AddMonths(-11).Date},
                new TempClass(){Id=14,Name="12",Date=DateTime.Now.AddMonths(-11).Date},
            };

            DateTime dtCreateTime = DateTime.Now;
            DateTime dtEndTime = DateTime.Now;

            if (StartTime == null && EndTime == null)
            {
                dtCreateTime = DateTime.Now.Date;
                dtEndTime = DateTime.Now.Date.AddMonths(-6);
            }

            //按照日期 年月日 分组排序
            //如果按照年月，则自己调整GroupBy中的x.date
            var q = list.Where(m => m.Date >= dtEndTime && m.Date < dtCreateTime)
                .GroupBy(x => x.Date).Select(x => new
                {
                    date = x.Key,
                    count = x.Count()
                }).ToList();

            Dictionary<string, string> dic = new Dictionary<string, string>();

            //打印输出
            foreach (var item in q)
            {
                dic.Add("date:" + item.date, "count:" + item.count);
            }

            return MyJson.ObjectToJson(dic);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetDataTable()
        {
            DataTable tblDatas = new DataTable("Datas");
            //数据列
            tblDatas.Columns.Add("姓名", Type.GetType("System.String"));
            tblDatas.Columns.Add("科目", Type.GetType("System.String"));
            tblDatas.Columns.Add("分数", Type.GetType("System.Int32"));
            tblDatas.Rows.Add(new object[] { "张三", "语文", 89 });
            tblDatas.Rows.Add(new object[] { "张三", "数学", 90 });
            tblDatas.Rows.Add(new object[] { "张三", "英语", 79 });
            tblDatas.Rows.Add(new object[] { "张三", "地理", 70 });
            tblDatas.Rows.Add(new object[] { "张三", "生物", 95 });
            tblDatas.Rows.Add(new object[] { "李四", "语文", 87 });
            tblDatas.Rows.Add(new object[] { "李四", "英语", 86 });
            tblDatas.Rows.Add(new object[] { "李四", "地理", 82 });
            tblDatas.Rows.Add(new object[] { "王五", "语文", 81 });
            tblDatas.Rows.Add(new object[] { "王五", "数学", 70 });
            tblDatas.Rows.Add(new object[] { "王五", "英语", 88 });
            tblDatas.Rows.Add(new object[] { "王五", "生物", 96 });

            DataTable tt = GetCrossTable(tblDatas);

            return MyJson.ObjectToJson(tt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable GetCrossTable(DataTable dt)
        {
            if (dt == null || dt.Columns.Count != 3 || dt.Rows.Count == 0)
            {
                return dt;
            }
            else
            {
                DataTable result = new DataTable();
                result.Columns.Add(dt.Columns[0].ColumnName);
                DataTable dtColumns = dt.DefaultView.ToTable("dtColumns", true, dt.Columns[1].ColumnName);
                for (int i = 0; i < dtColumns.Rows.Count; i++)
                {
                    string colName;
                    if (dtColumns.Rows[1][0] is DateTime)
                    {
                        colName = Convert.ToDateTime(dtColumns.Rows[i][0]).ToString();
                    }
                    else
                    {
                        colName = dtColumns.Rows[i][0].ToString();
                    }
                    result.Columns.Add(colName);
                    result.Columns[i + 1].DefaultValue = "0";
                }
                DataRow drNew = result.NewRow();
                drNew[0] = dt.Rows[0][0];
                string rowName = drNew[0].ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    string colName = dr[1].ToString();
                    double dValue = Convert.ToDouble(dr[2]);
                    if (dr[0].ToString().Equals(rowName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        drNew[colName] = dValue.ToString();
                    }
                    else
                    {
                        result.Rows.Add(drNew);
                        drNew = result.NewRow();
                        drNew[0] = dr[0];
                        rowName = drNew[0].ToString();
                        drNew[colName] = dValue.ToString();
                    }
                }
                result.Rows.Add(drNew);
                return result;
            }
        }


        [HttpPut]
        public HttpResponseMessage GetData()
        {

        }
    }
}