using DynamicDialogApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;
using System;

namespace DynamicDialogApi.Controllers
{
    [Route("api/[controller]")]
    public class ResponsesController : Controller
    {
        private IRepository _repository;

        public ResponsesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            string language;

            // supports en and sv. I don't bother with countries right now
            if (Request != null && ((FrameRequestHeaders)Request.Headers).HeaderAcceptLanguage.Count > 0)
            {
                language = ((FrameRequestHeaders)Request.Headers).HeaderAcceptLanguage[0];
                if(language != "sv" && language != "en")
                {
                    language = "sv";
                }
            }
            else
            {
                language = "sv";
            }

            if(String.IsNullOrEmpty(id))
            {
                return BadRequest("Not a valid id");
            }

            var result = _repository.GetResponse(id, language);

            if (result != null)
            {
                if (Response != null)
                {
                    ((FrameResponseHeaders)Response.Headers).HeaderContentLanguage = new Microsoft.Extensions.Primitives.StringValues(language);
                }
                    return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
