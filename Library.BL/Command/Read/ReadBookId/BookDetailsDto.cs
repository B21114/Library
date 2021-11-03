using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Read.ReadBookId
{
    /// <summary>
    /// DTO для сущности книги.
    /// </summary>
    public class BookDetailsDto
    {
        /// <summary>
        /// Идентификатор контента.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование книги.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество страниц книги.
        /// </summary>
        public int NumberOfPages { get; set; }

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
