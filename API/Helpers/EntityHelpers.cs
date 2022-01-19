using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class EntityHelpers
    {
        public const string actionAdd = "A";
        public const string actionEdit = "E";
        public const string actionDelete = "D";

        public static DateTime GetCurrentDate()
        {
            return Convert.ToDateTime(DateTime.UtcNow.ToString("dd-MMM-yyyy H:mm:ss"));
        }
    }
}
