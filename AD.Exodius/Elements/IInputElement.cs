namespace AD.Exodius.Elements;

public interface IInputElement<T>
{
    public Task TypeInput(T input);
}
