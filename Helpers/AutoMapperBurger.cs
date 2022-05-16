namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Accounts;
using WebApi.Models.Burgers;

public class AutoMapperBurger : Profile
{
    // mappings between model and entity objects
    public AutoMapperBurger()
    {
        CreateMap<Burger, BurgerResponse>();

        CreateMap<AddBurgerRequest, Burger>();

        CreateMap<UpdateBurgerRequest, Burger>().ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        CreateMap<UpdateBurgerScoreRequest, Burger>().ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}