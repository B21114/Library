using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DL.Domain.Entities
{
    /// <summary>
    /// DTO автор книги.
    /// </summary>
    public class AuthorDTO
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Отчество автора.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Деятельность автора.
        /// </summary>
        public string Activity { get; set; }
    }
}
