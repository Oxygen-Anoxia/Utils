using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ApiMessage<T> : ApiMessage
    {
        public new ApiMessageData<T> data { get; set; }        // {}
    }
    public class ApiMessage
    {
        public string apiVersion { get; set; }
        public string sendtime { get; set; }
        public string backtime { get; set; }
        public int status { get; set; }
        public string url { get; set; }
        public string debuginfo { get; set; }
        public ApiMessageError error { get; set; }
        public ApiMessageData data { get; set; }
        public int isUseCache { get; set; }

        private const string Format_DateTime_All = "yyyy-MM-dd HH:mm:ss fff";

        public bool IsError()
        {
            return status == 0;
        }
        public ApiMessage()
        {
            apiVersion = "";
            sendtime = DateTime.Now.ToString(Format_DateTime_All);
            backtime = DateTime.Now.ToString(Format_DateTime_All);
            status = 1;
            url = "";
            debuginfo = "";
            error = new ApiMessageError();
            data = new ApiMessageData
            {
                message = "操作成功。"
            };
            isUseCache = 0;
            data.setItems();
        }

        public void setError(ApiMessageError amerr)
        {
            error = amerr;
            if (amerr != null)
            {
                if (amerr.code != 0)
                {
                    status = 0;
                    data.message = "";
                }
            }
            backtime = DateTime.Now.ToString(Format_DateTime_All);
        }

        public ApiMessage Error(int errcode, String errmsg)
        {
            error.code = errcode;
            error.message = errmsg;
            if (errcode != 0)
            {
                status = 0;
                data.message = "";
            }
            backtime = DateTime.Now.ToString(Format_DateTime_All);
            return this;
        }

        public void setError(int errcode, String errmsg)
        {
            error.code = errcode;
            error.message = errmsg;
            if (errcode != 0)
            {
                status = 0;
                data.message = "";
            }
            backtime = DateTime.Now.ToString(Format_DateTime_All);
        }

        public void setItems(Object[] amditem)
        {
            data.setItems(amditem);
            backtime = DateTime.Now.ToString(Format_DateTime_All);
        }
        public void setItems(IEnumerable<object> amditem)
        {
            data.setItems(amditem.ToArray());
            backtime = DateTime.Now.ToString(Format_DateTime_All);
        }

        public void setItems(Object amditem)
        {
            data.setItems(amditem);
            backtime = DateTime.Now.ToString(Format_DateTime_All);
        }
        public void setItems()
        {
            data.setItems();
            backtime = DateTime.Now.ToString(Format_DateTime_All);
        }
        public void SetSessonMiss()
        {
            status = -1;
            error = new ApiMessageError(-1, "登录信息已过期，请重新登录");
        }

        public bool IsSuccess
        {
            get
            {
                return status == 1;
            }
        }

        public enum ErrorMessage
        {
            参数对象不能是null,
            必传参数不能为空,
            Json无法解析
        }
    }
}
