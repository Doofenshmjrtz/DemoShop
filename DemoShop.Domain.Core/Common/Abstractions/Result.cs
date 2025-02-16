namespace DemoShop.Domain.Core.Common.Abstractions;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; private set; }
    
    private Result(bool isSuccess, Error error)
    {
        if(isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));
        
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Success() => new (true, Error.None);
    
    public static Result Failure(Error error) => new (false, error);
}


public class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T Value { get; private set; }
    public Error Error { get; private set; }
    
    private Result(T value, bool isSuccess, Error error)
    {
        if(isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));
        
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }
    
    public static Result<T> Success(T value) => new (value, true, Error.None);
    
    public static Result<T> Failure(Error error) => new (default!, false, error);
}