using System.Collections.Generic;

namespace MyStock.Models
{
    public static class GlobalVariables
    {
        public static List<TimeSeriesDaily> StockList;
        public static List<string> DatesList;
        public static bool retreived = false;
        public static string ErrorString = "{\n    \"Error Message\": \"Invalid API call. Please retry or visit the documentation (https://www.alphavantage.co/documentation/) for TIME_SERIES_DAILY.\"\n}";
    }
}

