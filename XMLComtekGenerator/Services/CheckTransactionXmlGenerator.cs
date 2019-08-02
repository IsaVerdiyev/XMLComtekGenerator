using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLComtekGenerator.Interfaces;

namespace XMLComtekGenerator.Services
{
    class CheckTransactionXmlGenerator : ICheckTransactionXmlGenerator
    {
        private readonly IHashCodeGenerator hashCodeGenerator;

        public CheckTransactionXmlGenerator(IHashCodeGenerator hashCodeGenerator)
        {
            this.hashCodeGenerator = hashCodeGenerator;
        }
        public string Generate(string rrn, string datetime, string password)
        {
            string hash = hashCodeGenerator.GenerateHash(new List<string>() { rrn, datetime, password });

            XElement xml = new XElement("REQUEST",
                new XElement("ACTION", "check_transaction"),
                new XElement("DATA",
                    new XElement("RRN", rrn),
                    new XElement("DATE_TIME", datetime),
                    new XElement("HASH_CODE", hash)
                    )
                );
            return xml.ToString();
        }
    }
}
