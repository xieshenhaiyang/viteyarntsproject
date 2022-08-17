namespace Dapper_NOMiNiApi.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotEmptyOrNull(this string value) {
            return string.IsNullOrEmpty(value.Trim()) ? true : false;
        }
    }
}
