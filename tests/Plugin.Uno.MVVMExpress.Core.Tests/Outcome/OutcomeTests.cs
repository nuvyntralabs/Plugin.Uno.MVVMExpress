using Plugin.Uno.MVVMExpress.Errors;
using Plugin.Uno.MVVMExpress.Outcome;

namespace Plugin.Uno.MVVMExpress.Core.Tests.Outcome;

public sealed class OutcomeTests
{
    [Fact]
    public void Success_HasNoError()
    {
        var result = Plugin.Uno.MVVMExpress.Outcome.Outcome.Success();
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
    }

    [Fact]
    public void Failure_HasCodeAndMessage()
    {
        var result = Plugin.Uno.MVVMExpress.Outcome.Outcome.Failure("E_NET", "offline");
        Assert.False(result.IsSuccess);
        Assert.Equal("E_NET", result.Error?.Code);
        Assert.Equal("offline", result.Error?.Message);
    }

    [Fact]
    public void GenericSuccess_HoldsValue()
    {
        var result = Outcome<int>.Success(9);
        Assert.True(result.IsSuccess);
        Assert.Equal(9, result.Value);
    }

    [Fact]
    public void GenericFailure_HasNoValue()
    {
        var result = Outcome<int>.Failure("E", "no");
        Assert.False(result.IsSuccess);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public async Task NullErrorSink_AcceptsError()
    {
        await NullErrorSink.Instance.HandleAsync(new ErrorInfo("E", "msg"));
    }

    [Fact]
    public void ErrorInfo_RejectsEmptyCode()
        => Assert.Throws<ArgumentException>(() => new ErrorInfo("", "msg"));

    [Fact]
    public void Failure_NullError_Throws()
        => Assert.Throws<ArgumentNullException>(() =>
            Plugin.Uno.MVVMExpress.Outcome.Outcome.Failure((ErrorInfo)null!));

    [Fact]
    public void ErrorInfo_RejectsEmptyMessage()
        => Assert.Throws<ArgumentException>(() => new ErrorInfo("E", ""));

    [Fact]
    public void GenericFailure_NullError_Throws()
        => Assert.Throws<ArgumentNullException>(() => Outcome<int>.Failure((ErrorInfo)null!));
}
