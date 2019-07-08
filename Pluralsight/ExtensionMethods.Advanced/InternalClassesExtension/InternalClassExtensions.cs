using System.Reflection;

namespace ExtensionMethods.Advanced.InternalClassesExtension
{
    internal static class InternalClassExtensions
    {
        public static string GetString0Upper(this InternalClasses_0 obj)
        {
            return obj.GetString0().ToUpper();
        }

        public static string GetString1Upper(this InternalClasses_1 obj)
        {
            return obj.GetString1().ToUpper();
        }

        public static string GetString2Upper(this InternalClasses_1.InternalClasses_2 obj)
        {
            return obj.GetString2().ToUpper();
        }

        public static string GetString3Upper(this object obj)
        {
            var upper = string.Empty;
            var type3 = typeof(InternalClasses_1.InternalClasses_2)
                                .GetNestedType("InternalClasses_3"
                                                , BindingFlags.NonPublic);
            if (obj.GetType() == type3)
            {
                var method = type3
                                .GetMethod("GetString3"
                                            , BindingFlags.NonPublic
                                            | BindingFlags.Instance);
                var string3 = method.Invoke(obj, null) as string;
                upper = string3.ToUpper();
            }
            return upper;
        }
    }
}
