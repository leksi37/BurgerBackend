namespace WebApi.Services;
using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Burgers;

/**
 * An interface for the BurgerService to add level of abstraction and have access only to relative information
 */
public interface IBurgerService
{
    IEnumerable<BurgerResponse> GetAll();
    IEnumerable<BurgerScoreResponse> GetAllDetailed();
    BurgerResponse GetById(int id);
    BurgerScoreResponse GetByIdDetailed(int id);
    BurgerResponse Add(AddBurgerRequest model);
    BurgerResponse Update(int id, UpdateBurgerRequest model);
    BurgerScoreResponse Update(int id, UpdateBurgerScoreRequest model);
    void Delete(int id);
}

/** 
 * A Service that manages the CRUD operations of the Burgers in the database
 */
public class BurgerService : IBurgerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BurgerService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public BurgerResponse Add(AddBurgerRequest model)
    {
        // validate if that burger is not already added
        if (_context.Burgers.Any(x => x.Name == model.Name && x.BurgerPlaceId == model.BurgerPlaceId))
            throw new AppException($"'{model.Name}' burger in place with id '{model.BurgerPlaceId}' is already added");

        // map model to new burger object and set score to 0
        var burger = _mapper.Map<Burger>(model);
        var score = new Score { OverallScore = 0.0, TasteScore = 0.0, TextureScore = 0.0, VisualScore = 0.0 };
        var scoreInfo = _context.Scores.Add(score);
        _context.SaveChanges();
        burger.ScoreId = score.Id;

        // save burger place
        _context.Burgers.Add(burger);
        _context.SaveChanges();

        return _mapper.Map<BurgerResponse>(burger);
    }

    public void Delete(int id)
    {
        // validate
        if (!_context.Burgers.Any(x => x.Id == id))
            throw new AppException($"A burger with Id = {id} doesn't exist");

        var burger = _context.Burgers.Find(id);

        // delete model and save changes
        _context.Burgers.Remove(burger);
        _context.SaveChanges();
    }


    public IEnumerable<BurgerResponse> GetAll()
    {
        var burgers = _context.Burgers;
        return _mapper.Map<IList<BurgerResponse>>(burgers);
    }

    public IEnumerable<BurgerScoreResponse> GetAllDetailed()
    {
        var burgers = _context.Burgers;
        var burgerList = new List<BurgerScoreResponse>();
        for(int i = 0; i < burgers.Count(); i++)
        {
            var currentBurger = burgers.ToList()[i];
            var currentScore = _context.Scores.Find(currentBurger.ScoreId);
            burgerList.Add(MapToBurgerScoreResponse(currentBurger, currentScore));
        }
        return burgerList;
    }

    public BurgerResponse GetById(int id)
    {
        var burger = GetBurgerById(id);

        return _mapper.Map<BurgerResponse>(burger);
    }

    public Burger GetBurgerById(int id)
    {
        var burger = _context.Burgers.Find(id);
        if (burger == null) throw new KeyNotFoundException("Burger not found");
        return burger;
    }

    public BurgerScoreResponse GetByIdDetailed(int id)
    {
        var burger = GetBurgerById(id);

        // validate
        if (!_context.Burgers.Any(x => x.Id == id))
            throw new AppException($"A burger with this Id '{id}' doesn't exist");

        var score = _context.Scores.Find(burger.ScoreId);
        if (score == null) throw new KeyNotFoundException("Score not found");

        return MapToBurgerScoreResponse(burger, score);
    }

    public BurgerScoreResponse Update(int id, UpdateBurgerScoreRequest model)
    {
        var burger = GetBurgerById(id);

        // validate
        if (!_context.Burgers.Any(x => x.Id == model.Id))
            throw new AppException($"A burger with this Id '{model.Id}' doesn't exist");

        var score = _context.Scores.Find(burger.ScoreId);
        if (score == null) throw new KeyNotFoundException("Score not found");
        score.TextureScore = model.TextureScore;
        score.TasteScore = model.TasteScore;
        score.VisualScore = model.VisualScore;
        score.OverallScore = Math.Round((model.VisualScore + model.TextureScore + model.TasteScore) / 3, 2);

        // save score changes
        _context.Scores.Update(score);
        _context.SaveChanges();

        return MapToBurgerScoreResponse(burger, score);
    }

    public BurgerResponse Update(int id, UpdateBurgerRequest model)
    {
        var burger = GetBurgerById(id);

        // validate
        if (!_context.Burgers.Any(x => x.Id == model.Id))
            throw new AppException($"A burger with this Id '{model.Id}' doesn't exist");

        // copy model to account and save
        _mapper.Map(model, burger);
        _context.Burgers.Update(burger);
        _context.SaveChanges();

        return _mapper.Map<BurgerResponse>(burger);
    }

    private BurgerScoreResponse MapToBurgerScoreResponse(Burger burger, Score score)
    {
        return new BurgerScoreResponse
        {
            Id = burger.Id,
            BurgerPlaceId = burger.BurgerPlaceId,
            Description = burger.Description,
            Name = burger.Name,
            Price = burger.Price,
            VisualScore = score.VisualScore,
            TextureScore = score.TextureScore,
            TasteScore = score.TasteScore,
            OverallScore = score.OverallScore
        };
    }
}

