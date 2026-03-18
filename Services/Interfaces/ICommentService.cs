using PostCommentAPI.Common.Result;
using PostCommentAPI.Dtos;

namespace PostCommentAPI.Services;

public interface ICommentService
{
  Task<Result<CommentResponseDto>> CreateAsync(CreateCommentDto dto, CancellationToken cancellationToken);
  Task<Result<CommentResponseDto>> UpdateAsync(Guid id, CommentUpdateDto dto, CancellationToken cancellationToken);
  Task<Result<CommentResponseDto>> GetCommentById(Guid commentId, CancellationToken cancellationToken);
  Task<Result<IEnumerable<CommentResponseDto>>> GetCommentByUserId(Guid userId, CancellationToken cancellationToken);
}