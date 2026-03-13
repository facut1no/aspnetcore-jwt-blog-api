namespace PostCommentAPI.Common.Result;

public class Result<T> : Result
{
  public T? Value { get; }

  protected Result(T value) : base(true, string.Empty)
  {
    Value = value;
  }

  protected Result(string error) : base(false, error)
  {
    Value = default;
  }

  public static Result<T> Success(T value)
  {
    return new Result<T>(value);
  }

  public new static Result<T> Failure(string error)
  {
    return new Result<T>(error);
  }
}