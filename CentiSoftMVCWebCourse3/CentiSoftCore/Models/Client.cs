﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public List<Customer> Cutomers { get; set; }
    }
}
