using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Web.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonManagerContext _context;

    public PersonController(PersonManagerContext context)
    {
        _context = context;
    }

    [Route("{id:int}")]
    [HttpGet]
    public ActionResult<PersonViewModel> GetById(int id)
    {

        var person = _context.People.Find(id);
        if (person == null)
            return NotFound();

        var viewModel = new PersonViewModel
        {
            FirstName = person.FirstName,
            LastName = person.LastName
        };

        //return Ok(new PersonViewModel());
        return Ok(viewModel);
    }

    [Route("all")]
    [HttpGet]
    public ActionResult<IEnumerable<PersonViewModel>> GetAll()
    {

        var people = _context.People
        .Select(person => new PersonViewModel
        {
            FirstName = person.FirstName,
            LastName = person.LastName
        })
        .ToList();

        return Ok(people);

    }

}