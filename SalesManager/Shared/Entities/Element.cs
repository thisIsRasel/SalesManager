using System.ComponentModel.DataAnnotations;

namespace SalesManager.Shared.Entities;
public class Element : BaseEntity
{
    [Required]
    public string Type { get; set; } = default!;

    [Range(1, int.MaxValue, ErrorMessage = "Width must be a positive number")]
    public double Width { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Height must be a positive number")]
    public double Height { get; set; }
}
