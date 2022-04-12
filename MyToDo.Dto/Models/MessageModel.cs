﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Shared.Models
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;
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
            return Message(true, msg, default);
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
                success = true,
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
            return Message(false, msg, default);
        }
        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="response">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Fail(string msg, T response)
        {
            return Message(false, msg, response);
        }
        /// <summary>
        /// 返回消息
        /// </summary>
        /// <param name="success">失败/成功</param>
        /// <param name="msg">消息</param>
        /// <param name="response">数据</param>
        /// <returns></returns>
        public static MessageModel<T> Message(bool success, string msg, T response)
        {
            return new MessageModel<T>() { msg = msg, response = response, success = success };
        }
    }




    public class MessageModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public object response { get; set; }


        public static MessageModel Success(string msg = "成功", int status = 200)
        {
            return Message(true, msg, default, status);
        }


        public static MessageModel Success(object response, string msg = "成功", int status = 200)
        {
            return Message(true, msg, response, status);
        }


        public static MessageModel Fail(string msg = "失败", int status = 201)
        {
            return Message(false, msg, default, status);
        }


        public static MessageModel Message(bool success, string msg, object response, int status)
        {
            return new MessageModel() { msg = msg, response = response, success = success, status = status };
        }
    }
}
