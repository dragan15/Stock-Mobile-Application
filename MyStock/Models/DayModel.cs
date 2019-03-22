using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyStock.Models
{
    public class DayData
    {
        public string date { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
    }
}

