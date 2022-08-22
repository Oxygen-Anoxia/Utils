using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            Console.ReadLine();
            //Console.WriteLine("Hello World!");
            //var updateDate = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Console.WriteLine(updateDate);

            // DateTime newStartTime = Convert.ToDateTime("1910-01-01 00:00:00");
            // Console.WriteLine(newStartTime);

            //十进制转二进制 
            Console.WriteLine(Convert.ToString(69, 2));
            //十进制转八进制 
            Console.WriteLine(Convert.ToString(69, 8));

            Console.WriteLine(Convert.ToString(0080453043, 10));
            //十进制转十六进制 
            Console.WriteLine(Convert.ToString(0080453043, 16));


            byte[] byteArrayss = { 4, 40, 47, 94, 121, 72, 128 };
            string str = System.Text.Encoding.Default.GetString(byteArrayss);
            Console.WriteLine(str);


            string read = Console.ReadLine();
            Console.WriteLine(NFCIdConvert(read));
            Console.WriteLine();

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(read);

            Console.WriteLine(ByteArrayToHexString(byteArray));
            Console.WriteLine(ByteArrayToHexString(Str_String(read)));

            Console.WriteLine();
            Console.WriteLine(byte2HexString(byteArray));

            Console.ReadLine();


            //string path = @"C:\Users\Joyce\OneDrive\桌面\Untitled-WHYT_TY-209f115a-9452-4aab-94f3-21992a481bbc.pdf";
            //var vs = System.IO.File.ReadAllBytes(path);

            //Bytes2File(vs, @"D:\ssss");

        }


        private static string NFCIdConvert(string data)
        {
            string res = "";
            if (string.IsNullOrEmpty(data)) return data;
            try
            {
                String hex = UtilConvert.Ten2Hex(data);


                if (null != hex)
                {
                    char[] chars = hex.ToCharArray();
                    StringBuilder sb = new StringBuilder();
                    for (int i = chars.Length - 2; i >= 0; i -= 2)
                    {
                        sb.Append(chars[i].ToString().ToUpper()).Append(chars[i + 1].ToString().ToUpper());
                    }
                    res = sb.ToString();
                }
            }
            catch
            {

            }
            return res;
        }

        public static byte[] Str_String(string str)
        {
            byte[] str_byte = new byte[str.Length];
            char[] str1 = new char[str.Length];
            str.CopyTo(0, str1, 0, str.Length);
            for (int i = 0; i < str1.Length; i++) str_byte[i] = Convert.ToByte(str1[i]);
            return str_byte;
        }

        public static string byte2HexString(byte[] bytes)
        {
            string ret = "";
            if (bytes != null)
            {

                foreach (var item in bytes)
                {
                    ret += string.Format("%02X", item.ObjToInt() & 0xFF);
                }
                //for (byte b : bytes)
                //{
                //    ret += string.Format("%02X", b.intValue() & 0xFF);
                //}
            }
            return ret;
        }


        private static string ByteArrayToHexString(byte[] inarray)
        {
            int i, j, ins;
            string[] hex = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string outs = "";
            for (j = 0; j < inarray.Length; ++j)
            {
                ins = (int)inarray[j] & 0xff;
                i = (ins >> 4) & 0x0f;
                outs += hex[i];
                i = ins & 0x0f;
                outs += hex[i];
            }
            return outs;
        }


        /// <summary>
        /// 将byte数组转换为文件并保存到指定地址
        /// </summary>
        /// <param name="buff">byte数组</param>
        /// <param name="savepath">保存地址</param>
        public static void Bytes2File(byte[] buff, string savepath)
        {
            try
            {

                if (System.IO.File.Exists(savepath))
                {
                    System.IO.File.Delete(savepath);
                }

                FileStream fs = new FileStream(savepath, FileMode.CreateNew);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buff, 0, buff.Length);
                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

    }

    public static class UtilConvert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static int ObjToInt(this object thisValue)
        {
            int reval = 0;
            if (thisValue == null) return 0;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static int ObjToInt(this object thisValue, int errorValue)
        {
            int reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static double ObjToMoney(this object thisValue)
        {
            double reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static double ObjToMoney(this object thisValue, double errorValue)
        {
            double reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static string ObjToString(this object thisValue)
        {
            if (thisValue != null) return thisValue.ToString().Trim();
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsNotEmptyOrNull(this object thisValue)
        {
            return ObjToString(thisValue) != "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static string ObjToString(this object thisValue, string errorValue)
        {
            if (thisValue != null) return thisValue.ToString().Trim();
            return errorValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static Decimal ObjToDecimal(this object thisValue)
        {
            Decimal reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static Decimal ObjToDecimal(this object thisValue, decimal errorValue)
        {
            Decimal reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static DateTime ObjToDate(this object thisValue)
        {
            DateTime reval = DateTime.MinValue;
            if (thisValue != null && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out reval))
            {
                reval = Convert.ToDateTime(thisValue);
            }
            return reval;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static DateTime ObjToDate(this object thisValue, DateTime errorValue)
        {
            DateTime reval = DateTime.MinValue;
            if (thisValue != null && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool ObjToBool(this object thisValue)
        {
            bool reval = false;
            if (thisValue != null && thisValue != DBNull.Value && bool.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }

        /// <summary>
        /// 从十进制转换到十六进制
        /// </summary>
        /// <param name="ten"></param>
        /// <returns></returns>
        public static string Ten2Hex(string ten)
        {
            ulong tenValue = Convert.ToUInt64(ten);
            ulong divValue, resValue;
            string hex = "";
            do
            {
                //divValue = (ulong)Math.Floor(tenValue / 16);

                divValue = (ulong)Math.Floor((decimal)(tenValue / 16));

                resValue = tenValue % 16;
                hex = tenValue2Char(resValue) + hex;
                tenValue = divValue;
            }
            while (tenValue >= 16);
            if (tenValue != 0)
                hex = tenValue2Char(tenValue) + hex;
            return hex;
        }

        private static string tenValue2Char(ulong ten)
        {
            switch (ten)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return ten.ToString();
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return "";
            }
        }

        public static DateTime StampToDatetime(long TimeStamp, bool isMinSeconds = false)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));//当地时区
            //返回转换后的日期
            if (isMinSeconds)
                return startTime.AddMilliseconds(TimeStamp);
            else
                return startTime.AddSeconds(TimeStamp);
        }
    }

}
