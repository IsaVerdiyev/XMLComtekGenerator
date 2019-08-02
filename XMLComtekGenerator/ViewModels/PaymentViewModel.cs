using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLComtekGenerator.Interfaces;
using XMLComtekGenerator.Navigation;
using XMLComtekGenerator.ViewModels.Shared;

namespace XMLComtekGenerator.ViewModels
{
    class PaymentViewModel: ViewModelBase
    {
        #region Fields And Properties

        private ViewModelBase upperPart;

        public ViewModelBase UpperPart
        {
            get { return upperPart; }
            set { Set(ref upperPart, value); }
        }


        private string pinkod;

        public string PinKod
        {
            get => pinkod;
            set => Set(ref pinkod, value);
        }


        private string bank_kod;

        public string BankKod
        {
            get => bank_kod;
            set => Set(ref bank_kod, value);
        }

        private string datetime;


        private string ld;

        public string LD
        {
            get { return ld; }
            set => Set(ref ld, value);
        }


        private string currency;

        public string Currency
        {
            get { return currency; }
            set => Set(ref currency, value);
        }

        private string account;

        public string Account
        {
            get { return account; }
            set => Set(ref account, value);
        }


        private string rpn;

        public string Rpn
        {
            get { return rpn; }
            set => Set(ref rpn, value);
        }

        private string amount;

        public string Amount
        {
            get { return amount; }
            set => Set(ref amount, value);
        }


        public string DateTime
        {
            get { return datetime; }
            set { Set(ref datetime, value); }
        }



        private string password;

        public string Password
        {
            get { return password; }
            set { Set(ref password, value); }
        }


        public string xmlresult;


        public string XmlResult
        {
            get { return xmlresult; }
            set { Set(ref xmlresult, value); }
        }
        #endregion


        #region Dependencies

        private readonly INavigator navigator;
        private readonly IPaymentXmlGenerator xmlGenerator;




        #endregion

        #region Constructors

        public PaymentViewModel(INavigator navigator, IPaymentXmlGenerator xmlGenerator, NavigationViewModel navigationViewModel)
        {
            this.navigator = navigator;
            this.xmlGenerator = xmlGenerator;

            UpperPart = navigationViewModel;
        }

        #endregion


        #region Commands

        RelayCommand generateXmlCommand;

        public RelayCommand GenerateXmlCommand
        {
            get => generateXmlCommand ?? (generateXmlCommand = new RelayCommand(() =>
            {
                XmlResult = xmlGenerator.Generate(PinKod, BankKod, LD, Currency, Account, Rpn, Amount, DateTime, Password);
            }));
        }

        #endregion
    }
}
