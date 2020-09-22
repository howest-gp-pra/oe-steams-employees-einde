using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Pra.StreamsEmployee.CORE.Entities;

namespace Pra.StreamsEmployee.CORE.Services
{
    public class JSonReader
    {
        public static List<Employee> ReadJSON(string url)
        {
            EmployeeFileStructure employeeFileStructure = new EmployeeFileStructure();

            var json = new WebClient().DownloadString(url);
            employeeFileStructure = JsonConvert.DeserializeObject<EmployeeFileStructure>(json);
            return employeeFileStructure.Data;
        }
    }
}
