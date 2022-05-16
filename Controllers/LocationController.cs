namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Location;
using WebApi.Services;

    /**
     * API Controller for locations
     * Contains the following functionality :
     *      -Find nearby burger locations
     */
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

    /**
     * An instance of the location service provided by dependency injection
     */
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }


    /**
     * A POST function, which is called when the endpoint is accessed: /Location/get-nearby-burger-places
     * Uses the locationService and Google Maps API to retrieve nearby burger places for the given location
     * Should return a list of LocationResponce objects, containing Name, Address and Opening hours
     */
    [HttpPost("get-nearby-burger-places")]
    public ActionResult<IEnumerable<LocationResponse>> GetAll(LocationRequest locationRequest)
    {
        var response = _locationService.GetNearbyBurgerPlaces(locationRequest);
        return Ok(response);
    }
}
