using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        /// <summary>
        /// Tüm kayıtları getirir.
        /// </summary>
        /// <returns>Kurs Kayıt listesi</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _enrollmentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// ID'ye göre kayıtları getirir.
        /// </summary>
        /// <param name="id">Kayıt ID</param>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _enrollmentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Yeni kurs kaydı ekler.
        /// </summary>
        /// <param name="enrollment">Eklenecek kayıt nesnesi</param>
        [HttpPost]
        public IActionResult Add(Enrollment enrollment)
        {
            var result = _enrollmentService.Add(enrollment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        /// <summary>
        /// Mevcut kurs kaydını günceller.
        /// </summary>
        /// <param name="enrollment">Güncellenecek kayıt verisi</param>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Enrollment enrollment)
        {
            var result = _enrollmentService.Update(enrollment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Kurs kaydını siler.
        /// </summary>
        /// <param name="id">Kayıt ID</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enrollment = _enrollmentService.GetById(id);

            var result = _enrollmentService.Delete(enrollment.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Tüm kayıtların detaylarını getirir (öğrenci + kurs bilgisi ile birlikte).
        /// </summary>
        /// <returns>Kayıt detay listesi</returns>
        [HttpGet("details")]
        public IActionResult GetEnrollmentDetails()
        {
            var result = _enrollmentService.GetEnrollmentDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
