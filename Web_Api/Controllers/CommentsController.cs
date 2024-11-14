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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService) => _commentService = commentService ?? throw new System.ArgumentNullException(nameof(commentService));

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           IDataResult<List<Comment>> result = _commentService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            IDataResult<Comment> result = _commentService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Comment comment)
        {
            IResult result = _commentService.Add(comment);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Comment comment)
        {
            IResult result = _commentService.Update(comment);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Comment comment)
        {
            IResult result = _commentService.Delete(comment);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
