using MyToDo.Api.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Extensions
{
    public class DbContext
    {
        protected static SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig()
        {
            DbType = DbType.MySql,
            ConnectionString = Config.ConnectionString,
            IsAutoCloseConnection = true
        },
        db =>
        {
            //单例参数配置，所有上下文生效
            db.Aop.OnLogExecuting = (sql, pars) =>
           {
               //Console.WriteLine(sql);//输出sql，查看执行sql
               //Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数

               var queryString = new KeyValuePair<string, SugarParameter[]>(sql, pars);
               Console.WriteLine(ToSqlExplain.GetSql(queryString));//输出sql
           };
        });



        
        
    }
}
