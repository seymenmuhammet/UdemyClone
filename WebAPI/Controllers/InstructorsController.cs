using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        /// <summary>
        /// Tüm eğitmenleri getirir.
        /// </summary>
        /// <returns>Eğitmen listesi</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Yeni eğitmen ekler.
        /// </summary>
        /// <param name="instructor">Eklenecek eğitmen nesnesi</param>
        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            var result = _instructorService.Add(instructor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// ID'ye göre eğitmen getirir.
        /// </summary>
        /// <param name="id">Eğitmen ID</param>
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _instructorService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
