namespace ExtensionMethods.Advanced.InternalClassesExtension
{
    internal abstract class InternalClasses_0
    {
        public virtual string GetString0()
        {
            return "abc";
        }

        protected virtual string GetString00()
        {
            return "abcd";
        }
    }

    internal class InternalClasses_1 : InternalClasses_0
    {
        public string GetString1()
        {
            return "a";
        }

        internal class InternalClasses_2 : InternalClasses_0
        {
            public override string GetString0()
            {
                return "xyz";
            }

            internal string GetString2()
            {
                return "b";
            }

            private class InternalClasses_3
            {
                private string GetString3()
                {
                    return "c";
                }
            }
        }
    }
}
