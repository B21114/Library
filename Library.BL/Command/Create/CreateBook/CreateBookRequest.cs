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
    public class CreateBookRequest : IRequest<CreateBookResponse>
    {
   
        /// <summary>
        /// Aвтор книги.
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Издатель книги.
        /// </summary>
        public Guid PublisherId { get; set; }

        /// <summary>
        /// Наименование книги.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество страниц книги.
        /// </summary>
        public int NumberOfPages { get; set; }
    }
}
