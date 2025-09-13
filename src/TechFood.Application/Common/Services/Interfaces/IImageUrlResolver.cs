namespace TechFood.Application.Common.Services.Interfaces;

public interface IImageUrlResolver
{
    string BuildFilePath(string folderName, string imageFileName);

    string CreateImageFileName(string categoryName, string contentType);
}
