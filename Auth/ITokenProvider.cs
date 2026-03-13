using PostCommentAPI.Models;

namespace PostCommentAPI.Auth;

public interface ITokenProvider
{
  string Create(User user);
}