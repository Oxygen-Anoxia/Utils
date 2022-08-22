using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApiMessageError
    {
        public int code { get; set; } //": 404, //错误详细编号
        public String message { get; set; } //": "File Not Found" //错误信息
        public String showMessage { get; set; }
        public ApiMessageError()
        {
            code = 0;
            message = "";
            showMessage = "";
        }

        public ApiMessageError(int errcode, String errmsg)
        {
            code = errcode;
            message = errmsg;
        }

    }
}
