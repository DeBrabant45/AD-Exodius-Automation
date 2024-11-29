namespace AD.Exodius.Elements;

public interface IInputElement<T>
{
    public Task TypeInput(T input);
    public Task VisibilityTypeInput(T input);
    public Task PressKey(KeyCode key);
}
