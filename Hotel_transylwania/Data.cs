﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_transylwania
{
    public class Data
    {
        public Data(int day, int month, int year)
        {
            Dzien = day;
            Miesiac = month;
            Rok = Rok;
        }

        public int Dzien { get; set; }
        public int Miesiac { get; set; }
        public int Rok { get; set; }
    }
}
