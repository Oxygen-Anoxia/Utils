using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ClassToXmlLibrary
{
    /// <summary>
    /// XML序列化公共处理类
    /// </summary>
    public class XmlSerializeHelper
    {

        /// <summary>
        /// 将实体对象转换成XML
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="obj">实体对象</param>
        public static string XmlSerialize<T>(T obj)
        {
            try
            {

                string xmlString = string.Empty;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                using (MemoryStream ms = new MemoryStream())
                {
                    xmlSerializer.Serialize(ms, obj);
                    xmlString = Encoding.UTF8.GetString(ms.ToArray());
                }
                return xmlString;


                //using (StringWriter sw = new StringWriter())
                //{
                //    XmlSerializer xz = new XmlSerializer(obj.GetType());
                //    xz.Serialize(sw, obj);
                //    return sw.ToString();
                //}

                //using (StringWriter sw = new StringWriter())
                //{
                //    Type t = obj.GetType();
                //    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                //    serializer.Serialize(sw, obj);

                //    sw.Close();
                //    return sw.ToString();
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("将实体对象转换成XML异常", ex);
            }
            //try
            //{

            //    var doc = new XDocument(
            //        new XDeclaration("1.0", "gb2312", ""),
            //        new XElement("test", "data")
            //        );
            //    var output = new StringBuilder();
            //    var settings = new XmlWriterSettings { Indent = true };
            //    using (XmlWriter xw = XmlWriter.Create(output, settings))
            //    {
            //        doc.Save(xw);
            //    }
            //    //Console.WriteLine(output.ToString());

            //    return output.ToString();


            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("将实体对象转换成XML异常", ex);
            //}



            try
            {
                using (Stream stream = new MemoryStream())
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                    xmlSerializer.Serialize(stream, obj);
                    stream.Position = 0;
                    StreamReader reader = new StreamReader(stream);
                    string res = reader.ReadToEnd();
                    return res;
                }
                //string res = string.Empty;
                //XmlSerializer serializer = new XmlSerializer(obj.GetType());
                //FileStream stream = new FileStream("hh.xml", FileMode.Create);

                //XmlWriterSettings settings = new XmlWriterSettings();
                //settings.Indent = true;
                //settings.IndentChars = "  ";
                //settings.NewLineChars = "\r\n";
                //settings.Encoding = Encoding.GetEncoding("GB2312");
                //using (XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
                //{

                //    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                //    namespaces.Add(string.Empty, string.Empty);
                //    serializer.Serialize(xmlWriter, obj, namespaces);
                //    res = xmlWriter.ToString();
                //    xmlWriter.Close();
                //}
                //stream.Close();

                //return res;

            }
            catch (Exception ex)
            {
                throw new Exception("将实体对象转换成XML异常", ex);
            }

        }

        /// <summary>
        /// 将XML转换成实体对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="strXML">XML</param>
        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("将XML转换成实体对象异常", ex);
            }
        }

    }
}
