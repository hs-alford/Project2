using Project2.Data;
using Project2.Models;
using Project2.Repositories.Interfaces;

namespace Project2.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MenuItem CreateMenuItem(MenuItem menuItem)
        {
            var result = _context.MenuItems.Add(menuItem);
            _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteMenuItemById(string id)
        {
            var menuItem = _context.MenuItems.FirstOrDefault(u => u.MenuItemId == id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                _context.SaveChangesAsync();
            }
        }

        public MenuItem GetMenuItemById(string id)
        {
            return _context.MenuItems.FirstOrDefault(u => u.MenuItemId == id);
        }

        public List<MenuItem> GetMenuItems()
        {
            return _context.MenuItems.ToList();
        }

        public MenuItem UpdateMenuItem(MenuItem menuItem)
        {
            var result = _context.MenuItems
                .FirstOrDefault(e => e.MenuItemId == e.MenuItemId);

            if (result != null)
            {
                result.Description = menuItem.Description;
                result.Type = menuItem.Type;
                result.Name = menuItem.Name;
                result.Order = menuItem.Order;
                result.Color = menuItem.Color;
                result.Parent = menuItem.Parent;
                result.Controller = menuItem.Controller;
                result.Action = menuItem.Action;
                result.Enabled = menuItem.Enabled;
                result.SecurityID = menuItem.SecurityID;
                result.Icon = menuItem.Icon;
                result.Dashboard = menuItem.Dashboard;
                result.Customization = menuItem.Customization;
                result.Report = menuItem.Report;

                _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public List<MenuItem> GetMainMenu()
        {
            return _context.MenuItems.Where(u => u.Parent == "0000").ToList();
        }

        public List<MenuItem> GetChildMenuItems(string id)
        {
            return _context.MenuItems.Where(u => u.Parent == id).OrderBy(u => u.Order).ToList();
        }

        public bool IsParentMenu(MenuItem menuItem)
        {
            return menuItem.Type == "Parent";
        }

        public bool HasParentMenu(MenuItem menuItem)
        {
            return menuItem.Parent != "0000";
        }


        public Stack<MenuItem> BuildNavMenu(MenuItem menuItem)
        {
            Stack<MenuItem> stack = new Stack<MenuItem>();
            stack.Push(menuItem);
            MenuItem smenu = menuItem;
            while (smenu.Parent != "0000")
            {
                smenu = _context.MenuItems.Where(u => u.MenuItemId == smenu.Parent).FirstOrDefault();
                stack.Push(smenu);
            }
            return stack;
        }
    }
}
