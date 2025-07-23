using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Services;
using UKParliament.CodeTest.ViewModels;

namespace UKParliament.CodeTest.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {

        private readonly DepartmentManagerContext _context;

        public DepartmentController(DepartmentManagerContext context)
        {
            _context = context;
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentViewModel>> GetAll()
        {

            try
            {
                var departments = new DepartmentService(_context).GetAll();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
