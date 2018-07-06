using BlazorUI.Client.CoreUI;
using System;
using System.Collections.Generic;

namespace BlazorUI.Client.Services
{
    public class AppState
    {
        public NavbarModel LoadSidebar()
        {
            var result = new NavbarModel();

            var menuList = new List<NavbarItemModel>();

            menuList.Add(new NavbarItemModel { Caption = "控制面板", Link = "index.html", style = "icon-speedometer" });
            menuList.Add(new NavbarItemModel { ItemType = NavbarItemType.TextOnly, Caption = "Theme" });
            menuList.Add(new NavbarItemModel { Caption = "Colors", Link = "colors.html", style = "icon-drop" });
            menuList.Add(new NavbarItemModel { Caption = "Typography", Link = "colors.html", style = "icon-pencil" });
            menuList.Add(new NavbarItemModel { ItemType = NavbarItemType.TextOnly, Caption = "Components" });

            menuList.Add(new NavbarItemModel
            {
                ItemType = NavbarItemType.DropDown,
                Caption = "Base",
                style = "icon-puzzle",
                Children = new List<NavbarItemModel>()
                {
                    new NavbarItemModel { Caption = "Breadcrumb", Link = "base/breakcrumb.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Breadcrumb", Link = "base/breakcrumb.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Cards", Link = "base/cards.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Carousel", Link = "base/carousel.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Collapse", Link = "base/collapse.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Forms", Link = "base/forms.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Jumbotron", Link = "base/jumbotron.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "List group", Link = "base/list-group.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Navs", Link = "base/navs.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Pagination", Link = "base/pagination.html", style = "icon-puzzle" },

                    new NavbarItemModel { Caption = "Popovers", Link = "base/popovers.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Progress", Link = "base/progress.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Scrollspy", Link = "base/scrollspy.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Switches", Link = "base/switches.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Tables", Link = "base/tables.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Tabs", Link = "base/tabs.html", style = "icon-puzzle" },
                    new NavbarItemModel { Caption = "Tooltips", Link = "base/tooltips.html", style = "icon-puzzle" }
                }
            });

            menuList.Add(new NavbarItemModel
            {
                ItemType = NavbarItemType.DropDown,
                Caption = "Buttons",
                style = "icon-cursor",
                Children = new List<NavbarItemModel>()
                {
                    new NavbarItemModel { Caption = "Buttons", style = "icon-cursor", Link = "buttons/buttons.html" },
                    new NavbarItemModel { Caption = "Buttons Group", style = "icon-cursor", Link = "buttons/button-group.html" },
                    new NavbarItemModel { Caption = "Dropdowns", style = "icon-cursor", Link = "buttons/dropdowns.html" },
                    new NavbarItemModel { Caption = "Brand Buttons", style = "icon-cursor", Link = "buttons/brand-buttons.html" },
                }
            });

            menuList.Add(new NavbarItemModel { Caption = "Charts", style = "icon-pie-chart", Link= "charts.html" });

            menuList.Add(new NavbarItemModel
            {
                ItemType = NavbarItemType.DropDown,
                Caption = "Icons",
                style = "icon-star",
                Children = new List<NavbarItemModel>()
                {
                    new NavbarItemModel { Caption = "CoreUI Icons", style = "icon-star", Link = "icons/coreui-icons.html" },
                    new NavbarItemModel { Caption = "Flags", style = "icon-star", Link = "icons/flags.html" },
                    new NavbarItemModel { Caption = "Font Awesome", style = "icon-star", Link = "icons/font-awesome.html" },
                    new NavbarItemModel { Caption = "Simple Line Icons", style = "icon-star", Link = "icons/simple-line-icons.html" }
                }
            });

            menuList.Add(new NavbarItemModel
            {
                ItemType = NavbarItemType.DropDown,
                Caption = "Notifications",
                style = "icon-bell",
                Children = new List<NavbarItemModel>()
                {
                    new NavbarItemModel { Caption = "Alerts", style = "icon-bell", Link = "notifications/alerts.html" },
                  new NavbarItemModel { Caption = "Badge", style = "icon-bell", Link = "notifications/badge.html" },
                   new NavbarItemModel { Caption = "Modals", style = "icon-bell", Link = "notifications/modals.html" }
                }
            });

            menuList.Add(new NavbarItemModel { Caption = "Widgets", style = "icon-calculator", Link = "widgets.html" });

            menuList.Add(new NavbarItemModel { Caption = "Widgets", ItemType=NavbarItemType.TextOnly });

            menuList.Add(new NavbarItemModel { Caption = "Download CoreUI", style = "icon-cloud-download", Link = "https://coreui.io", StyleLi="mt-auto", StyleHref= "nav-link-success" });
            menuList.Add(new NavbarItemModel { Caption = "Try CoreUI", style = "icon-layers", Link = "https://coreui.io/pro/", StyleHref = "nav-link-danger" });

            result.MenuItems = menuList;
            return result;
        }

        #region "Sidebar Toggle"
        public event Action OnChange;

        public string BodySidebarClass = "";
        public string BodySidebarLgClass = "sidebar-lg-show";

        public string BodySidebarMinimizeClass = "";

        public void ToggleSidebarMinimize(bool isMinimize)
        {
            if (isMinimize)
            {
                BodySidebarMinimizeClass = "brand-minimized sidebar-minimized";
            }
            else
            {
                BodySidebarMinimizeClass = "";
            }
            NotifyStateChanged();
        }

        public void ToggleSidebar(string type, bool isVisible)
        {
            Console.WriteLine(type);

            switch (type)
            {
                case "lg":
                    if (isVisible)
                    {
                        BodySidebarLgClass = "sidebar-lg-show";
                    }
                    else
                    {
                        BodySidebarLgClass = "";
                    }
                    break;
                default:
                    if (isVisible)
                    {
                        BodySidebarClass = "sidebar-show";
                    }
                    else
                    {
                        BodySidebarClass = "";
                    }
                    break;
            }

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
    #endregion


}
