using ExampleApi.Features.ExampleFeature.Models;
using ExampleApi.Features.ExampleFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Features.ExampleFeature.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : Controller
{
    private readonly IMediator _mediator;

    public ExampleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: ExampleController/Details/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FakedData>> Details(int id)
    {
        var queryResponse = await _mediator.Send(new ExampleQuery.Query(id));
        return queryResponse.Result != null ? Ok(queryResponse?.Result) : NotFound();
    }

    // POST: ExampleController/Create
    [HttpPost]
    public ActionResult<bool> Create([FromBody]string example)
    {
        return example == "Test" ? Ok(true) : BadRequest(false);
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
