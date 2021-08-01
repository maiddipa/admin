using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class PlanPrice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
    }
}
