using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.Model
{
    class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created { get; set; }
        public float duration { get; set; }
        public int projectId { get; set; }
        public Project project { get; set; }
        public int developerId { get; set; }
        public Developer developer { get; set; }
    }
}
