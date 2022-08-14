namespace Sample1.Extensions
{
    // extension methods
    public static class DateTimeExtensions
    {

        public static TimeZoneInfo Vietnam_Tz => TimeZoneInfo.Local;

        public static DateTime GetDateTimeByUserTz(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, Vietnam_Tz);
        }

        public static DateTime GetUtcDateTimeFromUserTz(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, Vietnam_Tz);
        }
    }
}
