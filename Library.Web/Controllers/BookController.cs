﻿using Library.BL.Command.Create.CreateBook;
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
        public async Task<IActionResult> CreatePublications([FromForm] CreateBookRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
