using System.Collections.Generic;

namespace BlazorUI.Client.CoreUI
{
    public class NavbarModel
    {
        public string style { get; set; }

        public IList<NavbarItemModel> MenuItems { get; set; }=new List<NavbarItemModel>();
    }

    public class NavbarItemModel
    {
        public string StyleLi { get; set; }
        public string StyleHref { get; set; }

        public string style { get; set; }

        public NavbarItemType ItemType { get; set; } = NavbarItemType.MenuItem;

        public string Caption { get; set; }

        public IList<NavbarItemModel> Children { get; set; }

        public string Link { get; set; }

        public bool HasChild
        {
            get
            {
                return Children != null && Children.Count != 0;
            }
        }
    }

    public enum NavbarItemType
    {
        TextOnly,
        MenuItem,
        DropDown
    }
}
