using System.ComponentModel.DataAnnotations;

namespace SalesManager.Shared.Entities;
public class Window : BaseEntity
{
    [Required(ErrorMessage = "Window name is required.")]
    public string Name { get; set; } = default!;

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
    public int Quantity { get; set; } = default!;

    [ValidateComplexType]
    public List<Element> SubElements { get; set; } = new();
}
