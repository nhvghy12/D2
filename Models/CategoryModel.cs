using System.ComponentModel.DataAnnotations;

namespace D2.Models;
public class CategoryViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<ProductViewModel>? Products { get; set; }
}
public class CategoryCreateModel
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }

    public IEnumerable<ProductCreateModel>? Products { get; set; }
}

