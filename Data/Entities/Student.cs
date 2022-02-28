using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D2.Data.Entities;

// [Table("Student")]
public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    [Required, MaxLength(50)]
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public string? FirstName { get; set; }
    
    [Required, MaxLength(50)]
    public string? LastName { get; set; }
    
    [MaxLength(20)]
    public string? City { get; set; }

    [NotMapped]
    public string? State { get; set; }
    

}