using Microsoft.AspNetCore.Mvc;
using PostCommentAPI.Services;

namespace PostCommentAPI.Controllers;

[ApiController]
[Route("api/comments")]
public sealed class CommentController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService _commentService = commentService;
    [HttpGet("{commentId:guid}")]
    public async Task<IActionResult> GetByCommentIdAsync(
        Guid commentId,
        CancellationToken cancellationToken)
    {
        var result = await _commentService.GetCommentById(commentId, cancellationToken);
        if (!result.IsSuccess)
            return BadRequest();
        
        return Ok(result.Value);
    }

    [HttpGet("{postId:guid}/comments")]
    public async Task<IActionResult> GetCommentsByPostIdAsync(
        Guid postId,
        CancellationToken cancellationToken)
    {
        var result = await _commentService.GetCommentByPostId(postId, cancellationToken);
        if(!result.IsSuccess)
            return BadRequest(result.Error);
        
        return Ok(result.Value);
    }

    [HttpDelete("{commentId:guid}")]
    public async Task<IActionResult> DeleteComment(
        Guid commentId,
        CancellationToken cancellationToken)
    {
        var result = await _commentService.DeleteCommentById(commentId, cancellationToken);
        if(!result.IsSuccess)
            return BadRequest(result.Error);
        
        return Ok(result.Value);
    }
}