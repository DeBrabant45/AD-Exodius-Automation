using Xunit.Abstractions;

namespace AD.Exodius.Utility.XunitExtensions;

public abstract class XunitSerialization : IXunitSerializable
{
    public void Deserialize(IXunitSerializationInfo info) => info.AutoDeserialize(this);

    public void Serialize(IXunitSerializationInfo info) => info.AutoSerialize(this);
}
