using SqlSugar;
using System;

namespace Model.Models
{
    public class RootEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }


        public RootEntity()
        {
            CreateTime = DateTime.Now;
        }
    }
}
