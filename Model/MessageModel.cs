using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 通用返回信息类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }


        public void SetError(int statusCode, string errorMsg)
        {
            if (statusCode != 200)
            {
                success = false;
                status = statusCode;
                msg = errorMsg;
            }
        }

        public MessageModel()
        {
            success = true;
            msg = "操作成功";
            status = 200;
        }
    }
}
