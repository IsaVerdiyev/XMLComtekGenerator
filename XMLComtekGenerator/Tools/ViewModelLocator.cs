using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLComtekGenerator.Interfaces;
using XMLComtekGenerator.Navigation;
using XMLComtekGenerator.Services;
using XMLComtekGenerator.ViewModels;
using XMLComtekGenerator.ViewModels.Shared;

namespace XMLComtekGenerator.Tools
{
    class ViewModelLocator
    {
        INavigator navigator;

        public AppViewModel AppViewModel { get; }

        public NavigationViewModel NavigationViewModel { get; }



        public ViewModelLocator()
        {
            var config = new ConfigurationBuilder();
            //config.AddJsonFile("autofac.json");
            //var module = new ConfigurationModule(config.Build());
            //containerBuilder.RegisterModule(module);
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<MD5_Sha64_HashCodeGenerator>().As<IHashCodeGenerator>();
            containerBuilder.RegisterType<SearchBankXmlGenerator>().As<ISearchBankXmlGenerator>();
            containerBuilder.RegisterType<SearchLoansXmlGenerator>().As<ISearchLoansXmlGenerator>();
            containerBuilder.RegisterType<PaymentXmlGenerator>().As<IPaymentXmlGenerator>();
            containerBuilder.RegisterType<CheckTransactionXmlGenerator>().As<ICheckTransactionXmlGenerator>();

            containerBuilder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            containerBuilder.RegisterType<AppViewModel>();
            containerBuilder.RegisterType<SearchBankViewModel>();
            containerBuilder.RegisterType<SearchLoansViewModel>();
            containerBuilder.RegisterType<PaymentViewModel>();
            containerBuilder.RegisterType<NavigationViewModel>().SingleInstance();
            containerBuilder.RegisterType<CheckTransactionViewModel>();

            var container = containerBuilder.Build();

            AppViewModel = container.Resolve<AppViewModel>();

            NavigationViewModel = container.Resolve<NavigationViewModel>();

            navigator = container.Resolve<INavigator>();

            navigator.Register(AppViewModel);
            navigator.Register(container.Resolve<SearchBankViewModel>());
            navigator.Register(container.Resolve<SearchLoansViewModel>());
            navigator.Register(container.Resolve<PaymentViewModel>());
            navigator.Register(container.Resolve<CheckTransactionViewModel>());

            navigator.NavigateTo<SearchBankViewModel>();

        }
    }
}
