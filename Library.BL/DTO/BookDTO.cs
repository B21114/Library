using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DL.Domain.Entities
{
    /// <summary>
    /// DTO книги.
    /// </summary>
    public class BookDTO
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Aвтор книги.
        /// </summary>
        public AuthorDTO Author { get; set; }

        /// <summary>
        /// Издатель книги.
        /// </summary>
        public Publisher Publisher { get; set; }

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
