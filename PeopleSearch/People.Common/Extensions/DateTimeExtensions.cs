using System;

namespace People.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static int? GetCurrentAge(this DateTime? dateTime)
        {
            if (dateTime == null)
                return null;
            var thisDate = (DateTime)dateTime;

            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - thisDate.Year;

            if (currentDate < thisDate.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
