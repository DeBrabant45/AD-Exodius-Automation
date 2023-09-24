namespace AD.Exodius.Driver;

public interface IStorageService
{
    public bool IsSessionStatePresent();
    public Task StoreSessionState();
}
