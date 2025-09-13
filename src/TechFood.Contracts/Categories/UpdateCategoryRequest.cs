using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TechFood.Contracts.Common.Attributes;

namespace TechFood.Contracts.Categories;

public record UpdateCategoryRequest(
    [Required] string Name,
    [MaxFileSize(5 * 1024 * 1024), AllowedExtensions(".jpg", ".jpeg", ".png", ".webp")] IFormFile File);
