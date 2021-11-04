using Library.BL.Command.Create.CreateBook;
using Library.BL.Command.Delete.DeleteBook;
using Library.BL.Command.Read.ReadBookId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Library.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с книгами.
    /// </summary>
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Book/CreateBook")]
        public async Task<IActionResult> CreateBook(CreateBookRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Book/DeleteBook")]
        public async Task<IActionResult> DeleteBook(DeleteBookRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("Book/GetBook")]
        public async Task<IActionResult> GetBook(ReadBookByIdRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
