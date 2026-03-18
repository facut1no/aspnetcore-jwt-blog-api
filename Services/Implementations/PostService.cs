using PostCommentAPI.Common.Result;
using PostCommentAPI.Dtos;
using PostCommentAPI.Models;
using PostCommentAPI.Repositories;

namespace PostCommentAPI.Services;

public sealed class PostsService(IPostRepository postRepository, IIMageService iMageService) : IPostService
{
  private readonly IPostRepository _postRepository = postRepository;
  private readonly IIMageService _imageService = iMageService;
  public async Task<Result<ResponsePostDto>> CreateAsync(CreatePostDto dto, CancellationToken cancellationToken)
  {
    var post = new Post
    {
      Title = dto.Title,
      Content = dto.Content,
    };

    if (dto.ImageFile is not null)
    {
      var result = await _imageService.SaveImageAsync(dto.ImageFile, cancellationToken);
      if (!result.IsSuccess)
        return Result<ResponsePostDto>.Failure(result.Error);

      post.ImageUrl = result.Value!;
    }

    var postDb = await _postRepository.AddAsync(post, cancellationToken);
    if (postDb is null)
      return Result<ResponsePostDto>.Failure("Database Error.");

    await _postRepository.SaveChangeAsync(cancellationToken);

    var postResponse = ToDto(postDb);

    return Result<ResponsePostDto>.Success(postResponse);
  }

  public async Task<Result<IEnumerable<ResponsePostDto>>> GetAllPostByUserId(Guid userId, CancellationToken cancellationToken)
  {
    var posts = await _postRepository.GetByUserIdAsync(userId, cancellationToken);

    var postDtos = posts.Select(p => ToDto(p));

    return Result<IEnumerable<ResponsePostDto>>.Success(postDtos);
  }

  public async Task<Result<ResponsePostDto>> GetPostById(Guid postId, CancellationToken cancellationToken)
  {
    var post = await _postRepository.GetByIdAsync(postId, cancellationToken);
    if (post is null)
      return Result<ResponsePostDto>.Failure("Not Found.");

    var postResponse = ToDto(post);

    return Result<ResponsePostDto>.Success(postResponse);
  }

  public async Task<Result<ResponsePostDto>> UpdateAsync(Guid id, UpdatePostDto dto, CancellationToken cancellationToken)
  {
    var post = await _postRepository.GetByIdAsync(id, cancellationToken);
    if (post is null)
      return Result<ResponsePostDto>.Failure("Not found");

    if (!string.IsNullOrEmpty(dto.Title))
      post.Title = dto.Title;

    if (!string.IsNullOrEmpty(dto.Content))
      post.Content = dto.Content;

    if (dto.ImageFile is not null)
    {
      var result = await _imageService.SaveImageAsync(dto.ImageFile, cancellationToken);
      if (!result.IsSuccess)
        return Result<ResponsePostDto>.Failure(result.Error);

      if (!string.IsNullOrEmpty(post.ImageUrl))
        await _imageService.DeleteImageAsync(post.ImageUrl);

      post.ImageUrl = result.Value!;
    }

    await _postRepository.SaveChangeAsync(cancellationToken);

    var postResponse = ToDto(post);

    return Result<ResponsePostDto>.Success(postResponse);
  }

  private static ResponsePostDto ToDto(Post post) => new()
  {
    Id = post.Id,
    Title = post.Title,
    Content = post.Content,
    ImageUrl = post.ImageUrl,
    CreateAt = post.CreatedAt,
    UpdateAt = post.UpdatedAt,
    UserId = post.UserId,
  };
}