using D2.Models;
using D2.Services;
using Microsoft.AspNetCore.Mvc;

namespace D2.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{

    private readonly ILogger<StudentController> _logger;
    private readonly IStudentService _studentService;

    public StudentController(ILogger<StudentController> logger, IStudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await _studentService.GetAllAsync();
        var results = from item in entities
                      select new StudentViewModel
                      {
                          Id = item.Id,
                          FullName = $"{item.LastName} {item.FirstName}",
                          City = item.City
                      };
        return new JsonResult(results);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        var entity = await _studentService.GetOneAsync(id);
        if (entity == null) return NotFound();
        return new JsonResult(new StudentViewModel
        {
            Id = entity.Id,
            FullName = $"{entity.LastName} {entity.FirstName}",
            City = entity.City
        });

    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(StudentCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                State = model.State
            };
            var result = await _studentService.AddAsync(entity);
            return new JsonResult(result);

        }
        catch (Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, StudentCreateModel model)
    {
        try
        {
            var entity = await _studentService.GetOneAsync(id);
            if (entity == null) return NotFound();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.City = model.City;
            entity.State = model.State;

            var result = await _studentService.EditAsync(entity);
            return new JsonResult(result);

        }
        catch (Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var entity = await _studentService.GetOneAsync(id);
            if (entity == null) return NotFound();

            await _studentService.RemoveAsync(id);
            return Ok();

        }
        catch (Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
