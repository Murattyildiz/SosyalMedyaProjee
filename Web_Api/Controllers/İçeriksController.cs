using Business.Abstract;
using Core.Utulities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [HttpGet("getiçerikwithdetails")]
        public ActionResult GetDetails()
        {
            IDataResult<List<İçerikDetailDto>> result = _içerikService.GetİçerikDetails();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        //[HttpGet("getiçerikwithdetailsbyid")]
        //public ActionResult GetDetailsById(int id)
        //{
        //    IDataResult<İçerikDetailDto> result = _içerikService.GetİçerikDetailsById(id);
        //    return result.Success ? Ok(result) : BadRequest(result);
        //}

        //[HttpGet("getiçerikwithdetailsbyuserid")]
        //public ActionResult GetDetailsByUserId(int id)
        //{
        //    IDataResult<List<İçerikDetailDto>> result = _içerikService.GetİçerikDetailsByUserId(id);
        //    return result.Success ? Ok(result) : BadRequest(result);
        //}



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            IDataResult<List<İçerik>> result = _içerikService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            IDataResult<İçerik> result = _içerikService.GetEntityById(id);
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
        public IActionResult Delete(int id)
        {
            IResult result = _içerikService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
