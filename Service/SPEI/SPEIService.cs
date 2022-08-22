using Common.Helper;
using IService.SPEI;
using Model.SPEI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.SPEI
{
    public class SPEIService : ISPEIService
    {

        /// <summary>
        /// 根据年份获取干旱烈度
        /// </summary>
        /// <param name="baseCode">基地代码</param>
        /// <param name="years">年份</param>
        /// <returns></returns>
        public async Task<clsPrintResult> GetdroughtIntensity(string baseCode = "51711", int years = 1957)
        {

            var lstPrintResult = new clsPrintResult() { baseCode = baseCode, years = years };
            clsSPEI _clsSPEI_1 = new clsSPEI();
            clsSPEI _clsSPEI_3 = new clsSPEI();
            clsSPEI _clsSPEI_6 = new clsSPEI();
            clsSPEI _clsSPEI_12 = new clsSPEI();
            clsSPEI _clsSPEI_24 = new clsSPEI();

            string sql = string.Empty;
            var linkOrm = new DapperHelper();
            sql = @$"  select * from Base_SPEI  where baseCode={SafeStringSqlDBNull(baseCode)} and  years={years} order by years ,months ";
            var lstData = linkOrm.Query<clsSPEIModel>(sql);
            List<List<clsSPEIModel>> lstOut = new List<List<clsSPEIModel>>();

            if (lstData.Count > 0)
            {
                //干旱月份、     干旱次数、干旱烈度
                //3、8、9、10    2                  0.716、3.228

                decimal dnum = (decimal)-0.5;
                //List<clsSPEIModel> lstSpei_1 = lstData.Where(p => p.SPEI_1 < -0.5).ToList();
                List<clsSPEIModel> lstSpei_1 = lstData.Where(p => p.SPEI_1 < dnum).ToList();
                List<clsSPEIModel> lstSpei_3 = lstData.Where(p => p.SPEI_3 < dnum).ToList();
                List<clsSPEIModel> lstSpei_6 = lstData.Where(p => p.SPEI_6 < dnum).ToList();
                List<clsSPEIModel> lstSpei_12 = lstData.Where(p => p.SPEI_12 < dnum).ToList();
                List<clsSPEIModel> lstSpei_24 = lstData.Where(p => p.SPEI_24 < dnum).ToList();


                #region 
                //string months = "";
                //int times = 0;
                //string level = "";
                //lstSpei_1.ForEach(p => { months += p.months + "、"; });
                //months = months.TrimEnd('、');

                //if (lstSpei_1.Count == 0)//没有干旱
                //{
                //    times = 0;
                //    level = "";
                //}
                //else if (lstSpei_1.Count == 1)//只有一个月有干旱
                //{
                //    times = 1;
                //    level = (lstSpei_1.FirstOrDefault().SPEI_1 * -1).ToString();
                //}
                //else //存在多月干旱
                //{

                //    var lstTemp = lstSpei_1;
                //    var lstNewData = new List<clsSPEIModel>();
                //    lstNewData.Add(lstSpei_1[0]);
                //    lstOut.Add(lstNewData);
                //    int index = 0;

                //    for (int i = 0; i < lstSpei_1.Count - 1; i++)
                //    {
                //        var entity = lstSpei_1[i];
                //        var entitynext = lstSpei_1[i + 1];
                //        if (entitynext.months - entity.months == 1)//说明这个是一个连续的
                //        {
                //            //lstNewData.Add(lstSpei_1[i + 1]);
                //            lstOut[index].Add(lstSpei_1[i + 1]);
                //        }
                //        else
                //        {
                //            index++;
                //            var a = new List<clsSPEIModel>();
                //            a.Add(lstSpei_1[i + 1]);
                //            lstOut.Add(a);
                //        }
                //    }
                //}
                #endregion

                _clsSPEI_1 = await gets(lstSpei_1, "SPEI-1");
                _clsSPEI_3 = await gets(lstSpei_3, "SPEI-3");
                _clsSPEI_6 = await gets(lstSpei_6, "SPEI-6");
                _clsSPEI_12 = await gets(lstSpei_12, "SPEI-12");
                _clsSPEI_24 = await gets(lstSpei_24, "SPEI-24");

            }
            lstPrintResult.spei.Add(_clsSPEI_1);
            lstPrintResult.spei.Add(_clsSPEI_3);
            lstPrintResult.spei.Add(_clsSPEI_6);
            lstPrintResult.spei.Add(_clsSPEI_12);
            lstPrintResult.spei.Add(_clsSPEI_24);

            sql = @$" delete from Base_SPEI_View where baseCode={SafeStringSqlDBNull(baseCode)} and  years={lstPrintResult.years}";
            linkOrm.Exec(sql);


            foreach (var item in lstPrintResult.spei)
            {

                var index = item.SPEI.LastIndexOf('-');

                int iSPEI = int.Parse(item.SPEI.Substring(index + 1));

                sql = @$" insert into Base_SPEI_VIEW (baseCode,years,iSPEI,SPEI,droughtLasted,droughtMonths,times,droughtIntensity) 
                                select {SafeStringSqlDBNull(baseCode)}, {lstPrintResult.years},{iSPEI},{SafeStringSqlDBNull(item.SPEI)},
                                    {item.droughtLasted},isnull({SafeStringSqlDBNull(item.droughtMonths)},''),
                                    {item.times},isnull({SafeStringSqlDBNull(item.droughtIntensity)},'')  ";
                linkOrm.Exec(sql);
                //Thread.Sleep(500);//延时三秒
            }

            return lstPrintResult;
            //return JsonConvert.SerializeObject(lstPrintResult);
            //return JsonConvert.SerializeObject(lstOut);
        }


        string SafeStringSqlDBNull(string oldValue)
        {
            if (string.IsNullOrEmpty(oldValue))
                return "NULL";
            return "'" + oldValue + "'";
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<clsPrintResult>> GetAllData()
        {
            var resLst = new List<clsPrintResult>();
            var linkOrm = new DapperHelper();

            string sql = @$" select a.baseCode,a.years
                                        from Base_SPEI a
                                        group by a.baseCode,a.years ";

            var lstData = linkOrm.Query<clsPrintResult>(sql);

            foreach (var item in lstData)
            {
                var entity = await GetdroughtIntensity(baseCode: item.baseCode, years: item.years);
                resLst.Add(entity);
            }

            //for (int i = 1957; i <= 2016; i++)
            //{
            //    var entity = await GetdroughtIntensity(baseCode: "", years: i);
            //    resLst.Add(entity);
            //}

            return resLst;
        }


        private async Task<clsSPEI> gets2(List<clsSPEIModel> clsSPEIs, string speiType)
        {
            var resEntity = new clsSPEI();
            resEntity.SPEI = speiType;
            resEntity.droughtLasted = clsSPEIs.Count();


            if (clsSPEIs.Count > 0)
            {
                clsSPEIs.ForEach(p => { resEntity.droughtMonths += p.months + "、"; });
                resEntity.droughtMonths = resEntity.droughtMonths.TrimEnd('、');

                if (clsSPEIs.Count == 0)//没有干旱
                {
                    resEntity.times = 0;
                    resEntity.droughtIntensity = "";
                }
                else if (clsSPEIs.Count == 1)//只有一个月有干旱
                {
                    resEntity.times = 1;
                    switch (speiType)
                    {
                        case "SPEI-1":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_1 * -1).ToString();
                            //  Console.WriteLine("SPEI_1: " + clsSPEIs.FirstOrDefault().SPEI_1);
                            break;
                        case "SPEI-3":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_3 * -1).ToString();
                            //  Console.WriteLine("SPEI_3: " + clsSPEIs.FirstOrDefault().SPEI_3);
                            break;
                        case "SPEI-6":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_6 * -1).ToString();
                            //  Console.WriteLine("SPEI_6: " + clsSPEIs.FirstOrDefault().SPEI_6);
                            break;
                        case "SPEI-12":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_12 * -1).ToString();
                            //  Console.WriteLine("SPEI_12: " + clsSPEIs.FirstOrDefault().SPEI_12);
                            break;
                        case "SPEI-24":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_24 * -1).ToString();
                            //  Console.WriteLine("SPEI_24: " + clsSPEIs.FirstOrDefault().SPEI_24);
                            break;
                    }
                }
                else
                {
                    List<List<clsSPEIModel>> lstOut = new List<List<clsSPEIModel>>();

                    var lstTemp = clsSPEIs;
                    var lstNewData = new List<clsSPEIModel>();
                    lstNewData.Add(clsSPEIs[0]);
                    lstOut.Add(lstNewData);
                    int index = 0;

                    for (int i = 0; i < clsSPEIs.Count - 1; i++)
                    {
                        var entity = clsSPEIs[i];
                        var entitynext = clsSPEIs[i + 1];
                        if (entitynext.months - entity.months == 1)//说明这个是一个连续的
                        {

                            lstOut[index].Add(clsSPEIs[i + 1]);
                        }
                        else
                        {
                            index++;
                            var a = new List<clsSPEIModel>();
                            a.Add(clsSPEIs[i + 1]);
                            lstOut.Add(a);
                        }
                    }

                    resEntity.times = lstOut.Count();

                    lstOut.ForEach(p =>
                    {
                        decimal num = 0;
                        p.ForEach(i =>
                        {

                            switch (speiType)
                            {
                                case "SPEI-1":
                                    num += i.SPEI_1;
                                    //  Console.WriteLine("SPEI_1: " + i.SPEI_1);
                                    break;
                                case "SPEI-3":
                                    num += i.SPEI_3;
                                    //  Console.WriteLine("SPEI_3: " + i.SPEI_3);
                                    break;
                                case "SPEI-6":
                                    num += i.SPEI_6;
                                    //  Console.WriteLine("SPEI_6: " + i.SPEI_6);
                                    break;
                                case "SPEI-12":
                                    num += i.SPEI_12;
                                    //  Console.WriteLine("SPEI_12: " + i.SPEI_12);
                                    break;
                                case "SPEI-24":
                                    num += i.SPEI_24;
                                    //  Console.WriteLine("SPEI_24: " + i.SPEI_24);
                                    break;
                            }
                        });
                        num = num * -1;
                        //num= decimal.Round(num, 4);
                        resEntity.droughtIntensity += num + "、";
                    });
                    resEntity.droughtIntensity = resEntity.droughtIntensity.TrimEnd('、');

                }
            }

            return resEntity;
        }


        private async Task<clsSPEI> gets(List<clsSPEIModel> clsSPEIs, string speiType)
        {
            var resEntity = new clsSPEI();
            resEntity.SPEI = speiType;
            resEntity.droughtLasted = clsSPEIs.Count();


            if (clsSPEIs.Count > 0)
            {
                clsSPEIs.ForEach(p => { resEntity.droughtMonths += p.months + "、"; });
                resEntity.droughtMonths = resEntity.droughtMonths.TrimEnd('、');

                if (clsSPEIs.Count == 0)//没有干旱
                {
                    resEntity.times = 0;
                    resEntity.droughtIntensity = "";
                }
                else if (clsSPEIs.Count == 1)//只有一个月有干旱
                {
                    resEntity.times = 1;
                    switch (speiType)
                    {
                        case "SPEI-1":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_1 * -1).ToString();
                            //  Console.WriteLine("SPEI_1: " + clsSPEIs.FirstOrDefault().SPEI_1);
                            break;
                        case "SPEI-3":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_3 * -1).ToString();
                            //  Console.WriteLine("SPEI_3: " + clsSPEIs.FirstOrDefault().SPEI_3);
                            break;
                        case "SPEI-6":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_6 * -1).ToString();
                            //  Console.WriteLine("SPEI_6: " + clsSPEIs.FirstOrDefault().SPEI_6);
                            break;
                        case "SPEI-12":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_12 * -1).ToString();
                            //  Console.WriteLine("SPEI_12: " + clsSPEIs.FirstOrDefault().SPEI_12);
                            break;
                        case "SPEI-24":
                            resEntity.droughtIntensity = (clsSPEIs.FirstOrDefault().SPEI_24 * -1).ToString();
                            //  Console.WriteLine("SPEI_24: " + clsSPEIs.FirstOrDefault().SPEI_24);
                            break;
                    }
                }
                else
                {
                    List<List<clsSPEIModel>> lstOut = new List<List<clsSPEIModel>>();

                    var lstTemp = clsSPEIs;
                    var lstNewData = new List<clsSPEIModel>();
                    lstNewData.Add(clsSPEIs[0]);
                    lstOut.Add(lstNewData);
                    int index = 0;

                    for (int i = 0; i < clsSPEIs.Count - 1; i++)
                    {
                        var entity = clsSPEIs[i];
                        var entitynext = clsSPEIs[i + 1];
                        if (entitynext.months - entity.months == 1)//说明这个是一个连续的
                        {
                            //lstNewData.Add(lstSpei_1[i + 1]);
                            lstOut[index].Add(clsSPEIs[i + 1]);
                        }
                        else
                        {
                            index++;
                            var a = new List<clsSPEIModel>();
                            a.Add(clsSPEIs[i + 1]);
                            lstOut.Add(a);
                        }
                    }

                    resEntity.times = lstOut.Count();

                    lstOut.ForEach(p =>
                    {
                        decimal num = 0;
                        p.ForEach(i =>
                        {

                            switch (speiType)
                            {
                                case "SPEI-1":
                                    num += i.SPEI_1;
                                    //  Console.WriteLine("SPEI_1: " + i.SPEI_1);
                                    break;
                                case "SPEI-3":
                                    num += i.SPEI_3;
                                    //  Console.WriteLine("SPEI_3: " + i.SPEI_3);
                                    break;
                                case "SPEI-6":
                                    num += i.SPEI_6;
                                    //  Console.WriteLine("SPEI_6: " + i.SPEI_6);
                                    break;
                                case "SPEI-12":
                                    num += i.SPEI_12;
                                    //  Console.WriteLine("SPEI_12: " + i.SPEI_12);
                                    break;
                                case "SPEI-24":
                                    num += i.SPEI_24;
                                    //  Console.WriteLine("SPEI_24: " + i.SPEI_24);
                                    break;
                            }
                        });
                        num = num * -1;
                        //num= decimal.Round(num, 4);
                        resEntity.droughtIntensity += num + "、";
                    });
                    resEntity.droughtIntensity = resEntity.droughtIntensity.TrimEnd('、');

                }
            }

            return resEntity;
        }

    }
}
