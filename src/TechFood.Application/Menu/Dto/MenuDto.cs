using System.Collections.Generic;

namespace TechFood.Application.Menu.Dto;

public class MenuDto
{
    public IEnumerable<CategoryDto> Categories { get; set; } = [];
}
