using BasicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicApp.Views
{
    public partial class DomainList : ContentPage
    {
        public DomainList()
        {
            InitializeComponent();

            BindingContext = new DomainListViewModel(Navigation);
        }
    }
}