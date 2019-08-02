using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLComtekGenerator.Interfaces;

namespace XMLComtekGenerator.Services
{
    class SearchLoansXmlGenerator : ISearchLoansXmlGenerator
    {
        private readonly IHashCodeGenerator hashCodeGenerator;

        public SearchLoansXmlGenerator(IHashCodeGenerator hashCodeGenerator)
        {
            this.hashCodeGenerator = hashCodeGenerator;
        }
        public string Generate(string pinkod, string bank_kod, string datetime, string password)
        {
            string hash = hashCodeGenerator.GenerateHash(new List<string>() { pinkod, bank_kod, datetime, password });

            XElement xml = new XElement("REQUEST",
                new XElement("ACTION", "search_loans"),
                new XElement("DATA",
                    new XElement("PIN_CODE", pinkod),
                    new XElement("BANK_CODE", bank_kod),
                    new XElement("DATE_TIME", datetime),
                    new XElement("HASH_CODE", hash)
                    )
                );
            return xml.ToString();
        }
    }
}
