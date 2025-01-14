﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataStructures
{
    class Rate
    {
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }

        public int Cur_Scale { get; set; }

        public string Cur_Name { get; set; }

        public double Cur_OfficialRate { get; set; }
    }
}
