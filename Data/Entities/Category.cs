using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D2.Data.Entities;

// [Table("Category")]
public class Category : BaseEntity
{
    

    [Required, MaxLength(50)]
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}