namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models.Burgers;
using WebApi.Services;

/**
 * API Controller for the burgers
 * Contains the following functionality :
 *      -Add a burger
 *      -Update a burger 
 *      -Update burger's score
 *      -Delete a burger (by id)
 *      -Get all burgers (one option returns without score details, the other with)
 *      -Get a burger (by id) (one option returns without score details, the other with)
 */
[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BurgersController : ControllerBase
    {

    /**
     * An instance of the burger service provided by dependency injection
     */
    private readonly IBurgerService _burgerService;

    public BurgersController(IBurgerService burgerService)
    {
        _burgerService = burgerService;
    }

    /**
     * A POST (add) function, which is called when the endpoint is accessed: /Burgers/add-burger
     * Uses the burgerService to add the Burger specified in the AddBurgerRequest model
     * Returns an object of BurgerResponse type
     */
    [Authorize(Role.Admin)]
    [HttpPost("add-burger")]
    public ActionResult<BurgerResponse> AddBurger(AddBurgerRequest model)
    {
        var response = _burgerService.Add(model);
        return Ok(response);
    }

    /**
     * A PUT (update) function, which is called when the endpoint is accessed: /Burgers/update-burger
     * Uses the burgerService to update the Burger specified in the UpdateBurgerRequest model
     * Returns an object of BurgarResponse type
     */
    [Authorize(Role.Admin)]
    [HttpPut("update-burger")]
    public ActionResult<BurgerResponse> UpdateBurger(int id, UpdateBurgerRequest model)
    {
        var response = _burgerService.Update(id, model);
        return Ok(response);
    }

    /**
     * A PUT (update) function, which is called when the endpoint is accessed: /Burgers/update-burger-score
     * Uses the burgerService to update the Burger score specified in the UpdateBurgerScoreRequest model
     * Returns an object of BurgerScoreResponse type
     */
    [Authorize(Role.Admin)]
    [HttpPut("update-burger-score")]
    public ActionResult<BurgerScoreResponse> UpdateBurgerScore(int id, UpdateBurgerScoreRequest model)
    {
        var response = _burgerService.Update(id, model);
        return Ok(response);
    }

    /**
     * A GET function, which is called when the endpoint is accessed: /Burgers
     * Uses the burgerService to retrieve all Burgers from the database with ScoreIds
     * Returns a list of objects of type BurgerResponse
     */
    [HttpGet]
    public ActionResult<IEnumerable<BurgerResponse>> GetAll()
    {
        var response = _burgerService.GetAll();
        return Ok(response);
    }

    /**
     * A GET function, which is called when the endpoint is accessed: /Burgers/get-all-detailed
     * Uses the burgerService to retrieve all Burgers from the database with Score details
     * Returns a list of objects of type BurgerScoreResponse
     */
    [HttpGet("get-all-detailed")]
    public ActionResult<BurgerScoreResponse> GetDetailedById()
    {
        var response = _burgerService.GetAllDetailed();
        return Ok(response);
    }

    /**
     * A GET function, which is called when the endpoint is accessed: /Burgers/{id}, where {id} is replaced with the id number
     * Uses the burgerService to retrieve the specific Burger from the database with ScoreId
     * Returns an object of type BurgerResponse
     */
    [HttpGet("{id}")]
    public ActionResult<BurgerResponse> GetById(int id)
    {
        var response = _burgerService.GetById(id);
        return Ok(response);
    }

    /**
     * A GET function, which is called when the endpoint is accessed: /Burgers/get-detailed/{id}, where {id} is replaced with the id number
     * Uses the burgerService to retrieve the specific Burger place from the database with Score details
     * Returns an object of type BurgerScoreResponse
     */
    [HttpGet("get-detailed/{id}")]
    public ActionResult<BurgerScoreResponse> GetByIdDetailed(int id)
    {
        var response = _burgerService.GetByIdDetailed(id);
        return Ok(response);
    }

    /**
     * A DELETE function, which is called when the endpoint is accessed: /Burgers/{id}, where {id} is replaced with the id number
     * Uses the burgerPlaceService to delete the specific Burger from the database
     * Returns a message that the operation has been executed successfully
     */
    [Authorize(Role.Admin)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _burgerService.Delete(id);
        return Ok(new { message = "Burger deleted successfully" });
    }
}
