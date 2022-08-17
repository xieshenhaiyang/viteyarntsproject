using Dapper_NOMiNiApi.Models;

namespace Dapper_NOMiNiApi.Services
{
    public interface IMenuService
    {
        List<Models.Route> GetMenus();
    }
}
