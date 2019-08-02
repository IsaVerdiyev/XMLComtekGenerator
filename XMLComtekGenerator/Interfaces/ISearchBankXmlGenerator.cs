using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComtekGenerator.Interfaces
{
    interface ISearchBankXmlGenerator
    {
        string Generate(string pinkod, string datetime, string password);
    }
}
