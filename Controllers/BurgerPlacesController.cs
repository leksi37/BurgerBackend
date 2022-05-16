namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.BurgerPlaces;
using WebApi.Services;

/**
 * API Controller for the burger places
 * Contains the following functionality :
 *      -Add Burger place
 *      -Update Burger place
 *      -Update Burger place score
 *      -Delete a Burger place (by id)
 *      -Get all Burger places
 *      -Get a Burger place (by id)
 */
[Authorize]
[ApiController]
[Route("[controller]")]
public class BurgerPlacesController: BaseController
{
    /**
     * An instance of the burger place service provided by dependency injection
     */ 
    private readonly IBurgerPlaceService _burgerPlaceService;

    public BurgerPlacesController(IBurgerPlaceService burgerPlaceService)
    {
        _burgerPlaceService = burgerPlaceService;
    }

    /**
     * A POST (add) function, which is called when the endpoint is accessed: /BurgerPlaces/add-burger-place
     * Uses the burgerPlaceService to add the Burger place specified in the AddBurgerPlaceRequest model
     */
    [Authorize(Role.Admin)]
    [HttpPost("add-burger-place")]
    public ActionResult<BurgerPlaceResponse> AddBurgerPlace(AddBurgerPlaceRequest model)
    {
        var response = _burgerPlaceService.Add(model);
        return Ok(response);
    }

    /**
     * A PUT (update) function, which is called when the endpoint is accessed: /BurgerPlaces/update-burger-place
     * Uses the burgerPlaceService to update the Burger place specified in the UpdateBurgerPlaceRequest model
     * Returns an instance of BurgarPlaceResponse
     */
    [Authorize(Role.Admin)]
    [HttpPut("update-burger-place")]
    public ActionResult<BurgerPlaceResponse> UpdateBurgerPlace(int id, UpdateBurgerPlaceRequest model)
    {
        var response = _burgerPlaceService.Update(id, model);
        return Ok(response);
    }

    /**
     * A PUT (update) function, which is called when the endpoint is accessed: /BurgerPlaces/update-burger-place-score
     * Uses the burgerPlaceService to update the Burger place score specified in the UpdateBurgerPlaceScoreRequest model
     * Returns an object of BurgerPlaceResponse type
     */
    [Authorize(Role.Admin)]
    [HttpPut("update-burger-place-score")]
    public ActionResult<BurgerPlaceResponse> UpdateBurgerPlace(int id, UpdateBurgerPlaceScoreRequest model)
    {
        var response = _burgerPlaceService.Update(id, model);
        return Ok(response);
    }

    /**
     * A GET function, which is called when the endpoint is accessed: /BurgerPlaces
     * Uses the burgerPlaceService to retrieve all Burger places from the database
     * Returns a list with objects of type BurgerPlaceResponse
     */
    [HttpGet]
    public ActionResult<IEnumerable<BurgerPlaceResponse>> GetAll()
    {
        var response = _burgerPlaceService.GetAll();
        return Ok(response);
    }

    /**
     * A GET function, which is called when the endpoint is accessed: /BurgerPlaces/{id}, where {id} is replaced with the id number
     * Uses the burgerPlaceService to retrieve the specific Burger place from the database
     * Returns an object of type BurgerPlaceResponse
     */
    [HttpGet("{id}")]
    public ActionResult<BurgerPlaceResponse> GetById(int id)
    {
        var response = _burgerPlaceService.GetById(id);
        return Ok(response);
    }

    /**
     * A DELETE function, which is called when the endpoint is accessed: /BurgerPlaces/{id}, where {id} is replaced with the id number
     * Uses the burgerPlaceService to delete the specific Burger place from the database
     * Returns a message that the operation has been executed successfully
     */
    [Authorize(Role.Admin)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _burgerPlaceService.Delete(id);
        return Ok(new { message = "Burger place deleted successfully" });
    }
}
