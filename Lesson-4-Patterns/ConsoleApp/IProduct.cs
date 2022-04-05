using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal interface IProduct
    {
        int Id { get; set; }
        long Amount { get; set; }
        string AnotherInformation { get; set; }
    }
}
