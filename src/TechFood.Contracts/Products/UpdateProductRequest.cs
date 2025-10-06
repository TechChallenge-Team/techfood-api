using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TechFood.Contracts.Common.Attributes;

namespace TechFood.Contracts.Products;

public record UpdateProductRequest(
    [Required] string Name,
    [Required] string Description,
    [Required] Guid CategoryId,
    [Required] decimal Price,
    [MaxFileSize(5 * 1024 * 1024), AllowedExtensions(".jpg", ".jpeg", ".png", ".webp")] IFormFile File);
