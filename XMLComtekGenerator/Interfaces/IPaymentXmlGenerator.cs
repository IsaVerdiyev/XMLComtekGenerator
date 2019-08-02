using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComtekGenerator.Interfaces
{
    interface IPaymentXmlGenerator
    {
        string Generate(string pinkod, string bankcode, string ld, string currency, string account, string rpn, string amount, string datetime, string password);
    }
}
