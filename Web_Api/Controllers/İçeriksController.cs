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
    public class İçeriksController : ControllerBase
    {
        private IİçerikService _içerikService;

        public İçeriksController(IİçerikService içerikService) => _içerikService = içerikService ?? throw new ArgumentException(nameof(içerikService));




        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            IDataResult<List<İçerik>> result = _içerikService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            IDataResult<İçerik> result = _içerikService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("add")]
        public IActionResult Add(İçerik içerik)
        {
            IResult result = _içerikService.Add(içerik);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("update")]
        public IActionResult Update(İçerik içerik)
        {
            IResult result = _içerikService.Update(içerik);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("delete")]
        public IActionResult Delete(İçerik içerik)
        {
            IResult result = _içerikService.Delete(içerik);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
