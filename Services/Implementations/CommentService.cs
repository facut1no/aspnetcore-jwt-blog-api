using PostCommentAPI.Common.Result;
using PostCommentAPI.Dtos;
using PostCommentAPI.Models;
using PostCommentAPI.Repositories;

namespace PostCommentAPI.Services;


public sealed class CommentService(ICommentRepository commentRepository) : ICommentService
{
  private readonly ICommentRepository _commentRepository = commentRepository;
  public async Task<Result<CommentResponseDto>> CreateAsync(CreateCommentDto dto, CancellationToken cancellationToken)
  {
    var comment = new Comment
    {
      Content = dto.Content,
    };

    var commentDb = await _commentRepository.AddAsync(comment, cancellationToken);
    if (commentDb is null)
      return Result<CommentResponseDto>.Failure("Database error");

    await _commentRepository.SaveChangeAsync(cancellationToken);

    var responseDto = new CommentResponseDto
    {
      Id = commentDb.Id,
      Content = commentDb.Content,
    };

    return Result<CommentResponseDto>.Success(responseDto);

  }

  public Task<Result<CommentResponseDto>> GetCommentById(Guid commentId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<Result<IEnumerable<CommentResponseDto>>> GetCommentByUserId(Guid userId, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<Result<CommentResponseDto>> UpdateAsync(Guid id, CommentUpdateDto dto, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}