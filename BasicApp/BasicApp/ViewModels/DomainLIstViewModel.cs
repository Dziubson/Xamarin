using BasicApp.Models;
using BasicApp.Services;
using BasicApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BasicApp.ViewModels
{
    
    public class DomainListViewModel : BaseDomainViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllDomainsCommand { get; private set; }
        public ICommand LoadDomainsCommand { get; set; }

        public DomainListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _domainRepository = new DomainRepository();

            AddCommand = new Command(async () => await ShowAddDomain());
            DeleteAllDomainsCommand = new Command(async () => await DeleteAllDomains());
            LoadDomainsCommand = new Command(() => ExecuteLoadDomainsCommand());

            MessagingCenter.Subscribe<DomainListViewModel>(this,
                                      "ReloadDomainList", (sender) => { sender.FetchDomains(); });
            FetchDomains();
        }

        void FetchDomains()
        {
          //  DomainList = _domainRepository.GetAllDomainsData();
        }

        async Task ShowAddDomain()
        {
            var page = new AddDomain();
            page.Disappearing += SecondaryPage_OperationCompleted;
            //page.OperationCompeleted += SecondaryPage_OperationCompleted;
            await _navigation.PushAsync(page);
        }

        async Task DeleteAllDomains()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Domain List", "Delete All Domains Details ?", "OK", "Cancel");
            if (isUserAccept)
            {
              //  _domainRepository.DeleteAllDomains();
                FetchDomains();
                await _navigation.PushAsync(new AddDomain());
            }
        }

        async void ShowDomainDetails(int selectedDomainID)
        {
          //  await _navigation.PushAsync(new DomainDetails(selectedDomainID));
        }

        private void SecondaryPage_OperationCompleted(object sender, EventArgs e)
        {
            (sender as AddDomain).Disappearing -= SecondaryPage_OperationCompleted;
            FetchDomains();
        }

        void ExecuteLoadDomainsCommand()
        {
           // DomainList = _domainRepository.GetAllDomainsData();
        }

        public Domains SelectedDomainItem
        {
            set
            {
                NotifyPropertyChanged("SelectedDomainItem");
                ShowDomainDetails(value.Id);
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
}
