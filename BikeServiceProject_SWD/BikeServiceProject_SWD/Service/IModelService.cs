namespace BikeServiceProject_SWD.Service;
using AutoMapper;
using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Models;

public interface IModelService
{
    IEnumerable<Model> GetAll();
    Model GetById(int id);
    void Create(Model model);
    void Update(int id, Model model);
    void Delete(int id);
}

public class ModelService : IModelService
{

    private readonly MyDbContext _context;
    private readonly IMapper _mapper;

    public ModelService(IMapper mapper, MyDbContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(Model model)
    {
        _context.Models.Add(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var model = getModelId(id);
        _context.Models.Remove(model);
        _context.SaveChanges();
    }

    public IEnumerable<Model> GetAll()
    {
        return _context.Models;
    }

    public Model GetById(int id)
    {
        return getModelId(id);
    }

    public void Update(int id, Model model)
    {
        var modelId = getModelId;
        _mapper.Map(model, modelId);
        _context.Update(model);
        _context.SaveChanges();
    }


    // helper methods

    private Model getModelId(int id)
    {
        var model = _context.Models.Find(id);
        if (model == null) throw new KeyNotFoundException("Model not found");
        return model;
    }
}

