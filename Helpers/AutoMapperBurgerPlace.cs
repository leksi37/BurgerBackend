namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Accounts;
using WebApi.Models.BurgerPlaces;

public class AutoMapperBurgerPlace : Profile
{
    // mappings between model and entity objects
    public AutoMapperBurgerPlace()
    {
        CreateMap<BurgerPlace, BurgerPlaceResponse>();

        CreateMap<AddBurgerPlaceRequest, BurgerPlace>();

        CreateMap<UpdateBurgerPlaceRequest, BurgerPlace>().ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        CreateMap<UpdateBurgerPlaceScoreRequest, BurgerPlace>().ForAllMembers(x => x.Condition(
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