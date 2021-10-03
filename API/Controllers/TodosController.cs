using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
  public class TodosController : Controller
  {
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
      _todoService = todoService;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("todo/get-all")]
    public IActionResult GetAll()
    {
      var result = _todoService.GetAll();

      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }

    [HttpPost("todo/add")]
    public IActionResult Add(Todo todo)
    {
      var result = _todoService.Add(todo);

      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }
  }
}
