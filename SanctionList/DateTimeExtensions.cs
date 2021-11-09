namespace SanctionList
{
    public static class DateTimeExtensions
    {
        public static string ToFileNameFormatString(this DateTime dateTime)
        {
            return $"{dateTime.ToShortDateString()} - {dateTime.Hour}h {dateTime.Minute}m {dateTime.Second}s";
        }
    }
}
