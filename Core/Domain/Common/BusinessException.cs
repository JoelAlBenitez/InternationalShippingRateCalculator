namespace Domain.Common;


public class BusinessException : Exception
{
    public BusinessErrorCode ErrorCode { get; }

    public BusinessException(BusinessErrorCode errorCode, string message)
        : base(message)
    {
        ErrorCode = errorCode;
    }

    public BusinessException(BusinessErrorCode errorCode, string message, Exception innerException)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}
