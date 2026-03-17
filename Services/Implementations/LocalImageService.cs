using PostCommentAPI.Common.Result;

namespace PostCommentAPI.Services;

public sealed class LocalImageService : IIMageService
{
  private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };

  public async Task DeleteImageAsync(string imageUrl)
  {
    if (string.IsNullOrEmpty(imageUrl))
      return;

    var filePath = Path.Combine("wwwroot", imageUrl.TrimStart('/'));
    if (File.Exists(filePath))
      File.Delete(filePath);
  }

  public async Task<Result<string>> SaveImageAsync(IFormFile file, CancellationToken cancellationToken)
  {
    if (file is null)
      return Result<string>.Failure("File is null");

    var extension = Path.GetExtension(file.FileName);
    if (string.IsNullOrEmpty(extension) || !_allowedExtensions.Contains(extension))
      return Result<string>.Failure("Unsupported file type. Allowed types are: .jpg, .jpeg, .png, .webp");

    var filename = $"{Guid.NewGuid()}{extension}";
    var filePath = Path.Combine("wwwroot/images", filename);

    using var stream = new FileStream(filePath, FileMode.Create);
    await file.CopyToAsync(stream, cancellationToken);

    return Result<string>.Success($"/images/{filename}");
  }
}