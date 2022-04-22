using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Shared.Models
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public ResultStatus status { get; set; } = ResultStatus.Success;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public object response { get; set; }


        public static MessageModel Success(string msg = "成功")
        {
            return Message(msg, default, ResultStatus.Success);
        }


        public static MessageModel Success(object response, string msg = "成功")
        {
            return Message(msg, response, ResultStatus.Success);
        }


        public static MessageModel Fail(string msg = "失败")
        {
            return Message(msg, default, ResultStatus.Fail);
        }

        public static MessageModel Fail(object response, string msg = "失败")
        {
            return Message(msg, response, ResultStatus.Fail);
        }

        public static MessageModel Error(string msg = "异常")
        {
            return Message(msg, default, ResultStatus.Error);
        }

        public static MessageModel Error(object response, string msg = "异常")
        {
            return Message(msg, response, ResultStatus.Error);
        }


        public static MessageModel Message(string msg, object response, ResultStatus status)
        {
            return new MessageModel() { msg = msg, response = response, status = status };
        }
    }


    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public ResultStatus status { get; set; } = ResultStatus.Success;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }


        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static MessageModel<T> Success(string msg = "成功")
        {
            return Message(msg, default, ResultStatus.Success);
        }
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="response">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Success(T response, string msg = "成功")
        {
            return new MessageModel<T>()
            {
                msg = msg,
                response = response,
            };
        }
        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static MessageModel<T> Fail(string msg = "失败")
        {
            return Message(msg, default, ResultStatus.Fail);
        }
        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="response">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Fail(string msg, T response)
        {
            return Message(msg, response, ResultStatus.Fail);
        }
        /// <summary>
        /// 返回异常
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static MessageModel<T> Error(string msg = "异常")
        {
            return Message(msg, default, ResultStatus.Error);
        }
        /// <summary>
        /// 返回异常
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="response">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Error(string msg, T response)
        {
            return Message(msg, response, ResultStatus.Error);
        }
        /// <summary>
        /// 返回消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="response">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Message(string msg, T response, ResultStatus status)
        {
            return new MessageModel<T>() { msg = msg, response = response };
        }
    }


    public enum ResultStatus
    {
        [Description("请求失败")]
        Fail = 0,
        [Description("请求成功")]
        Success = 1,
        [Description("请求异常")]
        Error = -1
    }
}
