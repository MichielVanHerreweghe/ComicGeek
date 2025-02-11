namespace ComicGeek.Domain.Common;

public class Result
{
    private readonly bool _isSuccess;
    private readonly string? _error;

    public bool IsSuccess => _isSuccess;
    public bool IsFailure => !_isSuccess;
    public string? Error => _error;

    protected Result(bool isSuccess, string? error)
    {
        if (isSuccess && error is not null)
            throw new InvalidOperationException();

        if (!isSuccess && error is null)
            throw new InvalidOperationException();

        _isSuccess = isSuccess;
        _error = error;
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }

    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default!, false, message);
    }

    public static Result Succeed()
    {
        return new Result(true, null);
    }

    public static Result<T> Succeed<T>(T value)
    {
        return new Result<T>(value, true, null);
    }
}

public class Result<T> : Result
{
    private readonly T _value;

    public T Value => _value;

    protected internal Result(T value, bool isSuccess, string? error)
        : base(isSuccess, error)
    {
        _value = value;
    }
}
