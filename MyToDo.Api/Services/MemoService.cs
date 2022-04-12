using MyToDo.Api.Models;
using MyToDo.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MyToDo.Api.Services.IServices;
using MyToDo.Shared.Dtos;
using SqlSugar;
using MyToDo.Shared.Models;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Services
{
    public class MemoService : BaseServices<Memo, MemoDto>, IMemoService
    {
        private readonly IMapper mapper;
        private readonly ISqlSugarClient db;

        public MemoService(IMapper _mapper, ISqlSugarClient _sqlSugarClient) : base(_mapper, _sqlSugarClient)
        {
            this.mapper = _mapper;
            db = _sqlSugarClient;
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<MessageModel<PageModel<MemoDto>>> QueryPage(QueryParameter query)
        {
            //至关重要的参数：数据总数
            RefAsync<int> dataCount = 0;

            //Expression<Func<Modules, bool>> whereExpression = a => a.IsDeleted != true && (a.Name != null && a.Name.Contains(key));
            //var list = await db.Queryable<Memo>().OrderByIF(!string.IsNullOrEmpty(orderByFields), orderByFields)
            //   .WhereIF(whereExpression != null, whereExpression).ToPageListAsync(pageIndex, pageSize, dataCount);

            var list = await db.Queryable<Memo>().WhereIF(!string.IsNullOrEmpty(query.Search), a => a.Title.Contains(query.Search))
                .ToPageListAsync(query.PageIndex, query.PageSize, dataCount);

            List<MemoDto> listDto = mapper.Map<List<MemoDto>>(list);
            var pageModelList = new PageModel<MemoDto>(query.PageIndex, dataCount, query.PageSize, listDto);
            return MessageModel<PageModel<MemoDto>>.Success(pageModelList, "获取成功");
        }
    }
}
