namespace Lab5.Domain.Entities.Result;

public abstract record VerifyPinCodeResult
{
    private VerifyPinCodeResult() { }

    public sealed record Success : VerifyPinCodeResult;

    public sealed record Failed : VerifyPinCodeResult;
}