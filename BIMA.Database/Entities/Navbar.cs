using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Database.Entities
{
    public class Navbar
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Order { get; set; }

    }
}
