﻿using System.Collections.Generic;
using System;

namespace DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
