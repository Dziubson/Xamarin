using System;
using System.Collections.Generic;
using System.Text;

namespace BasicApp.Models
{
    public enum MenuItemType
    {
        //Browse,
        Domains,
        Settings,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string IconName { get; set; }
    }
}

