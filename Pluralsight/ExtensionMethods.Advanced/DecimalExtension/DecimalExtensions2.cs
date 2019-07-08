namespace System.Extensions
{
    public static class DecimalExtensions2
    {
        public static string ToStringRounded(this decimal input)
        {
            return Math.Round(input, 2).ToString();
        }
    }
}
