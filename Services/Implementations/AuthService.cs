using PostCommentAPI.Auth;
using PostCommentAPI.Common.Result;
using PostCommentAPI.Dtos.Auth;
using PostCommentAPI.Dtos.Users;
using PostCommentAPI.Models;

namespace PostCommentAPI.Services;

public sealed class AuhtService(IPasswordHasher passwordHasher, IUserRepository userRepository, ITokenProvider tokenProvider) : IAuhtService
{
  private readonly IPasswordHasher _passwordHasher = passwordHasher;
  private readonly IUserRepository _userRepository = userRepository;
  private readonly ITokenProvider _tokenProvider = tokenProvider;

  public async Task<Result<AuthResponseDto>> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetByUsernameAsync(request.UserName, cancellationToken);
    if (user is null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
      return Result<AuthResponseDto>.Failure("Invalid Credentials.");

    var token = _tokenProvider.Create(user);

    var userResponse = new UserDto
    {
      Id = user.Id,
      Username = user.Username,
      Email = user.Email,
      FirstName = user.FirstName,
      LastName = user.LastName
    };
    return Result<AuthResponseDto>.Success(new AuthResponseDto
    {
      AccessToken = token,
      User = userResponse,
    });
  }

  public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterRequestDto request, CancellationToken cancellationToken)
  {
    var existsUsername = await _userRepository.ExistsByUsernameAsync(request.Username, cancellationToken);
    if (existsUsername)
      return Result<AuthResponseDto>.Failure("The username is already in use.");

    var existsEmail = await _userRepository.ExistsByUsernameAsync(request.Username, cancellationToken);
    if (existsEmail)
      return Result<AuthResponseDto>.Failure("There is already an account with that email address.");

    var user = new User
    {
      Username = request.Username,
      FirstName = request.FirstName,
      LastName = request.LastName,
      Email = request.Email,
      PasswordHash = _passwordHasher.HashPassword(request.Password)
    };

    var userResponse = new UserDto
    {
      Id = user.Id,
      Username = user.Username,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Email = user.Email
    };

    var token = _tokenProvider.Create(user);

    await _userRepository.AddAsync(user, cancellationToken);
    await _userRepository.SaveChangeAsync(cancellationToken);
    return Result<AuthResponseDto>.Success(new AuthResponseDto
    {
      AccessToken = token,
      User = userResponse
    });
  }

  public Task LogoutAsync(Guid userId)
  {
    throw new NotImplementedException();
  }

  public Task<Result<AuthResponseDto>> RefreshTokenAsync(string refreshToken)
  {
    throw new NotImplementedException();
  }


}