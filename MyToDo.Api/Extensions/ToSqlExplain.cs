using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Extensions
{
    /// <summary>
    /// SQL拼接后输出
    /// </summary>
    public class ToSqlExplain
    {
        public static string GetSql(KeyValuePair<string, SugarParameter[]> queryString)
        {
            var sql = queryString.Key;//sql语句
            var par = queryString.Value;//参数

            //字符串替换MethodConst1x会替换掉MethodConst1所有要从后往前替换,不能用foreach,后续可以优化
            for (int i = par.Length - 1; i >= 0; i--)
            {
                if (par[i].ParameterName.StartsWith("@") && par[i].ParameterName.Contains("UnionAll"))
                {
                    sql = sql.Replace(par[i].ParameterName, par[i].Value.ToString());
                }
            }

            for (int i = par.Length - 1; i >= 0; i--)
            {
                if (par[i].ParameterName.StartsWith("@Method"))
                {
                    sql = sql.Replace(par[i].ParameterName, par[i].Value.ToString());
                }
            }
            for (int i = par.Length - 1; i >= 0; i--)
            {
                if (par[i].ParameterName.StartsWith("@Const"))
                {
                    sql = sql.Replace(par[i].ParameterName, par[i].Value.ToString());
                }
            }
            for (int i = par.Length - 1; i >= 0; i--)
            {
                if (par[i].ParameterName.StartsWith("@"))
                {
                    //值拼接单引号 拿出来的sql不会报错
                    sql = sql.Replace(par[i].ParameterName, "'" + Convert.ToString(par[i].Value) + "'");
                }
            }
            return sql;
        }
    }
}
