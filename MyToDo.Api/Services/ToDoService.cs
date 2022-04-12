using System;
using System.Threading.Tasks;
using MyToDo.Api.Models;
using AutoMapper;
using MyToDo.Api.Services.IServices;
using System.Collections.Generic;
using MyToDo.Shared.Dtos;
using SqlSugar;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyToDo.Api.Services
{
    /// <summary>
    /// 待办事项的实现类
    /// </summary>
    public class ToDoService : BaseServices<ToDo, ToDoDto>, IToDoService
    {
        private readonly IMapper mapper;
        private readonly ISqlSugarClient db;

        /// <summary>
        /// 待办事项构造函数
        /// </summary>
        /// <param name="_mapper">AutoMapper 对象映射</param>
        /// <param name="_sqlSugarClient">ORM框架创建的对象</param>
        public ToDoService(IMapper _mapper, ISqlSugarClient _sqlSugarClient) : base(_mapper, _sqlSugarClient)
        {
            this.mapper = _mapper;
            db = _sqlSugarClient;
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<MessageModel<PageModel<ToDoDto>>> QueryPageAsync(ToDoParameter query)
        {
            //至关重要的参数：数据总数
            RefAsync<int> dataCount = 0;

            //Expression<Func<Modules, bool>> whereExpression = a => a.IsDeleted != true && (a.Name != null && a.Name.Contains(key));
            //var list = await db.Queryable<ToDo>().OrderByIF(!string.IsNullOrEmpty(orderByFields), orderByFields)
            //   .WhereIF(whereExpression != null, whereExpression).ToPageListAsync(pageIndex, pageSize, dataCount);

            var list = await db.Queryable<ToDo>()
                .WhereIF(!string.IsNullOrEmpty(query.Search), a => a.Title.Contains(query.Search))
                .WhereIF(query.Status != null, a => a.Status.Equals(query.Status))
                .ToPageListAsync(query.PageIndex, query.PageSize, dataCount);

            List<ToDoDto> listDto = mapper.Map<List<ToDoDto>>(list);
            var pageModelList = new PageModel<ToDoDto>(query.PageIndex, dataCount, query.PageSize, listDto);
            return MessageModel<PageModel<ToDoDto>>.Success(pageModelList, "获取成功");
        }


        /// <summary>
        /// 首页数据的获取
        /// </summary>
        /// <returns></returns>
        public async Task<MessageModel> SummaryAsync()
        {
            try
            {
                //待办事项结果
                var todos = await db.Queryable<ToDo>()
                    .OrderBy(t => t.CreateDate, OrderByType.Desc)
                    .ToListAsync();

                //备忘录结果
                var memos = await db.Queryable<Memo>()
                    .OrderBy(t => t.CreateDate, OrderByType.Desc)
                    .ToListAsync();

                SummaryDto summary = new();
                summary.Sum = todos.Count;
                summary.CompletedCount = todos.Where(it => it.Status == 1).Count();
                summary.CompletedRadio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
                summary.MemoCount= memos.Count;
                summary.TodoList = new ObservableCollection<ToDoDto>(mapper.Map<List<ToDoDto>>(todos.Where(it => it.Status == 0)));
                summary.MemoList = new ObservableCollection<MemoDto>(mapper.Map<List<MemoDto>>(memos));

                return MessageModel.Success(summary);
            }
            catch (Exception)
            {
                return MessageModel.Fail();
            }
        }
    }
}
