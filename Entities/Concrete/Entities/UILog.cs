﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities
{
    public class UILog : IEntity
    {
        public long Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
    }
}
