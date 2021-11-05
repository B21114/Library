using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Querises.ReadBookById
{
    /// <summary>
    /// DTO для сущности книги.
    /// </summary>
    public class BookDetailsDto
    {
        /// <summary>
        /// Информация о книге Dto.
        /// </summary>
        public string BookFullInfo { get; set; }

        /// <summary>
        /// ФИО автора Dto.
        /// </summary>
        public string AuthorFullInfo { get; set; }

        /// <summary>
        /// Издатель книги.
        /// </summary>
        public string PublisherFullInfo { get; set; }
    }
}
