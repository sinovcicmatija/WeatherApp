namespace WeatherAPI.Helpers
{
    public static class TimeConversionHelper
    {
        public static DateTime ConvertToLocalTime(long unixTime, int timezoneOffset)
        {
            DateTime utcTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
            return utcTime.AddSeconds(timezoneOffset);
        }
        
    }
}
