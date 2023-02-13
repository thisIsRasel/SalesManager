using System.ComponentModel.DataAnnotations;

namespace SalesManager.Shared.Entities;
public class Order : BaseEntity
{
    [Required(ErrorMessage = "Order name is required.")]
    public string Name { get; set; } = default!;

    [Required]
    public string State { get; set; } = default!;

    [ValidateComplexType]
    public List<Window> Windows { get; set; } = new();
}
