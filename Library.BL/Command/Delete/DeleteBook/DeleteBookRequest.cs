using Library.DL.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Create.CreateBook
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteBookRequest : IRequest<DeleteBookResponse>
    {

        /// <summary>
        /// Хранит идентификатор книги.
        /// </summary>
        public Guid IdBook { get; set; }
    }
}
