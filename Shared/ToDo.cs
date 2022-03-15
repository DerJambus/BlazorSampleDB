using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSampleDB.Shared
{
    public class ToDo
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }

    }
}
