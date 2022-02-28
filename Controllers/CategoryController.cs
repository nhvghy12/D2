using D2.Data.Repositories;
using D2.Models;
using D2.Services;
using Microsoft.AspNetCore.Mvc;

namespace D2.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{

    private readonly ILogger<StudentController> _logger;
    private readonly ICategoryRepository _repository;
    // private readonly ICategoryService _categoryService;

    public CategoryController(ILogger<StudentController> logger, ICategoryRepository repository)
    {
        _logger = logger;
        // _categoryService = categoryService;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await _repository.GetAllIncludedAsync();
        var results = from item in entities
                      select new CategoryViewModel
                      {
                          Id = item.Id,
                          Name = item.Name,
                          Products = from p in item.Products
                                     select new ProductViewModel
                                     {
                                         Id = p.Id,
                                         Name = p.Name,
                                         Manufacture = p.Manufacture
                                     }

                      };
        return new JsonResult(results);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        // var entity = await _studentService.GetOneAsync(id);
        // if (entity == null) return NotFound();
        // return new JsonResult(new StudentViewModel
        // {
        //     Id = entity.Id,
        //     FullName = $"{entity.LastName} {entity.FirstName}",
        //     City = entity.City
        // });
        throw new NotImplementedException();

    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Category
            {
                Name = model.Name,
                Products = (from p in model.Products
                            select new Data.Entities.Product
                            {
                                Name = p.Name,
                                Manufacture = p.Manufacture
                            }).ToList()

            };
            var result = await _repository.InsertAsync(entity);
            return new JsonResult(new CategoryViewModel
            {
                Id =result.Id,
                Name = result.Name,
                Products = from p in result.Products
                            select new ProductViewModel
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Manufacture = p.Manufacture
                            }
            });

        }
        catch (Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        throw new NotImplementedException();
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, CategoryCreateModel model)
    {
        throw new NotImplementedException();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
