namespace MyToDo.Api.Models
{
    /// <summary>
    /// 邮件属性实体类
    /// </summary>
    public class EmailOptions
    {
        public const string Email = "Email";
        /// <summary>
        /// 发件者邮箱
        /// </summary>
        public string FromAddress { get; set; }

        /// <summary>
        /// 接收人邮箱
        /// </summary>
        public string ToAddress { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 发件邮箱账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 发件邮箱密码
        /// </summary>
        public string Password { get; set; }
    }
}
