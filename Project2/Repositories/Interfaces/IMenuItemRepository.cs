using Project2.Models;

namespace Project2.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        List<MenuItem> GetMenuItems();
        MenuItem GetMenuItemById(string menuItemId);
        MenuItem CreateMenuItem(MenuItem menuItem);
        MenuItem UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItemById(string menuItemId);
        List<MenuItem> GetChildMenuItems(string id);
        List<MenuItem> GetMainMenu();
        Stack<MenuItem> BuildNavMenu(MenuItem menuItem);
        bool IsParentMenu(MenuItem menuItem);
        bool HasParentMenu(MenuItem menuItem);
    }
}
