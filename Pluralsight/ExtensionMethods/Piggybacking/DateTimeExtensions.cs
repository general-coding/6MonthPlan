using System.Xml;

namespace System
{
    public static class DateTimeExtensions
    {
        //public static string ToXMLDateTime(this DateTime dateTime)
        //{
        //    //return XmlConvert.ToString(dateTime, XmlDateTimeSerializationMode.Utc);
        //    return dateTime.ToXMLDateTime(XmlDateTimeSerializationMode.Utc);
        //}

        public static string ToXMLDateTime(this DateTime dateTime
            , XmlDateTimeSerializationMode mode = XmlDateTimeSerializationMode.Utc)
        {
            return XmlConvert.ToString(dateTime, mode);
        }
    }
}
