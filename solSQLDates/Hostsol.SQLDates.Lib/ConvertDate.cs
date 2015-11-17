using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SQLDatesFunc
{
    //public partial class UserDefinedFunctions
    public class ConvertDate
    {

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertToUtc(SqlString dotNetTimeZone, SqlDateTime theDateTime)
        {
            var localDate = DateTime.SpecifyKind((DateTime)theDateTime, DateTimeKind.Unspecified);

            // create TimeZoneInfo by string time zone.
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dotNetTimeZone.ToString());

            // convert date local to utc date by time zone.
            return TimeZoneInfo.ConvertTimeToUtc(localDate, timeZoneInfo);
        }
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertToLocalTimeZone(SqlString dotNetTimeZone, SqlDateTime theDateTime)
        {
            // create TimeZoneInfo by string time zone by time zone.
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dotNetTimeZone.ToString());

            // convert date utc to local date.
            return TimeZoneInfo.ConvertTimeFromUtc((DateTime)theDateTime, timeZoneInfo);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlBoolean IsDaylightSaving(SqlString dotNetTimeZone, SqlDateTime theDateTime)
        {
            // create TimeZoneInfo by string time zone by time zone.
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dotNetTimeZone.ToString());

            // convert date utc to local date.
            var theNewDateTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)theDateTime, timeZoneInfo);

            return theNewDateTime.IsDaylightSavingTime();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlBoolean IsLeapYear(SqlString dotNetTimeZone, SqlDateTime theDateTime)
        {
            // create TimeZoneInfo by string time zone by time zone.
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dotNetTimeZone.ToString());

            // convert date utc to local date.
            var theNewDateTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)theDateTime, timeZoneInfo);

            return DateTime.IsLeapYear(theNewDateTime.Year);
        }
    }
}
