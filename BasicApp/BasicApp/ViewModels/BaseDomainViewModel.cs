using BasicApp.Services;
using BasicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BasicApp.ViewModels
{
    public class BaseDomainViewModel : INotifyPropertyChanged
    {
        public Domains _domain;

        public INavigation _navigation;
        public IDomainRepository _domainRepository;

        public string Name
        {
            get => _domain.Name;
            set
            {
                _domain.Name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string Link
        {
            get => _domain.Link;
            set
            {
                _domain.Link = value;
                NotifyPropertyChanged(nameof(Link));
            }
        }

        public string Cost
        {
            get => _domain.Cost;
            set
            {
                _domain.Cost = value;
                NotifyPropertyChanged(nameof(Cost));
            }
        }

        public string Description
        {
            get => _domain.Description;
            set
            {
                _domain.Description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        private List<Domains> domains;

        public List<Domains> DomainList
        {
            get { return domains; }
            set { domains = value; }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

