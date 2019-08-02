using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLComtekGenerator.Interfaces;

namespace XMLComtekGenerator.Services
{
    class SearchBankXmlGenerator : ISearchBankXmlGenerator
    {
        private readonly IHashCodeGenerator chiper;

        public SearchBankXmlGenerator(IHashCodeGenerator chiper)
        {
            this.chiper = chiper;
        }
        public string Generate(string pinkod, string datetime, string password)
        {
            string hash = chiper.GenerateHash(new List<string>() { pinkod, datetime, password });

            XElement xml = new XElement("REQUEST",
                new XElement("ACTION", "search_bank"),
                new XElement("DATA",
                    new XElement("PIN_CODE", pinkod),
                    new XElement("DATE_TIME", datetime),
                    new XElement("HASH_CODE", hash)
                    )
                );
            return xml.ToString();
        }
    }
}
