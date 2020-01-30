using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BasicApp.Models;
using BasicApp.Services;
using BasicApp.Views;
using Xamarin.Forms;
using BasicApp.ViewModels;
using System.Threading.Tasks;

namespace BasicApp.ViewModels
{
    public class AddDomainViewModel : BaseDomainViewModel
    {
        public ICommand AddDomainCommand { get; private set; }
        public ICommand ViewAllDomainsCommand { get; private set; }

        public AddDomainViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _domain = new Domains();
            _domainRepository = new DomainRepository();

            AddDomainCommand = new Command(async () => await AddDomain());
            ViewAllDomainsCommand = new Command(async () => await ShowDomainList());
        }

        async Task AddDomain()
        {
            _domainRepository.InsertDomain(_domain);

            //MessagingCenter.Send(new DomainListViewModel(_navigation), "ReloadDomainList");
            await _navigation.PopAsync();
        }

        async Task ShowDomainList()
        {
            await _navigation.PushAsync(new DomainList());
        }

        //public bool IsViewAll => _domainRepository.GetAllDomainsData().Count > 0 ? true : false;
    }
}
