using Microsoft.Extensions.Configuration;
using TrainTiming.Application.Interfaces.IServices;

namespace TrainTiming.Persistence.Services;

public class AccountService : IAccountService
{
    static HttpClient client = new HttpClient();
    
    private readonly IConfiguration _configuration;
    
    public AccountService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<string> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}