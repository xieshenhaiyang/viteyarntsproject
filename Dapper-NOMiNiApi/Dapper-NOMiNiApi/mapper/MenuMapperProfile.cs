using AutoMapper;
using Dapper_NOMiNiApi.Entity;
using Dapper_NOMiNiApi.Models;

namespace Dapper_NOMiNiApi.mapper
{
    public class MenuMapperProfile:Profile
    {
        public MenuMapperProfile()
        {
            CreateMap<MenuEntity, MenuModel>();
            CreateMap<MenuModel, MenuEntity>();
            //CreateMap<MenuModel, Models.Route>()
            //    .ForMember(d => d.Path, s => s.MapFrom(t => t.Path))
            //    .ForMember(d => d.Name, s => s.MapFrom(t => t.Name))
            //    .ForPath(d => d.Meta.Title, s => s.MapFrom(t => t.Title))
            //    .ForPath(d => d.Meta.IsShow, s => s.MapFrom(t => t.IsShow))
            //    .ForPath(d => d.Meta.Icon, s => s.MapFrom(t => t.Icon))
            //    ;
        }
    }
}
