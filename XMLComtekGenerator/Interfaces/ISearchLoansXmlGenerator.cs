using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComtekGenerator.Interfaces
{
    interface ISearchLoansXmlGenerator
    {
        string Generate(string pinkod, string bank_kod, string datetime, string password);
    }
}
