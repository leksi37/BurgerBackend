namespace WebApi.Services;

using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.BurgerPlaces;

/**
 * An interface for the BurgerPlaceService to add level of abstraction and have access only to relative information
 */
public interface IBurgerPlaceService
{
    IEnumerable<BurgerPlaceResponse> GetAll();
    BurgerPlaceResponse GetById(int id);
    BurgerPlaceResponse Add(AddBurgerPlaceRequest model);
    BurgerPlaceResponse Update(int id, UpdateBurgerPlaceRequest model);
    BurgerPlaceResponse Update(int id, UpdateBurgerPlaceScoreRequest model);
    void Delete(int id);
}

/** 
 * A Service that manages the CRUD operations of the Burger places in the database
 */
public class BurgerPlaceService : IBurgerPlaceService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BurgerPlaceService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /**
     * Get and return all burger places from the database
     * */
    public IEnumerable<BurgerPlaceResponse> GetAll()
    {
        var burgerPlaces = _context.BurgerPlaces;
        return _mapper.Map<IList<BurgerPlaceResponse>>(burgerPlaces);
    }

    /**
     * Get and return burger place by id from the database
     * */
    public BurgerPlaceResponse GetById(int id)
    {
        var burgerPlace = GetBurgerPlaceById(id);
        
        return _mapper.Map<BurgerPlaceResponse>(burgerPlace);
    }

    /**
     * Add a new burger place to the database
     * First check if a Burger place with the given name and address exists
     * */
    public BurgerPlaceResponse Add(AddBurgerPlaceRequest model)
    {
        // validate that place is not registered
        if (_context.BurgerPlaces.Any(x => x.Name == model.Name && x.Address == model.Address))
            throw new AppException($"'{model.Name}' on the following address '{model.Address}' is already registered");

        // map model to new urger place object and set score to 0
        var burgerPlace = _mapper.Map<BurgerPlace>(model);
        burgerPlace.OverallScore = 0.0;

        // save burger place
        _context.BurgerPlaces.Add(burgerPlace);
        _context.SaveChanges();

        return _mapper.Map<BurgerPlaceResponse>(burgerPlace);
    }

    /**
     * Update a specific burger place (by provided id)
     * First check if anything is changed, if nothing is changed do not update the database
     * */
    public BurgerPlaceResponse Update(int id, UpdateBurgerPlaceRequest model)
    {
        var burgerPlace = GetBurgerPlaceById(id);

        // validate
        if ((burgerPlace.Name == model.Name && burgerPlace.Address == model.Address) && _context.BurgerPlaces.Any(x => x.Id == model.Id))
            throw new AppException($"Nothing to change or a place with this Id '{model.Id}' doesn't exist");

        // copy model to account and save
        _mapper.Map(model, burgerPlace);
        _context.BurgerPlaces.Update(burgerPlace);
        _context.SaveChanges();

        return _mapper.Map<BurgerPlaceResponse>(burgerPlace);
    }

    /**
     * Update a burger place's score
     * First check if anything is changed, if nothing is changed do not update the database
     * */
    public BurgerPlaceResponse Update(int id, UpdateBurgerPlaceScoreRequest model)
    {
        var burgerPlace = GetBurgerPlaceById(id);

        // validate
        if ((burgerPlace.OverallScore == model.OverallScore) && _context.BurgerPlaces.Any(x => x.Id == model.Id))
            throw new AppException($"Score is the same or a place with this Id '{model.Id}' doesn't exist");

        // copy model to account and save
        _mapper.Map(model, burgerPlace);
        _context.BurgerPlaces.Update(burgerPlace);
        _context.SaveChanges();

        return _mapper.Map<BurgerPlaceResponse>(burgerPlace);
    }

    /**
     * Get a specific burger place (by provided id)
     * First check if the id is valid
     * Internal method
     * */
    private BurgerPlace GetBurgerPlaceById(int id)
    {
        var burgerPlace = _context.BurgerPlaces.Find(id);
        if (burgerPlace == null) throw new KeyNotFoundException("Burger place not found");
        return burgerPlace;
    }

    /**
     * Delete a specific burger place (by provided id)
     * First check if a burger place with the provided id exists
     * */
    public void Delete(int id)
    {
        // validate
        if (!_context.BurgerPlaces.Any(x => x.Id == id))
            throw new AppException($"A place with Id = {id} doesn't exist");

        var burgerPlace = _context.BurgerPlaces.Find(id);

        // delete model and save changes
        _context.BurgerPlaces.Remove(burgerPlace);
        _context.SaveChanges();
    }
}