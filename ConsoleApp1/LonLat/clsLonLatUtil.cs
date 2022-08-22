using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LonLat
{
    public static class clsLonLatUtil
    {

        //地图原点经纬度坐标
        //经度: 118.9681157689512
        //纬度: 33.37648744546809

        static long LonLat_A = 6378137;
        static double LonLat_B = 6356752.3142;
        static double LonLat_F = 1 / 298.257223563;

        // lon：基准点经度
        // lat：基准点纬度
        // distance：目标点离基准点距离
        // angle：目标点与基准点连线和正北方向夹角

        /// <summary>
        /// 获取xy 坐标的经纬度
        /// </summary>
        /// <param name="postX">X</param>
        /// <param name="postY">Y</param>
        /// <param name="lon">基准点经度</param>
        /// <param name="lat">基准点纬度</param>
        /// <param name="rootX">原点X</param>
        /// <param name="rootY">原点Y</param>
        /// <returns>返回经纬度实体类</returns>
        public static LonLat ComputeLonLat(double postX, double postY,
            double lon = 118.9681157689512, double lat = 33.37648744546809, double rootX = 0, double rootY = 0)
        {

            double distance = getDistance(rootX, rootY, postX, postY);
            double alpha1 = (Math.PI / 2) - Math.Atan2(postY - rootY, postX - rootX);
            double sinAlpha1 = Math.Sin(alpha1);
            double cosAlpha1 = Math.Cos(alpha1);

            double tanU1 = (1 - LonLat_F) * Math.Tan(Rad(lat));
            double cosU1 = 1 / Math.Sqrt((1 + tanU1 * tanU1));
            double sinU1 = tanU1 * cosU1;
            double sigma1 = Math.Atan2(tanU1, cosAlpha1);
            double sinAlpha = cosU1 * sinAlpha1;
            double cosSqAlpha = 1 - sinAlpha * sinAlpha;
            double uSq = cosSqAlpha * ((LonLat_A * LonLat_A) - LonLat_B * LonLat_B) / (LonLat_B * LonLat_B);
            double A = 1 + uSq / 16384 * (4096 + uSq * (-768 + uSq * (320 - 175 * uSq)));
            double B = uSq / 1024 * (256 + uSq * (-128 + uSq * (74 - 47 * uSq)));

            double sigma = distance / (LonLat_B * A);
            double sigmaP = 2 * Math.PI;
            double cos2SigmaM = Math.Cos(2 * sigma1 + sigma);
            double sinSigma = Math.Sin(sigma);
            double cosSigma = Math.Cos(sigma);
            while (Math.Abs(sigma - sigmaP) > 1e-12)
            {
                cos2SigmaM = Math.Cos(2 * sigma1 + sigma);
                sinSigma = Math.Sin(sigma);
                cosSigma = Math.Cos(sigma);
                double deltaSigma = B * sinSigma * (cos2SigmaM + B / 4 * (cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM)
                        - B / 6 * cos2SigmaM * (-3 + 4 * sinSigma * sinSigma) * (-3 + 4 * cos2SigmaM * cos2SigmaM)));
                sigmaP = sigma;
                sigma = distance / (LonLat_B * A) + deltaSigma;
            }

            double tmp = sinU1 * sinSigma - cosU1 * cosSigma * cosAlpha1;
            double lat2 = Math.Atan2(sinU1 * cosSigma + cosU1 * sinSigma * cosAlpha1,
                    (1 - LonLat_F) * Math.Sqrt(sinAlpha * sinAlpha + tmp * tmp));
            double lambda = Math.Atan2(sinSigma * sinAlpha1, cosU1 * cosSigma - sinU1 * sinSigma * cosAlpha1);
            double C = LonLat_F / 16 * cosSqAlpha * (4 + LonLat_F * (4 - 3 * cosSqAlpha));
            double L = lambda - (1 - C) * LonLat_F * sinAlpha
                    * (sigma + C * sinSigma * (cos2SigmaM + C * cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM)));

            //double revAz = Math.Atan2(sinAlpha, -tmp);
            //JSONObject lonLat = new JSONObject();
            //lonLat.put("lon", lon + Deg(L));
            //lonLat.put("lat", Deg(lat2));

            var entity = new LonLat()
            {
                lon = lon + Deg(L),
                lat = Deg(lat2)
            };

            return entity;
        }

        public static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double Deg(double d)
        {
            return d * 180 / Math.PI;
        }

        /// <summary>
        /// 获取与坐标原点的距离
        /// </summary>
        /// <param name="rootX">原点X</param>
        /// <param name="rootY">原点Y</param>
        /// <param name="postX">X</param>
        /// <param name="postY">Y</param>
        /// <returns>距离</returns>
        public static double getDistance(double rootX, double rootY, double postX, double postY)
        {
            double dx2 = Math.Pow((rootX - postX), 2);
            double dy2 = Math.Pow((rootY - postY), 2);
            double dz2 = Math.Pow((0 - 0), 2);
            return Math.Sqrt(dx2 + dy2 + dz2);
        }


    }


    /// <summary>
    /// 经纬度实体类
    /// </summary>
    public class LonLat
    {
        /// <summary>
        /// 经度
        /// </summary>
        public double lon { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double lat { get; set; }

    }
}
