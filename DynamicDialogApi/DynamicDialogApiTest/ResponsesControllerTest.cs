using DynamicDialogApi.Controllers;
using DynamicDialogApi.Interfaces;
using DynamicDialogCore.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;
using Moq;
using System;
using Xunit;

namespace DynamicDialogApiTest
{
    public class ResponsesControllerTest
    {
        [Fact]
        public void RepositoryReturnsAResponseWhenValidIdIsGiven()
        {
            var repository = new Mock<IRepository>();
            repository.Setup(r => r.GetResponse(It.IsAny<string>(), It.IsAny<string>())).Returns(new Response());

            var responsesController = new ResponsesController(repository.Object);
            var result = responsesController.Get(Guid.NewGuid().ToString());

            repository.Verify(r => r.GetResponse(It.IsAny<string>(), It.IsAny<string>()));
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Response>(((OkObjectResult)result).Value);
        }

        [Fact]
        public void EmptyResponsesReturnNotFound()
        {
            var repository = new Mock<IRepository>();

            var responsesController = new ResponsesController(repository.Object);
            var result = responsesController.Get();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void NotFoundReturnedWhenResponseNotInDatabase()
        {
            var repository = new Mock<IRepository>();
            repository.Setup(r => r.GetResponse(It.IsAny<string>(), It.IsAny<string>())).Returns((Response)null);

            var responsesController = new ResponsesController(repository.Object);
            var result = responsesController.Get(Guid.NewGuid().ToString());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void ReturnBadRequestIfNotValidGuidId()
        {
            var repository = new Mock<IRepository>();

            var responsesController = new ResponsesController(repository.Object);
            var result = responsesController.Get(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
