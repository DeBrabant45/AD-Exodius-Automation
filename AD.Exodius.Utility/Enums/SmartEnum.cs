using AD.Exodius.Utility.XunitExtensions;
using System.Collections.Concurrent;
using System.Reflection;

namespace AD.Exodius.Utility.Enums;

public abstract class SmartEnum<TEnum> : XunitSerialization, ISmartEnum
    where TEnum : SmartEnum<TEnum>, ISmartEnum
{
    private static readonly ConcurrentDictionary<int, TEnum> _smartEnums = new();
    private static int _nextId = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartEnum{TEnum}"/> class.
    /// This parameterless constructor is required for xUnit serialization.
    /// </summary>
    /// <remarks>
    /// xUnit uses this constructor during deserialization to create an instance of the class without needing to know
    /// the specific parameters required for instantiation. This ensures that the test framework can properly
    /// serialize and deserialize test data objects that are derived from this class, particularly for scenarios
    /// involving data-driven tests.
    /// </remarks>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SmartEnum() { }
#pragma warning restore CS8618

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartEnum{TEnum}"/> class with a specific identifier and name.
    /// Registers the instance with the internal dictionary to make it available for lookups and enumeration.
    /// </summary>
    /// <param name="id">The unique identifier of the smart enum item.</param>
    /// <param name="name">The name of the smart enum item.</param>
    /// <exception cref="InvalidOperationException">Thrown if the instance cannot be cast to the specified type <typeparamref name="TEnum"/>.</exception>
    protected SmartEnum(string name)
    {
        Id = _nextId++;
        Name = name;
        Register(this as TEnum);
    }

    public int Id { get; init; }

    public string Name { get; init; }

    /// <summary>
    /// Gets the internal dictionary of registered smart enum items.
    /// If the dictionary is empty, it will call <see cref="RegisterAll"/> to register all items.
    /// This property is designed as a fail-safe mechanism to ensure all enum items are registered properly,
    /// particularly due to the behavior of xUnit serialization which may instantiate types in a way that
    /// bypasses the expected initialization process.
    /// </summary>
    /// <remarks>
    /// This property ensures that all smart enum items are registered and available for lookups.
    /// It uses locking to ensure thread safety when accessing or modifying the internal dictionary.
    /// </remarks>
    private static ConcurrentDictionary<int, TEnum> SmartEnums
    {
        get
        {
            lock (_smartEnums)
            {
                if (_smartEnums.Count == 0)
                    RegisterAll();

                return _smartEnums;
            }
        }
    }

    /// <summary>
    /// Registers all public static fields of the derived enum type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <remarks>
    /// This method uses reflection to iterate through all public static fields of the type <typeparamref name="TEnum"/>. 
    /// Each field is expected to represent a unique instance of the derived enum type. These instances are then registered 
    /// in the internal dictionary to make them available for lookup and enumeration.
    /// </remarks>
    protected static void RegisterAll()
    {
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            if (field.GetValue(null) is TEnum smartEnum)
            {
                Register(smartEnum);
            }
        }
    }

    /// <summary>
    /// Registers the enum item in the internal dictionary.
    /// </summary>
    /// <param name="smartEnum">The enum item to register.</param>
    /// <returns>The registered enum item.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="smartEnum"/> is null.</exception>
    /// <remarks>
    /// If an item with the same identifier is already registered, it is returned from the dictionary.
    /// Otherwise, the item is added to the dictionary.
    /// </remarks>
    protected static TEnum Register(TEnum? smartEnum)
    {
        ArgumentNullException.ThrowIfNull(smartEnum, nameof(smartEnum));

        if (SmartEnums.TryGetValue(smartEnum.Id, out var existingSmartEnum))
            return existingSmartEnum;

        return SmartEnums.GetOrAdd(smartEnum.Id, smartEnum);
    }


    /// <summary>
    /// Retrieves the enum item associated with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the enum item.</param>
    /// <returns>The enum item associated with the specified identifier.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the identifier is not found.</exception>
    public static TEnum FromId(int id)
    {
        return SmartEnums[id];
    }

    /// <summary>
    /// Tries to retrieve the enum item associated with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the enum item.</param>
    /// <param name="result">The enum item associated with the specified identifier, if found.</param>
    /// <returns>True if the identifier is found; otherwise, false.</returns>
    public static bool TryFromId(int id, out TEnum? result)
    {
        return SmartEnums.TryGetValue(id, out result);
    }

    /// <summary>
    /// Returns all enum items.
    /// </summary>
    /// <returns>An enumerable collection of all enum items.</returns>
    public static IEnumerable<TEnum> GetAll()
    {
        return SmartEnums.Values;
    }

    /// <summary>
    /// Finds a smart enum item by its name.
    /// </summary>
    /// <param name="name">The name of the smart enum item.</param>
    /// <returns>The smart enum item with the specified name.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no item with the specified name is found.</exception>
    public static TEnum FromName(string name)
    {
        foreach (var smartEnum in SmartEnums.Values)
        {
            if (smartEnum.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                return smartEnum;
        }

        throw new KeyNotFoundException($"No {typeof(TEnum).Name} with name '{name}' found.");
    }

    /// <summary>
    /// Returns a string representation of the enum item.
    /// </summary>
    /// <returns>The name of the enum item.</returns>
    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is SmartEnum<TEnum> other)
            return Id == other.Id;

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(SmartEnum<TEnum>? left, SmartEnum<TEnum>? right)
    {
        if (ReferenceEquals(left, right)) 
            return true;

        if (left is null || right is null) 
            return false;

        return left.Id == right.Id;
    }

    public static bool operator !=(SmartEnum<TEnum>? left, SmartEnum<TEnum>? right)
    {
        return !(left == right);
    }
}
