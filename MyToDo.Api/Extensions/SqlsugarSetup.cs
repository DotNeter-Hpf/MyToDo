using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyToDo.Api.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Extensions
{
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services, string dbName = "DefaultConnection")
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });

            //调试SQL事件，可以删掉
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                //Console.WriteLine(sql);//输出sql，查看执行sql
                //Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数

                var queryString = new KeyValuePair<string, SugarParameter[]>(sql, pars);
                Console.WriteLine(ToSqlExplain.GetSql(queryString));//输出sql
            };
            services.AddSingleton<ISqlSugarClient>(db);

            
            
            #region 初始化数据库
            ////如果不存在创建数据库
            //db.DbMaintenance.CreateDatabase();

            ////use db query
            //var dt = db.Ado.GetDataTable("select 1");

            ////通过类创建表
            //db.CodeFirst.InitTables(typeof(User), typeof(ToDo), typeof(Memo));

            ////插入数据
            ////返回插入行数
            //var row = db.Insertable(new Memo() { Title = "测试一", Content = "测试插入数据", CreateDate = db.GetDate(), UpdateDate = db.GetDate() }).ExecuteCommand();
            ////插入返回自增列
            //var id = db.Insertable(new Memo() { Title = "测试一", Content = "测试插入数据", CreateDate = db.GetDate(), UpdateDate = db.GetDate() }).ExecuteReturnIdentity();
            #endregion


        }
    }
}
