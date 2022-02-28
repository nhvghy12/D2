using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D2.Data.Entities;
public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    [Required, MaxLength(50)]
    public int Id { get; set; }
    public DateTime? CreatedTime { get; set; }
    public string? Creator { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Modifier { get; set; }
}