using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace D2.Data.Entities;

// [Table("Category")]
public class Product : BaseEntity
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }

    [Required, MaxLength(100)]
    public string? Manufacture { get; set; }
    // Relationship
    [Required]
    public int CategoryId { get; set; }
    [JsonIgnore]
    public virtual Category? Category {get; set;}
}