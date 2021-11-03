using Library.BL.Command.Create.CreatePublisher;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с издателями.
    /// </summary>
    public class PublisherController : Controller
    {
        private readonly IMediator _mediator;
        public PublisherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Publisher/CreatePublisher")]
        public async Task<IActionResult> CreatePublications([FromForm] CreatePublisherRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
