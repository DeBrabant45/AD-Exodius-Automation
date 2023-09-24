namespace AD.Exodius.Driver;

public class ApiDriver
{
    private readonly IPlaywright _playwright;
    private readonly IAPIRequestContext _context;

    public ApiDriver()
    {
        _playwright = Playwright.CreateAsync().Result;
        _context = _playwright.APIRequest.NewContextAsync().Result;
    }

    public async Task<IAPIResponse?> GetApiResponse(string url)
    {
        return await _context.GetAsync(url);
    }

    public async Task PostApiRequest(string url, Dictionary<string, object> values)
    {
        await _context.PostAsync(url, new APIRequestContextOptions
        {
            Params = values
        });
    }

    public async Task PutApiRequest(string url, Dictionary<string, object> values)
    {
        await _context.PutAsync(url, new APIRequestContextOptions
        {
            Params = values
        });
    }

    public async Task DeleteApiRequest(string url, Dictionary<string, object> values)
    {
        await _context.DeleteAsync(url, new APIRequestContextOptions
        {
            Params = values
        });
    }
}