using CentiSoftCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.MODELS
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
