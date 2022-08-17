using AutoMapper;
using Dapper_NOMiNiApi.DAL;
using Dapper_NOMiNiApi.Entity;
using Dapper_NOMiNiApi.Models;

namespace Dapper_NOMiNiApi.Services
{
    public class MenuService : IMenuService
    {
        private readonly BaseMenuDAL _menuDAL;
        private readonly IMapper _mapper;
        public MenuService(BaseMenuDAL baseMenuDAL,IMapper mapper)
        {
            _menuDAL = baseMenuDAL;
            _mapper = mapper;
        }
        public List<Models.Route> GetMenus() {
            var menuModels = _mapper.Map<List<MenuEntity>,List<MenuModel>>(_menuDAL.GetAll().ToList());
            List<Models.Route> result = new List<Models.Route>();
            foreach (var menuModel in menuModels)
            {
                result.Add(new Models.Route()
                {
                    Path = menuModel.Path,
                    Name = menuModel.Path,
                    Meta = new Meta() { Title = menuModel.Title, Icon = menuModel.Icon, IsShow = menuModel.IsShow }
                });
            }
            return result;
        }
    }
}
