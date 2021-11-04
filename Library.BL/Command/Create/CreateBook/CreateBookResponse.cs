using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Create.CreateBook
{
    /// <summary>
    /// DTO книги.
    /// </summary>
    public class CreateBookResponse
    {
        /// <summary>
        /// Хранит идентификатор книги.
        /// </summary>
        public Guid BookId { get; set; }
    }
}
