namespace Domain.Ports.In.Result
{
    public record DomainRequestResultError(string PropertyName, string ErrorCode, string ErrorDescription);
}
