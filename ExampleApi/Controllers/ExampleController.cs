using ExampleApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : Controller
{
    // GET: ExampleController/Details/5
    [HttpGet("{id}")]
    public ActionResult<ExampleResponse> Details(int id)
    {
        return id switch
        {
            1 => Ok(new ExampleResponse() { Example = "Example1" }),
            2 => Ok(new ExampleResponse() { Example = "Example2" }),
            3 => Ok(new ExampleResponse() { Example = "Example3" }),
            _ => NotFound()
        };
    }

    // POST: ExampleController/Create
    [HttpPost]
    public ActionResult Create()
    {
        return Ok(true);
    }

    // POST: ExampleController/Edit/5
    [HttpPut]
    public ActionResult Edit(int id)
    {
        return Ok(true);
    }

    // POST: ExampleController/Delete/5
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        return Ok(true);
    }
}
