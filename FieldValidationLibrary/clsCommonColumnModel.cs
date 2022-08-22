using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldValidationLibrary
{
    public class clsCommonColumnModel
    {

        /// <summary>
        /// 唯一编码（32位uuid）
        /// 每张主表的主键
        /// </summary>
        [Required(ErrorMessage = " 安全风险空间分布图 is a required field.")]
        [Newtonsoft.Json.JsonIgnore]
        public Guid? c_id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 删除状态（未删除：0；已删除：1）（必填）
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string deleted { get; set; } = "0";
        /// <summary>
        /// （CREATE_DATE:日期时间）：创建时间（必填）（时间格式yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string createDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        /// <summary>
        /// （CREATE_BY:字符）：创建人（必填）
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string createBy { get; set; }
        /// <summary>
        ///（UPDATE_DATE:日期时间）：（必填）修改时间（时间格式yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string updateDate { get; set; }
        /// <summary>
        ///（UPDATE_BY:字符）： 修改人（必填）
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string updateBy { get; set; }


        public clsCommonCloumnRequiredResponse Validate()
        {
            var response = new clsCommonCloumnRequiredResponse() { flag = true, msg = "" };

            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }

                //throw new ValidationException(sbrErrors.ToString());

                response.flag = false;
                response.msg = sbrErrors.ToString();

            }

            return response;
        }
    }

    /// <summary>
    /// 字段验证失败返回实体类
    /// </summary>
    public class clsCommonCloumnRequiredResponse
    {
        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool flag { get; set; }
        /// <summary>
        /// 验证信息
        /// </summary>
        public string msg { get; set; }
    }
}
