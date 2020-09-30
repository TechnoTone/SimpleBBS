using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBBS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BBSController : ControllerBase
    {
        private readonly IBBService bbService;

        public BBSController(IBBService bbService) =>
            this.bbService = bbService;

        [HttpGet]
        public IEnumerable<Post> GetAll() =>
            bbService.GetAllPosts();

        [HttpPost]
        public ActionResult<Post> AddPost([FromBody] AddPostPayload payload) =>
            CreatedAtRoute(string.Empty, bbService.Post(payload.UserName, payload.Message));
    }

    public struct AddPostPayload
    {
        [field: Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}
