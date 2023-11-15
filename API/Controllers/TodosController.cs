using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
  [Route("todo")]
  public class TodosController : Controller
  {
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
      _todoService = todoService;
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
      var result = _todoService.GetAll();

      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }

    [HttpGet("get-all-by-tag")]
    public IActionResult GetAllByTag(string tag)
    {
      var result = _todoService.GetAllByTag(tag);

      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }

    [HttpPost("toggle-completed")]
    public IActionResult ToggleCompleted([FromBody] Guid id)
    {
      var result = _todoService.ToggleCompleted(id);
      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] TodoDto todo)
    {
      var result = _todoService.Add(todo);

      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }
  }
}
