using BasicApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace BasicApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        List<HomeMenuItem> menuBottomItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                //new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.Domains, Title="Strony użytkownika", IconName="Domain.png" },           
            };

            menuBottomItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Settings, Title="Ustawienia", IconName="settings.png" },
                new HomeMenuItem {Id = MenuItemType.About, Title="O programie"},
            };

            ListViewMenu.ItemsSource = menuItems;
            BottomListViewMenu.ItemsSource = menuBottomItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                BottomListViewMenu.SelectedItem = null;
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

            BottomListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                ListViewMenu.SelectedItem = null;
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}