using PostCommentAPI.Common.Result;
using PostCommentAPI.Dtos;
using PostCommentAPI.Models;

namespace PostCommentAPI.Services;

public interface IPostService
{
  Task<Result<ResponsePostDto>> CreateAsync(CreatePostDto dto, CancellationToken cancellationToken);
  Task<Result<ResponsePostDto>> UpdateAsync(Guid id, UpdatePostDto dto, CancellationToken cancellationToken);
  Task<Result<ResponsePostDto>> GetPostById(Guid postId, CancellationToken cancellationToken);
  Task<Result<IEnumerable<ResponsePostDto>>> GetAllPostByUserId(Guid userId, CancellationToken cancellationToken);
}