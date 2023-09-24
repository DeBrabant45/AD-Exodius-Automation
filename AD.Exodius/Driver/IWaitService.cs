namespace AD.Exodius.Driver;

public interface IWaitService
{
    public Task WaitForDomContentLoaded();
    public Task WatiForTimeout(float timeout);
}
