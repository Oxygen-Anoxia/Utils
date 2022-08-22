using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Quartz
{
    public static class QuartzCronExpression
    {
        public static bool IsValidExpression(string cronExpressionString)
        {
            string[] cronExpressionArray = cronExpressionString.Split(new char[1] { ' ' });
            if (cronExpressionArray.Length == 6 || cronExpressionArray.Length == 7)
            {
                try
                {
                    if (cronExpressionArray.Length == 7)
                    {
                        int.Parse(cronExpressionArray[6]);
                    }
                    bool isValid = IsValidExpression(cronExpressionString);
                    if (isValid)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
