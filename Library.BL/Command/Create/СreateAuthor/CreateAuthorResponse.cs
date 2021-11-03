using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BL.Command.Create.CreateAuthor
{
    /// <summary>
    /// DTO автор книги.
    /// </summary>
    public class CreateAuthorResponse
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public Guid IdAuthor { get; set; }
    }
}
