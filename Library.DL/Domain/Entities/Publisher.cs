using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DL.Domain.Entities
{
    /// <summary>
    /// Класс издателя.
    /// </summary>
    public class Publisher
    {
        /// <summary>
        /// Идентификатор издателя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование издателя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Город издателя.
        /// </summary>
        public string Sity { get; set; }
    }
}
