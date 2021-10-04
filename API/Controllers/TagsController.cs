using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
  [Route("tag")]
  public class TagsController : Controller
  {
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
      _tagService = tagService;
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
      var result = _tagService.GetAll();

      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] TagDto tag)
    {
      var result = _tagService.Add(tag);

      if (!result.IsSuccess)
        return BadRequest(result);

      return Ok(result);
    }
  }
}
