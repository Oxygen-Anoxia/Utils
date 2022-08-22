using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.SPEI
{

    public class clsSPEIModel
    {

        /// <summary>
        /// 基地代码
        /// </summary>
        public string baseCode { get; set; }

        //[JsonProperty("SFKZZ(K)S")]
        [JsonIgnore]
        public int yaers { get; set; }

        public int months { get; set; }

        public decimal SPEI_1 { get; set; }
        public decimal SPEI_3 { get; set; }
        public decimal SPEI_6 { get; set; }
        public decimal SPEI_12 { get; set; }
        public decimal SPEI_24 { get; set; }
        public string Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreatorId { get; set; }
        //public int Deleted { get; set; }
    }


    public class clsPrintResult
    {
        /// <summary>
        /// 基地代码
        /// </summary>
        public string baseCode { get; set; }

        /// <summary>
        /// 年份
        /// </summary>
        public int years { get; set; }

        public List<clsSPEI> spei { get; set; }

        public clsPrintResult()
        {
            spei = new List<clsSPEI>();
        }

    }
    /// <summary>
    /// SPEI
    /// </summary>
    public class clsSPEI
    {

        public string SPEI { get; set; }
        /// <summary>
        /// 干旱历时
        /// </summary>
        public int droughtLasted { get; set; }
        /// <summary>
        /// 干旱月份
        /// </summary>
        public string droughtMonths { get; set; }

        /// <summary>
        /// 干旱过程（次）
        /// </summary>
        public int times { get; set; }

        /// <summary>
        /// 干旱烈度
        /// </summary>
        public string droughtIntensity { get; set; }

        public clsSPEI()
        {
            SPEI = "";
            droughtLasted = 0;
            droughtMonths = "";
            times = 0;
            droughtIntensity = "";
        }
    }

}
