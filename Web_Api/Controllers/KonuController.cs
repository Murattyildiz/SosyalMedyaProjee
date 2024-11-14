using Business.Abstract;
using Core.Utulities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utulities.Result.Abstract.IResult;
namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonuController : ControllerBase
    {
        private readonly IKonuService _konuService;

        public KonuController(IKonuService konuService) => _konuService = konuService ?? throw new System.ArgumentNullException(nameof(konuService));

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            IDataResult<List<Konu>> result = _konuService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            IDataResult<Konu> result = _konuService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Konu konu)
        {
            IResult result = _konuService.Add(konu);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Konu konu)
        {
            IResult result = _konuService.Update(konu);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Konu konu)
        {
            IResult result = _konuService.Delete(konu);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }

}
