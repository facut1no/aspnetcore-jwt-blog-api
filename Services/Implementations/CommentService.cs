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

  public async Task<Result<CommentResponseDto>> GetCommentById(Guid commentId, CancellationToken cancellationToken)
  {
      var post = await _commentRepository.GetByIdAsync(commentId, cancellationToken);
      if (post is null)
        return Result<CommentResponseDto>.Failure("Not found");

      var commentResponse = new CommentResponseDto
      {
        Id = post.Id,
        Content = post.Content,
      };
      
      return Result<CommentResponseDto>.Success(commentResponse);
  }

  public async Task<Result<IEnumerable<CommentResponseDto>>> GetCommentByPostId(Guid postId, CancellationToken cancellationToken)
  {
    var comments = await _commentRepository.GetRootCommentsByPostId(postId, cancellationToken);
    var commentsResponse = comments.Select(c => new CommentResponseDto
    {
      Id = c.Id,
      Content = c.Content,
    });
    return Result<IEnumerable<CommentResponseDto>>.Success(commentsResponse);
  }

  public async Task<Result<IEnumerable<CommentResponseDto>>> GetCommentByUserId(Guid userId, CancellationToken cancellationToken)
  {
    var comments = await _commentRepository.GetByUserId(userId, cancellationToken);
    var commentResponseDtos = comments.Select(c => new CommentResponseDto
      {
        Id = c.Id,
        Content = c.Content,
      }
    );
      
    return Result<IEnumerable<CommentResponseDto>>.Success(commentResponseDtos);
  }

  public async Task<Result<CommentResponseDto>> DeleteCommentById(Guid commentId, CancellationToken cancellationToken)
  {
    var comment = await _commentRepository.GetByIdAsync(commentId, cancellationToken);
    if (comment is null)
      return Result<CommentResponseDto>.Failure("Not found");
    _commentRepository.SoftDelete(comment);
    return Result<CommentResponseDto>.Success(new CommentResponseDto
    {
      Id = comment.Id,
      Content = comment.Content,
    });
  }

  public async Task<Result<CommentResponseDto>> UpdateAsync(Guid id, CommentUpdateDto dto, CancellationToken cancellationToken)
  {
    var comment = await _commentRepository.GetByIdAsync(id, cancellationToken);
    if(comment is null)
        return Result<CommentResponseDto>.Failure("Not Found");
    
    if(dto.Content is not null)
        comment.Content = dto.Content;
    
    await _commentRepository.SaveChangeAsync(cancellationToken);

    var response = new CommentResponseDto
    {
      Id = comment.Id,
      Content = comment.Content,
    };
    
    return Result<CommentResponseDto>.Success(response);
  }
}