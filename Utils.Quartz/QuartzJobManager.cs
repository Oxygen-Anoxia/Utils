using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Quartz
{
    public class QuartzJobManager
    {
        public string Name { get; set; }

        public bool IsUsed { get; set; }

        public string Remark { get; set; }

        public string Description { get; set; }

        public IList<JobList> JobLists { get; set; }
    }


    public class JobList
    {
        public string JobName { get; set; }

        public string JobType { get; set; }

        public string JobClassName { get; set; }

        public string CronExpression { get; set; }

        public bool IsUsed { get; set; }

        public string Remark { get; set; }

        public string Description { get; set; }
    }
}
