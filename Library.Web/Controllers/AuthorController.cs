using Library.BL.Command.Create.CreateAuthor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с авторами.
    /// </summary>
    public class AuthorController : Controller
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Author/CreateAuthor")]
        public async Task<IActionResult> CreatePublications([FromForm] CreateAuthorRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
