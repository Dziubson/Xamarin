using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using BasicApp.Models;
using BasicApp.Services;

namespace BasicApp.ViewModels
{
    public class DomainDetailsViewModel : BaseDomainViewModel
    {
        public ICommand UpdateDomainCommand { get; private set; }
        public ICommand DeleteDomainCommand { get; private set; }

        public DomainDetailsViewModel(INavigation navigation, int selectedContactID)
        {
            _navigation = navigation;
            _domain = new Domains();
            _domain.Id = selectedContactID;
            _domainRepository = new DomainRepository();

            //UpdateDomainCommand = new Command(async () => await UpdateDomain());
            //DeleteDomainCommand = new Command(async () => await DeleteDomain());

            FetchContactDetails();
        }

        void FetchContactDetails()
        {
            _domain = _domainRepository.GetDomainData(_domain.Id);
        }

        async Task UpdateDomain()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Domain Details", "Update Domain Details", "OK", "Cancel");
            if (isUserAccept)
            {
               // _domainRepository.UpdateDomain(_domain);
                await _navigation.PopAsync();
            }
        }

        async Task DeleteDomain()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Domain Details", "Delete Domain Details", "OK", "Cancel");
            if (isUserAccept)
            {
               // _domainRepository.DeleteDomain(_domain.Id);
                await _navigation.PopAsync();
            }
        }
    }
}
