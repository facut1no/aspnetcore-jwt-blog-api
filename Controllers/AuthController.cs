using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PostCommentAPI.Dtos.Auth;
using PostCommentAPI.Services;

namespace PostCommentAPI.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(IAuhtService auhtService) : ControllerBase
{
  private readonly IAuhtService _authSerive = auhtService;

  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto, CancellationToken cancellationToken)
  {
    if (!ModelState.IsValid)
      return BadRequest();

    var result = await _authSerive.RegisterAsync(dto, cancellationToken);

    if (!result.IsSuccess)
      return BadRequest(result.Error);

    return Created("", result.Value);
  }

  [HttpPost]
  [Route("login")]
  public async Task<IActionResult> Login([FromBody] LoginRequestDto dto, CancellationToken cancellationToken)
  {
    if (!ModelState.IsValid)
      return BadRequest();

    var result = await _authSerive.LoginAsync(dto, cancellationToken);

    if (!result.IsSuccess)
      return BadRequest(result.Error);

    return Ok(result.Value);
  }

}