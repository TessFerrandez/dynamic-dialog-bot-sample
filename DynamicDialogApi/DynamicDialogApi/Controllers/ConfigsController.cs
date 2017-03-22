using DynamicDialogApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;
using System;

namespace DynamicDialogApi.Controllers
{
    [Route("api/[controller]")]
    public class ConfigsController : Controller
    {
        private IRepository _repository;

        public ConfigsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string language;

            // supports en and sv. I don't bother with countries right now
            if (Request != null)
            {
                language = ((FrameRequestHeaders)Request.Headers).HeaderAcceptLanguage[0];
                if (language != "sv" && language != "en")
                {
                    language = "sv";
                }
            }
            else
            {
                language = "sv";
            }

            var result = _repository.GetConfig(language);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
