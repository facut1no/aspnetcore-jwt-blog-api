using PostCommentAPI.Common.Result;

namespace PostCommentAPI.Services;

public interface IIMageService
{
  Task<Result<string>> SaveImageAsync(IFormFile file, CancellationToken cancellationToken);
  Task DeleteImageAsync(string imageUrl);
}