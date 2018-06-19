using Q.Entities;
using System.Collections.Generic;

namespace Q.API.Models
{
    public class MenuModel : BaseModel
    {
        public string Caption { get; set; }

        public string Route { get; set; }

        public bool HasChildren { get; set; }

        public List<MenuModel> Childrens { get; set; }

        public string ClassName { get; set; }

        public string IconName { get; set; }

        public bool IsVisible { get; set; }

        public int SortOrder { get; set; }

        public int? ParentId { get; set; }

        public int MenuGroupId { get; set; }

        public static MenuModel ReturnMenuModel(MenuItem menuItem)
        {
            return new MenuModel
            {
                Id = menuItem.Id,
                Caption = menuItem.Caption,
                IsVisible = menuItem.IsVisible,
                Route = menuItem.Route,
                IconName = menuItem.IconName,
                Childrens = menuItem.HasChildren ? GetChildMenu(menuItem) : null,
                HasChildren = menuItem.HasChildren,
                SortOrder = menuItem.SortOrder,
                ParentId = menuItem.ParentId
            };
        }

        private static List<MenuModel> GetChildMenu(MenuItem menuItem)
        {
            var childMenu = new List<MenuModel>();
            foreach (var item in menuItem.Children)
            {
                childMenu.Add(new MenuModel
                {
                    Id = item.Id,
                    Caption = item.Caption,
                    IsVisible = item.IsVisible,
                    Route = item.Route,
                    IconName = item.IconName,
                    ParentId = item.ParentId,
                    HasChildren = item.HasChildren,
                    SortOrder = item.SortOrder,
                    Childrens = item.HasChildren ? GetChildMenu(item) : null
                });
            }
            return childMenu;
        }

        public static MenuItem ReturnMenuItem(MenuModel menuModel)
        {
            return new MenuItem
            {
                Id = menuModel.Id,
                Caption = menuModel.Caption,
                IsVisible = menuModel.IsVisible,
                Route = menuModel.Route,
                IconName = menuModel.IconName,
                HasChildren = menuModel.HasChildren,
                MenuGroupId = menuModel.MenuGroupId,
                SortOrder = menuModel.SortOrder,
                ParentId = menuModel.ParentId
            };
        }

        private static List<MenuItem> GetChildMenuItems(MenuModel menuModel)
        {
            var childMenu = new List<MenuItem>();
            //foreach (var item in menuModel.Childrens)
            //{
            //    childMenu.Add(new MenuItem
            //    {
            //        Id = item.Id,
            //        Caption = item.Caption,
            //        IsVisible = item.IsVisible,
            //        Route = item.Route,
            //        IconName = item.IconName,
            //        ParentId = menuModel.Id,
            //        HasChildren = item.HasChildren,
            //        Childrens = item.HasChildren ? GetChildMenuItems(item) : null
            //    });
            //}
            return childMenu;
        }
    }
}
