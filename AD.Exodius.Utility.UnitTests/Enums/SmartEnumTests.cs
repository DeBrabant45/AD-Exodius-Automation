using AD.Exodius.Utility.Enums;

namespace AD.Exodius.Utility.UnitTests.Enums;

public class SmartEnumTests
{
    public class TestEnum : SmartEnum<TestEnum>
    {
        public static readonly TestEnum First = new (nameof(First));
        public static readonly TestEnum Second = new (nameof(Second));

        public TestEnum() { }

        private TestEnum(string name) : base(name) { }
    }

    [Fact]
    public void GetAll_Should_ReturnAllSmartEnums()
    {
        var smartEnums = TestEnum.GetAll();

        smartEnums.Should().Contain(TestEnum.First);
        smartEnums.Should().Contain(TestEnum.Second);
        smartEnums.Should().HaveCount(2);
    }

    [Fact]
    public void FromId_Should_ReturnCorrectItem()
    {
        var smartEnum = TestEnum.FromId(1);

        smartEnum.Should().Be(TestEnum.First);
    }

    [Fact]
    public void FromId_Should_ThrowException_ForInvalidId()
    {
        Action act = () => TestEnum.FromId(999);

        act.Should().Throw<KeyNotFoundException>();
    }

    [Fact]
    public void Name_Should_ReturnCorrectName()
    {
        var smartEnum = TestEnum.First;

        smartEnum.Name.Should().Be("First");
    }

    public static TheoryData<int, bool, TestEnum> GetTryFromIdTestData()
    {
        return new()
        {
            { 1, true, TestEnum.First },
            { 2, true, TestEnum.Second },
            { 999, false, null },
        };
    }

    [Theory]
    [MemberData(nameof(GetTryFromIdTestData))]
    protected void TryFromId_Should_ReturnExpectedResults(int id, bool expectedSuccess, TestEnum expectedEnum)
    {
        var success = TestEnum.TryFromId(id, out var smartEnum);

        success.Should().Be(expectedSuccess);
        smartEnum.Should().Be(expectedEnum);
    }

    public static TheoryData<string, TestEnum> FromNameTestData()
    {
        return new()
        {
            { "First", TestEnum.First },
            { "first", TestEnum.First },
            { "Second", TestEnum.Second },
        };
    }

    [Theory]
    [MemberData(nameof(FromNameTestData))]
    public void FromName_Should_ReturnExpectedSmartEnum(string name, TestEnum expectedEnum)
    {
        var smartEnum = TestEnum.FromName(name);

        smartEnum.Should().Be(expectedEnum);
    }

    public static TheoryData<string> FromNameExceptionTestData()
    {
        return new()
        { 
            { "NonExistent" },
            { "AnotherNonExistent" },
        };
    }

    [Theory]
    [MemberData(nameof(FromNameExceptionTestData))]
    public void FromName_Should_ThrowException(string name)
    {
        Action act = () => TestEnum.FromName(name);

        act.Should().Throw<KeyNotFoundException>()
           .WithMessage($"No TestEnum with name '{name}' found.");
    }

    [Fact]
    public void ToString_Should_ReturnName()
    {
        var firstSmatEnum = TestEnum.First.ToString();

        firstSmatEnum.Should().Be("First");
    }

    [Fact]
    public void EqualityOperator_Should_ReturnFalse_For_DifferentId()
    {
        var firstSmartEnum = TestEnum.First;
        var secondSmartEnum = TestEnum.Second;

        (firstSmartEnum == secondSmartEnum).Should().BeFalse();
    }

    [Fact]
    public void InequalityOperator_Should_ReturnTrue_For_DifferentId()
    {
        var firstSmartEnum = TestEnum.First;
        var secondSmartEnum = TestEnum.Second;

        (firstSmartEnum != secondSmartEnum).Should().BeTrue();
    }

    [Fact]
    public void Equals_Should_ReturnFalse_For_DifferentId()
    {
        var firstSmartEnum = TestEnum.First;
        var secondSmartEnum = TestEnum.Second;

        firstSmartEnum.Equals(secondSmartEnum).Should().BeFalse();
    }

    [Fact]
    public void Equals_Should_ReturnFalse_For_Null()
    {
        var firstSmartEnum = TestEnum.First;

        firstSmartEnum.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_Should_Return_DifferentValue_For_DifferentId()
    {
        var firstSmartEnum = TestEnum.First;
        var secondSmartEnum = TestEnum.Second;

        firstSmartEnum.GetHashCode().Should().NotBe(secondSmartEnum.GetHashCode());
    }
}
