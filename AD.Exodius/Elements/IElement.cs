namespace AD.Exodius.Elements;

public interface IElement
{
    /// <summary>
    /// <para>
    ///     Returns the value for the matching <c>&lt;input&gt;</c> or <c>&lt;textarea&gt;</c>
    ///     or <c>&lt;select&gt;</c> Element.
    /// </para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task<string> GetValue();

    /// <summary>
    /// <para>
    ///     Returns the <a href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText"><c>Element.InnerText</c></a>.
    /// </para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task<string> GetText();

    /// <summary>
    /// Retrieves the text and converts it to the specified type.
    /// </summary>
    /// <typeparam name="TPrimitive">The type to which the text should be converted.</typeparam>
    /// <returns>
    /// A <typeparamref name="TPrimitive"/> representing the converted text.
    /// </returns>
    /// <remarks>
    /// This method asynchronously retrieves the raw text and converts it to the specified primitive type using 
    /// the <see cref="ConvertToType{TPrimitive}(string)"/> method.
    /// </remarks>
    public Task<TPrimitive> GetTextAsType<TPrimitive>();

    /// <summary>
    /// <para>
    ///     Looks for the <a href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText"><c>Element.InnerText</c></a>.
    /// </para>
    /// <para> Will return empty string if Element.InnerText could not be found.</para>
    /// </summary>
    /// <returns></returns>
    /// <param name="options">Call options</param>
    public Task<string> FindText();

    /// <summary>
    /// Finds the text and converts it to the specified type.
    /// </summary>
    /// <typeparam name="TPrimitive">The type to which the text should be converted.</typeparam>
    /// <returns>
    /// A <typeparamref name="TPrimitive"/> representing the converted text.
    /// </returns>
    /// <remarks>
    /// This method asynchronously finds the raw text and converts it to the specified primitive type using 
    /// the <see cref="ConvertToType{TPrimitive}(string)"/> method.
    /// </remarks>
    public Task<TPrimitive> FindTextAsType<TPrimitive>();

    /// <summary>
    /// <para>Extracts and returns only the numeric text within the <a href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText"><c>Element.InnerText</c></a>.</para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task<string> GetNumericText();

    /// <summary>
    /// <para> Looks for the <a href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText"><c>Element.InnerText</c></a> while extracting and returning only the numeric text within it.
    /// </para>
    /// <para> Will return empty string if Element.InnerText could not be found.</para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task<string> FindNumericText();

    /// <summary>
    /// <para>Returns whether the element is enabled</a>.</para>
    /// </summary>
    public Task<bool> IsEnabled();

    /// <summary><para>Returns the matching element's attribute value.</para></summary>
    /// <param name="name">Attribute name to get the value for.</param>
    /// <param name="options">Call options</param>
    public Task<bool> IsAttributePresent(string attribute, string value);

    /// <summary>
    /// <para>Returns whether the element is visible.</para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task<bool> IsVisible();

    /// <summary>
    /// <para>Returns whether the element is hidden.</para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task<bool> IsHidden();

    /// <summary>
    /// <para>
    /// Calls <a href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/focus">focus</a>
    /// on the matching element.
    /// </para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task Focus();

    /// <summary>
    /// <para>Hover over the matching element.</para>
    /// <para>This method hovers over the element by performing the following steps:</para>
    /// <list type="ordinal">
    /// <item><description> Wait for actionability checks on the element.</description></item>
    /// <item><description>Scroll the element into view if needed.</description></item>
    /// </list>
    /// <para>If the element is detached from the DOM at any moment during the action, this method throws.</para>
    /// <para>
    /// When all steps combined have not finished during the specified <paramref name="timeout"/>,
    /// this method throws a <see cref="TimeoutException"/>. Passing zero timeout disables
    /// this.
    /// </para>
    /// </summary>
    /// <param name="options">Call options</param>
    public Task Hover();

    /// <summary>
    /// Waits asynchronously until the element is visible within the specified timeout period. An error will be thrown if the element does not become visible.
    /// </summary>
    /// <param name="timeout">The maximum time to wait for the element to become visible, in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task WaitUntilVisible(float timeout = 30f);

    /// <summary>
    /// Waits asynchronously until the element is hidden within the specified timeout period. An error will be thrown if the element remains visible.
    /// </summary>
    /// <param name="timeout">The maximum time to wait for the element to become hidden, in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task WaitUntilHidden(float timeout = 30f);

    /// <summary>
    /// Waits asynchronously until the element is visible within the specified timeout period. No error will be thrown if the element does not become visible.
    /// </summary>
    /// <param name="timeout">The maximum time to wait for the element to become visible, in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task WaitUntilVisibleNoException(float timeout = 30f);

    /// <summary>
    /// Waits asynchronously until the element is hidden within the specified timeout period. No error will be thrown if the element remains visible.
    /// </summary>
    /// <param name="timeout">The maximum time to wait for the element to become hidden, in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task WaitUntilHiddenNoException(float timeout = 30f);
}
