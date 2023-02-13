using System.ComponentModel.DataAnnotations;

namespace SalesManager.Shared.Entities;
public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = default!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
