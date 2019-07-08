using System.ComponentModel;
using System.Linq;

namespace System
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }

        public static string GetDescription(this Enum value)
        {
            Reflection.FieldInfo fieldInfo = value
                                                .GetType()
                                                .GetField(value.GetName());
            DescriptionAttribute descriptionAttribute = fieldInfo
                                                            .GetCustomAttributes(typeof(DescriptionAttribute)
                                                                                , false)
                                                            .FirstOrDefault()
                                                            as DescriptionAttribute;

            return descriptionAttribute == null ? value.GetName()
                                                : descriptionAttribute.Description;
        }
    }
}
