using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.ViewModels;
//using UKParliament.CodeTest.Web.ViewModels;

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

        try
        {
            var person = new PersonService(_context).getById(id);
            if (person == null)
                return NotFound();

            //var viewModel = new PersonViewModel
            //{
            //    FirstName = person.FirstName,
            //    LastName = person.LastName
            //};

            return Ok(new MappingService().MapToViewModel(person));

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Route("all")]
    [HttpGet]
    public ActionResult<IEnumerable<PersonViewModel>> GetAll()
    {

        try
        {
            var people = new PersonService(_context).getAll();
            return Ok(people);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public ActionResult<IEnumerable<PersonViewModel>> Save(PersonViewModel person)
    {

        try
        {
            new PersonService(_context).Save(new Person { FirstName = person.FirstName, LastName = person.LastName });
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

}