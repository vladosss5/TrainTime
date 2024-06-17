using Microsoft.EntityFrameworkCore;
using TrainTiming.Application.Interfaces.IRepository;
using TrainTiming.Core.Models;
using TrainTiming.Persistence.Data.Context;

namespace TrainTiming.Persistence.Repositories;

public class TypesRepository : ITypesRepository
{
    private readonly DataContext _dataContext;
    
    public TypesRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TypeTrain> GetTypeByIdAsync(int id)
    {
        return await _dataContext.TypesTrains.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TypeTrain>> GetAllTypesAsync()
    {
        return await _dataContext.TypesTrains.ToListAsync();
    }

    public async Task<TypeTrain> CreateTypeAsync(TypeTrain typeTrain)
    {
        await _dataContext.TypesTrains.AddAsync(typeTrain);
        await _dataContext.SaveChangesAsync();
        
        return typeTrain;
    }

    public async Task<TypeTrain> UpdateTypeAsync(TypeTrain type)
    {
        _dataContext.TypesTrains.Update(type);
        await _dataContext.SaveChangesAsync();
        
        return type;
    }

    public async Task DeleteTypeAsync(TypeTrain type)
    {
        _dataContext.Remove(type);
        await _dataContext.SaveChangesAsync();
    }
}