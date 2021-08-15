namespace Domain.Ports.In.Result
{
    public class DomainRequestResult
    {
        public DomainRequestResultStatuses Status { get; private set; }
        public List<DomainRequestResultError> Errors { get; private set; }

        public DomainRequestResult() : this(DomainRequestResultStatuses.Undefined, new List<DomainRequestResultError>()) { }
        public DomainRequestResult(DomainRequestResultStatuses status) : this(status, new List<DomainRequestResultError>()) { }
        public DomainRequestResult(List<DomainRequestResultError> errors) : this(DomainRequestResultStatuses.Undefined, errors) { }
        public DomainRequestResult(DomainRequestResultStatuses status, List<DomainRequestResultError> errors)
        {
            Status = status;
            Errors = errors;
        }

        public static DomainRequestResult Ok() => new(DomainRequestResultStatuses.Success);

        public void SetStatus(DomainRequestResultStatuses status)
        {
            Status = status;
        }

        public void SetErrors(List<DomainRequestResultError> errors)
        {
            Errors = errors;
        }
    }

    public class DomainRequestResult<TResult> : DomainRequestResult
    {
        public readonly TResult Data;

        public DomainRequestResult(TResult data)
        {
            Data = data;
        }

        public static DomainRequestResult<TResult> Ok(TResult data)
        {
            var result = new DomainRequestResult<TResult>(data);
            result.SetStatus(DomainRequestResultStatuses.Success);
            return result;
        }
    }
}
