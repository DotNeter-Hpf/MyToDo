using AutoMapper;
using MyToDo.Api.Extensions;
using MyToDo.Api.Services.IServices;
using MyToDo.Shared.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyToDo.Api.Services
{
    public class BaseServices<T, TDto> : IBaseService<T, TDto> where T : class, new()
    {
        public SimpleClient<T> SimpleClient => new(db);

        private readonly IMapper mapper;
        private readonly ISqlSugarClient db;

        public BaseServices(IMapper _mapper, ISqlSugarClient _sqlSugarClient)
        {
            mapper = _mapper;
            db = _sqlSugarClient;
        }


        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<MessageModel> GetAllAsync()
        {
            try
            {
                var list = await db.Queryable<T>().ToListAsync();
                return MessageModel.Success(list);
            }
            catch (Exception ex)
            {
                return MessageModel.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MessageModel> GetSingleAsync(int id)
        {
            try
            {
                var response = await SimpleClient.GetByIdAsync(id);
                return MessageModel.Success(response);
            }
            catch (Exception ex)
            {
                return MessageModel.Fail(ex.Message);
            }
        }


        //弃用 分页查询
        //public async Task<MessageModel<List<TDto>>> QueryPage(string where, int pageIndex, int pageSize, string orderByFields)
        //{
        //    var list = await db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(orderByFields), orderByFields)
        //        .WhereIF(!string.IsNullOrEmpty(where), where).ToPageListAsync(pageIndex, pageSize);

        //    List<TDto> listDto = mapper.Map<List<T>, List<TDto>>(list);

        //    return MessageModel<List<TDto>>.Success(listDto);
        //}





        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="tModel"></param>
        /// <returns></returns>
        public async Task<MessageModel<T>> AddAsync(TDto tModel)
        {
            //数据传输层和数据库实体层之间的一个映射转换
            var model = mapper.Map<T>(tModel);

            var t = await db.Insertable(model).ExecuteReturnEntityAsync();
            return t != null ? MessageModel<T>.Success(t) : MessageModel<T>.Fail();
        }


        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageModel> UpdateAsync(TDto model)
        {
            try
            {
                //数据传输层ToDoDto和数据库实体层之间的一个映射转换
                var tModel = mapper.Map<T>(model);
                int row = await db.Updateable(tModel).ExecuteCommandAsync();

                return row > 0 ? MessageModel.Success("修改成功") : MessageModel.Fail("修改失败");
            }
            catch (Exception ex)
            {
                return MessageModel.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据ID删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MessageModel> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) return MessageModel.Fail();
                bool isDelete = await SimpleClient.DeleteByIdAsync(id);
                return isDelete ? MessageModel.Success("删除成功") : MessageModel.Fail();
            }
            catch (Exception ex)
            {
                return MessageModel.Fail(ex.Message);
            }
        }






    }
}
