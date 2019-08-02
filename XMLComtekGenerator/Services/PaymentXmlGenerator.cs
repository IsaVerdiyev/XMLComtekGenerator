using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLComtekGenerator.Interfaces;

namespace XMLComtekGenerator.Services
{
    class PaymentXmlGenerator : IPaymentXmlGenerator
    {
        private readonly IHashCodeGenerator hashCodeGenerator;

        public PaymentXmlGenerator(IHashCodeGenerator hashCodeGenerator)
        {
            this.hashCodeGenerator = hashCodeGenerator;
        }

        public string Generate(string pinkod, string bankcode, string ld, string currency, string account, string rrn, string amount, string datetime, string password)
        {
            string hash = hashCodeGenerator.GenerateHash(new List<string>() { pinkod, bankcode, ld, currency, account, rrn, amount, datetime, password });

            XElement xml = new XElement("REQUEST",
                new XElement("ACTION", "payment"),
                new XElement("DATA",
                    new XElement("PIN_CODE", pinkod),
                    new XElement("BANK_CODE", bankcode),
                    new XElement("LD_ID", ld),
                    new XElement("CURRENCY_ID", currency),
                    new XElement("ACC_ID", account),
                    new XElement("RRN", rrn),
                    new XElement("AMT", amount),
                    new XElement("DATE_TIME", datetime),
                    new XElement("HASH_CODE", hash)
                    )
                );
            return xml.ToString();
        }
    }
}
