using System;
using System.Collections.Generic;
using Entry = Microcharts.Entry;
using Microcharts;
using SkiaSharp;

using Xamarin.Forms;
using MyStock.Models;
using Microcharts.Forms;

namespace MyStock
{
    public partial class Charts : ContentPage
    {
        private List<Entry> entries = new List<Entry> { };
        private Entry entry;
        private float temp;

        public Charts()
        {
            InitializeComponent();

        }

        public void FillChart()
        {
            if (GlobalVariables.retreived == true)
            {
                for (int i = 0; i < GlobalVariables.StockList.Count-20; i++)
                {
                    if (i % 2 == 0)
                    {
                        temp = float.Parse(GlobalVariables.StockList[i].The2High);
                        entry = new Entry(temp)
                        {
                            Color = SKColor.Parse("#2FF234"),
                            Label = "",
                            ValueLabel = GlobalVariables.StockList[i].The2High,
                        };

                        entries.Add(entry);
                        entries.Reverse();
                    }
                }
            }
        }

        void GenerateChart(object sender, EventArgs e)
        {
            entries.Clear();
            ChartView.Chart = new BarChart { Entries = entries, BackgroundColor = SKColors.Transparent };

            FillChart();
            ChartView.Chart = new BarChart { Entries = entries, BackgroundColor = SKColors.Transparent };

            entries.Clear();
            ChartView2.Chart = new PointChart { Entries = entries, BackgroundColor = SKColors.Transparent };

            FillChart();
            ChartView2.Chart = new PointChart { Entries = entries, BackgroundColor = SKColors.Transparent };
        }


    }
}

