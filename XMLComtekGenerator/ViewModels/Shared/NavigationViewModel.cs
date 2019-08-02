using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLComtekGenerator.Navigation;

namespace XMLComtekGenerator.ViewModels.Shared
{
    class NavigationViewModel: ViewModelBase
    {

        #region Fields And Properties

        private bool searchBankSelected;

        public bool SearchBankSelected
        {
            get { return searchBankSelected; }
            set { searchBankSelected = value; }
        }

        private bool searchLoansSelected;

        public bool SearchLoansSelected
        {
            get { return searchLoansSelected; }
            set { searchLoansSelected = value; }
        }

        private bool paymentSelected;

        public bool PaymentSelected
        {
            get { return paymentSelected; }
            set { paymentSelected = value; }
        }


        private bool checkSelected;

        public bool CheckSelected
        {
            get { return checkSelected; }
            set { checkSelected = value; }
        }



        #endregion

        #region Dependencies
        private readonly INavigator navigator;


        #endregion

        #region Constructors

        public NavigationViewModel(INavigator navigator)
        {
            this.navigator = navigator;
            SearchBankSelected = true;
        }

        #endregion


        #region Commands

        RelayCommand<Type> navigateCommand;

        public RelayCommand<Type> NavigateCommand
        {
            get => navigateCommand ?? (navigateCommand = new RelayCommand<Type>(
                t =>
                {
                    changeSelected(t);
                    navigator.NavigateTo(t);
                    
                }
                ));
        }


        #endregion


        #region Private Functions

        private void changeSelected(Type t)
        {
            SearchBankSelected = SearchLoansSelected = PaymentSelected = CheckSelected = false;

            if(t == typeof(SearchBankViewModel))
            {
                SearchBankSelected = true;
            }
            else if (t == typeof(SearchLoansViewModel))
            {
                SearchLoansSelected = true;
            }
            else if (t == typeof(PaymentViewModel))
            {
                PaymentSelected = true;
            }
            else if (t == typeof(CheckTransactionViewModel))
            {
                CheckSelected = true;
            }
        }

        #endregion

    }
}
