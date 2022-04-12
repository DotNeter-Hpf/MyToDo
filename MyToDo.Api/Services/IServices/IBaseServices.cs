using MyToDo.Api.Extensions;
using MyToDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyToDo.Api.Services.IServices
{
    public interface IBaseService<T, TDto> where T : class, new()
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<MessageModel> GetAllAsync();


        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MessageModel> GetSingleAsync(int id);


        //弃用 分页查询
        //Task<MessageModel<List<TDto>>>QueryPage(string where, int pageIndex, int pageSize, string orderByFields);




        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MessageModel<T>> AddAsync(TDto model);


        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MessageModel> UpdateAsync(TDto model);


        /// <summary>
        /// 根据ID删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MessageModel> DeleteAsync(int id);
    }
}
