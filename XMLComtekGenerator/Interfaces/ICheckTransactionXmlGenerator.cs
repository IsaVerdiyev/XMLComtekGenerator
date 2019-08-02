using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComtekGenerator.Interfaces
{
    interface ICheckTransactionXmlGenerator
    {
        string Generate(string rrn, string datetime, string password);
    }
}
