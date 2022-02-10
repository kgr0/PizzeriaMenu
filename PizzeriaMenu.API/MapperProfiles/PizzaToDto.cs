using AutoMapper;
using PizzeriaMenu.API;
using PizzeriaMenu.Domain;

namespace PizzeriaMenu.API.MapperProfiles
{
    public class PizzaToDto : Profile
    {
        public PizzaToDto()
        {
            CreateMap<Ingredient, string>()
                .ConstructUsing(i => i.Name);
                
            CreateMap<Pizza, Dto.GetPizza>()
                .ForMember(p => p.Ingredients, opt => opt.MapFrom(x => x.Ingredients));
        }
    }
}
