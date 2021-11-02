using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Models
{
    public class Book
    {

        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public Guid IdAuthor { get; set; }

        /// <summary>
        /// Идентификатор издателя.
        /// </summary>
        public Guid IdPublisher { get; set; }

        /// <summary>
        /// Наименование книги.
        /// </summary>
        public string NameBook { get; set; }

        /// <summary>
        /// Количество страниц книги.
        /// </summary>
        public int NumberOfPagesBook { get; set; }
    }
}
