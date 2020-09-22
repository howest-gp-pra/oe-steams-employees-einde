using System;
using System.Collections.Generic;
using System.Text;

namespace Pra.StreamsEmployee.CORE.Entities
{
    public class Employee
    {
        public string ID { get; set; }
        public string Employee_name { get; set; }
        public string Employee_salary { get; set; }
        public string Employee_age { get; set; }
        public string Profile_image { get; set; }

        public override string ToString()
        {
            return $"{ID} - {Employee_name} - ${double.Parse(Employee_salary).ToString("#,##0.00")} - {Employee_age} years";
        }
    }
}
