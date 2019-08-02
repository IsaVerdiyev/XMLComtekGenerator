using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLComtekGenerator.Interfaces;
using XMLComtekGenerator.Navigation;
using XMLComtekGenerator.Tools;
using XMLComtekGenerator.ViewModels.Shared;

namespace XMLComtekGenerator.ViewModels
{
    class SearchBankViewModel: ViewModelBase
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


        private string datetime;

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
        private readonly ISearchBankXmlGenerator xmlGenerator;


        #endregion

        #region Constructors

        public SearchBankViewModel(INavigator navigator, ISearchBankXmlGenerator xmlGenerator, NavigationViewModel navigationViewModel)
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
                XmlResult = xmlGenerator.Generate(PinKod, DateTime, Password);
            }));
        }

        #endregion
    }
}
