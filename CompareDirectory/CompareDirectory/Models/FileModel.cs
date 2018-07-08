using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDirectory.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public DateTime LastChange { get; set; }
        public string Status { get; set; }
    }

}
