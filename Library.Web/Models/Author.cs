using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Models
{
    public class Author
    {
        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Имя автора.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Отчество автора.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Деятельность автора.
        /// </summary>
        public string Activity { get; set; }
    }
}
