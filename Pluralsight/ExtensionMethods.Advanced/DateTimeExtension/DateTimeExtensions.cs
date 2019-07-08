using System;
using System.Xml;

namespace ExtensionMethods.Advanced.DateTimeExtension
{
    public static class DateTimeExtensions
    {
        public static string ToXmlDateTime(this DateTime dateTime)
        {
            return XmlConvert.ToString(dateTime, XmlDateTimeSerializationMode.Utc);
        }
    }
}
