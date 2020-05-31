using System;
using System.Collections.Generic;
using System.Text;

namespace CRMSystem.Domains
{
    public class Competency
    {
        public int ID { get; set; }
        public decimal TargetValue { get; set; }
        public decimal ActualValue { get; set; }
        public decimal CompPercent { get { return (ActualValue / TargetValue) * 100; } set { } }
    }
}
