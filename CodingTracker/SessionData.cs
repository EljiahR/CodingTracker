using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class SessionData : IBarChartItem
    {
        public string Label {  get; set; }

        public double Value { get; set; }

        public Color? Color { get; set; }

        public SessionData(string label, double value) 
        { 
            Label = label;
            Value = value;
        }
      
    }
}
